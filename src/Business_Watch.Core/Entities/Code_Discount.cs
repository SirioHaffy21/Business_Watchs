using Abp.Domain.Entities.Auditing;
using Business_Watch.Constants.Enum;
using System;

namespace Business_Watch.Entities
{
    public class Code_Discount : FullAuditedEntity<long>
    {
        public string Code { get; set; }

        public string Code_Description { get; set; }

        public double? Discount { get; set; }

        public DateTime? DateRelease { get; set; }

        public DateTime? DateExpried { get; set; }

        public Category_Discount? Category_Discount { get; set; }
    }
}
