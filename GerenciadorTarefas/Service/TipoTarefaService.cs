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
    public class TipoTarefaService : ITipoTarefaService
    {
        private ITipoTarefaRepositorio repositorio;

        private IMapper mapper;

        public TipoTarefaService(ITipoTarefaRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        public async Task<TipoTarefaDTO> addAsync(TipoTarefaDTO tipoTarefa)
        {
            var entidade = mapper.Map<TipoTarefa>(tipoTarefa);
            entidade = await this.repositorio.addAsync(entidade);
            return mapper.Map<TipoTarefaDTO>(entidade);
        }

        public async Task<IEnumerable<TipoTarefaDTO>> getAllAsync(Expression<Func<TipoTarefa, bool>> expression)
        {
            var listaTipo = await this.repositorio.getAllAsync(expression);
            return mapper.Map<IEnumerable<TipoTarefaDTO>>(listaTipo);
        }

        public Task<TipoTarefaDTO?> getAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task removeAsync(int id)
        {
            var tipo = await this.repositorio.getAsync(id);
            if(tipo != null)
            {
                await this.repositorio.removeAsync(tipo);
            }
        }

        public async Task updateAsync(TipoTarefaDTO tipoTarefa)
        {
            var tipo = mapper.Map<TipoTarefa>(tipoTarefa);
            await this.repositorio.updateAsync(tipo);
        }
    }
}
