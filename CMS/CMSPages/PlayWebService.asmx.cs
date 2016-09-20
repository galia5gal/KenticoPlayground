using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Runtime.Serialization;

namespace CMSAppAppCode.CMSPages
{
    /// <summary>
    /// Summary description for PlayWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    [System.Web.Script.Services.ScriptService]
    public class PlayWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void UserDetails()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";

            Context.Response.Write(ser.Serialize(new UserDetails { FirstName = "Galia", LastName = "Aidem" }));
            //return new string[] { "abc", "def" };
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Labels()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            // enable CORS
            //Context.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:8090");

            //if (Context.Request.HttpMethod == "OPTIONS")
            //{
            //    Context.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
            //    Context.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
                
            //}
            var labels = new List<Label> { 
                new Label() {LabelKey = "hasMedicalConditionsHeading", LabelValue="Medical Conditions"}, 
                new Label() {LabelKey = "hasMedicalConditionsText", LabelValue="Are any person to be insured...."},
                new Label() {LabelKey = "hasMedicalTreatmentHeading", LabelValue="Has Medical Treatment"},
                new Label() {LabelKey = "hasMedicalTreatmentText", LabelValue="Are any person to be insured...."},
            };
            Context.Response.Write(ser.Serialize(labels));
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Errors()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            //Context.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:8090");

            //if (Context.Request.HttpMethod == "OPTIONS")
            //{
            //    Context.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
            //    Context.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");

            //}
            var errors = new List<Error> { 
                new Error() {ErrorKey = "hasMedicalConditions", ErrorValue="Please Contact BF&M"}, 
                new Error() {ErrorKey = "hasMedicalTreatment", ErrorValue="Please Contact BF&M"},
                new Error() {ErrorKey = "travelCancellationNeeded", ErrorValue="Please Contact BF&M"},
                new Error() {ErrorKey = "hasClaimsAndPolicyHistory", ErrorValue="Please Contact BF&M"}
            };
            Context.Response.Write(ser.Serialize(errors));
        }
    }

    public class UserDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    [DataContract]
    public class Label
    {
        [DataMember (Name="labelKey")]
        public string LabelKey { get; set; }

        [DataMember(Name = "labelValue")]
        public string LabelValue { get; set; }
    }
    [DataContract]
    public class Error
    {
        [DataMember(Name = "errorKey")]
        public string ErrorKey { get; set; }

        [DataMember(Name = "errorValue")]
        public string ErrorValue { get; set; }
    }
}
