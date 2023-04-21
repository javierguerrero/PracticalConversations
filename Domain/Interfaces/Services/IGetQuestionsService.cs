﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IGetQuestionsService
    {
        Task<IEnumerable<Question>> GetQuestions(int categoryId);
    }
}
