﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PrestaQi.Model.Dto.Output
{
    public class CreditAverage
    {
        public int Credit_Average { get; set; }
        public int Total_Credit { get; set; }
        public double Amount_Average { get; set; }

        public List<CreditAvarageDetail> CreditAvarageDetails { get; set; }
    }
}
