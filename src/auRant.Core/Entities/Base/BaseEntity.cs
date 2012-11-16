using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace auRant.Core.Entities.Base
{
    /// <summary>
    /// Base class for all entities
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// The entitie Id
        /// </summary>
        [Key]
        public int ID { get; set; }     

        public BaseEntity()
        {
        }
    }
   
}
