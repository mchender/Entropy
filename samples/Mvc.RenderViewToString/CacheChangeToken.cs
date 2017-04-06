using Microsoft.Extensions.Primitives;
using System;

namespace Mvc.RenderViewToString
{
    //inspired by https://github.com/mikebrind/RazorEngineViewOptionsFileProviders/blob/master/RazorEngineViewOptionsFileProviders/src/RazorEngineViewOptionsFileProviders/DatabaseChangeToken.cs
    public class CacheChangeToken : IChangeToken
    {
        private string _viewPath;

        public CacheChangeToken(string viewPath)
        {
            _viewPath = viewPath;
        }

        public bool ActiveChangeCallbacks => false;

        public bool HasChanged
        {
            get
            {
                return false;
            }
        }

        public IDisposable RegisterChangeCallback(Action<object> callback, object state) => EmptyDisposable.Instance;
    }

    internal class EmptyDisposable : IDisposable
    {
        public static EmptyDisposable Instance { get; } = new EmptyDisposable();
        private EmptyDisposable() { }
        public void Dispose() { }
    }
}