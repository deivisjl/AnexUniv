using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Incomes
    {
        public int Id { get; set; }
        public Enums.EntityType EntityType { get; set; }
        public Enums.IncomeType IncomeType { get; set; }
        public decimal Total { get; set; }
        public int EntityID { get; set; }
    }
}
