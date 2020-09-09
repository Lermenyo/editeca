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
    public class LocalidadesController : Controller
    {
        private ModelRutoteca db = new ModelRutoteca();

        // GET: Localidades
        public async Task<ActionResult> Index()
        {
            var localidades = db.Localidades.Include(l => l.Elementos);
            return View(await localidades.ToListAsync());
        }

        // GET: Localidades/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localidades localidades = await db.Localidades.FindAsync(id);
            if (localidades == null)
            {
                return HttpNotFound();
            }
            return View(localidades);
        }

        // GET: Localidades/Create
        public ActionResult Create()
        {
            ViewBag.IdElemento = new SelectList(db.Elementos, "Id", "Nombre");
            return View();
        }

        // POST: Localidades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,IdElemento,Habitantes,NombreCapital,NombreOrigen,Tipo,CodigoINESuperior,CodigoINE,IdREL,Superficie,Perimetro,CodigoHojaMTN25")] Localidades localidades)
        {
            if (ModelState.IsValid)
            {
                db.Localidades.Add(localidades);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdElemento = new SelectList(db.Elementos, "Id", "Nombre", localidades.IdElemento);
            return View(localidades);
        }

        // GET: Localidades/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localidades localidades = await db.Localidades.FindAsync(id);
            if (localidades == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdElemento = new SelectList(db.Elementos, "Id", "Nombre", localidades.IdElemento);
            return View(localidades);
        }

        // POST: Localidades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,IdElemento,Habitantes,NombreCapital,NombreOrigen,Tipo,CodigoINESuperior,CodigoINE,IdREL,Superficie,Perimetro,CodigoHojaMTN25")] Localidades localidades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(localidades).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdElemento = new SelectList(db.Elementos, "Id", "Nombre", localidades.IdElemento);
            return View(localidades);
        }

        // GET: Localidades/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localidades localidades = await db.Localidades.FindAsync(id);
            if (localidades == null)
            {
                return HttpNotFound();
            }
            return View(localidades);
        }

        // POST: Localidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Localidades localidades = await db.Localidades.FindAsync(id);
            db.Localidades.Remove(localidades);
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
