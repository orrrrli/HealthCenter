﻿using Data.Contracts;
using Data.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.WebApi;
using Business.Contracts;
using Business.Implementation;
using System.Web.Http.Cors;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //SimpleInjectorInitializer.Initialize();
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            var container = new SimpleInjector.Container();
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            //User Controller
            container.Register<IUserService, UserService>();
            container.Register<IUserRepository, UserRepository>();

            //MedicalRecord Controller
            container.Register<IMedicalRecordService, MedicalRecordService>();
            container.Register<IMedicalRecordRepository, MedicalRecordRepository>();

            //Role Controller
            container.Register<IRoleService, RoleService>();
            container.Register<IRoleRepository, RoleRepository>();
            

            //Sheet Controller
            container.Register<ISheetService, SheetService>();
            container.Register<ISheetRepository, SheetRepository>();

            container.Verify();
            //config.DependencyResolver = new SimpleInjectorWebApiDependecyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver =
        new SimpleInjectorWebApiDependencyResolver(container);


        }
    }
}
