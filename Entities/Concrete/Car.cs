using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete {
    public class Car:IEntity {

        public int CarId { get; set; }
        public string CarName { get; set; }
        public string CarDescription { get; set; }
        public decimal CarUnitPrice { get; set; }

    }
}
