using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TienHocMuonMVC.Models;

namespace TienHocMuonMVC.Controllers
{
    public class DiHocMuonsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: DiHocMuons
        public ActionResult Index()
        {
            var listItem = new DiHocMuonListingModel();
            var sochongday = db.DiHocMuons.Where(p => p.HinhThucNopPhat.Equals("Tien")).Sum(p => p.SoLuong);
            var tongtien = db.DiHocMuons.Where(p => p.HinhThucNopPhat.Equals("Chong day")).Sum(p => p.SoLuong);

            listItem.TongTien = tongtien;
            listItem.TongChongDay = sochongday;
            listItem.DSHocMuon = db.DiHocMuons.ToList();
            return View(listItem);
        }

        // GET: DiHocMuons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiHocMuon diHocMuon = db.DiHocMuons.Find(id);
            if (diHocMuon == null)
            {
                return HttpNotFound();
            }
            return View(diHocMuon);
        }

        // GET: DiHocMuons/Create
        public ActionResult Create()
        {
            DiHocMuon diHocMuon = new DiHocMuon();
            diHocMuon.NgayNopPhat = DateTime.Now;
            return View(diHocMuon);
        }

        // POST: DiHocMuons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MaSinhVien,HinhThucNopPhat,SoLuong,NgayNopPhat")] DiHocMuon diHocMuon)
        {
            if (ModelState.IsValid)
            {
                db.DiHocMuons.Add(diHocMuon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diHocMuon);
        }

        // GET: DiHocMuons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiHocMuon diHocMuon = db.DiHocMuons.Find(id);
            if (diHocMuon == null)
            {
                return HttpNotFound();
            }
            return View(diHocMuon);
        }

        // POST: DiHocMuons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MaSinhVien,HinhThucNopPhat,SoLuong,NgayNopPhat")] DiHocMuon diHocMuon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diHocMuon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diHocMuon);
        }

        // GET: DiHocMuons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiHocMuon diHocMuon = db.DiHocMuons.Find(id);
            if (diHocMuon == null)
            {
                return HttpNotFound();
            }
            return View(diHocMuon);
        }

        // POST: DiHocMuons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiHocMuon diHocMuon = db.DiHocMuons.Find(id);
            db.DiHocMuons.Remove(diHocMuon);
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
