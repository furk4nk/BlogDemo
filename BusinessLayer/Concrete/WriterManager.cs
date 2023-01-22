﻿using BusinessLayer.Abstract;
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
	public class WriterManager : IWriterService
	{
		private readonly IWriterDal _writerDal;

		public WriterManager(IWriterDal writerDal)
		{
			_writerDal = writerDal;
		}

		public void TDelete(Writer t)
		{
			_writerDal.Delete(t);
		}

		public Writer TGetById(int ID)
		{
			return _writerDal.GetById(ID);
		}

		public List<Writer> TGetList()
		{
			return _writerDal.GetList();
		}

		public List<Writer> TGetList(Expression<Func<Writer, bool>> filter)
		{
			return _writerDal.GetList(filter);
		}

		public void TInsert(Writer t)
		{
			_writerDal.Insert(t);
		}

		public void TInsert(Writer t, string password)
		{
			_writerDal.Insert(t, password);
		}

		public void TUpdate(Writer t)
		{
			_writerDal.Update(t);
		}
	}
}
