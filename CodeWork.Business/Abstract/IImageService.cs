using CodeWork.Entities.Concrete;
using CodeWork.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeWork.Business.Abstract
{
    public interface IImageService
    {
        Response<ImageDto> Get(Expression<Func<Image, bool>> expression = null, string include = "");
        Response<List<ImageDto>> List(Expression<Func<Image, bool>> expression = null);
        Response<ImageDto> Add(ImageCreateDto bookDto);
        Response<ImageUpdateDto> Update(ImageUpdateDto bookUpdateDto);
        Response<NoContent> Delete(int id);

    }
}
