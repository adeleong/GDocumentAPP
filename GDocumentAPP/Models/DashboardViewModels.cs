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

         int CountExpedienteDigitales =  ( from e in db.EMPLEADOes
                                           where db.DOCUMENTOes.Any(d => (d.EMPLEADO_ID == e.EMPLEADO_ID))
                                          select e ).Count();

            return CountExpedienteDigitales;
        }

        public int CountExpedienteFisico()
        {
            int CountExpedienteFisico = (from e in db.EMPLEADOes
                                        where db.RASTREO_EXPEDIENTE.Any(r => (r.EMPLEADO_ID == e.EMPLEADO_ID))
                                       select e).Count();

            return CountExpedienteFisico;
        }

        public Dictionary<string, int> getDataDonut()
        {
            /* var DocumentosEstatus =  from d in db.DOCUMENTOes.GroupBy(d => d.ESTATUS_ID)
                                      select d.;*/

            return new Dictionary<string, int>();

        }

    }
}