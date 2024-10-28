using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Watch.Entities
{
    public class ReviewShipper : FullAuditedEntity<long>
    {
        public long? ShipperId { get; set; }

        [ForeignKey(nameof(ShipperId))]
        public Shipper Shipper { get; set; }

        public string Comment { get; set; }
    }
}
