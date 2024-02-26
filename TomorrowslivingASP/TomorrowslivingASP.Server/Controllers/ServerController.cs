using Microsoft.AspNetCore.Mvc;
using TomorrowsLiving;
public class ServerController : Controller
{
    private readonly ServerManager _serverManager;
    private const string DirectoryPathServers = @"c:\TomorrowsLiving\Servers";

    public ServerController()
    {
        _serverManager = new ServerManager(DirectoryPathServers);
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateServer()
    {
        _serverManager.CreateServer();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult EditServer()
    {
        _serverManager.EditServer();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DeleteServer(string serverName)
    {
        var serverPath = System.IO.Path.Combine(DirectoryPathServers, serverName);
        _serverManager.DeleteServer(serverPath);
        return RedirectToAction("Index");
    }
}
