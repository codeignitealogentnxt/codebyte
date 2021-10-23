﻿using ProjectDB.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.Abstraction
{
    public interface IJobDescriptionRepository : IBaseRepository<JobDescription>
    {
        IEnumerable<JobDescription> GetJobDescriptionById(int id);
        IEnumerable<JobDescription> GetJobDescription();
    }
}