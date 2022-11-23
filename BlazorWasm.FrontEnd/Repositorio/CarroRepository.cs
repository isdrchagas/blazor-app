using BlazorWasm.Compartilhado.Entidades;
using BlazorWasm.FrontEnd.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorWasm.FrontEnd.Repositorio
{

    public class CarroRepository : IRepository<Carro>
    {
        private readonly IHttpService httpService;
        private string url = "api/carro";

        public CarroRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<List<Carro>> Get()
        {
            var response = await httpService.Get<List<Carro>>(url);

            if (!response.Sucesso)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }
        public async Task<Carro> Get(int Id)
        {
            var response = await httpService.Get<Carro>($"{url}/{Id}");
            if (!response.Sucesso)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task Add(Carro item)
        {

            var response = await httpService.Post(url, item);
            if (response.Sucesso == false)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
        public async Task<int> AddAndGetId(Carro item)
        {
            var response = await httpService.Post<Carro, int>(url, item);
            if (response.Sucesso == false)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }


        public async Task Update(Carro item)
        {
            var response = await httpService.Put(url, item);
            if (!response.Sucesso)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task Delete(int Id)
        {
            var response = await httpService.Delete($"{url}/{Id}");
            if (!response.Sucesso)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }

}
