using System;
using System.Threading.Tasks;

namespace SignalR
{
    public interface IVotingService
    {
        Task ShareResult(Guid optionId);
    }
}
