using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIS.Data;
using SIS.Model;
using System.Data.SqlClient;
using System.Data;

namespace SIS.Manager
{
    public class VehicleManager
    {
        private DataAccess da = new DataAccess();
     
        public int SaveVehicle(Vehicle p_vehicle)
        {
            int vehicle_id = 0;

            try
            {


                string insertCommand = "insert into Vehicle values(@registration_no, @Make, @Model, @color,@lastupdate, 'OP')";
                insertCommand += "SELECT CAST(scope_identity() AS int)";

              
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@registration_no", p_vehicle.Vehicle_reg),
                        new SqlParameter("@Make", p_vehicle.Make),
                        new SqlParameter("@Model", p_vehicle.Model),
                        new SqlParameter("@color", p_vehicle.Color),
                        //new SqlParameter("@empid", p_vehicle.Employee_id),
                        new SqlParameter("@lastupdate",System.DateTime.Today),
              
                    };

                    vehicle_id = int.Parse(da.ExecuteScalarQuery(insertCommand, CommandType.Text, parameters).ToString());
              
                

            }
            catch (Exception ex)
            {

                throw;
            }


            return vehicle_id;
        }

        public int UpdateVehicle(Vehicle p_vehicle)
        {
            
            try
            {
                string insertCommand = "update Vehicle SET registration_no = @registration_no,Make =@Make,Model =@Model ,Color=@Color,LastUpdate=@LastUpdate WHERE vehicle_id = @veh_id ";

                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@registration_no", p_vehicle.Vehicle_reg),
                new SqlParameter("@Make", p_vehicle.Make),
                new SqlParameter("@Model", p_vehicle.Model),
                new SqlParameter("@color", p_vehicle.Color),
                new SqlParameter("@veh_id", p_vehicle.Vehicle_id),
                new SqlParameter("@lastupdate",System.DateTime.Today),     
                };


                ////SqlTransaction tr = new SqlTransaction();

                da.ExecuteNonQuery(insertCommand, CommandType.Text, parameters);
              
            }
            catch (Exception ex)
            {

                throw;
            }


            return p_vehicle.Vehicle_id;
        }

        public int AttachVehicle(Vehicle p_vehicle, int resident_id)
        {

            try
            {

                if (p_vehicle.Vehicle_id == 0)
                {
                    p_vehicle.Vehicle_id = SaveVehicle(p_vehicle);
                }

                string insertCommand = "UPDATE RESIDENT SET VEH_ID = @veh_id  WHERE RESIDENT_ID = @res_id ";

                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@res_id", resident_id),
                new SqlParameter("@veh_id", p_vehicle.Vehicle_id),
                };


                ////SqlTransaction tr = new SqlTransaction();

                da.ExecuteNonQuery(insertCommand, CommandType.Text, parameters);

            }
            catch (Exception ex)
            {

                throw;
            }


            return p_vehicle.Vehicle_id;
        }
        

        public bool DeleteVehicleByEmployeeID(int employeeID)
        {
            bool result = false;


            //string deleteString = "delete from Vehicle where vehicle_id IN (select veh_id from employee where emp_id = @empl_id)";
            string deleteString = "update Vehicle set status = 'CN' where vehicle_id IN (select veh_id from employee where emp_id = @empl_id)";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@empl_id", employeeID),
                
            };


           
            bool rowsDeletedCount = da.ExecuteNonQuery(deleteString, CommandType.Text, parameters);
            return result;
        }

        public bool DeleteVehicleByVehicleID(int VehicleId)
        {
            bool result = false;


            string deleteString = "delete from Vehicle where vehicle_id = @v_id";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@v_id", VehicleId),
                
            };



            bool rowsDeletedCount = da.ExecuteNonQuery(deleteString, CommandType.Text, parameters);
            return result;
        }

        public Vehicle GetvehByVehicleId(string vehicleID)
        {
            Vehicle result = new Vehicle();

            string sqlQuery = "select * from Vehicle where vehicle_id = @veh_id";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@veh_id", vehicleID),
                
            };

            DataTable dt = da.ExecuteParamerizedSelectCommand(sqlQuery, CommandType.Text, parameters);


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    result.Vehicle_id = Convert.ToInt32(row["vehicle_id"].ToString());
                    result.Vehicle_reg = row["registration_no"].ToString();
                    result.Make = row["Make"].ToString();
                    result.Model = row["Model"].ToString();
                    result.Color = row["Color"].ToString();
                    //result.Employee_id = Convert.ToInt32(row["emp_id"].ToString());
                    
                    result.RowState = Rowstate.None;
                }
            }
            else
            {
                result = null;
            }
            return result;
        }


        public Vehicle GetvehByRegNo(string RegNo)
        {
            Vehicle result = new Vehicle();

            string sqlQuery = "select * from Vehicle where registration_no = @veh_id";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@veh_id", RegNo),
                
            };

            DataTable dt = da.ExecuteParamerizedSelectCommand(sqlQuery, CommandType.Text, parameters);


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    result.Vehicle_id = Convert.ToInt32(row["vehicle_id"].ToString());
                    result.Vehicle_reg = row["registration_no"].ToString();
                    result.Make = row["Make"].ToString();
                    result.Model = row["Model"].ToString();
                    result.Color = row["Color"].ToString();
                    //result.Employee_id = Convert.ToInt32(row["emp_id"].ToString());

                    result.RowState = Rowstate.None;
                }
            }
            else
            {
                result = null;
            }
            return result;
        }
    }
}
