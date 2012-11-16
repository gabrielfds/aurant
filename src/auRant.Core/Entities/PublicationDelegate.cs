using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auRant.Core.Entities.Base;

namespace auRant.Core.Entities
{
    public delegate void PublicationDelegate(BasePublishableEntity draft, PublicationStatus status, BaseEntity originalEntity = null);
}
