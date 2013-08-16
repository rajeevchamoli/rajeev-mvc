using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace RajeevMVCApp.CustomValidation
{
    public class PostalCodeValidationAttibute : ValidationAttribute
    {
        //12209
        Regex postalCodeRegex = new Regex(@"^\d{5}(-\d{4})?$");

        public override bool IsValid(object value)
        {
            string zip = value as string;
            if(!(!string.IsNullOrEmpty(zip) &&  postalCodeRegex.IsMatch(zip)))
            {
                 this.ErrorMessage = "POSTAL code is not as per the US zip code";
                return false;
            }
            return true;
        }
    }
}