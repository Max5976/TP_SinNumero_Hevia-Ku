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
    public IActionResult Perfil(string email, string contrasenia) 
    {
        Integrante integrante = BD.encontrarUsuario(email, contrasenia);
        if (integrante == null) 
        {
            return View("Index");
        } 
        else
        {
            return View();
        }
    }
}
