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
    class SecurityManager
    {
        private DataAccess da = new DataAccess();


        public int CreateNewUser(Security User)
        {
            int userID = 0;
            
            try
            {
                string insertCommand = "insert into security_info values(@usercode, @password,@status, @type)";
               
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@usercode", User.user_code ),
                new SqlParameter("@password", User.password),
                new SqlParameter("@status", DBNull.Value),
                new SqlParameter ("@type", User.user_type),
             
               };

                da.ExecuteScalarQuery2(insertCommand, CommandType.Text, parameters);
               
            }
            catch (Exception ex)
            {
               throw;
            }

            return userID;
        }

        public bool ValidUser(Security User)
        {
            int result;
            if (User.user_type != " ")
            {
                
                string sqlQuery = "select count(*) from security_info where user_type = @user_type";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@user_code", User.user_code),
                    new SqlParameter("@user_type", User.user_type),
                };

                result = int.Parse(da.ExecuteScalarQuery(sqlQuery, CommandType.Text, parameters).ToString());

                if (result > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                string sqlQuery = "select count(*) from security_info where user_code = @user_code";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@user_code", User.user_code),
                };

                result = int.Parse(da.ExecuteScalarQuery(sqlQuery, CommandType.Text, parameters).ToString());

                if (result > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }


        public void EmployeeTimeIn(Employee User, string as_timeIn)
        {
            
            try
            {
                if (User.veh_id == null)
                {
                    string insertCommand = "insert into ENTRY_EXIT_DATA (EMPLOYEE_ID, ENTRY_TIME,CNIC_STATUS, OVER_NIGHTSTAY_STATUS, COMMENTS, LAST_UPDATE) " +
                   "values( @emp_id, @entry_time, @cnic_status, @overNightStayStatus, @comments, @lastUpdate)";

                    SqlParameter[] parameters = new SqlParameter[]
                        {
                        new SqlParameter("@emp_id", User.Emp_id),
                        new SqlParameter("@entry_time",Convert.ToDateTime(as_timeIn) ),
                        new SqlParameter("@cnic_status", "OP"),
                        new SqlParameter("@overNightStayStatus", "N"),
                        new SqlParameter("@comments", "Entered"),
                        new SqlParameter("@lastUpdate", DateTime.Now ),
             
                        };
                    da.ExecuteScalarQuery2(insertCommand, CommandType.Text, parameters);
                }
                else if (User.veh_id != null)
                {
                    string insertCommand = "insert into ENTRY_EXIT_DATA (EMPLOYEE_ID, VEHICLE_ID, ENTRY_TIME,CNIC_STATUS, OVER_NIGHTSTAY_STATUS, COMMENTS, LAST_UPDATE) " +
                    "values( @emp_id,@veh_id, @entry_time, @cnic_status, @overNightStayStatus, @comments, @lastUpdate)";

                    SqlParameter[] parameters = new SqlParameter[]
                        {
                        new SqlParameter("@emp_id", User.Emp_id),
                        new SqlParameter("@veh_id",User.veh_id),
                        new SqlParameter("@entry_time",Convert.ToDateTime(as_timeIn) ),
                        new SqlParameter("@cnic_status", "OP"),
                        new SqlParameter("@overNightStayStatus", "N"),
                        new SqlParameter("@comments", "Entered"),
                        new SqlParameter("@lastUpdate", DateTime.Now ),
             
                        };
                    da.ExecuteScalarQuery2(insertCommand, CommandType.Text, parameters);
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public void EmployeeTimeOut(Employee User, string as_timeOut)
        {
            try
            {
                string insertCommand = "update ENTRY_EXIT_DATA SET EXIT_TIME = @exit_time,  CNIC_STATUS = @cnic_status, COMMENTS = @comments , LAST_UPDATE =@lastUpdate  WHERE EMPLOYEE_ID = @emp_id AND CNIC_STATUS = 'OP'";

                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@emp_id", User.Emp_id ),
                new SqlParameter("@exit_time", Convert.ToDateTime(as_timeOut)),
                new SqlParameter("@cnic_status", "CL"),
                new SqlParameter("@comments", "Exit"),
                new SqlParameter("@lastUpdate", DateTime.Now ),
             
               };

                da.ExecuteNonQuery(insertCommand, CommandType.Text, parameters);

            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public bool GetEmpStatus(string emp_id)
        {
            int result;
            string sqlQuery = "select count(*) from ENTRY_EXIT_DATA where EMPLOYEE_ID = @idCard and CNIC_STATUS = 'OP'";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@idCard", emp_id),
                
            };

            result = int.Parse(da.ExecuteScalarQuery(sqlQuery, CommandType.Text, parameters).ToString());

            if (result > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        public void GuestTimeIn(Guest User, string as_timeIn, string Emp_name_visit, string Emp_ID_Card_visit, string PERSONS_ACCOMPANY_VISITOR)
        {
          try
            {
                if (PERSONS_ACCOMPANY_VISITOR == "" || PERSONS_ACCOMPANY_VISITOR == null)
                {
                    PERSONS_ACCOMPANY_VISITOR = " ";
                }
                if (User.veh_id == null)
                {
                    string insertCommand = "insert into ENTRY_EXIT_DATA (GUEST_ID, ENTRY_TIME,CNIC_STATUS, OVER_NIGHTSTAY_STATUS, COMMENTS, LAST_UPDATE, EMP_TO_VISIT, EMP_TO_VISIT_ID_CARD, PERSONS_ACCOMPANY_VISITOR) " +
                   "values( @gst_id, @entry_time, @cnic_status, @overNightStayStatus, @comments, @lastUpdate, @emp_name_visit, @emp_id_card_visit, @PERSONS_ACCOMPANY_VISITOR)";
                                                                                                              
                    SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@gst_id", User.Gst_id),
                            new SqlParameter("@entry_time",Convert.ToDateTime(as_timeIn) ),
                            new SqlParameter("@cnic_status", "OP"),
                            new SqlParameter("@overNightStayStatus", "N"),
                            new SqlParameter("@comments", "Entered"),
                            new SqlParameter("@lastUpdate", DateTime.Now ),
                            new SqlParameter("@emp_name_visit", Emp_name_visit),
                            new SqlParameter("@emp_id_card_visit",Emp_ID_Card_visit),
                            new SqlParameter("@PERSONS_ACCOMPANY_VISITOR",PERSONS_ACCOMPANY_VISITOR)
             
                        };
                    da.ExecuteScalarQuery2(insertCommand, CommandType.Text, parameters);
                }
                else if (User.veh_id != null)
                {
                    string insertCommand = "insert into ENTRY_EXIT_DATA (GUEST_ID, VEHICLE_ID, ENTRY_TIME,CNIC_STATUS, OVER_NIGHTSTAY_STATUS, COMMENTS, LAST_UPDATE, EMP_TO_VISIT, EMP_TO_VISIT_ID_CARD, PERSONS_ACCOMPANY_VISITOR) " +
                    "values( @gst_id,@veh_id, @entry_time, @cnic_status, @overNightStayStatus, @comments, @lastUpdate, @emp_name_visit, @emp_id_card_visit, @PERSONS_ACCOMPANY_VISITOR)";

                    SqlParameter[] parameters = new SqlParameter[]
                        {
                        new SqlParameter("@gst_id", User.Gst_id),
                        new SqlParameter("@veh_id",User.veh_id),
                        new SqlParameter("@entry_time",Convert.ToDateTime(as_timeIn) ),
                        new SqlParameter("@cnic_status", "OP"),
                        new SqlParameter("@overNightStayStatus", "N"),
                        new SqlParameter("@comments", "Entered"),
                        new SqlParameter("@lastUpdate", DateTime.Now ),
                        new SqlParameter("@emp_name_visit", Emp_name_visit),
                        new SqlParameter("@emp_id_card_visit",Emp_ID_Card_visit),
                        new SqlParameter("@PERSONS_ACCOMPANY_VISITOR",PERSONS_ACCOMPANY_VISITOR)
             
                        };
                    da.ExecuteScalarQuery2(insertCommand, CommandType.Text, parameters);
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public void GuestTimeOut(Guest User, string as_timeOut)
        {
            try
            {
                string insertCommand = "update ENTRY_EXIT_DATA SET EXIT_TIME = @exit_time,  CNIC_STATUS = @cnic_status, COMMENTS = @comments , LAST_UPDATE =@lastUpdate  WHERE GUEST_ID = @gst_id AND CNIC_STATUS = 'OP'";

                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@gst_id", User.Gst_id ),
                new SqlParameter("@exit_time", Convert.ToDateTime(as_timeOut)),
                new SqlParameter("@cnic_status", "CL"),
                new SqlParameter("@comments", "Exit"),
                new SqlParameter("@lastUpdate", DateTime.Now ),
             
               };

                da.ExecuteNonQuery(insertCommand, CommandType.Text, parameters);

            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public bool GetGuestStatus(string gst_id)
        {
            int result;
            string sqlQuery = "select count(*) from ENTRY_EXIT_DATA where GUEST_ID = @idCard and CNIC_STATUS = 'OP'";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@idCard", gst_id),
                
            };

            result = int.Parse(da.ExecuteScalarQuery(sqlQuery, CommandType.Text, parameters).ToString());

            if (result > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public void IssueVisitorPass(Guest User)
        {
            try
            {
                string insertCommand = "update ENTRY_EXIT_DATA SET VISITOR_PASS_ISSUED = 'Y' WHERE GUEST_ID = @gst_id AND CNIC_STATUS = 'OP'";

                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@gst_id", User.Gst_id )
                };

                da.ExecuteNonQuery(insertCommand, CommandType.Text, parameters);

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public void ReturnVisitorPass(Guest User)
        {
            try
            {
                string insertCommand = "update ENTRY_EXIT_DATA SET VISITOR_PASS_ISSUED = 'R' WHERE GUEST_ID = @gst_id AND CNIC_STATUS = 'OP'";

                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@gst_id", User.Gst_id )
                };

                da.ExecuteNonQuery(insertCommand, CommandType.Text, parameters);

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public bool GetVisitorPassStatus(string gst_id)
        {
            int result;
            string sqlQuery = "select count(*) from ENTRY_EXIT_DATA where GUEST_ID = @idCard and CNIC_STATUS = 'OP' and VISITOR_PASS_ISSUED = 'Y'";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@idCard", gst_id),
                
            };

            result = int.Parse(da.ExecuteScalarQuery(sqlQuery, CommandType.Text, parameters).ToString());

            if (result > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        public void StudentTimeIn(Student User, string as_timeIn)
        {
            try
            {
                if (User.veh_id == null)
                {
                    string insertCommand = "insert into ENTRY_EXIT_DATA (STUDENT_ID, ENTRY_TIME,CNIC_STATUS, OVER_NIGHTSTAY_STATUS, COMMENTS, LAST_UPDATE) " +
                   "values( @std_id, @entry_time, @cnic_status, @overNightStayStatus, @comments, @lastUpdate)";

                    SqlParameter[] parameters = new SqlParameter[]
                        {
                        new SqlParameter("@std_id", User.Std_id),
                        new SqlParameter("@entry_time",Convert.ToDateTime(as_timeIn) ),
                        new SqlParameter("@cnic_status", "OP"),
                        new SqlParameter("@overNightStayStatus", "N"),
                        new SqlParameter("@comments", "Entered"),
                        new SqlParameter("@lastUpdate", DateTime.Now ),
             
                        };
                    da.ExecuteScalarQuery2(insertCommand, CommandType.Text, parameters);
                }
                else if (User.veh_id != null)
                {
                    string insertCommand = "insert into ENTRY_EXIT_DATA (STUDENT_ID, VEHICLE_ID, ENTRY_TIME,CNIC_STATUS, OVER_NIGHTSTAY_STATUS, COMMENTS, LAST_UPDATE) " +
                    "values( @std_id,@veh_id, @entry_time, @cnic_status, @overNightStayStatus, @comments, @lastUpdate)";

                        SqlParameter[] parameters = new SqlParameter[]
                        {
                        new SqlParameter("@std_id", User.Std_id),
                        new SqlParameter("@veh_id",User.veh_id),
                        new SqlParameter("@entry_time",Convert.ToDateTime(as_timeIn) ),
                        new SqlParameter("@cnic_status", "OP"),
                        new SqlParameter("@overNightStayStatus", "N"),
                        new SqlParameter("@comments", "Entered"),
                        new SqlParameter("@lastUpdate", DateTime.Now ),
             
                        };
                        da.ExecuteScalarQuery2(insertCommand, CommandType.Text, parameters);
                }

                

            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public void StudentTimeOut(Student User, string as_timeOut)
        {
            try
            {
                string insertCommand = "update ENTRY_EXIT_DATA SET EXIT_TIME = @exit_time,  CNIC_STATUS = @cnic_status, COMMENTS = @comments , LAST_UPDATE =@lastUpdate  WHERE STUDENT_ID = @std_id AND CNIC_STATUS = 'OP'";

                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@std_id", User.Std_id ),
                new SqlParameter("@exit_time", Convert.ToDateTime(as_timeOut)),
                new SqlParameter("@cnic_status", "CL"),
                new SqlParameter("@comments", "Exit"),
                new SqlParameter("@lastUpdate", DateTime.Now ),
             
               };

                da.ExecuteNonQuery(insertCommand, CommandType.Text, parameters);

            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public bool GetStudentStatus(string std_id)
        {
            int result;
            string sqlQuery = "select count(*) from ENTRY_EXIT_DATA where STUDENT_ID = @idCard and CNIC_STATUS = 'OP'";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@idCard", std_id),
                
            };

            result = int.Parse(da.ExecuteScalarQuery(sqlQuery, CommandType.Text, parameters).ToString());

            if (result > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        public void GenerateOverNightReq(string visitor_ID, string duration)
        {
            try
            {
                string insertCommand = "update ENTRY_EXIT_DATA SET OVER_NIGHTSTAY_STATUS = 'R',  OVER_NIGHTSTAY_DURATION = @duration  WHERE  ( employee_id = @visitor_id OR student_id = @visitor_id OR guest_id = @visitor_id ) AND CNIC_STATUS = 'OP'";

                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@visitor_id", visitor_ID),
                new SqlParameter("@duration",Convert.ToInt32(duration)),
                };

                da.ExecuteNonQuery(insertCommand, CommandType.Text, parameters);

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public void ApproveOverNightReq(string visitor_ID)
        {
            try
            {
                string insertCommand = "update ENTRY_EXIT_DATA SET OVER_NIGHTSTAY_STATUS = 'Y' WHERE  ( employee_id = @visitor_id OR student_id = @visitor_id OR guest_id = @visitor_id ) AND CNIC_STATUS = 'OP'";

                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@visitor_id", visitor_ID),
                };

                da.ExecuteNonQuery(insertCommand, CommandType.Text, parameters);

            }
            catch (Exception ex)
            {
                throw;
            }

        }


        
    }
}
