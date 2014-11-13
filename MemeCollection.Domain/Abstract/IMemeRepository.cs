using System;
using System.Collections.Generic;
using MemeCollection.Domain.Entities;

namespace MemeCollection.Domain.Abstract
{
    public interface IMemeRepository
    {
        IEnumerable<Meme> Memes { get; }
        void Add(Meme meme);
        void Delete(Meme meme);
        Meme Find(int memeID);
    }
}
