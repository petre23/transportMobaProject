using DataLayer.PersistanceLayer;
using DataLayer.Repository;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Logic
{
    public class BrandsBL
    {
        BrandRepository _brandRepository = new BrandRepository();

        public List<Brand> GetBrands()
        {
            return _brandRepository.GetBrands();
        }

        public Guid SaveBrand(Brand brand)
        {
            return _brandRepository.SaveBrand(brand);
        }
    }
}
