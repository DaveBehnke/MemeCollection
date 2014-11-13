using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Ninject;
using MemeCollection.Domain.Abstract;
using MemeCollection.Domain.Concrete;
using MemeCollection.Domain.Entities;

namespace MemeCollection.UI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam) 
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
/*            Mock<IMemeRepository> mock = new Mock<IMemeRepository>();
            mock.Setup(m => m.Memes).Returns(new List<Meme>
            {
                new Meme { MemeID = 1, Title = "Running Dog", ImageURI = new Uri("http://animalia-life.com/data_images/dog/dog1.jpg"), Description = "A cute fluffy white dog in mid stride", Genre = "Dogs"},
                new Meme { MemeID = 2, Title = "Triple Dog", ImageURI = new Uri("http://animalia-life.com/data_images/dog/dog6.jpg"), Description = "Three golden siblings with tongues out", Genre = "Dogs"}
            });

            kernel.Bind<IMemeRepository>().ToConstant(mock.Object);
 */
            kernel.Bind<IMemeRepository>().To<EFMemeRepository>();
        }
    }
}