using ReportingModule.Core;

namespace NsbWeb.Core
{
    public interface IUserContext
    {
        UserReference UserRef { get; }

        //bool CurrentUserIsCustomer();
        //bool CurrentUserIsStaff();
        bool CurrentUserIsSystemAdmin();
        //bool CurrentUserIsJupiterSystemAdmin();
        //bool CurrentUserCanAccessAllAgents();
        //bool CurrentUserHasProtectedObject(ProtectedObject protectedObject);

        //int[] GetBusinessPartnerIds();
        //int GetAgentId();
        //int[] GetAgentIds();
        //EntityReference GetAgentRef();

        //PortReference GetUserLocation();

        string Username { get; }
        bool CurrentUserIsSystemUser();
        bool CurrentUserCanAccessAllOrganizations();
        bool CurrentUserIsOrganizationAdmin(int organizationId);
        bool CurrentUserCanAccess(int organizationId);
        int[] GetOrganizationIds();
    }
}