using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Watch.Entities
{
    public class ReviewTradeMark : FullAuditedEntity<long>
    {
        public long? TradeMarkWatchId { get; set; }
        [ForeignKey(nameof(TradeMarkWatchId))]

        public TradeMark_Watch TradeMark_Watch { get; set; }

        public string Comment { get; set; }
    }
}
