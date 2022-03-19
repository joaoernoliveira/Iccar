using AutoMapper;
using Japuacu.Blog.Aplicacao.ViewModels;
using Japuacu.Blog.Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Japuacu.Blog.Aplicacao.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Autor, AutorVM>().ReverseMap();
            CreateMap<Comentario, ComentarioVM>().ReverseMap();
            CreateMap<Paragrafo, ParagrafoVM>().ReverseMap();
            CreateMap<Post, PostVM>().ReverseMap();
        }
    }
}