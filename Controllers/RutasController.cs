using editeca.Models;
using editeca.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace editeca.Controllers
{
    public class RutasController : Controller
    {
        // GET: Rutas
        public ActionResult Index()
        {
            List<Rutas> list = new List<Rutas>(); 
            using (ModelRutoteca bd = new ModelRutoteca())
            {
                list = bd.Rutas.ToList();
            }

            return View(list);
        }

        // GET: Rutas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rutas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rutas/Create
        [HttpPost]
        public ActionResult Create(RutaViewModel rutaViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ModelRutoteca bd = new ModelRutoteca())
                    {
                        var ruta = new Rutas();

                        ruta.Codigo = rutaViewModel.Codigo;
                        ruta.Nombre = rutaViewModel.Nombre;
                        ruta.Longitud = rutaViewModel.Longitud;
                        ruta.Descripcion = rutaViewModel.Descripcion;

                        bd.Rutas.Add(ruta);
                        bd.SaveChanges();
                    }
                }
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rutas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rutas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rutas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rutas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
