using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IMapperService
    {
        Category ConvertToEntity(CategoryDto dto);
        CategoryDto ConvertToDto(Category entity);

        Conversation ConvertToEntity(ConversationDto dto);
        ConversationDto ConvertToDto(Conversation entity);
    }
}
