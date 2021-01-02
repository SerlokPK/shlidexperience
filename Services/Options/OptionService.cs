using AutoMapper;
using Common.Helpers;
using DtoModels.Options.Request;
using Interfaces.Repositories;
using Interfaces.Services;
using SignalR;
using System.Threading.Tasks;

namespace Services.Options
{
    public class OptionService : IOptionService
    {
        private readonly IMapper _mapper;
        private readonly IOptionRepository _optionRepository;
        private readonly IVotingHubClient _votingHub;
        private readonly IVotingService _votingService;
        
        public OptionService(
            IMapper mapper, 
            IOptionRepository optionRepository, 
            IVotingHubClient votingHubClient,
            IVotingService votingService)
        {
            DependencyHelper.ThrowIfNull(mapper, optionRepository, votingHubClient, votingService);

            _mapper = mapper;
            _optionRepository = optionRepository;
            _votingHub = votingHubClient;
            _votingService = votingService;
        }

        public async Task VoteOnOption(SaveOptionResultModel model)
        {
            _optionRepository.SaveOptionResult(model.SlideId, model.OptionId, model.DeviceId);
            await _votingService.ShareResult(model.OptionId);
        }
    }
}
