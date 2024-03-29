﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs {
    public class RentalDetailDto {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
