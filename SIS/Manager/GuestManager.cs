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
    class GuestManager 
    {

        private DataAccess da = new DataAccess();

        public int SaveGuest(Guest guest)
        {
            int GuestID = 0;
            int vehicle_id = 0;
            try
            {
                string insertCommand = "insert into Guest values(@FirstName, @lastName, @CNIC,@pgstid, @veh_id,'OP' )";
                insertCommand += "SELECT CAST(scope_identity() AS int)";


                SqlParameter[] parameters = new SqlParameter[]
                {
                //new SqlParameter("@IDCard", guest.Id_card),
                new SqlParameter("@FirstName", guest.First_name),
                new SqlParameter("@lastName", guest.Last_name),
                new SqlParameter("@CNIC", guest.CNIC),
                new SqlParameter("@pgstid",(object)guest.P_gst_id ?? DBNull.Value),
                new SqlParameter("@veh_id",DBNull.Value),
               };
                GuestID = int.Parse(da.ExecuteScalarQuery(insertCommand, CommandType.Text, parameters).ToString());
                guest.Gst_id = GuestID;
                if (guest.Vehicle != null && guest.Vehicle.Vehicle_reg != null)
                    if (guest.Vehicle.Vehicle_reg.Length > 0)
                    {
                        guest.Vehicle.Employee_id = GuestID;
                        VehicleManager vehMgr = new VehicleManager();
                        vehicle_id = vehMgr.SaveVehicle(guest.Vehicle);

                        //To Update the Vehicle ID of Guest (if any)
                        string updateCommand = "update Guest set veh_id = @veh_id where Gst_id = @gstid";
                        SqlParameter[] parameters2 = new SqlParameter[]
                        {
                        new SqlParameter("@veh_id", vehicle_id),
                        new SqlParameter("@gstid", GuestID),
                        };
                        da.ExecuteNonQuery(updateCommand, CommandType.Text, parameters2);
                    }

                PresistFamilyMem(guest.Family_mem, GuestID);

            }
            catch (Exception ex)
            {

                throw;
            }


            return GuestID;
        }

        public int UpdateGuest(Guest guest)
        {
            int GuestID = 0;
            int vehicle_id = 0;
            try
            {
                string insertCommand = "update Guest SET First_Name =@FirstName,Last_Name =@lastName ,CNIC=@CNIC WHERE Gst_id = @gstid ";
                //insertCommand += "SELECT CAST(scope_identity() AS int)";


                SqlParameter[] parameters = new SqlParameter[]
                {
               // new SqlParameter("@IDCard", guest.Id_card),
                new SqlParameter("@FirstName", guest.First_name),
                new SqlParameter("@lastName", guest.Last_name),
                new SqlParameter("@CNIC", guest.CNIC),
                new SqlParameter("@pgstid",(object)guest.P_gst_id ?? DBNull.Value),
                new SqlParameter("@gstid",(object)guest.Gst_id ?? DBNull.Value),       
                };


                ////SqlTransaction tr = new SqlTransaction();

                da.ExecuteNonQuery(insertCommand, CommandType.Text, parameters);

              /**  if (guest.Family_mem.Count != 0)
                {  **/
                    if (guest.Vehicle.Vehicle_reg != null)// && guest.Vehicle.Vehicle_reg.Length > 0)
                    {

                        VehicleManager vehMgr = new VehicleManager();
                        if (guest.Vehicle.RowState != Rowstate.None && guest.Vehicle.RowState != Rowstate.Modified)
                        {
                            guest.Vehicle.Guest_id = guest.Gst_id;
                            vehicle_id = vehMgr.SaveVehicle(guest.Vehicle);

                            //To Update the Vehicle ID of Guest (if any)
                            string updateCommand = "update Guest set veh_id = @veh_id where Gst_id = @gstid";
                            SqlParameter[] parameters2 = new SqlParameter[]
                        {
                        new SqlParameter("@veh_id", vehicle_id),
                        new SqlParameter("@gstid",(object)guest.Gst_id ?? DBNull.Value),
                        };
                            da.ExecuteNonQuery(updateCommand, CommandType.Text, parameters2);
                        }
                        else
                        {
                            vehMgr.UpdateVehicle(guest.Vehicle);
                        }
                        if (guest.Family_mem != null && guest.Family_mem.Count != 0)
                        {
                            PresistFamilyMem(guest.Family_mem, guest.Gst_id);
                        }
                   /** } **/
                
            }
            }
            catch (Exception ex)
            {

                throw;
            }


            return GuestID;
        }

        //public Employee GetEmpByCarId(string employeeCardID)
        //{
        //    Employee result = new Employee();

        //    string sqlQuery = "select * from Employee where ID_Card = @idCard";
        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //    new SqlParameter("@idCard", employeeCardID),
                
        //    };
        //    List<Employee> emplcoll = ReadEmployee(sqlQuery, parameters);
        //    if (emplcoll != null && emplcoll.Count > 0)
        //    {
        //        result = emplcoll.First<Employee>();
        //        result.Family_mem = new List<Employee>();
        //        result.Family_mem = GetEmpBypEmpId(result.Emp_id);
        //    }
        //    return result;
        //}

        public Guest GetGstByCNIC(string pCnic)
        {
            Guest result = new Guest();

            string sqlQuery = "select * from Guest where CNIC = @pCnic";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@pCnic", pCnic),
                
            };                            
            List<Guest> emplcoll = ReadGuest(sqlQuery, parameters);

            if (emplcoll != null && emplcoll.Count > 0)
            {
                result = emplcoll.First<Guest>();
                result.Family_mem = new List<Guest>();
                result.Family_mem = GetGstBypGstId(result.Gst_id);
            }

            return result;
        }
        public List<Guest> GetGstBypGstId(int p_Gstlid)
        {
            List<Guest> result = new List<Guest>();

            string sqlQuery = "select * from Guest where P_Gst_id = @p_Gstlid";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@p_Gstlid", p_Gstlid),
                
            };

            result = ReadGuest(sqlQuery, parameters);

            return result;
        }

        public DataTable GetGstNames()
        {
            DataTable result;
            string sqlQuery = "select g.* from Guest g, ENTRY_EXIT_DATA d where g.gst_id = d.guest_id and cnic_status = 'OP' and over_nightstay_status <> 'R'";
            result = da.ExecuteSelectCommand(sqlQuery, CommandType.Text);
            return result;
        }

        public DataTable GetGstNamesForApproval()
        {
            DataTable result;
            string sqlQuery = "select g.* from Guest g, ENTRY_EXIT_DATA d where g.gst_id = d.guest_id and cnic_status = 'OP' and over_nightstay_status = 'R'";
            result = da.ExecuteSelectCommand(sqlQuery, CommandType.Text);
            return result;
        }

        public DataTable GetGstDetails(string gst_name)
        {
            DataTable result;
            string sqlQuery = "select e.gst_id, e.first_name, e.last_name, e.cnic, count(d.guest_id) as visits, d.over_nightstay_status , d.over_nightstay_duration from Guest e, ENTRY_EXIT_DATA d where e.gst_id = d.Guest_id and e.first_name like @gst_firstname group by e.gst_id, e.first_name, e.last_name, e.cnic, d.over_nightstay_status , d.over_nightstay_duration";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@gst_firstname", "%"+gst_name+"%"),
            };

            result = da.ExecuteParamerizedSelectCommand(sqlQuery, CommandType.Text, parameters);
            return result;
        }

        private List<Guest> ReadGuest(string sqlQuery, SqlParameter[] parameters)
        {
            List<Guest> response = new List<Guest>();
            DataTable dt = da.ExecuteParamerizedSelectCommand(sqlQuery, CommandType.Text, parameters);


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Guest gst = new Guest();

                    gst.Gst_id = Convert.ToInt32(row["Gst_id"].ToString());
                    //gst.Id_card = row["ID_Card"].ToString();
                    gst.First_name = row["First_Name"].ToString();
                    gst.Last_name = row["Last_Name"].ToString();
                    gst.CNIC = row["CNIC"].ToString();
                    gst.status = row["status"].ToString();
                    gst.Uniqueid = Guid.NewGuid().ToString();

                    if (row["P_Gst_id"].ToString().Length > 0)
                    {
                        gst.P_gst_id = Convert.ToInt32(row["P_Gst_id"].ToString());
                    }
                    if (row["veh_id"].ToString().Length > 0)
                    {
                        gst.veh_id = Convert.ToInt32(row["veh_id"].ToString());
                    }
                    gst.RowState = Rowstate.None;

                    VehicleManager vhmgr = new VehicleManager();
                    gst.Vehicle = vhmgr.GetvehByVehicleId(gst.veh_id.ToString());
                    if (gst.Vehicle == null)
                    {
                        gst.Vehicle = new Vehicle();
                        gst.Vehicle.RowState = Rowstate.None;
                    }
                    response.Add(gst);
                }
            }
            else
            {

            }
            return response;
        }

        public bool DeleteGuest(int GuestID)
        {
            bool result = false;

            //string deleteString = "delete from Guest where gst_id = @gst_id";
            string deleteString = "update Guest set status = 'CN' where gst_id = @gst_id";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@gst_id", GuestID),
                
            };

            VehicleManager vehMgr = new VehicleManager();
            vehMgr.DeleteVehicleByEmployeeID(GuestID);
            // Execute the command
            bool rowsDeletedCount = da.ExecuteNonQuery(deleteString, CommandType.Text, parameters);

            return result;
        }

        public bool DeleteGuestFamilyMember(int Guest_ID)
        {
            bool result = false;

            string deleteString = "delete from Guest where Gst_id = @gst_id";
            //string deleteString = "update Guest set status = 'CN' where Gst_id = @gst_id";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@gst_id", Guest_ID),
                
            };

            //VehicleManager vehMgr = new VehicleManager();
            //vehMgr.DeleteVehicleByEmployeeID(GuestID);
            // Execute the command
            bool rowsDeletedCount = da.ExecuteNonQuery(deleteString, CommandType.Text, parameters);

            return result;
        }


        private bool PresistFamilyMem(List<Guest> colGst, int priGstId)
        {
            foreach (Guest info in colGst)
            {
                info.P_gst_id = priGstId;
                if (info.RowState == Rowstate.Modified || info.RowState == Rowstate.None)
                {
                    UpdateGuest(info);
                }
                else if (info.RowState == Rowstate.Deleted)
                {
                    DeleteGuest(info.Gst_id);
                }
                else if (info.RowState == Rowstate.Add)
                {
                    SaveGuest(info);
                }
            }
            return true;
        }

    }
}
