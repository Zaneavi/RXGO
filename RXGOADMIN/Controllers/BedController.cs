using RXGOADMIN.Helpers;
using RXGOADMIN.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RXGOADMIN.Controllers
{
    public class BedController : Controller
    {
        // GET: Finance
        DLayer dl = new DLayer();
        EncryptDecrypt enc = new EncryptDecrypt();
        public ActionResult Index()
        {
            return View();
        }


        #region Floor
        public ActionResult Floor()
        {
            List<Floor> CategoryList = new List<Floor>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchFloor";

            ds = dl.FetchFloor_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Floor m = new Floor();

                    m.FId = item["FId"].ToString();
                    m.Name = item["Name"].ToString();
                    m.AddedBy = item["AddedBy"].ToString();
                    m.Description = item["Description"].ToString();
                    m.IsActive = item["IsActive"].ToString();
                    CategoryList.Add(m);
                }
                ViewBag.CategoryList = CategoryList;
            }
            catch (Exception e)
            {

            }
            return View();
        }
        [HttpPost]
        public ActionResult Floor(Floor c)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string AddedBy = rxgoAdminCookie.Values["Hid"];
            c.AddedBy = AddedBy;
            try
            {
                if (dl.InsertFloor_Sp(c) > 0)
                {
                    TempData["MSG"] = "Floor Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Bed/Floor");
            }
            TempData["MSG"] = "Floor Added Successfully.";
            return Redirect("/Bed/Floor");
        }


        public JsonResult DeleteFloor(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteFloor";
            ds = dl.FetchFloor_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult FloorStatus(string id, string status)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            if (status == "True")
            {
                a.Condition1 = "False";
            }
            else
            {
                a.Condition1 = "True";
            }
            a.Condition2 = id;
            a.OnTable = "ChangeFloorStatus";
            ds = dl.FetchFloor_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditFloor(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchFloor";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchFloor_sp(p);

            Floor info = new RXGOADMIN.Models.Floor();
            try
            {
                info = new RXGOADMIN.Models.Floor()
                {
                    FId = ds.Tables[1].Rows[0]["FId"].ToString(),
                    Name = ds.Tables[1].Rows[0]["Name"].ToString(),
                    Description = ds.Tables[1].Rows[0]["Description"].ToString()
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }
        #endregion

        #region BedGroup
        public ActionResult BedGroup()
        {
            List<BedGroup> CategoryList = new List<BedGroup>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchBedGroup";

            ds = dl.FetchBedGroup_sp(p);

            List<SelectListItem> Categoryinventory = new List<SelectListItem>();
            Categoryinventory.Add(new SelectListItem { Text = "Select Floor", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                Categoryinventory.Add(new SelectListItem { Text = dr["Name"].ToString(), Value = dr["FId"].ToString() });
            }
            ViewBag.Categoryinventory = new SelectList(Categoryinventory, "Value", "Text");


            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    BedGroup m = new BedGroup();

                    m.BGId = item["BGId"].ToString();
                    m.GName = item["GName"].ToString();
                    m.Description = item["Description"].ToString();
                    m.FId = item["FId"].ToString();
                    m.Name = item["Name"].ToString();
                    m.AddedBy = item["AddedBy"].ToString();
                    m.IsActive = item["IsActive"].ToString();
                    CategoryList.Add(m);
                }
                ViewBag.CategoryList = CategoryList;
            }
            catch (Exception e)
            {

            }
            return View();
        }
        [HttpPost]
        public ActionResult BedGroup(BedGroup c)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string AddedBy = rxgoAdminCookie.Values["Hid"];
            c.AddedBy = AddedBy;
            try
            {
                if (dl.InsertBedGroup_Sp(c) > 0)
                {
                    TempData["MSG"] = "Bed Group Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Bed/BedGroup");
            }
            TempData["MSG"] = "Bed Group Added Successfully.";
            return Redirect("/Bed/BedGroup");
        }

        public JsonResult GetFloorName(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();

            List<SelectListItem> Categoryinventory = new List<SelectListItem>();
            Categoryinventory.Add(new SelectListItem { Text = "Select Floor", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                Categoryinventory.Add(new SelectListItem { Text = dr["Name"].ToString(), Value = dr["FId"].ToString() });
            }
            ViewBag.Categoryinventory = new SelectList(Categoryinventory, "Value", "Text");

            return Json(Categoryinventory, JsonRequestBehavior.AllowGet);

        }

        public JsonResult DeleteBedGroup(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteBedGroup";
            ds = dl.FetchBedGroup_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult BedGroupStatus(string id, string status)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            if (status == "True")
            {
                a.Condition1 = "False";
            }
            else
            {
                a.Condition1 = "True";
            }
            a.Condition2 = id;
            a.OnTable = "ChangeBedGroupStatus";
            ds = dl.FetchBedGroup_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditBedGroup(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchBedGroup";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchBedGroup_sp(p);

            List<SelectListItem> Categoryinventory = new List<SelectListItem>();
            Categoryinventory.Add(new SelectListItem { Text = "Select Floor", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                Categoryinventory.Add(new SelectListItem { Text = dr["Name"].ToString(), Value = dr["FId"].ToString() });
            }
            ViewBag.Categoryinventory = new SelectList(Categoryinventory, "Value", "Text");

            BedGroup info = new RXGOADMIN.Models.BedGroup();
            try
            {
                info = new RXGOADMIN.Models.BedGroup()
                {
                    BGId = ds.Tables[2].Rows[0]["BGId"].ToString(),
                    GName = ds.Tables[2].Rows[0]["GName"].ToString(),
                    Name = ds.Tables[2].Rows[0]["Name"].ToString(),
                    Description = ds.Tables[2].Rows[0]["Description"].ToString(),
                    FId = ds.Tables[2].Rows[0]["FId"].ToString()
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }
        #endregion

        #region BedType
        public ActionResult BedType()
        {
            List<BedType> CategoryList = new List<BedType>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchBedType";

            ds = dl.FetchBedType_sp(p);

            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    BedType m = new BedType();

                    m.TId = item["TId"].ToString();
                    m.Purpose = item["Purpose"].ToString();
                    m.AddedBy = item["AddedBy"].ToString();
                    m.IsActive = item["IsActive"].ToString();
                    CategoryList.Add(m);
                }
                ViewBag.CategoryList = CategoryList;
            }
            catch (Exception e)
            {

            }
            return View();
        }
        [HttpPost]
        public ActionResult BedType(BedType c)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string AddedBy = rxgoAdminCookie.Values["Hid"];
            c.AddedBy = AddedBy;
            try
            {
                if (dl.InsertBedType_Sp(c) > 0)
                {
                    TempData["MSG"] = "Bed Type Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Bed/BedType");
            }
            TempData["MSG"] = "Bed Type Added Successfully.";
            return Redirect("/Bed/BedType");
        }


        public JsonResult DeleteBedType(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteBedType";
            ds = dl.FetchBedType_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult BedTypeStatus(string id, string status)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            if (status == "True")
            {
                a.Condition1 = "False";
            }
            else
            {
                a.Condition1 = "True";
            }
            a.Condition2 = id;
            a.OnTable = "ChangeBedTypeStatus";
            ds = dl.FetchBedType_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditBedType(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchBedType";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchBedType_sp(p);

            BedType info = new RXGOADMIN.Models.BedType();
            try
            {
                info = new RXGOADMIN.Models.BedType()
                {
                    TId = ds.Tables[1].Rows[0]["TId"].ToString(),
                    Purpose = ds.Tables[1].Rows[0]["Purpose"].ToString()
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }
        #endregion

        #region Bed
        public ActionResult Bed()
        {
            List<Bed> CategoryList = new List<Bed>();
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchBed";

            ds = dl.FetchBed_sp(p);

            List<SelectListItem> Typeinventory = new List<SelectListItem>();
            Typeinventory.Add(new SelectListItem { Text = "Select", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                Typeinventory.Add(new SelectListItem { Text = dr["Purpose"].ToString(), Value = dr["TId"].ToString() });
            }
            ViewBag.Typeinventory = new SelectList(Typeinventory, "Value", "Text");


            List<SelectListItem> Groupinventory = new List<SelectListItem>();
            Groupinventory.Add(new SelectListItem { Text = "Select", Value = "" });
            foreach (DataRow dr in ds.Tables[2].Rows)
            {
                Groupinventory.Add(new SelectListItem { Text = dr["GName"].ToString(), Value = dr["BGId"].ToString() });
            }
            ViewBag.Groupinventory = new SelectList(Groupinventory, "Value", "Text");


            try
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Bed m = new Bed();

                    m.BId = item["BId"].ToString();
                    m.BName = item["BName"].ToString();
                    m.TId = item["TId"].ToString();
                    m.Purpose = item["Purpose"].ToString();
                    m.BGId = item["BGId"].ToString();
                    m.GName = item["GName"].ToString();
                    m.AddedBy = item["AddedBy"].ToString();
                    m.IsActive = item["IsActive"].ToString();
                    CategoryList.Add(m);
                }
                ViewBag.CategoryList = CategoryList;
            }
            catch (Exception e)
            {

            }
            return View();
        }
        [HttpPost]
        public ActionResult Bed(Bed c)
        {
            HttpCookie rxgoAdminCookie = Request.Cookies["rxgoAdmin"];
            string AddedBy = rxgoAdminCookie.Values["Hid"];
            c.AddedBy = AddedBy;
            try
            {
                if (dl.InsertBed_Sp(c) > 0)
                {
                    TempData["MSG"] = "Bed Added Successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["MSG"] = "Something went wrong.";
                return Redirect("/Bed/Bed");
            }
            TempData["MSG"] = "Bed Added Successfully.";
            return Redirect("/Bed/Bed");
        }


        public JsonResult DeleteBed(string id)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            a.Condition1 = id;
            a.OnTable = "DeleteBed";
            ds = dl.FetchBed_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult BedStatus(string id, string status)
        {
            Property a = new Property();
            DataSet ds = new DataSet();
            if (status == "True")
            {
                a.Condition1 = "False";
            }
            else
            {
                a.Condition1 = "True";
            }
            a.Condition2 = id;
            a.OnTable = "ChangeBedStatus";
            ds = dl.FetchBed_sp(a);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditBed(string id)
        {
            Property p = new Property();
            DataSet ds = new DataSet();
            p.OnTable = "FetchBed";
            if (id != null)
            {
                p.Condition1 = id;
            }

            ds = dl.FetchBed_sp(p);


            List<SelectListItem> Groupinventory = new List<SelectListItem>();
            Groupinventory.Add(new SelectListItem { Text = "Select", Value = "" });
            foreach (DataRow dr in ds.Tables[2].Rows)
            {
                Groupinventory.Add(new SelectListItem { Text = dr["GName"].ToString(), Value = dr["BGId"].ToString() });
            }
            ViewBag.Groupinventory = new SelectList(Groupinventory, "Value", "Text");


            List<SelectListItem> Typeinventory = new List<SelectListItem>();
            Typeinventory.Add(new SelectListItem { Text = "Select", Value = "" });
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                Typeinventory.Add(new SelectListItem { Text = dr["Purpose"].ToString(), Value = dr["TId"].ToString() });
            }
            ViewBag.Typeinventory = new SelectList(Typeinventory, "Value", "Text");

            Bed info = new RXGOADMIN.Models.Bed();
            try
            {
                info = new RXGOADMIN.Models.Bed()
                {
                    BId = ds.Tables[3].Rows[0]["BId"].ToString(),
                    BName =ds.Tables[3].Rows[0]["BName"].ToString(),
                    TId = ds.Tables[3].Rows[0]["TId"].ToString(),
                    BGId = ds.Tables[3].Rows[0]["BGId"].ToString()
                };

            }
            catch (Exception ex)
            {
            }
            return PartialView(info);
        }
        #endregion
    }
}