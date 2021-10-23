using DataRepository.Abstraction;
using ProjectDB.DBModel;
using ServiceProject.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceProject.Implementation
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository repository)
        {
            _candidateRepository = repository;
        }

        public IEnumerable<Candidates> GetCandidate()
        {
            return _candidateRepository.GetAll();
        }

        public Candidates GetCandidate(int id)
        {
            return _candidateRepository.GetAll().Where(i => i.ID == id).FirstOrDefault();
        }
    }
}
