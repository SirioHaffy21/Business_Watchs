using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Business_Watch.Entities
{
    public class Order : FullAuditedEntity<long>
    {
        public Guid? OrderId { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? ExpriedTime { get; set; }

        public long? Order_DetailId { get; set; }

        [ForeignKey(nameof(Order_DetailId))]
        public Order_Detail Order_Detail { get; set; }
    }
}
