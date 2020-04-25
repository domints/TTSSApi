using System.Collections.Generic;
using System.Threading.Tasks;
using TTSSApi.Web.Models.API;

namespace TTSSApi.Web.Abstraction.Providers
{
    public interface IStopsProvider
    {
        Task<IReadOnlyCollection<StopBase>> GetAllStops();
        string GetSimplifiedName(int id);
    }
}