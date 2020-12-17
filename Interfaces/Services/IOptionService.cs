using DtoModels.Options.Request;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IOptionService
    {
        Task VoteOnOption(SaveOptionResultModel model);
    }
}
