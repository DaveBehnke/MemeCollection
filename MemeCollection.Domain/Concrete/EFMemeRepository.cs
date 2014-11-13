using MemeCollection.Domain.Abstract;
using MemeCollection.Domain.Entities;
using System.Collections.Generic;

namespace MemeCollection.Domain.Concrete
{
    public class EFMemeRepository : IMemeRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Meme> Memes
        {
            get { return context.Memes;  }
        }

        public void Add(Meme meme)
        {
            meme.MemeID = 0;
            context.Memes.Add(meme);
            context.SaveChanges();
        }

        public void Delete(Meme meme)
        {
            context.Memes.Remove(meme);
            context.SaveChanges();
        }

        public Meme Find(int memeID)
        {
            return context.Memes.Find(memeID);
        }
    }
}
