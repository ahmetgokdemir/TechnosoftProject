﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.ENTITIES.Models;
using Mapster;
using Semerkand_Dergilik.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security;
using Semerkand_Dergilik.Enums;

namespace Semerkand_Dergilik.Controllers
{
    [Authorize]
    public class MemberController : BaseController
    {
        // kod tekrarı önlendi..
        //public UserManager<AppUser> userManager { get; }
        //public SignInManager<AppUser> signInManager { get; }


        public MemberController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(userManager, signInManager)
        {
            // kod tekrarı önlendi..
            //this.userManager = userManager;
            //this.signInManager = signInManager;
        }

        public IActionResult Index()
        {

            // HttpContext.User.Identity.Name, veritabanındaki UserName karşılığıdır.. ama Identity.Name cookie den geliyor..
            AppUser user = userManager.FindByNameAsync(HttpContext.User.Identity.Name).Result;
            // kod tekrarı önlenemedi..
            //AppUser user = base.CurrentUser;
            //AppUser user = CurrentUser;

            if (user == null)
            {
                return RedirectToAction("LogIn", "Home");
            }

            // fazla property'si olan class'lar için kısayol automap.. (User class'ın daki bilgileri UserViewModel'e basar)
            // mapster kütüphanesi indirilsin (dependencies --> manage nuget)

            UserViewModel userViewModel = user.Adapt<UserViewModel>(); // automap

            return View(userViewModel);
        }

        // PasswordChange actiom metot ->MemberLayouttan geliyor
        public IActionResult PasswordChange()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PasswordChange(PasswordChangeViewModel passwordChangeViewModel)
        {
            if (ModelState.IsValid)
            {
                // kod tekrarı önlenemedi..
                //AppUser user = CurrentUser;
                AppUser user = userManager.FindByNameAsync(HttpContext.User.Identity.Name).Result;

                // UserViewModel userViewModel = user.Adapt<UserViewModel>(); // password null geliyor userviewmodelde o yüzden remove ediyoruz model state'te


                // şifre kontrolü
                bool exist = userManager.CheckPasswordAsync(user, passwordChangeViewModel.PasswordOld).Result;

                if (exist) // şifre kontrolü başarılı
                {
                    // change işlemi eski şifreyi iptal eder.. validation
                    IdentityResult result = userManager.ChangePasswordAsync(user, passwordChangeViewModel.PasswordOld, passwordChangeViewModel.PasswordNew).Result;

                    if (result.Succeeded)
                    {
                        await userManager.UpdateSecurityStampAsync(user); // yeni securitystamp

                        /*             
                        Identity API 30 dk da bir cookie bilgisi ile veritabanındaki securitystamp bilgisini
                        kontrol ediyor.. eğer eşleşmezler iseler logout olur sistem.. ki eşleşmiyecekler zira
                        UpdateSecurityStampAsync edildi..

                        SecurityStamp: veritabanındaki bir alan.. yeni bir SecurityStamp oluşturulacak (user ile
                        ilgili bir bilgi değiştirildiği zaman yapılması gerekir)
                        nedeni: cookie içerisinde eski stamp bilgisi var ve user şifresini değiştirince artık yeni
                        şifre ile login olmalı bu yüzden çıkış yapılmalı ki yeni cookie(stamp) oluşturulsun

                        backend tarafında kod ile user çıkış ve giriş yaptırılmaz ise veritabanında yeni
                        securitystamp olmasına rağmen cookie içerisinde hala eski securitystamp bulunacak ve 30 dk
                        boyunca user sayfalarda dolaşabilir..
                        */

                        await signInManager.SignOutAsync(); // çıkış yapıldı .. cookie bilgisi silinir..


                        // user otomatik olarak yeni şifre ile login oldu.. PasswordSignInAsync metodu HomeController da LogIn action da kullanıldı 
                        await signInManager.PasswordSignInAsync(user, passwordChangeViewModel.PasswordNew, true, false);

                        /*
                          artık yeni cookie oluşturuldu artık sistem logout olmaz.. 
                         */

                        //AppUser user2 = userManager.FindByNameAsync(HttpContext.User.Identity.Name).Result;

                        ViewBag.success = "true";
                    }
                    else
                    {
                        // kod tekrarı önlendi..
                        /*foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }*/
                        AddModelError(result);

                    }
                }
                else // şifre kontrolü başarısız
                {
                    ModelState.AddModelError("", "Eski şifreniz yanlış");
                }
            }

            return View(passwordChangeViewModel); // şifre değişilince gene PasswordChange sayfasında kalır
        }

        // Üye bilgilerini güncelleme 
        public IActionResult UserEdit()
        {
            // kod tekrarı önlendi..
            AppUser user = userManager.FindByNameAsync(HttpContext.User.Identity.Name).Result;
            //AppUser user = CurrentUser;

            if (user == null)
            {
                return RedirectToAction("LogIn", "Home");
            }

            UserViewModel userViewModel = user.Adapt<UserViewModel>(); // automap

            ViewBag.Gender = new SelectList(Enum.GetNames(typeof(Gender)));
            // GetNames: gender enum'ın isimlerini alır

            return View(userViewModel); // güncellenecek bilgiler view'e gönderildi..
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(UserViewModel userViewModel, IFormFile userPicture)
        {
            ModelState.Remove("Password");
            //[Bind(Include = "UserName,Em..")] attribute'da Password null gelir ve ModelState.IsValid kısmında hata verir..

            ViewBag.Gender = new SelectList(Enum.GetNames(typeof(Gender))); // post işlemden sonra viewbag sıfırlandığı için tekrar yüklenmeli.. 

            //if (userPicture==null || userViewModel.Picture == null)
            //{
                ModelState.Remove("Picture");
                ModelState.Remove("userPicture");
                //ModelState.Remove("Gender");
                //ModelState.Remove("BirthDay");
                //ModelState.Remove("City");

            //}


            if (ModelState.IsValid)
            {
                // kod tekrarı önlendi..
                AppUser user = userManager.FindByNameAsync(HttpContext.User.Identity.Name).Result;
                //AppUser user = CurrentUser;

                /*
                string phone = userManager.GetPhoneNumberAsync(user).Result;

                if (phone != userViewModel.PhoneNumber)
                {
                    if (userManager.Users.Any(u => u.PhoneNumber == userViewModel.PhoneNumber))
                    {
                        ModelState.AddModelError("", "Bu telefon numarası başka üye tarafından kullanılmaktadır.");
                        return View(userViewModel);
                    }
                }

                */

                
                if (userPicture != null && userPicture.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(userPicture.FileName); // path oluşturma

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserPicture", fileName); // server'a kayıt edilecek path => wwwroot/UserPicture/fileName

                    // kayıt işlemi
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await userPicture.CopyToAsync(stream); // userPicture'ı, stream'e kayıt

                        user.Picture = "/UserPicture/" + fileName;   // veritabanına kayıt (wwwroot belirtmeye gerek yok)
                        
                    }
                }
                

                // güncelleme işlemi
                user.UserName = userViewModel.UserName;
                user.Email = userViewModel.Email;
                user.PhoneNumber = userViewModel.PhoneNumber;
                user.City = userViewModel.City;                
                user.BirthDay = userViewModel.BirthDay;                
                user.Gender = (int)userViewModel.Gender;

                userViewModel.Picture = user.Picture;

                //  IdentityResult sayesinde backend validation'ları (Program.cs ve CustomValidation kısımlarında) çalışır
                IdentityResult result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    await userManager.UpdateSecurityStampAsync(user); // kritik bilgi değişti için veritabanında securitystamp güncellendi.. ama cookie bilgisi eski..


                    await signInManager.SignOutAsync();
                    await signInManager.SignInAsync(user, true); // password ile giriş yapılmayacak
                                                                 //artık cookie yenilendi.. 30 dk sonra sistemden atılmayacak user





                    // AppUser user2 = userManager.FindByNameAsync(HttpContext.User.Identity.Name).Result;

                    ViewBag.success = "true";
                }
                else
                {
                    // kod tekrarı önlendi..
                    /*
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }*/

                    AddModelError(result);

                }
            }

            return View(userViewModel); // aynı sayfaya bilgiler dolu gider.. ViewBag.success = "true"; ise o kısım gelmez
        }

        /*
        // Logout
        public ActionResult LogOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
        */
        public void LogOut()
        {
            signInManager.SignOutAsync(); // opts.LogoutPath = new PathString("/Member/LogOut"); çalışır

        }


        // // // erişim yetkisi olmayan kullanıcıyı sayfadan Access Denied etme 
        public IActionResult AccessDenied(string ReturnUrl)
        {
            if (ReturnUrl.ToLower().Contains("violencegage"))
            {
                ViewBag.message = "Erişmeye çalıştığınız sayfa şiddet videoları içerdiğinden dolayı 15 yaşında büyük olmanız gerekmektedir";
            }
            else if (ReturnUrl.ToLower().Contains("ankarapage"))
            {
                ViewBag.message = "Bu sayfaya sadece şehir alanı ankara olan kullanıcılar erişebilir";
            }
            else if (ReturnUrl.ToLower().Contains("exchange"))
            {
                ViewBag.message = "30 günlük ücretsiz deneme hakkınız sona ermiştir.";
            }
            else
            {
                ViewBag.message = "Bu sayfaya erişim izniniz yoktur. Erişim izni almak için site yöneticisiyle görüşünüz";
            }

            return View();
        }


        // // // rollerin ulaşabileceği sayfalar, case sensitive  
        [Authorize(Roles = "Manager,Admin")]
        public IActionResult Manager()
        {
            return View();
        }


        // // // rollerin ulaşabileceği sayfalar, case sensitive  
        [Authorize(Roles = "Editor,Admin")]
        public IActionResult Editor()
        {
            return View();
        }

        // customize claim , yetki yoksa Access Denied olur..
        [Authorize(Policy = "IstanbulPolicy")]
        [Route("IstanbulPage")]
        public IActionResult IstanbulPage()
        {
            return View();
        }
    }
}
