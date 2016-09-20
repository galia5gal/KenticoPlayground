using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CMS.Base;

namespace BFM.Data
{
    public class UserCustomData : IDataContainer
    {
        #region "Variables"

        private string userToken = null;
        #endregion

        #region "Properties"

        /// <summary>
        /// Gets or sets the name of the site owner.
        /// </summary>
        public string UserToken
        {
            get
            {
                return userToken;
            }
            set
            {
                userToken = value;
            }
        }
        #endregion

        #region "IDataContainer members"
        /// <summary>
        /// Gets a list of column names.
        /// </summary>
        public List<string> ColumnNames
        {
            get
            {
                return new List<string>() { "UserToken" };
            }
        }

        /// <summary>
        /// Returns true if the class contains the specified column.
        /// </summary>
        /// <param name="columnName"></param>
        public bool ContainsColumn(string columnName)
        {
            switch (columnName.ToLower())
            {
                case "usertoken":
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Gets the value of the specified column.
        /// </summary>
        /// <param name="columnName">Column name</param>
        public object GetValue(string columnName)
        {
            switch (columnName.ToLower())
            {
                case "usertoken":
                    return userToken;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Sets the value of the specified column.
        /// </summary>
        /// <param name="columnName">Column name</param>
        /// <param name="value">New value</param>
        public bool SetValue(string columnName, object value)
        {
            switch (columnName.ToLower())
            {
                case "usertoken":
                    userToken = (string)value;
                    return true;

                default:
                    return false;
            }
        }

        /// <summary>
        /// Returns a boolean value indicating whether the class contains the specified column.
        /// Passes on the specified column's value through the second parameter.
        /// </summary>
        /// <param name="columnName">Column name</param>
        /// <param name="value">Return value</param>
        public bool TryGetValue(string columnName, out object value)
        {
            switch (columnName.ToLower())
            {
                case "usertoken":
                    value = userToken;
                    return true;

                default:
                    value = null;
                    return false;
            }
        }

        /// <summary>
        /// Gets or sets the value of the column.
        /// </summary>
        /// <param name="columnName">Column name</param>
        public object this[string columnName]
        {
            get
            {
                return GetValue(columnName);
            }
            set
            {
                SetValue(columnName, value);
            }
        }

        #endregion
    }
}
