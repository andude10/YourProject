using YourProject.Application.Common.Interfaces;

namespace YourProject.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
