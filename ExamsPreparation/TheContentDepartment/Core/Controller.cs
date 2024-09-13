using System.Diagnostics;
using System.Text;
using TheContentDepartment.Core.Contracts;
using TheContentDepartment.Models;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Core
{
    public class Controller : IController
    {
        private ResourceRepository resources;
        private MemberRepository members;

        public Controller()
        {
            resources = new ResourceRepository();
            members = new MemberRepository();
        }

        public string JoinTeam(string memberType, string memberName, string path)
        {
            if (memberType != nameof(TeamLead) && memberType != nameof(ContentMember))
            {
                return string.Format(OutputMessages.MemberTypeInvalid, memberType);
            }

            if (members.Models.Any(m => m.Path == path))
            {
                return string.Format(OutputMessages.PositionOccupied);
            }

            if (members.Models.Any(m => m.Name == memberName))
            {
                return string.Format(OutputMessages.MemberExists, memberName);
            }

            ITeamMember member;

            if (memberType == nameof(TeamLead))
            {
                member = new TeamLead(memberName, path);
            }
            else
            {
                member = new ContentMember(memberName, path);
            }

            members.Add(member);

            return string.Format(OutputMessages.MemberJoinedSuccessfully, memberName);
        }

        public string CreateResource(string resourceType, string resourceName, string path)
        {
            if (resourceType != typeof(Exam).Name 
                && resourceType != typeof(Workshop).Name 
                && resourceType != typeof(Presentation).Name)
            {
                return string.Format(OutputMessages.ResourceTypeInvalid, resourceType);
            }

            ITeamMember teamMember = members.Models.FirstOrDefault(m => m.Path == path);

            if (teamMember == null)
            {
                return string.Format(OutputMessages.NoContentMemberAvailable, resourceName);
            }

            if (teamMember.InProgress.Contains(resourceName))
            {
                return string.Format(OutputMessages.ResourceExists, resourceName);
            }

            IResource resource = resourceType switch
            {
                "Exam" => new Exam(resourceName, teamMember.Name),
                "Workshop" => new Workshop(resourceName, teamMember.Name),
                "Presentation" => new Presentation(resourceName, teamMember.Name),
            };

            teamMember.WorkOnTask(resourceName);
            resources.Add(resource);

            return string.Format(OutputMessages.ResourceCreatedSuccessfully, teamMember.Name, resourceType, resourceName);
        }

        public string LogTesting(string memberName)
        {
            ITeamMember teamMember = members.TakeOne(memberName);
            if (teamMember == null)
            {
                return OutputMessages.WrongMemberName;
            }

            IResource resource = resources.Models
                .OrderBy(r => r.Priority)
                .Where(r => r.IsTested == false)
                .Where(r => r.Creator == memberName)
                .FirstOrDefault();

            if (resource == null)
            {
                return string.Format(OutputMessages.NoResourcesForMember, memberName);
            }

            ITeamMember teamLead = members.Models.FirstOrDefault(m => m.GetType().Name == "TeamLead");
            teamMember.FinishTask(resource.Name);
            teamLead.WorkOnTask(resource.Name);
            resource.Test();

            return string.Format(OutputMessages.ResourceTested, resource.Name);
        }

        public string ApproveResource(string resourceName, bool isApprovedByTeamLead)
        {
            IResource resource = resources.TakeOne(resourceName);
            if (!resource.IsTested)
            {
                return string.Format(OutputMessages.ResourceNotTested, resourceName);
            }

            ITeamMember teamLead = members.Models.FirstOrDefault(m => m.GetType().Name == "TeamLead");

            if (isApprovedByTeamLead)
            {
                resource.Approve();
                teamLead.FinishTask(resourceName);
                return string.Format(OutputMessages.ResourceApproved, teamLead.Name, resourceName);
            }

            resource.Test();
            return string.Format(OutputMessages.ResourceReturned, teamLead.Name, resourceName);
        }

        public string DepartmentReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Finished Tasks:");

            foreach (var resource in resources.Models.Where(m => m.IsApproved))
            {
                sb.AppendLine($"--{resource.ToString()}");
            }

            sb.AppendLine($"Team Report:");

            ITeamMember teamLead = members.Models.FirstOrDefault(m => m.GetType().Name == nameof(TeamLead));

            sb.AppendLine($"--{teamLead!.ToString()}");

            foreach (var member in members.Models.Where(m => m.GetType().Name != nameof(TeamLead)))
            {
                sb.AppendLine($"{member.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
