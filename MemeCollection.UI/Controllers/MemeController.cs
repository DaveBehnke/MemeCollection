using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MemeCollection.Domain.Abstract;
using MemeCollection.Domain.Entities;

namespace MemeCollection.UI.Controllers
{
    public class MemeController : Controller
    {
        private IMemeRepository repository;

        private int SortMethod;

        public MemeController(IMemeRepository memeRepository)
        {
            this.repository = memeRepository;
            this.SortMethod = 1;
        }

        public ViewResult List(int method = 0)
        {
            if (method > 0)
                SortMethod = method;

            if (SortMethod == 1)
            {
                return View(repository.Memes.OrderBy(m => m.MemeID));
            }
            else
            {
                return View(repository.Memes.OrderBy(m => m.Genre));
            }
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meme/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemeID,Title,ImageURI,Description,Genre")] Meme meme)
        {
            if (ModelState.IsValid)
            {
                repository.Add(meme);
                return RedirectToAction("List");
            }

            return View(meme);
        }

        // GET: Meme/Delete/5
        public ActionResult Delete(int memeID)
        {
            Meme meme = repository.Find(memeID);
            if (meme == null)
            {
                return HttpNotFound();
            }
            return View(meme);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int memeID)
        {
            Meme meme = repository.Find(memeID);
            repository.Delete(meme);
            return RedirectToAction("List");
        }

    }
}