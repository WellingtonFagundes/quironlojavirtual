﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.V2.Models;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartupAttribute(typeof(Quiron.LojaVirtual.Web.V2.Startup))]
namespace Quiron.LojaVirtual.Web.V2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(EfDbContext.Create);
            app.CreatePerOwinContext<QuironUserManager>(QuironUserManager.Create);
            app.CreatePerOwinContext<QuironSignInManager>(QuironSignInManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/cliente/login"),
                CookieName = "clienteLogin",
                ExpireTimeSpan = TimeSpan.FromHours(12)
            });
        }
    }
}