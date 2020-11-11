using Common;
using DomainModels.Slides;
using Interfaces.Repositories;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Slides
{
    public class SlideRepository : BaseRepository, ISlideRepository
    {
        public SlideRepository(IOptions<AppSettings> config) : base(config)
        {
        }

        public List<SlideType> GetTypes()
        {
            using (var context = GetContext())
            {
                return context.SlideTypes.Select(x => x.Type)
                                         .ToList();
            }
        }
    }
}
