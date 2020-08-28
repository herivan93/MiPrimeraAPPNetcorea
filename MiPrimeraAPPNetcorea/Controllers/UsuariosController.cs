﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MiPrimeraAPPNetcorea.DTO;
using MiPrimeraAPPNetcorea.Model;
using MiPrimeraAPPNetcorea.Repository.IRepository;

namespace MiPrimeraAPPNetcorea.Controllers
{
    [Route("api/Usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IMapper _mapper;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _config;

        public UsuariosController(IUsuarioRepository UsuarioRepo,IMapper mapper, IConfiguration config)
        {
            _usuarioRepo = UsuarioRepo;
            _mapper = mapper;
            _config = config;

        }

        [Authorize]
        [HttpGet]
        public ActionResult GetUsuarios()
        {
            var LstUsuario = _usuarioRepo.GetUsuarios();
            var LstUsuarioDTO = new List<UsuarioDTO>();

            foreach(var list in LstUsuario)
            {
                LstUsuarioDTO.Add(_mapper.Map<UsuarioDTO>(list));
            }

            return Ok(LstUsuarioDTO);
        }

        [Authorize]
        [HttpGet("{IdUsuario:int}", Name ="GetUsuario")]
        public ActionResult GetUsuario(int IdUsuario)
        {
            var Usuario = _usuarioRepo.GetUsuario(IdUsuario);
            

            if(Usuario == null)
            {
                return NotFound();

            }

            var usuarioItemDTO = _mapper.Map<UsuarioDTO>(Usuario);

            return Ok(usuarioItemDTO);
        }

        [HttpPost("Registrar")]
        public ActionResult Registrar(UsuarioAuthDTO DatosRegistro)
        {
            if (_usuarioRepo.ExisteUsuario(DatosRegistro.ClientId.ToLower()))
            {
                return BadRequest("El nombre de usuario" + DatosRegistro.ClientId + " no esta disponible.");
            }

            var CreUsuario = new Usuario
            {
                ClientId = DatosRegistro.ClientId
            };

            var result = _usuarioRepo.Registrar(CreUsuario, DatosRegistro.Password);

            return Ok(result);
        }
        
        [HttpPost("Login")]
        public ActionResult Login(UsuarioAuthLoginDTO DatosRegistro)
        {
            var usuarioCredencial = _usuarioRepo.Login(DatosRegistro.ClientId, DatosRegistro.Password);

            if(usuarioCredencial == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,usuarioCredencial.ClientId.ToString()),
                new Claim(ClaimTypes.Name, usuarioCredencial.ClientId)
                
            };

            //Secret para generar token

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:TokenKey").Value));
            var credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var DescriptorToken = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credencial
            };

            var tokenHandle = new JwtSecurityTokenHandler();
            var token = tokenHandle.CreateToken(DescriptorToken);

            return Ok(new
            {
                token = tokenHandle.WriteToken(token)
            });

        }

        


    }
}
