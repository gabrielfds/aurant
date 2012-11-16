using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auRant.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace auRant.Core.Entities
{
    [Table("MANUFACTOR")]
    public class Manufactor: BaseEntity
    {
        /// <summary>
        /// The artist's name
        /// </summary>
        [Column("MANU_NM_MANUFACTOR")]
        public string Name { get; set; }
    }
}
    