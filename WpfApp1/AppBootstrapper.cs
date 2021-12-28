using Caliburn.Micro;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows;
using WpfApp1.Data;
using WpfApp1.Models;
using WpfApp1.ViewModels;

namespace WpfApp1
{
    class AppBootstrapper : BootstrapperBase
    {
        private SimpleContainer container;
        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            container = new SimpleContainer();

            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IEventAggregator, EventAggregator>();

            container.PerRequest<ShellViewModel>();
            container.PerRequest<PersonViewModel>();
            container.PerRequest<PageTwoViewModel>();
            container.PerRequest<ICanSaveService, CanSaveInDbService>();
            container.PerRequest<PersonModel>();
            var options = new DbContextOptionsBuilder<AppDbContext>()
                     .UseSqlServer(@"Server=(localdb)\QUINB016787\SQLEXPRESS;Database=TestDb;Integrated Security=True;")
                     //.UseInMemoryDatabase("Db")
                     .Options;
            var db = new AppDbContext(options);
            container.Instance(db);
           // container.Singleton<AppDbContext>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return new[] { Assembly.GetExecutingAssembly() };
        }
    }
}
