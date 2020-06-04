using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Models;
using CursoMVC.Models.TableViewModels;
using CursoMVC.Models.ViewModels;

namespace CursoMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> lst = null;
            using (corsomvcEntities db = new corsomvcEntities())
            {
                lst = (from d in db.user
                       where d.idState == 1
                       orderby d.email
                       select new UserTableViewModel
                       {
                           Email = d.email,
                           Id = d.id,
                           Edad = d.edad
                       }).ToList();
            }
            return View(lst);
        }
        [HttpGet]
        public ActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Add(UserViewModel model)
        {
            //Validar
            if (!ModelState.IsValid) //Si hay un error en los datos que se envian al UserViewModel.cs
            {
                return View(model); //Regresa los datos ingresados (No se borran los campos que se han llenado)
            }
            using (var db= new corsomvcEntities())
            {
                user oUser = new user();
                //Pasamos los parametros a guardar
                oUser.idState = 1;
                oUser.email = model.Email;
                oUser.edad = model.Edad;
                oUser.password = model.Password;

                //Agregar a la BD
                db.user.Add(oUser);
                db.SaveChanges();
            }
            //Enviamos al usuario a la lista de usuarios
            return Redirect(Url.Content("~/User"));
        }
        
        public ActionResult Edit(int Id)
        {
            EditUserViewModel model = new EditUserViewModel();

            using (var db = new corsomvcEntities())
            {
                var oUser = db.user.Find(Id);
                model.Edad = (int)oUser.edad;
                model.Email = oUser.email;
                model.Id = oUser.id;
            }
                return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {
            //Validar
            if (!ModelState.IsValid) //Si hay un error en los datos que se envian al UserViewModel.cs
            {
                return View(model); //Regresa los datos ingresados (No se borran los campos que se han llenado)
            }
            using (var db = new corsomvcEntities())
            {
                var oUser = db.user.Find(model.Id);
                oUser.email = model.Email;
                oUser.edad = model.Edad;

                if(model.Password!=null && model.Password.Trim() != "") //Esta validacion debe estar en este orden, si no va a crashear
                {
                    oUser.password = model.Password;
                }

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified; //Con esto le decimos a la bd que va a ejecutar una edicion
                db.SaveChanges(); //Guardamos los cambios

            }

            return Redirect(Url.Content("~/User"));
        }
    }
}