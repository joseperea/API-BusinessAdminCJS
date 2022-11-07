using API_BusinessAdminCJS.Data.Entities;
using API_BusinessAdminCJS.ModelsView;
using API_BusinessAdminCJS.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API_BusinessAdminCJS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;        
        private readonly IAuthManager _authManager; 


        public AccountController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, ILogger<AccountController> logger, IMapper mapper, IAuthManager authManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager; 
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] UsuarioDTO usuarioDTO) 
        {
            _logger.LogInformation($"Intento de registro de {usuarioDTO.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var usuario = _mapper.Map<Usuario>(usuarioDTO);
                usuario.UserName = usuarioDTO.Email;
                var result = await _userManager.CreateAsync(usuario, usuarioDTO.Password);

                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                    return BadRequest(ModelState);
                }
                await _userManager.AddToRolesAsync(usuario, usuarioDTO.Roles);

                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ocurrio un error al momento de {nameof(Register)}");
                return Problem($"Ocurrio un error al momento de {nameof(Register)}", statusCode: 500);
                //return StatusCode(500, "Error interno del servidor, inténtalo de nuevo más tarde.");
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUserDTO)
        {
            _logger.LogInformation($"Intento de inicio de sesion de {loginUserDTO.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                //var result = await _signInManager.PasswordSignInAsync(loginUserDTO.Email, loginUserDTO.Password, false, false);

                if (! await _authManager.ValidateUser(loginUserDTO))
                {
                    return Unauthorized(loginUserDTO);
                }

                return Accepted( new {  Token = await _authManager.CreateToken()});
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ocurrio un error al momento de {nameof(Login)}");
                return Problem($"Ocurrio un error al momento de {nameof(Login)}", statusCode: 500);
                //return StatusCode(500, "Error interno del servidor, inténtalo de nuevo más tarde.");
            }
        }
    }
}
