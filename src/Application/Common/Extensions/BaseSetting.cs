using AutoMapper;
using Application.Common.Interfaces;

namespace Application.Common.Extensions;
public class BaseSetting
{
    private protected readonly IMapper _mapper;
    private protected readonly IApplicationDbContext _dbContext;

    public BaseSetting(IMapper mapper,
                       IApplicationDbContext context)
    {
        _mapper = mapper;
        _dbContext = context;
    }
}