using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Watch.Entities
{
    public class ReviewWatch : FullAuditedEntity<long>
    {
        public long? WatchId { get; set; }
        [ForeignKey(nameof(WatchId))] 

        public Watch Watch { get; set; }

        public string Comment { get; set; }
    }
}
