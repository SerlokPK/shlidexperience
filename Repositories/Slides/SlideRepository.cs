using AutoMapper;
using Common;
using Common.Helpers;
using DomainModels.Exceptions;
using DomainModels.Slides;
using DtoModels.Slides.Filters;
using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repositories.Data;
using System;
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
            DependencyHelper.ThrowIfNull(mapper);

            _mapper = mapper;
        }

        public Slide CreateSlide(int presentationId)
        {
            using (var context = GetContext())
            {
                if (!context.Presentations.Any(p => p.PresentationId == presentationId))
                {
                    throw new NotFoundException(_presentationDoesNotExist);
                }

                var slide = new SlideEntity
                {
                    PresentationId = presentationId,
                    SlideTypeId = (short)SlideType.MultipleChoice
                };
                var slideEntity = context.Add(slide).Entity;

                context.SaveChanges();

                return _mapper.Map<Slide>(slideEntity);
            }
        }

        public void DeleteSlide(short slideId, int presentationId)
        {
            using (var context = GetContext())
            {
                var slide = context.Slides.SingleOrDefault(s => s.SlideId == slideId && s.PresentationId == presentationId);
                if (slide == null)
                {
                    throw new NotFoundException(_slideDoesNotExist);
                }

                context.Slides.Remove(slide);
                context.SaveChanges();
            }
        }

        public Slide GetSlide(short slideId, int presentationId, Guid deviceId)
        {
            using (var context = GetContext())
            {
                var slide = context.Slides.Include(s => s.SlideOptions)
                                          .SingleOrDefault(s => s.SlideId == slideId && s.PresentationId == presentationId);

                if (slide == null)
                {
                    throw new NotFoundException(_slideDoesNotExist);
                }

                var slideDto = _mapper.Map<Slide>(slide);
                slideDto.HasAnswered = context.OptionResults.Any(r => r.SlideId == slideId && r.DeviceId == deviceId);

                return slideDto;
            }
        }

        public List<Slide> GetSlides(int presentationId, SlideFilter filter)
        {
            using (var context = GetContext())
            {
                var query = context.Slides
                                    .Include(s => s.SlideOptions)
                                    .Where(s => s.PresentationId == presentationId);

                query = ApplySlideFilter(query, filter);

                return _mapper.Map<List<Slide>>(query);
            }
        }

        public int GetSlidesCount(int presentationId)
        {
            using (var context = GetContext())
            {
                return context.Slides.Count(s => s.PresentationId == presentationId);
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

        public Slide EditSlide(short slideId, int presentationId, string question, SlideType type, List<SlideOption> slideOptions)
        {
            using (var context = GetContext())
            {
                var slide = context.Slides.Include(s => s.SlideOptions)
                                          .SingleOrDefault(s => s.SlideId == slideId && s.PresentationId == presentationId);

                if (slide == null)
                {
                    throw new NotFoundException(_slideDoesNotExist);
                }

                UpdateSlide(question, type, slide);
                RemoveSlideOptions(slideOptions, slide.SlideOptions);
                AddOrUpdateSlideOptions(slideOptions, slide.SlideOptions);

                context.SaveChanges();

                return _mapper.Map<Slide>(slide);
            }
        }

        private void UpdateSlide(string question, SlideType type, SlideEntity slide)
        {
            if (question != slide.Question)
            {
                slide.Question = question;
            }

            if (type != (SlideType)slide.SlideTypeId)
            {
                slide.SlideTypeId = (short)type;
            }
        }

        private void AddOrUpdateSlideOptions(List<SlideOption> slideOptions, ICollection<SlideOptionEntity> slideOptionEntities)
        {
            foreach (var option in slideOptions)
            {
                var optionEntity = slideOptionEntities.SingleOrDefault(x => x.SlideOptionId == option.SlideOptionId);
                if (optionEntity != null)
                {
                    if (optionEntity.Text != option.Text)
                    {
                        optionEntity.Text = option.Text;
                    }
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
            var optionsToRemove = slideOptionEntities.Where(x => !slideOptions
                                                     .Any(s => s.SlideOptionId == x.SlideOptionId))
                                                     .ToList();
            foreach (var option in optionsToRemove)
            {
                slideOptionEntities.Remove(option);
            }
        }

        private IQueryable<SlideEntity> ApplySlideFilter(IQueryable<SlideEntity> entities, SlideFilter filter)
        {
            if (filter?.ItemsToSkip != null)
            {
                entities = entities.Skip(filter.ItemsToSkip.Value)
                    .Take(1);
            }

            return entities;
        }
    }
}
