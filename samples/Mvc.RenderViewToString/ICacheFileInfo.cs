using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.RenderViewToString
{
    public interface ICacheFileInfo : IFileInfo
    {
        void GetView(string viewPath);
    }
}
