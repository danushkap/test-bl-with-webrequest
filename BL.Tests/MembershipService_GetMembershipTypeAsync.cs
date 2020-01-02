using NSubstitute;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace BL.Tests
{
    public class MembershipService_GetMembershipTypeAsync
    {
        [Fact]
        public async Task Should_ReturnPlatinum_When_MembershipAmountIs1500()
        {
            // Arrange
            //
            var fakeWebRequestHandler = Substitute.For<IWebRequestHandler>();

            fakeWebRequestHandler
                .GetStringAsync("https://dummyurl")
                .ReturnsForAnyArgs("1500");

            var sUT = new MembershipService(fakeWebRequestHandler);

            // Act
            //
            var membershipType = await sUT.GetMembershipTypeAsync();

            // Assert
            //
            Assert.Equal(MembershipType.Platinum, membershipType);
        }

        [Fact]
        public async Task Should_ReturnGold_When_MembershipAmountIs700()
        {
            // Arrange
            //
            var fakeWebRequestHandler = Substitute.For<IWebRequestHandler>();

            fakeWebRequestHandler
                .GetStringAsync("https://dummyurl")
                .ReturnsForAnyArgs("700");

            var sUT = new MembershipService(fakeWebRequestHandler);

            // Act
            //
            var membershipType = await sUT.GetMembershipTypeAsync();

            // Assert
            //
            Assert.Equal(MembershipType.Gold, membershipType);
        }

        [Fact]
        public async Task Should_ReturnSilver_When_MembershipAmountIs200()
        {
            // Arrange
            //
            var fakeWebRequestHandler = Substitute.For<IWebRequestHandler>();

            fakeWebRequestHandler
                .GetStringAsync("https://dummyurl")
                .ReturnsForAnyArgs("200");

            var sUT = new MembershipService(fakeWebRequestHandler);

            // Act
            //
            var membershipType = await sUT.GetMembershipTypeAsync();

            // Assert
            //
            Assert.Equal(MembershipType.Silver, membershipType);
        }

        [Fact]
        public async Task Should_ReturnNA_When_MembershipAmountIsZero()
        {
            // Arrange
            //
            var fakeWebRequestHandler = Substitute.For<IWebRequestHandler>();

            fakeWebRequestHandler
                .GetStringAsync("https://dummyurl")
                .ReturnsForAnyArgs("0");

            var sUT = new MembershipService(fakeWebRequestHandler);

            // Act
            //
            var membershipType = await sUT.GetMembershipTypeAsync();

            // Assert
            //
            Assert.Equal(MembershipType.NA, membershipType);
        }

        [Fact]
        public async Task Should_ThrowException_When_RealWebRequestHandlerPassed()
        {
            // Arrange
            //
            var sUT = new MembershipService(new WebRequestHandler());

            // Act
            //
            var exception = await Assert.ThrowsAsync<HttpRequestException>(async () => await sUT.GetMembershipTypeAsync());

            // Assert
            //
            Assert.Equal("No such host is known", exception.Message);
        }
    }
}
