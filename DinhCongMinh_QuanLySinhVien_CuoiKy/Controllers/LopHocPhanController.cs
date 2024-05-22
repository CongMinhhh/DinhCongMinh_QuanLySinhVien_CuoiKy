using DinhCongMinh_QuanLySinhVien_CuoiKy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinhCongMinh_QuanLySinhVien_CuoiKy.Controllers
{
    public class LopHocPhanController : Controller
    {
        // GET: LopHocPhan
        public ActionResult Index(string searchString, string searchName, string searchMaLSH)
        {
            var context = new DBSinhVienContext();
            var listSinhVien = context.LopHocPhan.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                listSinhVien = listSinhVien.Where(sv => sv.MaLHP.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(searchName))
            {
                listSinhVien = listSinhVien.Where(sv => sv.TenLHP.Contains(searchName));
            }

            if (!string.IsNullOrEmpty(searchMaLSH))
            {
                listSinhVien = listSinhVien.Where(sv => sv.MaGV.Contains(searchMaLSH));
            }

            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentNameFilter = searchName;
            ViewBag.CurrentMaLSHFilter = searchMaLSH;

            return View(listSinhVien.ToList());
        }

        // GET: LopHocPhan/Details/5
        public ActionResult Details(string id)
        {
            var context = new DBSinhVienContext();
            var watching = context.LopHocPhan.Find(id);
            return View(watching);
        }

        // GET: LopHocPhan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LopHocPhan/Create
        [HttpPost]
        public ActionResult Create(LopHocPhan model)
        {
            try
            {
                // TODO: Add insert logic here
                var context = new DBSinhVienContext();
                context.LopHocPhan.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LopHocPhan/Edit/5
        public ActionResult Edit(string id)
        {
            var context = new DBSinhVienContext();
            var editting = context.LopHocPhan.Find(id);
            return View(editting);
        }

        // POST: LopHocPhan/Edit/5
        [HttpPost]
        public ActionResult Edit(LopHocPhan model)
        {
            try
            {
                // TODO: Add update logic here

                var context = new DBSinhVienContext();
                var oldItem = context.LopHocPhan.Find(model.MaLHP);
                oldItem.TenLHP = model.TenLHP;
                oldItem.SoLuong = model.SoLuong;
                oldItem.SoTinChi = model.SoTinChi;
                oldItem.NgayBatDau = model.NgayBatDau;
                oldItem.MaGV = model.MaGV;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LopHocPhan/Delete/5
        public ActionResult Delete(string id)
        {
            var context = new DBSinhVienContext();
            var deleting = context.LopHocPhan.Find(id);
            return View(deleting);
        }

        // POST: LopHocPhan/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                var context = new DBSinhVienContext();
                var deleting = context.LopHocPhan.Find(id);
                context.LopHocPhan.Remove(deleting);
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
