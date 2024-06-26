﻿using ApplicationCore.Domain.Entity;
using Applications.CQRS.Command.Create;
using Applications.CQRS.Command.Delete;
using Applications.CQRS.Command.Update;
using Applications.CQRS.Queries.GetAll;
using Applications.CQRS.Queries.GetById;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Extentions.MediatRHandler
{
    public class MediatRHandler
    {
        public static void MediatrRegisterHandler<TDomain, TDto, TReq>(IServiceCollection services)
           where TDomain : Entity<Guid>
           where TDto : class
           where TReq : class
        {
            services.AddTransient(
                typeof(IRequestHandler<GetAllQuery<TDomain, TDto>, IEnumerable<TDto>>),
                typeof(GetAllQueryHandler<TDomain, TDto>)
            );
            services.AddTransient(
               typeof(IRequestHandler<GetByIdQuery<TDomain, TDto>, TDto>),
               typeof(GetByIdQueryHandler<TDomain, TDto>)
           );

            services.AddTransient(
                typeof(IRequestHandler<CreateCommand<TDomain, TReq>>),
                typeof(CreateCommandHandler<TDomain, TReq>)
            );
            services.AddTransient(
                typeof(IRequestHandler<UpdateCommand<TDomain, TReq>>),
                typeof(UpdateCommandHandler<TDomain, TReq>)
            );
            services.AddTransient(
                typeof(IRequestHandler<DeleteCommand<TDomain>>),
                typeof(DeleteCommandHandler<TDomain>)
            );
        }
    }
}
