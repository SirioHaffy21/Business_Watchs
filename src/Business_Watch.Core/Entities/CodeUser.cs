using Abp.Domain.Entities.Auditing;
using Business_Watch.Authorization.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Watch.Entities
{
    public class CodeUser : FullAuditedEntity<long>
    {
        public long? CodeId { get; set; }

        [ForeignKey(nameof(CodeId))]
        public Code_Discount Code_Discount { get; set; }

        public long? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public bool? IsExpired { get; set; }
    }
}
