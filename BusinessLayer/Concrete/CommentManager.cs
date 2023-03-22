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

        public Task<Comment> TGetByIdAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<A> TGetByIdAsync<A>(int ID) where A : class
        {
            throw new NotImplementedException();
        }

        public Task<int> TGetCountAsync(Expression<Func<Comment, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<int> TGetCountAsync<A>(Expression<Func<A, bool>> filter) where A : class
        {
            throw new NotImplementedException();
        }

        public Task<List<Comment>> TGetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<A>> TGetListAsync<A>() where A : class
        {
            throw new NotImplementedException();
        }

        public Task<List<Comment>> TGetListAsync(Expression<Func<Comment, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<A>> TGetListAsync<A>(Expression<Func<A, bool>> filter) where A : class
        {
            throw new NotImplementedException();
        }

        public Task TInsertAsync(Comment t)
        {
            throw new NotImplementedException();
        }

        public Task TInsertAsync<A>(A model) where A : class
        {
            throw new NotImplementedException();
        }

        public Task TInsertRangeAsync(List<Comment> t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Comment t)
        {
            _commentDal.Delete(t);
        }

        public void TDeleteRange(List<Comment> t)
        {
            throw new NotImplementedException();
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

        public void TInsertRange(List<Comment> t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Comment t)
        {
            _commentDal.Update(t);
        }

        public void TUpdateRange(List<Comment> t)
        {
            throw new NotImplementedException();
        }
    }
}
