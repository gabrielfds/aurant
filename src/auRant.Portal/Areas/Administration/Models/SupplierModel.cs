using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using auRant.Core.Entities;
using System.ComponentModel.DataAnnotations;
using auRant.Core;

namespace auRant.Visual.Areas.Administration.Models
{
    public class SupplierModel
    {
        public SupplierModel()
        {

        }

        /// <summary>
        /// The supplier's ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The supplier's name
        /// </summary>
        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        public string Name { get; set; }


        public SupplierModel(Supplier supplier)
        {
            this.ID = supplier.ID;
            this.Name = supplier.Name;
        }

        public Supplier CreatesupplierFromModel()
        {
            return new Supplier(){
                Name = this.Name
            };
        }
    }
}