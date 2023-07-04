namespace CatQL.Application.Data.Cat;

using Core.Models;
using MediatR;

public class GetCatsRequest : IRequest<List<Cat>>
{
}