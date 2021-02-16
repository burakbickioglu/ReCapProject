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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color Item)
        {
            _colorDal.Add(Item);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Color Item)
        {
            _colorDal.Delete(Item);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(Color Item)
        {
            _colorDal.Update(Item);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>((_colorDal.GetAll()), Messages.Listed);
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(x => x.ColorId == id), Messages.Listed);
        }
    }
}
