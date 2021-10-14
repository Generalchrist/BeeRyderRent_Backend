using Business.Abstract;
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

        public void Add(Color color) {
            _color.Add(color);
        }

        public void Delete(Color color) {
            _color.Delete(color);
        }

        public List<Color> GetAll() {
            return _color.GetAll();
        }

        public List<Color> GetByColorId(int Id) {
            return _color.GetAll(b => b.Id == Id);
        }

        public void Update(Color color) {
            _color.Update(color);
        }
    }
}
