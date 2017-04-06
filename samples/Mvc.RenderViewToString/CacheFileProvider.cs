using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using System;

namespace Mvc.RenderViewToString
{
    //inspired by https://github.com/mikebrind/RazorEngineViewOptionsFileProviders/blob/master/RazorEngineViewOptionsFileProviders/src/RazorEngineViewOptionsFileProviders/DatabaseFileProvider.cs
    public class CacheFileProvider : IFileProvider
    {
        public CacheFileProvider()
        {
        }
        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            throw new NotImplementedException();
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            var result = new CacheFileInfo(subpath);
            return result.Exists ? result as IFileInfo : new NotFoundFileInfo(subpath);
        }

        public IChangeToken Watch(string filter)
        {
            return new CacheChangeToken(filter);
        }
    }
}
