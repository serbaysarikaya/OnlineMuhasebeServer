using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany
{
    public sealed record CreateCompanyCommand(string Name,
        string ServerName,
        string DataBaseName,
        string UserId,
        string Password) : ICommand<CreateCompanyCommandResponse>;
}
