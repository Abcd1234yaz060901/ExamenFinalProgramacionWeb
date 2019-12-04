using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalPWEB.Models;

namespace ProyectoFinalPWEB.Controllers
{
    public class SociosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Socios
        public ActionResult Index()
        {
            var socio = db.Socio.Include(s => s.Afiliados).Include(s => s.TiposMembresia);
            return View(socio.ToList());
        }

        // GET: Socios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Socio socio = db.Socio.Find(id);
            if (socio == null)
            {
                return HttpNotFound();
            }
            return View(socio);
        }

        // GET: Socios/Create
        public ActionResult Create()
        {
            ViewBag.AfiliadosID = new SelectList(db.Afiliado, "AfiliadosID", "Nombre");
            ViewBag.MembresiaID = new SelectList(db.TiposMembresia, "MembresiaID", "Nombre");
            return View();
        }

        // POST: Socios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SocioId,Nombre,Apellido,Cedula,Foto,Direccion,Telefonos,Sexo,Edad,FechaNacimiento,AfiliadosID,MembresiaID,LugarDeTrabajo,DireccionOficina,TelefonoOficina,Estado,FechaIngreso,FechaSalida")] Socio socio)
        {
            if (ModelState.IsValid)
            {
                db.Socio.Add(socio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AfiliadosID = new SelectList(db.Afiliado, "AfiliadosID", "Nombre", socio.AfiliadosID);
            ViewBag.MembresiaID = new SelectList(db.TiposMembresia, "MembresiaID", "Nombre", socio.MembresiaID);
            return View(socio);
        }

        // GET: Socios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Socio socio = db.Socio.Find(id);
            if (socio == null)
            {
                return HttpNotFound();
            }
            ViewBag.AfiliadosID = new SelectList(db.Afiliado, "AfiliadosID", "Nombre", socio.AfiliadosID);
            ViewBag.MembresiaID = new SelectList(db.TiposMembresia, "MembresiaID", "Nombre", socio.MembresiaID);
            return View(socio);
        }

        // POST: Socios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SocioId,Nombre,Apellido,Cedula,Foto,Direccion,Telefonos,Sexo,Edad,FechaNacimiento,AfiliadosID,MembresiaID,LugarDeTrabajo,DireccionOficina,TelefonoOficina,Estado,FechaIngreso,FechaSalida")] Socio socio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AfiliadosID = new SelectList(db.Afiliado, "AfiliadosID", "Nombre", socio.AfiliadosID);
            ViewBag.MembresiaID = new SelectList(db.TiposMembresia, "MembresiaID", "Nombre", socio.MembresiaID);
            return View(socio);
        }

        // GET: Socios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Socio socio = db.Socio.Find(id);
            if (socio == null)
            {
                return HttpNotFound();
            }
            return View(socio);
        }

        // POST: Socios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Socio socio = db.Socio.Find(id);
            db.Socio.Remove(socio);
            db.SaveChanges();
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
