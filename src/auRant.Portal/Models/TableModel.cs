using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using auRant.Core.Entities;
using auRant.Visual.Models;
using System.ComponentModel.DataAnnotations;

namespace auRant.Visual.Models
{
    public class TableModel:BaseModel
    {
        public TableModel()
        {

        }

        public TableModel(DraftTable draft)
        {
            this.ID = draft.ID;
            this.Name = draft.Name;
            this.Capacity = draft.Capacity;
            this.TableNumber = draft.TableNumber;
            this.IsDraft = true;
        }

        public TableModel(Core.Entities.Table table)
        {
            this.ID = table.ID;
            this.Name = table.Name;
            this.Capacity = table.Capacity;
            this.TableNumber = table.TableNumber;
            this.IsDraft = false;
        }

        public int ID { get; set; }

        [Required(ErrorMessage="The name field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The TableNumber field is required")]
        public int TableNumber { get; set; }

        [Required(ErrorMessage = "The Capacity field is required")]
        public int Capacity { get; set; }

        public bool IsDraft { get; set; }


        public DraftTable CreateDraftFromModel(TableModel model)
        {
            return new DraftTable()
            {
                Name = this.Name,
                Capacity = this.Capacity,
                TableNumber = this.TableNumber
            };
        }


        public DraftTable UpdateDraftFromModel(DraftTable draft)
        {
            draft.Name = this.Name;
            draft.TableNumber = this.TableNumber;
            draft.Capacity = this.Capacity;

            return draft;
        }
    }
}