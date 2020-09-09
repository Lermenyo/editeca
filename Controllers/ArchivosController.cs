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
    public class ArchivosController : Controller
    {
        private ModelRutoteca db = new ModelRutoteca();

        // GET: Archivos
        public async Task<ActionResult> Index()
        {
            var archivos = db.Archivos.Include(a => a.Rutas).Include(a => a.TiposArchivo);
            return View(await archivos.ToListAsync());
        }

        // GET: Archivos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Archivos archivos = await db.Archivos.FindAsync(id);
            if (archivos == null)
            {
                return HttpNotFound();
            }
            return View(archivos);
        }

        // GET: Archivos/Create
        public ActionResult Create()
        {
            ViewBag.IdRuta = new SelectList(db.Rutas, "Id", "Codigo");
            ViewBag.IdTipoArchivo = new SelectList(db.TiposArchivo, "Id", "Nombre");
            return View();
        }

        // POST: Archivos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,IdRuta,Orden,IdTipoArchivo")] Archivos archivos)
        {
            if (ModelState.IsValid)
            {
                db.Archivos.Add(archivos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdRuta = new SelectList(db.Rutas, "Id", "Codigo", archivos.IdRuta);
            ViewBag.IdTipoArchivo = new SelectList(db.TiposArchivo, "Id", "Nombre", archivos.IdTipoArchivo);
            return View(archivos);
        }

        // GET: Archivos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Archivos archivos = await db.Archivos.FindAsync(id);
            if (archivos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRuta = new SelectList(db.Rutas, "Id", "Codigo", archivos.IdRuta);
            ViewBag.IdTipoArchivo = new SelectList(db.TiposArchivo, "Id", "Nombre", archivos.IdTipoArchivo);
            return View(archivos);
        }

        // POST: Archivos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,IdRuta,Orden,IdTipoArchivo")] Archivos archivos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(archivos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdRuta = new SelectList(db.Rutas, "Id", "Codigo", archivos.IdRuta);
            ViewBag.IdTipoArchivo = new SelectList(db.TiposArchivo, "Id", "Nombre", archivos.IdTipoArchivo);
            return View(archivos);
        }

        // GET: Archivos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Archivos archivos = await db.Archivos.FindAsync(id);
            if (archivos == null)
            {
                return HttpNotFound();
            }
            return View(archivos);
        }

        // POST: Archivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Archivos archivos = await db.Archivos.FindAsync(id);
            db.Archivos.Remove(archivos);
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
