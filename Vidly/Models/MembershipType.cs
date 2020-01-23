﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public int SignUpFee { get; set; }
        public int DurationInMonths { get; set; }

        public int DiscountRate { get; set; }
        public String MembershipName { get; set; }


        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}