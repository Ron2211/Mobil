using Mobil.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OfficeOpenXml.Table;
using OfficeOpenXml;
using System.IO;
using ClosedXML.Excel;

namespace Mobil.Controllers
{
    public class DailySheetController : Controller
    {
        // GET: DailySheet
        public ActionResult Index()
        {
            try
            {
                DataTable dtResult = new DataTable();

                #region Get User list
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GetAllDataDailySheet", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            da.SelectCommand = cmd;
                            da.Fill(dtResult);
                        }
                    }
                }
                #endregion

                #region Prepare data to rerurn into view
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    List<DailySheet> list = (from dr in dtResult.AsEnumerable()
                                       select new DailySheet()
                                       {
                                           ID = Convert.ToInt64(dr["ID"]),
                                           Name = Convert.ToString(dr["Name"]),
                                           Date = Convert.ToDateTime(dr["Date"]),
                                           Time = Convert.ToDateTime(dr["Time"]),
                                           Day = Convert.ToString(dr["Day"]),
                                           Tank_one_dip = Convert.ToDecimal(dr["Tank_one_dip"]),
                                           Tank_two_dip = Convert.ToDecimal(dr["Tank_two_dip"]),
                                           Tank_three_dip = Convert.ToDecimal(dr["Tank_three_dip"]),
                                           Tank_four_dip = Convert.ToDecimal(dr["Tank_four_dip"]),
                                           Tank_five_dip = Convert.ToDecimal(dr["Tank_five_dip"]),
                                           Tank_six_dip = Convert.ToDecimal(dr["Tank_six_dip"]),
                                           TF_price_e10 = Convert.ToDecimal(dr["TF_price_e10"]),
                                           TF_price_91 = Convert.ToDecimal(dr["TF_price_91"]),
                                           TF_price_98 = Convert.ToDecimal(dr["TF_price_98"]),
                                           TF_price_Diesel = Convert.ToDecimal(dr["TF_price_Diesel"]),
                                           TLS_e10 = Convert.ToDecimal(dr["TLS_e10"]),
                                           TLS_91 = Convert.ToDecimal(dr["TLS_91"]),
                                           TLS_98 = Convert.ToDecimal(dr["TLS_98"]),
                                           TLS_Diesel = Convert.ToDecimal(dr["TLS_Diesel"]),
                                           TD_e10 = Convert.ToDecimal(dr["TD_e10"]),
                                           TD_91 = Convert.ToDecimal(dr["TD_91"]),
                                           TD_98 = Convert.ToDecimal(dr["TD_98"]),
                                           TD_Diesel = Convert.ToDecimal(dr["TD_Diesel"]),
                                           TLS_Total = Convert.ToDecimal(dr["TLS_Total"]),
                                           TD_Total = Convert.ToDecimal(dr["TD_Total"]),
                                           HotFood = Convert.ToDecimal(dr["HotFood"]),
                                           Pai = Convert.ToDecimal(dr["Pai"]),
                                           ColdFood = Convert.ToDecimal(dr["ColdFood"]),
                                           Coffee = Convert.ToDecimal(dr["Coffee"]),
                                           TotalHotFood = Convert.ToDecimal(dr["TotalHotFood"]),
                                           Total_efpost = Convert.ToDecimal(dr["Total_efpost"]),
                                           E_efpost = Convert.ToDecimal(dr["E_efpost"]),
                                           MotorPass = Convert.ToDecimal(dr["MotorPass"]),
                                           MotorCharge = Convert.ToDecimal(dr["MotorCharge"]),
                                           FleetCard = Convert.ToDecimal(dr["FleetCard"]),
                                           SafeDrop = Convert.ToDecimal(dr["SafeDrop"]),
                                           CashPaidout = Convert.ToDecimal(dr["CashPaidout"]),
                                           Accounts = Convert.ToDecimal(dr["Accounts"]),
                                           Total = Convert.ToDecimal(dr["Total"]),
                                           TotalSale = Convert.ToDecimal(dr["TotalSale"]),
                                           Shopsale = Convert.ToDecimal(dr["Shopsale"]),
                                           Cigartte = Convert.ToDecimal(dr["Cigartte"]),
                                           E_pay = Convert.ToDecimal(dr["E_pay"]),
                                           Refund = Convert.ToDecimal(dr["Refund"]),
                                           MISC = Convert.ToDecimal(dr["MISC"]),
                                           ATMFilled = Convert.ToDecimal(dr["ATMFilled"]),
                                           Diffrence = Convert.ToDecimal(dr["Diffrence"])
                                       }).ToList();

                    return View("~/views/DailySheet/index.cshtml", list);
                }
                else
                    return View("~/views/DailySheet/index.cshtml", new List<DailySheet>());
                #endregion
            }
            catch (Exception ex)
            {
                return View("~/views/DailySheet/index.cshtml", new List<DailySheet>());
            }
        }

        // GET: DailySheet/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DailySheet/Create
        public ActionResult Create()
        {
            try
            {
                DailySheet model = new DailySheet();
               

                return View(model);
            }
            catch (Exception)
            {
                return View(new DailySheet());
            }
           
        }

        // POST: DailySheet/Create
        [HttpPost]
        public ActionResult Create(DailySheet model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    #region Check Today Sheet Exists or Not
                    DataTable dt = new DataTable();
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ToString()))
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_CheckDateTimeDailySheet", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Date", model.Date);
                            using (SqlDataAdapter da = new SqlDataAdapter())
                            {
                                da.SelectCommand = cmd;
                                da.Fill(dt);
                            }
                        }
                    }
                    if (dt.Rows.Count > 0)
                    throw new Exception("Today Sheet is already submitted!!!");
                    #endregion

                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ToString()))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("sp_DailySheet", con))
                         {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", model.Name);
                        cmd.Parameters.AddWithValue("@Date", model.Date);
                        cmd.Parameters.AddWithValue("@Time", model.Time);
                        cmd.Parameters.AddWithValue("@Day", model.Day);
                        cmd.Parameters.AddWithValue("@Tank_one_dip", model.Tank_one_dip);
                        cmd.Parameters.AddWithValue("@Tank_two_dip", model.Tank_two_dip);
                        cmd.Parameters.AddWithValue("@Tank_three_dip", model.Tank_three_dip);
                        cmd.Parameters.AddWithValue("@Tank_four_dip", model.Tank_four_dip);
                        cmd.Parameters.AddWithValue("@Tank_five_dip", model.Tank_five_dip);
                        cmd.Parameters.AddWithValue("@Tank_six_dip", model.Tank_six_dip);
                        cmd.Parameters.AddWithValue("@TF_price_e10", model.TF_price_e10);
                        cmd.Parameters.AddWithValue("@TF_price_91", model.TF_price_91);
                        cmd.Parameters.AddWithValue("@TF_price_98", model.TF_price_98);
                        cmd.Parameters.AddWithValue("@TF_price_Diesel", model.TF_price_Diesel);
                        cmd.Parameters.AddWithValue("@TLS_e10", model.TLS_e10);
                        cmd.Parameters.AddWithValue("@TLS_91", model.TLS_91);
                        cmd.Parameters.AddWithValue("@TLS_98", model.TLS_98);
                        cmd.Parameters.AddWithValue("@TLS_Diesel", model.TLS_Diesel);
                        cmd.Parameters.AddWithValue("@TD_e10", model.TD_e10);
                        cmd.Parameters.AddWithValue("@TD_91", model.TD_91);
                        cmd.Parameters.AddWithValue("@TD_98", model.TD_98);
                        cmd.Parameters.AddWithValue("@TD_Diesel", model.TD_Diesel);
                        cmd.Parameters.AddWithValue("@TLS_Total", model.TLS_Total);
                        cmd.Parameters.AddWithValue("@TD_Total", model.TD_Total);
                        cmd.Parameters.AddWithValue("@HotFood", model.HotFood);
                        cmd.Parameters.AddWithValue("@Pai", model.Pai);
                        cmd.Parameters.AddWithValue("@ColdFood", model.ColdFood);
                        cmd.Parameters.AddWithValue("@Coffee", model.Coffee);
                        cmd.Parameters.AddWithValue("@TotalHotFood", model.TotalHotFood);
                        cmd.Parameters.AddWithValue("@Total_efpost", model.Total_efpost);
                        cmd.Parameters.AddWithValue("@E_efpost", model.E_efpost);
                        cmd.Parameters.AddWithValue("@MotorPass", model.MotorPass);
                        cmd.Parameters.AddWithValue("@MotorCharge", model.MotorCharge);
                        cmd.Parameters.AddWithValue("@FleetCard", model.FleetCard);
                        cmd.Parameters.AddWithValue("@SafeDrop", model.SafeDrop);
                        cmd.Parameters.AddWithValue("@CashPaidout", model.CashPaidout);
                        cmd.Parameters.AddWithValue("@Accounts", model.Accounts);
                        cmd.Parameters.AddWithValue("@Total", model.Total);
                        cmd.Parameters.AddWithValue("@TotalSale", model.TotalSale);
                        cmd.Parameters.AddWithValue("@Shopsale", model.Shopsale);
                        cmd.Parameters.AddWithValue("@Cigartte", model.Cigartte);
                        cmd.Parameters.AddWithValue("@E_pay", model.E_pay);
                        cmd.Parameters.AddWithValue("@Refund", model.Refund);
                        cmd.Parameters.AddWithValue("@MISC", model.MISC);
                        cmd.Parameters.AddWithValue("@ATMFilled", model.ATMFilled);
                        cmd.Parameters.AddWithValue("@Diffrence", model.Diffrence);
                        cmd.ExecuteNonQuery();
                        }
                    con.Close();
                    }
                    ViewBag.CustomMessage = "Successfully Done";
                    return RedirectToAction("Index");
                }
                ViewBag.CustomMessage = "Please Try Again";
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.CustomMessage = "Please Try Again";
                return View(model);
            }
        }

        // GET: DailySheet/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new DailySheet();
            try
            {
                DataTable dtResult = new DataTable();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GetDailySheetRecordByID_Get", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", id);
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            da.SelectCommand = cmd;
                            da.Fill(dtResult);
                        }
                    }
                }

                if (dtResult.Rows.Count > 0)
                {
                    model.ID = Convert.ToInt64(dtResult.Rows[0]["ID"]);
                    model.Name = dtResult.Rows[0]["Name"].ToString();
                    model.Date = Convert.ToDateTime( dtResult.Rows[0]["Date"]);
                    model.Time = Convert.ToDateTime(dtResult.Rows[0]["Time"]);
                    model.Day = dtResult.Rows[0]["Day"].ToString();
                    model.Tank_one_dip = Convert.ToDecimal(dtResult.Rows[0]["Tank_one_dip"]);
                    model.Tank_two_dip = Convert.ToDecimal(dtResult.Rows[0]["Tank_two_dip"]);
                    model.Tank_three_dip = Convert.ToDecimal(dtResult.Rows[0]["Tank_three_dip"]);
                    model.Tank_four_dip = Convert.ToDecimal(dtResult.Rows[0]["Tank_four_dip"]);
                    model.Tank_five_dip = Convert.ToDecimal(dtResult.Rows[0]["Tank_five_dip"]);
                    model.Tank_six_dip = Convert.ToDecimal(dtResult.Rows[0]["Tank_six_dip"]);
                    model.TF_price_e10 = Convert.ToDecimal(dtResult.Rows[0]["TF_price_e10"]);
                    model.TF_price_91 = Convert.ToDecimal(dtResult.Rows[0]["TF_price_91"]);
                    model.TF_price_98 = Convert.ToDecimal(dtResult.Rows[0]["TF_price_98"]);
                    model.TF_price_Diesel = Convert.ToDecimal(dtResult.Rows[0]["TF_price_Diesel"]);
                    model.TLS_e10 = Convert.ToDecimal(dtResult.Rows[0]["TLS_e10"]);
                    model.TLS_91 = Convert.ToDecimal(dtResult.Rows[0]["TLS_91"]);
                    model.TLS_98 = Convert.ToDecimal(dtResult.Rows[0]["TLS_98"]);
                    model.TLS_Diesel = Convert.ToDecimal(dtResult.Rows[0]["TLS_Diesel"]);
                    model.TD_e10 = Convert.ToDecimal(dtResult.Rows[0]["TD_e10"]);
                    model.TD_91 = Convert.ToDecimal(dtResult.Rows[0]["TD_91"]);
                    model.TD_98 = Convert.ToDecimal(dtResult.Rows[0]["TD_98"]);
                    model.TD_Diesel = Convert.ToDecimal(dtResult.Rows[0]["TD_Diesel"]);
                    model.TLS_Total = Convert.ToDecimal(dtResult.Rows[0]["TLS_Total"]);
                    model.TD_Total = Convert.ToDecimal(dtResult.Rows[0]["TD_Total"]);
                    model.HotFood = Convert.ToDecimal(dtResult.Rows[0]["HotFood"]);
                    model.Pai = Convert.ToDecimal(dtResult.Rows[0]["Pai"]);
                    model.ColdFood = Convert.ToDecimal(dtResult.Rows[0]["ColdFood"]);
                    model.Coffee = Convert.ToDecimal(dtResult.Rows[0]["Coffee"]);
                    model.TotalHotFood = Convert.ToDecimal(dtResult.Rows[0]["TotalHotFood"]);
                    model.Total_efpost = Convert.ToDecimal(dtResult.Rows[0]["Total_efpost"]);
                    model.E_efpost = Convert.ToDecimal(dtResult.Rows[0]["E_efpost"]);
                    model.MotorPass = Convert.ToDecimal(dtResult.Rows[0]["MotorPass"]);
                    model.MotorCharge = Convert.ToDecimal(dtResult.Rows[0]["MotorCharge"]);
                    model.FleetCard = Convert.ToDecimal(dtResult.Rows[0]["FleetCard"]);
                    model.SafeDrop = Convert.ToDecimal(dtResult.Rows[0]["SafeDrop"]);
                    model.CashPaidout = Convert.ToDecimal(dtResult.Rows[0]["CashPaidout"]);
                    model.Accounts = Convert.ToDecimal(dtResult.Rows[0]["Accounts"]);
                    model.Total = Convert.ToDecimal(dtResult.Rows[0]["Total"]);
                    model.TotalSale = Convert.ToDecimal(dtResult.Rows[0]["TotalSale"]);
                    model.Shopsale = Convert.ToDecimal(dtResult.Rows[0]["Shopsale"]);
                    model.Cigartte = Convert.ToDecimal(dtResult.Rows[0]["Cigartte"]);
                    model.E_pay = Convert.ToDecimal(dtResult.Rows[0]["E_pay"]);
                    model.Refund = Convert.ToDecimal(dtResult.Rows[0]["Refund"]);
                    model.MISC = Convert.ToDecimal(dtResult.Rows[0]["MISC"]);
                    model.ATMFilled = Convert.ToDecimal(dtResult.Rows[0]["ATMFilled"]);
                    model.Diffrence = Convert.ToDecimal(dtResult.Rows[0]["Diffrence"]);
                    return View(model);
                }
                else
                    return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        // POST: DailySheet/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DailySheet model)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("UserID is invalid.");

                if (ModelState.IsValid)
                {
                    #region Check User name Exists or Not while updating
                    DataTable dt = new DataTable();
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ToString()))
                    {
                        using (SqlCommand cmd = new SqlCommand("usp_CheckDailySheetExistsWhileUpdate_GetByDate", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", id);
                            cmd.Parameters.AddWithValue("@Date", model.Date);
                            using (SqlDataAdapter da = new SqlDataAdapter())
                            {
                                da.SelectCommand = cmd;
                                da.Fill(dt);
                            }
                        }
                    }
                    if (dt.Rows.Count > 0)
                        throw new Exception("DailySheet is already exists!!!");
                    #endregion


                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ToString()))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("usp_UpdateUser_Update", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Name", model.Name);
                            cmd.Parameters.AddWithValue("@Date", model.Date);
                            cmd.Parameters.AddWithValue("@Time", model.Time);
                            cmd.Parameters.AddWithValue("@Day", model.Day);
                            cmd.Parameters.AddWithValue("@Tank_one_dip", model.Tank_one_dip);
                            cmd.Parameters.AddWithValue("@Tank_two_dip", model.Tank_two_dip);
                            cmd.Parameters.AddWithValue("@Tank_three_dip", model.Tank_three_dip);
                            cmd.Parameters.AddWithValue("@Tank_four_dip", model.Tank_four_dip);
                            cmd.Parameters.AddWithValue("@Tank_five_dip", model.Tank_five_dip);
                            cmd.Parameters.AddWithValue("@Tank_six_dip", model.Tank_six_dip);
                            cmd.Parameters.AddWithValue("@TF_price_e10", model.TF_price_e10);
                            cmd.Parameters.AddWithValue("@TF_price_91", model.TF_price_91);
                            cmd.Parameters.AddWithValue("@TF_price_98", model.TF_price_98);
                            cmd.Parameters.AddWithValue("@TF_price_Diesel", model.TF_price_Diesel);
                            cmd.Parameters.AddWithValue("@TLS_e10", model.TLS_e10);
                            cmd.Parameters.AddWithValue("@TLS_91", model.TLS_91);
                            cmd.Parameters.AddWithValue("@TLS_98", model.TLS_98);
                            cmd.Parameters.AddWithValue("@TLS_Diesel", model.TLS_Diesel);
                            cmd.Parameters.AddWithValue("@TD_e10", model.TD_e10);
                            cmd.Parameters.AddWithValue("@TD_91", model.TD_91);
                            cmd.Parameters.AddWithValue("@TD_98", model.TD_98);
                            cmd.Parameters.AddWithValue("@TD_Diesel", model.TD_Diesel);
                            cmd.Parameters.AddWithValue("@TLS_Total", model.TLS_Total);
                            cmd.Parameters.AddWithValue("@TD_Total", model.TD_Total);
                            cmd.Parameters.AddWithValue("@HotFood", model.HotFood);
                            cmd.Parameters.AddWithValue("@Pai", model.Pai);
                            cmd.Parameters.AddWithValue("@ColdFood", model.ColdFood);
                            cmd.Parameters.AddWithValue("@Coffee", model.Coffee);
                            cmd.Parameters.AddWithValue("@TotalHotFood", model.TotalHotFood);
                            cmd.Parameters.AddWithValue("@Total_efpost", model.Total_efpost);
                            cmd.Parameters.AddWithValue("@E_efpost", model.E_efpost);
                            cmd.Parameters.AddWithValue("@MotorPass", model.MotorPass);
                            cmd.Parameters.AddWithValue("@MotorCharge", model.MotorCharge);
                            cmd.Parameters.AddWithValue("@FleetCard", model.FleetCard);
                            cmd.Parameters.AddWithValue("@SafeDrop", model.SafeDrop);
                            cmd.Parameters.AddWithValue("@CashPaidout", model.CashPaidout);
                            cmd.Parameters.AddWithValue("@Accounts", model.Accounts);
                            cmd.Parameters.AddWithValue("@Total", model.Total);
                            cmd.Parameters.AddWithValue("@TotalSale", model.TotalSale);
                            cmd.Parameters.AddWithValue("@Shopsale", model.Shopsale);
                            cmd.Parameters.AddWithValue("@Cigartte", model.Cigartte);
                            cmd.Parameters.AddWithValue("@E_pay", model.E_pay);
                            cmd.Parameters.AddWithValue("@Refund", model.Refund);
                            cmd.Parameters.AddWithValue("@MISC", model.MISC);
                            cmd.Parameters.AddWithValue("@ATMFilled", model.ATMFilled);
                            cmd.Parameters.AddWithValue("@Diffrence", model.Diffrence);
                            cmd.ExecuteNonQuery();
                        }
                        con.Close();
                    }
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        // GET: DailySheet/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DailySheet/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ExportToExcel(int id)
        {
            MobilEntities db = new MobilEntities();
            List<DailySheet> dailySheets = db.tbl_DailySheet.Select(x => new DailySheet
            {
                ID = x.ID,
                Name = x.Name,
                Date = (DateTime)x.Date,
                Day = x.Day,
                Tank_one_dip = (decimal)x.Tank_one_dip,
                Tank_two_dip = (decimal)x.Tank_two_dip,
                Tank_three_dip = (decimal)x.Tank_three_dip,
                Tank_four_dip = (decimal)x.Tank_four_dip,
                Tank_five_dip = (decimal)x.Tank_five_dip,
                Tank_six_dip = (decimal)x.Tank_six_dip


            }).Where(c => c.ID == id).ToList();

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["B2"].Value = "Name:";
            ws.Cells["D2"].Value = "Date:";
            ws.Cells["F2"].Value = "Day:";
            ws.Cells["B3"].Value = "Dips";
            ws.Cells["B4"].Value = "Tank 1";
            ws.Cells["C4"].Value = "Premium 98";
            ws.Cells["D4"].Value = "4300";
            ws.Cells["E4"].Value = "Yes - No";
            ws.Cells["B5"].Value = "Tank 2";
            ws.Cells["C5"].Value = "Premium Diesel";
            ws.Cells["D5"].Value = "26000";
            ws.Cells["E5"].Value = "Yes - No";
            ws.Cells["B6"].Value = "Tank 3";
            ws.Cells["C6"].Value = "Unleaded E10";
            ws.Cells["D6"].Value = "4300";
            ws.Cells["E6"].Value = "Yes - No";
            ws.Cells["B7"].Value = "Tank 4";
            ws.Cells["C7"].Value = "Unleaded E10";
            ws.Cells["D7"].Value = "4300";
            ws.Cells["E7"].Value = "Yes - No";
            ws.Cells["B8"].Value = "Tank 5";
            ws.Cells["C8"].Value = "Unleaded 91";
            ws.Cells["D8"].Value = "4300";
            ws.Cells["E8"].Value = "Yes - No";
            ws.Cells["B9"].Value = "Tank 6";
            ws.Cells["C9"].Value = "Unleaded 91";
            ws.Cells["D9"].Value = "10000";
            ws.Cells["E9"].Value = "Yes - No";
            int rowStart = 7;
            foreach (var item in dailySheets)
            {
                ws.Cells[string.Format("C2", rowStart)].Value = item.Name;
                ws.Cells[string.Format("E2", rowStart)].Value = item.Date;
                ws.Cells[string.Format("G2", rowStart)].Value = item.Day;
                ws.Cells[string.Format("F4", rowStart)].Value = item.Tank_one_dip;
                ws.Cells[string.Format("F5", rowStart)].Value = item.Tank_one_dip;
                ws.Cells[string.Format("F6", rowStart)].Value = item.Tank_one_dip;
                ws.Cells[string.Format("F7", rowStart)].Value = item.Tank_one_dip;
                ws.Cells[string.Format("F8", rowStart)].Value = item.Tank_one_dip;
                ws.Cells[string.Format("F9", rowStart)].Value = item.Tank_one_dip;

                rowStart++;
            }
            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "Report.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
            return View();
        }

    }
}
