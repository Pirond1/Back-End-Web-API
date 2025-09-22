using AutoMapper;
using Dominio.DTOs;
using Dominio.Entidades;
using Interface.Repositorio;
using Interface.Service;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class LoginService : ILoginService
    {
        private ILoginRepositorio repositorio;
        private IMapper mapper;

        public LoginService(ILoginRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        public async Task<LoginDTO> addAsync(LoginDTO login)
        {
            var entidade = mapper.Map<Login>(login);
            entidade = await this.repositorio.addAsync(entidade);
            return mapper.Map<LoginDTO>(entidade);
        }

        public async Task<IEnumerable<LoginDTO>> getAllAsync(Expression<Func<Login, bool>> expression)
        {
            var listaLogin = await this.repositorio.getAllAsync(expression);
            return mapper.Map<IEnumerable<LoginDTO>>(listaLogin);
        }

        public async Task<LoginDTO?> getAsync(int id)
        {
            var login = await this.repositorio.getAsync(id);
            return mapper.Map<LoginDTO>(login);
        }

        public async Task removeAsync(int id)
        {
            var login = await this.repositorio.getAsync(id);
            if(login != null)
            {
                await this.repositorio.removeAsync(login);
            }
        }

        public async Task updateAsync(LoginDTO login)
        {
            var log = mapper.Map<Login>(login);
            await this.repositorio.updateAsync(log);
        }
    }
}
