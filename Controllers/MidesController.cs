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
    public class MidesController : Controller
    {
        private ModelRutoteca db = new ModelRutoteca();

        // GET: Mides
        public async Task<ActionResult> Index()
        {
            var mides = db.Mides.Include(m => m.Rutas);
            return View(await mides.ToListAsync());
        }

        // GET: Mides/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mides mides = await db.Mides.FindAsync(id);
            if (mides == null)
            {
                return HttpNotFound();
            }
            return View(mides);
        }

        // GET: Mides/Create
        public ActionResult Create()
        {
            ViewBag.IdRuta = new SelectList(db.Rutas, "Id", "Codigo");
            return View();
        }

        // POST: Mides/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,IdRuta,Medio,Itinerario,Desplazamiento,Esfuerzo,Origen")] Mides mides)
        {
            if (ModelState.IsValid)
            {
                db.Mides.Add(mides);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdRuta = new SelectList(db.Rutas, "Id", "Codigo", mides.IdRuta);
            return View(mides);
        }

        // GET: Mides/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mides mides = await db.Mides.FindAsync(id);
            if (mides == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRuta = new SelectList(db.Rutas, "Id", "Codigo", mides.IdRuta);
            return View(mides);
        }

        // POST: Mides/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,IdRuta,Medio,Itinerario,Desplazamiento,Esfuerzo,Origen")] Mides mides)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mides).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdRuta = new SelectList(db.Rutas, "Id", "Codigo", mides.IdRuta);
            return View(mides);
        }

        // GET: Mides/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mides mides = await db.Mides.FindAsync(id);
            if (mides == null)
            {
                return HttpNotFound();
            }
            return View(mides);
        }

        // POST: Mides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Mides mides = await db.Mides.FindAsync(id);
            db.Mides.Remove(mides);
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
