using ApiCandidatos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ApiCandidatos.Controllers
{
    public class CandidatosController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetTodosCandidatos(bool incluirEndereco = false)
        {
            IList<Candidatos> candidatos = null;

            using (var ctx = new AppDbContext())
            {
                candidatos = ctx.Candidatos.Include("Endereco").ToList()
                            .Select(s => new Candidatos()
                            {
                                CandidatoId = s.CandidatoId,
                                Nome = s.Nome,
                                Email = s.Email,
                                Telefone = s.Telefone,
                                Vaga = s.Vaga,
                                Endereco = s.Endereco == null || incluirEndereco == false ? null : new Endereco()
                                {
                                    EnderecoId = s.Endereco.EnderecoId,
                                    Local = s.Endereco.Local,
                                    Cidade = s.Endereco.Cidade,
                                    Estado = s.Endereco.Estado
                                }
                            }).ToList();
            }

            if (candidatos.Count == 0)
            {
                return NotFound();
            }
            return Ok(candidatos);
        }
        public IHttpActionResult PostNovoCandidato(CandidatoEnderecoDTO candidato)
        {
            if (!ModelState.IsValid || candidato == null)
                return BadRequest("Dados do candidatos inválidos.");

            using (var ctx = new AppDbContext())
            {
                ctx.Candidatos.Add(new Candidatos()
                {
                    Nome = candidato.Nome,
                    Email = candidato.Email,
                    Telefone = candidato.Telefone,
                    Vaga = candidato.Vaga,
                    Endereco = new Endereco()
                    {
                        Local = candidato.Local,
                        Cidade = candidato.Cidade,
                        Estado = candidato.Estado
                    }
                });

                ctx.SaveChanges();
            }
            return Ok(candidato);
        }
        public IHttpActionResult Put(Candidatos Candidato)
        {
            if (!ModelState.IsValid || Candidato == null)
                return BadRequest("Dados do candidato inválidos");

            using (var ctx = new AppDbContext())
            {
                var CandidatoSelecionado = ctx.Candidatos.Where(c => c.CandidatoId == Candidato.CandidatoId).FirstOrDefault<Candidatos>();

                if (CandidatoSelecionado != null)
                {
                    CandidatoSelecionado.Nome = Candidato.Nome;
                    CandidatoSelecionado.Email = Candidato.Email;
                    CandidatoSelecionado.Telefone = Candidato.Telefone;
                    CandidatoSelecionado.Vaga = Candidato.Vaga;

                    ctx.Entry(CandidatoSelecionado).State = System.Data.Entity.EntityState.Modified;

                    var enderecoSelecionado = ctx.Enderecos.Where(e =>
                                                  e.EnderecoId == CandidatoSelecionado.Endereco.EnderecoId).FirstOrDefault<Endereco>();

                    if (enderecoSelecionado != null)
                    {
                        enderecoSelecionado.Local = Candidato.Endereco.Local;
                        enderecoSelecionado.Cidade = Candidato.Endereco.Cidade;
                        enderecoSelecionado.Estado = Candidato.Endereco.Estado;

                        ctx.Entry(enderecoSelecionado).State = System.Data.Entity.EntityState.Modified;
                    }

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok($"Candidato {Candidato.Nome} atualizado com sucesso");
        }
        public IHttpActionResult Delete(int? id, Candidatos Candidato)
        {
            if (id == null)
                return BadRequest("Dados inválidos");

            using (var ctx = new AppDbContext())
            {
                var candidatoSelecionado2 = ctx.Candidatos.Where(c => c.CandidatoId == id)
                                                           .FirstOrDefault<Candidatos>();

                if (candidatoSelecionado2 != null)
                {
                    Candidato.Nome = candidatoSelecionado2.Nome;

                    ctx.Entry(candidatoSelecionado2).State = System.Data.Entity.EntityState.Deleted;
                    

                    var enderecoSelecionado = ctx.Enderecos.Where(e =>
                                             e.EnderecoId == candidatoSelecionado2.EnderecoId)
                                             .FirstOrDefault<Endereco>();

                    if (enderecoSelecionado != null)
                    {
                        ctx.Entry(enderecoSelecionado).State = System.Data.Entity.EntityState.Deleted;
                    }
                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok($"Contato {Candidato.Nome} foi deletado com sucesso");
        }
    }
}

