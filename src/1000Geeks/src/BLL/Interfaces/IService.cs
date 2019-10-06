using BLL.ActualResults;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<ActualResult<IEnumerable<T>>> GetAllAsync();
        Task<ActualResult<T>> GetAsync(string hashId);
        Task<ActualResult<string>> CreateAsync(T dto);
        Task<ActualResult> UpdateAsync(T dto);
        Task<ActualResult> DeleteAsync(string hashId);
        void Dispose();
    }
}
