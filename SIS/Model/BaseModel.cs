using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIS.Model
{
    public class BaseModel
    {
        private Rowstate _rowstate;

        internal Rowstate RowState
        {
            get { return _rowstate; }
            set { _rowstate = value; }
        }

    }
}
