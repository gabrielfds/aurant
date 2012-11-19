using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using auRant.Core.Entities.Base;

namespace auRant.Core.Entities
{
    /// <summary>
    /// The parameter class
    /// </summary>
    [Table("PARAMETER")]
    public class Parameter:BaseEntity
    {
        /// <summary>
        /// The name of the parameter
        /// </summary>
        [Column("PARA_NM_PARAMETER")]
        public string Name { get; set; }

        /// <summary>
        /// The value for the parameter
        /// </summary>
        [Column("PARA_VL_PARAMETER")]
        public string Value { get; set; }

    }
}
