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
        //private readonly SignInManager<VAUser> _signInManager;
        private IVeteranRepository _veteranRepository;

        int DisabilityRating;
        DepStatus DependencyStatus;
        int AddChildUnder18;
        int AddChild18Plus;
        bool AidSupport;
        float result; 

        public UserController(IVeteranRepository repository, UserManager<VAUser> userManager)
        {
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


        public IActionResult Calculate()
        {
            //var user = await _userManager.GetUserAsync(User);

           //float result = _veteranRepository.CalculateMonthlyCompensation((int)user.DependencyStatus, user.AddChildUnder18, user.AddChild18Plus, user.DisabilityRating, user.AidSupport);
            result = _veteranRepository.CalculateMonthlyCompensation((int)DependencyStatus,AddChildUnder18, AddChild18Plus, DisabilityRating, AidSupport);
            return View(result);
        }




        //public async Task<IActionResult> CompensationCalcAsync()
        //{
        //    var user = await _userManager.GetUserAsync(User);

        //    var viewModel = new VAUser
        //    {
        //        DisabilityRating = user.DisabilityRating,
        //        DependencyStatus = user.DependencyStatus,
        //        AddChildUnder18 = user.AddChildUnder18,
        //        AddChild18Plus = user.AddChild18Plus,
        //        AidSupport = user.AidSupport
        //    };

        //    return View(viewModel);
        //}

      






        // add logic for whether authenticated or not


        //        public async Task<IActionResult> OnGetAsync()
        //        {
        //            var user = await _userManager.GetUserAsync(User);
        //            if (user == null)
        //            {
        //                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //            }

        //            await LoadAsync(user);
        //            return Page();
        //        }

        //        public async Task<IActionResult> OnPostAsync()
        //        {
        //            var user = await _userManager.GetUserAsync(User);
        //            var firstName = user.FirstName;
        //            var lastName = user.LastName;
        //            var disabilityRating = user.DisabilityRating;
        //            var dependencyStatus = user.DependencyStatus;
        //            var addChildUnder18 = user.AddChildUnder18;
        //            var addChild18Plus = user.AddChild18Plus;
        //            var aidSupport = user.AidSupport;
        //            if (user == null)
        //            {
        //                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //            }

        //            if (!ModelState.IsValid)
        //            {
        //                await LoadAsync(user);
        //                return Page();
        //            }

        //            if (Input.FirstName != user.FirstName)
        //            {
        //                user.FirstName = Input.FirstName;
        //                await _userManager.UpdateAsync(user);
        //            }
        //            if (Input.LastName != user.LastName)
        //            {
        //                user.LastName = Input.LastName;
        //                await _userManager.UpdateAsync(user);
        //            }

        //            if (Input.DisabilityRating != user.DisabilityRating)
        //            {
        //                user.DisabilityRating = Input.DisabilityRating;
        //                await _userManager.UpdateAsync(user);
        //            }

        //            if (Input.DependencyStatus != user.DependencyStatus)
        //            {
        //                user.DependencyStatus = Input.DependencyStatus;
        //                await _userManager.UpdateAsync(user);
        //            }
        //            if (Input.AddChildUnder18 != user.AddChildUnder18)
        //            {
        //                user.AddChildUnder18 = Input.AddChildUnder18;
        //                await _userManager.UpdateAsync(user);
        //            }
        //            if (Input.AddChild18Plus != user.AddChild18Plus)
        //            {
        //                user.AddChild18Plus = Input.AddChild18Plus;
        //                await _userManager.UpdateAsync(user);
        //            }
        //            if (Input.AidSupport != user.AidSupport)
        //            {
        //                user.AidSupport = Input.AidSupport;
        //                await _userManager.UpdateAsync(user);
        //            }



        //            await _signInManager.RefreshSignInAsync(user);
        //            StatusMessage = "Your profile has been updated";
        //            return RedirectToPage();
        //        }
        //    }
        //}


        //[HttpGet]
        //public ViewResult Update(string id)
        //{
        //    VAUser obj = _userManager.GetVeteran(id);
        //    return View(obj);
        //}

        //[HttpGet]
        //public ViewResult Create()
        //{
        //    return View();
        //}
        ////[HttpPost]
        ////public IActionResult Create(VAUser obj)
        ////{

        ////    if (ModelState.IsValid)
        ////    {
        ////        _veteranRepository.AddVeteran(obj);
        ////        return RedirectToAction("AllEmployees");
        ////    }
        ////    return View();

        ////}

        //[HttpPost]
        //public IActionResult Update(VAUser user, string id)
        //{
        //    user.Id = id;
        //    VAUser newUserData = _veteranRepository.UpdateVeteran(user);
        //    return RedirectToAction("Veteran Data");                         // not sure what to return here
        //}


    }
}
