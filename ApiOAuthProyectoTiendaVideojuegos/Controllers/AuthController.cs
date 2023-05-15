using ApiOAuthProyectoTiendaVideojuegos.Helpers;
using ApiOAuthProyectoTiendaVideojuegos.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NugetProyectoTinedaVideojuegosAzure;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ApiOAuthProyectoTiendaVideojuegos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private HelperOAuthToken helper;
        private RepositoryProductos repo;
        public AuthController(HelperOAuthToken helper, RepositoryProductos repo)
        {
            this.helper = helper;
            this.repo = repo;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Login(LoginModel model)
        {
            Cliente usuario =
                await this.repo.ExisteCliente(model.UserName, model.Password);

            if (usuario == null)
            {
                return Unauthorized();
            }
            else
            {
                SigningCredentials credentials =
                    new SigningCredentials(this.helper.GetKeyToken(), SecurityAlgorithms.HmacSha256);
                //GENERACION DEL JWT TOKEN CON SUS CORRESPONDIENTES DATOS
                string jsonCubo = JsonConvert.SerializeObject(usuario);
                Claim[] informacion = new[]
                {
                    new Claim("UserData", jsonCubo)
                };

                JwtSecurityToken token =
                    new JwtSecurityToken(
                        claims: informacion,
                        issuer: this.helper.Issuer,
                        audience: this.helper.Audience,
                        signingCredentials: credentials,
                        expires: DateTime.UtcNow.AddMinutes(15),
                        notBefore: DateTime.UtcNow
                        );
                return Ok(new
                {
                    response =
                    new JwtSecurityTokenHandler().WriteToken(token)
                });


            }
        }

        [HttpPost]
        [Route("[action]/{nombre}/{apellidos}/{email}/{password}")]
        public async Task<ActionResult<Cliente>> Register(string nombre, string apellidos, string email, string password)
        {
            await this.repo.RegisterUsuario(nombre,apellidos,email,password);
            return Ok();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<Cliente>> PerfilUsuario()
        {
            Claim claim = HttpContext.User.Claims
                .SingleOrDefault(x => x.Type == "UserData");
            string jsonUsuario =
                claim.Value;
            Cliente usuario = JsonConvert.DeserializeObject<Cliente>
                (jsonUsuario);
            return usuario;
        }
    }
}
