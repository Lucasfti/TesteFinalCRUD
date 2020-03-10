using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteFinalCRUD.Models;
using TesteFinalCRUD.ViewModel;

namespace TesteFinalCRUD.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoa
        public ActionResult Index()
        {
            using(var context = new CrudSemBDEntities())
            {
                var buscaPessoas = context.Pessoa.AsNoTracking().ToList();
                var pessoaViewModel = new List<PessoaViewModel>();

                if(buscaPessoas != null)
                {
                    foreach (var item in buscaPessoas)
                    {
                        pessoaViewModel.Add(new PessoaViewModel
                        {
                            nmPessoa = item.nmPessoa,
                            descricaoSexo = item.Sexo.descricaoSexo,
                            dtnascimento = item.dtnascimento.ToString("dd/MM/yyyy"),
                            pessoaCPF = item.pessoaCPF,
                            idPessoa = item.idPessoa,
                            idSexo = item.idSexo
                        });
                    }
                }

                return View(pessoaViewModel);
            }

        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int id)
        {
            var buscaPessoa = BuscaPessoaById(id);
            var pessoaViewModel = new PessoaViewModel();

            if(buscaPessoa != null)
            {
                pessoaViewModel.nmPessoa = buscaPessoa.nmPessoa;
                pessoaViewModel.dtnascimento = buscaPessoa.dtnascimento.ToString("dd/MM/yyyy");
                pessoaViewModel.pessoaCPF = buscaPessoa.pessoaCPF;
                pessoaViewModel.idPessoa = buscaPessoa.idPessoa;
                pessoaViewModel.descricaoSexo = buscaPessoa.Sexo.descricaoSexo;
            }

            return View(pessoaViewModel);
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {

            PreencherViewBag();

            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        public ActionResult Create(PessoaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using(var contexto = new CrudSemBDEntities())
                    {
                        contexto.Pessoa.Add(new Pessoa
                        {
                            nmPessoa = model.nmPessoa,
                            dtnascimento = Convert.ToDateTime(model.dtnascimento),
                            pessoaCPF = model.pessoaCPF,
                            idSexo = model.idSexo
                        });

                        contexto.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            var buscaPessoa = BuscaPessoaById(id);
            var pessoaViewModel = new PessoaViewModel();

            if(buscaPessoa != null)
            {
                pessoaViewModel.nmPessoa = buscaPessoa.nmPessoa;
                pessoaViewModel.dtnascimento = buscaPessoa.dtnascimento.ToString("dd/MM/yyyy");
                pessoaViewModel.idSexo = buscaPessoa.idSexo;
                pessoaViewModel.pessoaCPF = buscaPessoa.pessoaCPF;
                pessoaViewModel.idPessoa = buscaPessoa.idPessoa;
            }

            PreencherViewBag();

            return View(pessoaViewModel);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        public ActionResult Edit(PessoaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using(var context = new CrudSemBDEntities())
                    {
                        var buscaPessoa = context.Pessoa.Find(model.idPessoa);

                        if(buscaPessoa != null)
                        {
                            buscaPessoa.nmPessoa = model.nmPessoa;
                            buscaPessoa.dtnascimento = Convert.ToDateTime(model.dtnascimento);
                            buscaPessoa.pessoaCPF = model.pessoaCPF;
                            buscaPessoa.idSexo = model.idSexo;
                        }

                        context.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            var buscaPessoa = BuscaPessoaById(id);
            var pessoaViewModel = new PessoaViewModel();

            if(buscaPessoa != null)
            {
                pessoaViewModel.nmPessoa = buscaPessoa.nmPessoa;
                pessoaViewModel.descricaoSexo = buscaPessoa.Sexo.descricaoSexo;
                pessoaViewModel.dtnascimento = buscaPessoa.dtnascimento.ToString("dd/MM/yyyy");
                pessoaViewModel.pessoaCPF = buscaPessoa.pessoaCPF;
                pessoaViewModel.idPessoa = buscaPessoa.idPessoa;
            }

            return View(pessoaViewModel);
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        public ActionResult Delete(PessoaViewModel model)
        {
            try
            {
                using(var context = new CrudSemBDEntities())
                {
                    var buscaPessoa = context.Pessoa.Find(model.idPessoa);

                    if(buscaPessoa != null)
                    {
                        context.Pessoa.Remove(buscaPessoa);
                        context.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        public Pessoa BuscaPessoaById(int id)
        {
            using(var context = new CrudSemBDEntities())
            {
                var buscaPessoa = context.Pessoa.Include("Sexo").AsNoTracking().FirstOrDefault(x => x.idPessoa == id);

                if (buscaPessoa != null)
                {
                    return buscaPessoa;
                }
                else
                {
                    return null;
                }
            }
        }
        public void PreencherViewBag()
        {
            using(var context = new CrudSemBDEntities())
            {
                var buscaSexos = context.Sexo.AsNoTracking().ToList();

                if(buscaSexos != null)
                {
                    ViewBag.listaSexo = buscaSexos;
                }
            }
        }
    }
}
