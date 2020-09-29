namespace ReportingModule.Core.Security
{
    public static class ReportingModuleClaimTypes
    {
        public const string UserDbId = "https://reportingmodule.com/claims/UserDbId";
        public const string Username = "https://reportingmodule.com/claims/username";
        public const string IsSystemAdmin = "https://reportingmodule.com/claims/IsSystemAdmin";
        public const string IsSystemUser = "https://reportingmodule.com/claims/IsSystemUser";
        public const string AccessAllOrganizations = "https://reportingmodule.com/claims/AccessAllOrganizations";
        public const string OrganizationRole = "https://reportingmodule.com/claims/OrganizationRole";
        public const string OrganizationAccess = "https://reportingmodule.com/claims/OrganizationAccess";
    }

    public enum OrganizationRoleType
    {
        Admin = 1,
        User = 2,
    }
}