using DinhCongMinh_QuanLySinhVien_CuoiKy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinhCongMinh_QuanLySinhVien_CuoiKy.Controllers
{
    public class TruongController : Controller
    {
        // GET: Truong
        public ActionResult Index(string searchString, string searchName)
        {
            var context = new DBSinhVienContext();
            var listSinhVien = context.Truong.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                listSinhVien = listSinhVien.Where(sv => sv.MaTruong.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(searchName))
            {
                listSinhVien = listSinhVien.Where(sv => sv.TenTruong.Contains(searchName));
            }

            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentNameFilter = searchName;

            return View(listSinhVien.ToList());
        }

        // GET: Truong/Details/5
        public ActionResult Details(string id)
        {
            var context = new DBSinhVienContext();
            var watching = context.Truong.Find(id);
            return View(watching);
        }

        // GET: Truong/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Truong/Create
        [HttpPost]
        public ActionResult Create(Truong model)
        {
            try
            {
                // TODO: Add insert logic here

                var context = new DBSinhVienContext();
                context.Truong.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Truong/Edit/5
        public ActionResult Edit(string id)
        {
            var context = new DBSinhVienContext();
            var editting = context.Truong.Find(id);
            return View(editting);
        }

        // POST: Truong/Edit/5
        [HttpPost]
        public ActionResult Edit(Truong model)
        {
            try
            {
                // TODO: Add update logic here

                var context = new DBSinhVienContext();
                var oldItem = context.Truong.Find(model.MaTruong);
                oldItem.TenTruong = model.TenTruong;
                oldItem.Gmail = model.Gmail;
                oldItem.SDT = model.SDT;
                oldItem.DiaChi = model.DiaChi;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Truong/Delete/5
        public ActionResult Delete(string id)
        {
            var context = new DBSinhVienContext();
            var deleting = context.Truong.Find(id);
            return View(deleting);
        }

        // POST: Truong/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                var context = new DBSinhVienContext();
                var deleting = context.Truong.Find(id);
                context.Truong.Remove(deleting);
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
