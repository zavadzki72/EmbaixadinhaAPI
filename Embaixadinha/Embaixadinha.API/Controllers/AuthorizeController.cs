﻿using Embaixadinha.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Embaixadinha.API.Controllers
{
    [ApiController]
    [Route("authorize")]
    public class AuthorizeController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;

        public AuthorizeController(IConfiguration configuration, ITokenService tokenService)
        {
            _configuration = configuration;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("client-credential")]
        [AllowAnonymous]
        public IActionResult Authorize([FromForm] string clientCredential)
        {
            if (!Guid.TryParse(clientCredential, out var secretGuid))
            {
                return Unauthorized("Invalid client credential");
            }

            var secretTrueGuid = Guid.Parse(_configuration["AUTH_CLIENT_CREDENTIAL"] ?? "");

            if (secretGuid != secretTrueGuid)
                return Unauthorized("Invalid client credential");

            var token = _tokenService.GenerateToken();
            return Ok(token);
        }
    }
}
