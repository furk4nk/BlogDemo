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
	public class DistrictManager : IDistrictService
	{
		IDistrictDal _districtDal;

		public DistrictManager(IDistrictDal districtDal)
		{
			_districtDal = districtDal;
		}

		public void TDelete(District t)
		{
			throw new NotImplementedException();
		}

		public District TGetById(int ID)
		{
			throw new NotImplementedException();
		}

		public List<District> TGetList()
		{
			return _districtDal.GetList();
		}

		public List<District> TGetList(Expression<Func<District, bool>> filter)
		{
			return _districtDal.GetList(filter);
		}

		public void TInsert(District t)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(District t)
		{
			throw new NotImplementedException();
		}
	}
}
