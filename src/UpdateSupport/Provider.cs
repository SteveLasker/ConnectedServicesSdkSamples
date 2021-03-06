﻿using Contoso.Samples.ConnectedServices.UpdateSupport.ViewModels;
using Microsoft.VisualStudio.ConnectedServices;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Contoso.Samples.ConnectedServices.UpdateSupport
{
    [ConnectedServiceProviderExport(
        "Microsoft.Samples.UpdateSupport",
        SupportsUpdate = true)]
    internal class Provider : ConnectedServiceProvider
    {
        public Provider()
        {
            this.Name = "Sample: Update Support";
            this.Category = "Contoso";
            this.Description = "A sample handler demonstrating supporting update of a service";
            this.Icon = new BitmapImage(new Uri("pack://application:,,/" + this.GetType().Assembly.ToString() + ";component/Resources/ProviderIcon.png"));
            this.CreatedBy = "Microsoft";
            this.Version = new Version(1, 0, 0);
            this.MoreInfoUri = new Uri("http://aka.ms/ConnectedServicesSDK");
        }

        public override Task<ConnectedServiceConfigurator> CreateConfiguratorAsync(ConnectedServiceProviderContext context)
        {
            SinglePageViewModel configurator = new SinglePageViewModel();
            configurator.Context = context;
            // Initialize viewmodel with the update functionality, based on the context
            configurator.Initialize();

            return Task.FromResult(configurator as ConnectedServiceConfigurator);
        }
    }
}
