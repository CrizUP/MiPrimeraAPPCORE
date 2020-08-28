using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiPrimeraAPPCORE.DTO;
using MiPrimeraAPPCORE.Repository.IRepository;

namespace MiPrimeraAPPCORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Categoria : ControllerBase
    {
        private readonly ICategoriaRepository _CategoriaRepository;
        private readonly IMapper _Mapper;

        public Categoria(ICategoriaRepository CategoriaRepository, IMapper Mapper)
        {
            _CategoriaRepository = CategoriaRepository;
            _Mapper = Mapper;
        }

        [HttpGet]
        public ActionResult GetCategoria()
        {
            var LstCategorias = _CategoriaRepository.GetCategoria();
            var LstCategoriaDTO = new List<CategoriaDTO>();
            foreach (var lst in LstCategorias)
            {
                LstCategoriaDTO.Add(_Mapper.Map<CategoriaDTO>(lst));
            }
            return Ok(LstCategoriaDTO);
        }

        [HttpGet("{IdCategoria:int}", Name = "GetCategoria")]
        public ActionResult GetCategoria(int IdCategoria)
        {
            var itemCategoria = _CategoriaRepository.GetCategoria(IdCategoria);
            if (itemCategoria == null)
            {
                return NotFound();
            }
            var CategoriaDTO = _Mapper.Map<CategoriaDTO>(itemCategoria);
           
            return Ok(CategoriaDTO);
        }
        [HttpPost]
        public IActionResult CreateCategoria([FromBody] CategoriaDTO CategoriaDTO)
        {
            if (CategoriaDTO == null)
            {
                return BadRequest(ModelState);
            }
            else if (_CategoriaRepository.ExisteCategoria(CategoriaDTO.Nombre))
            {
                ModelState.AddModelError("", $"La categoria { CategoriaDTO.Nombre }, ya existe");
                return StatusCode(404, ModelState);
            }
            var Categoria = _Mapper.Map<Model.Categoria>(CategoriaDTO);
            int idCategoria = _CategoriaRepository.CreateCategoria(Categoria);
            if (idCategoria == 0)
            {
                ModelState.AddModelError("", $"La categoria { CategoriaDTO.Nombre }, no se pudo crear.");
                return StatusCode(500, ModelState);
            }
            return Ok(idCategoria);
        }

        [HttpPatch("{IdCategoria:int}", Name = "UpdateCategoria")]
        public IActionResult UpdateCategoria(int IdCategoria, [FromBody] CategoriaDTO CategoriaDTO)
        {
            if (CategoriaDTO == null)
            {
                return BadRequest(ModelState);
            }

            var Categoria = _Mapper.Map<Model.Categoria>(CategoriaDTO);

            var item = _CategoriaRepository.UpdateCategoria(Categoria);

            if (item == null)
            {
                ModelState.AddModelError("", $"La categoia no se puede actualizar");
                return StatusCode(500, ModelState);
            }

            return Ok(item);
        }

        [HttpDelete("{IdCategoria:int}", Name = "DeleteCategoria")]
        public IActionResult DeleteCategoria(int IdCategoria)
        {
            if (!_CategoriaRepository.ExisteCategoria(IdCategoria))
            {
                return NotFound();
            }

            if (!_CategoriaRepository.DeleteCategoria(IdCategoria))
            {
                ModelState.AddModelError("", $"La categoria no se pudó eliminar");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
