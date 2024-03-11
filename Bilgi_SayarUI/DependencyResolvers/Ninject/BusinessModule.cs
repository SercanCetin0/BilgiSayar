using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Ninject;
using Ninject.Modules;

namespace Bilgi_SayarUI.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {

        
        public override void Load()
        {
            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICommentService>().To<CommentManager>().InSingletonScope();
            Bind<IContentImageService>().To<ContentImageManager>().InSingletonScope();
            Bind<IEntryService>().To<EntryManager>().InSingletonScope();
            Bind<IWriterService>().To<WriterManager>().InSingletonScope();

            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();
            Bind<ICommentDal>().To<EfCommentDal>().InSingletonScope();
            Bind<IWriterDal>().To<EfWriterDal>().InSingletonScope();
            Bind<IEntryDal>().To<EfEntryDal>().InSingletonScope();
            Bind<IContentImageDal>().To<EfContentImageDal>().InSingletonScope();

        }

    }
}
