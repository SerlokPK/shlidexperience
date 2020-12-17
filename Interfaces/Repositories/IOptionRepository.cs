using System;

namespace Interfaces.Repositories
{
    public interface IOptionRepository
    {
        void SaveOptionResult(short slideId, Guid optionId, int userId);
    }
}
