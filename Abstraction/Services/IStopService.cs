using System.Collections.Generic;
using System.Threading.Tasks;
using TTSSApi.Web.Models.API;

namespace TTSSApi.Web.Abstraction.Services
{
    public interface IStopService
    {
        Task<IReadOnlyCollection<StopBase>> GetAutocomplete(string query);
    }
}