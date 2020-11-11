using Common;
using Interfaces.Repositories;
using Microsoft.Extensions.Options;

namespace Repositories.Slides
{
    public class SlideRepository : BaseRepository, ISlideRepository
    {
        public SlideRepository(IOptions<AppSettings> config) : base(config)
        {
        }
    }
}
