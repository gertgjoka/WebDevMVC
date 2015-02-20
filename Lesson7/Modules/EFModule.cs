using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Autofac;
using Lesson7.Model;

namespace Lesson7.Modules
{
    

    public class EFModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
         
            builder.RegisterType(typeof(Lesson7Entities)).As(typeof(IContext)).InstancePerRequest();                 

        }

    }
}