using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Avaliacao.Models;

namespace Avaliacao.Controllers
{
    public class TbProfessorsController : Controller
    {
        private ProfessorContext db = new ProfessorContext();


        // GET: TbProfessors
        public ActionResult Index()
        {
            return View(db.TbProfessors.ToList());

        }

        // GET: TbProfessors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TbProfessor tbProfessor = db.TbProfessors.Find(id);
            if (tbProfessor == null)
            {
                return HttpNotFound();
            }
            return View(tbProfessor);
        }

        // GET: TbProfessors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TbProfessors/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_professor,nome_professor,email_professor,senha_professor")] TbProfessor tbProfessor)
        {
            if (ModelState.IsValid)
            {
                db.TbProfessors.Add(tbProfessor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbProfessor);
        }

        // GET: TbProfessors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TbProfessor tbProfessor = db.TbProfessors.Find(id);
            if (tbProfessor == null)
            {
                return HttpNotFound();
            }
            return View(tbProfessor);
        }

        // POST: TbProfessors/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_professor,nome_professor,email_professor,senha_professor")] TbProfessor tbProfessor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbProfessor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbProfessor);
        }

        // GET: TbProfessors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TbProfessor tbProfessor = db.TbProfessors.Find(id);
            if (tbProfessor == null)
            {
                return HttpNotFound();
            }
            return View(tbProfessor);
        }

        // POST: TbProfessors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TbProfessor tbProfessor = db.TbProfessors.Find(id);
            db.TbProfessors.Remove(tbProfessor);
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
