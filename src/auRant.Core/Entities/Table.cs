using System.ComponentModel.DataAnnotations;
using auRant.Core.Entities.Base;
using System;
namespace auRant.Core.Entities
{
    [Table("TABLE")]
    public class Table : BasePublishableEntity
    {
        [Column("TABL_NM_TABLE")]
        public string Name { get; set; }

        [Column("TABL_NR_TABLE")]
        public int TableNumber { get; set; }

        [Column("TABL_NR_CAPACIDADE")]
        public int Capacity { get; set; }

        [Column("TABL_DS_PASSWORD")]
        public Guid? Password { get; set; }
    }
}
