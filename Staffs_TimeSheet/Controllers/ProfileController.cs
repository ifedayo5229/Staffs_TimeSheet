using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Staffs_TimeSheet.Data.Entities;
using Staffs_TimeSheet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Staffs_TimeSheet.Controllers
{
    [Authorize, Route("[controller]")]
    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITimeTracker _timeTracker;

        public ProfileController(ILogger<ProfileController> logger, UserManager<ApplicationUser> userManager, ITimeTracker timeTracker)
        {
            _logger = logger;
            _userManager = userManager;
            _timeTracker = timeTracker;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var result = await _timeTracker.GetDetails(userId);
            if(result == null){return RedirectToAction("logout", "Home");}
            return View(result);
        }

       [HttpGet("/clockin")]
        public async Task<IActionResult> ClockIn()
        {
            var userId = _userManager.GetUserId(User);
            var result = await _timeTracker.CheckIn(userId);
            if(result == null){return RedirectToAction("logout", "Home");}
            return LocalRedirect("/Profile");
        }

       [HttpGet("/clockout")]
        public async Task<IActionResult> ClockOut()
        {
            var userId = _userManager.GetUserId(User);
            var result = await _timeTracker.CheckOut(userId);                
            
            //If user is not found
            if(result == null){return RedirectToAction("logout", "Home");}
            return LocalRedirect("/Profile");

        }



    }
}