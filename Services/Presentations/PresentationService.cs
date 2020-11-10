using AutoMapper;
using Common.Helpers;
using DtoModels.Presentations.Request;
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

        public int CreatePresentation(int userId, CreatePresentationModel model)
        {
            return _presentationRepository.CreatePresentation(userId, model.Name);
        }

        public PresentationDto GetPresentation(int userId, short presentationId)
        {
            var presentation = _presentationRepository.GetPresentation(userId, presentationId);

            return _mapper.Map<PresentationDto>(presentation);
        }

        public List<PresentationViewDto> GetPresentations(int userId)
        {
            var presentations = _presentationRepository.GetPresentations(userId);

            return _mapper.Map<List<PresentationViewDto>>(presentations);
        }
    }
}
