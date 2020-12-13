using System.Threading.Tasks;

namespace SignalR
{
    public interface IVotingHubClient
    {
        Task ReceiveResult(string result);
    }
}
