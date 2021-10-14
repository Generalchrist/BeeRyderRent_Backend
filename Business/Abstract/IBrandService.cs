using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract {
    public interface IBrandService {
        public List<Brand> GetAll();
        public List<Brand> GetByBrandId(int Id);
        void Add(Brand brand);
        void Update(Brand brand);
        void Delete(Brand brand);
    }
}
