using AutoMapper;
using Dominio.DTOs;
using Dominio.Entidades;

namespace GerenciadorTarefas.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Tarefa, TarefaDTO>().ReverseMap();
            CreateMap<TipoTarefa, TipoTarefaDTO>().ReverseMap();
            CreateMap<Login, LoginDTO>().ReverseMap();
        }
    }
}
