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
    public class ResidentManager
    {
        private DataAccess da = new DataAccess();

        public int SaveResident(Resident resident)
        {
            bool retrieve;
            int ResidentID = 0;
            int vehicle_id = 0;

            try
            {
                string insertCommand = "insert into Resident (House_no, First_Name, Last_Name, CNIC, Mobile_no, PTCL_no, Email_id, P_Emp_id, status) values(@House_no, @FirstName, @lastName, @CNIC, @MobileNo, @PtclNo, @EmailID, @pemplid, 'OP')";
                insertCommand += "SELECT CAST(scope_identity() AS int)";


                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@House_no", resident.House_no),
                new SqlParameter("@FirstName", resident.First_name),
                new SqlParameter("@lastName", resident.Last_name),
                new SqlParameter("@CNIC", resident.CNIC),
                new SqlParameter("@MobileNo", resident.Mobile_no),
                new SqlParameter("@PtclNo", resident.PTCL_No),
                new SqlParameter("@EmailID", resident.Email_ID),
                new SqlParameter("@pemplid",(object)resident.P_emp_id ?? DBNull.Value),
               };
                ResidentID = int.Parse(da.ExecuteScalarQuery(insertCommand, CommandType.Text, parameters).ToString());
                resident.Res_id = ResidentID;
                if (resident.Vehicle != null && resident.Vehicle.Vehicle_reg != null)
                    if (resident.Vehicle.Vehicle_reg.Length > 0)
                    {
                        resident.Vehicle.Employee_id = ResidentID;
                        VehicleManager vehMgr = new VehicleManager();
                        vehicle_id = vehMgr.SaveVehicle(resident.Vehicle);

                        //To Update the Vehicle ID of Resident (if any)
                        string updateCommand = "update Resident set veh_id = @veh_id where Emp_id = @empid";
                        SqlParameter[] parameters2 = new SqlParameter[]
                        {
                        new SqlParameter("@veh_id", vehicle_id),
                        new SqlParameter("@empid", ResidentID),
                        };
                        da.ExecuteNonQuery(updateCommand, CommandType.Text, parameters2);
                    }

                PresistFamilyMem(resident.Family_mem, ResidentID);
           
            }
            catch (Exception ex)
            {
                
            }

            return ResidentID;
        }

        public int UpdateResident(Resident resident)
        {
            int residentID = 0;

            try
            {
                string insertCommand = "update Employee SET ID_Card = @IDCard,First_Name =@FirstName,Last_Name =@lastName ,CNIC=@CNIC WHERE Emp_id = @empid ";
                //insertCommand += "SELECT CAST(scope_identity() AS int)";


                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@IDCard", resident.House_no),
                    new SqlParameter("@FirstName", resident.First_name),
                    new SqlParameter("@lastName", resident.Last_name),
                    new SqlParameter("@CNIC", resident.CNIC),
                    new SqlParameter("@pemplid",(object)resident.P_emp_id ?? DBNull.Value),
                    new SqlParameter("@empid",(object)resident.Res_id ?? DBNull.Value),       
                };

                ////SqlTransaction tr = new SqlTransaction();

                da.ExecuteNonQuery(insertCommand, CommandType.Text, parameters);

             
                if (resident.Vehicle.Vehicle_reg != null)// && employee.Vehicle.Vehicle_reg.Length > 0)
                {

                    VehicleManager vehMgr = new VehicleManager();
                    if (resident.Vehicle.RowState != Rowstate.None && resident.Vehicle.RowState != Rowstate.Modified)
                    {
                        resident.Vehicle.Employee_id = resident.Res_id;
                        vehMgr.SaveVehicle(resident.Vehicle);

                        //To Update the Vehicle ID of Guest (if any)
                        string updateCommand = "update Employee set veh_id = @veh_id where Emp_id = @emp_id";
                        SqlParameter[] parameters2 = new SqlParameter[]
                    {
                    new SqlParameter("@veh_id", residentID),
                    new SqlParameter("@emp_id",(object) resident.Res_id ?? DBNull.Value),
                    };
                        da.ExecuteNonQuery(updateCommand, CommandType.Text, parameters2);
                    }
                    else
                    {
                        vehMgr.UpdateVehicle(resident.Vehicle);
                    }

                    if (resident.Family_mem != null)
                    {
                        PresistFamilyMem(resident.Family_mem, resident.Res_id);
                    }

                   
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return residentID;
        }

        public Resident GetResidentByHouseNo(string employeeCardID)
        {
            Resident result = new Resident();

            string sqlQuery = "select * from Resident where House_no = @idCard";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@idCard", employeeCardID),
                
            };
            List<Resident> emplcoll = ReadResident(sqlQuery, parameters);
            if (emplcoll != null && emplcoll.Count > 0)
            {
                result = emplcoll.First<Resident>();
                result.Family_mem = new List<Resident>();
                result.Family_mem = GetResidentFamilyByHouseNo(result.Res_id);
            }
            return result;
        }

        public Resident GetEmpByCNIC(string pCnic)
        {
            Resident result = new Resident();

            string sqlQuery = "select * from Employee where CNIC = @pCnic";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@pCnic", pCnic),
                
            };
            List<Resident> emplcoll = ReadResident(sqlQuery, parameters);
            if (emplcoll != null && emplcoll.Count > 0)
                result = emplcoll.First<Resident>();
            result.Family_mem = new List<Resident>();
            result.Family_mem = GetResidentFamilyByHouseNo(result.Res_id);

            return result;
        }
        public List<Resident> GetResidentFamilyByHouseNo(int p_emplid)
        {
            List<Resident> result = new List<Resident>();

            string sqlQuery = "select * from Resident where P_Emp_id = @p_emplid";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@p_emplid", p_emplid),
                
            };

            result = ReadResident(sqlQuery, parameters);

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

        private List<Resident> ReadResident(string sqlQuery, SqlParameter[] parameters)
        {
            List<Resident> response = new List<Resident>();
            DataTable dt = da.ExecuteParamerizedSelectCommand(sqlQuery, CommandType.Text, parameters);


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Resident emp = new Resident();

                    if (row["Resident_id"].ToString().Length > 0)
                    {
                        emp.Res_id = Convert.ToInt32(row["Resident_id"]);
                    }
                    emp.House_no = row["House_no"].ToString();
                    emp.First_name = row["First_Name"].ToString();
                    emp.Last_name = row["Last_Name"].ToString();
                    emp.CNIC = row["CNIC"].ToString();
                    emp.Mobile_no = row["Mobile_no"].ToString();
                    emp.PTCL_No = row["PTCL_no"].ToString();
                    emp.Email_ID = row["Email_id"].ToString();
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
                    emp.Vehicle = vhmgr.GetvehByVehicleId(emp.veh_id.ToString());
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

        public bool DeleteResidentFamilyMem(string fName, string lName, string CNIC)
        {
            bool result = false;

            string deleteString = "delete from Resident where First_Name = @fName and Last_Name = @lName and CNIC = @CNIC";
            //string deleteString = "update Employee set Status = 'CN'where Emp_id = @empl_id";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@fName", fName),
            new SqlParameter("@lName", lName),
            new SqlParameter("@CNIC", CNIC),
                
            };

            //VehicleManager vehMgr = new VehicleManager();
            //vehMgr.DeleteVehicleByEmployeeID(ResID);
            // Execute the command
            bool rowsDeletedCount = da.ExecuteNonQuery(deleteString, CommandType.Text, parameters);

            return result;
        }


        private bool PresistFamilyMem(List<Resident> colEmp, int priEmpId)
        {

            foreach (Resident info in colEmp)
            {
                info.P_emp_id = priEmpId;
                if (info.RowState == Rowstate.Modified || info.RowState == Rowstate.None)
                {
                    UpdateResident(info);
                }
                else if (info.RowState == Rowstate.Deleted)
                {
                    DeleteEmployee(info.Res_id);
                }
                else if (info.RowState == Rowstate.Add)
                {
                    SaveResident(info);
                }
            }
            return true;
              
        }
    }

}
