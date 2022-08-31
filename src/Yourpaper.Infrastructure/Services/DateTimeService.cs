using Yourpaper.Application.Common.Interfaces;

namespace Yourpaper.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
