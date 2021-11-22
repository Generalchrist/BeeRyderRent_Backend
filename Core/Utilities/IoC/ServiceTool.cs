using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC {
    public static class ServiceTool {

        // Ioc => inversion of control
        //oluşturulan injectionları tekraren kullanmamızı sağlıyor
        //ya mesela zincir dışında olan yerlerde programa dahil olabilsin
        //diye injection veriyoruz

        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services) {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
