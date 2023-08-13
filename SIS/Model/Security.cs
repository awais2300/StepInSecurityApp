using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIS.Model
{
    class Security : BaseModel
    {

        #region private member

        private string _user_code;
        private string _password;
        private string _status;
        private string _user_type;

        #endregion 

        #region Public propeties 
        public Security()
        {
            
        }

        public string user_code
        {
            get { return _user_code; }
            set { _user_code = value; }
        }

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string user_type
        {
            get { return _user_type; }
            set { _user_type = value; }
        }
        

        #endregion

    }
}
