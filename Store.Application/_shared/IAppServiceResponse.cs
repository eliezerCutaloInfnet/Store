using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application._shared
{
    public interface IAppServiceResponse
    {
        string Message { get; set; }
        bool Success { get; set; }
    }
}
