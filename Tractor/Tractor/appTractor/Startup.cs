using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using appTractor.Controller;

namespace appTractor
{
    class Startup
    {
        public static ApplicationContext Run()
        {
            ApplicationContext context;
            context = new ApplicationContext();

            LoginController login = new LoginController();
            login.run(null);

            return context;
        }
    }
}
