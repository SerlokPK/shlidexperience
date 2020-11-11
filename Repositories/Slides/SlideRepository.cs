using AutoMapper;
using Common;
using DomainModels.Exceptions;
using DomainModels.Slides;
using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repositories.Data;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Slides
{
    public class SlideRepository : BaseRepository, ISlideRepository
    {
        private const string _presentationDoesNotExist = "Presentation does not exist";
        private const string _slideDoesNotExist = "Slide does not exist";

        private readonly IMapper _mapper;

        public SlideRepository(IOptions<AppSettings> config, IMapper mapper) : base(config)
        {
            _mapper = mapper;
        }

        public short CreateSlide(int presentationId)
        {
            using (var context = GetContext())
            {
                if (!context.Presentations.Any(p => p.PresentationId == presentationId))
                {
                    throw new NotFoundException(_presentationDoesNotExist);
                }

                var slide = new SlideEntity
                {
                    PresentationId = presentationId
                };
                var slideEntity = context.Add(slide).Entity;

                context.SaveChanges();

                return slideEntity.SlidetId;
            }
        }

        public Slide GetSlide(short slideId)
        {
            using (var context = GetContext())
            {
                var slide = context.Slides.Include(s => s.SlideOptions).SingleOrDefault(s => s.SlidetId == slideId);

                if(slide == null)
                {
                    throw new NotFoundException(_slideDoesNotExist);
                }

                return _mapper.Map<Slide>(slide);
            }
        }

        public List<Slide> GetSlides(int presentationId)
        {
            using (var context = GetContext())
            {
                var slides = context.Slides
                                    .Where(s => s.PresentationId == presentationId);

                return _mapper.Map<List<Slide>>(slides);
            }
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
