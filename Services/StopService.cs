using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTSSApi.Web.Abstraction.Providers;
using TTSSApi.Web.Abstraction.Services;
using TTSSApi.Web.Helpers;
using TTSSApi.Web.Models.API;

namespace TTSSApi.Web.Services
{
    public class StopService : IStopService
    {
        private readonly IStopsProvider _stopsProvider;

        public StopService(IStopsProvider stopsProvider)
        {
            _stopsProvider = stopsProvider;
        }

        public async Task<IReadOnlyCollection<StopBase>> GetAutocomplete(string query)
        {
            if(string.IsNullOrWhiteSpace(query))
                return new List<StopBase>();
            
            var cleanedQ = query.PrepareForCompare();

            return (await _stopsProvider.GetAllStops().ConfigureAwait(false))
                .Where(s => ShouldIncludeStop(s, cleanedQ))
                .ToList();
        }

        private bool ShouldIncludeStop(StopBase stop, string query)
        {
            var name = _stopsProvider.GetSimplifiedName(stop.Id);
            return name.Contains(query) 
                || AreInitials(name, query);
        }

        private bool AreInitials(string fullName, string query)
        {
            bool[] isMatched = new bool[query.Length];
            var lastIndex = 0;
            foreach(var n in fullName.Split(' '))
            {
                var gotMatch = false;
                var nameIndex = 0;
                for(int i = lastIndex; i < query.Length; i++)
                {
                    if(n[nameIndex] == query[i])
                    {
                        if(!gotMatch)
                        {
                            gotMatch = true;
                            lastIndex = i + 1;
                        }

                        isMatched[i] = true;
                        nameIndex++;
                    }
                    else if(gotMatch)
                    {
                        break;
                    }
                }
            }

            return isMatched.All(x => x);
        }
    }
}