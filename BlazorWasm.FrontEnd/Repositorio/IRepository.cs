using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorWasm.FrontEnd.Repositorio
{

        public interface IRepository<T>
        {
            Task Add(T item);
            Task<int> AddAndGetId(T item);
            Task Delete(int Id);
            Task<List<T>> Get();
            Task<List<T>> Get(string filter);
            Task<T> Get(int id);
            Task Update(T item);
        }
    
}
