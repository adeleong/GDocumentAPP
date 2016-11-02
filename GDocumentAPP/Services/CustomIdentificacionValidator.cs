using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using GDocumentAPP.Context;
using System.Text.RegularExpressions;

namespace GDocumentAPP.Services
{
    public class CustomIdentificacionValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var persona = (PERSONA)validationContext.ObjectInstance;

            if (String.IsNullOrEmpty(persona.IDENTIFICACION))
            {
                return new ValidationResult(Bundle.mensajeIdentificacionRequerida);
            }

            if (persona.TIPO_IDENTIFICACION == Bundle.tipoIdentificacionCedula)
            {
                if (!(Regex.IsMatch(persona.IDENTIFICACION, @"([0-9]{11})$")))
                {
                    return new ValidationResult(Bundle.mensajeCedulaNumero);
                }

               /* if(persona.IDENTIFICACION.Length != Bundle.longitudCedula)
                {
                    return new ValidationResult(Bundle.mensajeCedulaLongitud);
                }*/
            }


             if (persona.TIPO_IDENTIFICACION == Bundle.tipoIdentificacionPasaporte)
             {
                if (!(Regex.IsMatch(persona.IDENTIFICACION, @"^([A-Z]{2,3})([0-9]{7,11})$")))                                                 
                {
                    return new ValidationResult(Bundle.mensajePasaporteLetraNumero);
                }

            }

            return ValidationResult.Success;
        }

    }
}