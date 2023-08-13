using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIS.Model
{
    public class Resident :BaseModel
    {

        #region private member

        private int _res_id;
        private string _House_no;
        private string _first_name;
        private string _last_name;
        private string _CNIC;
        private string _Mobile_no;
        private string _PTCL_no;
        private string _Email_ID;
        private List<Resident> _family_mem;
        private Vehicle _vehicle;        
        private string _uniqueid;
        private int? _p_emp_id;
        private int? _veh_id;
        private string _status;

        #endregion 

        #region Public propeties 
        public Resident()
        {
            _vehicle = new Vehicle();
            _family_mem = new List<Resident>();

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

        public int Res_id
        {
            get { return _res_id; }
            set { _res_id = value; }
        }
        
        public string House_no
        {
            get { return _House_no; }
            set { _House_no = value; }
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

        public string Mobile_no
        {
            get { return _Mobile_no; }
            set { _Mobile_no = value; }
        }

        public string PTCL_No
        {
            get { return _PTCL_no; }
            set { _PTCL_no = value; }
        }

        public string Email_ID
        {
            get { return _Email_ID; }
            set { _Email_ID = value; }
        }
        
        public List<Resident> Family_mem
        {
            get { return _family_mem; }
            set { _family_mem = value; }
        }

        public int? P_emp_id
        {
            get { return _p_emp_id; }
            set { _p_emp_id = value; }
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
