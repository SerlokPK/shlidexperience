using AutoMapper;
using Common.Helpers;
using DtoModels.Presentations.Response;
using Interfaces.Repositories;
using Interfaces.Services;
using System.Collections.Generic;

namespace Services.Presentations
{
    public class PresentationService : IPresentationService
    {
        private readonly IPresentationRepository _presentationRepository;
        private readonly IMapper _mapper;

        public PresentationService(IPresentationRepository presentationRepository, IMapper mapper)
        {
            DependencyHelper.ThrowIfNull(presentationRepository, mapper);

            _presentationRepository = presentationRepository;
            _mapper = mapper;
        }

        public List<PresentationViewDto> GetPresentations(int userId)
        {
            var presentations = _presentationRepository.GetPresentations(userId);

            return _mapper.Map<List<PresentationViewDto>>(presentations);
        }
    }
}
