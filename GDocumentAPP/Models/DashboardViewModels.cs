using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GDocumentAPP.Models
{
    public class DashboardViewModels
    {

        private ModelDocumentoApp db = new ModelDocumentoApp();

        public int CountPersona()
        {
            return  db.PERSONAs.Count();
        }

        public int CountEmpleadoActivos()
        {

            return db.EMPLEADOes.Where( e => e.ESTATU.DESCRIPCION.ToLower().Equals("activo") ).Count(); ;
        }

        public int CountExpedienteDigitales()
        {
            return 0;
        }

        public int CountExpedienteFisico()
        {
            return 0;
        }

    }
}