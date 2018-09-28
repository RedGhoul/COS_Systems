using MultipartDataMediaFormatter;
using MultipartDataMediaFormatter.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace HHAM
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            GlobalConfiguration.Configuration.Formatters.Add(new FormMultipartEncodedMediaTypeFormatter(new MultipartFormatterSettings()));

            // Web API configuration and services
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;
            settings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            // Web API routes
            config.MapHttpAttributeRoutes();
        }
    }
}
