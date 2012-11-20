using auRant.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace auRant.Core.Entities
{
    [Table("SUPPLIER")]
    public class Supplier: BaseEntity
    {
        /// <summary>
        /// The artist's name
        /// </summary>
        [Column("SUPL_NM_SUPLIER")]
        public string Name { get; set; }

        [Column("SUPL_CNPJ_SUPLIER")]
        /// <summary>
        /// The suplier identification number (cnpj)
        /// </summary>
        public string IdentificationNumber { get; set; }
    }
}
    