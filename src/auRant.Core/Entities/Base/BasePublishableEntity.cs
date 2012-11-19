using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace auRant.Core.Entities.Base
{
    public class BasePublishableEntity:BaseEntity
    {
        [Column("PBST_ID_PUBLICATION_STATUS")]
        public PublicationStatus PublicationStatus { get; set; }
    }
}
