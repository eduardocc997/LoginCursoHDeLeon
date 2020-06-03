using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Models;

namespace CursoMVC.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (corsomvcEntities db = new corsomvcEntities()) //inicializamos la BD
                {
                    //Hacemos una lista de los datos con una consulta a la BD, este metodo se llama LINQ
                    var lst = from d in db.user
                              where d.email == user && d.password == password && d.idState==1
                              select d;

                    if(lst.Count() > 0) //Verificamos que exista el usuario
                    {
                        user oUser = lst.First(); //Hacemos un tipo de dato llamado model.user
                        Session["User"] = oUser;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario Invalido");
                    }
                }

        
            }
            catch (Exception ex)
            {
                return Content("Ha ocurrido un error " + ex.Message);
            }
        }
    }
}