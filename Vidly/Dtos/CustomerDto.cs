﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {


        public int Id { get; set; } = 0;

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        
        public bool IsSubscribedToNewsLetter { get; set; }

        
        public byte MembershipTypeId { get; set; }

        [Min18YearsIfAMember]
        
        public DateTime? BirthDate { get; set; }

        public int DrivingLicense { get; set; }
    }
}