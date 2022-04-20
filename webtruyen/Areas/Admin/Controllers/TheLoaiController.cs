using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webtruyen.Models;

namespace webtruyen.Areas.Admin.Controllers
{
    public class TheLoaiController : Controller
    {
        // GET: Admin/TheLoai
        private DB myDb = new DB();
        public ActionResult ds_TL()
        {
            if (Session["loai"] == null)
            {
                return RedirectToAction("TrangChu", "trangChu", new { area = "" });
            }
            else
            {
                List<THELOAI> listTL = myDb.THELOAIs.ToList();
                return View(listTL);
            }

           
        }

        public ActionResult Create()
        {
            if (Session["loai"] == null)
            {
                return RedirectToAction("TrangChu", "trangChu", new { area = "" });
            }
            else
            {
                if (Request.Form.Count > 0)
                {

                    string tenTL = Request.Form["TENTHELOAI"];
                    string mota = Request.Form["MOTA"];
                    THELOAI TL = new THELOAI();

                    TL.TENTHELOAI = tenTL;
                    TL.MOTA = mota;
                    myDb.THELOAIs.Add(TL);
                    myDb.SaveChanges();
                    return RedirectToAction("ds_TL");

                }
                return View();
            }

            
        }
        public ActionResult Edit(int maTL)
        {
            if (Session["loai"] == null)
            {
                return RedirectToAction("TrangChu", "trangChu", new { area = "" });
            }
            else
            {
                THELOAI TL = myDb.THELOAIs.FirstOrDefault(p => p.MATHELOAI == maTL);
                if (Request.Form.Count > 0)
                {
                    string tenTL = Request.Form["TENTHELOAI"];
                    string mota = Request.Form["MOTA"];
                    TL.TENTHELOAI = tenTL;
                    TL.MOTA = mota;
                    myDb.SaveChanges();
                    return RedirectToAction("ds_TL");
                }
                return View(TL);
            }

            
        }
        public ActionResult Delete(int maTL)
        {
            THELOAI TL = myDb.THELOAIs.FirstOrDefault(p => p.MATHELOAI == maTL);
            if (TL != null)
            {
                myDb.THELOAIs.Remove(TL);
                myDb.SaveChanges();
            }
            return RedirectToAction("ds_TL");
        }
    }
}