using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VACompWeb.Areas.Identity.Data;

namespace VACompWeb.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<VAUser> _userManager;
        private readonly SignInManager<VAUser> _signInManager;

        public IndexModel(
            UserManager<VAUser> userManager,
            SignInManager<VAUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
           
      
            [Display(Name = "First Name")]
            public string FirstName { get; set; }



            
            [Display(Name = "Last Name")]        
            public string LastName { get; set; }


            
            [Display(Name = "Combined Disability Rating")]
            //[RegularExpression("[1 - 9][0 - 9] * 0")]
            public int DisabilityRating { get; set; }



     
            [Display(Name = "Dependency Status")]
            public DepStatus DependencyStatus { get; set; }



           
            [Display(Name = "Number of Additional Children Under 18")]
            public int AddChildUnder18 { get; set; }

          
            [Display(Name = "Number of Additional Children 18 and Over with School Status")]
            public int AddChild18Plus { get; set; }


            
            [Display(Name = "Spouse Receives Aid Support?")]
            public bool AidSupport { get; set; }
        }

        private async Task LoadAsync(VAUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var firstName =  user.FirstName;
            var lastName = user.LastName;
            var disabilityRating = user.DisabilityRating;
            var dependencyStatus = user.DependencyStatus;
            var addChildUnder18 = user.AddChildUnder18;
            var addChild18Plus = user.AddChild18Plus;
            var aidSupport = user.AidSupport;
            Username = userName;


            Username = userName;

            Input = new InputModel
            {
                //Username = userName,
                FirstName = firstName,
                LastName = lastName,
                DisabilityRating = disabilityRating,
                AddChildUnder18 = addChildUnder18,
                AddChild18Plus = addChild18Plus,
                AidSupport = aidSupport

                
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var firstName = user.FirstName;
            var lastName = user.LastName;
            var disabilityRating = user.DisabilityRating;
            var dependencyStatus = user.DependencyStatus;
            var addChildUnder18 = user.AddChildUnder18;
            var addChild18Plus = user.AddChild18Plus;
            var aidSupport = user.AidSupport;
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            if (Input.FirstName != user.FirstName)
            {
                user.FirstName = Input.FirstName;
                await _userManager.UpdateAsync(user);
            }
            if (Input.LastName != user.LastName)
            {
                user.LastName = Input.LastName;
                await _userManager.UpdateAsync(user);
            }

            if (Input.DisabilityRating != user.DisabilityRating)
            {
                user.DisabilityRating = Input.DisabilityRating;
                await _userManager.UpdateAsync(user);
            }

            if (Input.DependencyStatus != user.DependencyStatus)
            {
                user.DependencyStatus = Input.DependencyStatus;
                await _userManager.UpdateAsync(user);
            }
            if (Input.AddChildUnder18 != user.AddChildUnder18)
            {
                user.AddChildUnder18 = Input.AddChildUnder18;
                await _userManager.UpdateAsync(user);
            }
            if (Input.AddChild18Plus != user.AddChild18Plus)
            {
                user.AddChild18Plus = Input.AddChild18Plus;
                await _userManager.UpdateAsync(user);
            }
            if (Input.AidSupport != user.AidSupport)
            {
                user.AidSupport = Input.AidSupport;
                await _userManager.UpdateAsync(user);
            }



            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
