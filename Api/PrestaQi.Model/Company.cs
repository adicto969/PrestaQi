﻿using PrestaQi.Model.General;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrestaQi.Model
{
    [Table("companies")]
    public class Company : Entity<int>
    {
        [Column("description")]
        public string Description { get; set; }
        [Column("enabled")]
        public bool Enabled { get; set; }
    }
}
