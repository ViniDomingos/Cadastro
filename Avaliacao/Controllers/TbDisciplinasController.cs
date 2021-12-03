using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Avaliacao.Data;
using Avaliacao.Models;

namespace Avaliacao.Controllers
{
    public class TbDisciplinasController : Controller
    {
        private AvaliacaoContext db = new AvaliacaoContext();

        // GET: TbDisciplinas
        public ActionResult Index()
        {
            return View(db.TbDisciplinas.ToList());
        }

        // GET: TbDisciplinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TbDisciplina tbDisciplina = db.TbDisciplinas.Find(id);
            if (tbDisciplina == null)
            {
                return HttpNotFound();
            }
            return View(tbDisciplina);
        }

        // GET: TbDisciplinas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TbDisciplinas/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_disciplina,nome_disciplina,cargahoraria_disciplina")] TbDisciplina tbDisciplina)
        {
            if (ModelState.IsValid)
            {
                db.TbDisciplinas.Add(tbDisciplina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbDisciplina);
        }

        // GET: TbDisciplinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TbDisciplina tbDisciplina = db.TbDisciplinas.Find(id);
            if (tbDisciplina == null)
            {
                return HttpNotFound();
            }
            return View(tbDisciplina);
        }

        // POST: TbDisciplinas/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_disciplina,nome_disciplina,cargahoraria_disciplina")] TbDisciplina tbDisciplina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbDisciplina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbDisciplina);
        }

        // GET: TbDisciplinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TbDisciplina tbDisciplina = db.TbDisciplinas.Find(id);
            if (tbDisciplina == null)
            {
                return HttpNotFound();
            }
            return View(tbDisciplina);
        }

        // POST: TbDisciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TbDisciplina tbDisciplina = db.TbDisciplinas.Find(id);
            db.TbDisciplinas.Remove(tbDisciplina);
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
