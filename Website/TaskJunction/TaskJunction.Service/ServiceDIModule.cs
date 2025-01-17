using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskJunction.Service.Common;

namespace TaskJunction.Service
{
    public class ServiceDIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DepartmentService>()
                .As<IDepartmentService>()
                .InstancePerDependency();
            builder.RegisterType<WorkerService>()
                .As<IWorkerService>()
                .InstancePerDependency();
            builder.RegisterType<WorkerService>()
                .As<IWorkerService>()
                .InstancePerDependency();
        }
    }
}
