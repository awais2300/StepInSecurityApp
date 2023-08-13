using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIS.Model
{
    public class Vehicle:BaseModel
    {
        #region private members

        private int _vehicle_id;
        private Guid _employeeGuid;
        private string _vehicle_reg;
        private string _make;
        private string _model;
        private string _color;
        private DateTime _latestdatetime;
        private int _employee_id;
        private int _guest_id;

        #endregion private members

        #region public properties 

        public string Vehicle_reg
        {
            get { return _vehicle_reg; }
            set { _vehicle_reg = value; }
        }
        public Guid EmployeeGuid
        {
            get { return _employeeGuid; }
            set { _employeeGuid = value; }
        }
        public int Vehicle_id
        {
            get { return _vehicle_id; }
            set { _vehicle_id = value; }
        }
        public string Make
        {
            get { return _make; }
            set { _make = value; }
        }
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }
        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public DateTime Latestdatetime
        {
            get { return _latestdatetime; }
            set { _latestdatetime = value; }
        }
        public int Employee_id
        {
            get { return _employee_id; }
            set { _employee_id = value; }
        }

        public int Guest_id
        {
            get { return _guest_id; }
            set { _guest_id = value; }
        }
        
        #endregion public properties
    }
}
