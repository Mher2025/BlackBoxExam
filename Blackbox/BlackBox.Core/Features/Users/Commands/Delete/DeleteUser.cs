using AutoMapper;
using BlackBox.Domain.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBox.Core.Features.Users.Commands.Delete
{
    public class DeleteUser
    {
        public class CommandHandler : IRequestHandler<DeleteUserCommand, CommandResponse>
        {
            private readonly ApplicationDbContext _dbContext;
            private readonly IMapper _mapper;
            public CommandHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
            {
                _dbContext = applicationDbContext;
                _mapper = mapper;
            }

            public async Task<CommandResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _dbContext.Users.Where(u => u.Id == request.Id).SingleOrDefaultAsync(cancellationToken);
               
                _dbContext.Remove(user);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return new CommandResponse();
            }
        }
        public class DeleteUserCommand : IRequest<CommandResponse>
        {
            public Guid Id { get; set; }
        }
        public class CommandResponse
        { 
        }
    }
}
