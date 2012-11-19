using System.ComponentModel.DataAnnotations;
using auRant.Core.Entities.Base;
using System;

namespace auRant.Core.Entities
{
    [Table("DRAFT_TABLE")]
    public class DraftTable : BasePublishableEntity, IPublishable
    {
        [Column("DRTA_NM_TABLE")]
        public string Name { get; set; }

        [Column("DRTA_NR_TABLE")]
        public int TableNumber { get; set; }

        [Column("DRTA_NR_CAPACIDADE")]
        public int Capacity { get; set; }

        [Column("DRTA_ID_TABLE")]
        public virtual Table OriginalTable { get; set; }

        [Column("DRTA_DS_PASSWORD")]
        public Guid? Password { get; set; }

        public void Publish(BasePublishableEntity draft, PublicationStatus status, BaseEntity originalEntity = null)
        {
            if (((DraftTable)draft).OriginalTable == null)
            {
                ((DraftTable)draft).OriginalTable = new Table()
                {
                    Name = this.Name,
                    Capacity = this.Capacity,
                    TableNumber = this.TableNumber,
                    PublicationStatus = status,
                    Password = this.Password

                };
            }
            else
            {
                Table original = (Table)originalEntity;
                original.PublicationStatus = new Entities.PublicationStatus();
                original.PublicationStatus = status;
                original.Name = this.Name;
                original.TableNumber = this.TableNumber;
                original.Capacity = this.Capacity;
                original.Password = this.Password;
            }
        }

        public void CreateOriginal(BaseEntity original)
        {
            if (original != null)
            {
                this.OriginalTable = (Table)original;
            }
        }
    }
}
