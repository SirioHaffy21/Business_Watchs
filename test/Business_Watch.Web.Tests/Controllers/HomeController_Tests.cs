using System.Threading.Tasks;
using Business_Watch.Models.TokenAuth;
using Business_Watch.Web.Controllers;
using Shouldly;
using Xunit;

namespace Business_Watch.Web.Tests.Controllers
{
    public class HomeController_Tests: Business_WatchWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}