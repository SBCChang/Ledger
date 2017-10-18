using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Ledger.ValidateAttribute
{
    public sealed class BeforeTodayAttribute : ValidationAttribute, IClientValidatable
    {

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if (value is DateTime)
            {
                if (Convert.ToDateTime(value).Date <= DateTime.Now.Date)
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule()
            {
                ValidationType = "beforetoday",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName())
            };

            yield return rule;
        }

    }
}