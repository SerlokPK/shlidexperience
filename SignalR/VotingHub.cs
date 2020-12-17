using Interfaces.SignalR;
using System.Threading.Tasks;

namespace SignalR
{
    public class VotingHub : BaseHub, IVotingHubClient
    {
        private readonly string _receiveResult = "receiveResult";

        public async Task ShareResult(string result)
        {
            await BroadcastMessage(result, _receiveResult);
        }
    }
}
