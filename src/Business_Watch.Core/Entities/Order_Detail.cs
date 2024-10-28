using Abp.Domain.Entities.Auditing;
using Business_Watch.Constants.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Watch.Entities
{
    public class Order_Detail : FullAuditedEntity<long>
    {
        public long OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }

        public long WatchId { get; set; }

        [ForeignKey(nameof(WatchId))]
        public Watch Watch { get; set; }

        public long? ShipperId { get; set; }

        [ForeignKey(nameof(ShipperId))]
        public Shipper Shipper { get; set; }

        public Category_Pay? Category_Pay { get; set; }

        public Time_Delivery? Time_Delivery { get; set; }

        public long? CodeDiscountId { get; set; }

        [ForeignKey(nameof(CodeDiscountId))]
        public Code_Discount Code_Discount { get; set; }

        public int? Quantity { get; set; }

        public double? Total_Price { get; set; }
    }
}
