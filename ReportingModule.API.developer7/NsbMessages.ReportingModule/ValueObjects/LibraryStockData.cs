using System;

namespace ReportingModule.ValueObjects
{
    public class LibraryStockData
    {
        protected LibraryStockData()
        {
        }

        public LibraryStockData(int lastPeriod, int increased, int decreased, string comment)
        {
            Increased = increased;
            Decreased = decreased;
            LastPeriod = lastPeriod;
            Comment = comment;
        }
        public int LastPeriod { get; private set; }

        public int ThisPeriod => GetThisPeriod();

        public int Increased { get; private set; }
        public int Decreased { get; private set; }
        public string Comment { get; private set; }

       
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

        public static LibraryStockData Default() => new LibraryStockData(0, 0, 0,null);

        private int GetThisPeriod()
        {
            return LastPeriod + Increased - Decreased <= 0 ? 0 : LastPeriod + Increased - Decreased;
        }

        public static implicit operator LibraryStockPlanData(LibraryStockData data)
        {
            //return new LibraryStockPlanData(data.LastPeriod,data.Increased,data.Decreased);
            return new LibraryStockPlanData();
        }

        public static implicit operator LibraryStockReportData(LibraryStockData data)
        {
            return new LibraryStockReportData(data.LastPeriod,
                data.Increased, data.Decreased, data.Comment);
        }
    }
}