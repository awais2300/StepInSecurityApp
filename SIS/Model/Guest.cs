using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIS.Model
{
    public class Guest : BaseModel
    {

         #region private member

        private int _gst_id;
        private string _first_name;
        private string _last_name;
        private string _CNIC;
        private List<Guest> _family_mem;
        private Vehicle _vehicle;        
        private string _uniqueid;
        private int? _p_gst_id;
        private int? _veh_id;
        private string _status;
      
        #endregion 

        #region Public propeties 
        public Guest()
        {
            _vehicle = new Vehicle();
            _family_mem = new List<Guest>();

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

        public int Gst_id
        {
            get { return _gst_id; }
            set { _gst_id = value; }
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
        
        public List<Guest> Family_mem
        {
            get { return _family_mem; }
            set { _family_mem = value; }
        }

        public int? P_gst_id
        {
            get { return _p_gst_id; }
            set { _p_gst_id = value; }
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
