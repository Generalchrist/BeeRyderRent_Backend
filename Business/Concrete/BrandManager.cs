using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete {
    public class BrandManager : IBrandService {

        IBrandDal _brand;

        public BrandManager(IBrandDal brand) {
            _brand = brand;
        }

        public void Add(Brand brand) {
            _brand.Add(brand);
        }

        public void Delete(Brand brand) {
            _brand.Delete(brand);
        }

        public List<Brand> GetAll() {
            return _brand.GetAll();
        }

        public List<Brand> GetByBrandId(int Id) {
            return _brand.GetAll(b=> b.Id==Id);
        }

        public void Update(Brand brand) {
            _brand.Update(brand);
        }
    }
}
