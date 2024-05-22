using DinhCongMinh_QuanLySinhVien_CuoiKy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinhCongMinh_QuanLySinhVien_CuoiKy.Controllers
{
    public class SV_LHPController : Controller
    {
        // GET: SV_LHP
        public ActionResult Index(string searchString, string searchName,  int? minScore, int? maxScore)
        {
            var context = new DBSinhVienContext();
            var listSV_LHP = context.SV_LHP.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                listSV_LHP = listSV_LHP.Where(lhp => lhp.MaLHP.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(searchName))
            {
                listSV_LHP = listSV_LHP.Where(lhp => lhp.MaSV.Contains(searchName));
            }
            // Lọc theo điểm học phần nếu có
            if (minScore != null && maxScore != null)
            {
                listSV_LHP = listSV_LHP.Where(lhp => lhp.DiemHocPhan >= minScore && lhp.DiemHocPhan <= maxScore);
            }
            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentNameFilter = searchName;
            ViewBag.CurrentMinScore = minScore;
            ViewBag.CurrentMaxScore = maxScore;

            return View(listSV_LHP.ToList());
        }

        // GET: SV_LHP/Details/5
        public ActionResult Details(string id1, string id2)
        {
            using (var context = new DBSinhVienContext())
            {
                var watching = context.SV_LHP.Find(id1, id2);
                if (watching == null)
                {
                    return HttpNotFound();
                }
                return View(watching);
            }
        }

        // GET: SV_LHP/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SV_LHP/Create
        [HttpPost]
        public ActionResult Create(SV_LHP model)
        {
            try
            {
                // TODO: Add insert logic here

                var context = new DBSinhVienContext();
                context.SV_LHP.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SV_LHP/Edit/5
        public ActionResult Edit(string id1, string id2)
        {
            var context = new DBSinhVienContext();
            var editting = context.SV_LHP.Find(id1, id2);
            return View(editting);
        }

        // POST: SV_LHP/Edit/5
        [HttpPost]
        public ActionResult Edit(SV_LHP model)
        {
            try
            {
                // TODO: Add update logic here

                var context = new DBSinhVienContext();
                var oldItem = context.SV_LHP.Find(model.MaLHP, model.MaSV);
                oldItem.DiemHocPhan = model.DiemHocPhan;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SV_LHP/Delete/5
        public ActionResult Delete(string id1, string id2)
        {
            var context = new DBSinhVienContext();
            var deleting = context.SV_LHP.Find(id1, id2);
            return View(deleting);
        }

        // POST: SV_LHP/Delete/5
        [HttpPost]
        public ActionResult Delete(string id1, string id2, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                var context = new DBSinhVienContext();
                var deleting = context.SV_LHP.Find(id1, id2);
                context.SV_LHP.Remove(deleting);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
