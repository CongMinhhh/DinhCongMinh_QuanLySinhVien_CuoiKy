using DinhCongMinh_QuanLySinhVien_CuoiKy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DinhCongMinh_QuanLySinhVien_CuoiKy.Controllers
{
    public class GiaoVienController : Controller
    {
        // GET: GiaoVien
        public ActionResult Index(string searchString, string searchName, string searchMaKhoa)
        {
            var context = new DBSinhVienContext();
            var listSinhVien = context.GiaoVien.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                listSinhVien = listSinhVien.Where(sv => sv.MaGV.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(searchName))
            {
                listSinhVien = listSinhVien.Where(sv => sv.TenGiaoVien.Contains(searchName));
            }

            if (!string.IsNullOrEmpty(searchMaKhoa))
            {
                listSinhVien = listSinhVien.Where(sv => sv.MaKhoa.Contains(searchMaKhoa));
            }

            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentNameFilter = searchName;
            ViewBag.CurrentMaKhoaFilter = searchMaKhoa;

            return View(listSinhVien.ToList());
        }

        // GET: GiaoVien/Details/5
        public ActionResult Details(string id)
        {
            var context = new DBSinhVienContext();
            var watching_gv = context.GiaoVien.Find(id);
            return View(watching_gv);
        }

        // GET: GiaoVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GiaoVien/Create
        [HttpPost]
        public ActionResult Create(GiaoVien model)
        {
            try
            {
                // TODO: Add insert logic here
                var context = new DBSinhVienContext();
                context.GiaoVien.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GiaoVien/Edit/5
        public ActionResult Edit(string id)
        {
            var context = new DBSinhVienContext();
            var editting_gv = context.GiaoVien.Find(id);
            return View(editting_gv);
        }

        // POST: GiaoVien/Edit/5
        [HttpPost]
        public ActionResult Edit(GiaoVien model)
        {
            try
            {
                // TODO: Add update logic here
                var context = new DBSinhVienContext();
                var oldItem = context.GiaoVien.Find(model.MaGV);
                oldItem.TenGiaoVien = model.TenGiaoVien;
                oldItem.Gmail = model.Gmail;
                oldItem.SDT = model.SDT;
                oldItem.MaKhoa = model.MaKhoa;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GiaoVien/Delete/5
        public ActionResult Delete(string id)
        {
            var context = new DBSinhVienContext();
            var deleting_gv = context.GiaoVien.Find(id);
            return View(deleting_gv);
        }

        // POST: GiaoVien/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var context = new DBSinhVienContext();
                var deleting_gv = context.GiaoVien.Find(id);
                context.GiaoVien.Remove(deleting_gv);
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
