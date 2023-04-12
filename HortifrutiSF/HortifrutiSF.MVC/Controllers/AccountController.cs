using HortifrutiSF.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HortifrutiSF.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;


        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)

        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        // GET: LoginController
        public IActionResult Login()
        {
            return View();

        }


        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel loginVM)////
        {
            if (!ModelState.IsValid) //se não for valido
                return View(loginVM); //retorna a pagina de login

            //Se for Valido
            var user = await _signInManager.PasswordSignInAsync(loginVM.Usuario, loginVM.Senha, false, false);
            if (user.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Falha ao realizar o login !!");
                return View();
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(LoginViewModel resgistroVM)///////
        {
            //Verfica se o ModelState é valido
            if (ModelState.IsValid)
            {
                //se for valido
                var user = new IdentityUser
                {
                    UserName = resgistroVM.Usuario,
                    Email = resgistroVM.Usuario
                };
                var result = await _userManager.CreateAsync(user, resgistroVM.Senha);

                //se o resultado foi feito com sucesso
                if (result.Succeeded)
                {
                    //Para adicionar uma permissão
                    // await AdicionarPermissao(resgistroVM, user);

                    // await signManager.SignInAsync(user, isPersistent: false);
                    //await userManager.AddToRoleAsync(user, "Member");
                    return RedirectToAction("Login", "Account");
                }
                // Se não deu certo
                else
                {
                    this.ModelState.AddModelError("Registro", "Falha ao registrar o usário");
                }
            }

            return View(resgistroVM);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.User = null;
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}
