using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete {
    public class FilterOptions {
        public List<int>? Brands { get; set; }
        public List<int>? Colors { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int? MinModelYear { get; set; }

    }
}
