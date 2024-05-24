using ErrorOr;
using MediatR;
using Application.Common.Interfaces;

namespace Application.Common.Behaviors;

public sealed class UnitOfWorkBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
{
    private readonly IApplicationDbContext _context;

    public UnitOfWorkBehavior(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (IsNotCommand())
            return await next();

        var result = await next();

        await _context.SaveChangesAsync(cancellationToken);

        return result;
    }

    private static bool IsNotCommand()
    {
        return !typeof(TRequest).Name.EndsWith("Command");
    }
}
