using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using auRant.Core.Entities.Base;

namespace auRant.Core.Entities
{
    [Table("REVIEW")]
    public class Review: BasePublishableEntity
    {
        public Review()
        {

        }
        [Column("PROD_SQ_PRODUCT")]
        public virtual Product Product { get; set; }

        [Column("REVI_TX_REVIEW")]
        public string ReviewText { get; set; }
    }
}
