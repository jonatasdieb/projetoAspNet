using WebApi.Services;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using System.Collections.Generic;

namespace WebApi
{
    public class ProviderDeTokensDeAcesso : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }


        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }



        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (UserService.Login(context.UserName, context.Password))
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);                

                var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                        "username", context.UserName
                    }
                });

                var ticket = new AuthenticationTicket(identity, props);
                
                context.Validated(ticket);
            }
            else
            {
                context.SetError("Acesso inválido", "As credenciais do usuário não conferem...");
                return;
            }
        }
    }
}