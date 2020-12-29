using AutoMapper;
using Common.Helpers;
using DtoModels.Options.Request;
using Interfaces.Repositories;
using Interfaces.Services;
using Interfaces.SignalR;
using System.Threading.Tasks;

namespace Services.Options
{
    public class OptionService : IOptionService
    {
        private readonly IMapper _mapper;
        private readonly IOptionRepository _optionRepository;
        private readonly IVotingHubClient _votingHub;

        public OptionService(IMapper mapper, IOptionRepository optionRepository, IVotingHubClient votingHubClient)
        {
            DependencyHelper.ThrowIfNull(mapper, optionRepository, votingHubClient);

            _mapper = mapper;
            _optionRepository = optionRepository;
            _votingHub = votingHubClient;
        }

        public async Task VoteOnOption(SaveOptionResultModel model)
        {
            _optionRepository.SaveOptionResult(model.SlideId, model.OptionId, model.DeviceId);
            await _votingHub.ShareResult(model.OptionId);
        }
    }
}
