using Abp.Domain.Entities.Auditing;
using Business_Watch.Constants.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Business_Watch.Entities
{
    public class Watch : FullAuditedEntity<long>
    {
        public string Name { get; set; }

        public Category_Watch? Category_Watch { get; set; }

        public Category_Human_Watch? Category_Human_Watch { get; set; }

        public string Description { get; set; }

        public int? Quantity { get; set; }

        public string Insurance { get; set; }

        public double? Origin_Price { get; set; }

        public double? Current_Price { get; set; }

        public long? CodeDiscoutnId { get; set; }

        [ForeignKey(nameof(CodeDiscoutnId))]
        public Code_Discount Code_Discount { get; set; }

        public long? TradeMark_Id { get; set; }

        [ForeignKey(nameof(TradeMark_Id))]
        public TradeMark_Watch TradeMark_Watch { get; set; }

        public DateTime? Date_Release { get; set; }

        public string Note { get; set; }

        public ICollection<ReviewWatch> ReviewWatches { get; set; }
    }
}
