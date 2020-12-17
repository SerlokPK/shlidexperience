using System.Threading.Tasks;

namespace Interfaces.SignalR
{
    public interface IVotingHubClient
    {
        Task ShareResult(string result);
    }
}
