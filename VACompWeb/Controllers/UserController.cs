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
using System.Threading;


namespace VACompWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<VAUser> _userManager;
        private readonly SignInManager<VAUser> _signInManager;
        private IVeteranRepository _veteranRepository;

        

        public UserController(IVeteranRepository repository, UserManager<VAUser> userManager, SignInManager<VAUser> signInManager)
        {
            
            _userManager = userManager;
            _veteranRepository = repository;
            _signInManager = signInManager;

        }

     



        public async Task<IActionResult> CompensationCalcAsync(VAUser user)
        {
            if (User.Identity.IsAuthenticated)
            {
                var CurrentUser = await _userManager.GetUserAsync(User);

                var viewModel = new VAUser
                {
                    DisabilityRating = CurrentUser.DisabilityRating,
                    DependencyStatus = CurrentUser.DependencyStatus,
                    AddChildUnder18 = CurrentUser.AddChildUnder18,
                    AddChild18Plus = CurrentUser.AddChild18Plus,
                    AidSupport = CurrentUser.AidSupport

                };

                return View(viewModel);
            }
            else
            {
                var viewModel = new VAUser
                {
                    DisabilityRating = user.DisabilityRating,
                    DependencyStatus = user.DependencyStatus,
                    AddChildUnder18 = user.AddChildUnder18,
                    AddChild18Plus = user.AddChild18Plus,
                    AidSupport = user.AidSupport
                };
                return View();
            }
        }

        [HttpPost]
        public IActionResult Calculate(VAUser user)
        {
            

            user.MonthlyComp = _veteranRepository.CalculateMonthlyCompensation((int)user.DependencyStatus, user.AddChildUnder18, user.AddChild18Plus, user.DisabilityRating, user.AidSupport);
           
            return View("CompensationCalc", user);

        }

       
        public async Task<IActionResult> UpdateProfileAsync(VAUser formUser)
        {
            var user = await _userManager.GetUserAsync(User);
            

            if (formUser.DisabilityRating != user.DisabilityRating)
            {
                user.DisabilityRating = formUser.DisabilityRating;
                await _userManager.UpdateAsync(user);
            }

            if (formUser.DependencyStatus != user.DependencyStatus)
            {
                user.DependencyStatus = formUser.DependencyStatus;
                await _userManager.UpdateAsync(user);
            }
            if (formUser.AddChildUnder18 != user.AddChildUnder18)
            {
                user.AddChildUnder18 = formUser.AddChildUnder18;
                await _userManager.UpdateAsync(user);
            }
            if (formUser.AddChild18Plus != user.AddChild18Plus)
            {
                user.AddChild18Plus = formUser.AddChild18Plus;
                await _userManager.UpdateAsync(user);
            }
            if (formUser.AidSupport != user.AidSupport)
            {
                user.AidSupport = formUser.AidSupport;
                await _userManager.UpdateAsync(user);
            }


         
            await _signInManager.RefreshSignInAsync(user);
            
            return View("CompensationCalc", user);
        }

    }
}
