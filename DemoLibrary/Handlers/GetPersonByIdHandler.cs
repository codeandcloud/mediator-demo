using DemoLibrary.DataAccess;
using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Handlers
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, PersonModel>
    {
        private readonly IDataAccess _data;
        private readonly IMediator _mediator;

        public GetPersonByIdHandler(IDataAccess data, IMediator mediator)
        {
            _data = data;
            _mediator = mediator;
        }
        public async Task<PersonModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var results = await _mediator.Send(new GetPersonListQuery());
            var output = results.FirstOrDefault(x => x.Id == request.Id);
            return output;
        }
    }
}
