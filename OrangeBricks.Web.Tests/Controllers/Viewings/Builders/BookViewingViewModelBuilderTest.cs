using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Viewings.Builders;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Tests.Controllers.Viewings.Builders
{
    [TestFixture]
    public class BookViewingViewModelBuilderTest
    {
        private IOrangeBricksContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<IOrangeBricksContext>();
        }

        [Test]
        public void BuilderShouldReturnInitialisedAppointmentViewModel()
        {
            // Arrange
            var builder = new BookViewingViewModelBuilder(_context);

            var properties = new List<Models.Property>{
                new Models.Property{ Id = 1, PropertyType = "House", StreetName = "Smith Street", Description = "", IsListedForSale = true },
                new Models.Property{ Id = 2, PropertyType = "Flat", StreetName = "Jones Street", Description = "", IsListedForSale = true}
            };

            var propertiesMockSet = Substitute.For<IDbSet<Models.Property>>().Initialize(properties.AsQueryable());

            _context.Properties.Returns(propertiesMockSet);

            // Act
            var viewModel = builder.Build(1);

            // Assert
            Assert.That(viewModel.Appointment, Is.EqualTo(DateTime.Today));
            Assert.That(viewModel.PropertyId, Is.EqualTo(1));
            Assert.That(viewModel.PropertyType, Is.EqualTo("House"));
            Assert.That(viewModel.StreetName, Is.EqualTo("Smith Street"));
        }
    }
}
