using Interfaces.SignalR;
using System;
using System.Threading.Tasks;

namespace SignalR
{
    public class VotingHub : BaseHub, IVotingHubClient
    {
        private readonly string _receiveResult = "receiveResult";

        public async Task ShareResult(Guid result)
        {
            await BroadcastMessage(_receiveResult, new[] { result });
        }
    }
}
