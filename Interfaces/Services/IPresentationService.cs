using DtoModels.Presentations.Response;
using System.Collections.Generic;

namespace Interfaces.Services
{
    public interface IPresentationService
    {
        List<PresentationDto> GetPresentations(int userId);
    }
}
