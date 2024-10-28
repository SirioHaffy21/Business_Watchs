using Abp.Domain.Entities.Auditing;
using Business_Watch.Constants.Enum;

namespace Business_Watch.Entities
{
    public class Bank : FullAuditedEntity<long>
    {
        public string Bank_Name { get; set; }

        public string NumberBank { get; set; }

        public Category_BankAccount? Category_BankAccount { get; set; }

    }

}
