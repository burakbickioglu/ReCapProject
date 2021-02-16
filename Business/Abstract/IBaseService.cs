using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBaseService<T>
    {
        IResult Add(T Item);
        IResult Delete(T Item);
        IResult Update(T Item);
        IDataResult<List<T>> GetAll();
        IDataResult<T> GetById(int id);
    }
}
