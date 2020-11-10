using DtoModels.Presentations.Response;
using System.Collections.Generic;

namespace Interfaces.Services
{
    public interface IPresentationService
    {
        List<PresentationViewDto> GetPresentations(int userId);
        PresentationDto GetPresentation(int userId, short presentationId);
    }
}
