namespace TTSSApi.Web.Helpers
{
    public static class IntExtensions
    {
        internal static decimal ToCoordinate(this int mpkCoord)
        {
            return mpkCoord / 3600000.0m;
        }
    }
}