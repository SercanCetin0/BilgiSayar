﻿using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Ninject.Modules;

namespace Bilgi_SayarUI.Areas.Admin.DependencyResolvers.Ninject
{
    public class AdminModule:NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
           
           
            Bind<IEntryService>().To<EntryManager>().InSingletonScope();
            Bind<IWriterService>().To<WriterManager>().InSingletonScope();

            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();
           
            Bind<IWriterDal>().To<EfWriterDal>().InSingletonScope();
            Bind<IEntryDal>().To<EfEntryDal>().InSingletonScope();
            

        }
    }
}
