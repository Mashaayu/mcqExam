
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using AutoMapper;
//using AutoMapper.Internal;
//using Microsoft.Extensions.DependencyInjection.Extensions;
//using Microsoft.Extensions.Options;
//using Microsoft.Extensions.Configuration;
//using AutoMapper.Configuration;

//namespace EmployeeRH.Extensions
//{
//    public static class AutomapperExtension
//    {
//        public static IServiceCollection AddAutoMapper(this IServiceCollection services, params Type[] profileAssemblyMarkerTypes)
//        {
//            return AddAutoMapperClasses(services, null, profileAssemblyMarkerTypes.Select((Type t) => t.GetTypeInfo().Assembly));
//        }


//        private static IServiceCollection AddAutoMapperClasses(IServiceCollection services, Action<IServiceProvider, IMapperConfigurationExpression> configAction, IEnumerable<Assembly> assembliesToScan, ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
//        {
//            if (configAction != null)
//            {
//                services.AddOptions<MapperConfigurationExpression>().Configure(delegate (MapperConfigurationExpression options, IServiceProvider sp)
//                {
//                    configAction(sp, options);
//                });
//            }

//            if (assembliesToScan != null)
//            {
//                assembliesToScan = new HashSet<Assembly>(assembliesToScan.Where((Assembly a) => !a.IsDynamic && a != typeof(Mapper).Assembly));
//                services.Configure(delegate (MapperConfigurationExpression options)
//                {
//                    options.AddMaps(assembliesToScan);
//                });
//                Type[] openTypes = new Type[5]
//                {
//                typeof(IValueResolver<, , >),
//                typeof(IMemberValueResolver<, , , >),
//                typeof(ITypeConverter<, >),
//                typeof(IValueConverter<, >),
//                typeof(IMappingAction<, >)
//                };
//                foreach (Type item in assembliesToScan.SelectMany((Assembly a) => from type in a.GetTypes()
//                                                                                  where type.IsClass && !type.IsAbstract && Array.Exists(openTypes, (Type openType) => type.GetGenericInterface(openType) != null)
//                                                                                  select type))
//                {
//                    services.TryAddTransient(item);
//                }
//            }

//            if (services.Any((ServiceDescriptor sd) => sd.ServiceType == typeof(IMapper)))
//            {
//                return services;
//            }

//            services.AddSingleton((Func<IServiceProvider, IConfigurationProvider>)((IServiceProvider sp) => new MapperConfiguration(sp.GetRequiredService<IOptions<MapperConfigurationExpression>>().Value)));
//            services.Add(new ServiceDescriptor(typeof(IMapper), (IServiceProvider sp) => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService), serviceLifetime));
//            return services;
//        }

//    }
//}
