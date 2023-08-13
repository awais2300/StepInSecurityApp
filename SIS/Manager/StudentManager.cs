using SIS.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS.Model;
using System.Data;

namespace SIS.Manager
{
    class StudentManager
    {

        private DataAccess da = new DataAccess();

        public int SaveStudent(Student std)
        {
            int studentID = 0;
            int vehicle_id = 0;
            try
            {
                string insertCommand = "insert into Student values(@FirstName, @lastName, @CNIC,@pstdid, @veh_id, 'OP')";
                insertCommand += "SELECT CAST(scope_identity() AS int)";


                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@FirstName", std.First_name),
                new SqlParameter("@lastName", std.Last_name),
                new SqlParameter("@CNIC", std.CNIC),
                new SqlParameter("@pstdid",(object)std.P_std_id ?? DBNull.Value),
                new SqlParameter("@veh_id",DBNull.Value),
               };
                studentID = int.Parse(da.ExecuteScalarQuery(insertCommand, CommandType.Text, parameters).ToString());
                std.Std_id = studentID;
                if (std.Vehicle != null && std.Vehicle.Vehicle_reg != null)
                    if (std.Vehicle.Vehicle_reg.Length > 0)
                    {
                        std.Vehicle.Employee_id = studentID;
                        VehicleManager vehMgr = new VehicleManager();
                        vehicle_id = vehMgr.SaveVehicle(std.Vehicle);

                        //To Update the Vehicle ID of Student (if any)
                        string updateCommand = "update Student set veh_id = @veh_id where std_id = @std_id";
                        SqlParameter[] parameters2 = new SqlParameter[]
                        {
                        new SqlParameter("@veh_id", vehicle_id),
                        new SqlParameter("@std_id", studentID),
                        };
                        da.ExecuteNonQuery(updateCommand, CommandType.Text, parameters2);
                    }
            //PresistFamilyMem(employee.Family_mem, employeeID);

            }
            catch (Exception ex)
            {

                throw;
            }


            return studentID;
        }

        public int UpdateStudent(Student std)
        {
            int studentID = 0;
            int vehicle_id = 0;
            try
            {
                string insertCommand = "update Student SET First_Name =@FirstName,Last_Name =@lastName ,CNIC=@CNIC,P_Std_id=@pstdid WHERE Std_id = @stdid ";
                //insertCommand += "SELECT CAST(scope_identity() AS int)";


                SqlParameter[] parameters = new SqlParameter[]
                {
    
                new SqlParameter("@FirstName", std.First_name),
                new SqlParameter("@lastName", std.Last_name),
                new SqlParameter("@CNIC", std.CNIC),
                new SqlParameter("@pstdid",(object)std.P_std_id ?? DBNull.Value),
                new SqlParameter("@stdid",(object)std.Std_id ?? DBNull.Value),       
                };


                ////SqlTransaction tr = new SqlTransaction();

                da.ExecuteNonQuery(insertCommand, CommandType.Text, parameters);
                if (std.Vehicle != null && std.Vehicle.Vehicle_reg.Length > 0)
                {

                    VehicleManager vehMgr = new VehicleManager();
                    if (std.Vehicle.RowState != Rowstate.None)
                    {
                        std.Vehicle.Employee_id = std.Std_id;
                        vehicle_id = vehMgr.SaveVehicle(std.Vehicle);
                        //To Update the Vehicle ID of Student (if any)
                        string updateCommand = "update Student set veh_id = @veh_id where std_id = @std_id";
                        SqlParameter[] parameters2 = new SqlParameter[]
                        {
                        new SqlParameter("@veh_id", vehicle_id),
                        new SqlParameter("@std_id", (object)std.Std_id ?? DBNull.Value),
                        };
                        da.ExecuteNonQuery(updateCommand, CommandType.Text, parameters2);
                    }
                    else
                    {
                        vehMgr.UpdateVehicle(std.Vehicle);
                    }
                   // PresistFamilyMem(std.Family_mem, std.Emp_id);
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return studentID;
        }

     

        public Student GetStdByCNIC(string pCnic)
        {
            Student result = new Student();

            string sqlQuery = "select * from Student where CNIC = @pCnic";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@pCnic", pCnic),
                
            };
            List<Student> stdcoll = ReadStudent(sqlQuery, parameters);
            if (stdcoll != null && stdcoll.Count > 0)
                result = stdcoll.First<Student>();
            //result.Family_mem = new List<Employee>();
            //result.Family_mem = GetEmpBypEmpId(result.Emp_id);

            return result;
        }


        public List<Student> GetStdBypStdId(int p_stdid)
        {
            List<Student> result = new List<Student>();

            string sqlQuery = "select * from Student where P_Std_id = @p_stdid";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@p_stdid", p_stdid),
                
            };

            result = ReadStudent(sqlQuery, parameters);

            return result;
        }

        public List<Student> ShowAllStudents()
        {
            List<Student> result = new List<Student>();

            string sqlQuery = "select * from Student ";
            DataTable dt = da.ExecuteSelectCommand(sqlQuery, CommandType.Text);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Student std = new Student();

                    std.Std_id = Convert.ToInt32(row["std_id"].ToString());
                    std.First_name = row["First_Name"].ToString();
                    std.Last_name = row["Last_Name"].ToString();
                    std.CNIC = row["CNIC"].ToString();
                    std.Uniqueid = Guid.NewGuid().ToString();
                    if (row["P_std_id"].ToString().Length > 0)
                    {
                        std.P_std_id = Convert.ToInt32(row["P_Std_id"].ToString());
                    }
                    if (row["veh_id"].ToString().Length > 0)
                    {
                        std.veh_id = Convert.ToInt32(row["veh_id"].ToString());
                    }
                    std.RowState = Rowstate.None;

                    VehicleManager vhmgr = new VehicleManager();
                    std.Vehicle = vhmgr.GetvehByVehicleId(std.veh_id.ToString());
                    if (std.Vehicle == null)
                    {
                        std.Vehicle = new Vehicle();
                        std.Vehicle.RowState = Rowstate.None;
                    }

                    result.Add(std);
                }
            }

            return result;
        }       


        public DataTable GetStdNames()
        {
            DataTable result;
            string sqlQuery = "select s.* from Student s, ENTRY_EXIT_DATA d where s.std_id = d.student_id and cnic_status = 'OP' and over_nightstay_status <> 'R'";
            result = da.ExecuteSelectCommand(sqlQuery, CommandType.Text);
            return result;
        }

        public DataTable GetStdNamesForApproval()
        {
            DataTable result;
            string sqlQuery = "select s.* from Student s, ENTRY_EXIT_DATA d where s.std_id = d.student_id and cnic_status = 'OP' and over_nightstay_status = 'R'";
            result = da.ExecuteSelectCommand(sqlQuery, CommandType.Text);
            return result;
        }

        public DataTable GetStdDetails(string std_name)
        {
            DataTable result;
            string sqlQuery = "select e.std_id, e.first_name, e.last_name, e.cnic, count(d.student_id) as visits, d.over_nightstay_status , d.over_nightstay_duration from Student e, ENTRY_EXIT_DATA d where e.std_id = d.student_id and e.first_name like @std_firstname and cnic_status = 'OP' group by e.std_id, e.first_name, e.last_name, e.cnic, d.over_nightstay_status , d.over_nightstay_duration";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@std_firstname", "%"+std_name+"%"),
            };

            result = da.ExecuteParamerizedSelectCommand(sqlQuery, CommandType.Text, parameters);
            return result;
        }

        private List<Student> ReadStudent(string sqlQuery, SqlParameter[] parameters)
        {
            List<Student> response = new List<Student>();
            DataTable dt = da.ExecuteParamerizedSelectCommand(sqlQuery, CommandType.Text, parameters);


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Student std = new Student();

                    std.Std_id = Convert.ToInt32(row["std_id"].ToString());
                    std.First_name = row["First_Name"].ToString();
                    std.Last_name = row["Last_Name"].ToString();
                    std.CNIC = row["CNIC"].ToString();
                    std.status = row["status"].ToString();
                    std.Uniqueid = Guid.NewGuid().ToString();
                    if (row["P_std_id"].ToString().Length > 0)
                    {
                        std.P_std_id = Convert.ToInt32(row["P_Std_id"].ToString());
                    }
                    if (row["veh_id"].ToString().Length > 0)
                    {
                        std.veh_id = Convert.ToInt32(row["veh_id"].ToString());
                    }
                    std.RowState = Rowstate.None;

                    VehicleManager vhmgr = new VehicleManager();
                    std.Vehicle = vhmgr.GetvehByVehicleId(std.veh_id.ToString());
                    if (std.Vehicle == null)
                    {
                        std.Vehicle = new Vehicle();
                        std.Vehicle.RowState = Rowstate.None;
                    }

                    response.Add(std);
                }
            }
            else
            {

            }
            return response;
        }

        public bool DeleteStudent(int StudentID)
        {
            bool result = false;

            //string deleteString = "delete from Student where Std_id = @std_id";
            string deleteString = "update Student set status = 'CN' where Std_id = @std_id";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@std_id", StudentID),
                
            };

            VehicleManager vehMgr = new VehicleManager();
            vehMgr.DeleteVehicleByVehicleID(StudentID);
            // Execute the command
            bool rowsDeletedCount = da.ExecuteNonQuery(deleteString, CommandType.Text, parameters);

            return result;
        }

     /*   private bool PresistFamilyMem(List<Employee> colEmp, int priEmpId)
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
        }    */


    }
}
