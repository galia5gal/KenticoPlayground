using System;
using System.Collections.Generic;

using CMS;
using CMS.Helpers;
using CMS.DataEngine;
using CMS.CustomTables.Types;
using CMS.CustomTables;

[assembly: RegisterCustomTable(LabelsItem.CLASS_NAME, typeof(LabelsItem))]
namespace CMS.CustomTables.Types
{
    public partial class LabelsItem : CustomTableItem
    {
        #region "Constants and variables"

        /// <summary>
        /// The name of the data class.
        /// </summary>
        public const string CLASS_NAME = "customtable.Labels";


        /// <summary>
        /// The instance of the class that provides extended API for working with LabelsItem fields.
        /// </summary>
        private readonly LabelsItemFields mFields;

        #endregion


        #region "Properties"

        /// <summary>
        /// Key.
        /// </summary>
        [DatabaseField]
        public string LabelKey
        {
            get
            {
                return ValidationHelper.GetString(GetValue("LabelKey"), "");
            }
            set
            {
                SetValue("LabelKey", value);
            }
        }


        /// <summary>
        /// Heading.
        /// </summary>
        [DatabaseField]
        public string LabelHeading
        {
            get
            {
                return ValidationHelper.GetString(GetValue("LabelHeading"), "");
            }
            set
            {
                SetValue("LabelHeading", value);
            }
        }


        /// <summary>
        /// Text.
        /// </summary>
        [DatabaseField]
        public string LabelText
        {
            get
            {
                return ValidationHelper.GetString(GetValue("LabelText"), "");
            }
            set
            {
                SetValue("LabelText", value);
            }
        }


        /// <summary>
        /// Help Info.
        /// </summary>
        [DatabaseField]
        public string LabelHelpInfo
        {
            get
            {
                return ValidationHelper.GetString(GetValue("LabelHelpInfo"), "");
            }
            set
            {
                SetValue("LabelHelpInfo", value);
            }
        }


        /// <summary>
        /// Gets an object that provides extended API for working with LabelsItem fields.
        /// </summary>
        public LabelsItemFields Fields
        {
            get
            {
                return mFields;
            }
        }


        /// <summary>
        /// Provides extended API for working with LabelsItem fields.
        /// </summary>
        public partial class LabelsItemFields
        {
            /// <summary>
            /// The content item of type LabelsItem that is a target of the extended API.
            /// </summary>
            private readonly LabelsItem mInstance;


            /// <summary>
            /// Initializes a new instance of the <see cref="LabelsItemFields" /> class with the specified content item of type LabelsItem.
            /// </summary>
            /// <param name="instance">The content item of type LabelsItem that is a target of the extended API.</param>
            public LabelsItemFields(LabelsItem instance)
            {
                mInstance = instance;
            }


            /// <summary>
            /// Key.
            /// </summary>
            public string LabelKey
            {
                get
                {
                    return mInstance.LabelKey;
                }
                set
                {
                    mInstance.LabelKey = value;
                }
            }


            /// <summary>
            /// Heading.
            /// </summary>
            public string LabelHeading
            {
                get
                {
                    return mInstance.LabelHeading;
                }
                set
                {
                    mInstance.LabelHeading = value;
                }
            }


            /// <summary>
            /// Text.
            /// </summary>
            public string LabelText
            {
                get
                {
                    return mInstance.LabelText;
                }
                set
                {
                    mInstance.LabelText = value;
                }
            }


            /// <summary>
            /// Help Info.
            /// </summary>
            public string LabelHelpInfo
            {
                get
                {
                    return mInstance.LabelHelpInfo;
                }
                set
                {
                    mInstance.LabelHelpInfo = value;
                }
            }
        }

        #endregion


        #region "Constructors"

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelsItem" /> class.
        /// </summary>
        public LabelsItem()
            : base(CLASS_NAME)
        {
            mFields = new LabelsItemFields(this);
        }

        #endregion
    }
}
