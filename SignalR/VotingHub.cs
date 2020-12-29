using Interfaces.SignalR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace SignalR
{
    public class VotingHub : BaseHub, IVotingHubClient
    {
        private readonly string _receiveResult = "receiveResult";

        public VotingHub(IHubContext<BaseHub> context) : base(context)
        {
        }

        public async Task ShareResult(Guid result)
        {
            await BroadcastMessage(_receiveResult, new[] { result });
        }
    }
}
