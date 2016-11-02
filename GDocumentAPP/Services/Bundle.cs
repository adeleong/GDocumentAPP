using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GDocumentAPP.Services
{
    public static class Bundle
    {
        public const string tipoIdentificacionCedula = "C";
        public const string tipoIdentificacionPasaporte = "P";
        public const int longitudCedula = 11;
        public const string mensajeIdentificacionRequerida = "La Identificación es requerida";
        public const string mensajeCedulaNumero = "La Cédula debe ser solo número y longitud de 11";
        public const string mensajePasaporteLetraNumero= "El Pasaporte debe ser letra, número y longitud entre [9-14] Ej:RD012345678";
        public const string mensajeCedulaLongitud = "La longitud de la Cédula debe ser de 11";
        public const string mensajePasaporteLongitud = "La longitud del Pasaporte debe ser entre [9-14]";
    }
}