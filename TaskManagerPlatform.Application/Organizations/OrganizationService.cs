using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPlatform.Domain.Organizations;
using TaskManagerPlatform.Domain.Repository;

namespace TaskManagerPlatform.Application.Organizations
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;
        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }
        public void DeleteOrganization(int id)
        {
            _organizationRepository.Delete(id);
        }

        public Organization GetOrganizationByID(int id)
        {
            var result = _organizationRepository.GetByID(id);
            return result;
        }

        public IList<Organization> GetOrganizations()
        {
            var list = _organizationRepository.Get().ToList();
            return list;
        }

        public void Insert(Organization organization)
        {
            _organizationRepository.Insert(organization);
        }

        public void Save()
        {
            _organizationRepository.Save();
        }

        public void UpdateOrganization(Organization organization)
        {
            _organizationRepository.Update(organization);
        }
    }
}
