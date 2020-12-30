using AutoMapper;
using Common.Helpers;
using DtoModels.Options.Request;
using Interfaces.Repositories;
using Interfaces.Services;
using Interfaces.SignalR;
using Microsoft.AspNetCore.SignalR;
using SignalR;
using System.Threading.Tasks;

namespace Services.Options
{
    public class OptionService : IOptionService
    {
        private readonly IMapper _mapper;
        private readonly IOptionRepository _optionRepository;
        private readonly IVotingHubClient _votingHub;
        private readonly IHubContext<VotingHub> _context;

        public OptionService(
            IMapper mapper, 
            IOptionRepository optionRepository, 
            IVotingHubClient votingHubClient,
            IHubContext<VotingHub> context)
        {
            DependencyHelper.ThrowIfNull(mapper, optionRepository, votingHubClient, context);

            _mapper = mapper;
            _optionRepository = optionRepository;
            _votingHub = votingHubClient;
            _context = context;
        }

        public async Task VoteOnOption(SaveOptionResultModel model)
        {
            _optionRepository.SaveOptionResult(model.SlideId, model.OptionId, model.DeviceId);
            //await _context.Clients.All.SendAsync("receiveResult", model.OptionId);
            await _votingHub.ShareResult(model.OptionId);
        }
    }
}
