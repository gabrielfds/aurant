using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using auRant.Core.Entities;
using System.ComponentModel.DataAnnotations;
using auRant.Core;

namespace auRant.Visual.Areas.Administration.Models
{
    public class ManufactorModel
    {
        public ManufactorModel()
        {

        }

        /// <summary>
        /// The manufactor's ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The manufactor's name
        /// </summary>
        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        public string Name { get; set; }


        public ManufactorModel(Suplier manufactor)
        {
            this.ID = manufactor.ID;
            this.Name = manufactor.Name;
        }

        public Suplier CreateManufactorFromModel()
        {
            return new Suplier(){
                Name = this.Name
            };
        }
    }
}