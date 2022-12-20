using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;


namespace Api.Extensions
{
    public class AutorizacaoCustomizada
    {
        public static bool ValidarUsuario(HttpContext context, string ClaimNome, string ClamValor)
        {
            return context.User.Identity.IsAuthenticated &&
                context.User.Claims.Any(x => x.Type == ClaimNome && x.Value == ClamValor);
        }
    }
    public class AutorizacaoClaimAttribute : TypeFilterAttribute
    {
        public AutorizacaoClaimAttribute(string Nome, String Valor) : base(typeof(RequisitoClaimFiltro))
        {
            Arguments = new object[] { new Claim(Nome,Valor)  };
        }
    }
    public class RequisitoClaimFiltro : IAuthorizationFilter
    {
        private readonly Claim _Claim;
        public RequisitoClaimFiltro(Claim claim)
        {
            _Claim = claim;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            if(!AutorizacaoCustomizada.ValidarUsuario(context.HttpContext, _Claim.Type,_Claim.Value))
            {

                context.Result = new StatusCodeResult(403);
                return;


            }

        }
    }




}
