using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auRant.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace auRant.Core.Entities
{
    [Table("PRODUCT_CATEGORY")]
    /// <summary>
    /// The category for all products 
    /// </summary>
    public class ProductCategory:BaseEntity
    {
        [Column("CATEGORY_NAME")]
        /// <summary>
        /// The category name
        /// </summary>
        public string Name { get; set; }
    }
}
