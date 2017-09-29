using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using System;

namespace Mvc.RenderViewToString
{
    //inspired by https://github.com/mikebrind/RazorEngineViewOptionsFileProviders/blob/master/RazorEngineViewOptionsFileProviders/src/RazorEngineViewOptionsFileProviders/DatabaseFileProvider.cs
    public class CacheFileProvider : ICacheFileProvider
    {
        private readonly ICacheFileInfo _fileInfo;
        public CacheFileProvider(ICacheFileInfo fileInfo)
        {
            _fileInfo = fileInfo;
        }
        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            throw new NotImplementedException();
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            _fileInfo.GetView(subpath);
            return _fileInfo.Exists ? _fileInfo as IFileInfo : new NotFoundFileInfo(subpath);
        }

        public IChangeToken Watch(string filter)
        {
            return new CacheChangeToken(filter);
        }
    }
}
