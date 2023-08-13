using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIS.Model
{
    public class Employee :BaseModel
    {

        #region private member

        private int _emp_id;
        private string _id_card;
        private string _first_name;
        private string _last_name;
        private string _CNIC;
        private List<Employee> _family_mem;
        private Vehicle _vehicle;        
        private string _uniqueid;
        private int? _p_emp_id;
        private int? _veh_id;
        private string _status;

        #endregion 

        #region Public propeties 
        public Employee()
        {
            _vehicle = new Vehicle();
            _family_mem = new List<Employee>();

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

        public int Emp_id
        {
            get { return _emp_id; }
            set { _emp_id = value; }
        }
        
        public string Id_card
        {
            get { return _id_card; }
            set { _id_card = value; }
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
        
        public List<Employee> Family_mem
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
