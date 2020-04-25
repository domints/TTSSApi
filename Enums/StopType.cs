using System;

namespace TTSSApi.Web.Enums
{
    [Flags]
    public enum StopType : int
    {
        Unknown = 1,
        Tram = 2,
        Bus = 4,
        Other = 8
    }
}