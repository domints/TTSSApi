using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using TTSSApi.Web.Abstraction.Providers;
using TTSSApi.Web.Abstraction.Clients;
using TTSSApi.Web.Enums;
using TTSSApi.Web.Helpers;
using TTSSApi.Web.Models.API;

namespace TTSSApi.Web.Providers
{
    public class StopsProvider : IStopsProvider
    {

        private readonly IStopClient _stopClient;
        public StopsProvider(IStopClient stopClient)
        {
            _stopClient = stopClient;
        }

        private ConcurrentDictionary<int, StopType> StopTypeCache;
        private ConcurrentDictionary<int, string> SimplifiedNames;
        private ConcurrentBag<StopBase> Stops;

        public async Task<IReadOnlyCollection<StopBase>> GetAllStops()
        {
            if(Stops == null || Stops.Count == 0)
                await InitStaticData().ConfigureAwait(false);

            return Stops;
        }

        public string GetSimplifiedName(int id)
        {
            if(SimplifiedNames == null)
                return string.Empty;
            return SimplifiedNames.GetValueOrDefault(id);
        }

        public async Task InitStaticData()
        {
            var stops = await _stopClient.GetAllStops();
            if(StopTypeCache == null)
                StopTypeCache = new ConcurrentDictionary<int, StopType>();
            if(Stops == null)
                Stops = new ConcurrentBag<StopBase>();
            if(SimplifiedNames == null)
                SimplifiedNames = new ConcurrentDictionary<int, string>();
            
            StopTypeCache.Clear();
            Stops.Clear();
            SimplifiedNames.Clear();

            foreach(var stop in stops)
            {
                StopTypeCache.AddOrUpdate(stop.Id, stop.Type, (_, __) => stop.Type);
                Stops.Add(new StopBase { Id = stop.Id, Name = stop.Name.Trim() });
                SimplifiedNames.AddOrUpdate(stop.Id, stop.Name.PrepareForCompare(), (_, __) => stop.Name.PrepareForCompare());
            }
        }
    }
}