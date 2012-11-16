using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auRant.Core.Entities.Base;

namespace auRant.Core.Entities
{   
    public interface IPublishable
    {
        void Publish(BasePublishableEntity draft, PublicationStatus status, BaseEntity originalEntity = null);
        void CreateOriginal(BaseEntity original);
    }
}
