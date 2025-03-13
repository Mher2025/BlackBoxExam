using MediatR;
using BlackBox.Domain.Database;
using Microsoft.EntityFrameworkCore;
using BlackBox.Core.Features.Users.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace BlackBox.Core.Features.Users.Queries
{
    public class GetUserList
    {
        public class QueryHandler : IRequestHandler<Query, QueryResponse>
        {
            private readonly ApplicationDbContext _dbContext;
            private readonly IMapper _mapper;
            public QueryHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
            {
                _dbContext = applicationDbContext;
                _mapper = mapper;
            }
            public async Task<QueryResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                var users = await _dbContext.Users
                    .ProjectTo<GetUsersDTO>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return new QueryResponse() { UsersList = users };
            }
        }
        public class Query : IRequest<QueryResponse>
        { 
        }

        public class QueryResponse
        {
            public List<GetUsersDTO> UsersList { get; set; } = new List<GetUsersDTO>();
        }
    }
}
