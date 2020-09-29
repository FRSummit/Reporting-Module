using System;

namespace ReportingModule.ValueObjects
{
    public class MemberData
    {
        protected MemberData()
        {
        }

        public MemberData(string nameAndContactNumber, string action, int lastPeriod, int upgradeTarget, int increased, int decreased, string comment, int personalContact)
        {
            NameAndContactNumber = nameAndContactNumber;
            Action = action;
            Increased = increased;
            Decreased = decreased;
            UpgradeTarget = upgradeTarget;
            LastPeriod = lastPeriod;
            Comment = comment;
            PersonalContact = personalContact;
        }
        public string NameAndContactNumber { get; private set; }
        public string Action { get; private set; }
        public int LastPeriod { get; private set; }
        public int UpgradeTarget { get; private set; }

        public int ThisPeriod => GetThisPeriod();

        public int Increased { get; private set; }
        public int Decreased { get; private set; }
        public string Comment { get; private set; }
        public int PersonalContact { get; private set; }

       
        public void SetIncreased(int increased)
        {
            if (increased < 0)
                throw new ArgumentOutOfRangeException(nameof(increased));
            Increased = increased;
        }

        public void SetDecreased(int decreased)
        {
            if (decreased < 0)
                throw new ArgumentOutOfRangeException(nameof(decreased));

            Decreased = decreased;
        }

        public void SetThisPeriod(int thisPeriod)
        {
            if (thisPeriod < 0)
                throw new ArgumentOutOfRangeException(nameof(thisPeriod));


            if (LastPeriod > thisPeriod)
            {
                var diff = LastPeriod - thisPeriod;
                Increased = 0;
                Decreased = diff;
            }
            else if (LastPeriod < thisPeriod)
            {
                var diff = thisPeriod - LastPeriod;
                Increased = diff;
                Decreased = 0;
            }
            else
            {
                Increased = 0;
                Decreased = 0;
            }
        }

        public static MemberData Default() => new MemberData(null, null, 0, 0, 0, 0, null, 0);

        private int GetThisPeriod()
        {
            return LastPeriod + Increased - Decreased <= 0 ? 0 : LastPeriod + Increased - Decreased;
        }

        public static implicit operator MemberPlanData(MemberData data)
        {
            return new MemberPlanData(data.NameAndContactNumber,
                data.Action, data.UpgradeTarget);
        }

        public static implicit operator MemberReportData(MemberData data)
        {
            return new MemberReportData(data.LastPeriod,
                data.Increased, data.Decreased, data.Comment, data.PersonalContact);
        }
    }
}