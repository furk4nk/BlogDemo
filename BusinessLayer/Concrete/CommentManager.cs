using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void TDelete(Comment t)
        {
            _commentDal.Delete(t);
        }

        public Comment TGetById(int ID)
        {
            return _commentDal.GetById(ID);
        }

        public int TGetCount(Expression<Func<Comment, bool>> filter = null)
        {
            return _commentDal.GetCount(filter);
        }

        public List<Comment> TGetList()
        {
            return _commentDal.GetList();
        }

		public List<Comment> TGetList(Expression<Func<Comment, bool>> filter)
		{
			return _commentDal.GetList(filter);
		}

		public void TInsert(Comment t)
        {
            _commentDal.Insert(t);
        }

        public void TUpdate(Comment t)
        {
            _commentDal.Update(t);
        }
    }
}
