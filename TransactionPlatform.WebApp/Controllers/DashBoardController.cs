using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransactionPlatform.DomainLibrary.Models;
using TransactionPlatform.WebApp.Data;
using TransactionPlatform.WebApp.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices.ComTypes;

namespace TransactionPlatform.WebApp.Controllers
{
    [Authorize]
    public class DashBoardController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AppDbContext Context { get; }
        public DashBoardController(UserManager<ApplicationUser> userManager, AppDbContext ctx)
        {
            this.userManager = userManager;
            Context = ctx;
        }
        public async Task<IActionResult> Index()
        {
            var model = new DashboardDto();
            
            var apiCaller = new ApiCaller();
         
            

                var userName = User.Identity.Name;
                var user = await userManager.FindByNameAsync(userName);
                var walletTsk = apiCaller.GetWalletFromAPI(user.Id );
                var instrumentsTsk = apiCaller.GetInstrumentsFromAPI();

                model.Instruments = await instrumentsTsk;
                model.UserWallet = await walletTsk;

            return View(model);

        }
    }
}