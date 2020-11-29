using AutoMapper;
using Common;
using Common.Helpers;
using DomainModels.Exceptions;
using DomainModels.Presentations;
using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Presentations
{
    public class PresentationRepository : BaseRepository, IPresentationRepository
    {
        private const string _presentationDoesNotExist = "Presentation does not exist";

        private readonly IMapper _mapper;

        public PresentationRepository(IOptions<AppSettings> options, IMapper mapper) : base(options)
        {
            DependencyHelper.ThrowIfNull(options, mapper);

            _mapper = mapper;
        }

        public int CreatePresentation(int userId, string name)
        {
            using (var context = GetContext())
            {
                var presentation = new PresentationEntity
                {
                    Name = name,
                    UserId = userId,
                    Created = DateTime.Now
                };
                var presentationEntity = context.Add(presentation).Entity;

                context.SaveChanges();

                return presentationEntity.PresentationId;
            }
        }

        public Presentation GetPresentation(int userId, int presentationId)
        {
            using (var context = GetContext())
            {
                var presentation = context.Presentations
                                          .SingleOrDefault(p => p.PresentationId == presentationId && p.UserId == userId);
                if (presentation != null)
                {
                    return _mapper.Map<Presentation>(presentation);
                }

                throw new NotFoundException(_presentationDoesNotExist);
            }
        }

        public List<PresentationView> GetPresentations(int userId)
        {
            using (var context = GetContext())
            {
                var presentations = context.Presentations
                                           .Include(p => p.Slides)
                                           .Where(p => p.UserId == userId);

                return _mapper.Map<List<PresentationView>>(presentations);
            }
        }

        public void UpdatePresentation(int userId, int presentationId, string name)
        {
            using (var context = GetContext())
            {
                var presentation = context.Presentations
                                          .SingleOrDefault(p => p.PresentationId == presentationId && p.UserId == userId);
                if (presentation == null)
                {
                    throw new NotFoundException(_presentationDoesNotExist);
                }

                presentation.Name = name;

                context.SaveChanges();
            }
        }
    }
}
