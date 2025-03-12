using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ASPReactCQRS.Persistence.Common.Comparers
{
    public class TimeOnlyComparer : ValueComparer<TimeOnly>
    {
        public TimeOnlyComparer() : base(
            (x, y) => x.Ticks == y.Ticks,
            timeOnly => timeOnly.GetHashCode())
        { }
    }
}
