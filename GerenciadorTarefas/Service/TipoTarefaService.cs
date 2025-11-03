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

        public async Task<TipoTarefaDTO> addAsync(TipoTarefaDTO tipoTarefa, int userID)
        {
            var entidade = mapper.Map<TipoTarefa>(tipoTarefa);
            entidade.idLogin = userID;
            entidade = await this.repositorio.addAsync(entidade);
            return mapper.Map<TipoTarefaDTO>(entidade);
        }

        public async Task<IEnumerable<TipoTarefaDTO>> getAllAsync(int userID)
        {
            var listaTipo = await this.repositorio.getAllAsync(p => p.idLogin == userID);
            return mapper.Map<IEnumerable<TipoTarefaDTO>>(listaTipo);
        }

        public async Task<TipoTarefaDTO?> getAsync(int id, int userID)
        {
            var tipo = await this.repositorio.getAsync(id);

            if (tipo == null || tipo.idLogin != userID)
            {
                return null;
            }

            return mapper.Map<TipoTarefaDTO>(tipo);
        }

        public async Task removeAsync(int id, int userID)
        {
            var tipo = await this.repositorio.getAsync(id);
            if(tipo != null && tipo.idLogin == userID)
            {
                await this.repositorio.removeAsync(tipo);
            }
        }

        public async Task updateAsync(TipoTarefaDTO tipoTarefa, int userID)
        {
            var tipo = await this.repositorio.getAsync(tipoTarefa.id);
            if (tipo != null && tipo.idLogin == userID)
            {
                mapper.Map(tipoTarefa, tipo);
                tipo.idLogin = userID;
                await this.repositorio.updateAsync(tipo);
            }
            
        }
    }
}
