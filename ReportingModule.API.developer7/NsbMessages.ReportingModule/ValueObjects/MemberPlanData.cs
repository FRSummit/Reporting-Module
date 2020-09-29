namespace ReportingModule.ValueObjects
{
    public class MemberPlanData
    {
        protected MemberPlanData()
        {
        }

        public MemberPlanData(string nameAndContactNumber, string action, int upgradeTarget)
        {
            NameAndContactNumber = nameAndContactNumber;
            Action = action;
            UpgradeTarget = upgradeTarget;
        }

        public string NameAndContactNumber { get; private set; }
        public string Action { get; private set; }
        public int UpgradeTarget { get; private set; }
        
    }
}