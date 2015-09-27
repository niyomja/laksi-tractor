using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace appTractor.Controller
{
    interface IControllerBase
    {
         void run(IControllerBase ctl);
    }
}
