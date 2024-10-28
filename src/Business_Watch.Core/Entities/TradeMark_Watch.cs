using Abp.Domain.Entities.Auditing;
using System;

namespace Business_Watch.Entities
{
    public class TradeMark_Watch : FullAuditedEntity<long>
    {

        public string Name { get; set; }

        public string Country_Origin { get; set; }

        public DateTime? Date_Release { get; set; }

        public string Description { get; set; }

        public string Note { get; set; }

    }
}
