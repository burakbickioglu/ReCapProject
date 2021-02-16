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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        
        public IResult Add(Customer Item)
        {
            _customerDal.Add(Item);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Customer Item)
        {
            _customerDal.Delete(Item);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(Customer Item)
        {
            _customerDal.Update(Item);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>((_customerDal.GetAll()), Messages.Listed);
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(x => x.CustomerId == id), Messages.Listed);
        }
    }
}
