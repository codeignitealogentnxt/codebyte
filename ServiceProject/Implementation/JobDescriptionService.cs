using DataRepository;
using ProjectDB.DBModel;
using ServiceProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceProject
{
    public class JobDescriptionService : IJobDescriptionService
    {
        private readonly IJobDescriptionRepository _jobdescriptionRepository;

        public JobDescriptionService(IJobDescriptionRepository clientRepository)
        {
            _jobdescriptionRepository = clientRepository;
        }

        public IEnumerable<ProjectDB.DBModel.JobDescription> GetJobDescription()
        {
            return _jobdescriptionRepository.GetAll();
        }

        JobDescription IJobDescriptionService.GetJobDescription(int id)
        {
            return _jobdescriptionRepository.GetAll().Where(i => i.ID == id).FirstOrDefault();
        }
    }
}
