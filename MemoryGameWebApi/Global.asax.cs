using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Routing;

namespace MemoryGameWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var config = GlobalConfiguration.Configuration;
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
     //       config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
     //= Newtonsoft.Json.ReferenceLoopHandling.Serialize;
     //       config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling
     //            = Newtonsoft.Json.PreserveReferencesHandling.Objects;
        }
    }
}
