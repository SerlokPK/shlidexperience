using AutoMapper;
using Common;
using Common.Helpers;
using DomainModels.Presentations;
using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Presentations
{
    public class PresentationRepository : BaseRepository, IPresentationRepository
    {
        private readonly IMapper _mapper;

        public PresentationRepository(IOptions<AppSettings> options, IMapper mapper) : base(options)
        {
            DependencyHelper.ThrowIfNull(options, mapper);

            _mapper = mapper;
        }

        public List<Presentation> GetPresentations()
        {
            using (var context = GetContext())
            {
                var presentations = context.Presentations
                                           .Include(PresentationPath.SlidePath.SlideOptionPath.Path)
                                           .ToList();

                return _mapper.Map<List<Presentation>>(presentations);
            }
        }
    }
}
