using AutoMapper;
using Common;
using Common.Helpers;
using DomainModels.Exceptions;
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

        public Presentation GetPresentation(int userId, short presentationId)
        {
            using (var context = GetContext())
            {
                var presentation = context.Presentations
                                          .SingleOrDefault(p => p.PresentationId == presentationId && p.UserId == userId);
                if (presentation != null)
                {
                    return _mapper.Map<Presentation>(presentation);
                }

                throw new NotFoundException("Presentation does not exist");
            }
        }

        public List<PresentationView> GetPresentations(int userId)
        {
            using (var context = GetContext())
            {
                var presentations = context.Presentations
                                           .Include(p => p.Slides)
                                           .Where(p => p.UserId == userId);

                return _mapper.Map<List<PresentationView>>(presentations);
            }
        }
    }
}
