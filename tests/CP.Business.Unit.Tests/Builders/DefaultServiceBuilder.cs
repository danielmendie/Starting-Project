﻿using Microsoft.Extensions.DependencyInjection;

namespace CP.Business.Unit.Tests.Builders
{
    public static class DefaultServiceBuilder
    {
        public static T Build<T>()
        {
#pragma warning disable CS8603 // Possible null reference return.
            return BaseTest.ServiceProvider.GetService<T>();
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
