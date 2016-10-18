using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Offers.Builders;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Tests.Controllers.Offers.Builders
{
    [TestFixture]
    public class MyOffersViewModelBuilderTest
    {
        private IOrangeBricksContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<IOrangeBricksContext>();
        }

        [Test]
        public void BuilderShouldReturnAcceptedOffersForUser()
        {
            // Arrange
            var builder = new MyOffersViewModelBuilder(_context);

            var properties = new List<Models.Property>{
                new Models.Property{ Id = 1, StreetName = "Smith Street", Description = "", IsListedForSale = true },
                new Models.Property{ Id = 2, StreetName = "Jones Street", Description = "", IsListedForSale = true}
            };

            var offers = new List<Offer>()
            {
                new Offer { BuyerUserId = "user1", Amount = 100000, PropertyId = 1, Status = OfferStatus.Accepted },
                new Offer { BuyerUserId = "user1", Amount = 100000, PropertyId = 2, Status = OfferStatus.Rejected },
                new Offer { BuyerUserId = "user2", Amount = 150000, PropertyId = 2, Status = OfferStatus.Accepted },
            };

            var propertiesMockSet = Substitute.For<IDbSet<Models.Property>>().Initialize(properties.AsQueryable());
            var offersMockSet = Substitute.For<IDbSet<Offer>>().Initialize(offers.AsQueryable());

            _context.Properties.Returns(propertiesMockSet);
            _context.Offers.Returns(offersMockSet);

            // Act
            var viewModel = builder.Build("user1");

            // Assert
            Assert.That(viewModel.AcceptedOffers.Count, Is.EqualTo(1));
        }
    }
}
