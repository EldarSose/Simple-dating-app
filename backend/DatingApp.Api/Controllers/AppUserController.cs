using DatingApp.Api.DTO;
using DatingApp.Api.Entity;
using DatingApp.Api.HelperCode;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;
using System.Security.Cryptography;
using System.Text;

namespace DatingApp.Api.Controllers
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class AppUserController : ControllerBase
	{
		private readonly ITokenService tokenService;
		private readonly SimpleDatingAppDBContext simpleDatingAppDBContext;

		public AppUserController(ITokenService tokenService,
			SimpleDatingAppDBContext simpleDatingAppDBContext) 
			
		{
			this.tokenService = tokenService;
			this.simpleDatingAppDBContext = simpleDatingAppDBContext;
		}
		[HttpPost]
		public async Task<ActionResult<AppUserDTO>> Register(RegisterDTO registerDTO)
		{
			if (await UserExists.CheckUserExists(registerDTO.username, simpleDatingAppDBContext))
				return BadRequest("Username is taken");

			using var hmac = new HMACSHA512();

			var user = new AppUser
			{
				username = registerDTO.username.ToLower(),
				passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.password)),
				passwordSalt = hmac.Key
			};

			simpleDatingAppDBContext.appUsers.Add(user);
			return new AppUserDTO
			{
				username = registerDTO.username,
				token = tokenService.createToken(user)
			};
		}
		[HttpPost]
		public async Task<ActionResult<AppUserDTO>> Login (LoginDTO loginDTO)
		{
			var user = await simpleDatingAppDBContext.appUsers.SingleOrDefaultAsync(x =>
			x.username == loginDTO.username);

			if (user == null)
				return Unauthorized("Invalid username or password");

			using var hmac = new HMACSHA512(user.passwordSalt);

			var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.password));

			for (int i = 0; i < computedHash.Length; i++)
			{
				if (computedHash[i] != user.passwordHash[i])
					return Unauthorized("Invalid username or password");
			}
			return new AppUserDTO
			{
				username = loginDTO.username,
				token = tokenService.createToken(user)
			};
		}
	}
}
