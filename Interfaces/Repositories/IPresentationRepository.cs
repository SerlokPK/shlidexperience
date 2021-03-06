﻿using DomainModels.Presentations;
using System.Collections.Generic;

namespace Interfaces.Repositories
{
    public interface IPresentationRepository
    {
        List<PresentationView> GetPresentations(int userId);
        Presentation GetPresentation(int userId, int presentationId);
        int CreatePresentation(int userId, string name);
        void UpdatePresentation(int userId, int presentationId, string name);
        void RemovePresentation(int userId, int presentationId);
    }
}
