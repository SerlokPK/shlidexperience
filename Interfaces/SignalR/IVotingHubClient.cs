using System;
using System.Threading.Tasks;

namespace Interfaces.SignalR
{
    public interface IVotingHubClient
    {
        Task ShareResult(Guid optionId);
    }
}
