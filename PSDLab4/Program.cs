﻿using System;
using DomainModel.Infrastructure;
using DomainModel.Service;
using Presenters.Presenters;
using View.Forms;
using View.ViewInterfaces;
using System.Windows.Forms;
using Autofac;
using PSDLab4.Presenters;

namespace PSDLab4
{
    static class Program
    {
        private static IContainer _container;

        [STAThread]
        static void Main()
        {
            RegisterTypes();

            var presenter = _container.Resolve<Pres>();
            
            try
            {
                presenter.Run();
            }
            catch (Exception e)
            {
                Application.Exit();
            }
        }

        private static void RegisterTypes()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AddingForm>().As<IInputView>();
            builder.RegisterType<SubPres>();
            builder.RegisterType<Model>().As<IModel>();
            builder.RegisterType<MainForm>().As<IMainView>();
            builder.RegisterType<Pres>();
            _container = builder.Build();
        }
    }
}
