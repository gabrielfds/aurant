using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace auRant.Core.Entities
{
    [Table("STOCK")]
    public class Stock
    {
        /// <summary>
        /// The product in stock
        /// </summary>
        [Column("PROD_SQ_PRODUTO")]
        public Product Product { get; set; }

        /// <summary>
        /// The amount of the product in stock
        /// </summary>
        [Column("STOC_QT_IN_STOCK")]
        public int Quantity { get; set; }
    }
}
