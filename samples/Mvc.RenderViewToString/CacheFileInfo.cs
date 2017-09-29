using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using System.Text;

namespace Mvc.RenderViewToString
{
    //inspired by https://github.com/mikebrind/RazorEngineViewOptionsFileProviders/blob/master/RazorEngineViewOptionsFileProviders/src/RazorEngineViewOptionsFileProviders/DatabaseFileInfo.cs
    public class CacheFileInfo : ICacheFileInfo
    {
        private readonly IMemoryCache _cache;
        private string _viewPath;
        private byte[] _viewContent;
        private DateTimeOffset _lastModified;
        private bool _exists;

        public CacheFileInfo(IMemoryCache cache)
        {
            _cache = cache;
        }

        public bool Exists => _exists;

        public bool IsDirectory => false;

        public DateTimeOffset LastModified => _lastModified;

        public long Length
        {
            get
            {
                using (var stream = new MemoryStream(_viewContent))
                {
                    return stream.Length;
                }
            }
        }

        public string Name => Path.GetFileName(_viewPath);

        public string PhysicalPath => null;

        public Stream CreateReadStream()
        {
            return new MemoryStream(_viewContent);
        }

        public void GetView(string viewPath)
        {
            _viewPath = viewPath;
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(_viewPath);
            if (fileNameWithoutExtension == "_ViewImports")
            {
                _exists = false;
                _viewContent = null;
            }
            else
            {
                _lastModified = DateTime.UtcNow;
                _exists = true;
                var template = _cache.Get(fileNameWithoutExtension);
                _viewContent = Encoding.UTF8.GetBytes(template.ToString());
            }
        }
    }
}