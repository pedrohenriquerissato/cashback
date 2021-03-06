﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace CashBack.Domain.Attributes
{
    public class ValidDateAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "{0} possui uma data inválida";

        public ValidDateAttribute() : base(DefaultErrorMessage)
        {
        }

        //Fonte: https://stackoverflow.com/questions/5390403/datetime-date-and-hour-validation-with-data-annotation
        public override bool IsValid(object value)
        {

            if (DateTime.TryParseExact((string)value, "dd/MM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _))
            {
                return true;
            }

            var parsed = DateTime.TryParse((string)value, out _);
            return parsed;
        }
    }
}
