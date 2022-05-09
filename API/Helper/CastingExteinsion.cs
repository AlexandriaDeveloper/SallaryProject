using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using API.DTOs;
using AutoMapper;

using Microsoft.Extensions.DependencyInjection;
using Core;
using Core.Specifications;

namespace API.Helper
{
    public static class CastExtension
    {

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
        private static List<TDestination> EvaluateModelToDto<TSource, TDestination>(this List<TSource> data)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<TSource>, List<TDestination>>(data);
        }


  

    }





}