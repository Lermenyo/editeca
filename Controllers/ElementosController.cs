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
    public class ElementosController : Controller
    {
        private ModelRutoteca db = new ModelRutoteca();

        // GET: Elementos
        public async Task<ActionResult> Index()
        {
            var elementos = db.Elementos.Include(e => e.Elementos_Imagen).Include(e => e.TiposElemento);
            return View(await elementos.ToListAsync());
        }

        // GET: Elementos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elementos elementos = await db.Elementos.FindAsync(id);
            if (elementos == null)
            {
                return HttpNotFound();
            }
            return View(elementos);
        }

        // GET: Elementos/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Elementos_Imagen, "IdElemento", "Extension");
            ViewBag.IdTipoElemento = new SelectList(db.TiposElemento, "Id", "Nombre");
            return View();
        }

        // POST: Elementos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nombre,Icono,Permalink,DescripcionCorta,Create,ImportanciaIntrinseca,IdTipoElemento")] Elementos elementos)
        {
            if (ModelState.IsValid)
            {
                db.Elementos.Add(elementos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Elementos_Imagen, "IdElemento", "Extension", elementos.Id);
            ViewBag.IdTipoElemento = new SelectList(db.TiposElemento, "Id", "Nombre", elementos.IdTipoElemento);
            return View(elementos);
        }

        // GET: Elementos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elementos elementos = await db.Elementos.FindAsync(id);
            if (elementos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Elementos_Imagen, "IdElemento", "Extension", elementos.Id);
            ViewBag.IdTipoElemento = new SelectList(db.TiposElemento, "Id", "Nombre", elementos.IdTipoElemento);
            return View(elementos);
        }

        // POST: Elementos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre,Icono,Permalink,DescripcionCorta,Create,ImportanciaIntrinseca,IdTipoElemento")] Elementos elementos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(elementos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Elementos_Imagen, "IdElemento", "Extension", elementos.Id);
            ViewBag.IdTipoElemento = new SelectList(db.TiposElemento, "Id", "Nombre", elementos.IdTipoElemento);
            return View(elementos);
        }

        // GET: Elementos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elementos elementos = await db.Elementos.FindAsync(id);
            if (elementos == null)
            {
                return HttpNotFound();
            }
            return View(elementos);
        }

        // POST: Elementos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Elementos elementos = await db.Elementos.FindAsync(id);
            db.Elementos.Remove(elementos);
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
