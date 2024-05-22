using DinhCongMinh_QuanLySinhVien_CuoiKy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinhCongMinh_QuanLySinhVien_CuoiKy.Controllers
{
    public class LopSinhHoatController : Controller
    {
        // GET: LopSinhHoat
        public ActionResult Index(string searchString, string searchName, string searchMaLSH, string searchMaKhoa)
        {
            var context = new DBSinhVienContext();
            var listSinhVien = context.LopSinhHoat.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                listSinhVien = listSinhVien.Where(sv => sv.MaLSH.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(searchName))
            {
                listSinhVien = listSinhVien.Where(sv => sv.TenLSH.Contains(searchName));
            }

            if (!string.IsNullOrEmpty(searchMaLSH))
            {
                listSinhVien = listSinhVien.Where(sv => sv.MaGV.Contains(searchMaLSH));
            }

            if (!string.IsNullOrEmpty(searchMaKhoa))
            {
                listSinhVien = listSinhVien.Where(sv => sv.MaKhoa.Contains(searchMaKhoa));
            }

            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentNameFilter = searchName;
            ViewBag.CurrentMaLSHFilter = searchMaLSH;
            ViewBag.CurrentMaKhoaFilter = searchMaKhoa;

            return View(listSinhVien.ToList());
        }

        // GET: LopSinhHoat/Details/5
        public ActionResult Details(string id)
        {
            var context = new DBSinhVienContext();
            var watching = context.LopSinhHoat.Find(id);
            return View(watching);
        }

        // GET: LopSinhHoat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LopSinhHoat/Create
        [HttpPost]
        public ActionResult Create(LopSinhHoat model)
        {
            try
            {
                // TODO: Add insert logic here

                var context = new DBSinhVienContext();
                context.LopSinhHoat.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LopSinhHoat/Edit/5
        public ActionResult Edit(string id)
        {
            var context = new DBSinhVienContext();
            var editting = context.LopSinhHoat.Find(id);
            return View(editting);
        }

        // POST: LopSinhHoat/Edit/5
        [HttpPost]
        public ActionResult Edit(LopSinhHoat model)
        {
            try
            {
                // TODO: Add update logic here

                var context = new DBSinhVienContext();
                var oldItem = context.LopSinhHoat.Find(model.MaLSH);
                oldItem.TenLSH = model.TenLSH;
                oldItem.SoLuong = model.SoLuong;
                oldItem.MaGV = model.MaGV;
                oldItem.MaKhoa = model.MaKhoa;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LopSinhHoat/Delete/5
        public ActionResult Delete(string id)
        {
            var context = new DBSinhVienContext();
            var deleting = context.LopSinhHoat.Find(id);
            return View(deleting);
        }

        // POST: LopSinhHoat/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                var context = new DBSinhVienContext();
                var deleting = context.LopSinhHoat.Find(id);
                context.LopSinhHoat.Remove(deleting);
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
