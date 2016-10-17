using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Controllers.Offers.Builders;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Offers
{
    [OrangeBricksAuthorize(Roles = "Buyer")]
    public class MyOffersController : Controller
    {
        private readonly IOrangeBricksContext _context;

        public MyOffersController(IOrangeBricksContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var builder = new MyOffersViewModelBuilder(_context);
            var viewModel = builder.Build(User.Identity.GetUserId());

            return View(viewModel);
        }
    }
}