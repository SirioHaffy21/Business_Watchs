using Abp.AutoMapper;
using Business_Watch.Constants.Enum;
using Business_Watch.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Watch.APIs.Banks.Dto
{
    [AutoMap(typeof(Bank))]
    public class BankDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string NumberBank { get; set; }
        public Category_BankAccount? Category_BankAccount { get; set; }
    }
}
