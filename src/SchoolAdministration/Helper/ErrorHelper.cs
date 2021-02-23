using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Diagnostics;
using System.Linq;

namespace SchoolAdministration.Helper
{
    public static class ErrorHelpers
    {
        public static string GetErrors(ModelStateDictionary modelState)
        {
            if (modelState.Values.Any())
            {
                return string.Join("\r\n", modelState.Values.SelectMany(x => x.Errors).Select(x => !string.IsNullOrEmpty(x.ErrorMessage) ? x.ErrorMessage : x.Exception?.Message));
            }
            return string.Empty;
        }
    }
}
