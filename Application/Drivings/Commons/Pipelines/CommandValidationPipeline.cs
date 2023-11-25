using Application.Drivings.Commons.Models.Requests;
using MediatR;

namespace Application.Drivings.Commons.Pipelines;

public record CommandValidationPipeline<TCommand, TBody, TRes> : IPipelineBehavior<TCommand, TRes> 
    where TCommand : IBaseRequest, ICommandRequest<TBody>
    where TBody : notnull
{
    public Task<TRes> Handle(TCommand request, RequestHandlerDelegate<TRes> next, CancellationToken stopToken)
    {
        // TODO
        return next();
    }
}