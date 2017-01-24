using GDocumentAPP.Services;
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

            return db.EMPLEADOes.Where( e => e.ESTATU.DESCRIPCION.ToLower().Equals(Bundle.Estatus.Activo.ToString().ToLower()) ).Count(); ;
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

        public IQueryable getDataDonut()
        {
         
            IQueryable DocumentosEstatus = from documento in db.DOCUMENTOes
                                           join estatu in db.ESTATUS on documento.ESTATUS_ID equals estatu.ESTATUS_ID
                                           group estatu by new { estatu.DESCRIPCION } into groupNew
                                          select new { label = groupNew.Key.DESCRIPCION , value = groupNew.Count() };
                 

            return DocumentosEstatus;

        }

    }
}