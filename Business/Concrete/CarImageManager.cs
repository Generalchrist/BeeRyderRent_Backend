using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Results.Data;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Helpers;

namespace Business.Concrete {
    public class CarImageManager : ICarImageService {

        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal) {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, int carImageId) {

            var carImage = new CarImage(){
                CarId = carImageId
            };

            var imageResult = FileHelper.Upload(file);
            if (!imageResult.Success) {
                carImage.ImageDate = DateTime.Now;
                return new ErrorResult(imageResult.Message);

            }

            carImage.ImagePath = imageResult.Message;

            _carImageDal.Add(carImage);

            return new SuccessResult(carImage.CarImageId.ToString());

        }

        public IResult Delete(CarImage carImage) {

            var image = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
            if (image == null) {

                return new ErrorResult();

            }

            FileHelper.Delete(image.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll() {
            var images = _carImageDal.GetAll();

            return new SuccessDataResult<List<CarImage>>(images, Messages.CarsListed);

        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage) {
            var isImage = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
            if (isImage == null) {
                return new ErrorResult("Image not found");
            }

            var updatedFile = FileHelper.Update(file, isImage.ImagePath);
            if (!updatedFile.Success) {
                return new ErrorResult(updatedFile.Message);
            }
            carImage.ImagePath = updatedFile.Message;
            _carImageDal.Update(carImage);
            return new SuccessResult("Car image updated");
        }

        public IDataResult<CarImage> Get(int id) {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.CarImageId == id));
        }

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int carId) {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == carId));
        }


    }
}
