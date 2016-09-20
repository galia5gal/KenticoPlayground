using BFM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace BFM.Kernel.Interfaces
{
    [ServiceContract]
    public interface IUtilService
    {
        /// <summary>
        /// help at: http://localhost/UtilService.svc/rest/util/labels
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "util/labels", ResponseFormat=WebMessageFormat.Json)]
        List<Label> Labels_Get();

        /// <summary>
        /// http://localhost/UtilService.svc/rest/util/validationErrors
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "util/validationErrors", ResponseFormat = WebMessageFormat.Json)]
        List<ValidationErrorMessage> ValidationErrors_Get();

    }
}
