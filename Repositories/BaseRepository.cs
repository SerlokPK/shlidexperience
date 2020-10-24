using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repositories.Data;

namespace Repositories
{
    public class BaseRepository
    {
        protected DbContextOptions<ShlidexperienceContext> _options;

        public BaseRepository(IOptions<AppSettings> config)
        {
            _options = new DbContextOptionsBuilder<ShlidexperienceContext>()
                   .UseSqlServer(config.Value.ConnectionString)
                   .Options;
        }

        public ShlidexperienceContext GetContext()
        {
            return new ShlidexperienceContext(_options);
        }
    }
}
