using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using RuSpeak.Models.Auth;
using RuSpeak.Models.Things;

namespace RuSpeak.Infrastructure.Mappers
{
    public class CommonMapper : IMapper
    {
        static CommonMapper()
        {
            Mapper.CreateMap<User, RegisterInfo>();
            Mapper.CreateMap<RegisterInfo, User>();

            Mapper.CreateMap<Post, PostInfo>();
            Mapper.CreateMap<PostInfo, Post>();
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
}