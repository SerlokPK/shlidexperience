using System.Threading.Tasks;

namespace SignalR
{
    public class VotingHub : BaseHub, IVotingHubClient
    {
        private readonly string _receiveResult = "receiveResult";

        public async Task ReceiveResult(string result)
        {
            await SendToCaller(result, _receiveResult);
        }
    }
}
