using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental Item)
        {
            var results = _rentalDal.GetAll(x => x.CarId == Item.CarId);
            foreach (var result in results)
            {
                if (result.ReturnDate == null || result.RentDate > result.ReturnDate)
                {
                    return new ErrorResult(Messages.RentalAddedError);
                }
            }

            _rentalDal.Add(Item);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Rental Item)
        {
            _rentalDal.Delete(Item);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(Rental Item)
        {
            _rentalDal.Update(Item);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Rental> Get(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.RentalId==id),Messages.Listed);
        }

        
    }
}
