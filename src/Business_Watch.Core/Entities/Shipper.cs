using Abp.Domain.Entities.Auditing;
using Business_Watch.Constants.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business_Watch.Entities
{
    public class Shipper : FullAuditedEntity<long>
    {
        public string TradeMark_Shipper { get; set; }

        public string Shipper_Description { get; set; }

        public double Shipper_PriceRent { get; set; }

        public Postage Postage { get; set; }

        public long? BankId { get; set; }

        [ForeignKey(nameof(BankId))]
        public Bank Bank { get; set; }

        public  Status_Shipper? Status_Shipper { get; set; }
    }
}
