﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SimpleCMS.Application.Common.PipelineBehaviours;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SimpleCMS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehaviour<,>));

            return services;
        }
    }
}
