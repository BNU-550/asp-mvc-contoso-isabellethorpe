﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC_Contoso.Models
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public Nullable<DateTime> EnrollmentDate { get; set; }

        public int StudentCount { get; set; }
    }
}