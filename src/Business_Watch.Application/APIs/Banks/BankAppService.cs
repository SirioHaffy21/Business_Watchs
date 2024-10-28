using Abp.UI;
using Business_Watch.APIs.Banks.Dto;
using Business_Watch.Entities;
using Business_Watch.Extension;
using Business_Watch.Paging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Business_Watch.APIs.Banks
{
    public class BankAppService : Business_WatchAppServiceBase
    {
        [HttpPost]
        public async Task<GridResult<BankDto>> GetAllPagging(GridParam input)
        {
            var query = WorkScope.GetAll<Bank>()
                .Select(s => new BankDto
                {
                    Id = s.Id,
                    Name = s.Bank_Name,
                    NumberBank = s.NumberBank,
                    Category_BankAccount = s.Category_BankAccount,
                });

            return await query.GetGridResult(query, input);
        }

        [HttpGet]
        public async Task<List<BankDto>> GetAllNotPagging()
        {
            return await WorkScope.GetAll<Bank>()
                .Select(s => new BankDto
                {
                    Id = s.Id,
                    Name = s.Bank_Name,
                    NumberBank = s.NumberBank,
                    Category_BankAccount = s.Category_BankAccount
                }).ToListAsync();
        }

        [HttpPost]
        public async Task<BankDto> Save(BankDto input)
        {
            var isExist = await WorkScope.GetAll<Bank>().Where(s => s.Bank_Name == input.Name).Where(s => s.Id != input.Id).AnyAsync();

            if (isExist)
                throw new UserFriendlyException("");

            if (input.Id <= 0)
            {
                var item = ObjectMapper.Map<Bank>(input);

                await WorkScope.InsertAndGetIdAsync(item);
            }
            else
            {
                var item = await WorkScope.GetAsync<Bank>(input.Id);
                ObjectMapper.Map(item, input);
                await WorkScope.UpdateAsync(item);
            }

            return input;
        }

        public async Task Delete(long id)
        {
            await WorkScope.DeleteAsync<Bank>(id);
        }
    }
}
