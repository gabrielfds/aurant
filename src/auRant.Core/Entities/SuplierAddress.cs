﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auRant.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace auRant.Core.Entities
{
    [Table("SUPLIER_ADDRESS")]
    public class SupllierAddress: BaseEntity
    {
        /// <summary>
        /// the suplier's id
        /// </summary>
        public virtual Supplier Supplier { get; set; }

        /// <summary>
        /// the address kind (rua, avenida)
        /// </summary>
        [Column("SUAD_TP_ADDRESS")]
        public string AddressType { get; set; }


        /// <summary>
        /// The addres
        /// </summary>
        [Column("SUAD_DS_ADDRESS")]
        public string Address { get; set; }


        /// <summary>
        /// The address number
        /// </summary>
        [Column("SUAD_NR_ADDRESS")]
        public string Number { get; set; }



    }
}
