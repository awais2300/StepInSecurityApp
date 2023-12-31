using SIS.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS.Model;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace SIS.Manager
{
    public class EmployeeManager
    {
        private DataAccess da = new DataAccess();

        public int SaveEmployee(Employee employee)
        {
            bool retrieve;
            int employeeID = 0;
            int vehicle_id = 0;

            try
            {
                //string insertCommand = "insert into Employee (ID_Card, First_Name, Last_Name, CNIC, P_Emp_id, status) values(@IDCard, @FirstName, @lastName, @CNIC,@pemplid, 'OP')";
                string insertCommand = "insert into Resident (House_no, First_Name, Last_Name, CNIC, Mobile_no, PTCL_no, Email_id, P_Emp_id, status) values(@IDCard, @FirstName, @lastName, @CNIC, @MobileNo, @PtclNo, @EmailID, @pemplid, 'OP')";
                insertCommand += "SELECT CAST(scope_identity() AS int)";


                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@IDCard", employee.Id_card),
                new SqlParameter("@FirstName", employee.First_name),
                new SqlParameter("@lastName", employee.Last_name),
                new SqlParameter("@CNIC", employee.CNIC),
                new SqlParameter("@MobileNo", DBNull.Value),
                new SqlParameter("@PtclNo", DBNull.Value),
                new SqlParameter("@EmailID", DBNull.Value),
                new SqlParameter("@pemplid",(object)employee.P_emp_id ?? DBNull.Value),
               };
                employeeID = int.Parse(da.ExecuteScalarQuery(insertCommand, CommandType.Text, parameters).ToString());
                employee.Emp_id = employeeID;
                if (employee.Vehicle != null && employee.Vehicle.Vehicle_reg != null)
                    if (employee.Vehicle.Vehicle_reg.Length > 0)
                    {
                        employee.Vehicle.Employee_id = employeeID;
                        VehicleManager vehMgr = new VehicleManager();
                        vehicle_id = vehMgr.SaveVehicle(employee.Vehicle);

                        //To Update the Vehicle ID of Employee (if any)
                        string updateCommand = "update Employee set veh_id = @veh_id where Emp_id = @empid";
                        SqlParameter[] parameters2 = new SqlParameter[]
                        {
                        new SqlParameter("@veh_id", vehicle_id),
                        new SqlParameter("@empid", employeeID),
                        };
                        da.ExecuteNonQuery(updateCommand, CommandType.Text, parameters2);
                    }

                PresistFamilyMem(employee.Family_mem, employeeID);
           
            }
            catch (Exception ex)
            {
                
            }

            return employeeID;
        }

        public int UpdateEmployee(Employee employee)
        {
            int employeeID = 0;

            try
            {
                string insertCommand = "update Employee SET ID_Card = @IDCard,First_Name =@FirstName,Last_Name =@lastName ,CNIC=@CNIC WHERE Emp_id = @empid ";
                //insertCommand += "SELECT CAST(scope_identity() AS int)";


                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@IDCard", employee.Id_card),
                    new SqlParameter("@FirstName", employee.First_name),
                    new SqlParameter("@lastName", employee.Last_name),
                    new SqlParameter("@CNIC", employee.CNIC),
                    new SqlParameter("@pemplid",(object)employee.P_emp_id ?? DBNull.Value),
                    new SqlParameter("@empid",(object)employee.Emp_id ?? DBNull.Value),       
                };

                ////SqlTransaction tr = new SqlTransaction();

                da.ExecuteNonQuery(insertCommand, CommandType.Text, parameters);

             
                if (employee.Vehicle.Vehicle_reg != null)// && employee.Vehicle.Vehicle_reg.Length > 0)
                {

                    VehicleManager vehMgr = new VehicleManager();
                    if (employee.Vehicle.RowState != Rowstate.None && employee.Vehicle.RowState != Rowstate.Modified)
                    {
                        employee.Vehicle.Employee_id = employee.Emp_id;
                        vehMgr.SaveVehicle(employee.Vehicle);

                        //To Update the Vehicle ID of Guest (if any)
                        string updateCommand = "update Employee set veh_id = @veh_id where Emp_id = @emp_id";
                        SqlParameter[] parameters2 = new SqlParameter[]
                    {
                    new SqlParameter("@veh_id", employeeID),
                    new SqlParameter("@emp_id",(object) employee.Emp_id ?? DBNull.Value),
                    };
                        da.ExecuteNonQuery(updateCommand, CommandType.Text, parameters2);
                    }
                    else
                    {
                        vehMgr.UpdateVehicle(employee.Vehicle);
                    }

                    if (employee.Family_mem != null)
                    {
                        PresistFamilyMem(employee.Family_mem, employee.Emp_id);
                    }

                   
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return employeeID;
        }

        public Employee GetEmpByCarId(string employeeCardID)
        {
            Employee result = new Employee();

            string sqlQuery = "select * from Employee where ID_Card = @idCard";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@idCard", employeeCardID),
                
            };
            List<Employee> emplcoll = ReadEmployee(sqlQuery, parameters);
            if (emplcoll != null && emplcoll.Count > 0)
            {
                result = emplcoll.First<Employee>();
                result.Family_mem = new List<Employee>();
                result.Family_mem = GetEmpBypEmpId(result.Emp_id);
            }
            return result;
        }

        public Employee GetEmpByCNIC(string pCnic)
        {
            Employee result = new Employee();

            string sqlQuery = "select * from Employee where CNIC = @pCnic";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@pCnic", pCnic),
                
            };
            List<Employee> emplcoll = ReadEmployee(sqlQuery, parameters);
            if (emplcoll != null && emplcoll.Count > 0)
                result = emplcoll.First<Employee>();
            result.Family_mem = new List<Employee>();
            result.Family_mem = GetEmpBypEmpId(result.Emp_id);

            return result;
        }
        public List<Employee> GetEmpBypEmpId(int p_emplid)
        {
            List<Employee> result = new List<Employee>();

            string sqlQuery = "select * from Employee where P_Emp_id = @p_emplid";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@p_emplid", p_emplid),
                
            };

            result = ReadEmployee(sqlQuery, parameters);

            return result;
        }

        public DataTable GetEmpNames()
        {
            DataTable result;
            string sqlQuery = "select e.* from Employee e, ENTRY_EXIT_DATA d where e.emp_id = d.employee_id and cnic_status = 'OP' and over_nightstay_status <> 'R' and isnull(e.status,'OP') <> 'CN'";
            result = da.ExecuteSelectCommand(sqlQuery, CommandType.Text);
            return result;
        }

        public DataTable GetEmpNamesForVisit()
        {
            DataTable result;
            string sqlQuery = "select * from Employee where p_emp_id is null";
            result = da.ExecuteSelectCommand(sqlQuery, CommandType.Text);
            return result;
        }

        public DataTable GetEmpNamesForApproval()
        {
            DataTable result;
            string sqlQuery = "select e.* from Employee e, ENTRY_EXIT_DATA d where e.emp_id = d.employee_id and cnic_status = 'OP' and over_nightstay_status = 'R' and isnull(e.status,'OP') <> 'CN'";
            result = da.ExecuteSelectCommand(sqlQuery, CommandType.Text);
            return result;
        }

        public DataTable GetEmpDetails(string emp_name)
        {
            DataTable result;
            string sqlQuery = "select e.emp_id, e.first_name, e.last_name, e.cnic, count(d.employee_id) as visits, d.over_nightstay_status , d.over_nightstay_duration from employee e, ENTRY_EXIT_DATA d where e.emp_id = d.employee_id and e.first_name like @emp_firstname and cnic_status = 'OP' group by e.emp_id, e.first_name, e.last_name, e.cnic, d.over_nightstay_status , d.over_nightstay_duration";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@emp_firstname", "%"+emp_name+"%"),
            };

            result = da.ExecuteParamerizedSelectCommand(sqlQuery, CommandType.Text, parameters);
            return result;
        }

        public DataTable GetEmpDetailsForVisits(string emp_name)
        {
            DataTable result;
            string sqlQuery = "select e.emp_id, e.ID_Card, e.first_name, e.last_name, e.cnic from employee e where e.first_name like @emp_firstname "; 

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@emp_firstname", "%"+emp_name+"%"),
            };

            result = da.ExecuteParamerizedSelectCommand(sqlQuery, CommandType.Text, parameters);
            return result;
        }

        private List<Employee> ReadEmployee(string sqlQuery, SqlParameter[] parameters)
        {
            List<Employee> response = new List<Employee>();
            DataTable dt = da.ExecuteParamerizedSelectCommand(sqlQuery, CommandType.Text, parameters);


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Employee emp = new Employee();

                    emp.Emp_id = Convert.ToInt32(row["Emp_id"].ToString());
                    emp.Id_card = row["ID_Card"].ToString();
                    emp.First_name = row["First_Name"].ToString();
                    emp.Last_name = row["Last_Name"].ToString();
                    emp.CNIC = row["CNIC"].ToString();
                    emp.status = row["status"].ToString();

                    if (row["veh_id"].ToString().Length > 0)
                    {
                        emp.veh_id = Convert.ToInt32(row["veh_id"]);
                    }
                    
                    emp.Uniqueid = Guid.NewGuid().ToString();
                    if (row["P_Emp_id"].ToString().Length > 0)
                    {
                        emp.P_emp_id = Convert.ToInt32(row["P_Emp_id"].ToString());
                    }
                    emp.RowState = Rowstate.None;

                    VehicleManager vhmgr = new VehicleManager();
                    emp.Vehicle = vhmgr.GetvehByVehicleId( emp.veh_id.ToString());
                    if (emp.Vehicle == null)
                    {
                        emp.Vehicle = new Vehicle();
                        emp.Vehicle.RowState = Rowstate.None;
                    }
                    response.Add(emp);
                }
            }
            else
            {

            }
            return response;
        }

        public bool DeleteEmployee(int employeeID)
        {
            bool result = false;

            //string deleteString = "delete from Employee where Emp_id = @empl_id";
            string deleteString = "update Employee set Status = 'CN'where Emp_id = @empl_id";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@empl_id", employeeID),
                
            };

            VehicleManager vehMgr = new VehicleManager();
            vehMgr.DeleteVehicleByEmployeeID(employeeID);
            // Execute the command
            bool rowsDeletedCount = da.ExecuteNonQuery(deleteString, CommandType.Text, parameters);

            return result;
        }

        public bool DeleteEmployeeFamilyMem(int employeeID)
        {
            bool result = false;

            string deleteString = "delete from Employee where Emp_id = @empl_id";
            //string deleteString = "update Employee set Status = 'CN'where Emp_id = @empl_id";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@empl_id", employeeID),
                
            };

            VehicleManager vehMgr = new VehicleManager();
            vehMgr.DeleteVehicleByEmployeeID(employeeID);
            // Execute the command
            bool rowsDeletedCount = da.ExecuteNonQuery(deleteString, CommandType.Text, parameters);

            return result;
        }


        private bool PresistFamilyMem(List<Employee> colEmp, int priEmpId)
        {
           
            foreach (Employee info in colEmp)
            {
                info.P_emp_id = priEmpId;
                if (info.RowState == Rowstate.Modified || info.RowState == Rowstate.None)
                {
                    UpdateEmployee(info);
                }
                else if (info.RowState == Rowstate.Deleted)
                {
                    DeleteEmployee(info.Emp_id);
                }
                else if (info.RowState == Rowstate.Add)
                {
                    SaveEmployee(info);
                }
            }
            return true;
              
        }
    }

}
