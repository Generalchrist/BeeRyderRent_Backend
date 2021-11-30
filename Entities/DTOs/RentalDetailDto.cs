using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs {
    public class RentalDetailDto {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime RentDate { get; set; }
        public Nullable<DateTime> ReturnDate { get; set; }
    }
}
