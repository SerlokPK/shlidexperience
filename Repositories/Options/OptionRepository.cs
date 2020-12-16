using AutoMapper;
using Common;
using Interfaces.Repositories;
using Microsoft.Extensions.Options;

namespace Repositories.Options
{
    public class OptionRepository : BaseRepository, IOptionRepository
    {
        private readonly IMapper _mapper;

        public OptionRepository(IOptions<AppSettings> options, IMapper mapper) : base(options)
        {
            //DependencyHelper.ThrowIfNull(options, mapper);

            _mapper = mapper;
        }

        public void VoteOnOption()
        {
            throw new System.NotImplementedException();
        }
    }
}
