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

namespace BlackBox.Core.Features.Users.Commands.Update
{
    public class UpdateUser
    {
        public class CommandHandler : IRequestHandler<UpdateUserCommand, CommandResponse>
        {
            private readonly ApplicationDbContext _dbContext;
            private readonly IMapper _mapper;
            public CommandHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
            {
                _dbContext = applicationDbContext;
                _mapper = mapper;
            }

            public async Task<CommandResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var user = new UsersEntity();

                if (request.Id.HasValue)
                {
                    user = await _dbContext.Users.Where(u => u.Id == request.Id).SingleOrDefaultAsync(cancellationToken);
                    user.Birthdate = request.BirthDate;
                    user.Address = request.Address;
                    user.Name = request.Name;
                }
                else 
                {
                   // throw exception
                }

                await _dbContext.SaveChangesAsync(cancellationToken);

                var users = await _dbContext.Users
                   .ProjectTo<GetUsersDTO>(_mapper.ConfigurationProvider)
                   .ToListAsync(cancellationToken);

                return new CommandResponse();
            }
        }
        public class UpdateUserCommand : InsertUserDTO, IRequest<CommandResponse>
        { 
        }
        public class CommandResponse
        { 
             
        }
    }
}
