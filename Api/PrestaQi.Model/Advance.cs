﻿using PrestaQi.Model.General;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrestaQi.Model
{
    [Table("advances")]
    public partial class Advance : Entity<int>
    {
        [Column("accredited_id")]
        public int Accredited_Id { get; set; }
        [Column("amount")]
        public double Amount { get; set; }
        [Column("date_advance")]
        public DateTime Date_Advance { get; set; }
        [Column("requested_day")]
        public int Requested_Day { get; set; }
        [Column("total_withhold")]
        public double Total_Withhold { get; set; }
        [Column("comission")]
        public int Comission { get; set; }
        [Column("enabled")]
        public bool Enabled { get; set; }
        [Column("paid_status")]
        public int Paid_Status { get; set; }
        [Column("interest")]
        public double Interest { get; set; }
        [Column("vat")]
        public double Vat { get; set; }
        [Column("subtotal")]
        public double Subtotal { get; set; }
        [Column("interest_moratorium")]
        public double Interest_Moratorium { get; set; }
        [Column("day_moratorium")]
        public double Day_Moratorium { get; set; }
        [Column("limit_date")]
        public DateTime Limit_Date { get; set; }
        [Column("promotional_setting")]
        public double Promotional_Setting { get; set; }
        [Column("day_for_payment")]
        public int Day_For_Payment { get; set; }
        [Column("interest_rate")]
        public int Interest_Rate { get; set; }
    }
}
