using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPlatform.Application.EmailNotification;
using TaskManagerPlatform.Domain.Issues;
using TaskManagerPlatform.Domain.Repository;

namespace TaskManagerPlatform.Application.Issues
{
    public class IssueService : IIssueService
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IEmailSender _emailSender;

        public IssueService(IIssueRepository issueRepository, IEmailSender emailSender)
        {
            _issueRepository = issueRepository;
            _emailSender = emailSender;
        }

        public void DeleteIssue(int id)
        {
            throw new NotImplementedException();
        }

        public Issue GetIssueByID(int id)
        {
            var result = _issueRepository.GetByID(id);
            return result;
        }

        public IList<Issue> GetIssues()
        {
            var list = _issueRepository.Get().ToList();
            return list;
        }

        public void Insert(Issue issue)
        {
            _issueRepository.Insert(issue);
            //send mail to email address with MailKit
            foreach(var user in issue.AssignableUsers)
            {
                _emailSender.SendEmailAsync(user.Email, "task assing", "a new task has been assigned to you");
            }
        }

        public void Save()
        {
            _issueRepository.Save();
        }

        public void UpdateIssue(Issue issue)
        {
            _issueRepository.Update(issue);
        }
    }
}
