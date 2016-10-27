using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GDocumentAPP.Models
{

    public struct StructTarifario
    {
        public const string nodeRoot = "//tarifarios";
        public const string nodeChild = "tarifario";
        public const string tipoFile = "img";
        public const string tipo = "tipo";
        public const string rutaFileImage = "ruta";
        public const string rutaRelativaImage = "images/";
        public const string ordenFile = "orden";
        public const string nodes= "//tarifarios/tarifario";
    }

    public class TarifarioXML
    {

        public string fileName { get; set; }
        public string pathTarifarioXml { get; set; }
        public string pathImage { get; set; }
        public string attributeTipo { get; set; }
        public string attributeRuta { get; set; }
        public int attributeOrden { get; set; }

    }
}