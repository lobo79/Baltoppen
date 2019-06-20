using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Baltoppen.Models;

namespace Baltoppen.Controllers
{
    public class AdminController : Controller
    {
        private BaltoppenEntities1 db = new BaltoppenEntities1();
        // GET: Admin
        public ActionResult Admin_Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Admin_Login(Login login)
        {
            var result1 = (from admin in db.Users where admin.Email == login.Username select admin.Password).FirstOrDefault();

            string DPassword = Decrypt(result1);

             //db.Users.Where(m=>m.Email==login.Username && m.Password==login.Password).FirstOrDefault()

            if (DPassword == login.Password)

            {

                return RedirectToAction("Admin", "Home", new { area = "Admin" });

            }

            else

            {

                ViewBag.Message = string.Format("UserName and Password is incorrect");

                return View();

            }
        }

        [NonAction]

        public string Decrypt(string cipherText)

        {

            if (cipherText != null)

            {

                string EncryptionKey = "MAKV2SPBNI99212";

                byte[] cipherBytes = Convert.FromBase64String(cipherText);

                using (Aes encryptor = Aes.Create())

                {

                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

                    encryptor.Key = pdb.GetBytes(32);

                    encryptor.IV = pdb.GetBytes(16);

                    using (MemoryStream ms = new MemoryStream())

                    {

                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))

                        {

                            cs.Write(cipherBytes, 0, cipherBytes.Length);

                            cs.Close();

                        }

                        cipherText = Encoding.Unicode.GetString(ms.ToArray());

                    }

                }

                return cipherText;

            }

            return null;

        }


    }
}