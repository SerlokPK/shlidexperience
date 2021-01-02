using Common.Helpers;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace SignalR
{
    public class VotingService : IVotingService
    {
        private readonly string _receiveResult = "receiveResult";
        private readonly IHubContext<VotingHub> _context;

        public VotingService(IHubContext<VotingHub> context)
        {
            DependencyHelper.ThrowIfNull(context);

            _context = context;
        }

        public async Task ShareResult(Guid optionId)
        {
            await _context.Clients.All.SendAsync(_receiveResult, optionId);
        }
    }
}
