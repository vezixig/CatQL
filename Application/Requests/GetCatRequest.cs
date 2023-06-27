namespace CatQL.Application.Requests
{
    using Core.Models;
    using MediatR;

    public class GetCatRequest : IRequest<Cat>
    {
        public GetCatRequest(int id)
            => Id = id;

        public int Id { get; set; }
    }
}