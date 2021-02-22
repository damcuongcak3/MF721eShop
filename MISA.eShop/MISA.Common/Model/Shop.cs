using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Model
{
    public class Shop
    {
        public Guid ShopId { get; set; }
        public string ShopCode { get; set; }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ShopTaxCode { get; set; }
        public string Status { get; set; }
        #region Other
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        #endregion








    }
}
