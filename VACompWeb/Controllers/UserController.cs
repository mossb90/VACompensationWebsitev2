using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VACompWeb.Areas.Identity.Data;
using VACompWeb.Areas.Identity.Pages.Account.Manage;
using VACompWeb.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace VACompWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<VAUser> _userManager;
        private IVeteranRepository _veteranRepository;


        public UserController(IVeteranRepository repository, UserManager<VAUser> userManager)
        {
            ;
            _userManager = userManager;
            _veteranRepository = repository;

        }




        [Authorize]
        public async Task<IActionResult> CompensationCalcAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            var viewModel = new VAUser
            {
                DisabilityRating = user.DisabilityRating,
                DependencyStatus = user.DependencyStatus,
                AddChildUnder18 = user.AddChildUnder18,
                AddChild18Plus = user.AddChild18Plus,
                AidSupport = user.AidSupport
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Calculate(VAUser user)
        {
            //var user = await _userManager.GetUserAsync(User);

            user.MonthlyComp = _veteranRepository.CalculateMonthlyCompensation((int)user.DependencyStatus, user.AddChildUnder18, user.AddChild18Plus, user.DisabilityRating, user.AidSupport);
            //result = _veteranRepository.CalculateMonthlyCompensation((int)DependencyStatus,AddChildUnder18, AddChild18Plus, DisabilityRating, AidSupport);
            return View("CompensationCalc", user);

        }

    }
}
