using System;

namespace Mvc.RenderViewToString
{
    //inspired by https://github.com/aspnet/DependencyInjection/issues/294#issuecomment-142206501
    public class ServiceProviderProvider
    {
        public static IServiceProvider ServiceProvider { get; set; }
    }
}
