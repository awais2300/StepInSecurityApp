using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIS.Model
{
    class Student : BaseModel
    {
         #region private member

        private int _std_id;
        private string _first_name;
        private string _last_name;
        private string _CNIC;
        private Vehicle _vehicle;        
        private string _uniqueid;
        private int? _p_std_id;
        private int? _veh_id;
        private string _status;

        #endregion 

        #region Public propeties 
        public Student()
        {
            _vehicle = new Vehicle();
        }
        public Vehicle Vehicle
        {
            get { return _vehicle; }
            set { _vehicle = value; }
        }

        public string Uniqueid
        {
            get { return _uniqueid; }
            set { _uniqueid = value; }
        }

        public int Std_id
        {
            get { return _std_id; }
            set { _std_id = value; }
        }
        
        public string First_name
        {
            get { return _first_name; }
            set { _first_name = value; }
        }
        
        public string Last_name
        {
            get { return _last_name; }
            set { _last_name = value; }
        }

        public string CNIC
        {
            get { return _CNIC; }
            set { _CNIC = value; }
        }
        
        public int? P_std_id
        {
            get { return _p_std_id; }
            set { _p_std_id = value; }
        }

        public int? veh_id
        {
            get { return _veh_id; }
            set { _veh_id = value; }
        }

        public string status
        {
            get { return _status; }
            set { _status = value; }
        }

        #endregion

    }
}
