using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace GDocumentAPP.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }

    public class ListaValoresPersona
    {

        private ModelDocumentoApp db = new ModelDocumentoApp();

        public IQueryable getListaPersona()
        {
            IQueryable ListaPersona = from persona in db.PERSONAs 
                                      select new
                                      {
                                          PersonaId = persona.PERSONA_ID,
                                          PersonaDescripcion = persona.NOMBRE + " " +
                                                               persona.PRIMER_APELLIDO + " | " +
                                                               persona.TIPO_IDENTIFICACION + " | " +
                                                               persona.IDENTIFICACION
                                                              
                                      };
            
            return ListaPersona;
        }

        public IQueryable getListaPersonaById(int id)
        {
            IQueryable ListaPersona = from persona in db.PERSONAs.Where( p => p.PERSONA_ID == id)
                                      select new
                                      {
                                          PersonaId = persona.PERSONA_ID,
                                          PersonaDescripcion = persona.NOMBRE + " " +
                                                               persona.PRIMER_APELLIDO + " | " +
                                                               persona.TIPO_IDENTIFICACION + " | " +
                                                               persona.IDENTIFICACION

                                      };

            return ListaPersona;
        }

    }

    public class ListaValoresEmpleado
    {

        private ModelDocumentoApp db = new ModelDocumentoApp();

        public IQueryable getListaEmpleado()
        {
            IQueryable ListaEmpleado = from Empleado in db.EMPLEADOes
                                      select new
                                      {
                                          EmpleadoId = Empleado.EMPLEADO_ID,
                                          EmpleadoDescripcion = Empleado.PERSONA.NOMBRE + " " +
                                                                Empleado.PERSONA.PRIMER_APELLIDO + " | " +
                                                                Empleado.PERSONA.IDENTIFICACION + " | " +
                                                                Empleado.PUESTO

                                      };

            return ListaEmpleado;
        }

        public IQueryable getListaEmpleadoById(int id)
        {
            IQueryable ListaEmpleado = from Empleado in db.EMPLEADOes.Where(e => e.EMPLEADO_ID == id)
                                       select new
                                       {
                                           EmpleadoId = Empleado.EMPLEADO_ID,
                                           EmpleadoDescripcion = Empleado.PERSONA.NOMBRE + " " +
                                                                 Empleado.PERSONA.PRIMER_APELLIDO + " | " +
                                                                 Empleado.PERSONA.IDENTIFICACION + " | " +
                                                                 Empleado.PUESTO

                                       };

            return ListaEmpleado;
        }
    }
}
