using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using auRant.Core.Entities.Base;

namespace auRant.Core.Entities
{
    public class SuplierTelephone : BaseEntity
    {
        /// <summary>
        /// the suplier's id
        /// </summary>
        [Column("SUPL_ID_SUPLIER")]
        public virtual Suplier Suplier { get; set; }

        /// <summary>
        /// telephone's area code
        /// </summary>
        [Column("TELE_DS_AREA_CODE")]
        public string AreaCode { get; set; }

        /// <summary>
        /// telephone's number
        /// </summary>
        [Column("TELE_NR_TELEPHONE")]
        public string TelephoneNumber { get; set; }


    }
}
