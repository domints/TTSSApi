using System.Collections.Generic;
using System.Threading.Tasks;
using TTSSApi.Web.Enums;
using TTSSApi.Web.Models.API;

namespace TTSSApi.Web.Abstraction.Clients
{
    public interface IStopClient
    {
        Task<List<StopData>> GetAllStops(StopType requestedTypes = StopType.Other | StopType.Tram | StopType.Bus);
    }
}