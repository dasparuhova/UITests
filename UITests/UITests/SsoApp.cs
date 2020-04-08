using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Pages;

namespace UITests
{
    public static class SsoApp
    {
        public static LoginPage LoginPage { get; } = new LoginPage();
        public static HomePage HomePage { get; } = new HomePage();

    }
}
