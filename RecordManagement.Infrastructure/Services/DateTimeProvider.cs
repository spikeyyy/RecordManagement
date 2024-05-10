using RecordManagement.Application.Services;

namespace RecordManagement.Infrastructure.Services;

public class DateTimeProvide : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;}