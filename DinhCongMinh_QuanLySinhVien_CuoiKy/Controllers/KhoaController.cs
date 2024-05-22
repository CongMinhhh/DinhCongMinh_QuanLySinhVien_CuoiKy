using DinhCongMinh_QuanLySinhVien_CuoiKy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinhCongMinh_QuanLySinhVien_CuoiKy.Controllers
{
    public class KhoaController : Controller
    {
        // GET: Khoa
        public ActionResult Index(string searchString, string searchName, string searchMaT)
        {
            var context = new DBSinhVienContext();
            var listSinhVien = context.Khoa.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                listSinhVien = listSinhVien.Where(sv => sv.MaKhoa.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(searchName))
            {
                listSinhVien = listSinhVien.Where(sv => sv.TenKhoa.Contains(searchName));
            }

            if (!string.IsNullOrEmpty(searchMaT))
            {
                listSinhVien = listSinhVien.Where(sv => sv.MaTruong.Contains(searchMaT));
            }

            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentNameFilter = searchName;
            ViewBag.CurrentMaLSHFilter = searchMaT;

            return View(listSinhVien.ToList());
        }

        // GET: Khoa/Details/5
        public ActionResult Details(string id)
        {
            var context = new DBSinhVienContext();
            var watching_gv = context.Khoa.Find(id);
            return View(watching_gv);
        }

        // GET: Khoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Khoa/Create
        [HttpPost]
        public ActionResult Create(Khoa model)
        {
            try
            {
                // TODO: Add insert logic here
                var context = new DBSinhVienContext();
                context.Khoa.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Khoa/Edit/5
        public ActionResult Edit(string id)
        {
            var context = new DBSinhVienContext();
            var editting = context.Khoa.Find(id);
            return View(editting);
        }

        // POST: Khoa/Edit/5
        [HttpPost]
        public ActionResult Edit(Khoa model)
        {
            try
            {
                // TODO: Add update logic here
                var context = new DBSinhVienContext();
                var oldItem = context.Khoa.Find(model.MaKhoa);
                oldItem.TenKhoa = model.TenKhoa;
                oldItem.Gmail = model.Gmail;
                oldItem.SDT= model.SDT;
                oldItem.MaTruong = model.MaTruong;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Khoa/Delete/5
        public ActionResult Delete(string id)
        {
            var context = new DBSinhVienContext();
            var deleting_gv = context.Khoa.Find(id);
            return View(deleting_gv);
        }

        // POST: Khoa/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                var context = new DBSinhVienContext();
                var deleting = context.Khoa.Find(id);
                context.Khoa.Remove(deleting);
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
