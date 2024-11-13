using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cours.Services;
using gestionDetteWeb2.Models;

namespace GestionDette.Controllers;

public class ClientController : Controller
{
    private readonly ILogger<ClientController> _logger;
    private readonly IClientService _clientService;

    /* 
        ViewBag => Recupérer le même type
        ViewData => Dictionnaire durant une requête C => V | V => C
        TempData => Dictionnaire durant des requêtes successives
     */

    public ClientController(ILogger<ClientController> logger, IClientService clientService)
    {
        _logger = logger;
        _clientService = clientService;
    }
    // Home/Index | Routes
    public async Task<IActionResult> Index()
    {
        // Fetch clients from the service
        var clients = await _clientService.GetClientsAsync();
        // Pass the clients to the view
        return View(clients);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}