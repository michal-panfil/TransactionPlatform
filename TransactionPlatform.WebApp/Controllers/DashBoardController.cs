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
using Microsoft.Extensions.Logging;

namespace TransactionPlatform.WebApp.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<AccountController> logger;

        public AppDbContext Context { get; }
        public DashboardController(UserManager<ApplicationUser> userManager, AppDbContext ctx, ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            Context = ctx;
            this.logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var model = new DashboardDto();
            
            var apiCaller = new ApiCaller();
         
            var userName = User.Identity.Name;
            var user = await userManager.FindByNameAsync(userName);
            try
            {
                var walletTsk = apiCaller.GetWalletFromAPI(user.Id);
                var instrumentsTsk = apiCaller.GetInstrumentsFromAPI();
                model.Instruments = await instrumentsTsk;
                model.UserWallet = await walletTsk;
            }
            catch (Exception)
            {
                var errorMessage = $"Can't reach api services {DateTime.Now}";
                logger.LogError(errorMessage);
                ViewBag.ConnectionError = "Sorry we could not reach importent services. Please wait a moment and try again or reach helpdesk";
            }
           
            return View(model);
        }
    }
}