using AutoMapper;
using CodeWork.Business.Abstract;
using CodeWork.Dal.Abstract;
using CodeWork.Entities.Concrete;
using CodeWork.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeWork.Business.Concrete.Manager
{
    public class ImageService : IImageService
    {
        private IImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public ImageService(IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }

        public Response<ImageDto> Add(ImageCreateDto imageCreateDto)
        {
            var newImage = _mapper.Map<Image>(imageCreateDto);
            var image = _imageRepository.Add(newImage);
            return Response<ImageDto>.Success(_mapper.Map<ImageDto>(image), 200);
        }

        public Response<NoContent> Delete(int id)
        {
            var getImage = _imageRepository.Get(x => x.Id == id);

            if (getImage == null)
            {
                return Response<NoContent>.Fail("Image Not Found", 404);
            }

            _imageRepository.Delete(id);

            return Response<NoContent>.Success(204);
        }

        public Response<ImageDto> Get(Expression<Func<Image, bool>> expression = null, string include = "")
        {
            var image = _imageRepository.Get(expression, include);

            if (image == null)
            {
                return Response<ImageDto>.Fail("image Not Found", 404);

            }
            return Response<ImageDto>.Success(_mapper.Map<ImageDto>(image), 200);
        }

        public Response<List<ImageDto>> List(Expression<Func<Image, bool>> expression = null)
        {
            var images = _imageRepository.List(expression);

            return Response<List<ImageDto>>.Success(_mapper.Map<List<ImageDto>>(images), 200);
        }

        public Response<ImageUpdateDto> Update(ImageUpdateDto imageUpdateDto)
        {
            var newImage = _mapper.Map<Image>(imageUpdateDto);

            var result = _imageRepository.Get(x => x.Id == newImage.Id);

            if (result == null)
            {
                return Response<ImageUpdateDto>.Fail("Image Not Found", 404);
            }

            var getImage = _imageRepository.Update(newImage);


            return Response<ImageUpdateDto>.Success(_mapper.Map<ImageUpdateDto>(getImage), 200);
        }
    }
}
