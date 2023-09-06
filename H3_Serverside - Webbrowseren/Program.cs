using H3_Serverside___Webbrowseren.Data_Access;
using H3_Serverside___Webbrowseren.GUI.Controllers;
using H3_Serverside___Webbrowseren.GUI.Utilities;
using H3_Serverside___Webbrowseren.Manager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IWebpageClient, WebPageClient>();
        services.AddSingleton<WebsiteManager>();
        services.AddSingleton<HomeController>();
        //services.AddSingleton<ViewRenderer>();
    })
    .Build();


var homeController = host.Services.GetService<HomeController>();
await homeController.Index();