using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand Item)
        {
            _brandDal.Add(Item);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Brand Item)
        {
            _brandDal.Delete(Item);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(Brand Item)
        {
            _brandDal.Update(Item);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>((_brandDal.GetAll()), Messages.Listed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(x => x.BrandId == id), Messages.Listed);
        }
    }
}
