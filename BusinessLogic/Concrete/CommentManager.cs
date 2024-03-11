using BusinessLogic.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void Add(Comment comment)
        {
            _commentDal.Add(comment);   
        }

        public void Delete(Comment comment)
        {
            _commentDal.Delete(comment);
        }

        public Comment Get(int id)
        {
            return _commentDal.Get(x=>x.CommentId.Equals(id));
        }

        public List<Comment> GetAll()
        {
            return _commentDal.GetAll();
        }

        public void Update(Comment comment)
        {
            _commentDal.Update(comment);
        }
    }
}
