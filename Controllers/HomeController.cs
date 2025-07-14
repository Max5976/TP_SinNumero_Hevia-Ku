using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP_SinNumero_Hevia_Ku.Models;

namespace TP_SinNumero_Hevia_Ku.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

public IActionResult Index()
    {
        return View();
    }
    public IActionResult LogIn()
    {
        return View();
    }

    [HttpPost]
    public IActionResult LogIn(string email, string contrasenia)
    {
        Integrante integrante = BD.encontrarUsuario(email, contrasenia);
        if (integrante == null)
        {
            ViewBag.Error = "Usuario o contraseña incorrectos";
            return View();
        }
        else
        {
            HttpContext.Session.SetString("usuarioEmail", integrante.email);
            return RedirectToAction("Perfil");
        }
    }

    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RegistrarUsuario(Integrante nuevo)
    {
        if (BD.encontrarUsuarioPorEmail(nuevo.email) != null)
        {
            ViewBag.Error = "Ya existe una cuenta con ese correo electrónico. Por favor, intenta con otro.";
            return View("SignUp");
        }
        BD.AgregarUsuario(nuevo);
        HttpContext.Session.SetString("usuarioEmail", nuevo.email);
        return RedirectToAction("Perfil");
    }

    public IActionResult Perfil()
    {
        string email = HttpContext.Session.GetString("usuarioEmail");
        if (string.IsNullOrEmpty(email))
        {
            return RedirectToAction("LogIn");
        }
        Integrante integrante = BD.encontrarUsuarioPorEmail(email);
        ViewBag.Integrante = integrante;
        return View();
    }

    public IActionResult CerrarSesion()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("LogIn");
    }
    
}