using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using VACompWebsite.Areas.Identity.Data;

namespace VACompWebsite.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<VACompUser> _signInManager;
        private readonly UserManager<VACompUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<VACompUser> userManager,
            SignInManager<VACompUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public enum DepStatus
        {
            VetOnly,
            VetSpouse,
            VetSpouse1P,
            VetSpouse2P,
            Vet1P,
            Vet2P,
            Vet1C,
            VetSpouse1C,
            VetSpouse1C1P,
            VetSpouse1C2P,
            Vet1C1P,
            Vet1C2P

        }
        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }


            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "First Name")]
            [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
            public string FirstName { get; set; }



            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Last Name")]
            [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
            public string LastName { get; set; }


            [Required]
            [Range(10, 100)]
            [Display(Name = "Combined Disability Rating")]
            //[RegularExpression("[1 - 9][0 - 9] * 0")]
            public int DisabilityRating { get; set; }



            [Required]
            [Display(Name = "Dependency Status")]
            public DepStatus DependencyStatus { get; set; }



            [Required]
            [Display(Name = "Number of Additional Children Under 18")]
            public int AddChildUnder18 { get; set; }



            [Required]
            [Display(Name = "Number of Additional Children 18 and Over with School Status")]
            public int AddChild18Plus { get; set; }


            [Required]
            [Display(Name = "Spouse Receives Aid Support?")]
            public bool AidSupport { get; set; }

        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new VACompUser { UserName = Input.Email, Email = Input.Email, FirstName = Input.FirstName, LastName = Input.LastName, DependencyStatus = (Data.DepStatus)Input.DependencyStatus, DisabilityRating = Input.DisabilityRating,  AddChildUnder18 = Input.AddChildUnder18, AddChild18Plus = Input.AddChild18Plus, AidSupport = Input.AidSupport };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
