﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fophex.Application.Shared.Accounts.Detail.FinancialYears.Dto
{
    public class CreateFinancialYearDto
    {
        public string  Description { get; set; }
        public DateTime  FromDate { get; set; }
        public DateTime  ToDate { get; set; }
        public bool IsClosed { get; set; }


    }
}