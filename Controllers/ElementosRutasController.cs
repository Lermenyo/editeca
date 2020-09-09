using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using editeca.Models;

namespace editeca.Controllers
{
    public class ElementosRutasController : Controller
    {
        private ModelRutoteca db = new ModelRutoteca();

        // GET: ElementosRutas
        public async Task<ActionResult> Index()
        {
            var elementosRuta = db.ElementosRuta.Include(e => e.Elementos).Include(e => e.Rutas);
            return View(await elementosRuta.ToListAsync());
        }

        // GET: ElementosRutas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ElementosRuta elementosRuta = await db.ElementosRuta.FindAsync(id);
            if (elementosRuta == null)
            {
                return HttpNotFound();
            }
            return View(elementosRuta);
        }

        // GET: ElementosRutas/Create
        public ActionResult Create()
        {
            ViewBag.IdElemento = new SelectList(db.Elementos, "Id", "Nombre");
            ViewBag.IdRuta = new SelectList(db.Rutas, "Id", "Codigo");
            return View();
        }

        // POST: ElementosRutas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdRuta,IdElemento,Inicio,Fin,Intermedia,Orden")] ElementosRuta elementosRuta)
        {
            if (ModelState.IsValid)
            {
                db.ElementosRuta.Add(elementosRuta);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdElemento = new SelectList(db.Elementos, "Id", "Nombre", elementosRuta.IdElemento);
            ViewBag.IdRuta = new SelectList(db.Rutas, "Id", "Codigo", elementosRuta.IdRuta);
            return View(elementosRuta);
        }

        // GET: ElementosRutas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ElementosRuta elementosRuta = await db.ElementosRuta.FindAsync(id);
            if (elementosRuta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdElemento = new SelectList(db.Elementos, "Id", "Nombre", elementosRuta.IdElemento);
            ViewBag.IdRuta = new SelectList(db.Rutas, "Id", "Codigo", elementosRuta.IdRuta);
            return View(elementosRuta);
        }

        // POST: ElementosRutas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdRuta,IdElemento,Inicio,Fin,Intermedia,Orden")] ElementosRuta elementosRuta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(elementosRuta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdElemento = new SelectList(db.Elementos, "Id", "Nombre", elementosRuta.IdElemento);
            ViewBag.IdRuta = new SelectList(db.Rutas, "Id", "Codigo", elementosRuta.IdRuta);
            return View(elementosRuta);
        }

        // GET: ElementosRutas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ElementosRuta elementosRuta = await db.ElementosRuta.FindAsync(id);
            if (elementosRuta == null)
            {
                return HttpNotFound();
            }
            return View(elementosRuta);
        }

        // POST: ElementosRutas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ElementosRuta elementosRuta = await db.ElementosRuta.FindAsync(id);
            db.ElementosRuta.Remove(elementosRuta);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
