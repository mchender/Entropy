using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.RenderViewToString
{
    public class CacheFileProviderOptions : IConfigureOptions<RazorViewEngineOptions>
    {
        private IFileProvider _fileProvider;

        public CacheFileProviderOptions(ICacheFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public void Configure(RazorViewEngineOptions options)
        {
            options.FileProviders.Clear();
            options.FileProviders.Add(_fileProvider);
        }
    }
}