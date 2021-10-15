using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Data;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete {
    public class ColorManager : IColorService {
        IColorDal _color;

        public ColorManager(IColorDal color) {
            _color = color;
        }

        public IResult Add(Color color) {
            _color.Add(color);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Color color) {
            _color.Delete(color);
            return new SuccessResult(Messages.CarDeleted);

        }

        public IDataResult<List<Color>> GetAll() {
            return new SuccessDataResult<List<Color>>(_color.GetAll(),Messages.CarsListed);
        }

        public IDataResult<List<Color>> GetByColorId(int Id) {
            return new SuccessDataResult<List<Color>>(_color.GetAll(b => b.Id == Id));
        }

        public IResult Update(Color color) {
            _color.Update(color);
            return new SuccessResult(Messages.CarUpdated);

        }
    }
}
