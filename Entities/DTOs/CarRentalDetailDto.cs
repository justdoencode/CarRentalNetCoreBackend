﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarRentalDetailDto:IDto
    {
        public int RentalId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public string BrandName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
