using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WCFService.Models
{
    [DataContract]
    public partial class Category
    {
        public Category()
        {
            this.Products = new List<Product>();
        }

        [DataMember(IsRequired = true, Name = "CatId", Order = 0)]
        public int CategoryID { get; set; }
        [DataMember(IsRequired = true, Name = "CatName", Order = 1)]
        public string CategoryName { get; set; }
        [DataMember(IsRequired = true, Name = "CatDesc", Order = 0)]
        public string Description { get; set; }
        [DataMember(IsRequired = true, Name = "CatPic", Order = 0)]
        public byte[] Picture { get; set; }
        [DataMember(IsRequired = true, Name = "ProductList", Order = 0)]
        public virtual ICollection<Product> Products { get; set; }
    }
}
