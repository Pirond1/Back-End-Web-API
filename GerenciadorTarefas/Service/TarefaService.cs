using AutoMapper;
using Dominio.DTOs;
using Dominio.Entidades;
using Interface.Repositorio;
using Interface.Service;
using Microsoft.EntityFrameworkCore;
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

        public async Task<TarefaDTO> addAsync(TarefaDTO tarefa, int userID)
        {
            var entidade = mapper.Map<Tarefa>(tarefa);
            entidade.idLogin = userID;
            entidade = await this.repositorio.addAsync(entidade);
            return mapper.Map<TarefaDTO>(entidade);
        }

        public async Task<IEnumerable<TarefaDTO>> getAllAsync(int userID, int? idTipoTarefa)
        {
            if (idTipoTarefa.HasValue)
            {
                var listaFiltrada = await this.repositorio.getAllAsync(t => t.idLogin == userID && t.idTipoTarefa == idTipoTarefa.Value);
                return mapper.Map<IEnumerable<TarefaDTO>>(listaFiltrada);
            }
            else
            {
                var listaCompleta = await this.repositorio.getAllAsync(t => t.idLogin == userID);
                return mapper.Map<IEnumerable<TarefaDTO>>(listaCompleta);
            }
        }

        public async Task<TarefaDTO?> getAsync(int id, int userID)
        {
            var listaTarefa = await this.repositorio.getAsync(id);
            if (listaTarefa == null || listaTarefa.idLogin != userID)
            {
                return null;
            }
            return mapper.Map<TarefaDTO>(listaTarefa);
        }

        public async Task removeAsync(int id, int userID)
        {
            var tarefa = await this.repositorio.getAsync(id);
            if(tarefa != null && tarefa.idLogin == userID)
            {
                await this.repositorio.removeAsync(tarefa);
            }     
        }

        public async Task updateAsync(TarefaDTO tarefa, int userID)
        {
            var tar = await this.repositorio.getAsync(tarefa.id);
            if (tar != null && tar.idLogin == userID)
            {
                mapper.Map(tarefa, tar);
                tar.idLogin = userID;
                tar.idTipoTarefa = tarefa.idTipoTarefa;
                tar.status = tarefa.status;

                tar.tipotarefa = null;

                await this.repositorio.updateAsync(tar);
            }
            
        }
    }
}
