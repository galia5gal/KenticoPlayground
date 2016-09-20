using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BFM.Data
{
    [DataContract]
    public class Label
    {
        [DataMember(Name = "key")]
        public string Key { get; set; }

        [DataMember(Name = "heading")]
        public string Heading { get; set; }

        [DataMember(Name = "helpInfo")]
        public string HelpInfo { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}
