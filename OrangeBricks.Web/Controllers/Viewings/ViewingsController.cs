using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Controllers.Viewings.Builders;
using OrangeBricks.Web.Controllers.Viewings.Commands;
using OrangeBricks.Web.Controllers.Viewings.ViewModels;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Viewings
{
    [OrangeBricksAuthorize(Roles = "Buyer")]
    public class ViewingsController : Controller
    {
        private readonly IOrangeBricksContext _context;

        public ViewingsController(IOrangeBricksContext context)
        {
            _context = context;
        }

        public ActionResult Book(int propertyId)
        {
            var builder = new BookViewingViewModelBuilder(_context);
            var viewModel = builder.Build(propertyId);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Book(BookViewingViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return Book(viewModel.PropertyId);
            }

            var command = new BookViewingCommand
            {
                Appointment = viewModel.Appointment,
                PropertyId = viewModel.PropertyId,
                BuyerUserId = User.Identity.GetUserId()
            };

            var handler = new BookViewingCommandHandler(_context);
            handler.Handle(command);

            return RedirectToAction("Index", "Property");
        }
    }
}