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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User Item)
        {
            _userDal.Add(Item);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(User Item)
        {
            _userDal.Delete(Item);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(User Item)
        {
            _userDal.Update(Item);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>((_userDal.GetAll()), Messages.Listed);
        }

        public IDataResult<User> Get(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(x => x.UserId== id), Messages.Listed);
        }
    }
}
