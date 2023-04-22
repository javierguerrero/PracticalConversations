using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MapperService : IMapperService
    {
        private readonly IMapper _autoMapper;

        public MapperService(IMapper autoMapper)
        {
            _autoMapper = autoMapper;
        }

        public CategoryDto ConvertToDto(Category entity)
        {
            return _autoMapper.Map<CategoryDto>(entity); 
        }

        public Category ConvertToEntity(CategoryDto dto)
        {
            return _autoMapper.Map<Category>(dto);
        }
    }
}
