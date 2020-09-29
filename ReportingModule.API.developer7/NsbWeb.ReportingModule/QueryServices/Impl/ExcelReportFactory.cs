using NsbWeb.ReportingModule.ViewModels;
using OfficeOpenXml;
using ReportingModule.ValueObjects;
using ReportingModule.ViewModels.Search;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ReportingModule.Common;

namespace NsbWeb.ReportingModule.QueryServices.Impl
{
    public class ExcelReportFactory : IExcelReportFactory
    {
        public byte[] CreateExcelReport(SearchResult<UnitReportViewModel> data)
        {
            var items = data.Items.Select(ExcelReportDataTranslator.ToExcelReportData).ToArray();
            var searchResult = new SearchResult<ExcelReportData>(items, data.PagingData);
            return CreateExcelReport(searchResult);
        }
        public byte[] CreateExcelReport(UnitReportViewModel data)
        {
            var excelReportData = ExcelReportDataTranslator.ToExcelReportData(data);
            return CreateExcelReport(excelReportData);
        }

        public byte[] CreateExcelReport(SearchResult<ZoneReportViewModel> data)
        {
            var items = data.Items.Select(ExcelReportDataTranslator.ToExcelReportData).ToArray();
            var searchResult = new SearchResult<ExcelReportData>(items, data.PagingData);
            return CreateExcelReport(searchResult);
        }
        public byte[] CreateExcelReport(ZoneReportViewModel data)
        {
            var excelReportData = ExcelReportDataTranslator.ToExcelReportData(data);
            return CreateExcelReport(excelReportData);

        }

        public byte[] CreateExcelReport(SearchResult<StateReportViewModel> data)
        {
            var items = data.Items.Select(ExcelReportDataTranslator.ToExcelReportData).ToArray();
            var searchResult = new SearchResult<ExcelReportData>(items, data.PagingData);
            return CreateExcelReport(searchResult);
        }
        public byte[] CreateExcelReport(StateReportViewModel data)
        {
            var excelReportData = ExcelReportDataTranslator.ToExcelReportData(data);
            return CreateExcelReport(excelReportData);

        }

        public byte[] CreateExcelReport(SearchResult<CentralReportViewModel> data)
        {
            var items = data.Items.Select(ExcelReportDataTranslator.ToExcelReportData).ToArray();
            var searchResult = new SearchResult<ExcelReportData>(items, data.PagingData);
            return CreateExcelReport(searchResult);

        }
        public byte[] CreateExcelReport(CentralReportViewModel data)
        {
            var excelReportData = ExcelReportDataTranslator.ToExcelReportData(data);
            return CreateExcelReport(excelReportData);
        }

        public byte[] CreateExcelReport(SearchResult<ExcelReportData> data)
        {
            var comments = new List<string>();
            var totalData =  GetConsolidated(data);

            const string template = "NsbWeb.ReportingModule.Templates.IpdcReportDetailMultipleTemplate.xlsx";
            using (var stream = new MemoryStream())
            {
                Stream s = Assembly.GetAssembly(typeof(ExcelReportData)).GetManifestResourceStream(template);

                var excel = new ExcelPackage(s);
                var ws = excel.Workbook.Worksheets["Reports"];
                var wsTotal = excel.Workbook.Worksheets["Consolidated"];

                #region ReportDetails Worksheet
                //Body row 2
                int row = 2;
                int columnReport = 1; // Column for Report
                int columnOrganizations = 3; // Column for Organization
                int columnReportingPeriodYear = 7; //Reporting Period Year
                int columnReopened = 13; //Reopened
                int columnComment = 14; //Comment
                int columnTimestamp = 15; //Timestamp
                int columnParent = 16; //Parent
                int columnOrganization = 18; // Organization
                int columnMemberMember = 21; // Member Member
                int columnAssociateMember = 28; //Associate Member      
                int columnPreliminaryMember = 35; //Preliminary Member
                int columnSupporterMember = 42; //Supporter Member
                int columnCmsMeeting = 49; //CMS Meeting 
                int columSmMeeting = 52; //SM Meeting
                int columMemberMeeting = 55; //Member Meeting
                int columnWorkerMeeting = 58; //Worker Meeting
                int columnDawahMeeting = 61; //Dawah Meeting
                int columnLearningMeeting = 64; //Learning Meeting
                int columnStateLeaderMeeting = 67; // State LeaderState Leader Meeting
                int columnSocialDawahMeeting = 70; //Social Dawah Meeting
                int columnTafsirMeetin = 73; //Tafsir Meeting
                int columnOtherMeeting = 76; //Other Meeting
                int columnDawahGroupMeeting = 79; //Dawah Group Meeting
                int columnUnitMeeting = 82; // Unit Meeting
                int columnFamilyVisitMeeting = 85; //Family Visit Meeting
                int columnIftarMeeting = 88; //Iftar Meeting
                int columnEidReunionMeeting = 91;//Eid Reunion Meeting
                int columnBbqMeeting = 94;//Bbq Meeting
                int columnStateOutingMeeting = 97; //State Outing Meeting 
                int columnNextGMeeting = 100; //NextG Meeting 
                int columnGatheringMeeting = 103;//Gathering Meeting
                int columnGroupStudy = 106; //Group Study Teaching Learning Program
                int columnStudyCircleForAssociate = 109; //Study Circle For Associate Member Teaching Learning Program
                int columnStudyCircle = 112; //Study Circle Teaching Learning Program
                int columnPracticeDars = 115; //Practice Dars Teaching Learning Program
                int columnStateLearningCamp = 118; //State Learning Camp Teaching Learning Program
                int columnQuranStudy = 121; //Quran Study Teaching Learning Program
                int columnHadithTeachingLearning = 124; //Hadith Teaching Learning Program
                int columnQuranClass = 127; //Quran Class Teaching Learning Program
                int columnWeekendIslamicSchoolTeachingLearning = 130; //Weekend Islamic School Teaching Learning Program
                int columnMemorizingAyat = 133; //Memorizing Ayat Teaching Learning Program
                int columnMemorizingHadithTeachingLearning = 136; //Memorizing Hadith Teaching Learning Program
                int columnMemorizingDoaTeachingLearning = 139; //Memorizing Doa Teaching Learning Program
                int columnStateLearningSession = 142; //State Learning Session Teaching Learning Program
                int columnStateQiyamulLail = 145; //State QiyamulLail Teaching Learning Program
                int columnOtherTeachingLearning = 148; //Other Teaching Learning Program
                int columnBookSaleDistributionMaterial = 151; //Book Sale Distribution Material
                int columnBookSaleMaterial = 153; //Book Sale Material
                int columnBookLibraryStock = 155; //Book Library Stock
                int columnVhsDistributionMaterial = 158; //Vhs Distribution Material
                int columnVhsSaleMaterial = 160; //Vhs Sale Material
                int columnVhsLibraryStock = 162; //Vhs Library Stock
                int columnIpdcLeaflet = 165; //Ipdc Leaflet Distribution Material
                int columnEmailDistribution = 167; //Email Distribution Material
                int columOtherMaterial = 169; // Other Material Distribution
                int columOtherLibraryStock = 171; // Other Library Stock
                int columnBaitulMalFinance = 174; //Baitul Mal Finance
                int columnADayMasjidProjectFinance = 182; //ADay Masjid Project Finance
                int columnMasjidTableBankFinance = 190; //Masjid Table Bank Finance
                int columnQardeHasana = 198; //Qarde Hasana Social Welfare 
                int columnTransport = 200; //Transport Social Welfare
                int columnPatientVisit = 202; //Patient Visit Social Welfare 
                int columnShifting = 204; //Shifting Social Welfare
                int columnSocialVisit = 206; //Social Visit Social Welfare
                int columnShopping = 208; //Shopping Social Welfare
                int columnFoodDistribution = 210; // Food Distribution Social Welfare Data
                int columnOtherCleanUpAustralia = 212; // Other Clean Up Australia
                int columnOtherSocialWelfare = 214; // Other Social Welfare Data
                foreach (var item in data.Items)
                {
                    //Report = 1
                    ws.Cells[row, columnReport].Value = item.Id;
                    ws.Cells[row, columnReport + 1].Value = item.Description;
                    //Organizations = 3
                    ws.Cells[row, columnOrganizations].Value = item.Organization.Id;
                    ws.Cells[row, columnOrganizations + 1].Value = item.Organization.Description;
                    ws.Cells[row, columnOrganizations + 2].Value = item.Organization.OrganizationType;
                    ws.Cells[row, columnOrganizations + 3].Value = item.Organization.ReportingFrequency;
                    //Reporting Period Year = 7
                    ws.Cells[row, columnReportingPeriodYear].Value = item.ReportingPeriod.Year;
                    ws.Cells[row, columnReportingPeriodYear + 1].Value = item.ReportingPeriod.ReportingFrequency;
                    ws.Cells[row, columnReportingPeriodYear + 2].Value = item.ReportingPeriod.ReportingTerm;
                    ws.Cells[row, columnReportingPeriodYear + 3].Value = item.ReportingPeriod.StartDate;
                    ws.Cells[row, columnReportingPeriodYear + 4].Value = item.ReportingPeriod.EndDate;
                    ws.Cells[row, columnReportingPeriodYear + 5].Value = item.ReportStatus;
                    //Reopened = 13
                    ws.Cells[row, columnReopened].Value = item.ReOpenedReportStatus;
                    //Comment = 14
                    ws.Cells[row, columnComment].Value = item.Comment;
                    //Timestamp = 15
                    ws.Cells[row, columnTimestamp].Value = item.Timestamp;
                    //Parent = 16
                    ws.Cells[row, columnParent].Value = null; // ParentId
                    ws.Cells[row, columnParent + 1].Value = null; // ParentDescription
                    //Organization = 172
                    ws.Cells[row, columnOrganization].Value = item.Organization.Description;
                    ws.Cells[row, columnOrganization + 1].Value = item.Organization.OrganizationType;
                    ws.Cells[row, columnOrganization + 2].Value = item.Organization.ReportingFrequency;

                    //Member data
                    ws.Cells[row, columnMemberMember].Value = item.MemberMemberData.LastPeriod;
                    ws.Cells[row, columnMemberMember + 1].Value = item.MemberMemberData.UpgradeTarget;
                    ws.Cells[row, columnMemberMember + 2].Value = item.MemberMemberData.Increased;
                    ws.Cells[row, columnMemberMember + 3].Value = item.MemberMemberData.Decreased;
                    ws.Cells[row, columnMemberMember + 4].Value = item.MemberMemberData.ThisPeriod;
                    ws.Cells[row, columnMemberMember + 5].Value = item.MemberMemberData.PersonalContact;
                    ws.Cells[row, columnMemberMember + 6].Value = item.MemberMemberData.Comment;
                    //Associate Member data
                    ws.Cells[row, columnAssociateMember].Value = item.AssociateMemberData.LastPeriod;
                    ws.Cells[row, columnAssociateMember + 1].Value = item.AssociateMemberData.UpgradeTarget;
                    ws.Cells[row, columnAssociateMember + 2].Value = item.AssociateMemberData.Increased;
                    ws.Cells[row, columnAssociateMember + 3].Value = item.AssociateMemberData.Decreased;
                    ws.Cells[row, columnAssociateMember + 4].Value = item.AssociateMemberData.ThisPeriod;
                    ws.Cells[row, columnAssociateMember + 5].Value = item.AssociateMemberData.PersonalContact;
                    ws.Cells[row, columnAssociateMember + 6].Value = item.AssociateMemberData.Comment;

                    //Preliminary Member data
                    ws.Cells[row, columnPreliminaryMember].Value = item.PreliminaryMemberData.LastPeriod;
                    ws.Cells[row, columnPreliminaryMember + 1].Value = item.PreliminaryMemberData.UpgradeTarget;
                    ws.Cells[row, columnPreliminaryMember + 2].Value = item.PreliminaryMemberData.Increased;
                    ws.Cells[row, columnPreliminaryMember + 3].Value = item.PreliminaryMemberData.Decreased;
                    ws.Cells[row, columnPreliminaryMember + 4].Value = item.PreliminaryMemberData.ThisPeriod;
                    ws.Cells[row, columnPreliminaryMember + 5].Value = item.PreliminaryMemberData.PersonalContact;
                    ws.Cells[row, columnPreliminaryMember + 6].Value = item.PreliminaryMemberData.Comment;

                    //Supporter Member data
                    ws.Cells[row, columnSupporterMember].Value = item.SupporterMemberData.LastPeriod;
                    ws.Cells[row, columnSupporterMember + 1].Value = item.SupporterMemberData.UpgradeTarget;
                    ws.Cells[row, columnSupporterMember + 2].Value = item.SupporterMemberData.Increased;
                    ws.Cells[row, columnSupporterMember + 3].Value = item.SupporterMemberData.Decreased;
                    ws.Cells[row, columnSupporterMember + 4].Value = item.SupporterMemberData.ThisPeriod;
                    ws.Cells[row, columnSupporterMember + 5].Value = item.SupporterMemberData.PersonalContact;
                    ws.Cells[row, columnSupporterMember + 6].Value = item.SupporterMemberData.Comment;

                    //Regular & Special Meetings / Programs

                    //CMS Meeting
                    ws.Cells[row, columnCmsMeeting].Value = item.CmsMeetingProgramData.Target;
                    ws.Cells[row, columnCmsMeeting + 1].Value = item.CmsMeetingProgramData.Actual;
                    ws.Cells[row, columnCmsMeeting + 2].Value = item.CmsMeetingProgramData.AverageAttendance;
                    //SM Meeting
                    ws.Cells[row, columSmMeeting].Value = item.SmMeetingProgramData.Target;
                    ws.Cells[row, columSmMeeting + 1].Value = item.SmMeetingProgramData.Actual;
                    ws.Cells[row, columSmMeeting + 2].Value = item.SmMeetingProgramData.AverageAttendance;
                    //Member Meeting
                    ws.Cells[row, columMemberMeeting].Value = item.MemberMeetingProgramData.Target;
                    ws.Cells[row, columMemberMeeting + 1].Value = item.MemberMeetingProgramData.Actual;
                    ws.Cells[row, columMemberMeeting + 2].Value = item.MemberMeetingProgramData.AverageAttendance;
                    //Worker Meeting
                    ws.Cells[row, columnWorkerMeeting].Value = item.WorkerMeetingProgramData.Target;
                    ws.Cells[row, columnWorkerMeeting + 1].Value = item.WorkerMeetingProgramData.Actual;
                    ws.Cells[row, columnWorkerMeeting + 2].Value = item.WorkerMeetingProgramData.AverageAttendance;
                    //Dawah Meeting
                    ws.Cells[row, columnDawahMeeting].Value = item.DawahMeetingProgramData.Target;
                    ws.Cells[row, columnDawahMeeting + 1].Value = item.DawahMeetingProgramData.Actual;
                    ws.Cells[row, columnDawahMeeting + 2].Value = item.DawahMeetingProgramData.AverageAttendance;
                    //Learning Meeting
                    ws.Cells[row, columnLearningMeeting].Value = item.LearningMeetingProgramData.Target;
                    ws.Cells[row, columnLearningMeeting + 1].Value = item.LearningMeetingProgramData.Actual;
                    ws.Cells[row, columnLearningMeeting + 2].Value = item.LearningMeetingProgramData.AverageAttendance;
                    //State - Leaders Meeting
                    ws.Cells[row, columnStateLeaderMeeting].Value = item.StateLeaderMeetingProgramData.Target;
                    ws.Cells[row, columnStateLeaderMeeting + 1].Value = item.StateLeaderMeetingProgramData.Actual;
                    ws.Cells[row, columnStateLeaderMeeting + 2].Value = item.StateLeaderMeetingProgramData.AverageAttendance;
                    //Social Dawah Gathering
                    ws.Cells[row, columnSocialDawahMeeting].Value = item.SocialDawahMeetingProgramData.Target;
                    ws.Cells[row, columnSocialDawahMeeting + 1].Value = item.SocialDawahMeetingProgramData.Actual;
                    ws.Cells[row, columnSocialDawahMeeting + 2].Value = item.SocialDawahMeetingProgramData.AverageAttendance;
                    //Tafsir	
                    ws.Cells[row, columnTafsirMeetin].Value = item.TafsirMeetingProgramData.Target;
                    ws.Cells[row, columnTafsirMeetin + 1].Value = item.TafsirMeetingProgramData.Actual;
                    ws.Cells[row, columnTafsirMeetin + 2].Value = item.TafsirMeetingProgramData.AverageAttendance;
                    //Other(……..)
                    ws.Cells[row, columnOtherMeeting].Value = item.OtherMeetingProgramData.Target;
                    ws.Cells[row, columnOtherMeeting + 1].Value = item.OtherMeetingProgramData.Actual;
                    ws.Cells[row, columnOtherMeeting + 2].Value = item.OtherMeetingProgramData.AverageAttendance;
                    //Dawah Group/Unit/Family Visits 	
                    ws.Cells[row, columnDawahGroupMeeting].Value = item.DawahGroupMeetingProgramData.Target;
                    ws.Cells[row, columnDawahGroupMeeting + 1].Value = item.DawahGroupMeetingProgramData.Actual;
                    ws.Cells[row, columnDawahGroupMeeting + 2].Value = item.DawahGroupMeetingProgramData.AverageAttendance;
                    //Unit
                    ws.Cells[row, columnUnitMeeting].Value = item.UnitMeetingProgramData.Target;
                    ws.Cells[row, columnUnitMeeting + 1].Value = item.UnitMeetingProgramData.Actual;
                    ws.Cells[row, columnUnitMeeting + 2].Value = item.UnitMeetingProgramData.AverageAttendance;
                    //Family Visits 	
                    ws.Cells[row, columnFamilyVisitMeeting].Value = item.FamilyVisitMeetingProgramData.Target;
                    ws.Cells[row, columnFamilyVisitMeeting + 1].Value = item.FamilyVisitMeetingProgramData.Actual;
                    ws.Cells[row, columnFamilyVisitMeeting + 2].Value = item.FamilyVisitMeetingProgramData.AverageAttendance;
                    //Iftar/Eid Re-union/BBQ		
                    ws.Cells[row, columnIftarMeeting].Value = item.IftarMeetingProgramData.Target;
                    ws.Cells[row, columnIftarMeeting + 1].Value = item.IftarMeetingProgramData.Actual;
                    ws.Cells[row, columnIftarMeeting + 2].Value = item.IftarMeetingProgramData.AverageAttendance;
                    //Eid Re-union		
                    ws.Cells[row, columnEidReunionMeeting].Value = item.IftarMeetingProgramData.Target;
                    ws.Cells[row, columnEidReunionMeeting + 1].Value = item.IftarMeetingProgramData.Actual;
                    ws.Cells[row, columnEidReunionMeeting + 2].Value = item.IftarMeetingProgramData.AverageAttendance;
                    //BBQ
                    ws.Cells[row, columnBbqMeeting].Value = item.BbqMeetingProgramData.Target;
                    ws.Cells[row, columnBbqMeeting + 1].Value = item.BbqMeetingProgramData.Actual;
                    ws.Cells[row, columnBbqMeeting + 2].Value = item.BbqMeetingProgramData.AverageAttendance;
                    //State - Outing		
                    ws.Cells[row, columnStateOutingMeeting].Value = item.StateOutingMeetingProgramData.Target;
                    ws.Cells[row, columnStateOutingMeeting + 1].Value = item.StateOutingMeetingProgramData.Actual;
                    ws.Cells[row, columnStateOutingMeeting + 2].Value = item.StateOutingMeetingProgramData.AverageAttendance;                    //NextG Meeting/Gathering
                    //NextG meeting
                    ws.Cells[row, columnNextGMeeting].Value = item.NextGMeetingProgramData.Target;
                    ws.Cells[row, columnNextGMeeting + 1].Value = item.NextGMeetingProgramData.Actual;
                    ws.Cells[row, columnNextGMeeting + 2].Value = item.NextGMeetingProgramData.AverageAttendance;
                    //Gathering meeting
                    ws.Cells[row, columnGatheringMeeting].Value = item.GatheringMeetingProgramData.Target;
                    ws.Cells[row, columnGatheringMeeting + 1].Value = item.GatheringMeetingProgramData.Actual;
                    ws.Cells[row, columnGatheringMeeting + 2].Value = item.GatheringMeetingProgramData.AverageAttendance;

                    //Teaching and Learning Programs
                    //Group Study
                    ws.Cells[row, columnGroupStudy].Value = item.GroupStudyTeachingLearningProgramData.Target;
                    ws.Cells[row, columnGroupStudy + 1].Value = item.GroupStudyTeachingLearningProgramData.Actual;
                    ws.Cells[row, columnGroupStudy + 2].Value = item.GroupStudyTeachingLearningProgramData.AverageAttendance;
                    //Group Study / Study Circle (AM)
                    ws.Cells[row, columnStudyCircleForAssociate].Value = item.StudyCircleForAssociateMemberTeachingLearningProgramData.Target;
                    ws.Cells[row, columnStudyCircleForAssociate + 1].Value = item.StudyCircleForAssociateMemberTeachingLearningProgramData.Actual;
                    ws.Cells[row, columnStudyCircleForAssociate + 2].Value = item.StudyCircleForAssociateMemberTeachingLearningProgramData.AverageAttendance;
                    //Study Circle (MEMBER, CMS)
                    ws.Cells[row, columnStudyCircle].Value = item.StudyCircleTeachingLearningProgramData.Target;
                    ws.Cells[row, columnStudyCircle + 1].Value = item.StudyCircleTeachingLearningProgramData.Actual;
                    ws.Cells[row, columnStudyCircle + 2].Value = item.StudyCircleTeachingLearningProgramData.AverageAttendance;
                    //Practice Dars/ Speech
                    ws.Cells[row, columnPracticeDars].Value = item.PracticeDarsTeachingLearningProgramData.Target;
                    ws.Cells[row, columnPracticeDars + 1].Value = item.PracticeDarsTeachingLearningProgramData.Actual;
                    ws.Cells[row, columnPracticeDars + 2].Value = item.PracticeDarsTeachingLearningProgramData.AverageAttendance;
                    //Sate - Learning Camp (LC)
                    ws.Cells[row, columnStateLearningCamp].Value = item.StateLearningCampTeachingLearningProgramData.Target;
                    ws.Cells[row, columnStateLearningCamp + 1].Value = item.StateLearningCampTeachingLearningProgramData.Actual;
                    ws.Cells[row, columnStateLearningCamp + 2].Value = item.StateLearningCampTeachingLearningProgramData.AverageAttendance;
                    //Quran Study
                    ws.Cells[row, columnQuranStudy].Value = item.QuranStudyTeachingLearningProgramData.Target;
                    ws.Cells[row, columnQuranStudy + 1].Value = item.QuranStudyTeachingLearningProgramData.Actual;
                    ws.Cells[row, columnQuranStudy + 2].Value = item.QuranStudyTeachingLearningProgramData.AverageAttendance;
                    //Hadith Study
                    ws.Cells[row, columnHadithTeachingLearning].Value = item.HadithTeachingLearningProgramData.Target;
                    ws.Cells[row, columnHadithTeachingLearning + 1].Value = item.HadithTeachingLearningProgramData.Actual;
                    ws.Cells[row, columnHadithTeachingLearning + 2].Value = item.HadithTeachingLearningProgramData.AverageAttendance;
                    //Quran Class
                    ws.Cells[row, columnQuranClass].Value = item.QuranClassTeachingLearningProgramData.Target;
                    ws.Cells[row, columnQuranClass + 1].Value = item.QuranClassTeachingLearningProgramData.Actual;
                    ws.Cells[row, columnQuranClass + 2].Value = item.QuranClassTeachingLearningProgramData.AverageAttendance;
                    //Weekend Islamic School
                    ws.Cells[row, columnWeekendIslamicSchoolTeachingLearning].Value = item.WeekendIslamicSchoolTeachingLearningProgramData.Target;
                    ws.Cells[row, columnWeekendIslamicSchoolTeachingLearning + 1].Value = item.WeekendIslamicSchoolTeachingLearningProgramData.Actual;
                    ws.Cells[row, columnWeekendIslamicSchoolTeachingLearning + 2].Value = item.WeekendIslamicSchoolTeachingLearningProgramData.AverageAttendance;
                    //Memorizing Ayat
                    ws.Cells[row, columnMemorizingAyat].Value = item.MemorizingAyatTeachingLearningProgramData.Target;
                    ws.Cells[row, columnMemorizingAyat + 1].Value = item.MemorizingAyatTeachingLearningProgramData.Actual;
                    ws.Cells[row, columnMemorizingAyat + 2].Value = item.MemorizingAyatTeachingLearningProgramData.AverageAttendance;
                    //Memorizing Hadith
                    ws.Cells[row, columnMemorizingHadithTeachingLearning].Value = item.MemorizingHadithTeachingLearningProgramData.Target;
                    ws.Cells[row, columnMemorizingHadithTeachingLearning + 1].Value = item.MemorizingHadithTeachingLearningProgramData.Actual;
                    ws.Cells[row, columnMemorizingHadithTeachingLearning + 2].Value = item.MemorizingHadithTeachingLearningProgramData.AverageAttendance;
                    //Memorizing Doa
                    ws.Cells[row, columnMemorizingDoaTeachingLearning].Value = item.MemorizingDoaTeachingLearningProgramData.Target;
                    ws.Cells[row, columnMemorizingDoaTeachingLearning + 1].Value = item.MemorizingDoaTeachingLearningProgramData.Actual;
                    ws.Cells[row, columnMemorizingDoaTeachingLearning + 2].Value = item.MemorizingDoaTeachingLearningProgramData.AverageAttendance;
                    //State - Learning Session (LS)
                    ws.Cells[row, columnStateLearningSession].Value = item.StateLearningSessionTeachingLearningProgramData.Target;
                    ws.Cells[row, columnStateLearningSession + 1].Value = item.StateLearningSessionTeachingLearningProgramData.Actual;
                    ws.Cells[row, columnStateLearningSession + 2].Value = item.StateLearningSessionTeachingLearningProgramData.AverageAttendance;
                    //State - Qiyamul Lail
                    ws.Cells[row, columnStateQiyamulLail].Value = item.StateQiyamulLailTeachingLearningProgramData.Target;
                    ws.Cells[row, columnStateQiyamulLail + 1].Value = item.StateQiyamulLailTeachingLearningProgramData.Actual;
                    ws.Cells[row, columnStateQiyamulLail + 2].Value = item.StateQiyamulLailTeachingLearningProgramData.AverageAttendance;
                    //Other(……..)
                    ws.Cells[row, columnOtherTeachingLearning].Value = item.OtherTeachingLearningProgramData.Target;
                    ws.Cells[row, columnOtherTeachingLearning + 1].Value = item.OtherTeachingLearningProgramData.Actual;
                    ws.Cells[row, columnOtherTeachingLearning + 2].Value = item.OtherTeachingLearningProgramData.AverageAttendance;

                    //Dawah Material Distribution & Unit Library Status
                    //Book
                    ws.Cells[row, columnBookSaleDistributionMaterial].Value = item.BookDistributionMaterialData.Target;
                    ws.Cells[row, columnBookSaleDistributionMaterial + 1].Value = item.BookDistributionMaterialData.Actual;
                    ws.Cells[row, columnBookSaleMaterial].Value = item.BookSaleMaterialData.Target;
                    ws.Cells[row, columnBookSaleMaterial + 1].Value = item.BookSaleMaterialData.Actual;
                    ws.Cells[row, columnBookLibraryStock].Value = item.BookLibraryStockData.LastPeriod;
                    ws.Cells[row, columnBookLibraryStock + 1].Value = item.BookLibraryStockData.Increased;
                    ws.Cells[row, columnBookLibraryStock + 2].Value = item.BookLibraryStockData.Decreased;
                    //VHS/DVD/VCD/CD/Audio
                    ws.Cells[row, columnVhsDistributionMaterial].Value = item.VhsDistributionMaterialData.Target;
                    ws.Cells[row, columnVhsDistributionMaterial + 1].Value = item.VhsDistributionMaterialData.Actual;
                    ws.Cells[row, columnVhsSaleMaterial].Value = item.VhsSaleMaterialData.Target;
                    ws.Cells[row, columnVhsSaleMaterial + 1].Value = item.VhsSaleMaterialData.Actual;
                    ws.Cells[row, columnVhsLibraryStock].Value = item.VhsLibraryStockData.LastPeriod;
                    ws.Cells[row, columnVhsLibraryStock + 1].Value = item.VhsLibraryStockData.Increased;
                    ws.Cells[row, columnVhsLibraryStock + 2].Value = item.VhsLibraryStockData.Decreased;
                    //IPDC Leaflet
                    ws.Cells[row, columnIpdcLeaflet].Value = item.IpdcLeafletDistributionMaterialData.Target;
                    ws.Cells[row, columnIpdcLeaflet + 1].Value = item.IpdcLeafletDistributionMaterialData.Actual;
                    //Other(Email/Others)
                    ws.Cells[row, columnEmailDistribution].Value = item.EmailDistributionMaterialData.Target;
                    ws.Cells[row, columnEmailDistribution + 1].Value = item.EmailDistributionMaterialData.Actual;

                    //Other
                    ws.Cells[row, columOtherMaterial].Value = item.OtherDistributionMaterialData.Target;
                    ws.Cells[row, columOtherMaterial + 1].Value = item.OtherDistributionMaterialData.Actual;
                    ws.Cells[row, columOtherLibraryStock].Value = item.OtherLibraryStockData.LastPeriod;
                    ws.Cells[row, columOtherLibraryStock + 1].Value = item.OtherLibraryStockData.Increased;
                    ws.Cells[row, columOtherLibraryStock + 2].Value = item.OtherLibraryStockData.Decreased;

                    //Finance
                    //Baitul-Mal
                    ws.Cells[row, columnBaitulMalFinance].Value = item.BaitulMalFinanceData.WorkerPromiseLastPeriod;
                    ws.Cells[row, columnBaitulMalFinance + 1].Value = item.BaitulMalFinanceData.LastPeriod;
                    ws.Cells[row, columnBaitulMalFinance + 2].Value = item.BaitulMalFinanceData.Collection;
                    ws.Cells[row, columnBaitulMalFinance + 3].Value = item.BaitulMalFinanceData.Expense;
                    ws.Cells[row, columnBaitulMalFinance + 4].Value = item.BaitulMalFinanceData.NisabPaidToCentral;
                    ws.Cells[row, columnBaitulMalFinance + 5].Value = item.BaitulMalFinanceData.Balance;
                    ws.Cells[row, columnBaitulMalFinance + 6].Value = item.BaitulMalFinanceData.TotalIncreaseTarget;
                    ws.Cells[row, columnBaitulMalFinance + 7].Value = item.BaitulMalFinanceData.WorkerPromiseThisPeriod;
                    //$ a Day Masjid Project
                    ws.Cells[row, columnADayMasjidProjectFinance].Value = item.ADayMasjidProjectFinanceData.WorkerPromiseLastPeriod;
                    ws.Cells[row, columnADayMasjidProjectFinance + 1].Value = item.ADayMasjidProjectFinanceData.LastPeriod;
                    ws.Cells[row, columnADayMasjidProjectFinance + 2].Value = item.ADayMasjidProjectFinanceData.Collection;
                    ws.Cells[row, columnADayMasjidProjectFinance + 3].Value = item.ADayMasjidProjectFinanceData.Expense;
                    ws.Cells[row, columnADayMasjidProjectFinance + 4].Value = item.ADayMasjidProjectFinanceData.NisabPaidToCentral;
                    ws.Cells[row, columnADayMasjidProjectFinance + 5].Value = item.ADayMasjidProjectFinanceData.Balance;
                    ws.Cells[row, columnADayMasjidProjectFinance + 6].Value = item.ADayMasjidProjectFinanceData.TotalIncreaseTarget;
                    ws.Cells[row, columnADayMasjidProjectFinance + 7].Value = item.ADayMasjidProjectFinanceData.WorkerPromiseThisPeriod;
                    //Masjid Table Bank
                    ws.Cells[row, columnMasjidTableBankFinance].Value = item.MasjidTableBankFinanceData.WorkerPromiseLastPeriod;
                    ws.Cells[row, columnMasjidTableBankFinance + 1].Value = item.MasjidTableBankFinanceData.LastPeriod;
                    ws.Cells[row, columnMasjidTableBankFinance + 2].Value = item.MasjidTableBankFinanceData.Collection;
                    ws.Cells[row, columnMasjidTableBankFinance + 3].Value = item.MasjidTableBankFinanceData.Expense;
                    ws.Cells[row, columnMasjidTableBankFinance + 4].Value = item.MasjidTableBankFinanceData.NisabPaidToCentral;
                    ws.Cells[row, columnMasjidTableBankFinance + 5].Value = item.MasjidTableBankFinanceData.Balance;
                    ws.Cells[row, columnMasjidTableBankFinance + 6].Value = item.MasjidTableBankFinanceData.TotalIncreaseTarget;
                    ws.Cells[row, columnMasjidTableBankFinance + 7].Value = item.MasjidTableBankFinanceData.WorkerPromiseThisPeriod;

                    //Social Welfare
                    //Qard-e-Hasana
                    ws.Cells[row, columnQardeHasana].Value = item.QardeHasanaSocialWelfareData.Target;
                    ws.Cells[row, columnQardeHasana + 1].Value = item.QardeHasanaSocialWelfareData.Actual;
                    //Transport			
                    ws.Cells[row, columnTransport].Value = item.TransportSocialWelfareData.Target;
                    ws.Cells[row, columnTransport + 1].Value = item.TransportSocialWelfareData.Actual;
                    //Patient Visit
                    ws.Cells[row, columnPatientVisit].Value = item.PatientVisitSocialWelfareData.Target;
                    ws.Cells[row, columnPatientVisit + 1].Value = item.PatientVisitSocialWelfareData.Actual;
                    //Shifting			
                    ws.Cells[row, columnShifting].Value = item.ShiftingSocialWelfareData.Target;
                    ws.Cells[row, columnShifting + 1].Value = item.ShiftingSocialWelfareData.Actual;
                    //Social Visit
                    ws.Cells[row, columnSocialVisit].Value = item.SocialVisitSocialWelfareData.Target;
                    ws.Cells[row, columnSocialVisit + 1].Value = item.SocialVisitSocialWelfareData.Actual;
                    //Shopping
                    ws.Cells[row, columnShopping].Value = item.ShoppingSocialWelfareData.Target;
                    ws.Cells[row, columnShopping + 1].Value = item.ShoppingSocialWelfareData.Actual;
                    //Food Distribution
                    ws.Cells[row, columnFoodDistribution].Value = item.FoodDistributionSocialWelfareData.Target;
                    ws.Cells[row, columnFoodDistribution + 1].Value = item.FoodDistributionSocialWelfareData.Actual;
                    //Clean Up Austrailia
                    ws.Cells[row, columnOtherCleanUpAustralia].Value = item.CleanUpAustraliaSocialWelfareData.Target;
                    ws.Cells[row, columnOtherCleanUpAustralia + 1].Value = item.CleanUpAustraliaSocialWelfareData.Actual;
                    //Other			
                    ws.Cells[row, columnOtherSocialWelfare].Value = item.OtherSocialWelfareData.Target;
                    ws.Cells[row, columnOtherSocialWelfare + 1].Value = item.OtherSocialWelfareData.Actual;

                    if (!string.IsNullOrEmpty(item.Comment))
                    {
                        comments.Add(item.Comment);
                    }
                    row++;
                }

                ws.Cells[row + 1, 4].Value = "Total =";
                //Member Member
                ws.Cells[row + 1, columnMemberMember].Value = totalData.MemberMemberData.LastPeriod;
                ws.Cells[row + 1, columnMemberMember + 1].Value = totalData.MemberMemberData.UpgradeTarget;
                ws.Cells[row + 1, columnMemberMember + 2].Value = totalData.MemberMemberData.Increased;
                ws.Cells[row + 1, columnMemberMember + 3].Value = totalData.MemberMemberData.Decreased;
                ws.Cells[row + 1, columnMemberMember + 4].Value = totalData.MemberMemberData.ThisPeriod;
                //Associate Member
                ws.Cells[row + 1, columnAssociateMember].Value = totalData.AssociateMemberData.LastPeriod;
                ws.Cells[row + 1, columnAssociateMember + 1].Value = totalData.AssociateMemberData.UpgradeTarget;
                ws.Cells[row + 1, columnAssociateMember + 2].Value = totalData.AssociateMemberData.Increased;
                ws.Cells[row + 1, columnAssociateMember + 3].Value = totalData.AssociateMemberData.Decreased;
                ws.Cells[row + 1, columnAssociateMember + 4].Value = totalData.AssociateMemberData.ThisPeriod;
                //Preliminary Member
                ws.Cells[row + 1, columnPreliminaryMember].Value = totalData.PreliminaryMemberData.LastPeriod;
                ws.Cells[row + 1, columnPreliminaryMember + 1].Value = totalData.PreliminaryMemberData.UpgradeTarget;
                ws.Cells[row + 1, columnPreliminaryMember + 2].Value = totalData.PreliminaryMemberData.Increased;
                ws.Cells[row + 1, columnPreliminaryMember + 3].Value = totalData.PreliminaryMemberData.Decreased;
                ws.Cells[row + 1, columnPreliminaryMember + 4].Value = totalData.PreliminaryMemberData.ThisPeriod;
                //Supporter Member
                ws.Cells[row + 1, columnSupporterMember].Value = totalData.SupporterMemberData.LastPeriod;
                ws.Cells[row + 1, columnSupporterMember + 1].Value = totalData.SupporterMemberData.UpgradeTarget;
                ws.Cells[row + 1, columnSupporterMember + 2].Value = totalData.SupporterMemberData.Increased;
                ws.Cells[row + 1, columnSupporterMember + 3].Value = totalData.SupporterMemberData.Decreased;
                ws.Cells[row + 1, columnSupporterMember + 4].Value = totalData.SupporterMemberData.ThisPeriod;
                //CMS Meeting
                ws.Cells[row + 1, columnCmsMeeting].Value = totalData.CmsMeetingProgramData.Target;
                ws.Cells[row + 1, columnCmsMeeting + 1].Value = totalData.CmsMeetingProgramData.Actual;
                ws.Cells[row + 1, columnCmsMeeting + 2].Value = totalData.CmsMeetingProgramData.AverageAttendance;
                //SM Meeting
                ws.Cells[row + 1, columSmMeeting].Value = totalData.SmMeetingProgramData.Target;
                ws.Cells[row + 1, columSmMeeting + 1].Value = totalData.SmMeetingProgramData.Actual;
                ws.Cells[row + 1, columSmMeeting + 2].Value = totalData.SmMeetingProgramData.AverageAttendance;
                //Member Meeting
                ws.Cells[row + 1, columMemberMeeting].Value = totalData.MemberMeetingProgramData.Target;
                ws.Cells[row + 1, columMemberMeeting + 1].Value = totalData.MemberMeetingProgramData.Actual;
                ws.Cells[row + 1, columMemberMeeting + 2].Value = totalData.MemberMeetingProgramData.AverageAttendance;
                //Worker Meeting
                ws.Cells[row + 1, columnWorkerMeeting].Value = totalData.WorkerMeetingProgramData.Target;
                ws.Cells[row + 1, columnWorkerMeeting + 1].Value = totalData.WorkerMeetingProgramData.Actual;
                ws.Cells[row + 1, columnWorkerMeeting + 2].Value = totalData.WorkerMeetingProgramData.AverageAttendance;
                //Dawah Meeting
                ws.Cells[row + 1, columnDawahMeeting].Value = totalData.DawahMeetingProgramData.Target;
                ws.Cells[row + 1, columnDawahMeeting + 1].Value = totalData.DawahMeetingProgramData.Actual;
                ws.Cells[row + 1, columnDawahMeeting + 2].Value = totalData.DawahMeetingProgramData.AverageAttendance;
                //Learning Meeting
                ws.Cells[row + 1, columnLearningMeeting].Value = totalData.LearningMeetingProgramData.Target;
                ws.Cells[row + 1, columnLearningMeeting + 1].Value = totalData.LearningMeetingProgramData.Actual;
                ws.Cells[row + 1, columnLearningMeeting + 2].Value = totalData.LearningMeetingProgramData.AverageAttendance;
                //State - Leaders Meeting
                ws.Cells[row + 1, columnStateLeaderMeeting].Value = totalData.StateLeaderMeetingProgramData.Target;
                ws.Cells[row + 1, columnStateLeaderMeeting + 1].Value = totalData.StateLeaderMeetingProgramData.Actual;
                ws.Cells[row + 1, columnStateLeaderMeeting + 2].Value = totalData.StateLeaderMeetingProgramData.AverageAttendance;
                //Social Dawah Meeting
                ws.Cells[row + 1, columnSocialDawahMeeting].Value = totalData.SocialDawahMeetingProgramData.Target;
                ws.Cells[row + 1, columnSocialDawahMeeting + 1].Value = totalData.SocialDawahMeetingProgramData.Actual;
                ws.Cells[row + 1, columnSocialDawahMeeting + 2].Value = totalData.SocialDawahMeetingProgramData.AverageAttendance;
                //Tafsir Meeting
                ws.Cells[row + 1, columnTafsirMeetin].Value = totalData.TafsirMeetingProgramData.Target;
                ws.Cells[row + 1, columnTafsirMeetin + 1].Value = totalData.TafsirMeetingProgramData.Actual;
                ws.Cells[row + 1, columnTafsirMeetin + 2].Value = totalData.TafsirMeetingProgramData.AverageAttendance;
                //Other Meeting
                ws.Cells[row + 1, columnOtherMeeting].Value = totalData.OtherMeetingProgramData.Target;
                ws.Cells[row + 1, columnOtherMeeting + 1].Value = totalData.OtherMeetingProgramData.Actual;
                ws.Cells[row + 1, columnOtherMeeting + 2].Value = totalData.OtherMeetingProgramData.AverageAttendance;
                //Other Meeting
                ws.Cells[row + 1, columnOtherMeeting].Value = totalData.OtherMeetingProgramData.Target;
                ws.Cells[row + 1, columnOtherMeeting + 1].Value = totalData.OtherMeetingProgramData.Actual;
                ws.Cells[row + 1, columnOtherMeeting + 2].Value = totalData.OtherMeetingProgramData.AverageAttendance;
                //Dawah Group Meeting
                ws.Cells[row + 1, columnDawahGroupMeeting].Value = totalData.DawahGroupMeetingProgramData.Target;
                ws.Cells[row + 1, columnDawahGroupMeeting + 1].Value = totalData.DawahGroupMeetingProgramData.Actual;
                ws.Cells[row + 1, columnDawahGroupMeeting + 2].Value = totalData.DawahGroupMeetingProgramData.AverageAttendance;
                //Unit Meeting
                ws.Cells[row + 1, columnUnitMeeting].Value = totalData.UnitMeetingProgramData.Target;
                ws.Cells[row + 1, columnUnitMeeting + 1].Value = totalData.UnitMeetingProgramData.Actual;
                ws.Cells[row + 1, columnUnitMeeting + 2].Value = totalData.UnitMeetingProgramData.AverageAttendance;
                //Family Visit Meeting
                ws.Cells[row + 1, columnFamilyVisitMeeting].Value = totalData.FamilyVisitMeetingProgramData.Target;
                ws.Cells[row + 1, columnFamilyVisitMeeting + 1].Value = totalData.FamilyVisitMeetingProgramData.Actual;
                ws.Cells[row + 1, columnFamilyVisitMeeting + 2].Value = totalData.FamilyVisitMeetingProgramData.AverageAttendance;
                //Iftar Meeting
                ws.Cells[row + 1, columnIftarMeeting].Value = totalData.IftarMeetingProgramData.Target;
                ws.Cells[row + 1, columnIftarMeeting + 1].Value = totalData.IftarMeetingProgramData.Actual;
                ws.Cells[row + 1, columnIftarMeeting + 2].Value = totalData.IftarMeetingProgramData.AverageAttendance;
                //Eid Reunion Meeting
                ws.Cells[row + 1, columnEidReunionMeeting].Value = totalData.EidReunionMeetingProgramData.Target;
                ws.Cells[row + 1, columnEidReunionMeeting + 1].Value = totalData.EidReunionMeetingProgramData.Actual;
                ws.Cells[row + 1, columnEidReunionMeeting + 2].Value = totalData.EidReunionMeetingProgramData.AverageAttendance;
                //Eid Reunion Meeting
                ws.Cells[row + 1, columnBbqMeeting].Value = totalData.BbqMeetingProgramData.Target;
                ws.Cells[row + 1, columnBbqMeeting + 1].Value = totalData.BbqMeetingProgramData.Actual;
                ws.Cells[row + 1, columnBbqMeeting + 2].Value = totalData.BbqMeetingProgramData.AverageAttendance;
                //Bbq Meeting
                ws.Cells[row + 1, columnBbqMeeting].Value = totalData.BbqMeetingProgramData.Target;
                ws.Cells[row + 1, columnBbqMeeting + 1].Value = totalData.BbqMeetingProgramData.Actual;
                ws.Cells[row + 1, columnBbqMeeting + 2].Value = totalData.BbqMeetingProgramData.AverageAttendance;
                //State Outing Meeting
                ws.Cells[row + 1, columnStateOutingMeeting].Value = totalData.StateOutingMeetingProgramData.Target;
                ws.Cells[row + 1, columnStateOutingMeeting + 1].Value = totalData.StateOutingMeetingProgramData.Actual;
                ws.Cells[row + 1, columnStateOutingMeeting + 2].Value = totalData.StateOutingMeetingProgramData.AverageAttendance;
                //NextG Meeting
                ws.Cells[row + 1, columnNextGMeeting].Value = totalData.NextGMeetingProgramData.Target;
                ws.Cells[row + 1, columnNextGMeeting + 1].Value = totalData.NextGMeetingProgramData.Actual;
                ws.Cells[row + 1, columnNextGMeeting + 2].Value = totalData.NextGMeetingProgramData.AverageAttendance;
                //Gathering Meeting
                ws.Cells[row + 1, columnGatheringMeeting].Value = totalData.GatheringMeetingProgramData.Target;
                ws.Cells[row + 1, columnGatheringMeeting + 1].Value = totalData.GatheringMeetingProgramData.Actual;
                ws.Cells[row + 1, columnGatheringMeeting + 2].Value = totalData.GatheringMeetingProgramData.AverageAttendance;
                //Group Study Teaching Learning Program
                ws.Cells[row + 1, columnGroupStudy].Value = totalData.GroupStudyTeachingLearningProgramData.Target;
                ws.Cells[row + 1, columnGroupStudy + 1].Value = totalData.GroupStudyTeachingLearningProgramData.Actual;
                ws.Cells[row + 1, columnGroupStudy + 2].Value = totalData.GroupStudyTeachingLearningProgramData.AverageAttendance;
                //Study Circle For Associate Member Teaching Learning Program
                ws.Cells[row + 1, columnStudyCircleForAssociate].Value = totalData.StudyCircleForAssociateMemberTeachingLearningProgramData.Target;
                ws.Cells[row + 1, columnStudyCircleForAssociate + 1].Value = totalData.StudyCircleForAssociateMemberTeachingLearningProgramData.Actual;
                ws.Cells[row + 1, columnStudyCircleForAssociate + 2].Value = totalData.StudyCircleForAssociateMemberTeachingLearningProgramData.AverageAttendance;
                //Study Circle Teaching Learning Program
                ws.Cells[row + 1, columnStudyCircle].Value = totalData.StudyCircleTeachingLearningProgramData.Target;
                ws.Cells[row + 1, columnStudyCircle + 1].Value = totalData.StudyCircleTeachingLearningProgramData.Actual;
                ws.Cells[row + 1, columnStudyCircle + 2].Value = totalData.StudyCircleTeachingLearningProgramData.AverageAttendance;
                //Practice Dars Teaching Learning Program
                ws.Cells[row + 1, columnPracticeDars].Value = totalData.PracticeDarsTeachingLearningProgramData.Target;
                ws.Cells[row + 1, columnPracticeDars + 1].Value = totalData.PracticeDarsTeachingLearningProgramData.Actual;
                ws.Cells[row + 1, columnPracticeDars + 2].Value = totalData.PracticeDarsTeachingLearningProgramData.AverageAttendance;
                //State Learning Camp Teaching Learning Program
                ws.Cells[row + 1, columnStateLearningCamp].Value = totalData.StateLearningCampTeachingLearningProgramData.Target;
                ws.Cells[row + 1, columnStateLearningCamp + 1].Value = totalData.StateLearningCampTeachingLearningProgramData.Actual;
                ws.Cells[row + 1, columnStateLearningCamp + 2].Value = totalData.StateLearningCampTeachingLearningProgramData.AverageAttendance;
                //Quran Study Teaching Learning Program
                ws.Cells[row + 1, columnQuranStudy].Value = totalData.QuranStudyTeachingLearningProgramData.Target;
                ws.Cells[row + 1, columnQuranStudy + 1].Value = totalData.QuranStudyTeachingLearningProgramData.Actual;
                ws.Cells[row + 1, columnQuranStudy + 2].Value = totalData.QuranStudyTeachingLearningProgramData.AverageAttendance;
                //Hadith Study Teaching Learning Program
                ws.Cells[row + 1, columnHadithTeachingLearning].Value = totalData.HadithTeachingLearningProgramData.Target;
                ws.Cells[row + 1, columnHadithTeachingLearning + 1].Value = totalData.HadithTeachingLearningProgramData.Actual;
                ws.Cells[row + 1, columnHadithTeachingLearning + 2].Value = totalData.HadithTeachingLearningProgramData.AverageAttendance;
                //Quran Class Teaching Learning Program
                ws.Cells[row + 1, columnQuranClass].Value = totalData.QuranClassTeachingLearningProgramData.Target;
                ws.Cells[row + 1, columnQuranClass + 1].Value = totalData.QuranClassTeachingLearningProgramData.Actual;
                ws.Cells[row + 1, columnQuranClass + 2].Value = totalData.QuranClassTeachingLearningProgramData.AverageAttendance;
                //Weekend Islamic School Teaching Learning Program
                ws.Cells[row + 1, columnWeekendIslamicSchoolTeachingLearning].Value = totalData.WeekendIslamicSchoolTeachingLearningProgramData.Target;
                ws.Cells[row + 1, columnWeekendIslamicSchoolTeachingLearning + 1].Value = totalData.WeekendIslamicSchoolTeachingLearningProgramData.Actual;
                ws.Cells[row + 1, columnWeekendIslamicSchoolTeachingLearning + 2].Value = totalData.WeekendIslamicSchoolTeachingLearningProgramData.AverageAttendance;
                //Memorizing Ayat Teaching Learning Program
                ws.Cells[row + 1, columnMemorizingAyat].Value = totalData.MemorizingAyatTeachingLearningProgramData.Target;
                ws.Cells[row + 1, columnMemorizingAyat + 1].Value = totalData.MemorizingAyatTeachingLearningProgramData.Actual;
                ws.Cells[row + 1, columnMemorizingAyat + 2].Value = totalData.MemorizingAyatTeachingLearningProgramData.AverageAttendance;
                //Memorizing Hadith Teaching Learning Program
                ws.Cells[row + 1, columnMemorizingHadithTeachingLearning].Value = totalData.MemorizingHadithTeachingLearningProgramData.Target;
                ws.Cells[row + 1, columnMemorizingHadithTeachingLearning + 1].Value = totalData.MemorizingHadithTeachingLearningProgramData.Actual;
                ws.Cells[row + 1, columnMemorizingHadithTeachingLearning + 2].Value = totalData.MemorizingHadithTeachingLearningProgramData.AverageAttendance;
                //Memorizing Doa Teaching Learning Program
                ws.Cells[row + 1, columnMemorizingDoaTeachingLearning].Value = totalData.MemorizingDoaTeachingLearningProgramData.Target;
                ws.Cells[row + 1, columnMemorizingDoaTeachingLearning + 1].Value = totalData.MemorizingDoaTeachingLearningProgramData.Actual;
                ws.Cells[row + 1, columnMemorizingDoaTeachingLearning + 2].Value = totalData.MemorizingDoaTeachingLearningProgramData.AverageAttendance;
                //State Learning Session Teaching Learning Program
                ws.Cells[row + 1, columnStateLearningSession].Value = totalData.StateLearningSessionTeachingLearningProgramData.Target;
                ws.Cells[row + 1, columnStateLearningSession + 1].Value = totalData.StateLearningSessionTeachingLearningProgramData.Actual;
                ws.Cells[row + 1, columnStateLearningSession + 2].Value = totalData.StateLearningSessionTeachingLearningProgramData.AverageAttendance;
                //State QiyamulLail Learning Session Teaching Learning Program
                ws.Cells[row + 1, columnStateQiyamulLail].Value = totalData.StateQiyamulLailTeachingLearningProgramData.Target;
                ws.Cells[row + 1, columnStateQiyamulLail + 1].Value = totalData.StateQiyamulLailTeachingLearningProgramData.Actual;
                ws.Cells[row + 1, columnStateQiyamulLail + 2].Value = totalData.StateQiyamulLailTeachingLearningProgramData.AverageAttendance;
                //Other Teaching Learning Program
                ws.Cells[row + 1, columnOtherTeachingLearning].Value = totalData.OtherTeachingLearningProgramData.Target;
                ws.Cells[row + 1, columnOtherTeachingLearning + 1].Value = totalData.OtherTeachingLearningProgramData.Actual;
                ws.Cells[row + 1, columnOtherTeachingLearning + 2].Value = totalData.OtherTeachingLearningProgramData.AverageAttendance;
                //Book
                ws.Cells[row + 1, columnBookSaleDistributionMaterial].Value = totalData.BookDistributionMaterialData.Target;
                ws.Cells[row + 1, columnBookSaleDistributionMaterial + 1].Value = totalData.BookDistributionMaterialData.Actual;
                ws.Cells[row + 1, columnBookSaleMaterial].Value = totalData.BookSaleMaterialData.Target;
                ws.Cells[row + 1, columnBookSaleMaterial + 1].Value = totalData.BookSaleMaterialData.Actual;
                ws.Cells[row + 1, columnBookLibraryStock].Value = totalData.BookLibraryStockData.ThisPeriod;
                ws.Cells[row + 1, columnBookLibraryStock + 1].Value = totalData.BookLibraryStockData.Increased;
                ws.Cells[row + 1, columnBookLibraryStock + 2].Value = totalData.BookLibraryStockData.Decreased;
                //VHS/DVD/VCD/CD/Audio
                ws.Cells[row + 1, columnVhsDistributionMaterial].Value = totalData.VhsDistributionMaterialData.Target;
                ws.Cells[row + 1, columnVhsDistributionMaterial + 1].Value = totalData.VhsDistributionMaterialData.Actual;
                ws.Cells[row + 1, columnVhsSaleMaterial].Value = totalData.VhsSaleMaterialData.Target;
                ws.Cells[row + 1, columnVhsSaleMaterial + 1].Value = totalData.VhsSaleMaterialData.Actual;
                ws.Cells[row + 1, columnVhsLibraryStock].Value = totalData.VhsLibraryStockData.ThisPeriod;
                ws.Cells[row + 1, columnVhsLibraryStock + 1].Value = totalData.VhsLibraryStockData.Increased;
                ws.Cells[row + 1, columnVhsLibraryStock + 2].Value = totalData.VhsLibraryStockData.Decreased;
                //IPDC Leaflet
                ws.Cells[row + 1, columnIpdcLeaflet].Value = totalData.IpdcLeafletDistributionMaterialData.Target;
                ws.Cells[row + 1, columnIpdcLeaflet + 1].Value = totalData.IpdcLeafletDistributionMaterialData.Actual;
                //Email Distribution Material
                ws.Cells[row + 1, columnEmailDistribution].Value = totalData.EmailDistributionMaterialData.Target;
                ws.Cells[row + 1, columnEmailDistribution + 1].Value = totalData.EmailDistributionMaterialData.Actual;
                //Other Distribution Material
                ws.Cells[row + 1, columOtherMaterial].Value = totalData.OtherDistributionMaterialData.Target;
                ws.Cells[row + 1, columOtherMaterial + 1].Value = totalData.OtherDistributionMaterialData.Actual;
                ws.Cells[row + 1, columOtherLibraryStock].Value = totalData.OtherLibraryStockData.LastPeriod;
                ws.Cells[row + 1, columOtherLibraryStock + 1].Value = totalData.OtherLibraryStockData.Increased;
                ws.Cells[row + 1, columOtherLibraryStock + 2].Value = totalData.OtherLibraryStockData.Decreased;
                //Baitul Mal Finance
                ws.Cells[row + 1, columnBaitulMalFinance].Value = totalData.BaitulMalFinanceData.WorkerPromiseLastPeriod;
                ws.Cells[row + 1, columnBaitulMalFinance + 1].Value = totalData.BaitulMalFinanceData.LastPeriod;
                ws.Cells[row + 1, columnBaitulMalFinance + 2].Value = totalData.BaitulMalFinanceData.Collection;
                ws.Cells[row + 1, columnBaitulMalFinance + 3].Value = totalData.BaitulMalFinanceData.Expense;
                ws.Cells[row + 1, columnBaitulMalFinance + 4].Value = totalData.BaitulMalFinanceData.NisabPaidToCentral;
                ws.Cells[row + 1, columnBaitulMalFinance + 5].Value = totalData.BaitulMalFinanceData.Balance;
                ws.Cells[row + 1, columnBaitulMalFinance + 6].Value = totalData.BaitulMalFinanceData.TotalIncreaseTarget;
                ws.Cells[row + 1, columnBaitulMalFinance + 7].Value = totalData.BaitulMalFinanceData.WorkerPromiseThisPeriod;
                // a Day Masjid Project
                ws.Cells[row + 1, columnADayMasjidProjectFinance].Value = totalData.ADayMasjidProjectFinanceData.WorkerPromiseLastPeriod;
                ws.Cells[row + 1, columnADayMasjidProjectFinance + 1].Value = totalData.ADayMasjidProjectFinanceData.LastPeriod;
                ws.Cells[row + 1, columnADayMasjidProjectFinance + 2].Value = totalData.ADayMasjidProjectFinanceData.Collection;
                ws.Cells[row + 1, columnADayMasjidProjectFinance + 3].Value = totalData.ADayMasjidProjectFinanceData.Expense;
                ws.Cells[row + 1, columnADayMasjidProjectFinance + 4].Value = totalData.ADayMasjidProjectFinanceData.NisabPaidToCentral;
                ws.Cells[row + 1, columnADayMasjidProjectFinance + 5].Value = totalData.ADayMasjidProjectFinanceData.Balance;
                ws.Cells[row + 1, columnADayMasjidProjectFinance + 6].Value = totalData.ADayMasjidProjectFinanceData.TotalIncreaseTarget;
                ws.Cells[row + 1, columnADayMasjidProjectFinance + 7].Value = totalData.ADayMasjidProjectFinanceData.WorkerPromiseThisPeriod;
                // Masjid Table Bank
                ws.Cells[row + 1, columnMasjidTableBankFinance].Value = totalData.MasjidTableBankFinanceData.WorkerPromiseLastPeriod;
                ws.Cells[row + 1, columnMasjidTableBankFinance + 1].Value = totalData.MasjidTableBankFinanceData.LastPeriod;
                ws.Cells[row + 1, columnMasjidTableBankFinance + 2].Value = totalData.MasjidTableBankFinanceData.Collection;
                ws.Cells[row + 1, columnMasjidTableBankFinance + 3].Value = totalData.MasjidTableBankFinanceData.Expense;
                ws.Cells[row + 1, columnMasjidTableBankFinance + 4].Value = totalData.MasjidTableBankFinanceData.NisabPaidToCentral;
                ws.Cells[row + 1, columnMasjidTableBankFinance + 5].Value = totalData.MasjidTableBankFinanceData.Balance;
                ws.Cells[row + 1, columnMasjidTableBankFinance + 6].Value = totalData.MasjidTableBankFinanceData.TotalIncreaseTarget;
                ws.Cells[row + 1, columnMasjidTableBankFinance + 7].Value = totalData.MasjidTableBankFinanceData.WorkerPromiseThisPeriod;
                //Qarde Hasana Social Welfare
                ws.Cells[row + 1, columnQardeHasana].Value = totalData.QardeHasanaSocialWelfareData.Target;
                ws.Cells[row + 1, columnQardeHasana + 1].Value = totalData.QardeHasanaSocialWelfareData.Actual;
                //Transport
                ws.Cells[row + 1, columnTransport].Value = totalData.TransportSocialWelfareData.Target;
                ws.Cells[row + 1, columnTransport + 1].Value = totalData.TransportSocialWelfareData.Actual;
                //Patient Visit
                ws.Cells[row + 1, columnPatientVisit].Value = totalData.PatientVisitSocialWelfareData.Target;
                ws.Cells[row + 1, columnPatientVisit + 1].Value = totalData.PatientVisitSocialWelfareData.Actual;
                //Shifting
                ws.Cells[row + 1, columnShifting].Value = totalData.ShiftingSocialWelfareData.Target;
                ws.Cells[row + 1, columnShifting + 1].Value = totalData.ShiftingSocialWelfareData.Actual;
                //Social Visit
                ws.Cells[row + 1, columnSocialVisit].Value = totalData.SocialVisitSocialWelfareData.Target;
                ws.Cells[row + 1, columnSocialVisit + 1].Value = totalData.SocialVisitSocialWelfareData.Actual;
                //Shopping
                ws.Cells[row + 1, columnShopping].Value = totalData.ShoppingSocialWelfareData.Target;
                ws.Cells[row + 1, columnShopping + 1].Value = totalData.ShoppingSocialWelfareData.Actual;
                //Food Distribution
                ws.Cells[row + 1, columnFoodDistribution].Value = totalData.FoodDistributionSocialWelfareData.Target;
                ws.Cells[row + 1, columnFoodDistribution + 1].Value = totalData.FoodDistributionSocialWelfareData.Actual;
                //Clean Up Australia Social Welfare Data
                ws.Cells[row + 1, columnOtherCleanUpAustralia].Value = totalData.CleanUpAustraliaSocialWelfareData.Target;
                ws.Cells[row + 1, columnOtherCleanUpAustralia + 1].Value = totalData.CleanUpAustraliaSocialWelfareData.Actual;
                //Other
                ws.Cells[row + 1, columnOtherSocialWelfare].Value = totalData.OtherSocialWelfareData.Target;
                ws.Cells[row + 1, columnOtherSocialWelfare + 1].Value = totalData.OtherSocialWelfareData.Actual;
                #endregion

                #region Total Report worksheet
                // Total work sheet 

                //Member data
                int rowTotalMemberData = 8;
                int columnTotalMemberData = 2;

                //Associate Member data
                int rowTotalAssociateMemberData = 9;
                int columnTotalAssociateMemberData = 2;

                //Preliminary Member data
                int rowTotalPreliminaryMemberData = 10;
                int columnTotalPreliminaryMemberData = 2;

                //Supporter Member data
                int rowTotalSupporterMemberData = 11;
                int columnTotalSupporterMemberData = 2;

                //Regular & Special Meetings / Programs

                //CMS Meeting
                int rowTotalCMSMeetingProgramData = 15;
                int columnTotalCMSMeetingProgramData = 2;

                //SM Meeting
                int rowTotalSMMeetingProgramData = 16;
                int columnTotalSMMeetingProgramData = 2;

                //Member Meeting
                int rowTotalMemberMeetingProgramData = 17;
                int columnTotalMemberMeetingProgramData = 2;

                //Worker Meeting
                int rowTotalWorkerMeetingProgramData = 18;
                int columnTotalWorkerMeetingProgramData = 2;

                //Dawah Meeting
                int rowTotalDawahMeetingProgramData = 19;
                int columnTotalDawahMeetingProgramData = 2;

                //Learning Meeting
                int rowTotalLearningMeetingProgramData = 20;
                int columnTotalLearningMeetingProgramData = 2;

                //State - Leaders Meeting
                int rowTotalStateLeaderMeetingProgramData = 21;
                int columnTotalStateLeaderMeetingProgramData = 2;

                //Social Dawah Gathering
                int rowTotalSocialDawahMeetingProgramData = 22;
                int columnTotalSocialDawahMeetingProgramData = 2;

                //Tafsir	
                int rowTotalTafsirMeetingProgramData = 23;
                int columnTotalTafsirMeetingProgramData = 2;

                //Other(……..)
                int rowTotalOther_1 = 24;
                int columnTotalOther_1 = 2;

                //Dawah Group/Unit/Family Visits 	
                int rowTotalDawahGroup = 15;
                int columnTotalDawahGroup = 8;

                //Unit
                int rowTotalUnitmeeting = 16;
                int columnTotalUnitmeeting = 8;

                //Family Visits 	
                int rowTotalFamillyVisit = 17;
                int columnTotalFamillyVisit = 8;

                //Iftar/Eid Re-union/BBQ		
                int rowTotalIftarMeeting = 18;
                int columnTotalIftarMeeting = 8;

                //Eid Re-union		
                int rowTotalEidReunion = 19;
                int columnTotalEidReunion = 8;

                //BBQ
                int rowTotalBbqMeeting = 20;
                int columnTotalBbqMeeting = 8;

                //State - Outing		
                int rowTotalStateOuting = 21;
                int columnTotalStateOuting = 8;

                //NextG meeting
                int rowTotalNextG = 22;
                int columnTotalNextG = 8;

                //Gathering meeting
                int rowTotalGathering = 23;
                int columnTotalGathering = 8;

                //Teaching and Learning Programs
                //Group Study
                int rowTotalGroupStudy = 28;
                int columnTotalGroupStudy = 8;

                //Group Study / Study Circle (AM)
                int rowTotalStudyCircle = 29;
                int columnTotalStudyCircle = 2;

                //Study Circle (MEMBER, CMS)
                int rowTotalStudyCircleCMS = 30;
                int columnTotalStudyCircleCMS = 2;

                //Practice Dars/ Speech
                int rowTotalPracticeDars = 31;
                int columnTotalPracticeDars = 2;

                //Sate - Learning Camp (LC)
                int rowTotalStateLearningCamp = 32;
                int columnTotalStateLearningCamp = 2;

                //Quran Study
                int rowTotalQuranStudy = 33;
                int columnTotalrowQuranStudy = 2;

                //Hadith Study
                int rowTotalHadithStudy = 34;
                int columnTotalrowHadithStudy = 2;

                //Quran Class
                int rowTotalQuranClass = 28;
                int columnTotalQuranClass = 8;

                //Weekend Islamic School
                int rowTotalIslamicSchool = 29;
                int columnTotalIslamicSchool = 8;

                //Memorizing Ayat
                int rowTotalMemorizingAyat = 30;
                int columnTotalMemorizingAyat = 8;

                //Memorizing Hadith
                int rowTotalMemorizingHadit = 31;
                int columnTotalMemorizinghadit = 8;

                //Memorizing Doa
                int rowTotalMemorizingDoa = 32;
                int columnTotalMemorizingDoa = 8;

                //State - Learning Session (LS)
                int rowTotalStateLearningSession = 33;
                int columnTotalStateLearningSession = 8;

                //State - Qiyamul Lail
                int rowTotalStateQiyamulLail = 34;
                int columnTotalStateQiyamulLail = 8;

                //Other(……..)
                int rowTotalOther_3 = 35;
                int columnTotalOther_3 = 8;

                //Dawah Material Distribution & Unit Library Status
                //Book
                int rowTotalBookDistribution = 40;
                int columnTotalBookDistribution = 2;

                //VHS/DVD/VCD/CD/Audio
                int rowTotalVhsDistribution = 41;
                int columnTotalVhsDistribution = 2;

                //IPDC Leaflet
                int rowTotalIpdcLeafletDistribution = 42;
                int columnTotalIpdcLeafletDistribution = 2;

                //Other(Email/Others)
                int rowTotalEmailDistribution = 43;
                int columnTotalEmailDistribution = 2;

                //Other
                int rowTotalOthers = 44;
                int columnTotalOthers = 2;

                //Finance
                //Baitul-Mal
                int rowTotalBaitulMalFinance = 49;
                int columnTotalBaitulMalFinance = 2;

                //$ a Day Masjid Project
                int rowTotalADayMasjidProjectFinance = 50;
                int columnTotalADayMasjidProjectFinance = 2;

                //Masjid Table Bank
                int rowTotalMasjidTableBank = 51;
                int columnTotalMasjidTableBank = 2;

                //Social Welfare
                //Qard-e-Hasana
                int rowTotalQardeHasanaSocialWelfareData = 56;
                int columnTotalQardeHasanaSocialWelfareData = 3;

                //Transport	
                int rowTotalTransportSocialWelfareData = 56;
                int columnTotalTransportSocialWelfareData = 9;

                //Patient Visit
                int rowTotalPatientVisitSocialWelfareData = 57;
                int columnTotalPatientVisitSocialWelfareData = 3;

                //Shifting
                int rowTotalShiftingSocialWelfareData = 57;
                int columnTotalShiftingSocialWelfareData = 9;

                //Social Visit
                int rowTotalSocialVisitSocialWelfareData = 58;
                int columnTotalSocialVisitSocialWelfareData = 3;

                //Shopping
                int rowTotalShoppingSocialWelfareData = 58;
                int columnTotalShoppingSocialWelfareData = 9;

                //Food Distribution
                int rowTotalFoodDistributionSocialWelfareData = 59;
                int columnTotalFoodDistributionSocialWelfareData = 3;

                //Other
                int rowTotalOtherSocialWelfareData = 59;
                int columnTotalOtherSocialWelfareData = 9;

                //Comment
                int rowComments = 62;
                int columnReportComments = 1;

                //Member
                wsTotal.Cells[rowTotalMemberData, columnTotalMemberData].Value = totalData.MemberMemberData.LastPeriod;
                wsTotal.Cells[rowTotalMemberData, columnTotalMemberData + 1].Value = totalData.MemberMemberData.UpgradeTarget;
                wsTotal.Cells[rowTotalMemberData, columnTotalMemberData + 2].Value = totalData.MemberMemberData.Increased;
                wsTotal.Cells[rowTotalMemberData, columnTotalMemberData + 3].Value = totalData.MemberMemberData.Decreased;
                wsTotal.Cells[rowTotalMemberData, columnTotalMemberData + 4].Value = totalData.MemberMemberData.ThisPeriod;
                //Associate Member
                wsTotal.Cells[rowTotalAssociateMemberData, columnTotalAssociateMemberData].Value = totalData.AssociateMemberData.LastPeriod;
                wsTotal.Cells[rowTotalAssociateMemberData, columnTotalAssociateMemberData + 1].Value = totalData.AssociateMemberData.UpgradeTarget;
                wsTotal.Cells[rowTotalAssociateMemberData, columnTotalAssociateMemberData + 2].Value = totalData.AssociateMemberData.Increased;
                wsTotal.Cells[rowTotalAssociateMemberData, columnTotalAssociateMemberData + 3].Value = totalData.AssociateMemberData.Decreased;
                wsTotal.Cells[rowTotalAssociateMemberData, columnTotalAssociateMemberData + 4].Value = totalData.AssociateMemberData.ThisPeriod;
                //Preliminary Member
                wsTotal.Cells[rowTotalPreliminaryMemberData, columnTotalPreliminaryMemberData].Value = totalData.PreliminaryMemberData.LastPeriod;
                wsTotal.Cells[rowTotalPreliminaryMemberData, columnTotalPreliminaryMemberData + 1].Value = totalData.PreliminaryMemberData.UpgradeTarget;
                wsTotal.Cells[rowTotalPreliminaryMemberData, columnTotalPreliminaryMemberData + 2].Value = totalData.PreliminaryMemberData.Increased;
                wsTotal.Cells[rowTotalPreliminaryMemberData, columnTotalPreliminaryMemberData + 3].Value = totalData.PreliminaryMemberData.Decreased;
                wsTotal.Cells[rowTotalPreliminaryMemberData, columnTotalPreliminaryMemberData + 4].Value = totalData.PreliminaryMemberData.ThisPeriod;
                //Supporter Member data
                wsTotal.Cells[rowTotalSupporterMemberData, columnTotalSupporterMemberData].Value = totalData.SupporterMemberData.LastPeriod;
                wsTotal.Cells[rowTotalSupporterMemberData, columnTotalSupporterMemberData + 1].Value = totalData.SupporterMemberData.UpgradeTarget;
                wsTotal.Cells[rowTotalSupporterMemberData, columnTotalSupporterMemberData + 2].Value = totalData.SupporterMemberData.Increased;
                wsTotal.Cells[rowTotalSupporterMemberData, columnTotalSupporterMemberData + 3].Value = totalData.SupporterMemberData.Decreased;
                wsTotal.Cells[rowTotalSupporterMemberData, columnTotalSupporterMemberData + 4].Value = totalData.SupporterMemberData.ThisPeriod;
                //CMS Meeting
                wsTotal.Cells[rowTotalCMSMeetingProgramData, columnTotalCMSMeetingProgramData].Value = totalData.CmsMeetingProgramData.Target;
                wsTotal.Cells[rowTotalCMSMeetingProgramData, columnTotalCMSMeetingProgramData + 1].Value = totalData.CmsMeetingProgramData.Actual;
                wsTotal.Cells[rowTotalCMSMeetingProgramData, columnTotalCMSMeetingProgramData + 2].Value = totalData.CmsMeetingProgramData.AverageAttendance;
                //SM Meeting
                wsTotal.Cells[rowTotalSMMeetingProgramData, columnTotalSMMeetingProgramData].Value = totalData.SmMeetingProgramData.Target;
                wsTotal.Cells[rowTotalSMMeetingProgramData, columnTotalSMMeetingProgramData + 1].Value = totalData.SmMeetingProgramData.Actual;
                wsTotal.Cells[rowTotalSMMeetingProgramData, columnTotalSMMeetingProgramData + 2].Value = totalData.SmMeetingProgramData.AverageAttendance;
                ////Member Meeting
                wsTotal.Cells[rowTotalMemberMeetingProgramData, columnTotalMemberMeetingProgramData].Value = totalData.MemberMeetingProgramData.Target;
                wsTotal.Cells[rowTotalMemberMeetingProgramData, columnTotalMemberMeetingProgramData + 1].Value = totalData.MemberMeetingProgramData.Actual;
                wsTotal.Cells[rowTotalMemberMeetingProgramData, columnTotalMemberMeetingProgramData + 2].Value = totalData.MemberMeetingProgramData.AverageAttendance;
                //Worker Meeting
                wsTotal.Cells[rowTotalWorkerMeetingProgramData, columnTotalWorkerMeetingProgramData].Value = totalData.WorkerMeetingProgramData.Target;
                wsTotal.Cells[rowTotalWorkerMeetingProgramData, columnTotalWorkerMeetingProgramData + 1].Value = totalData.WorkerMeetingProgramData.Actual;
                wsTotal.Cells[rowTotalWorkerMeetingProgramData, columnTotalWorkerMeetingProgramData + 2].Value = totalData.WorkerMeetingProgramData.AverageAttendance;
                //Dawah Meeting
                wsTotal.Cells[rowTotalDawahMeetingProgramData, columnTotalDawahMeetingProgramData].Value = totalData.DawahMeetingProgramData.Target;
                wsTotal.Cells[rowTotalDawahMeetingProgramData, columnTotalDawahMeetingProgramData + 1].Value = totalData.DawahMeetingProgramData.Actual;
                wsTotal.Cells[rowTotalDawahMeetingProgramData, columnTotalDawahMeetingProgramData + 2].Value = totalData.DawahMeetingProgramData.AverageAttendance;
                //Learning Meeting
                wsTotal.Cells[rowTotalLearningMeetingProgramData, columnTotalLearningMeetingProgramData].Value = totalData.LearningMeetingProgramData.Target;
                wsTotal.Cells[rowTotalLearningMeetingProgramData, columnTotalLearningMeetingProgramData + 1].Value = totalData.LearningMeetingProgramData.Actual;
                wsTotal.Cells[rowTotalLearningMeetingProgramData, columnTotalLearningMeetingProgramData + 2].Value = totalData.LearningMeetingProgramData.AverageAttendance;
                //State - Leaders Meeting
                wsTotal.Cells[rowTotalStateLeaderMeetingProgramData, columnTotalStateLeaderMeetingProgramData].Value = totalData.StateLeaderMeetingProgramData.Target;
                wsTotal.Cells[rowTotalStateLeaderMeetingProgramData, columnTotalStateLeaderMeetingProgramData + 1].Value = totalData.StateLeaderMeetingProgramData.Actual;
                wsTotal.Cells[rowTotalStateLeaderMeetingProgramData, columnTotalStateLeaderMeetingProgramData + 2].Value = totalData.StateLeaderMeetingProgramData.AverageAttendance;
                //Social Dawah Gathering
                wsTotal.Cells[rowTotalSocialDawahMeetingProgramData, columnTotalSocialDawahMeetingProgramData].Value = totalData.SocialDawahMeetingProgramData.Target;
                wsTotal.Cells[rowTotalSocialDawahMeetingProgramData, columnTotalSocialDawahMeetingProgramData + 1].Value = totalData.SocialDawahMeetingProgramData.Actual;
                wsTotal.Cells[rowTotalSocialDawahMeetingProgramData, columnTotalSocialDawahMeetingProgramData + 2].Value = totalData.SocialDawahMeetingProgramData.AverageAttendance;
                //Tafsir Meeting
                wsTotal.Cells[rowTotalTafsirMeetingProgramData, columnTotalTafsirMeetingProgramData].Value = totalData.TafsirMeetingProgramData.Target;
                wsTotal.Cells[rowTotalTafsirMeetingProgramData, columnTotalTafsirMeetingProgramData + 1].Value = totalData.TafsirMeetingProgramData.Actual;
                wsTotal.Cells[rowTotalTafsirMeetingProgramData, columnTotalTafsirMeetingProgramData + 2].Value = totalData.TafsirMeetingProgramData.AverageAttendance;
                //Other Meeting
                wsTotal.Cells[rowTotalOther_1, columnTotalOther_1].Value = totalData.OtherMeetingProgramData.Target;
                wsTotal.Cells[rowTotalOther_1, columnTotalOther_1 + 1].Value = totalData.OtherMeetingProgramData.Actual;
                wsTotal.Cells[rowTotalOther_1, columnTotalOther_1 + 2].Value = totalData.OtherMeetingProgramData.AverageAttendance;
                //Dawah Group Program
                wsTotal.Cells[rowTotalDawahGroup, columnTotalDawahGroup].Value = totalData.DawahGroupMeetingProgramData.Target;
                wsTotal.Cells[rowTotalDawahGroup, columnTotalDawahGroup + 1].Value = totalData.DawahGroupMeetingProgramData.Actual;
                wsTotal.Cells[rowTotalDawahGroup, columnTotalDawahGroup + 2].Value = totalData.DawahGroupMeetingProgramData.AverageAttendance;
                //Unit Program
                wsTotal.Cells[rowTotalUnitmeeting, columnTotalUnitmeeting].Value = totalData.UnitMeetingProgramData.Target;
                wsTotal.Cells[rowTotalUnitmeeting, columnTotalUnitmeeting + 1].Value = totalData.UnitMeetingProgramData.Actual;
                wsTotal.Cells[rowTotalUnitmeeting, columnTotalUnitmeeting + 2].Value = totalData.UnitMeetingProgramData.AverageAttendance;
                //Family Visits Program
                wsTotal.Cells[rowTotalFamillyVisit, columnTotalFamillyVisit].Value = totalData.FamilyVisitMeetingProgramData.Target;
                wsTotal.Cells[rowTotalFamillyVisit, columnTotalFamillyVisit + 1].Value = totalData.FamilyVisitMeetingProgramData.Actual;
                wsTotal.Cells[rowTotalFamillyVisit, columnTotalFamillyVisit + 2].Value = totalData.FamilyVisitMeetingProgramData.AverageAttendance;
                //Iftar Program
                wsTotal.Cells[rowTotalIftarMeeting, columnTotalIftarMeeting].Value = totalData.IftarMeetingProgramData.Target;
                wsTotal.Cells[rowTotalIftarMeeting, columnTotalIftarMeeting + 1].Value = totalData.IftarMeetingProgramData.Actual;
                wsTotal.Cells[rowTotalIftarMeeting, columnTotalIftarMeeting + 2].Value = totalData.IftarMeetingProgramData.AverageAttendance;
                //Eid Re-union Program
                wsTotal.Cells[rowTotalEidReunion, columnTotalEidReunion].Value = totalData.EidReunionMeetingProgramData.Target;
                wsTotal.Cells[rowTotalEidReunion, columnTotalEidReunion + 1].Value = totalData.EidReunionMeetingProgramData.Actual;
                wsTotal.Cells[rowTotalEidReunion, columnTotalEidReunion + 2].Value = totalData.EidReunionMeetingProgramData.AverageAttendance;
                //BBQ Program
                wsTotal.Cells[rowTotalBbqMeeting, columnTotalBbqMeeting].Value = totalData.BbqMeetingProgramData.Target;
                wsTotal.Cells[rowTotalBbqMeeting, columnTotalBbqMeeting + 1].Value = totalData.BbqMeetingProgramData.Actual;
                wsTotal.Cells[rowTotalBbqMeeting, columnTotalBbqMeeting + 2].Value = totalData.BbqMeetingProgramData.AverageAttendance;
                //State - Outing Program
                wsTotal.Cells[rowTotalStateOuting, columnTotalStateOuting].Value = totalData.StateOutingMeetingProgramData.Target;
                wsTotal.Cells[rowTotalStateOuting, columnTotalStateOuting + 1].Value = totalData.StateOutingMeetingProgramData.Actual;
                wsTotal.Cells[rowTotalStateOuting, columnTotalStateOuting + 2].Value = totalData.StateOutingMeetingProgramData.AverageAttendance;
                //NextG meeting
                wsTotal.Cells[rowTotalNextG, columnTotalNextG].Value = totalData.NextGMeetingProgramData.Target;
                wsTotal.Cells[rowTotalNextG, columnTotalNextG + 1].Value = totalData.NextGMeetingProgramData.Actual;
                wsTotal.Cells[rowTotalNextG, columnTotalNextG + 2].Value = totalData.NextGMeetingProgramData.AverageAttendance;
                //Gathering meeting
                wsTotal.Cells[rowTotalGathering, columnTotalGathering].Value = totalData.GatheringMeetingProgramData.Target;
                wsTotal.Cells[rowTotalGathering, columnTotalGathering + 1].Value = totalData.GatheringMeetingProgramData.Actual;
                wsTotal.Cells[rowTotalGathering, columnTotalGathering + 2].Value = totalData.GatheringMeetingProgramData.AverageAttendance;
                //Teaching and Learning Programs
                //Group Study
                wsTotal.Cells[rowTotalGroupStudy, columnTotalGroupStudy].Value = totalData.GroupStudyTeachingLearningProgramData.Target;
                wsTotal.Cells[rowTotalGroupStudy, columnTotalGroupStudy + 1].Value = totalData.GroupStudyTeachingLearningProgramData.Actual;
                wsTotal.Cells[rowTotalGroupStudy, columnTotalGroupStudy + 2].Value = totalData.GroupStudyTeachingLearningProgramData.AverageAttendance;
                //Study Circle(AM)
                wsTotal.Cells[rowTotalStudyCircle, columnTotalStudyCircle].Value = totalData.StudyCircleForAssociateMemberTeachingLearningProgramData.Target;
                wsTotal.Cells[rowTotalStudyCircle, columnTotalStudyCircle + 1].Value = totalData.StudyCircleForAssociateMemberTeachingLearningProgramData.Actual;
                wsTotal.Cells[rowTotalStudyCircle, columnTotalStudyCircle + 2].Value = totalData.StudyCircleForAssociateMemberTeachingLearningProgramData.AverageAttendance;
                //Study Circle(MEMBER, CMS)
                wsTotal.Cells[rowTotalStudyCircleCMS, columnTotalStudyCircleCMS].Value = totalData.StudyCircleTeachingLearningProgramData.Target;
                wsTotal.Cells[rowTotalStudyCircleCMS, columnTotalStudyCircleCMS + 1].Value = totalData.StudyCircleTeachingLearningProgramData.Actual;
                wsTotal.Cells[rowTotalStudyCircleCMS, columnTotalStudyCircleCMS + 2].Value = totalData.StudyCircleTeachingLearningProgramData.AverageAttendance;
                //Practice Dars/ Speech
                wsTotal.Cells[rowTotalPracticeDars, columnTotalPracticeDars].Value = totalData.PracticeDarsTeachingLearningProgramData.Target;
                wsTotal.Cells[rowTotalPracticeDars, columnTotalPracticeDars + 1].Value = totalData.PracticeDarsTeachingLearningProgramData.Actual;
                wsTotal.Cells[rowTotalPracticeDars, columnTotalPracticeDars + 2].Value = totalData.PracticeDarsTeachingLearningProgramData.AverageAttendance;
                //Sate - Learning Camp (LC)
                wsTotal.Cells[rowTotalStateLearningCamp, columnTotalStateLearningCamp].Value = totalData.StateLearningCampTeachingLearningProgramData.Target;
                wsTotal.Cells[rowTotalStateLearningCamp, columnTotalStateLearningCamp + 1].Value = totalData.StateLearningCampTeachingLearningProgramData.Actual;
                wsTotal.Cells[rowTotalStateLearningCamp, columnTotalStateLearningCamp + 2].Value = totalData.StateLearningCampTeachingLearningProgramData.AverageAttendance;
                //Hadith Study
                wsTotal.Cells[rowTotalHadithStudy, columnTotalrowHadithStudy].Value = totalData.HadithTeachingLearningProgramData.Target;
                wsTotal.Cells[rowTotalHadithStudy, columnTotalrowHadithStudy + 1].Value = totalData.HadithTeachingLearningProgramData.Actual;
                wsTotal.Cells[rowTotalHadithStudy, columnTotalrowHadithStudy + 2].Value = totalData.HadithTeachingLearningProgramData.AverageAttendance;
                //Quran Study
                wsTotal.Cells[rowTotalQuranStudy, columnTotalrowQuranStudy].Value = totalData.QuranStudyTeachingLearningProgramData.Target;
                wsTotal.Cells[rowTotalQuranStudy, columnTotalrowQuranStudy + 1].Value = totalData.QuranStudyTeachingLearningProgramData.Actual;
                wsTotal.Cells[rowTotalQuranStudy, columnTotalrowQuranStudy + 2].Value = totalData.QuranStudyTeachingLearningProgramData.AverageAttendance;
                //Quran Class
                wsTotal.Cells[rowTotalQuranClass, columnTotalQuranClass].Value = totalData.QuranClassTeachingLearningProgramData.Target;
                wsTotal.Cells[rowTotalQuranClass, columnTotalQuranClass + 1].Value = totalData.QuranClassTeachingLearningProgramData.Actual;
                wsTotal.Cells[rowTotalQuranClass, columnTotalQuranClass + 2].Value = totalData.QuranClassTeachingLearningProgramData.AverageAttendance;
                //Weekend Islamic School
                wsTotal.Cells[rowTotalIslamicSchool, columnTotalIslamicSchool].Value = totalData.WeekendIslamicSchoolTeachingLearningProgramData.Target;
                wsTotal.Cells[rowTotalIslamicSchool, columnTotalIslamicSchool + 1].Value = totalData.WeekendIslamicSchoolTeachingLearningProgramData.Actual;
                wsTotal.Cells[rowTotalIslamicSchool, columnTotalIslamicSchool + 2].Value = totalData.WeekendIslamicSchoolTeachingLearningProgramData.AverageAttendance;
                //Memorizing Ayat
                wsTotal.Cells[rowTotalMemorizingAyat, columnTotalMemorizingAyat].Value = totalData.MemorizingAyatTeachingLearningProgramData.Target;
                wsTotal.Cells[rowTotalMemorizingAyat, columnTotalMemorizingAyat + 1].Value = totalData.MemorizingAyatTeachingLearningProgramData.Actual;
                wsTotal.Cells[rowTotalMemorizingAyat, columnTotalMemorizingAyat + 2].Value = totalData.MemorizingAyatTeachingLearningProgramData.AverageAttendance;
                //Memorizing Hadith
                wsTotal.Cells[rowTotalMemorizingHadit, columnTotalMemorizinghadit].Value = totalData.MemorizingHadithTeachingLearningProgramData.Target;
                wsTotal.Cells[rowTotalMemorizingHadit, columnTotalMemorizinghadit + 1].Value = totalData.MemorizingHadithTeachingLearningProgramData.Actual;
                wsTotal.Cells[rowTotalMemorizingHadit, columnTotalMemorizinghadit + 2].Value = totalData.MemorizingHadithTeachingLearningProgramData.AverageAttendance;
                //Memorizing Doa
                wsTotal.Cells[rowTotalMemorizingDoa, columnTotalMemorizingDoa].Value = totalData.MemorizingDoaTeachingLearningProgramData.Target;
                wsTotal.Cells[rowTotalMemorizingDoa, columnTotalMemorizingDoa + 1].Value = totalData.MemorizingDoaTeachingLearningProgramData.Actual;
                wsTotal.Cells[rowTotalMemorizingDoa, columnTotalMemorizingDoa + 2].Value = totalData.MemorizingDoaTeachingLearningProgramData.AverageAttendance;
                //State - Learning Session (LS)
                wsTotal.Cells[rowTotalStateLearningSession, columnTotalStateLearningSession].Value = totalData.StateLearningSessionTeachingLearningProgramData.Target;
                wsTotal.Cells[rowTotalStateLearningSession, columnTotalStateLearningSession + 1].Value = totalData.StateLearningSessionTeachingLearningProgramData.Actual;
                wsTotal.Cells[rowTotalStateLearningSession, columnTotalStateLearningSession + 2].Value = totalData.StateLearningSessionTeachingLearningProgramData.AverageAttendance;
                //State - Qiyamul Lail
                wsTotal.Cells[rowTotalStateQiyamulLail, columnTotalStateQiyamulLail].Value = totalData.StateQiyamulLailTeachingLearningProgramData.Target;
                wsTotal.Cells[rowTotalStateQiyamulLail, columnTotalStateQiyamulLail + 1].Value = totalData.StateQiyamulLailTeachingLearningProgramData.Actual;
                wsTotal.Cells[rowTotalStateQiyamulLail, columnTotalStateQiyamulLail + 2].Value = totalData.StateQiyamulLailTeachingLearningProgramData.AverageAttendance;
                //Other- Teaching and Learning Program
                wsTotal.Cells[rowTotalOther_3, columnTotalOther_3].Value = totalData.OtherTeachingLearningProgramData.Target;
                wsTotal.Cells[rowTotalOther_3, columnTotalOther_3 + 1].Value = totalData.OtherTeachingLearningProgramData.Actual;
                wsTotal.Cells[rowTotalOther_3, columnTotalOther_3 + 2].Value = totalData.OtherTeachingLearningProgramData.AverageAttendance;
                //Dawah Material Distribution & Unit Library Status
                //Book
                wsTotal.Cells[rowTotalBookDistribution, columnTotalBookDistribution].Value = totalData.BookDistributionMaterialData.Target;
                wsTotal.Cells[rowTotalBookDistribution, columnTotalBookDistribution + 1].Value = totalData.BookDistributionMaterialData.Actual;
                wsTotal.Cells[rowTotalBookDistribution, columnTotalBookDistribution + 2].Value = totalData.BookSaleMaterialData.Target;
                wsTotal.Cells[rowTotalBookDistribution, columnTotalBookDistribution + 3].Value = totalData.BookSaleMaterialData.Actual;
                wsTotal.Cells[rowTotalBookDistribution, columnTotalBookDistribution + 4].Value = totalData.BookLibraryStockData.LastPeriod;
                wsTotal.Cells[rowTotalBookDistribution, columnTotalBookDistribution + 5].Value = totalData.BookLibraryStockData.Increased;
                wsTotal.Cells[rowTotalBookDistribution, columnTotalBookDistribution + 6].Value = totalData.BookLibraryStockData.Decreased;
                //VHS/DVD/VCD/CD/Audio
                wsTotal.Cells[rowTotalVhsDistribution, columnTotalVhsDistribution].Value = totalData.VhsDistributionMaterialData.Target;
                wsTotal.Cells[rowTotalVhsDistribution, columnTotalVhsDistribution + 1].Value = totalData.VhsDistributionMaterialData.Actual;
                wsTotal.Cells[rowTotalVhsDistribution, columnTotalVhsDistribution + 2].Value = totalData.VhsSaleMaterialData.Target;
                wsTotal.Cells[rowTotalVhsDistribution, columnTotalVhsDistribution + 3].Value = totalData.VhsSaleMaterialData.Actual;
                wsTotal.Cells[rowTotalVhsDistribution, columnTotalVhsDistribution + 4].Value = totalData.VhsLibraryStockData.LastPeriod;
                wsTotal.Cells[rowTotalVhsDistribution, columnTotalVhsDistribution + 5].Value = totalData.VhsLibraryStockData.Increased;
                wsTotal.Cells[rowTotalVhsDistribution, columnTotalVhsDistribution + 6].Value = totalData.VhsLibraryStockData.Decreased;
                //IPDC Leaflet
                wsTotal.Cells[rowTotalIpdcLeafletDistribution, columnTotalIpdcLeafletDistribution].Value = totalData.IpdcLeafletDistributionMaterialData.Target;
                wsTotal.Cells[rowTotalIpdcLeafletDistribution, columnTotalIpdcLeafletDistribution + 1].Value = totalData.IpdcLeafletDistributionMaterialData.Actual;
                //Email
                wsTotal.Cells[rowTotalEmailDistribution, columnTotalEmailDistribution].Value = totalData.EmailDistributionMaterialData.Target;
                wsTotal.Cells[rowTotalEmailDistribution, columnTotalEmailDistribution + 1].Value = totalData.EmailDistributionMaterialData.Actual;
                //Other Material
                wsTotal.Cells[rowTotalOthers, columnTotalOthers].Value = totalData.OtherDistributionMaterialData.Target;
                wsTotal.Cells[rowTotalOthers, columnTotalOthers + 1].Value = totalData.OtherDistributionMaterialData.Actual;
                wsTotal.Cells[rowTotalOthers, columnTotalOthers + 4].Value = totalData.OtherLibraryStockData.LastPeriod;
                wsTotal.Cells[rowTotalOthers, columnTotalOthers + 5].Value = totalData.OtherLibraryStockData.Increased;
                wsTotal.Cells[rowTotalOthers, columnTotalOthers + 6].Value = totalData.OtherLibraryStockData.Decreased;
                //Finance
                //Baitul-Mal
                wsTotal.Cells[rowTotalBaitulMalFinance, columnTotalBaitulMalFinance].Value = totalData.BaitulMalFinanceData.WorkerPromiseLastPeriod;
                wsTotal.Cells[rowTotalBaitulMalFinance, columnTotalBaitulMalFinance + 1].Value = totalData.BaitulMalFinanceData.LastPeriod;
                wsTotal.Cells[rowTotalBaitulMalFinance, columnTotalBaitulMalFinance + 2].Value = totalData.BaitulMalFinanceData.Collection;
                wsTotal.Cells[rowTotalBaitulMalFinance, columnTotalBaitulMalFinance + 3].Value = totalData.BaitulMalFinanceData.Expense;
                wsTotal.Cells[rowTotalBaitulMalFinance, columnTotalBaitulMalFinance + 4].Value = totalData.BaitulMalFinanceData.NisabPaidToCentral;
                wsTotal.Cells[rowTotalBaitulMalFinance, columnTotalBaitulMalFinance + 6].Value = totalData.BaitulMalFinanceData.Balance;
                wsTotal.Cells[rowTotalBaitulMalFinance, columnTotalBaitulMalFinance + 7].Value = totalData.BaitulMalFinanceData.TotalIncreaseTarget;
                wsTotal.Cells[rowTotalBaitulMalFinance, columnTotalBaitulMalFinance + 8].Value = totalData.BaitulMalFinanceData.WorkerPromiseThisPeriod;
                //$ a Day Masjid Project
                wsTotal.Cells[rowTotalADayMasjidProjectFinance, columnTotalADayMasjidProjectFinance].Value = totalData.ADayMasjidProjectFinanceData.WorkerPromiseLastPeriod;
                wsTotal.Cells[rowTotalADayMasjidProjectFinance, columnTotalADayMasjidProjectFinance + 1].Value = totalData.ADayMasjidProjectFinanceData.LastPeriod;
                wsTotal.Cells[rowTotalADayMasjidProjectFinance, columnTotalADayMasjidProjectFinance + 2].Value = totalData.ADayMasjidProjectFinanceData.Collection;
                wsTotal.Cells[rowTotalADayMasjidProjectFinance, columnTotalADayMasjidProjectFinance + 3].Value = totalData.ADayMasjidProjectFinanceData.Expense;
                wsTotal.Cells[rowTotalADayMasjidProjectFinance, columnTotalADayMasjidProjectFinance + 4].Value = totalData.ADayMasjidProjectFinanceData.NisabPaidToCentral;
                wsTotal.Cells[rowTotalADayMasjidProjectFinance, columnTotalADayMasjidProjectFinance + 6].Value = totalData.ADayMasjidProjectFinanceData.Balance;
                wsTotal.Cells[rowTotalADayMasjidProjectFinance, columnTotalADayMasjidProjectFinance + 7].Value = totalData.ADayMasjidProjectFinanceData.TotalIncreaseTarget;
                wsTotal.Cells[rowTotalADayMasjidProjectFinance, columnTotalADayMasjidProjectFinance + 8].Value = totalData.ADayMasjidProjectFinanceData.WorkerPromiseThisPeriod;
                //Masjid Table Bank
                wsTotal.Cells[rowTotalMasjidTableBank, columnTotalMasjidTableBank].Value = totalData.MasjidTableBankFinanceData.WorkerPromiseLastPeriod;
                wsTotal.Cells[rowTotalMasjidTableBank, columnTotalMasjidTableBank + 1].Value = totalData.MasjidTableBankFinanceData.LastPeriod;
                wsTotal.Cells[rowTotalMasjidTableBank, columnTotalMasjidTableBank + 2].Value = totalData.MasjidTableBankFinanceData.Collection;
                wsTotal.Cells[rowTotalMasjidTableBank, columnTotalMasjidTableBank + 3].Value = totalData.MasjidTableBankFinanceData.Expense;
                wsTotal.Cells[rowTotalMasjidTableBank, columnTotalMasjidTableBank + 4].Value = totalData.MasjidTableBankFinanceData.NisabPaidToCentral;
                wsTotal.Cells[rowTotalMasjidTableBank, columnTotalMasjidTableBank + 6].Value = totalData.MasjidTableBankFinanceData.Balance;
                wsTotal.Cells[rowTotalMasjidTableBank, columnTotalMasjidTableBank + 7].Value = totalData.MasjidTableBankFinanceData.TotalIncreaseTarget;
                wsTotal.Cells[rowTotalMasjidTableBank, columnTotalMasjidTableBank + 8].Value = totalData.MasjidTableBankFinanceData.WorkerPromiseThisPeriod;
                //Social Welfare
                //Qard-e-Hasana
                wsTotal.Cells[rowTotalQardeHasanaSocialWelfareData, columnTotalQardeHasanaSocialWelfareData].Value = totalData.QardeHasanaSocialWelfareData.Target;
                wsTotal.Cells[rowTotalQardeHasanaSocialWelfareData, columnTotalQardeHasanaSocialWelfareData + 1].Value = totalData.QardeHasanaSocialWelfareData.Actual;
                //Patient Visit
                wsTotal.Cells[rowTotalPatientVisitSocialWelfareData, columnTotalPatientVisitSocialWelfareData].Value = totalData.PatientVisitSocialWelfareData.Target;
                wsTotal.Cells[rowTotalPatientVisitSocialWelfareData, columnTotalPatientVisitSocialWelfareData + 1].Value = totalData.PatientVisitSocialWelfareData.Actual;
                //Social Visit
                wsTotal.Cells[rowTotalSocialVisitSocialWelfareData, columnTotalSocialVisitSocialWelfareData].Value = totalData.SocialVisitSocialWelfareData.Target;
                wsTotal.Cells[rowTotalSocialVisitSocialWelfareData, columnTotalSocialVisitSocialWelfareData + 1].Value = totalData.SocialVisitSocialWelfareData.Actual;
                //Food Distribution
                wsTotal.Cells[rowTotalFoodDistributionSocialWelfareData, columnTotalFoodDistributionSocialWelfareData].Value = totalData.FoodDistributionSocialWelfareData.Target;
                wsTotal.Cells[rowTotalFoodDistributionSocialWelfareData, columnTotalFoodDistributionSocialWelfareData + 1].Value = totalData.FoodDistributionSocialWelfareData.Actual;
                //Transport
                wsTotal.Cells[rowTotalTransportSocialWelfareData, columnTotalTransportSocialWelfareData].Value = totalData.TransportSocialWelfareData.Target;
                wsTotal.Cells[rowTotalTransportSocialWelfareData, columnTotalTransportSocialWelfareData + 1].Value = totalData.TransportSocialWelfareData.Actual;
                //Shifting
                wsTotal.Cells[rowTotalShiftingSocialWelfareData, columnTotalShiftingSocialWelfareData].Value = totalData.ShiftingSocialWelfareData.Target;
                wsTotal.Cells[rowTotalShiftingSocialWelfareData, columnTotalShiftingSocialWelfareData + 1].Value = totalData.ShiftingSocialWelfareData.Actual;
                //Shopping
                wsTotal.Cells[rowTotalShoppingSocialWelfareData, columnTotalShoppingSocialWelfareData].Value = totalData.ShoppingSocialWelfareData.Target;
                wsTotal.Cells[rowTotalShoppingSocialWelfareData, columnTotalShoppingSocialWelfareData + 1].Value = totalData.ShoppingSocialWelfareData.Actual;
                //Other Social Walfare
                wsTotal.Cells[rowTotalOtherSocialWelfareData, columnTotalOtherSocialWelfareData].Value = totalData.OtherSocialWelfareData.Target;
                wsTotal.Cells[rowTotalOtherSocialWelfareData, columnTotalOtherSocialWelfareData + 1].Value = totalData.OtherSocialWelfareData.Actual;
                //Comment
                wsTotal.Cells[rowComments, columnReportComments].Value = string.Join(", ", comments);
                #endregion

                excel.SaveAs(stream);
                stream.Position = 0;
                return ReadFully(stream);
            }

        }

        private ExcelReportData GetConsolidated(SearchResult<ExcelReportData> data)
        {
            var onlyRecentUnitReports = GetRecentExcelReportDatas(data.Items, OrganizationType.Unit);
            var onlyRecentZoneReports = GetRecentExcelReportDatas(data.Items, OrganizationType.Zone);
            var onlyRecentStateReports = GetRecentExcelReportDatas(data.Items, OrganizationType.State);
            var onlyRecentCentralReports = GetRecentExcelReportDatas(data.Items, OrganizationType.Central);

            var allUnitReports = GetAllExcelReportDatas(data.Items, OrganizationType.Unit);
            var allZoneReports = GetAllExcelReportDatas(data.Items, OrganizationType.Zone);
            var allStateReports = GetAllExcelReportDatas(data.Items, OrganizationType.State);
            var allCentralReports = GetAllExcelReportDatas(data.Items, OrganizationType.Central);

            return ExcelReportDataCalculator.GetCalculatedExcelReportData(onlyRecentUnitReports, allUnitReports, onlyRecentZoneReports, allZoneReports, onlyRecentStateReports, allStateReports, onlyRecentCentralReports, allCentralReports);
         }

        public static ExcelReportData[] GetRecentExcelReportDatas(ExcelReportData[] items, OrganizationType organizationType)
        {
            var data = items.Where(o => o.Organization.OrganizationType == organizationType).Select(o => o).ToArray();

            return data.GroupBy(o => o.Organization.Id).Select(o =>
                                   o.OrderByDescending(r => r.ReportingPeriod.EndDate).First()
                                    ).ToArray();

        }

        public static ExcelReportData[] GetAllExcelReportDatas(ExcelReportData[] items, OrganizationType organizationType)
        {
            return items.Where(o => o.Organization.OrganizationType == organizationType).Select(o => o).ToArray();
        }
        private byte[] CreateExcelReport(ExcelReportData data)
        {
            const string resourceName = "NsbWeb.ReportingModule.Templates.IpdcReportDetailTemplate.xlsx";
            using (var stream = new MemoryStream())
            {
                Stream s = Assembly.GetAssembly(typeof(ExcelReportData)).GetManifestResourceStream(resourceName);

                var excel = new ExcelPackage(s);
                var ws = excel.Workbook.Worksheets["Report"];

                if (data != null)
                {
                    // 
                    ws.Cells[3, 2].Value = data.Organization.Description;//"NSW";
                    ws.Cells[4, 2].Value = data.Organization.Details;//"Abdul Goni Chowdhury";
                    ws.Cells[3, 10].Value = data.Description; //"Q1-Q3, 2019";
                    ws.Cells[4, 10].Value = data.Timestamp.ToLocalTime();//"Aug 30, 2019";

                    //Menpower & Personal Contact
                    //Member data

                    int rowMemberData = 8;
                    int columnMemberData = 1;
                    ws.Cells[rowMemberData, columnMemberData + 1].Value = data.MemberMemberData.LastPeriod;
                    ws.Cells[rowMemberData, columnMemberData + 2].Value = data.MemberMemberData.UpgradeTarget;
                    ws.Cells[rowMemberData, columnMemberData + 3].Value = data.MemberMemberData.Increased;
                    ws.Cells[rowMemberData, columnMemberData + 4].Value = data.MemberMemberData.Decreased;
                    ws.Cells[rowMemberData, columnMemberData + 5].Value = data.MemberMemberData.ThisPeriod;
                    ws.Cells[rowMemberData, columnMemberData + 6].Value = data.MemberMemberData.PersonalContact;
                    ws.Cells[rowMemberData, columnMemberData + 7].Value = data.MemberMemberData.Comment;
                    //Associate Member data


                    int rowAssociateMemberData = 9;
                    int columnAssociateMemberData = 1;
                    ws.Cells[rowAssociateMemberData, columnAssociateMemberData + 1].Value = data.AssociateMemberData.LastPeriod;
                    ws.Cells[rowAssociateMemberData, columnAssociateMemberData + 2].Value = data.AssociateMemberData.UpgradeTarget;
                    ws.Cells[rowAssociateMemberData, columnAssociateMemberData + 3].Value = data.AssociateMemberData.Increased;
                    ws.Cells[rowAssociateMemberData, columnAssociateMemberData + 4].Value = data.AssociateMemberData.Decreased;
                    ws.Cells[rowAssociateMemberData, columnAssociateMemberData + 5].Value = data.AssociateMemberData.ThisPeriod;
                    ws.Cells[rowAssociateMemberData, columnAssociateMemberData + 6].Value = data.AssociateMemberData.PersonalContact;
                    ws.Cells[rowAssociateMemberData, columnAssociateMemberData + 7].Value = data.AssociateMemberData.Comment;

                    //Preliminary Member data
                    int rowPreliminaryMemberData = 10;
                    int columnPreliminaryMemberData = 1;

                    ws.Cells[rowPreliminaryMemberData, columnPreliminaryMemberData + 1].Value = data.PreliminaryMemberData.LastPeriod;
                    ws.Cells[rowPreliminaryMemberData, columnPreliminaryMemberData + 2].Value = data.PreliminaryMemberData.UpgradeTarget;
                    ws.Cells[rowPreliminaryMemberData, columnPreliminaryMemberData + 3].Value = data.PreliminaryMemberData.Increased;
                    ws.Cells[rowPreliminaryMemberData, columnPreliminaryMemberData + 4].Value = data.PreliminaryMemberData.Decreased;
                    ws.Cells[rowPreliminaryMemberData, columnPreliminaryMemberData + 5].Value = data.PreliminaryMemberData.ThisPeriod;
                    ws.Cells[rowPreliminaryMemberData, columnPreliminaryMemberData + 6].Value = data.PreliminaryMemberData.PersonalContact;
                    ws.Cells[rowPreliminaryMemberData, columnPreliminaryMemberData + 7].Value = data.PreliminaryMemberData.Comment;

                    //Supporter Member data
                    int rowSupporterMemberData = 11;
                    int columnSupporterMemberData = 1;
                    ws.Cells[rowSupporterMemberData, columnSupporterMemberData + 1].Value = data.SupporterMemberData.LastPeriod;
                    ws.Cells[rowSupporterMemberData, columnSupporterMemberData + 2].Value = data.SupporterMemberData.UpgradeTarget;
                    ws.Cells[rowSupporterMemberData, columnSupporterMemberData + 3].Value = data.SupporterMemberData.Increased;
                    ws.Cells[rowSupporterMemberData, columnSupporterMemberData + 4].Value = data.SupporterMemberData.Decreased;
                    ws.Cells[rowSupporterMemberData, columnSupporterMemberData + 5].Value = data.SupporterMemberData.ThisPeriod;
                    ws.Cells[rowSupporterMemberData, columnSupporterMemberData + 6].Value = data.SupporterMemberData.PersonalContact;
                    ws.Cells[rowSupporterMemberData, columnSupporterMemberData + 7].Value = data.SupporterMemberData.Comment;

                    //Regular & Special Meetings / Programs

                    //CMS Meeting
                    int rowCMSMeetingProgramData = 15;
                    int columnCMSMeetingProgramData = 1;
                    ws.Cells[rowCMSMeetingProgramData, columnCMSMeetingProgramData + 1].Value = data.CmsMeetingProgramData.Target;
                    ws.Cells[rowCMSMeetingProgramData, columnCMSMeetingProgramData + 2].Value = data.CmsMeetingProgramData.Actual;
                    ws.Cells[rowCMSMeetingProgramData, columnCMSMeetingProgramData + 3].Value = data.CmsMeetingProgramData.AverageAttendance;
                    //SM Meeting
                    int rowSMMeetingProgramData = 16;
                    int columnSMMeetingProgramData = 1;
                    ws.Cells[rowSMMeetingProgramData, columnSMMeetingProgramData + 1].Value = data.SmMeetingProgramData.Target;
                    ws.Cells[rowSMMeetingProgramData, columnSMMeetingProgramData + 2].Value = data.SmMeetingProgramData.Actual;
                    ws.Cells[rowSMMeetingProgramData, columnSMMeetingProgramData + 3].Value = data.SmMeetingProgramData.AverageAttendance;
                    //Member Meeting
                    int rowMemberMeetingProgramData = 17;
                    int columnMemberMeetingProgramData = 1;
                    ws.Cells[rowMemberMeetingProgramData, columnMemberMeetingProgramData + 1].Value = data.MemberMeetingProgramData.Target;
                    ws.Cells[rowMemberMeetingProgramData, columnMemberMeetingProgramData + 2].Value = data.MemberMeetingProgramData.Actual;
                    ws.Cells[rowMemberMeetingProgramData, columnMemberMeetingProgramData + 3].Value = data.MemberMeetingProgramData.AverageAttendance;
                    //Worker Meeting
                    int rowWorkerMeetingProgramData = 18;
                    int columnWorkerMeetingProgramData = 1;
                    ws.Cells[rowWorkerMeetingProgramData, columnWorkerMeetingProgramData + 1].Value = data.WorkerMeetingProgramData.Target;
                    ws.Cells[rowWorkerMeetingProgramData, columnWorkerMeetingProgramData + 2].Value = data.WorkerMeetingProgramData.Actual;
                    ws.Cells[rowWorkerMeetingProgramData, columnWorkerMeetingProgramData + 3].Value = data.WorkerMeetingProgramData.AverageAttendance;
                    //Dawah Meeting
                    int rowDawahMeetingProgramData = 19;
                    int columnDawahMeetingProgramData = 1;
                    ws.Cells[rowDawahMeetingProgramData, columnDawahMeetingProgramData + 1].Value = data.DawahMeetingProgramData.Target;
                    ws.Cells[rowDawahMeetingProgramData, columnDawahMeetingProgramData + 2].Value = data.DawahMeetingProgramData.Actual;
                    ws.Cells[rowDawahMeetingProgramData, columnDawahMeetingProgramData + 3].Value = data.DawahMeetingProgramData.AverageAttendance;
                    //Learning Meeting
                    int rowLearningMeetingProgramData = 20;
                    int columnLearningMeetingProgramData = 1;
                    ws.Cells[rowLearningMeetingProgramData, columnLearningMeetingProgramData + 1].Value = data.LearningMeetingProgramData.Target;
                    ws.Cells[rowLearningMeetingProgramData, columnLearningMeetingProgramData + 2].Value = data.LearningMeetingProgramData.Actual;
                    ws.Cells[rowLearningMeetingProgramData, columnLearningMeetingProgramData + 3].Value = data.LearningMeetingProgramData.AverageAttendance;
                    //State - Leaders Meeting
                    int rowStateLeaderMeetingProgramData = 21;
                    int columnStateLeaderMeetingProgramData = 1;
                    ws.Cells[rowStateLeaderMeetingProgramData, columnStateLeaderMeetingProgramData + 1].Value = data.StateLeaderMeetingProgramData.Target;
                    ws.Cells[rowStateLeaderMeetingProgramData, columnStateLeaderMeetingProgramData + 2].Value = data.StateLeaderMeetingProgramData.Actual;
                    ws.Cells[rowStateLeaderMeetingProgramData, columnStateLeaderMeetingProgramData + 3].Value = data.StateLeaderMeetingProgramData.AverageAttendance;
                    //Social Dawah Gathering
                    int rowSocialDawahMeetingProgramData = 22;
                    int columnSocialDawahMeetingProgramData = 1;
                    ws.Cells[rowSocialDawahMeetingProgramData, columnSocialDawahMeetingProgramData + 1].Value = data.SocialDawahMeetingProgramData.Target;
                    ws.Cells[rowSocialDawahMeetingProgramData, columnSocialDawahMeetingProgramData + 2].Value = data.SocialDawahMeetingProgramData.Actual;
                    ws.Cells[rowSocialDawahMeetingProgramData, columnSocialDawahMeetingProgramData + 3].Value = data.SocialDawahMeetingProgramData.AverageAttendance;
                    //Tafsir	
                    int rowTafsirMeetingProgramData = 23;
                    int columnTafsirMeetingProgramData = 1;
                    ws.Cells[rowTafsirMeetingProgramData, columnTafsirMeetingProgramData + 1].Value = data.TafsirMeetingProgramData.Target;
                    ws.Cells[rowTafsirMeetingProgramData, columnTafsirMeetingProgramData + 2].Value = data.TafsirMeetingProgramData.Actual;
                    ws.Cells[rowTafsirMeetingProgramData, columnTafsirMeetingProgramData + 3].Value = data.TafsirMeetingProgramData.AverageAttendance;
                    //Other(……..)
                    int rowOther_1 = 24;
                    int columnOther_1 = 1;
                    ws.Cells[rowOther_1, columnOther_1 + 1].Value = data.OtherMeetingProgramData.Target;
                    ws.Cells[rowOther_1, columnOther_1 + 2].Value = data.OtherMeetingProgramData.Actual;
                    ws.Cells[rowOther_1, columnOther_1 + 3].Value = data.OtherMeetingProgramData.AverageAttendance;
                    //Dawah Group/Unit/Family Visits 	
                    int rowDawahGroup = 15;
                    int columnDawahGroup = 7;
                    ws.Cells[rowDawahGroup, columnDawahGroup + 1].Value = data.DawahGroupMeetingProgramData.Target;
                    ws.Cells[rowDawahGroup, columnDawahGroup + 2].Value = data.DawahGroupMeetingProgramData.Actual;
                    ws.Cells[rowDawahGroup, columnDawahGroup + 3].Value = data.DawahGroupMeetingProgramData.AverageAttendance;
                    //Unit
                    int rowUnitmeeting = 16;
                    int columnUnitmeeting = 7;
                    ws.Cells[rowUnitmeeting, columnUnitmeeting + 1].Value = data.UnitMeetingProgramData.Target;
                    ws.Cells[rowUnitmeeting, columnUnitmeeting + 2].Value = data.UnitMeetingProgramData.Actual;
                    ws.Cells[rowUnitmeeting, columnUnitmeeting + 3].Value = data.UnitMeetingProgramData.AverageAttendance;
                    //Family Visits 	
                    int rowFamillyVisit = 17;
                    int columnFamillyVisit = 7;
                    ws.Cells[rowFamillyVisit, columnFamillyVisit + 1].Value = data.FamilyVisitMeetingProgramData.Target;
                    ws.Cells[rowFamillyVisit, columnFamillyVisit + 2].Value = data.FamilyVisitMeetingProgramData.Actual;
                    ws.Cells[rowFamillyVisit, columnFamillyVisit + 3].Value = data.FamilyVisitMeetingProgramData.AverageAttendance;
                    //Iftar/Eid Re-union/BBQ		
                    int rowIftarMeeting = 18;
                    int columnIftarMeeting = 7;
                    ws.Cells[rowIftarMeeting, columnIftarMeeting + 1].Value = data.IftarMeetingProgramData.Target;
                    ws.Cells[rowIftarMeeting, columnIftarMeeting + 2].Value = data.IftarMeetingProgramData.Actual;
                    ws.Cells[rowIftarMeeting, columnIftarMeeting + 3].Value = data.IftarMeetingProgramData.AverageAttendance;
                    //Eid Re-union		
                    int rowEidReunion = 19;
                    int columnEidReunion = 7;
                    ws.Cells[rowEidReunion, columnEidReunion + 1].Value = data.IftarMeetingProgramData.Target;
                    ws.Cells[rowEidReunion, columnEidReunion + 2].Value = data.IftarMeetingProgramData.Actual;
                    ws.Cells[rowEidReunion, columnEidReunion + 3].Value = data.IftarMeetingProgramData.AverageAttendance;
                    //BBQ
                    int rowBbqMeeting = 20;
                    int columnBbqMeeting = 7;
                    ws.Cells[rowBbqMeeting, columnBbqMeeting + 1].Value = data.BbqMeetingProgramData.Target;
                    ws.Cells[rowBbqMeeting, columnBbqMeeting + 2].Value = data.BbqMeetingProgramData.Actual;
                    ws.Cells[rowBbqMeeting, columnBbqMeeting + 3].Value = data.BbqMeetingProgramData.AverageAttendance;
                    //State - Outing		
                    int rowStateOuting = 21;
                    int columnStateOuting = 7;
                    ws.Cells[rowStateOuting, columnStateOuting + 1].Value = data.StateOutingMeetingProgramData.Target;
                    ws.Cells[rowStateOuting, columnStateOuting + 2].Value = data.StateOutingMeetingProgramData.Actual;
                    ws.Cells[rowStateOuting, columnStateOuting + 3].Value = data.StateOutingMeetingProgramData.AverageAttendance;                    //NextG Meeting/Gathering
                    //NextG meeting
                    int rowNextG = 22;
                    int columnNextG = 7;
                    ws.Cells[rowNextG, columnNextG + 1].Value = data.NextGMeetingProgramData.Target;
                    ws.Cells[rowNextG, columnNextG + 2].Value = data.NextGMeetingProgramData.Actual;
                    ws.Cells[rowNextG, columnNextG + 3].Value = data.NextGMeetingProgramData.AverageAttendance;
                    //Gathering meeting
                    int rowGathering = 23;
                    int columnGathering = 7;
                    ws.Cells[rowGathering, columnGathering + 1].Value = data.GatheringMeetingProgramData.Target;
                    ws.Cells[rowGathering, columnGathering + 2].Value = data.GatheringMeetingProgramData.Actual;
                    ws.Cells[rowGathering, columnGathering + 3].Value = data.GatheringMeetingProgramData.AverageAttendance;

                    //Teaching and Learning Programs
                    //Group Study
                    int rowGroupStudy = 28;
                    int columnGroupStudy = 1;
                    ws.Cells[rowGroupStudy, columnGroupStudy + 1].Value = data.GroupStudyTeachingLearningProgramData.Target;
                    ws.Cells[rowGroupStudy, columnGroupStudy + 2].Value = data.GroupStudyTeachingLearningProgramData.Actual;
                    ws.Cells[rowGroupStudy, columnGroupStudy + 3].Value = data.GroupStudyTeachingLearningProgramData.AverageAttendance;
                    //Group Study / Study Circle (AM)
                    int rowStudyCircle = 29;
                    int columnStudyCircle = 1;
                    ws.Cells[rowStudyCircle, columnStudyCircle + 1].Value = data.StudyCircleForAssociateMemberTeachingLearningProgramData.Target;
                    ws.Cells[rowStudyCircle, columnStudyCircle + 2].Value = data.StudyCircleForAssociateMemberTeachingLearningProgramData.Actual;
                    ws.Cells[rowStudyCircle, columnStudyCircle + 3].Value = data.StudyCircleForAssociateMemberTeachingLearningProgramData.AverageAttendance;
                    //Study Circle (MEMBER, CMS)
                    int rowStudyCircleCMS = 30;
                    int columnStudyCircleCMS = 1;
                    ws.Cells[rowStudyCircleCMS, columnStudyCircleCMS + 1].Value = data.StudyCircleTeachingLearningProgramData.Target;
                    ws.Cells[rowStudyCircleCMS, columnStudyCircleCMS + 2].Value = data.StudyCircleTeachingLearningProgramData.Actual;
                    ws.Cells[rowStudyCircleCMS, columnStudyCircleCMS + 3].Value = data.StudyCircleTeachingLearningProgramData.AverageAttendance;
                    //Practice Dars/ Speech
                    int rowPracticeDars = 31;
                    int columnPracticeDars = 1;
                    ws.Cells[rowPracticeDars, columnPracticeDars + 1].Value = data.PracticeDarsTeachingLearningProgramData.Target;
                    ws.Cells[rowPracticeDars, columnPracticeDars + 2].Value = data.PracticeDarsTeachingLearningProgramData.Actual;
                    ws.Cells[rowPracticeDars, columnPracticeDars + 3].Value = data.PracticeDarsTeachingLearningProgramData.AverageAttendance;
                    //Sate - Learning Camp (LC)
                    int rowStateLearningCamp = 32;
                    int columnStateLearningCamp = 1;
                    ws.Cells[rowStateLearningCamp, columnStateLearningCamp + 1].Value = data.StateLearningCampTeachingLearningProgramData.Target;
                    ws.Cells[rowStateLearningCamp, columnStateLearningCamp + 2].Value = data.StateLearningCampTeachingLearningProgramData.Actual;
                    ws.Cells[rowStateLearningCamp, columnStateLearningCamp + 3].Value = data.StateLearningCampTeachingLearningProgramData.AverageAttendance;
                    //Quran Study
                    int rowQuranStudy = 33;
                    int columnrowQuranStudy = 1;
                    ws.Cells[rowQuranStudy, columnrowQuranStudy + 1].Value = data.QuranStudyTeachingLearningProgramData.Target;
                    ws.Cells[rowQuranStudy, columnrowQuranStudy + 2].Value = data.QuranStudyTeachingLearningProgramData.Actual;
                    ws.Cells[rowQuranStudy, columnrowQuranStudy + 3].Value = data.QuranStudyTeachingLearningProgramData.AverageAttendance;
                    //Hadith Study
                    int rowHadithStudy = 34;
                    int columnrowHadithStudy = 1;
                    ws.Cells[rowHadithStudy, columnrowHadithStudy + 1].Value = data.HadithTeachingLearningProgramData.Target;
                    ws.Cells[rowHadithStudy, columnrowHadithStudy + 2].Value = data.HadithTeachingLearningProgramData.Actual;
                    ws.Cells[rowHadithStudy, columnrowHadithStudy + 3].Value = data.HadithTeachingLearningProgramData.AverageAttendance;
                    //Quran Class
                    int rowQuranClass = 28;
                    int columnQuranClass = 7;
                    ws.Cells[rowQuranClass, columnQuranClass + 1].Value = data.QuranClassTeachingLearningProgramData.Target;
                    ws.Cells[rowQuranClass, columnQuranClass + 2].Value = data.QuranClassTeachingLearningProgramData.Actual;
                    ws.Cells[rowQuranClass, columnQuranClass + 3].Value = data.QuranClassTeachingLearningProgramData.AverageAttendance;
                    //Weekend Islamic School
                    int rowIslamicSchool = 29;
                    int columnIslamicSchool = 7;
                    ws.Cells[rowIslamicSchool, columnIslamicSchool + 1].Value = data.WeekendIslamicSchoolTeachingLearningProgramData.Target;
                    ws.Cells[rowIslamicSchool, columnIslamicSchool + 2].Value = data.WeekendIslamicSchoolTeachingLearningProgramData.Actual;
                    ws.Cells[rowIslamicSchool, columnIslamicSchool + 3].Value = data.WeekendIslamicSchoolTeachingLearningProgramData.AverageAttendance;
                    //Memorizing Ayat
                    int rowMemorizingAyat = 30;
                    int columnMemorizingAyat = 7;
                    ws.Cells[rowMemorizingAyat, columnMemorizingAyat + 1].Value = data.MemorizingAyatTeachingLearningProgramData.Target;
                    ws.Cells[rowMemorizingAyat, columnMemorizingAyat + 2].Value = data.MemorizingAyatTeachingLearningProgramData.Actual;
                    ws.Cells[rowMemorizingAyat, columnMemorizingAyat + 3].Value = data.MemorizingAyatTeachingLearningProgramData.AverageAttendance;
                    //Memorizing Hadith
                    int rowMemorizingHadit = 31;
                    int columnMemorizinghadit = 7;
                    ws.Cells[rowMemorizingHadit, columnMemorizinghadit + 1].Value = data.MemorizingHadithTeachingLearningProgramData.Target;
                    ws.Cells[rowMemorizingHadit, columnMemorizinghadit + 2].Value = data.MemorizingHadithTeachingLearningProgramData.Actual;
                    ws.Cells[rowMemorizingHadit, columnMemorizinghadit + 3].Value = data.MemorizingHadithTeachingLearningProgramData.AverageAttendance;
                    //Memorizing Doa
                    int rowMemorizingDoa = 32;
                    int columnMemorizingDoa = 7;
                    ws.Cells[rowMemorizingDoa, columnMemorizingDoa + 1].Value = data.MemorizingDoaTeachingLearningProgramData.Target;
                    ws.Cells[rowMemorizingDoa, columnMemorizingDoa + 2].Value = data.MemorizingDoaTeachingLearningProgramData.Actual;
                    ws.Cells[rowMemorizingDoa, columnMemorizingDoa + 3].Value = data.MemorizingDoaTeachingLearningProgramData.AverageAttendance;
                    //State - Learning Session (LS)
                    int rowStateLearningSession = 33;
                    int columnStateLearningSession = 7;
                    ws.Cells[rowStateLearningSession, columnStateLearningSession + 1].Value = data.StateLearningSessionTeachingLearningProgramData.Target;
                    ws.Cells[rowStateLearningSession, columnStateLearningSession + 2].Value = data.StateLearningSessionTeachingLearningProgramData.Actual;
                    ws.Cells[rowStateLearningSession, columnStateLearningSession + 3].Value = data.StateLearningSessionTeachingLearningProgramData.AverageAttendance;
                    //State - Qiyamul Lail
                    int rowStateQiyamulLail = 34;
                    int columnStateQiyamulLail = 7;
                    ws.Cells[rowStateQiyamulLail, columnStateQiyamulLail + 1].Value = data.StateQiyamulLailTeachingLearningProgramData.Target;
                    ws.Cells[rowStateQiyamulLail, columnStateQiyamulLail + 2].Value = data.StateQiyamulLailTeachingLearningProgramData.Actual;
                    ws.Cells[rowStateQiyamulLail, columnStateQiyamulLail + 3].Value = data.StateQiyamulLailTeachingLearningProgramData.AverageAttendance;
                    //Other(……..)
                    int rowOther_3 = 35;
                    int columnOther_3 = 7;
                    ws.Cells[rowOther_3, columnOther_3 + 1].Value = data.OtherTeachingLearningProgramData.Target;
                    ws.Cells[rowOther_3, columnOther_3 + 2].Value = data.OtherTeachingLearningProgramData.Actual;
                    ws.Cells[rowOther_3, columnOther_3 + 3].Value = data.OtherTeachingLearningProgramData.AverageAttendance;

                    //Dawah Material Distribution & Unit Library Status
                    //Book
                    int rowBookDistribution = 40;
                    int columnBookDistribution = 1;
                    ws.Cells[rowBookDistribution, columnBookDistribution + 1].Value = data.BookDistributionMaterialData.Target;
                    ws.Cells[rowBookDistribution, columnBookDistribution + 2].Value = data.BookDistributionMaterialData.Actual;
                    ws.Cells[rowBookDistribution, columnBookDistribution + 3].Value = data.BookSaleMaterialData.Target;
                    ws.Cells[rowBookDistribution, columnBookDistribution + 4].Value = data.BookSaleMaterialData.Actual;
                    ws.Cells[rowBookDistribution, columnBookDistribution + 5].Value = data.BookLibraryStockData.LastPeriod;
                    ws.Cells[rowBookDistribution, columnBookDistribution + 6].Value = data.BookLibraryStockData.Increased;
                    ws.Cells[rowBookDistribution, columnBookDistribution + 7].Value = data.BookLibraryStockData.Decreased;
                    //VHS/DVD/VCD/CD/Audio
                    int rowVhsDistribution = 41;
                    int columnVhsDistribution = 1;
                    ws.Cells[rowVhsDistribution, columnVhsDistribution + 1].Value = data.VhsDistributionMaterialData.Target;
                    ws.Cells[rowVhsDistribution, columnVhsDistribution + 2].Value = data.VhsDistributionMaterialData.Actual;
                    ws.Cells[rowVhsDistribution, columnVhsDistribution + 3].Value = data.VhsSaleMaterialData.Target;
                    ws.Cells[rowVhsDistribution, columnVhsDistribution + 4].Value = data.VhsSaleMaterialData.Actual;
                    ws.Cells[rowVhsDistribution, columnVhsDistribution + 5].Value = data.VhsLibraryStockData.LastPeriod;
                    ws.Cells[rowVhsDistribution, columnVhsDistribution + 6].Value = data.VhsLibraryStockData.Increased;
                    ws.Cells[rowVhsDistribution, columnVhsDistribution + 7].Value = data.VhsLibraryStockData.Decreased;
                    //IPDC Leaflet
                    int rowIpdcLeafletDistribution = 42;
                    int columnIpdcLeafletDistribution = 1;
                    ws.Cells[rowIpdcLeafletDistribution, columnIpdcLeafletDistribution + 1].Value = data.IpdcLeafletDistributionMaterialData.Target;
                    ws.Cells[rowIpdcLeafletDistribution, columnIpdcLeafletDistribution + 2].Value = data.IpdcLeafletDistributionMaterialData.Actual;
                    ws.Cells[rowIpdcLeafletDistribution, columnIpdcLeafletDistribution + 3].Value = null;
                    ws.Cells[rowIpdcLeafletDistribution, columnIpdcLeafletDistribution + 4].Value = null;
                    ws.Cells[rowIpdcLeafletDistribution, columnIpdcLeafletDistribution + 5].Value = null;
                    ws.Cells[rowIpdcLeafletDistribution, columnIpdcLeafletDistribution + 6].Value = null;
                    ws.Cells[rowIpdcLeafletDistribution, columnIpdcLeafletDistribution + 7].Value = null;
                    //Other(Email/Others)
                    int rowEmailDistribution = 43;
                    int columnEmailDistribution = 1;
                    ws.Cells[rowEmailDistribution, columnEmailDistribution + 1].Value = data.EmailDistributionMaterialData.Target;
                    ws.Cells[rowEmailDistribution, columnEmailDistribution + 2].Value = data.EmailDistributionMaterialData.Actual;
                    ws.Cells[rowEmailDistribution, columnEmailDistribution + 3].Value = null;
                    ws.Cells[rowEmailDistribution, columnEmailDistribution + 4].Value = null;
                    ws.Cells[rowEmailDistribution, columnEmailDistribution + 5].Value = null;
                    ws.Cells[rowEmailDistribution, columnEmailDistribution + 6].Value = null;
                    ws.Cells[rowEmailDistribution, columnEmailDistribution + 7].Value = null;
                    //Other
                    int rowOthers = 44;
                    int columnOthers = 1;
                    ws.Cells[rowOthers, columnOthers + 1].Value = data.EmailDistributionMaterialData.Target;
                    ws.Cells[rowOthers, columnOthers + 2].Value = data.EmailDistributionMaterialData.Actual;
                    ws.Cells[rowOthers, columnOthers + 3].Value = null;
                    ws.Cells[rowOthers, columnOthers + 4].Value = null;
                    ws.Cells[rowOthers, columnOthers + 5].Value = data.OtherLibraryStockData.LastPeriod;
                    ws.Cells[rowOthers, columnOthers + 6].Value = data.OtherLibraryStockData.Increased;
                    ws.Cells[rowOthers, columnOthers + 7].Value = data.OtherLibraryStockData.Decreased;

                    //Finance
                    //Baitul-Mal
                    int rowBaitulMalFinance = 49;
                    int columnBaitulMalFinance = 1;
                    ws.Cells[rowBaitulMalFinance, columnBaitulMalFinance + 1].Value = data.BaitulMalFinanceData.WorkerPromiseLastPeriod;
                    ws.Cells[rowBaitulMalFinance, columnBaitulMalFinance + 2].Value = data.BaitulMalFinanceData.LastPeriod;
                    ws.Cells[rowBaitulMalFinance, columnBaitulMalFinance + 3].Value = data.BaitulMalFinanceData.Collection;
                    ws.Cells[rowBaitulMalFinance, columnBaitulMalFinance + 4].Value = data.BaitulMalFinanceData.Expense;
                    ws.Cells[rowBaitulMalFinance, columnBaitulMalFinance + 5].Value = data.BaitulMalFinanceData.NisabPaidToCentral;
                    ws.Cells[rowBaitulMalFinance, columnBaitulMalFinance + 7].Value = data.BaitulMalFinanceData.Balance;
                    ws.Cells[rowBaitulMalFinance, columnBaitulMalFinance + 8].Value = data.BaitulMalFinanceData.TotalIncreaseTarget;
                    ws.Cells[rowBaitulMalFinance, columnBaitulMalFinance + 9].Value = data.BaitulMalFinanceData.WorkerPromiseThisPeriod;
                    //$ a Day Masjid Project
                    int rowADayMasjidProjectFinance = 50;
                    int columnADayMasjidProjectFinance = 1;
                    ws.Cells[rowADayMasjidProjectFinance, columnADayMasjidProjectFinance + 1].Value = data.ADayMasjidProjectFinanceData.WorkerPromiseLastPeriod;
                    ws.Cells[rowADayMasjidProjectFinance, columnADayMasjidProjectFinance + 2].Value = data.ADayMasjidProjectFinanceData.LastPeriod;
                    ws.Cells[rowADayMasjidProjectFinance, columnADayMasjidProjectFinance + 3].Value = data.ADayMasjidProjectFinanceData.Collection;
                    ws.Cells[rowADayMasjidProjectFinance, columnADayMasjidProjectFinance + 4].Value = data.ADayMasjidProjectFinanceData.Expense;
                    ws.Cells[rowADayMasjidProjectFinance, columnADayMasjidProjectFinance + 5].Value = data.ADayMasjidProjectFinanceData.NisabPaidToCentral;
                    ws.Cells[rowADayMasjidProjectFinance, columnADayMasjidProjectFinance + 7].Value = data.ADayMasjidProjectFinanceData.Balance;
                    ws.Cells[rowADayMasjidProjectFinance, columnADayMasjidProjectFinance + 8].Value = data.ADayMasjidProjectFinanceData.TotalIncreaseTarget;
                    ws.Cells[rowADayMasjidProjectFinance, columnADayMasjidProjectFinance + 9].Value = data.ADayMasjidProjectFinanceData.WorkerPromiseThisPeriod;
                    //Masjid Table Bank
                    int rowMasjidTableBank = 51;
                    int columnMasjidTableBank = 1;
                    ws.Cells[rowMasjidTableBank, columnMasjidTableBank + 1].Value = data.MasjidTableBankFinanceData.WorkerPromiseLastPeriod;
                    ws.Cells[rowMasjidTableBank, columnMasjidTableBank + 2].Value = data.MasjidTableBankFinanceData.LastPeriod;
                    ws.Cells[rowMasjidTableBank, columnMasjidTableBank + 3].Value = data.MasjidTableBankFinanceData.Collection;
                    ws.Cells[rowMasjidTableBank, columnMasjidTableBank + 4].Value = data.MasjidTableBankFinanceData.Expense;
                    ws.Cells[rowMasjidTableBank, columnMasjidTableBank + 5].Value = data.MasjidTableBankFinanceData.NisabPaidToCentral;
                    ws.Cells[rowMasjidTableBank, columnMasjidTableBank + 7].Value = data.MasjidTableBankFinanceData.Balance;
                    ws.Cells[rowMasjidTableBank, columnMasjidTableBank + 8].Value = data.MasjidTableBankFinanceData.TotalIncreaseTarget;
                    ws.Cells[rowMasjidTableBank, columnMasjidTableBank + 9].Value = data.MasjidTableBankFinanceData.WorkerPromiseThisPeriod;

                    //Social Welfare
                    //Qard-e-Hasana
                    ws.Cells[56, 3].Value = data.QardeHasanaSocialWelfareData.Target;
                    ws.Cells[56, 4].Value = data.QardeHasanaSocialWelfareData.Actual;
                    //Transport			
                    ws.Cells[56, 9].Value = data.TransportSocialWelfareData.Target;
                    ws.Cells[56, 10].Value = data.TransportSocialWelfareData.Actual;
                    //Patient Visit
                    ws.Cells[57, 3].Value = data.PatientVisitSocialWelfareData.Target;
                    ws.Cells[57, 4].Value = data.PatientVisitSocialWelfareData.Actual;
                    //Shifting			
                    ws.Cells[57, 9].Value = data.ShiftingSocialWelfareData.Target;
                    ws.Cells[57, 10].Value = data.ShiftingSocialWelfareData.Actual;
                    //Social Visit
                    ws.Cells[58, 3].Value = data.SocialVisitSocialWelfareData.Target;
                    ws.Cells[58, 4].Value = data.SocialVisitSocialWelfareData.Actual;
                    //Shopping
                    ws.Cells[58, 9].Value = data.ShoppingSocialWelfareData.Target;
                    ws.Cells[58, 10].Value = data.ShoppingSocialWelfareData.Actual;
                    //Food Distribution
                    ws.Cells[59, 3].Value = data.FoodDistributionSocialWelfareData.Target;
                    ws.Cells[59, 4].Value = data.FoodDistributionSocialWelfareData.Actual;

                    //Other			
                    ws.Cells[59, 9].Value = data.OtherSocialWelfareData.Target;
                    ws.Cells[59, 10].Value = data.OtherSocialWelfareData.Actual;

                    //Comment (in the light of problem & prospect)
                    ws.Cells[62, 1].Value = data.Comment;
                }

                excel.SaveAs(stream);
                stream.Position = 0;

                return ReadFully(stream);
            }

        }
        private static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}