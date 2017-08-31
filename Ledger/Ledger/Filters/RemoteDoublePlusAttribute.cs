using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace Ledger.Filters
{
    public class RemoteDoublePlusAttribute : RemoteAttribute
    {

        private string _action;
        private string _controller;

        public RemoteDoublePlusAttribute(string action, string controller, AreaReference areaReference)
            : base(action, controller)
        {
            _action = action;
            _controller = controller;
            if (areaReference == AreaReference.UseRoot)
            {
                RouteData["area"] = null;
            }
        }

        public RemoteDoublePlusAttribute(string action, string controller, string area)
            : base(action, controller, area)
        {
            _action = action;
            _controller = controller;
            RouteData["area"] = area;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var additionalFields = AdditionalFields.Split(',');
            var propValues = new List<object> { value };

            foreach (var additionalField in additionalFields)
            {
                var prop = validationContext.ObjectType.GetProperty(additionalField);
                if (prop != null)
                {
                    var propValue = prop.GetValue(validationContext.ObjectInstance, null);
                    propValues.Add(propValue);
                }
                //else
                //{
                //    propValues.Add(null);
                //}
            }

            var controllerType = Assembly.GetExecutingAssembly().GetTypes()
                                         .FirstOrDefault(d => d.Name.ToLower() == (_controller + "Controller").ToLower());

            if (controllerType == null) return null;

            var instance = Activator.CreateInstance(controllerType);

            var method = controllerType.GetMethod(_action);

            if (method == null) return null;

            var response = method.Invoke(instance, propValues.ToArray());

            if (!(response is JsonResult)) return null;

            var isAvailable = false;
            var json = response as JsonResult;
            bool.TryParse(json.Data.ToString(), out isAvailable);

            return isAvailable ? null : new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

    }
}