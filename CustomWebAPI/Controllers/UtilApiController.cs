
using BFM.Data;
using CMS.CustomTables;
using CMS.CustomTables.Types;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;

namespace CustomWebAPI.Controllers
{
    public class UtilApiController : ApiController
    {
        [Route("util/errorMessages")]
        public HttpResponseMessage GetValidationErrorMessages()
        {
            // You can return variety of things in here, for more see http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/action-results
            var errors = CustomTableItemProvider.GetItems<ValidationErrorMessagesItem>().ToList().Select(s => new ValidationErrorMessage() { Key = s.ErrorKey, Value = s.ErrorValue }).ToList();
            

            return Request.CreateResponse(HttpStatusCode.OK, errors);
        }

        [Route("util/labels")]
        public HttpResponseMessage GetLabels()
        {
            // You can return variety of things in here, for more see http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/action-results
            var labels = CustomTableItemProvider.GetItems<LabelsItem>().ToList().Select(s => new Label() { Key = s.LabelKey, Heading = s.LabelHeading, Text = s.LabelText, HelpInfo = s.LabelHelpInfo }).ToList(); ;
            return Request.CreateResponse(HttpStatusCode.OK, labels);
        }
    }
}
