using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: WebActivator.PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]

namespace eGaragem.UI.Mvc.App_Start
{
    public class SimpleInjectorInitializer
    {
    }
}