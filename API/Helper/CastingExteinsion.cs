using System.Collections.ObjectModel;
using System.Collections.Generic;
using API.DTOs;
using AutoMapper;

using Microsoft.Extensions.DependencyInjection;
using Core;

namespace API.Helper
{
    public static class CastExtension
    {
        //  Employees
        // public static EmployeeDto AsEmployeeDto(this Employee entity)
        // {
        //     return EvaluateModelToDto<Employee, EmployeeDto>(entity);
        // }
        // public static Employee AsEmployee(this EmployeeDto entity)
        // {
        //     return EvaluateModelToDto<EmployeeDto, Employee>(entity);
        // }
        // public static List<EmployeeDto> AsEmployeeListDto(this List<Employee> entity)
        // {
        //     return EvaluateModelToDto<Employee, EmployeeDto>(entity);
        // }

        //Map Obj To Obj
        public static TDestination EvaluateModelToDto<TSource, TDestination>(this TSource data)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            var mapper = new Mapper(config);
            return mapper.Map<TSource, TDestination>(data);
        }
        //Map List To List
        // private static List<TDestination> EvaluateModelToDto<TSource, TDestination>(this List<TSource> data)
        // {
        //     var config = new MapperConfiguration(cfg =>
        //     {
        //         cfg.AddProfile(new AutoMapperProfile());
        //     });
        //     var mapper = new Mapper(config);
        //     return mapper.Map<List<TSource>, List<TDestination>>(data);
        // }

    }



}