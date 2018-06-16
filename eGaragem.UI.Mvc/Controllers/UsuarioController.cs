using eGaragem.UI.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace eGaragem.UI.Mvc.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Locador
        public ActionResult Index()
        {
            return View();
        }

        [Route("incluir-novo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                //TODO
                //usuarioViewModel = inserir
                return RedirectToAction("Index");
                
            }
            return View(usuarioViewModel);
        }

        [Route("editar/{id:guid}")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TODO - buscar na base o usuario
            UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
            if (usuarioViewModel == null)
            {
                return HttpNotFound();
            }

            ViewBag.UsuarioId = id;
            return View(usuarioViewModel);
        }

        [Route("editar/{id:guid}")]
        public ActionResult Edit(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                //TODO - atualizar com objeto
                return RedirectToAction("Index");
            }
            return View(usuarioViewModel);
        }

        [Route("excluir/{id:guid}")]
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TODO - buscar o usuario no banco usando o ID
            UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
            if (usuarioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(usuarioViewModel);
        }

        [Route("excluir/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            //TODO exlcuir 
            return RedirectToAction("Index");
        }
    }
}