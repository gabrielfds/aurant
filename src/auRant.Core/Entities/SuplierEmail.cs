using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using auRant.Core.Entities.Base;

namespace auRant.Core.Entities
{
    public class SuplierEmail: BaseEntity
    {
        /// <summary>
        /// the suplier's id
        /// </summary>
        [Column("SUPL_ID_SUPLIER")]
        public virtual Supplier Supplier { get; set; }

        [Column("SUEM_DS_EMAIL")]
        public string EmailAddress { get; set; }


    }
}
