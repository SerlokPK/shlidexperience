using AutoMapper;
using Common;
using Common.Helpers;
using DomainModels.Exceptions;
using Interfaces.Repositories;
using Microsoft.Extensions.Options;
using Repositories.Data;
using System;
using System.Linq;

namespace Repositories.Options
{
    public class OptionRepository : BaseRepository, IOptionRepository
    {
        private const string _slideDoesNotExist = "Slide does not exist";
        private const string _optionExist = "Option for this slide already selected";

        private readonly IMapper _mapper;

        public OptionRepository(IOptions<AppSettings> options, IMapper mapper) : base(options)
        {
            DependencyHelper.ThrowIfNull(options, mapper);

            _mapper = mapper;
        }

        public void SaveOptionResult(short slideId, Guid optionId, Guid deviceId)
        {
            using (var context = GetContext())
            {
                if (!context.Slides.Any(s => s.SlideId == slideId))
                {
                    throw new NotFoundException(_slideDoesNotExist);
                }
                if (context.OptionResults.Any(o => o.SlideId == slideId && o.DeviceId == deviceId))
                {
                    throw new ConflictException(_optionExist);
                }

                var option = context.SlideOptions.Find(optionId);
                option.NumberOfAnswers++;

                var optionResult = new OptionResultEntity
                {
                    SlideId = slideId,
                    SlideOptionId = optionId,
                    DeviceId = deviceId
                };

                context.OptionResults.Add(optionResult);
                context.SaveChanges();
            }
        }
    }
}
