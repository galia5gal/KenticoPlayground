using BFM.Data;
using BFM.Kernel.Interfaces;
using CMS.CustomTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;

namespace BFM.Kernel.Services
{
    /// <summary>
    /// help located at: http://localhost/UtilService.svc/rest/help
    /// </summary>
    [AspNetCompatibilityRequirements(
        RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class UtilService: IUtilService
    {
        public List<Label> Labels_Get()
        {
            
            return new List<Label> { 
                new Label() {Key = "hasMedicalConditionsHeading", Text="Medical Conditions"}, 
                new Label() {Key = "hasMedicalConditionsText", Text="Are any person to be insured...."},
                new Label() {Key = "hasMedicalTreatmentHeading", Text="Has Medical Treatment"},
                new Label() {Key = "hasMedicalTreatmentText", Text="Are any person to be insured...."},
            };
        }

        public List<ValidationErrorMessage> ValidationErrors_Get()
        {
            return new List<ValidationErrorMessage> { 
                new ValidationErrorMessage() {Key = "hasMedicalConditions", Value="Please Contact BF&M"}, 
                new ValidationErrorMessage() {Key = "hasMedicalTreatment", Value="Please Contact BF&M"},
                new ValidationErrorMessage() {Key = "travelCancellationNeeded", Value="Please Contact BF&M"},
                new ValidationErrorMessage() {Key = "hasClaimsAndPolicyHistory", Value="Please Contact BF&M"}
            };
        }
    }
}
