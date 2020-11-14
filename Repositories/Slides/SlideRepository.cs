﻿using AutoMapper;
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

                return slideEntity.SlideId;
            }
        }

        public Slide GetSlide(short slideId)
        {
            using (var context = GetContext())
            {
                var slide = context.Slides.Include(s => s.SlideOptions).SingleOrDefault(s => s.SlideId == slideId);

                if (slide == null)
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

        public Slide EditSlide(short slideId, SlideType type, List<SlideOption> slideOptions)
        {
            using (var context = GetContext())
            {
                var slide = context.Slides.Include(s => s.SlideOptions).SingleOrDefault(s => s.SlideId == slideId);

                if (slide == null)
                {
                    throw new NotFoundException(_slideDoesNotExist);
                }

                RemoveSlideOptions(slideOptions, slide.SlideOptions);
                AddOrUpdateSlideOptions(slideOptions, slide.SlideOptions);

                context.SaveChanges();

                return _mapper.Map<Slide>(slide);
            }
        }

        private void AddOrUpdateSlideOptions(List<SlideOption> slideOptions, ICollection<SlideOptionEntity> slideOptionEntities)
        {
            foreach (var option in slideOptions)
            {
                var optionEntity = slideOptionEntities.SingleOrDefault(x => x.SlideOptionId == option.SlideOptionId);
                if (optionEntity != null)
                {
                    optionEntity.Text = option.Text;
                }
                else
                {
                    slideOptionEntities.Add(new SlideOptionEntity
                    {
                        Text = option.Text
                    });
                }
            }
        }

        private void RemoveSlideOptions(List<SlideOption> slideOptions, ICollection<SlideOptionEntity> slideOptionEntities)
        {
            var optionsToRemove = slideOptionEntities.Where(x => !slideOptions.Any(s => s.SlideOptionId == x.SlideOptionId));
            foreach (var option in optionsToRemove)
            {
                slideOptionEntities.Remove(option);
            }
        }
    }
}
