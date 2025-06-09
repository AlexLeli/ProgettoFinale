using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class ProductInventory
    {
        public int ProductId { get; set; }

        [JsonIgnore]
        public Product? Product { get; set; }

        public int InventoryId { get; set; }

        [JsonIgnore]
        public Inventory? Inventory { get; set; }

        public int InventoryQuantity { get; set; }
    }
}
