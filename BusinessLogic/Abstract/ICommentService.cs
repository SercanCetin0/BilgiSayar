using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetAll();
        Comment Get(int id);

        void Add(Comment comment);
        void Update(Comment comment);
        void Delete(Comment comment);
    }
}
