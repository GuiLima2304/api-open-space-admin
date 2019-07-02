using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Estagio.OpenSpaceAdmin.Models;
using Estagio.OpenSpaceAdmin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenSpaceAdmin.ViewModels.Base;

namespace Estagio.OpenSpaceAdmin.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ApresentacaoController : Controller
  {
    private readonly OPENSPACEContext _context;
    private readonly IMapper _mapper;

    public ApresentacaoController(OPENSPACEContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    [HttpGet]
    [Route("aprovadas")]
    public async Task<IActionResult> GetAprovadas()
    {
      List<Apresentacao> apresentacoesAprovadas = await _context.Apresentacao.Include(p=>p.Usuario).Where(p=> p.Aprovado ).ToListAsync();
      List<ApresentacaoModel> apresentacoes = apresentacoesAprovadas.Select(_mapper.Map<ApresentacaoModel>).ToList();
      return Ok(new GenericResponse<List<ApresentacaoModel>>(apresentacoes));
    }

    [HttpGet]
    [Route("reprovadas")]
    public async Task<IActionResult> GetReprovadas()
    {
      List<Apresentacao> apresentacoesAprovadas = await _context.Apresentacao.Include(p=>p.Usuario).Where(p=> !p.Aprovado ).ToListAsync();
      List<ApresentacaoModel> apresentacoes = apresentacoesAprovadas.Select(_mapper.Map<ApresentacaoModel>).ToList();
      return Ok(new GenericResponse<List<ApresentacaoModel>>(apresentacoes));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromBody] AprovacaoViewModel model, int id){
      var apr = await _context.Apresentacao.FirstOrDefaultAsync(ap => ap.Id == id);
      
      if (model.Aprovado)
      {
        if(model.Data < DateTime.Now)
          return BadRequest();
        apr.DataApresentacao = model.Data;
      }
      else
      {
        if(model.MotivoReprovacao==String.Empty)
          return BadRequest();
        apr.MotivoReprovacao = model.MotivoReprovacao;
      }

      apr.Aprovado = model.Aprovado;
      await _context.SaveChangesAsync();
      return Created("", new GenericResponse<Apresentacao>(apr));
    }
    
  }
}