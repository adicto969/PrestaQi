﻿using PrestaQi.Model.General;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrestaQi.Model
{
    [Table("advancedetails")]
    public partial class AdvanceDetail : Entity<int>
    {
        [Column("advance_id")]
        public int Advance_Id { get; set; }
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
        [Column("limit_date")]
        public DateTime Limit_Date { get; set; }
        [Column("day_for_payment")]
        public int Day_For_Payment { get; set; }
    }
}