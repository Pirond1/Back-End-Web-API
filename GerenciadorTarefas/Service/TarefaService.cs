using AutoMapper;
using Dominio.DTOs;
using Dominio.Entidades;
using Interface.Repositorio;
using Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TarefaService : ITarefaService
    {
        private ITarefaRepositorio repositorio;

        private IMapper mapper;

        public TarefaService(ITarefaRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        public async Task<TarefaDTO> addAsync(TarefaDTO tarefa)
        {
            var entidade = mapper.Map<Tarefa>(tarefa);
            entidade = await this.repositorio.addAsync(entidade);
            return mapper.Map<TarefaDTO>(entidade);
        }

        public async Task<IEnumerable<TarefaDTO>> getAllAsync(Expression<Func<Tarefa, bool>> expression)
        {
            var listaTarefa = await this.repositorio.getAllAsync(expression);
            return mapper.Map<IEnumerable<TarefaDTO>>(listaTarefa);
        }

        public async Task<TarefaDTO?> getAsync(int id)
        {
            var listaTarefa = await this.repositorio.getAsync(id);
            return mapper.Map<TarefaDTO>(listaTarefa);
        }

        public async Task removeAsync(int id)
        {
            var tarefa = await this.repositorio.getAsync(id);
            if(tarefa != null)
            {
                await this.repositorio.removeAsync(tarefa);
            }
        }

        public async Task updateAsync(TarefaDTO tarefa)
        {
            var tar = mapper.Map<Tarefa>(tarefa);
            await this.repositorio.updateAsync(tar);
        }
    }
}
