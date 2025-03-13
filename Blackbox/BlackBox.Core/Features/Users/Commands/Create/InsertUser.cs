using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlackBox.Core.Features.Users.DTOs;
using BlackBox.Domain.Database;
using BlackBox.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBox.Core.Features.Users.Commands.Create
{
    public class InsertUser
    {
        public class CommandHandler : IRequestHandler<InsertUserCommand, CommandResponse>
        {
            private readonly ApplicationDbContext _dbContext;
            private readonly IMapper _mapper;
            public CommandHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
            {
                _dbContext = applicationDbContext;
                _mapper = mapper;
            }

            public async Task<CommandResponse> Handle(InsertUserCommand request, CancellationToken cancellationToken)
            {
                var user = new UsersEntity();

                if (request.Id.HasValue)
                {
                    user = await _dbContext.Users
                        .Where(u => u.Id == request.Id)
                        .SingleOrDefaultAsync(cancellationToken);
                }
                else {

                    user.Id = Guid.NewGuid();
                    await _dbContext.AddAsync(user);
                }

                user.Name = request.Name;
                user.Address = request.Address;
                user.Birthdate = request.BirthDate;

                await _dbContext.SaveChangesAsync(cancellationToken);

                var users = await _dbContext.Users
                    .ProjectTo<GetUsersDTO>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return new CommandResponse() { UserList = users };
            }
        }
        public class InsertUserCommand : InsertUserDTO, IRequest<CommandResponse>
        { 
        }
        public class CommandResponse
        {
            public List<GetUsersDTO> UserList { get; set; }
        }
    }
}
