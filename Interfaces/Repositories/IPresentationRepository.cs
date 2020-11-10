﻿using DomainModels.Presentations;
using System.Collections.Generic;

namespace Interfaces.Repositories
{
    public interface IPresentationRepository
    {
        List<PresentationView> GetPresentations(int userId);
    }
}
