using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete {
    public class CreditCard {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpireMonth { get; set; }
        public string ExpireYear { get; set; }
        public string CVC { get; set; }
    }
}
