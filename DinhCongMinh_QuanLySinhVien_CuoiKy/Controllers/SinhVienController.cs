using DinhCongMinh_QuanLySinhVien_CuoiKy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinhCongMinh_QuanLySinhVien_CuoiKy.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: SinhVien
        public ActionResult Index(string searchString, string searchName, string searchMaLSH, string genderFilter)
        {
            var context = new DBSinhVienContext();
            var listSinhVien = context.SinhVien.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                listSinhVien = listSinhVien.Where(sv => sv.MaSV.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(searchName))
            {
                listSinhVien = listSinhVien.Where(sv => sv.TenSinhVien.Contains(searchName));
            }

            if (!string.IsNullOrEmpty(searchMaLSH))
            {
                listSinhVien = listSinhVien.Where(sv => sv.MaLSH.Contains(searchMaLSH));
            }

            if (!string.IsNullOrEmpty(genderFilter))
            {
                listSinhVien = listSinhVien.Where(sv => sv.GioiTinh == genderFilter);
            }

            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentNameFilter = searchName;
            ViewBag.CurrentMaLSHFilter = searchMaLSH;
            ViewBag.CurrentGenderFilter = genderFilter;

            return View(listSinhVien.ToList());
        }

        // GET: SinhVien/Details/5
        public ActionResult Details(string id)
        {
            var context = new DBSinhVienContext();
            var watching = context.SinhVien.Find(id);
            return View(watching);
        }

        // GET: SinhVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SinhVien/Create
        [HttpPost]
        public ActionResult Create(SinhVien model)
        {
            try
            {
                // TODO: Add insert logic here
                var context = new DBSinhVienContext();
                context.SinhVien.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SinhVien/Edit/5
        public ActionResult Edit(string id)
        {
            var context = new DBSinhVienContext();
            var editting = context.SinhVien.Find(id);
            return View(editting);
        }

        // POST: SinhVien/Edit/5
        [HttpPost]
        public ActionResult Edit(SinhVien model)
        {
            try
            {
                // TODO: Add update logic here
                var context = new DBSinhVienContext();
                var oldItem = context.SinhVien.Find(model.MaSV);
                oldItem.TenSinhVien = model.TenSinhVien;
                oldItem.NgaySinh = model.NgaySinh;
                oldItem.GioiTinh = model.GioiTinh;
                oldItem.QueQuan = model.QueQuan;
                oldItem.SDT = model.SDT;
                oldItem.Gmail = model.Gmail;
                oldItem.MaLSH = model.MaLSH;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SinhVien/Delete/5
        public ActionResult Delete(string id)
        {
            var context = new DBSinhVienContext();
            var deleting = context.SinhVien.Find(id);
            return View(deleting);
        }

        // POST: SinhVien/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var context = new DBSinhVienContext();
                var deleting = context.SinhVien.Find(id);
                context.SinhVien.Remove(deleting);
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
