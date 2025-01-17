using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskJunction.Repository.Common;

namespace TaskJunction.Repository
{
    public class RepositoryDIModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DepartmentRepository>()
                .As<IDepartmentRepository>()
                .InstancePerDependency();
            builder.RegisterType<WorkerRepository>()
                .As<IWorkerRepository>()
                .InstancePerDependency();
            builder.RegisterType<TaskRepository>()
                .As<ITaskRepository>()
                .InstancePerDependency();
        }
    }
}
