using AutoMapper;
using Dominio.DTOs;
using Dominio.Entidades;

namespace ProjetoAPI.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }
    }
}
