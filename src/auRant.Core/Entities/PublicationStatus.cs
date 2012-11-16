using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using auRant.Core.Entities.Base;

namespace auRant.Core.Entities
{
    [Table("PUBLICATION_STATUS")]
    public class PublicationStatus:BaseEntity
    {
        [Column("PBST_NM_STATUS")]
        /// <summary>
        /// The product name
        /// </summary>
        public string Name { get; set; }

        [Column("PBST_VL_STATUS")]
        /// <summary>
        /// The status value
        /// </summary>
        public string Value { get; set; }

    }
}
