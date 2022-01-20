using G7.Models;
using System;
using System.IO;
using System.Web.Mvc;

namespace G7.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Branderson Lima";

            return View();
        }

        public ActionResult Contact(string nome, string email, string msg, string tel)
        {
            FormData formData = new FormData
            {
                Name = nome,
                Email = email,
                Tel = tel,
                Text = msg
            };

            string path = @"c:\temp\G7Form.txt";
            if (!System.IO.File.Exists(path))
            {
                using (StreamWriter sw = System.IO.File.CreateText(path))
                {
                    sw.WriteLine("Nome: " + nome);
                    sw.WriteLine("Email: " + email);
                    sw.WriteLine("Telefone: " + tel);
                    sw.WriteLine("Mensagem: " + msg);
                }
            }
            else
            {
                string text = "Nome: " + nome + Environment.NewLine +
                              "Email: " + email + Environment.NewLine +
                              "Telefone: " + tel + Environment.NewLine +
                              "Mensagem: " + msg;
                System.IO.File.WriteAllText(path, text);
            }
            return View();
        }
    }
}