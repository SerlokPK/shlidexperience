using System.Threading.Tasks;

namespace SignalR
{
    public interface IVotingHubClient
    {
        Task ShareResult(string result);
    }
}
