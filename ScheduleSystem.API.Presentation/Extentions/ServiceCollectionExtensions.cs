﻿using ScheduleSystem.API.CrossCutting;

namespace ScheduleSystem.API.Presentation.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddNativeIoC(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            RegisterAllServices(serviceCollection, configuration);
        }
        private static void RegisterAllServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            InjectorBootStrapper.RegisterServices(serviceCollection, configuration);
        }
    }
}
