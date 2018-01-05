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
        [HttpPost]
        public async Task<IActionResult> Bid(string itemNumber, string bidCustomName, string bidCustomPhone, string bidPrice) {
            var service = new AuctionService.AuctionsServiceClient();

            await service.ProvideBidAsync(int.Parse(itemNumber), int.Parse(bidPrice), bidCustomName, bidCustomPhone);

            var chosenItem = await service.GetAuctionItemAsync(int.Parse(itemNumber));
            return View("About", chosenItem);
        }

        public IActionResult About() {
            return Redirect("Index");
        }

        [HttpPost]
        public async Task<IActionResult> About(string itemNumber) {
            var service = new AuctionService.AuctionsServiceClient();

            var chosenItem = await service.GetAuctionItemAsync(int.Parse(itemNumber));

            return View(chosenItem);
        }

        public async Task<ActionResult> History() {
            var service = new AuctionService.AuctionsServiceClient();
            List<AuctionService.AuctionItem> Auctions = await service.GetAllAuctionItemsAsync();
            return View(Auctions);
        }

        public async Task<ActionResult> Create(string itemNumber, string idemDescription, string ratingPrice) {
            var service = new AuctionService.AuctionsServiceClient();
            await service.CreateAuctionItemAsync(int.Parse(itemNumber), idemDescription, int.Parse(ratingPrice));
            return Redirect("Index");
        }

        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
