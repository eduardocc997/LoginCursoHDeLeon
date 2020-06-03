using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Controllers;
using CursoMVC.Models;

namespace CursoMVC.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (user)HttpContext.Current.Session["User"]; //Traemos la variable de inicio de sesion del usuario
            if(oUser == null) //Si no hay una sesion iniciada...
            {
                if(filterContext.Controller is AccessController == false) //Si viene de otra pagina que no sea la de iniciar sesion
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index");
                }
            }
            else //Si ya se ha iniciado sesión
            {
                if (filterContext.Controller is AccessController == true) //Si se quiere acceder a la pagina de login
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index"); //Redirecciona a inicio
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}