using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mobil.Models
{
    public class DailySheet
    {
        public long UID { get; set; }

        
        [DisplayName("User Type")]
        public long UserTypeID { get; set; }

        public long ID { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Date")]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [DisplayName("Time")]
        public DateTime Time { get; set; }

        [DisplayName("Day")]
        public string Day { get; set; }

        [DisplayName("Tank 1 [ Premium 98 ]")]
        public Decimal Tank_one_dip { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirm Tank Dip required")]
        [System.ComponentModel.DataAnnotations.Compare("Tank_one_dip")]
        public Decimal Tank1 { get; set; }

        [DisplayName("Tank 2 [ Premium Diesel ]")]
        public Decimal Tank_two_dip { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirm Tank Dip required")]
        [System.ComponentModel.DataAnnotations.Compare("Tank_two_dip")]
        public Decimal Tank2 { get; set; }

        [DisplayName("Tank 3 [ Unleaseded E10 ]")]
        public Decimal Tank_three_dip { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirm Tank Dip required")]
        [System.ComponentModel.DataAnnotations.Compare("Tank_three_dip")]
        public Decimal Tank3 { get; set; }

        [DisplayName("Tank 4 [ Unleaseded E10 ]")]
        public Decimal Tank_four_dip { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirm Tank Dip required")]
        [System.ComponentModel.DataAnnotations.Compare("Tank_four_dip")]
        public Decimal Tank4 { get; set; }

        [DisplayName("Tank 5 [ Unleaseded 91 ]")]
        public Decimal Tank_five_dip { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirm Tank Dip required")]
        [System.ComponentModel.DataAnnotations.Compare("Tank_five_dip")]
        public Decimal Tank5 { get; set; }

        [DisplayName("Tank 6 [ Unleaseded 91 ]")]
        public Decimal Tank_six_dip { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirm Tank Dip required")]
        [System.ComponentModel.DataAnnotations.Compare("Tank_six_dip")]
        public Decimal Tank6 { get; set; }

        [DisplayName(" Unleaded E10 Price")]
        public Decimal TF_price_e10 { get; set; }

        [DisplayName(" Unleaded 91 Price")]
        public Decimal TF_price_91 { get; set; }

        [DisplayName(" Premium 98 Price")]
        public Decimal TF_price_98 { get; set; }

        [DisplayName(" Premium Diesel Price")]
        public Decimal TF_price_Diesel { get; set; }

        [DisplayName("Total Liters Unleaded E10 Sold")]
        public Decimal TLS_e10 { get; set; }

        [DisplayName("Total Liters Unleaded 91 Sold")]
        public Decimal TLS_91 { get; set; }

        [DisplayName("Total Liters Premium 98 Sold")]
        public Decimal TLS_98 { get; set; }

        [DisplayName("Total Liters Premium Diesel Sold")]
        public Decimal TLS_Diesel { get; set; }

        [DisplayName("Total Dollar Unleaded E10 ")]
        public Decimal TD_e10 { get; set; }

        [DisplayName("Total Dollar Unleaded 91 ")]
        public Decimal TD_91 { get; set; }

        [DisplayName("Total Dollar Premium 98 ")]
        public Decimal TD_98 { get; set; }

        [DisplayName("Total Dollar Premium Diesel ")]
        public Decimal TD_Diesel { get; set; }

        [DisplayName("Total Liters Fuel ")]
        public Decimal TLS_Total { get; set; }

        [DisplayName("Total Dollar Fuel ")]
        public Decimal TD_Total { get; set; }

        [DisplayName("Hot Food ")]
        public Decimal HotFood { get; set; }

        [DisplayName("Gundai PIE ")]
        public Decimal Pai { get; set; }

        [DisplayName("Cold Food Sandwich ")]
        public Decimal ColdFood { get; set; }

        [DisplayName("Coffee ")]
        public Decimal Coffee { get; set; }

        [Required]
        [DisplayName("Total Hot Food")]
        public Decimal TotalHotFood { get; set; }

        [Required]
        [DisplayName("Total Efpost")]
        public Decimal Total_efpost { get; set; }

        [DisplayName("Emergency Efpost ")]
        public Decimal E_efpost { get; set; }

        [DisplayName("Motor Pass ")]
        public Decimal MotorPass { get; set; }

        [DisplayName("Motor Charge ")]
        public Decimal MotorCharge { get; set; }

        [DisplayName("Fleet Card ")]
        public Decimal FleetCard { get; set; }

        [Required]
        [DisplayName("Safe Drop ")]
        public Decimal SafeDrop { get; set; }

        [DisplayName("Cash Paid Out")]
        public Decimal CashPaidout { get; set; }

        [DisplayName("Accounts ")]
        public Decimal Accounts { get; set; }

        [Required]
        [DisplayName("Total")]
        public Decimal Total { get; set; }

        [Required]
        [DisplayName("Total Sale")]
        public Decimal TotalSale { get; set; }

        [Required]
        [DisplayName("Shop Sale")]
        public Decimal Shopsale { get; set; }

        [DisplayName("Cigarttes Sale")]
        public Decimal Cigartte { get; set; }

        [DisplayName("E-Pay")]
        public Decimal E_pay { get; set; }

        [DisplayName("Refund")]
        public Decimal Refund { get; set; }

        [DisplayName("MICS")]
        public Decimal MISC { get; set; }

        [DisplayName("ATM Filled")]
        public Decimal ATMFilled { get; set; }

        [Required]
        [DisplayName("Diffrence")]
        public Decimal Diffrence { get; set; }


      
        [DisplayName("User Name")]
        public string UName { get; set; }

       
        [DisplayName("User Password")]
        public string UPass { get; set; }
    }

    public class LoginUser
    {
        [Required]
        [DisplayName("User Name")]
        public string UName { get; set; }

        [Required]
        [DisplayName("User Password")]
        public string UPass { get; set; }
    }
}