using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using SIS.Model;


namespace SIS.Data
{
    public class Collection
    {

        public System.Data.DataTable ToDataTableGst(List<Guest> obj1)
        {
            System.Data.DataTable dt = new System.Data.DataTable(obj1.GetType().ToString());
            int colList = obj1.Count > 0 ? 1 : 0;
            for (int index = 0; index < colList; index++)
            {
                //T obj = (T)this[index];
                PropertyInfo[] propertyArray = obj1[index].GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in propertyArray)
                {
                    dt.Columns.Add(propertyInfo.Name, Nullable.GetUnderlyingType(
                            propertyInfo.PropertyType) ?? propertyInfo.PropertyType);
                }
            }

            for (int index = 0; index < obj1.Count; index++)
            {
                System.Data.DataRow dr = dt.NewRow();
                PropertyInfo[] propertyArray = obj1[index].GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in propertyArray)
                {
                    Type type = propertyInfo.PropertyType;
                    object value = propertyInfo.GetValue(obj1[index], null);
                    if (type == (typeof(int)) || type == (typeof(long)) || type == (typeof(string))
                        || type == (typeof(double)) || type == (typeof(decimal))
                        || type == (typeof(System.Nullable<int>))
                        || type == (typeof(System.Nullable<long>))
                        || type == (typeof(System.Nullable<double>))
                        || type == (typeof(System.Nullable<decimal>))
                        || type == (typeof(System.Nullable<System.DateTime>)))
                    {
                        if (value != null)
                            dr[propertyInfo.Name] = value;
                    }
                }
                if (obj1[index].RowState != null)
                {
                    if (obj1[index].RowState != Rowstate.Deleted)
                        dt.Rows.Add(dr);
                }
                else
                    dt.Rows.Add(dr);

            }

            return dt;
        }

        public System.Data.DataTable ToDataTableEmp(List<Employee> obj)
        {
            System.Data.DataTable dt = new System.Data.DataTable(obj.GetType().ToString());
            int colList = obj.Count > 0 ? 1 : 0;
            for (int index = 0; index < colList; index++)
            {
                //T obj = (T)this[index];
                PropertyInfo[] propertyArray = obj[index].GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in propertyArray)
                {
                    dt.Columns.Add(propertyInfo.Name, Nullable.GetUnderlyingType(
                            propertyInfo.PropertyType) ?? propertyInfo.PropertyType);
                }
            }

            for (int index = 0; index < obj.Count; index++)
            {
                System.Data.DataRow dr = dt.NewRow();
                PropertyInfo[] propertyArray = obj[index].GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in propertyArray)
                {
                    Type type = propertyInfo.PropertyType;
                    object value = propertyInfo.GetValue(obj[index], null);
                    if (type == (typeof(int)) || type == (typeof(long)) || type == (typeof(string))
                        || type == (typeof(double)) || type == (typeof(decimal))
                        || type == (typeof(System.Nullable<int>))
                        || type == (typeof(System.Nullable<long>))
                        || type == (typeof(System.Nullable<double>))
                        || type == (typeof(System.Nullable<decimal>))
                        || type == (typeof(System.Nullable<System.DateTime>)))
                    {
                        if (value != null)
                            dr[propertyInfo.Name] = value;
                    }
                }
                if (obj[index].RowState != null)
                {
                    if (obj[index].RowState  != Rowstate.Deleted)
                        dt.Rows.Add(dr);
                }
                else
                    dt.Rows.Add(dr);

            }

            return dt;
        }

        public System.Data.DataTable ToDataTableEmp(List<Resident> obj)
        {
            System.Data.DataTable dt = new System.Data.DataTable(obj.GetType().ToString());
            int colList = obj.Count > 0 ? 1 : 0;
            for (int index = 0; index < colList; index++)
            {
                //T obj = (T)this[index];
                PropertyInfo[] propertyArray = obj[index].GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in propertyArray)
                {
                    dt.Columns.Add(propertyInfo.Name, Nullable.GetUnderlyingType(
                            propertyInfo.PropertyType) ?? propertyInfo.PropertyType);
                }
            }

            for (int index = 0; index < obj.Count; index++)
            {
                System.Data.DataRow dr = dt.NewRow();
                PropertyInfo[] propertyArray = obj[index].GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in propertyArray)
                {
                    Type type = propertyInfo.PropertyType;
                    object value = propertyInfo.GetValue(obj[index], null);
                    if (type == (typeof(int)) || type == (typeof(long)) || type == (typeof(string))
                        || type == (typeof(double)) || type == (typeof(decimal))
                        || type == (typeof(System.Nullable<int>))
                        || type == (typeof(System.Nullable<long>))
                        || type == (typeof(System.Nullable<double>))
                        || type == (typeof(System.Nullable<decimal>))
                        || type == (typeof(System.Nullable<System.DateTime>)))
                    {
                        if (value != null)
                            dr[propertyInfo.Name] = value;
                    }
                }
                if (obj[index].RowState != null)
                {
                    if (obj[index].RowState != Rowstate.Deleted)
                        dt.Rows.Add(dr);
                }
                else
                    dt.Rows.Add(dr);

            }

            return dt;
        }


              
    }
}
