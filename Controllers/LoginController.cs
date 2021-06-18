using Mobil.Enum;
using Mobil.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mobil.Controllers
{
    public class LoginController : Controller
    {

        // GET: Login
        public ActionResult Login()
        {
            if (Session["UserTypeID"] != null)
            {
                if (Session["UserTypeID"].ToString() == UserType.Admin.ToString())
                    return RedirectToAction("Index", "DailySheet");
                else if (Session["UserTypeID"].ToString() == UserType.Staff.ToString())
                    return RedirectToAction("Create", "DailySheet");
                else
                    return RedirectToAction("", "");
            }
            else
                return View("~/Views/Login/Login.cshtml", new DailySheet());
        }
        [HttpPost]
        public ActionResult Login(DailySheet model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DataTable dtLogin = new DataTable();
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ToString()))
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_UserLogin_get", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@UName", model.UName);
                            cmd.Parameters.AddWithValue("@UPass", model.UPass);

                            using (SqlDataAdapter da = new SqlDataAdapter())
                            {
                                da.SelectCommand = cmd;
                                da.Fill(dtLogin);
                            }
                        }
                    }

                    if (dtLogin != null && dtLogin.Rows.Count > 0)
                    {
                        Session["UID"] = dtLogin.Rows[0]["UID"].ToString();
                        Session["UName"] = dtLogin.Rows[0]["UName"].ToString();
                        Session["UserTypeID"] = dtLogin.Rows[0]["UserTypeID"].ToString();

                        if (Session["UserTypeID"].ToString() == UserType.Admin.GetHashCode().ToString())
                            return RedirectToAction("Index", "DailySheet");
                        else if (Session["UserTypeID"].ToString() == UserType.Staff.GetHashCode().ToString())
                            return RedirectToAction("Create", "DailySheet");
                        else
                            return RedirectToAction("", "");

                    }
                    else
                    {
                        ViewBag.CustomMessage = "User details are not valid.";
                        return View();
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return Login();
            }
        }

    }
   
}