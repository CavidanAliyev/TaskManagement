using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPlatform.Domain.Organizations;

namespace TaskManagerPlatform.Application.Organizations
{
    public interface IOrganizationService
    {
        IList<Organization> GetOrganizations();
        Organization GetOrganizationByID(int id);
        void Insert(Organization organization);
        void DeleteOrganization(int id);
        void UpdateOrganization(Organization organization);
        void Save();
    }
}
