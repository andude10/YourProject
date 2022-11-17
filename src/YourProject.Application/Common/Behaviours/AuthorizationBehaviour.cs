using System.Reflection;
using MediatR;
using YourProject.Application.Common.Exceptions;
using YourProject.Application.Common.Interfaces;
using YourProject.Application.Common.Security;

namespace YourProject.Application.Common.Behaviours;

public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IIdentityService _identityService;

    public AuthorizationBehaviour(
        ICurrentUserService currentUserService,
        IIdentityService identityService)
    {
        _currentUserService = currentUserService;
        _identityService = identityService;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>().ToList();

        if (!authorizeAttributes.Any()) return await next();

        // Must be authenticated user
        if (_currentUserService.UserId is null) throw new UnauthorizedAccessException();

        var authorizeAttributesWithRoles = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Roles)).ToList();
        if (authorizeAttributesWithRoles.Any()) await ProcessRoleBasedAuthorization(authorizeAttributesWithRoles);

        var authorizeAttributesWithPolicies =
            authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Policy)).ToList();
        if (authorizeAttributesWithPolicies.Any())
            await ProcessPolicyBasedAuthorization(authorizeAttributesWithPolicies);

        // User is authorized / authorization not required
        return await next();
    }

    private async Task ProcessPolicyBasedAuthorization(List<AuthorizeAttribute> authorizeAttributesWithPolicies)
    {
        if (_currentUserService.UserId is not { } userId)
            return;

        foreach (var policy in authorizeAttributesWithPolicies.Select(a => a.Policy))
        {
            var authorized = await _identityService.AuthorizeAsync(userId, policy);

            if (!authorized) throw new ForbiddenAccessException();
        }
    }

    private async Task ProcessRoleBasedAuthorization(List<AuthorizeAttribute> authorizeAttributesWithRoles)
    {
        var authorized = false;

        if (_currentUserService.UserId is not { } userId)
            return;

        foreach (var roles in authorizeAttributesWithRoles.Select(a => a.Roles.Split(',')))
        foreach (var role in roles)
        {
            var isInRole = await _identityService.IsInRoleAsync(userId, role.Trim());

            if (!isInRole) continue;

            authorized = true;
            break;
        }

        // Must be a member of at least one role in roles
        if (!authorized) throw new ForbiddenAccessException();
    }
}