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
    public class TracksController : Controller
    {
        private ModelRutoteca db = new ModelRutoteca();

        // GET: Tracks
        public async Task<ActionResult> Index()
        {
            return View(await db.Tracks.ToListAsync());
        }

        // GET: Tracks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tracks tracks = await db.Tracks.FindAsync(id);
            if (tracks == null)
            {
                return HttpNotFound();
            }
            return View(tracks);
        }

        // GET: Tracks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tracks/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdTrack,NombreFichero,Fecha")] Tracks tracks)
        {
            if (ModelState.IsValid)
            {
                db.Tracks.Add(tracks);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tracks);
        }

        // GET: Tracks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tracks tracks = await db.Tracks.FindAsync(id);
            if (tracks == null)
            {
                return HttpNotFound();
            }
            return View(tracks);
        }

        // POST: Tracks/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdTrack,NombreFichero,Fecha")] Tracks tracks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tracks).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tracks);
        }

        // GET: Tracks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tracks tracks = await db.Tracks.FindAsync(id);
            if (tracks == null)
            {
                return HttpNotFound();
            }
            return View(tracks);
        }

        // POST: Tracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tracks tracks = await db.Tracks.FindAsync(id);
            db.Tracks.Remove(tracks);
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
