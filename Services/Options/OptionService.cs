using AutoMapper;
using Interfaces.Services;

namespace Services.Options
{
    public class OptionService : IOptionService
    {
        private readonly IMapper _mapper;

        public OptionService(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
