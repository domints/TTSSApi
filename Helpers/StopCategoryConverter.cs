using TTSSApi.Web.Enums;

namespace TTSSApi.Web.Helpers
{
    internal static class StopCategoryConverter
    {
        internal static StopType Convert(string category)
        {
            switch(category)
            {
                case "tram":
                    return StopType.Tram;

                case "bus":
                    return StopType.Bus;

                case "other":
                    return StopType.Other;
            }

            return StopType.Unknown;
        }
    }
}