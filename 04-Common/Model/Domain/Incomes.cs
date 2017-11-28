using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Incomes : Helper.AuditEntity, Common.CustomFilters.ISoftDeleted
    {
        public int Id { get; set; }
        public Enums.EntityType EntityType { get; set; }
        public Enums.IncomeType IncomeType { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        public int EntityID { get; set; }

        public bool Deleted { get; set; }
    }
}
