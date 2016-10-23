using System;
using System.Data.Entity;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Property.Commands;
using OrangeBricks.Web.Controllers.Viewings.Commands;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Tests.Controllers.Viewings.Commands
{
    [TestFixture]
    public class BookViewingCommandHandlerTest
    {
        private BookViewingCommandHandler _handler;
        private IOrangeBricksContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<IOrangeBricksContext>();
            _context.Viewings.Returns(Substitute.For<IDbSet<Viewing>>());
            _handler = new BookViewingCommandHandler(_context);
        }

        [Test]
        public void HandlerShouldAddViewing()
        {
            // Arrange
            var command = new BookViewingCommand();

            // Act
            _handler.Handle(command);

            // Assert
            _context.Viewings.Received(1).Add(Arg.Any<Viewing>());
        }

        [Test]
        public void HandleShouldAddViewingWithCorrectPropertyId()
        {
            // Arrange
            var command = new BookViewingCommand
            {
                PropertyId = 25
            };

            // Act
            _handler.Handle(command);

            // Assert
            _context.Viewings.Received(1).Add(Arg.Is<Viewing>(p => p.PropertyId == 25));
        }

        [Test]
        public void HandleShouldAddViewingWithCorrectAppointment()
        {
            // 
            var command = new BookViewingCommand
            {
                Appointment = DateTime.Today.AddDays(3)
            };

            // Act
            _handler.Handle(command);

            // Assert
            _context.Viewings.Received(1).Add(Arg.Is<Viewing>(p => p.Appointment == DateTime.Today.AddDays(3)));
        }

        [Test]
        public void HandleShouldAddViewingWithCorrectBuyerId()
        {
            // Arrange
            var command = new BookViewingCommand
            {
                BuyerUserId = "BuyerId1"
            };

            // Act
            _handler.Handle(command);

            // Assert
            _context.Viewings.Received(1).Add(Arg.Is<Viewing>(p => p.BuyerUserId == "BuyerId1"));
        }

    }
}
