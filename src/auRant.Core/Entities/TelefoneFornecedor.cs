using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using auRant.Core.Entities.Base;

namespace auRant.Core.Entities
{
    [Table("CONTATO")]
    public class TelefoneFornecedor:BaseEntity
    {
        /// <summary>
        /// O fornecedor dono do telefone
        /// </summary>
        public virtual Fornecedor Fornecedor { get; set; }

        /// <summary>
        /// O ddd do telefone do fornecedor
        /// </summary>
        [Column("TELE_NR_DDD")]
        public string NrTelefone { get; set; }

        /// <summary>
        /// O número do telefone do fornecedor
        /// </summary>
        [Column("TELE_NR_TELEFONE")]
        public string NrTelefone { get; set; }

    }
}
