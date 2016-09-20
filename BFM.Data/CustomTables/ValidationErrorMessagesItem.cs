using System;
using System.Collections.Generic;

using CMS;
using CMS.Helpers;
using CMS.DataEngine;
using CMS.CustomTables.Types;
using CMS.CustomTables;
using System.Runtime.Serialization;


[assembly: RegisterCustomTable(ValidationErrorMessagesItem.CLASS_NAME, typeof(ValidationErrorMessagesItem))]
namespace CMS.CustomTables.Types
{
    
    public partial class ValidationErrorMessagesItem : CustomTableItem
    {
        #region "Constants and variables"

        /// <summary>
        /// The name of the data class.
        /// </summary>
        public const string CLASS_NAME = "customtable.ValidationErrorMessages";


        /// <summary>
        /// The instance of the class that provides extended API for working with ValidationErrorMessagesItem fields.
        /// </summary>
        private readonly ValidationErrorMessagesItemFields mFields;

        #endregion


        #region "Properties"

        /// <summary>
        /// Key.
        /// </summary>
        [DatabaseField]
        public string ErrorKey
        {
            get
            {
                return ValidationHelper.GetString(GetValue("ErrorKey"), "");
            }
            set
            {
                SetValue("ErrorKey", value);
            }
        }


        /// <summary>
        /// Value.
        /// </summary>
        [DatabaseField]
        public string ErrorValue
        {
            get
            {
                return ValidationHelper.GetString(GetValue("ErrorValue"), "");
            }
            set
            {
                SetValue("ErrorValue", value);
            }
        }


        /// <summary>
        /// Gets an object that provides extended API for working with ValidationErrorMessagesItem fields.
        /// </summary>
        public ValidationErrorMessagesItemFields Fields
        {
            get
            {
                return mFields;
            }
        }


        /// <summary>
        /// Provides extended API for working with ValidationErrorMessagesItem fields.
        /// </summary>
        public partial class ValidationErrorMessagesItemFields
        {
            /// <summary>
            /// The content item of type ValidationErrorMessagesItem that is a target of the extended API.
            /// </summary>
            private readonly ValidationErrorMessagesItem mInstance;


            /// <summary>
            /// Initializes a new instance of the <see cref="ValidationErrorMessagesItemFields" /> class with the specified content item of type ValidationErrorMessagesItem.
            /// </summary>
            /// <param name="instance">The content item of type ValidationErrorMessagesItem that is a target of the extended API.</param>
            public ValidationErrorMessagesItemFields(ValidationErrorMessagesItem instance)
            {
                mInstance = instance;
            }


            /// <summary>
            /// Key.
            /// </summary>
            public string ErrorKey
            {
                get
                {
                    return mInstance.ErrorKey;
                }
                set
                {
                    mInstance.ErrorKey = value;
                }
            }


            /// <summary>
            /// Value.
            /// </summary>
            public string ErrorValue
            {
                get
                {
                    return mInstance.ErrorValue;
                }
                set
                {
                    mInstance.ErrorValue = value;
                }
            }
        }

        #endregion


        #region "Constructors"

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationErrorMessagesItem" /> class.
        /// </summary>
        public ValidationErrorMessagesItem()
            : base(CLASS_NAME)
        {
            mFields = new ValidationErrorMessagesItemFields(this);
        }

        #endregion
    }
}
