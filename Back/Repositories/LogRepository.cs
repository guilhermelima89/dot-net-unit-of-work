using Api.Data;
using Api.Interfaces;
using Api.Models;
using Data.Repositories;

namespace Api.Repositories;

public class LogRepository : Repository<Log>, ILogRepository
{
    public LogRepository(ApplicationDbContext context) : base(context)
    {
    }
}