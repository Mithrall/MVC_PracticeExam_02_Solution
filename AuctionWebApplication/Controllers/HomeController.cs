using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AuctionWebApplication.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AuctionWebApplication.Controllers {
    public class HomeController : Controller {
        public async Task<ActionResult> Index() {
            var service = new AuctionService.AuctionsServiceClient();
            List<AuctionService.AuctionItem> Auctions = await service.GetAllAuctionItemsAsync();
            return View(Auctions);
        }

        public IActionResult About() {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact() {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
