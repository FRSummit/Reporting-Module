using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using FluentAssertions;
using NsbWeb.ReportingModule.ViewModels;
using ReportingModule.Core.Security;
using ReportingModule.Entities;
using ReportingModule.SystemTests.Common;
using ReportingModule.ValueObjects;

namespace ReportingModule.Tests.Integration.CommandHandlers
{
    public class TestHelper
    {
        #region MemberData
        public static void MemberDataForCreateUnitPlanShouldBeEquivalent(MemberData source, MemberData target)
        {
            source.UpgradeTarget.Should().Be(target.UpgradeTarget);
            source.LastPeriod.Should().Be(target.ThisPeriod);
            source.ThisPeriod.Should().Be(target.ThisPeriod); //As increased = 0 and decreased = 0
        }

        #endregion


        public static IEnumerable<Claim> GetOrganizationClaims(string username, IEnumerable<OrganizationUser> organizationUsers)
        {
            var enumerable = organizationUsers as OrganizationUser[] ?? organizationUsers.ToArray();
            var orgIds = enumerable.Select(o => o.Organization.Id).ToArray();
            yield return new Claim(ReportingModuleClaimTypes.OrganizationAccess, string.Join("|", orgIds));

            var organizationRoleClaims = enumerable.Select(o => new Claim(ReportingModuleClaimTypes.OrganizationRole,
                $"{o.Organization.Id}|{o.Role}")).ToArray();

            foreach (var claim in organizationRoleClaims)
                yield return claim;
        }

        public static Claim GetAccessAllOrganizationsClaim(string username)
        {
            return new Claim(ReportingModuleClaimTypes.AccessAllOrganizations, "true");
        }
        public static Claim GetAccessAsSystemAdminClaim(string username)
        {
            return new Claim(ReportingModuleClaimTypes.IsSystemAdmin, "true");
        }

        public static void SetUserAccessAllOrganizationsClaim(string username)
        {
            new UserContextBuilder()
                .SetUsername(username)
                .AddClaim(GetAccessAllOrganizationsClaim(username))
                .SetCurrentPrincipal();
        }

        public static void SetUserAccessAsSystemAdmin(string username)
        {
            new UserContextBuilder()
                .SetUsername(username)
                .AddClaim(GetAccessAsSystemAdminClaim(username))
                .SetCurrentPrincipal();
        }

        public static UnitPlanViewModel ConvertToUnitPlanViewModel(UnitReport unitReport)
        {
            return new UnitPlanViewModel()
            {
                Id = unitReport.Id,
                Description = unitReport.Description,
                Organization = unitReport.Organization,
                ReportingPeriod = unitReport.ReportingPeriod,
                ReportStatus = unitReport.ReportStatus,
                ReOpenedReportStatus = unitReport.ReopenedReportStatus,
                Timestamp = unitReport.Timestamp,

                MemberMemberPlanData = unitReport.MemberMemberData,
                AssociateMemberPlanData = unitReport.AssociateMemberData,
                PreliminaryMemberPlanData = unitReport.PreliminaryMemberData,
                SupporterMemberPlanData = unitReport.SupporterMemberData,

                WorkerMeetingProgramPlanData = unitReport.WorkerMeetingProgramData,
                DawahMeetingProgramPlanData = unitReport.DawahMeetingProgramData,
                StateLeaderMeetingProgramPlanData = unitReport.StateLeaderMeetingProgramData,
                StateOutingMeetingProgramPlanData = unitReport.StateOutingMeetingProgramData,
                IftarMeetingProgramPlanData = unitReport.IftarMeetingProgramData,
                LearningMeetingProgramPlanData = unitReport.LearningMeetingProgramData,
                SocialDawahMeetingProgramPlanData = unitReport.SocialDawahMeetingProgramData,
                DawahGroupMeetingProgramPlanData = unitReport.DawahGroupMeetingProgramData,
                NextGMeetingProgramPlanData = unitReport.NextGMeetingProgramData,

                CmsMeetingProgramPlanData = unitReport.CmsMeetingProgramData,
                SmMeetingProgramPlanData = unitReport.SmMeetingProgramData,
                MemberMeetingProgramPlanData = unitReport.MemberMeetingProgramData,
                TafsirMeetingProgramPlanData = unitReport.TafsirMeetingProgramData,
                UnitMeetingProgramPlanData = unitReport.UnitMeetingProgramData,
                FamilyVisitMeetingProgramPlanData = unitReport.FamilyVisitMeetingProgramData,
                EidReunionMeetingProgramPlanData = unitReport.EidReunionMeetingProgramData,
                BbqMeetingProgramPlanData = unitReport.BbqMeetingProgramData,
                GatheringMeetingProgramPlanData = unitReport.GatheringMeetingProgramData,
                OtherMeetingProgramPlanData = unitReport.OtherMeetingProgramData,

                BaitulMalFinancePlanData = unitReport.BaitulMalFinanceData,
                ADayMasjidProjectFinancePlanData = unitReport.ADayMasjidProjectFinanceData,
                MasjidTableBankFinancePlanData = unitReport.MasjidTableBankFinanceData,

                QardeHasanaSocialWelfarePlanData = unitReport.QardeHasanaSocialWelfareData,
                PatientVisitSocialWelfarePlanData = unitReport.PatientVisitSocialWelfareData,
                SocialVisitSocialWelfarePlanData = unitReport.SocialVisitSocialWelfareData,

                TransportSocialWelfarePlanData = unitReport.TransportSocialWelfareData,
                ShiftingSocialWelfarePlanData = unitReport.ShiftingSocialWelfareData,
                ShoppingSocialWelfarePlanData = unitReport.ShoppingSocialWelfareData,

                FoodDistributionSocialWelfarePlanData = unitReport.FoodDistributionSocialWelfareData,
                CleanUpAustraliaSocialWelfarePlanData = unitReport.CleanUpAustraliaSocialWelfareData,
                OtherSocialWelfarePlanData = unitReport.OtherSocialWelfareData,

                BookSaleMaterialPlanData = unitReport.BookSaleMaterialData,
                BookDistributionMaterialPlanData = unitReport.BookDistributionMaterialData,
                BookLibraryStockPlanData = unitReport.BookLibraryStockData,

                OtherSaleMaterialPlanData = unitReport.OtherSaleMaterialData,
                OtherDistributionMaterialPlanData = unitReport.OtherDistributionMaterialData,
                OtherLibraryStockPlanData = unitReport.OtherLibraryStockData,

                VhsSaleMaterialPlanData = unitReport.VhsSaleMaterialData,
                VhsDistributionMaterialPlanData = unitReport.VhsDistributionMaterialData,
                VhsLibraryStockPlanData = unitReport.VhsLibraryStockData,
                EmailDistributionMaterialPlanData = unitReport.EmailDistributionMaterialData,
                IpdcLeafletDistributionMaterialPlanData = unitReport.IpdcLeafletDistributionMaterialData,


                GroupStudyTeachingLearningProgramPlanData = unitReport.GroupStudyTeachingLearningProgramData,
                StudyCircleTeachingLearningProgramPlanData = unitReport.StudyCircleTeachingLearningProgramData,
                PracticeDarsTeachingLearningProgramPlanData = unitReport.PracticeDarsTeachingLearningProgramData,
                StateLearningCampTeachingLearningProgramPlanData = unitReport.StateLearningCampTeachingLearningProgramData,
                QuranStudyTeachingLearningProgramPlanData = unitReport.QuranStudyTeachingLearningProgramData,
                QuranClassTeachingLearningProgramPlanData = unitReport.QuranClassTeachingLearningProgramData,
                MemorizingAyatTeachingLearningProgramPlanData = unitReport.MemorizingAyatTeachingLearningProgramData,
                StateLearningSessionTeachingLearningProgramPlanData = unitReport.StateLearningSessionTeachingLearningProgramData,
                StateQiyamulLailTeachingLearningProgramPlanData = unitReport.StateQiyamulLailTeachingLearningProgramData,
                StudyCircleForAssociateMemberTeachingLearningProgramPlanData = unitReport.StudyCircleForAssociateMemberTeachingLearningProgramData,
                HadithTeachingLearningProgramPlanData = unitReport.HadithTeachingLearningProgramData,
                WeekendIslamicSchoolTeachingLearningProgramPlanData = unitReport.WeekendIslamicSchoolTeachingLearningProgramData,
                MemorizingHadithTeachingLearningProgramPlanData = unitReport.MemorizingHadithTeachingLearningProgramData,
                MemorizingDoaTeachingLearningProgramPlanData = unitReport.MemorizingDoaTeachingLearningProgramData,
                OtherTeachingLearningProgramPlanData = unitReport.OtherTeachingLearningProgramData,

            };
        }
        public static UnitReportViewModel ConvertToUnitReportViewModel(UnitReport unitReport)
        {
            return new UnitReportViewModel()
            {
                Id = unitReport.Id,
                Description = unitReport.Description,
                Organization = unitReport.Organization,
                ReportingPeriod = unitReport.ReportingPeriod,
                ReportStatus = unitReport.ReportStatus,
                ReOpenedReportStatus = unitReport.ReopenedReportStatus,
                Timestamp = unitReport.Timestamp,

                AssociateMemberData = unitReport.AssociateMemberData,
                PreliminaryMemberData = unitReport.PreliminaryMemberData,
                SupporterMemberData = unitReport.SupporterMemberData,

                WorkerMeetingProgramData = unitReport.WorkerMeetingProgramData,
                DawahMeetingProgramData = unitReport.DawahMeetingProgramData,
                StateLeaderMeetingProgramData = unitReport.StateLeaderMeetingProgramData,
                StateOutingMeetingProgramData = unitReport.StateOutingMeetingProgramData,
                IftarMeetingProgramData = unitReport.IftarMeetingProgramData,
                LearningMeetingProgramData = unitReport.LearningMeetingProgramData,
                SocialDawahMeetingProgramData = unitReport.SocialDawahMeetingProgramData,
                DawahGroupMeetingProgramData = unitReport.DawahGroupMeetingProgramData,
                NextGMeetingProgramData = unitReport.NextGMeetingProgramData,

                CmsMeetingProgramData = unitReport.CmsMeetingProgramData,
                SmMeetingProgramData = unitReport.SmMeetingProgramData,
                MemberMeetingProgramData = unitReport.MemberMeetingProgramData,
                TafsirMeetingProgramData = unitReport.TafsirMeetingProgramData,
                UnitMeetingProgramData = unitReport.UnitMeetingProgramData,
                FamilyVisitMeetingProgramData = unitReport.FamilyVisitMeetingProgramData,
                EidReunionMeetingProgramData = unitReport.EidReunionMeetingProgramData,
                BbqMeetingProgramData = unitReport.BbqMeetingProgramData,
                GatheringMeetingProgramData = unitReport.GatheringMeetingProgramData,
                OtherMeetingProgramData = unitReport.OtherMeetingProgramData,

                MemberMemberData = unitReport.MemberMemberData,

                BaitulMalFinanceData = unitReport.BaitulMalFinanceData,
                ADayMasjidProjectFinanceData = unitReport.ADayMasjidProjectFinanceData,
                MasjidTableBankFinanceData = unitReport.MasjidTableBankFinanceData,

                QardeHasanaSocialWelfareData = unitReport.QardeHasanaSocialWelfareData,
                PatientVisitSocialWelfareData = unitReport.PatientVisitSocialWelfareData,
                SocialVisitSocialWelfareData = unitReport.SocialVisitSocialWelfareData,
                TransportSocialWelfareData = unitReport.TransportSocialWelfareData,
                ShiftingSocialWelfareData = unitReport.ShiftingSocialWelfareData,
                ShoppingSocialWelfareData = unitReport.ShoppingSocialWelfareData,

                FoodDistributionSocialWelfareData = unitReport.FoodDistributionSocialWelfareData,
                CleanUpAustraliaSocialWelfareData = unitReport.CleanUpAustraliaSocialWelfareData,
                OtherSocialWelfareData = unitReport.OtherSocialWelfareData,

                BookSaleMaterialData = unitReport.BookSaleMaterialData,
                BookDistributionMaterialData = unitReport.BookDistributionMaterialData,
                BookLibraryStockData = unitReport.BookLibraryStockData,

                OtherSaleMaterialData = unitReport.OtherSaleMaterialData,
                OtherDistributionMaterialData = unitReport.OtherDistributionMaterialData,
                OtherLibraryStockData = unitReport.OtherLibraryStockData,

                VhsSaleMaterialData = unitReport.VhsSaleMaterialData,
                VhsDistributionMaterialData = unitReport.VhsDistributionMaterialData,
                VhsLibraryStockData = unitReport.VhsLibraryStockData,
                EmailDistributionMaterialData = unitReport.EmailDistributionMaterialData,
                IpdcLeafletDistributionMaterialData = unitReport.IpdcLeafletDistributionMaterialData,

                GroupStudyTeachingLearningProgramData = unitReport.GroupStudyTeachingLearningProgramData,
                StudyCircleTeachingLearningProgramData = unitReport.StudyCircleTeachingLearningProgramData,
                PracticeDarsTeachingLearningProgramData = unitReport.PracticeDarsTeachingLearningProgramData,
                StateLearningCampTeachingLearningProgramData = unitReport.StateLearningCampTeachingLearningProgramData,
                QuranStudyTeachingLearningProgramData = unitReport.QuranStudyTeachingLearningProgramData,
                QuranClassTeachingLearningProgramData = unitReport.QuranClassTeachingLearningProgramData,
                MemorizingAyatTeachingLearningProgramData = unitReport.MemorizingAyatTeachingLearningProgramData,
                StateLearningSessionTeachingLearningProgramData = unitReport.StateLearningSessionTeachingLearningProgramData,
                StateQiyamulLailTeachingLearningProgramData = unitReport.StateQiyamulLailTeachingLearningProgramData,

                StudyCircleForAssociateMemberTeachingLearningProgramData = unitReport.StudyCircleForAssociateMemberTeachingLearningProgramData,
                HadithTeachingLearningProgramData = unitReport.HadithTeachingLearningProgramData,
                WeekendIslamicSchoolTeachingLearningProgramData = unitReport.WeekendIslamicSchoolTeachingLearningProgramData,
                MemorizingHadithTeachingLearningProgramData = unitReport.MemorizingHadithTeachingLearningProgramData,
                MemorizingDoaTeachingLearningProgramData = unitReport.MemorizingDoaTeachingLearningProgramData,
                OtherTeachingLearningProgramData = unitReport.OtherTeachingLearningProgramData,

            };
        }

        public static ZonePlanViewModel ConvertToZonePlanViewModel(ZoneReport zoneReport)
        {
            return new ZonePlanViewModel()
            {
                Id = zoneReport.Id,
                Description = zoneReport.Description,
                Organization = zoneReport.Organization,
                ReportingPeriod = zoneReport.ReportingPeriod,
                ReportStatus = zoneReport.ReportStatus,
                ReOpenedReportStatus = zoneReport.ReopenedReportStatus,
                Timestamp = zoneReport.Timestamp,
                MemberMemberPlanData = zoneReport.MemberMemberData,
                MemberMemberPlanGeneratedData = zoneReport.MemberMemberGeneratedData,
                AssociateMemberPlanData = zoneReport.AssociateMemberData,
                AssociateMemberPlanGeneratedData = zoneReport.AssociateMemberGeneratedData,
                PreliminaryMemberPlanData = zoneReport.PreliminaryMemberData,
                PreliminaryMemberPlanGeneratedData = zoneReport.PreliminaryMemberGeneratedData,
                SupporterMemberPlanData = zoneReport.SupporterMemberData,
                SupporterMemberPlanGeneratedData = zoneReport.SupporterMemberGeneratedData,

                WorkerMeetingProgramPlanData = zoneReport.WorkerMeetingProgramData,
                WorkerMeetingProgramPlanGeneratedData = zoneReport.WorkerMeetingProgramGeneratedData,
                DawahMeetingProgramPlanData = zoneReport.DawahMeetingProgramData,
                DawahMeetingProgramPlanGeneratedData = zoneReport.DawahMeetingProgramGeneratedData,
                StateLeaderMeetingProgramPlanData = zoneReport.StateLeaderMeetingProgramData,
                StateLeaderMeetingProgramPlanGeneratedData = zoneReport.StateLeaderMeetingProgramGeneratedData,
                StateOutingMeetingProgramPlanData = zoneReport.StateOutingMeetingProgramData,
                StateOutingMeetingProgramPlanGeneratedData = zoneReport.StateOutingMeetingProgramGeneratedData,
                IftarMeetingProgramPlanData = zoneReport.IftarMeetingProgramData,
                IftarMeetingProgramPlanGeneratedData = zoneReport.IftarMeetingProgramGeneratedData,
                LearningMeetingProgramPlanData = zoneReport.LearningMeetingProgramData,
                LearningMeetingProgramPlanGeneratedData = zoneReport.LearningMeetingProgramGeneratedData,
                SocialDawahMeetingProgramPlanData = zoneReport.SocialDawahMeetingProgramData,
                SocialDawahMeetingProgramPlanGeneratedData = zoneReport.SocialDawahMeetingProgramGeneratedData,
                DawahGroupMeetingProgramPlanData = zoneReport.DawahGroupMeetingProgramData,
                DawahGroupMeetingProgramPlanGeneratedData = zoneReport.DawahGroupMeetingProgramGeneratedData,
                NextGMeetingProgramPlanData = zoneReport.NextGMeetingProgramData,
                NextGMeetingProgramPlanGeneratedData = zoneReport.NextGMeetingProgramGeneratedData,


                CmsMeetingProgramPlanData = zoneReport.CmsMeetingProgramData,
                CmsMeetingProgramPlanGeneratedData = zoneReport.CmsMeetingProgramGeneratedData,
                SmMeetingProgramPlanData = zoneReport.SmMeetingProgramData,
                SmMeetingProgramPlanGeneratedData = zoneReport.SmMeetingProgramGeneratedData,
                MemberMeetingProgramPlanData = zoneReport.MemberMeetingProgramData,
                MemberMeetingProgramPlanGeneratedData = zoneReport.MemberMeetingProgramGeneratedData,
                TafsirMeetingProgramPlanData = zoneReport.TafsirMeetingProgramData,
                TafsirMeetingProgramPlanGeneratedData = zoneReport.TafsirMeetingProgramGeneratedData,
                UnitMeetingProgramPlanData = zoneReport.UnitMeetingProgramData,
                UnitMeetingProgramPlanGeneratedData = zoneReport.UnitMeetingProgramGeneratedData,
                FamilyVisitMeetingProgramPlanData = zoneReport.FamilyVisitMeetingProgramData,
                FamilyVisitMeetingProgramPlanGeneratedData = zoneReport.FamilyVisitMeetingProgramGeneratedData,
                EidReunionMeetingProgramPlanData = zoneReport.EidReunionMeetingProgramData,
                EidReunionMeetingProgramPlanGeneratedData = zoneReport.EidReunionMeetingProgramGeneratedData,
                BbqMeetingProgramPlanData = zoneReport.BbqMeetingProgramData,
                BbqMeetingProgramPlanGeneratedData = zoneReport.BbqMeetingProgramGeneratedData,
                GatheringMeetingProgramPlanData = zoneReport.GatheringMeetingProgramData,
                GatheringMeetingProgramPlanGeneratedData = zoneReport.GatheringMeetingProgramGeneratedData,
                OtherMeetingProgramPlanData = zoneReport.OtherMeetingProgramData,
                OtherMeetingProgramPlanGeneratedData = zoneReport.OtherMeetingProgramGeneratedData,


                GroupStudyTeachingLearningProgramPlanData = zoneReport.GroupStudyTeachingLearningProgramData,
                GroupStudyTeachingLearningProgramPlanGeneratedData = zoneReport.GroupStudyTeachingLearningProgramGeneratedData,
                StudyCircleTeachingLearningProgramPlanData = zoneReport.StudyCircleTeachingLearningProgramData,
                StudyCircleTeachingLearningProgramPlanGeneratedData = zoneReport.StudyCircleTeachingLearningProgramGeneratedData,
                PracticeDarsTeachingLearningProgramPlanData = zoneReport.PracticeDarsTeachingLearningProgramData,
                PracticeDarsTeachingLearningProgramPlanGeneratedData = zoneReport.PracticeDarsTeachingLearningProgramGeneratedData,
                StateLearningCampTeachingLearningProgramPlanData = zoneReport.StateLearningCampTeachingLearningProgramData,
                StateLearningCampTeachingLearningProgramPlanGeneratedData = zoneReport.StateLearningCampTeachingLearningProgramGeneratedData,
                QuranStudyTeachingLearningProgramPlanData = zoneReport.QuranStudyTeachingLearningProgramData,
                QuranStudyTeachingLearningProgramPlanGeneratedData = zoneReport.QuranStudyTeachingLearningProgramGeneratedData,
                QuranClassTeachingLearningProgramPlanData = zoneReport.QuranClassTeachingLearningProgramData,
                QuranClassTeachingLearningProgramPlanGeneratedData = zoneReport.QuranClassTeachingLearningProgramGeneratedData,
                MemorizingAyatTeachingLearningProgramPlanData = zoneReport.MemorizingAyatTeachingLearningProgramData,
                MemorizingAyatTeachingLearningProgramPlanGeneratedData = zoneReport.MemorizingAyatTeachingLearningProgramGeneratedData,
                StateLearningSessionTeachingLearningProgramPlanData = zoneReport.StateLearningSessionTeachingLearningProgramData,
                StateLearningSessionTeachingLearningProgramPlanGeneratedData = zoneReport.StateLearningSessionTeachingLearningProgramGeneratedData,
                StateQiyamulLailTeachingLearningProgramPlanData = zoneReport.StateQiyamulLailTeachingLearningProgramData,
                StateQiyamulLailTeachingLearningProgramPlanGeneratedData = zoneReport.StateQiyamulLailTeachingLearningProgramGeneratedData,

                StudyCircleForAssociateMemberTeachingLearningProgramPlanData = zoneReport.StudyCircleForAssociateMemberTeachingLearningProgramData,
                StudyCircleForAssociateMemberTeachingLearningProgramPlanGeneratedData = zoneReport.StudyCircleForAssociateMemberTeachingLearningProgramGeneratedData,
                HadithTeachingLearningProgramPlanData = zoneReport.HadithTeachingLearningProgramData,
                HadithTeachingLearningProgramPlanGeneratedData = zoneReport.HadithTeachingLearningProgramGeneratedData,
                WeekendIslamicSchoolTeachingLearningProgramPlanData = zoneReport.WeekendIslamicSchoolTeachingLearningProgramData,
                WeekendIslamicSchoolTeachingLearningProgramPlanGeneratedData = zoneReport.WeekendIslamicSchoolTeachingLearningProgramGeneratedData,
                MemorizingHadithTeachingLearningProgramPlanData = zoneReport.MemorizingHadithTeachingLearningProgramData,
                MemorizingHadithTeachingLearningProgramPlanGeneratedData = zoneReport.MemorizingHadithTeachingLearningProgramGeneratedData,
                MemorizingDoaTeachingLearningProgramPlanData = zoneReport.MemorizingDoaTeachingLearningProgramData,
                MemorizingDoaTeachingLearningProgramPlanGeneratedData = zoneReport.MemorizingDoaTeachingLearningProgramGeneratedData,

                OtherTeachingLearningProgramPlanData = zoneReport.OtherTeachingLearningProgramData,
                OtherTeachingLearningProgramPlanGeneratedData = zoneReport.OtherTeachingLearningProgramGeneratedData,


                BookSaleMaterialPlanData = zoneReport.BookSaleMaterialData,
                BookSaleMaterialPlanGeneratedData = zoneReport.BookSaleMaterialGeneratedData,
                BookDistributionMaterialPlanData = zoneReport.BookDistributionMaterialData,
                BookDistributionMaterialPlanGeneratedData = zoneReport.BookDistributionMaterialGeneratedData,
                BookLibraryStockPlanData = zoneReport.BookLibraryStockData,
                BookLibraryStockPlanGeneratedData = zoneReport.BookLibraryStockGeneratedData,

                OtherSaleMaterialPlanData = zoneReport.OtherSaleMaterialData,
                OtherSaleMaterialPlanGeneratedData = zoneReport.OtherSaleMaterialGeneratedData,
                OtherDistributionMaterialPlanData = zoneReport.OtherDistributionMaterialData,
                OtherDistributionMaterialPlanGeneratedData = zoneReport.OtherDistributionMaterialGeneratedData,
                OtherLibraryStockPlanData = zoneReport.OtherLibraryStockData,
                OtherLibraryStockPlanGeneratedData = zoneReport.OtherLibraryStockGeneratedData,

                VhsSaleMaterialPlanData = zoneReport.VhsSaleMaterialData,
                VhsSaleMaterialPlanGeneratedData = zoneReport.VhsSaleMaterialGeneratedData,
                VhsDistributionMaterialPlanData = zoneReport.VhsDistributionMaterialData,
                VhsDistributionMaterialPlanGeneratedData = zoneReport.VhsDistributionMaterialGeneratedData,
                VhsLibraryStockPlanData = zoneReport.VhsLibraryStockData,
                VhsLibraryStockPlanGeneratedData = zoneReport.VhsLibraryStockGeneratedData,
                EmailDistributionMaterialPlanData = zoneReport.EmailDistributionMaterialData,
                EmailDistributionMaterialPlanGeneratedData = zoneReport.EmailDistributionMaterialGeneratedData,
                IpdcLeafletDistributionMaterialPlanData = zoneReport.IpdcLeafletDistributionMaterialData,
                IpdcLeafletDistributionMaterialPlanGeneratedData = zoneReport.IpdcLeafletDistributionMaterialGeneratedData,


                BaitulMalFinancePlanData = zoneReport.BaitulMalFinanceData,
                BaitulMalFinancePlanGeneratedData = zoneReport.BaitulMalFinanceGeneratedData,
                ADayMasjidProjectFinancePlanData = zoneReport.ADayMasjidProjectFinanceData,
                ADayMasjidProjectFinancePlanGeneratedData = zoneReport.ADayMasjidProjectFinanceGeneratedData,
                MasjidTableBankFinancePlanData = zoneReport.MasjidTableBankFinanceData,
                MasjidTableBankFinancePlanGeneratedData = zoneReport.MasjidTableBankFinanceGeneratedData,


                QardeHasanaSocialWelfarePlanData = zoneReport.QardeHasanaSocialWelfareData,
                QardeHasanaSocialWelfarePlanGeneratedData = zoneReport.QardeHasanaSocialWelfareGeneratedData,
                PatientVisitSocialWelfarePlanData = zoneReport.PatientVisitSocialWelfareData,
                PatientVisitSocialWelfarePlanGeneratedData = zoneReport.PatientVisitSocialWelfareGeneratedData,
                SocialVisitSocialWelfarePlanData = zoneReport.SocialVisitSocialWelfareData,
                SocialVisitSocialWelfarePlanGeneratedData = zoneReport.SocialVisitSocialWelfareGeneratedData,
                TransportSocialWelfarePlanData = zoneReport.TransportSocialWelfareData,
                TransportSocialWelfarePlanGeneratedData = zoneReport.TransportSocialWelfareGeneratedData,
                ShiftingSocialWelfarePlanData = zoneReport.ShiftingSocialWelfareData,
                ShiftingSocialWelfarePlanGeneratedData = zoneReport.ShiftingSocialWelfareGeneratedData,
                ShoppingSocialWelfarePlanData = zoneReport.ShoppingSocialWelfareData,
                ShoppingSocialWelfarePlanGeneratedData = zoneReport.ShoppingSocialWelfareGeneratedData,
                FoodDistributionSocialWelfarePlanData = zoneReport.FoodDistributionSocialWelfareData,
                FoodDistributionSocialWelfarePlanGeneratedData = zoneReport.FoodDistributionSocialWelfareGeneratedData,
                CleanUpAustraliaSocialWelfarePlanData = zoneReport.CleanUpAustraliaSocialWelfareData,
                CleanUpAustraliaSocialWelfarePlanGeneratedData = zoneReport.CleanUpAustraliaSocialWelfareGeneratedData,
                OtherSocialWelfarePlanData = zoneReport.OtherSocialWelfareData,
                OtherSocialWelfarePlanGeneratedData = zoneReport.OtherSocialWelfareGeneratedData,
            };
        }
        public static ZoneReportViewModel ConvertToZoneReportViewModel(ZoneReport zoneReport)
        {
            return new ZoneReportViewModel()
            {
                Id = zoneReport.Id,
                Description = zoneReport.Description,
                Organization = zoneReport.Organization,
                ReportingPeriod = zoneReport.ReportingPeriod,
                ReportStatus = zoneReport.ReportStatus,
                ReOpenedReportStatus = zoneReport.ReopenedReportStatus,
                Timestamp = zoneReport.Timestamp,
                MemberMemberData = zoneReport.MemberMemberData,
                MemberMemberGeneratedData = zoneReport.MemberMemberData,
                AssociateMemberData = zoneReport.AssociateMemberData,
                AssociateMemberGeneratedData = zoneReport.AssociateMemberData,
                PreliminaryMemberData = zoneReport.PreliminaryMemberData,
                PreliminaryMemberGeneratedData = zoneReport.PreliminaryMemberData,
                SupporterMemberData = zoneReport.SupporterMemberData,
                SupporterMemberGeneratedData = zoneReport.SupporterMemberData,

                WorkerMeetingProgramData = zoneReport.WorkerMeetingProgramData,
                WorkerMeetingProgramGeneratedData = zoneReport.WorkerMeetingProgramData,
                DawahMeetingProgramData = zoneReport.DawahMeetingProgramData,
                DawahMeetingProgramGeneratedData = zoneReport.DawahMeetingProgramGeneratedData,
                StateLeaderMeetingProgramData = zoneReport.StateLeaderMeetingProgramData,
                StateLeaderMeetingProgramGeneratedData = zoneReport.StateLeaderMeetingProgramGeneratedData,
                StateOutingMeetingProgramData = zoneReport.StateOutingMeetingProgramData,
                StateOutingMeetingProgramGeneratedData = zoneReport.StateOutingMeetingProgramGeneratedData,
                IftarMeetingProgramData = zoneReport.IftarMeetingProgramData,
                IftarMeetingProgramGeneratedData = zoneReport.IftarMeetingProgramGeneratedData,
                LearningMeetingProgramData = zoneReport.LearningMeetingProgramData,
                LearningMeetingProgramGeneratedData = zoneReport.LearningMeetingProgramGeneratedData,
                SocialDawahMeetingProgramData = zoneReport.SocialDawahMeetingProgramData,
                SocialDawahMeetingProgramGeneratedData = zoneReport.SocialDawahMeetingProgramGeneratedData,
                DawahGroupMeetingProgramData = zoneReport.DawahGroupMeetingProgramData,
                DawahGroupMeetingProgramGeneratedData = zoneReport.DawahGroupMeetingProgramGeneratedData,
                NextGMeetingProgramData = zoneReport.NextGMeetingProgramData,
                NextGMeetingProgramGeneratedData = zoneReport.NextGMeetingProgramGeneratedData,

                CmsMeetingProgramData = zoneReport.CmsMeetingProgramData,
                CmsMeetingProgramGeneratedData = zoneReport.CmsMeetingProgramGeneratedData,
                SmMeetingProgramData = zoneReport.SmMeetingProgramData,
                SmMeetingProgramGeneratedData = zoneReport.SmMeetingProgramGeneratedData,
                MemberMeetingProgramData = zoneReport.MemberMeetingProgramData,
                MemberMeetingProgramGeneratedData = zoneReport.MemberMeetingProgramGeneratedData,
                TafsirMeetingProgramData = zoneReport.TafsirMeetingProgramData,
                TafsirMeetingProgramGeneratedData = zoneReport.TafsirMeetingProgramGeneratedData,
                UnitMeetingProgramData = zoneReport.UnitMeetingProgramData,
                UnitMeetingProgramGeneratedData = zoneReport.UnitMeetingProgramGeneratedData,
                FamilyVisitMeetingProgramData = zoneReport.FamilyVisitMeetingProgramData,
                FamilyVisitMeetingProgramGeneratedData = zoneReport.FamilyVisitMeetingProgramGeneratedData,
                EidReunionMeetingProgramData = zoneReport.EidReunionMeetingProgramData,
                EidReunionMeetingProgramGeneratedData = zoneReport.EidReunionMeetingProgramGeneratedData,
                BbqMeetingProgramData = zoneReport.BbqMeetingProgramData,
                BbqMeetingProgramGeneratedData = zoneReport.BbqMeetingProgramGeneratedData,
                GatheringMeetingProgramData = zoneReport.GatheringMeetingProgramData,
                GatheringMeetingProgramGeneratedData = zoneReport.GatheringMeetingProgramGeneratedData,

                OtherMeetingProgramData = zoneReport.OtherMeetingProgramData,
                OtherMeetingProgramGeneratedData = zoneReport.OtherMeetingProgramGeneratedData,

                GroupStudyTeachingLearningProgramData = zoneReport.GroupStudyTeachingLearningProgramData,
                GroupStudyTeachingLearningProgramGeneratedData = zoneReport.GroupStudyTeachingLearningProgramGeneratedData,
                StudyCircleTeachingLearningProgramData = zoneReport.StudyCircleTeachingLearningProgramData,
                StudyCircleTeachingLearningProgramGeneratedData = zoneReport.StudyCircleTeachingLearningProgramGeneratedData,
                PracticeDarsTeachingLearningProgramData = zoneReport.PracticeDarsTeachingLearningProgramData,
                PracticeDarsTeachingLearningProgramGeneratedData = zoneReport.PracticeDarsTeachingLearningProgramGeneratedData,
                StateLearningCampTeachingLearningProgramData = zoneReport.StateLearningCampTeachingLearningProgramData,
                StateLearningCampTeachingLearningProgramGeneratedData = zoneReport.StateLearningCampTeachingLearningProgramGeneratedData,
                QuranStudyTeachingLearningProgramData = zoneReport.QuranStudyTeachingLearningProgramData,
                QuranStudyTeachingLearningProgramGeneratedData = zoneReport.QuranStudyTeachingLearningProgramGeneratedData,
                QuranClassTeachingLearningProgramData = zoneReport.QuranClassTeachingLearningProgramData,
                QuranClassTeachingLearningProgramGeneratedData = zoneReport.QuranClassTeachingLearningProgramGeneratedData,
                MemorizingAyatTeachingLearningProgramData = zoneReport.MemorizingAyatTeachingLearningProgramData,
                MemorizingAyatTeachingLearningProgramGeneratedData = zoneReport.MemorizingAyatTeachingLearningProgramGeneratedData,
                StateLearningSessionTeachingLearningProgramData = zoneReport.StateLearningSessionTeachingLearningProgramData,
                StateLearningSessionTeachingLearningProgramGeneratedData = zoneReport.StateLearningSessionTeachingLearningProgramGeneratedData,
                StateQiyamulLailTeachingLearningProgramData = zoneReport.StateQiyamulLailTeachingLearningProgramData,
                StateQiyamulLailTeachingLearningProgramGeneratedData = zoneReport.StateQiyamulLailTeachingLearningProgramGeneratedData,

                StudyCircleForAssociateMemberTeachingLearningProgramData = zoneReport.StudyCircleForAssociateMemberTeachingLearningProgramData,
                StudyCircleForAssociateMemberTeachingLearningProgramGeneratedData = zoneReport.StudyCircleForAssociateMemberTeachingLearningProgramGeneratedData,
                HadithTeachingLearningProgramData = zoneReport.HadithTeachingLearningProgramData,
                HadithTeachingLearningProgramGeneratedData = zoneReport.HadithTeachingLearningProgramGeneratedData,
                WeekendIslamicSchoolTeachingLearningProgramData = zoneReport.WeekendIslamicSchoolTeachingLearningProgramData,
                WeekendIslamicSchoolTeachingLearningProgramGeneratedData = zoneReport.WeekendIslamicSchoolTeachingLearningProgramGeneratedData,
                MemorizingHadithTeachingLearningProgramData = zoneReport.MemorizingHadithTeachingLearningProgramData,
                MemorizingHadithTeachingLearningProgramGeneratedData = zoneReport.MemorizingHadithTeachingLearningProgramGeneratedData,
                MemorizingDoaTeachingLearningProgramData = zoneReport.MemorizingDoaTeachingLearningProgramData,
                MemorizingDoaTeachingLearningProgramGeneratedData = zoneReport.MemorizingDoaTeachingLearningProgramGeneratedData,
                OtherTeachingLearningProgramData = zoneReport.OtherTeachingLearningProgramData,
                OtherTeachingLearningProgramGeneratedData = zoneReport.OtherTeachingLearningProgramGeneratedData,

                BookSaleMaterialData = zoneReport.BookSaleMaterialData,
                BookSaleMaterialGeneratedData = zoneReport.BookSaleMaterialGeneratedData,
                BookDistributionMaterialData = zoneReport.BookDistributionMaterialData,
                BookDistributionMaterialGeneratedData = zoneReport.BookDistributionMaterialGeneratedData,
                BookLibraryStockData = zoneReport.BookLibraryStockData,
                BookLibraryStockGeneratedData = zoneReport.BookLibraryStockGeneratedData,
                OtherSaleMaterialData = zoneReport.OtherSaleMaterialData,
                OtherSaleMaterialGeneratedData = zoneReport.OtherSaleMaterialGeneratedData,
                OtherDistributionMaterialData = zoneReport.OtherDistributionMaterialData,
                OtherDistributionMaterialGeneratedData = zoneReport.OtherDistributionMaterialGeneratedData,
                OtherLibraryStockData = zoneReport.OtherLibraryStockData,
                OtherLibraryStockGeneratedData = zoneReport.OtherLibraryStockGeneratedData,
                VhsSaleMaterialData = zoneReport.VhsSaleMaterialData,
                VhsSaleMaterialGeneratedData = zoneReport.VhsSaleMaterialGeneratedData,
                VhsDistributionMaterialData = zoneReport.VhsDistributionMaterialData,
                VhsDistributionMaterialGeneratedData = zoneReport.VhsDistributionMaterialGeneratedData,
                VhsLibraryStockData = zoneReport.VhsLibraryStockData,
                VhsLibraryStockGeneratedData = zoneReport.VhsLibraryStockGeneratedData,
                EmailDistributionMaterialData = zoneReport.EmailDistributionMaterialData,
                EmailDistributionMaterialGeneratedData = zoneReport.EmailDistributionMaterialGeneratedData,
                IpdcLeafletDistributionMaterialData = zoneReport.IpdcLeafletDistributionMaterialData,
                IpdcLeafletDistributionMaterialGeneratedData = zoneReport.IpdcLeafletDistributionMaterialGeneratedData,

                BaitulMalFinanceData = zoneReport.BaitulMalFinanceData,
                BaitulMalFinanceGeneratedData = zoneReport.BaitulMalFinanceGeneratedData,

                ADayMasjidProjectFinanceData = zoneReport.ADayMasjidProjectFinanceData,
                ADayMasjidProjectFinanceGeneratedData = zoneReport.ADayMasjidProjectFinanceGeneratedData,
                MasjidTableBankFinanceData = zoneReport.MasjidTableBankFinanceData,
                MasjidTableBankFinanceGeneratedData = zoneReport.MasjidTableBankFinanceGeneratedData,

                QardeHasanaSocialWelfareData = zoneReport.QardeHasanaSocialWelfareData,
                QardeHasanaSocialWelfareGeneratedData = zoneReport.QardeHasanaSocialWelfareGeneratedData,
                PatientVisitSocialWelfareData = zoneReport.PatientVisitSocialWelfareData,
                PatientVisitSocialWelfareGeneratedData = zoneReport.PatientVisitSocialWelfareGeneratedData,
                SocialVisitSocialWelfareData = zoneReport.SocialVisitSocialWelfareData,
                SocialVisitSocialWelfareGeneratedData = zoneReport.SocialVisitSocialWelfareGeneratedData,
                TransportSocialWelfareData = zoneReport.TransportSocialWelfareData,
                TransportSocialWelfareGeneratedData = zoneReport.TransportSocialWelfareGeneratedData,
                ShiftingSocialWelfareData = zoneReport.ShiftingSocialWelfareData,
                ShiftingSocialWelfareGeneratedData = zoneReport.ShiftingSocialWelfareGeneratedData,
                ShoppingSocialWelfareData = zoneReport.ShoppingSocialWelfareData,
                ShoppingSocialWelfareGeneratedData = zoneReport.ShoppingSocialWelfareGeneratedData,
                FoodDistributionSocialWelfareData = zoneReport.FoodDistributionSocialWelfareData,
                FoodDistributionSocialWelfareGeneratedData = zoneReport.FoodDistributionSocialWelfareGeneratedData,
                CleanUpAustraliaSocialWelfareData = zoneReport.CleanUpAustraliaSocialWelfareData,
                CleanUpAustraliaSocialWelfareGeneratedData = zoneReport.CleanUpAustraliaSocialWelfareGeneratedData,
                OtherSocialWelfareData = zoneReport.OtherSocialWelfareData,
                OtherSocialWelfareGeneratedData = zoneReport.OtherSocialWelfareGeneratedData,
            };
        }

        public static StatePlanViewModel ConvertToStatePlanViewModel(StateReport stateReport)
        {
            return new StatePlanViewModel()
            {
                Id = stateReport.Id,
                Description = stateReport.Description,
                Organization = stateReport.Organization,
                ReportingPeriod = stateReport.ReportingPeriod,
                ReportStatus = stateReport.ReportStatus,
                ReOpenedReportStatus = stateReport.ReopenedReportStatus,
                Timestamp = stateReport.Timestamp,
                MemberMemberPlanData = stateReport.MemberMemberData,
                MemberMemberPlanGeneratedData = stateReport.MemberMemberGeneratedData,
                AssociateMemberPlanData = stateReport.AssociateMemberData,
                AssociateMemberPlanGeneratedData = stateReport.AssociateMemberGeneratedData,
                PreliminaryMemberPlanData = stateReport.PreliminaryMemberData,
                PreliminaryMemberPlanGeneratedData = stateReport.PreliminaryMemberGeneratedData,
                SupporterMemberPlanData = stateReport.SupporterMemberData,
                SupporterMemberPlanGeneratedData = stateReport.SupporterMemberGeneratedData,

                WorkerMeetingProgramPlanData = stateReport.WorkerMeetingProgramData,
                WorkerMeetingProgramPlanGeneratedData = stateReport.WorkerMeetingProgramGeneratedData,
                DawahMeetingProgramPlanData = stateReport.DawahMeetingProgramData,
                DawahMeetingProgramPlanGeneratedData = stateReport.DawahMeetingProgramGeneratedData,
                StateLeaderMeetingProgramPlanData = stateReport.StateLeaderMeetingProgramData,
                StateLeaderMeetingProgramPlanGeneratedData = stateReport.StateLeaderMeetingProgramGeneratedData,
                StateOutingMeetingProgramPlanData = stateReport.StateOutingMeetingProgramData,
                StateOutingMeetingProgramPlanGeneratedData = stateReport.StateOutingMeetingProgramGeneratedData,
                IftarMeetingProgramPlanData = stateReport.IftarMeetingProgramData,
                IftarMeetingProgramPlanGeneratedData = stateReport.IftarMeetingProgramGeneratedData,
                LearningMeetingProgramPlanData = stateReport.LearningMeetingProgramData,
                LearningMeetingProgramPlanGeneratedData = stateReport.LearningMeetingProgramGeneratedData,
                SocialDawahMeetingProgramPlanData = stateReport.SocialDawahMeetingProgramData,
                SocialDawahMeetingProgramPlanGeneratedData = stateReport.SocialDawahMeetingProgramGeneratedData,
                DawahGroupMeetingProgramPlanData = stateReport.DawahGroupMeetingProgramData,
                DawahGroupMeetingProgramPlanGeneratedData = stateReport.DawahGroupMeetingProgramGeneratedData,
                NextGMeetingProgramPlanData = stateReport.NextGMeetingProgramData,
                NextGMeetingProgramPlanGeneratedData = stateReport.NextGMeetingProgramGeneratedData,


                CmsMeetingProgramPlanData = stateReport.CmsMeetingProgramData,
                CmsMeetingProgramPlanGeneratedData = stateReport.CmsMeetingProgramGeneratedData,
                SmMeetingProgramPlanData = stateReport.SmMeetingProgramData,
                SmMeetingProgramPlanGeneratedData = stateReport.SmMeetingProgramGeneratedData,
                MemberMeetingProgramPlanData = stateReport.MemberMeetingProgramData,
                MemberMeetingProgramPlanGeneratedData = stateReport.MemberMeetingProgramGeneratedData,
                TafsirMeetingProgramPlanData = stateReport.TafsirMeetingProgramData,
                TafsirMeetingProgramPlanGeneratedData = stateReport.TafsirMeetingProgramGeneratedData,
                UnitMeetingProgramPlanData = stateReport.UnitMeetingProgramData,
                UnitMeetingProgramPlanGeneratedData = stateReport.UnitMeetingProgramGeneratedData,
                FamilyVisitMeetingProgramPlanData = stateReport.FamilyVisitMeetingProgramData,
                FamilyVisitMeetingProgramPlanGeneratedData = stateReport.FamilyVisitMeetingProgramGeneratedData,
                EidReunionMeetingProgramPlanData = stateReport.EidReunionMeetingProgramData,
                EidReunionMeetingProgramPlanGeneratedData = stateReport.EidReunionMeetingProgramGeneratedData,
                BbqMeetingProgramPlanData = stateReport.BbqMeetingProgramData,
                BbqMeetingProgramPlanGeneratedData = stateReport.BbqMeetingProgramGeneratedData,
                GatheringMeetingProgramPlanData = stateReport.GatheringMeetingProgramData,
                GatheringMeetingProgramPlanGeneratedData = stateReport.GatheringMeetingProgramGeneratedData,
                OtherMeetingProgramPlanData = stateReport.OtherMeetingProgramData,
                OtherMeetingProgramPlanGeneratedData = stateReport.OtherMeetingProgramGeneratedData,


                GroupStudyTeachingLearningProgramPlanData = stateReport.GroupStudyTeachingLearningProgramData,
                GroupStudyTeachingLearningProgramPlanGeneratedData = stateReport.GroupStudyTeachingLearningProgramGeneratedData,
                StudyCircleTeachingLearningProgramPlanData = stateReport.StudyCircleTeachingLearningProgramData,
                StudyCircleTeachingLearningProgramPlanGeneratedData = stateReport.StudyCircleTeachingLearningProgramGeneratedData,
                PracticeDarsTeachingLearningProgramPlanData = stateReport.PracticeDarsTeachingLearningProgramData,
                PracticeDarsTeachingLearningProgramPlanGeneratedData = stateReport.PracticeDarsTeachingLearningProgramGeneratedData,
                StateLearningCampTeachingLearningProgramPlanData = stateReport.StateLearningCampTeachingLearningProgramData,
                StateLearningCampTeachingLearningProgramPlanGeneratedData = stateReport.StateLearningCampTeachingLearningProgramGeneratedData,
                QuranStudyTeachingLearningProgramPlanData = stateReport.QuranStudyTeachingLearningProgramData,
                QuranStudyTeachingLearningProgramPlanGeneratedData = stateReport.QuranStudyTeachingLearningProgramGeneratedData,
                QuranClassTeachingLearningProgramPlanData = stateReport.QuranClassTeachingLearningProgramData,
                QuranClassTeachingLearningProgramPlanGeneratedData = stateReport.QuranClassTeachingLearningProgramGeneratedData,
                MemorizingAyatTeachingLearningProgramPlanData = stateReport.MemorizingAyatTeachingLearningProgramData,
                MemorizingAyatTeachingLearningProgramPlanGeneratedData = stateReport.MemorizingAyatTeachingLearningProgramGeneratedData,
                StateLearningSessionTeachingLearningProgramPlanData = stateReport.StateLearningSessionTeachingLearningProgramData,
                StateLearningSessionTeachingLearningProgramPlanGeneratedData = stateReport.StateLearningSessionTeachingLearningProgramGeneratedData,
                StateQiyamulLailTeachingLearningProgramPlanData = stateReport.StateQiyamulLailTeachingLearningProgramData,
                StateQiyamulLailTeachingLearningProgramPlanGeneratedData = stateReport.StateQiyamulLailTeachingLearningProgramGeneratedData,

                StudyCircleForAssociateMemberTeachingLearningProgramPlanData = stateReport.StudyCircleForAssociateMemberTeachingLearningProgramData,
                StudyCircleForAssociateMemberTeachingLearningProgramPlanGeneratedData = stateReport.StudyCircleForAssociateMemberTeachingLearningProgramGeneratedData,
                HadithTeachingLearningProgramPlanData = stateReport.HadithTeachingLearningProgramData,
                HadithTeachingLearningProgramPlanGeneratedData = stateReport.HadithTeachingLearningProgramGeneratedData,
                WeekendIslamicSchoolTeachingLearningProgramPlanData = stateReport.WeekendIslamicSchoolTeachingLearningProgramData,
                WeekendIslamicSchoolTeachingLearningProgramPlanGeneratedData = stateReport.WeekendIslamicSchoolTeachingLearningProgramGeneratedData,
                MemorizingHadithTeachingLearningProgramPlanData = stateReport.MemorizingHadithTeachingLearningProgramData,
                MemorizingHadithTeachingLearningProgramPlanGeneratedData = stateReport.MemorizingHadithTeachingLearningProgramGeneratedData,
                MemorizingDoaTeachingLearningProgramPlanData = stateReport.MemorizingDoaTeachingLearningProgramData,
                MemorizingDoaTeachingLearningProgramPlanGeneratedData = stateReport.MemorizingDoaTeachingLearningProgramGeneratedData,

                OtherTeachingLearningProgramPlanData = stateReport.OtherTeachingLearningProgramData,
                OtherTeachingLearningProgramPlanGeneratedData = stateReport.OtherTeachingLearningProgramGeneratedData,


                BookSaleMaterialPlanData = stateReport.BookSaleMaterialData,
                BookSaleMaterialPlanGeneratedData = stateReport.BookSaleMaterialGeneratedData,
                BookDistributionMaterialPlanData = stateReport.BookDistributionMaterialData,
                BookDistributionMaterialPlanGeneratedData = stateReport.BookDistributionMaterialGeneratedData,
                BookLibraryStockPlanData = stateReport.BookLibraryStockData,
                BookLibraryStockPlanGeneratedData = stateReport.BookLibraryStockGeneratedData,

                OtherSaleMaterialPlanData = stateReport.OtherSaleMaterialData,
                OtherSaleMaterialPlanGeneratedData = stateReport.OtherSaleMaterialGeneratedData,
                OtherDistributionMaterialPlanData = stateReport.OtherDistributionMaterialData,
                OtherDistributionMaterialPlanGeneratedData = stateReport.OtherDistributionMaterialGeneratedData,
                OtherLibraryStockPlanData = stateReport.OtherLibraryStockData,
                OtherLibraryStockPlanGeneratedData = stateReport.OtherLibraryStockGeneratedData,

                VhsSaleMaterialPlanData = stateReport.VhsSaleMaterialData,
                VhsSaleMaterialPlanGeneratedData = stateReport.VhsSaleMaterialGeneratedData,
                VhsDistributionMaterialPlanData = stateReport.VhsDistributionMaterialData,
                VhsDistributionMaterialPlanGeneratedData = stateReport.VhsDistributionMaterialGeneratedData,
                VhsLibraryStockPlanData = stateReport.VhsLibraryStockData,
                VhsLibraryStockPlanGeneratedData = stateReport.VhsLibraryStockGeneratedData,
                EmailDistributionMaterialPlanData = stateReport.EmailDistributionMaterialData,
                EmailDistributionMaterialPlanGeneratedData = stateReport.EmailDistributionMaterialGeneratedData,
                IpdcLeafletDistributionMaterialPlanData = stateReport.IpdcLeafletDistributionMaterialData,
                IpdcLeafletDistributionMaterialPlanGeneratedData = stateReport.IpdcLeafletDistributionMaterialGeneratedData,


                BaitulMalFinancePlanData = stateReport.BaitulMalFinanceData,
                BaitulMalFinancePlanGeneratedData = stateReport.BaitulMalFinanceGeneratedData,
                ADayMasjidProjectFinancePlanData = stateReport.ADayMasjidProjectFinanceData,
                ADayMasjidProjectFinancePlanGeneratedData = stateReport.ADayMasjidProjectFinanceGeneratedData,
                MasjidTableBankFinancePlanData = stateReport.MasjidTableBankFinanceData,
                MasjidTableBankFinancePlanGeneratedData = stateReport.MasjidTableBankFinanceGeneratedData,


                QardeHasanaSocialWelfarePlanData = stateReport.QardeHasanaSocialWelfareData,
                QardeHasanaSocialWelfarePlanGeneratedData = stateReport.QardeHasanaSocialWelfareGeneratedData,
                PatientVisitSocialWelfarePlanData = stateReport.PatientVisitSocialWelfareData,
                PatientVisitSocialWelfarePlanGeneratedData = stateReport.PatientVisitSocialWelfareGeneratedData,
                SocialVisitSocialWelfarePlanData = stateReport.SocialVisitSocialWelfareData,
                SocialVisitSocialWelfarePlanGeneratedData = stateReport.SocialVisitSocialWelfareGeneratedData,
                TransportSocialWelfarePlanData = stateReport.TransportSocialWelfareData,
                TransportSocialWelfarePlanGeneratedData = stateReport.TransportSocialWelfareGeneratedData,
                ShiftingSocialWelfarePlanData = stateReport.ShiftingSocialWelfareData,
                ShiftingSocialWelfarePlanGeneratedData = stateReport.ShiftingSocialWelfareGeneratedData,
                ShoppingSocialWelfarePlanData = stateReport.ShoppingSocialWelfareData,
                ShoppingSocialWelfarePlanGeneratedData = stateReport.ShoppingSocialWelfareGeneratedData,
                FoodDistributionSocialWelfarePlanData = stateReport.FoodDistributionSocialWelfareData,
                FoodDistributionSocialWelfarePlanGeneratedData = stateReport.FoodDistributionSocialWelfareGeneratedData,
                CleanUpAustraliaSocialWelfarePlanData = stateReport.CleanUpAustraliaSocialWelfareData,
                CleanUpAustraliaSocialWelfarePlanGeneratedData = stateReport.CleanUpAustraliaSocialWelfareGeneratedData,
                OtherSocialWelfarePlanData = stateReport.OtherSocialWelfareData,
                OtherSocialWelfarePlanGeneratedData = stateReport.OtherSocialWelfareGeneratedData,
            };
        }
        public static StateReportViewModel ConvertToStateReportViewModel(StateReport stateReport)
        {
            return new StateReportViewModel()
            {
                Id = stateReport.Id,
                Description = stateReport.Description,
                Organization = stateReport.Organization,
                ReportingPeriod = stateReport.ReportingPeriod,
                ReportStatus = stateReport.ReportStatus,
                ReOpenedReportStatus = stateReport.ReopenedReportStatus,
                Timestamp = stateReport.Timestamp,
                MemberMemberData = stateReport.MemberMemberData,
                MemberMemberGeneratedData = stateReport.MemberMemberData,
                AssociateMemberData = stateReport.AssociateMemberData,
                AssociateMemberGeneratedData = stateReport.AssociateMemberData,
                PreliminaryMemberData = stateReport.PreliminaryMemberData,
                PreliminaryMemberGeneratedData = stateReport.PreliminaryMemberData,
                SupporterMemberData = stateReport.SupporterMemberData,
                SupporterMemberGeneratedData = stateReport.SupporterMemberData,

                WorkerMeetingProgramData = stateReport.WorkerMeetingProgramData,
                WorkerMeetingProgramGeneratedData = stateReport.WorkerMeetingProgramData,
                DawahMeetingProgramData = stateReport.DawahMeetingProgramData,
                DawahMeetingProgramGeneratedData = stateReport.DawahMeetingProgramGeneratedData,
                StateLeaderMeetingProgramData = stateReport.StateLeaderMeetingProgramData,
                StateLeaderMeetingProgramGeneratedData = stateReport.StateLeaderMeetingProgramGeneratedData,
                StateOutingMeetingProgramData = stateReport.StateOutingMeetingProgramData,
                StateOutingMeetingProgramGeneratedData = stateReport.StateOutingMeetingProgramGeneratedData,
                IftarMeetingProgramData = stateReport.IftarMeetingProgramData,
                IftarMeetingProgramGeneratedData = stateReport.IftarMeetingProgramGeneratedData,
                LearningMeetingProgramData = stateReport.LearningMeetingProgramData,
                LearningMeetingProgramGeneratedData = stateReport.LearningMeetingProgramGeneratedData,
                SocialDawahMeetingProgramData = stateReport.SocialDawahMeetingProgramData,
                SocialDawahMeetingProgramGeneratedData = stateReport.SocialDawahMeetingProgramGeneratedData,
                DawahGroupMeetingProgramData = stateReport.DawahGroupMeetingProgramData,
                DawahGroupMeetingProgramGeneratedData = stateReport.DawahGroupMeetingProgramGeneratedData,
                NextGMeetingProgramData = stateReport.NextGMeetingProgramData,
                NextGMeetingProgramGeneratedData = stateReport.NextGMeetingProgramGeneratedData,

                CmsMeetingProgramData = stateReport.CmsMeetingProgramData,
                CmsMeetingProgramGeneratedData = stateReport.CmsMeetingProgramGeneratedData,
                SmMeetingProgramData = stateReport.SmMeetingProgramData,
                SmMeetingProgramGeneratedData = stateReport.SmMeetingProgramGeneratedData,
                MemberMeetingProgramData = stateReport.MemberMeetingProgramData,
                MemberMeetingProgramGeneratedData = stateReport.MemberMeetingProgramGeneratedData,
                TafsirMeetingProgramData = stateReport.TafsirMeetingProgramData,
                TafsirMeetingProgramGeneratedData = stateReport.TafsirMeetingProgramGeneratedData,
                UnitMeetingProgramData = stateReport.UnitMeetingProgramData,
                UnitMeetingProgramGeneratedData = stateReport.UnitMeetingProgramGeneratedData,
                FamilyVisitMeetingProgramData = stateReport.FamilyVisitMeetingProgramData,
                FamilyVisitMeetingProgramGeneratedData = stateReport.FamilyVisitMeetingProgramGeneratedData,
                EidReunionMeetingProgramData = stateReport.EidReunionMeetingProgramData,
                EidReunionMeetingProgramGeneratedData = stateReport.EidReunionMeetingProgramGeneratedData,
                BbqMeetingProgramData = stateReport.BbqMeetingProgramData,
                BbqMeetingProgramGeneratedData = stateReport.BbqMeetingProgramGeneratedData,
                GatheringMeetingProgramData = stateReport.GatheringMeetingProgramData,
                GatheringMeetingProgramGeneratedData = stateReport.GatheringMeetingProgramGeneratedData,

                OtherMeetingProgramData = stateReport.OtherMeetingProgramData,
                OtherMeetingProgramGeneratedData = stateReport.OtherMeetingProgramGeneratedData,

                GroupStudyTeachingLearningProgramData = stateReport.GroupStudyTeachingLearningProgramData,
                GroupStudyTeachingLearningProgramGeneratedData = stateReport.GroupStudyTeachingLearningProgramGeneratedData,
                StudyCircleTeachingLearningProgramData = stateReport.StudyCircleTeachingLearningProgramData,
                StudyCircleTeachingLearningProgramGeneratedData = stateReport.StudyCircleTeachingLearningProgramGeneratedData,
                PracticeDarsTeachingLearningProgramData = stateReport.PracticeDarsTeachingLearningProgramData,
                PracticeDarsTeachingLearningProgramGeneratedData = stateReport.PracticeDarsTeachingLearningProgramGeneratedData,
                StateLearningCampTeachingLearningProgramData = stateReport.StateLearningCampTeachingLearningProgramData,
                StateLearningCampTeachingLearningProgramGeneratedData = stateReport.StateLearningCampTeachingLearningProgramGeneratedData,
                QuranStudyTeachingLearningProgramData = stateReport.QuranStudyTeachingLearningProgramData,
                QuranStudyTeachingLearningProgramGeneratedData = stateReport.QuranStudyTeachingLearningProgramGeneratedData,
                QuranClassTeachingLearningProgramData = stateReport.QuranClassTeachingLearningProgramData,
                QuranClassTeachingLearningProgramGeneratedData = stateReport.QuranClassTeachingLearningProgramGeneratedData,
                MemorizingAyatTeachingLearningProgramData = stateReport.MemorizingAyatTeachingLearningProgramData,
                MemorizingAyatTeachingLearningProgramGeneratedData = stateReport.MemorizingAyatTeachingLearningProgramGeneratedData,
                StateLearningSessionTeachingLearningProgramData = stateReport.StateLearningSessionTeachingLearningProgramData,
                StateLearningSessionTeachingLearningProgramGeneratedData = stateReport.StateLearningSessionTeachingLearningProgramGeneratedData,
                StateQiyamulLailTeachingLearningProgramData = stateReport.StateQiyamulLailTeachingLearningProgramData,
                StateQiyamulLailTeachingLearningProgramGeneratedData = stateReport.StateQiyamulLailTeachingLearningProgramGeneratedData,

                StudyCircleForAssociateMemberTeachingLearningProgramData = stateReport.StudyCircleForAssociateMemberTeachingLearningProgramData,
                StudyCircleForAssociateMemberTeachingLearningProgramGeneratedData = stateReport.StudyCircleForAssociateMemberTeachingLearningProgramGeneratedData,
                HadithTeachingLearningProgramData = stateReport.HadithTeachingLearningProgramData,
                HadithTeachingLearningProgramGeneratedData = stateReport.HadithTeachingLearningProgramGeneratedData,
                WeekendIslamicSchoolTeachingLearningProgramData = stateReport.WeekendIslamicSchoolTeachingLearningProgramData,
                WeekendIslamicSchoolTeachingLearningProgramGeneratedData = stateReport.WeekendIslamicSchoolTeachingLearningProgramGeneratedData,
                MemorizingHadithTeachingLearningProgramData = stateReport.MemorizingHadithTeachingLearningProgramData,
                MemorizingHadithTeachingLearningProgramGeneratedData = stateReport.MemorizingHadithTeachingLearningProgramGeneratedData,
                MemorizingDoaTeachingLearningProgramData = stateReport.MemorizingDoaTeachingLearningProgramData,
                MemorizingDoaTeachingLearningProgramGeneratedData = stateReport.MemorizingDoaTeachingLearningProgramGeneratedData,
                OtherTeachingLearningProgramData = stateReport.OtherTeachingLearningProgramData,
                OtherTeachingLearningProgramGeneratedData = stateReport.OtherTeachingLearningProgramGeneratedData,

                BookSaleMaterialData = stateReport.BookSaleMaterialData,
                BookSaleMaterialGeneratedData = stateReport.BookSaleMaterialGeneratedData,
                BookDistributionMaterialData = stateReport.BookDistributionMaterialData,
                BookDistributionMaterialGeneratedData = stateReport.BookDistributionMaterialGeneratedData,
                BookLibraryStockData = stateReport.BookLibraryStockData,
                BookLibraryStockGeneratedData = stateReport.BookLibraryStockGeneratedData,
                OtherSaleMaterialData = stateReport.OtherSaleMaterialData,
                OtherSaleMaterialGeneratedData = stateReport.OtherSaleMaterialGeneratedData,
                OtherDistributionMaterialData = stateReport.OtherDistributionMaterialData,
                OtherDistributionMaterialGeneratedData = stateReport.OtherDistributionMaterialGeneratedData,
                OtherLibraryStockData = stateReport.OtherLibraryStockData,
                OtherLibraryStockGeneratedData = stateReport.OtherLibraryStockGeneratedData,
                VhsSaleMaterialData = stateReport.VhsSaleMaterialData,
                VhsSaleMaterialGeneratedData = stateReport.VhsSaleMaterialGeneratedData,
                VhsDistributionMaterialData = stateReport.VhsDistributionMaterialData,
                VhsDistributionMaterialGeneratedData = stateReport.VhsDistributionMaterialGeneratedData,
                VhsLibraryStockData = stateReport.VhsLibraryStockData,
                VhsLibraryStockGeneratedData = stateReport.VhsLibraryStockGeneratedData,
                EmailDistributionMaterialData = stateReport.EmailDistributionMaterialData,
                EmailDistributionMaterialGeneratedData = stateReport.EmailDistributionMaterialGeneratedData,
                IpdcLeafletDistributionMaterialData = stateReport.IpdcLeafletDistributionMaterialData,
                IpdcLeafletDistributionMaterialGeneratedData = stateReport.IpdcLeafletDistributionMaterialGeneratedData,

                BaitulMalFinanceData = stateReport.BaitulMalFinanceData,
                BaitulMalFinanceGeneratedData = stateReport.BaitulMalFinanceGeneratedData,

                ADayMasjidProjectFinanceData = stateReport.ADayMasjidProjectFinanceData,
                ADayMasjidProjectFinanceGeneratedData = stateReport.ADayMasjidProjectFinanceGeneratedData,
                MasjidTableBankFinanceData = stateReport.MasjidTableBankFinanceData,
                MasjidTableBankFinanceGeneratedData = stateReport.MasjidTableBankFinanceGeneratedData,

                QardeHasanaSocialWelfareData = stateReport.QardeHasanaSocialWelfareData,
                QardeHasanaSocialWelfareGeneratedData = stateReport.QardeHasanaSocialWelfareGeneratedData,
                PatientVisitSocialWelfareData = stateReport.PatientVisitSocialWelfareData,
                PatientVisitSocialWelfareGeneratedData = stateReport.PatientVisitSocialWelfareGeneratedData,
                SocialVisitSocialWelfareData = stateReport.SocialVisitSocialWelfareData,
                SocialVisitSocialWelfareGeneratedData = stateReport.SocialVisitSocialWelfareGeneratedData,
                TransportSocialWelfareData = stateReport.TransportSocialWelfareData,
                TransportSocialWelfareGeneratedData = stateReport.TransportSocialWelfareGeneratedData,
                ShiftingSocialWelfareData = stateReport.ShiftingSocialWelfareData,
                ShiftingSocialWelfareGeneratedData = stateReport.ShiftingSocialWelfareGeneratedData,
                ShoppingSocialWelfareData = stateReport.ShoppingSocialWelfareData,
                ShoppingSocialWelfareGeneratedData = stateReport.ShoppingSocialWelfareGeneratedData,
                FoodDistributionSocialWelfareData = stateReport.FoodDistributionSocialWelfareData,
                FoodDistributionSocialWelfareGeneratedData = stateReport.FoodDistributionSocialWelfareGeneratedData,
                CleanUpAustraliaSocialWelfareData = stateReport.CleanUpAustraliaSocialWelfareData,
                CleanUpAustraliaSocialWelfareGeneratedData = stateReport.CleanUpAustraliaSocialWelfareGeneratedData,
                OtherSocialWelfareData = stateReport.OtherSocialWelfareData,
                OtherSocialWelfareGeneratedData = stateReport.OtherSocialWelfareGeneratedData,
            };
        }

        public static CentralPlanViewModel ConvertToCentralPlanViewModel(CentralReport centralReport)
        {
            return new CentralPlanViewModel()
            {
                Id = centralReport.Id,
                Description = centralReport.Description,
                Organization = centralReport.Organization,
                ReportingPeriod = centralReport.ReportingPeriod,
                ReportStatus = centralReport.ReportStatus,
                ReOpenedReportStatus = centralReport.ReopenedReportStatus,
                Timestamp = centralReport.Timestamp,
                MemberMemberPlanData = centralReport.MemberMemberData,
                MemberMemberPlanGeneratedData = centralReport.MemberMemberGeneratedData,
                AssociateMemberPlanData = centralReport.AssociateMemberData,
                AssociateMemberPlanGeneratedData = centralReport.AssociateMemberGeneratedData,
                PreliminaryMemberPlanData = centralReport.PreliminaryMemberData,
                PreliminaryMemberPlanGeneratedData = centralReport.PreliminaryMemberGeneratedData,
                SupporterMemberPlanData = centralReport.SupporterMemberData,
                SupporterMemberPlanGeneratedData = centralReport.SupporterMemberGeneratedData,

                WorkerMeetingProgramPlanData = centralReport.WorkerMeetingProgramData,
                WorkerMeetingProgramPlanGeneratedData = centralReport.WorkerMeetingProgramGeneratedData,
                DawahMeetingProgramPlanData = centralReport.DawahMeetingProgramData,
                DawahMeetingProgramPlanGeneratedData = centralReport.DawahMeetingProgramGeneratedData,
                StateLeaderMeetingProgramPlanData = centralReport.StateLeaderMeetingProgramData,
                StateLeaderMeetingProgramPlanGeneratedData = centralReport.StateLeaderMeetingProgramGeneratedData,
                StateOutingMeetingProgramPlanData = centralReport.StateOutingMeetingProgramData,
                StateOutingMeetingProgramPlanGeneratedData = centralReport.StateOutingMeetingProgramGeneratedData,
                IftarMeetingProgramPlanData = centralReport.IftarMeetingProgramData,
                IftarMeetingProgramPlanGeneratedData = centralReport.IftarMeetingProgramGeneratedData,
                LearningMeetingProgramPlanData = centralReport.LearningMeetingProgramData,
                LearningMeetingProgramPlanGeneratedData = centralReport.LearningMeetingProgramGeneratedData,
                SocialDawahMeetingProgramPlanData = centralReport.SocialDawahMeetingProgramData,
                SocialDawahMeetingProgramPlanGeneratedData = centralReport.SocialDawahMeetingProgramGeneratedData,
                DawahGroupMeetingProgramPlanData = centralReport.DawahGroupMeetingProgramData,
                DawahGroupMeetingProgramPlanGeneratedData = centralReport.DawahGroupMeetingProgramGeneratedData,
                NextGMeetingProgramPlanData = centralReport.NextGMeetingProgramData,
                NextGMeetingProgramPlanGeneratedData = centralReport.NextGMeetingProgramGeneratedData,


                CmsMeetingProgramPlanData = centralReport.CmsMeetingProgramData,
                CmsMeetingProgramPlanGeneratedData = centralReport.CmsMeetingProgramGeneratedData,
                SmMeetingProgramPlanData = centralReport.SmMeetingProgramData,
                SmMeetingProgramPlanGeneratedData = centralReport.SmMeetingProgramGeneratedData,
                MemberMeetingProgramPlanData = centralReport.MemberMeetingProgramData,
                MemberMeetingProgramPlanGeneratedData = centralReport.MemberMeetingProgramGeneratedData,
                TafsirMeetingProgramPlanData = centralReport.TafsirMeetingProgramData,
                TafsirMeetingProgramPlanGeneratedData = centralReport.TafsirMeetingProgramGeneratedData,
                UnitMeetingProgramPlanData = centralReport.UnitMeetingProgramData,
                UnitMeetingProgramPlanGeneratedData = centralReport.UnitMeetingProgramGeneratedData,
                FamilyVisitMeetingProgramPlanData = centralReport.FamilyVisitMeetingProgramData,
                FamilyVisitMeetingProgramPlanGeneratedData = centralReport.FamilyVisitMeetingProgramGeneratedData,
                EidReunionMeetingProgramPlanData = centralReport.EidReunionMeetingProgramData,
                EidReunionMeetingProgramPlanGeneratedData = centralReport.EidReunionMeetingProgramGeneratedData,
                BbqMeetingProgramPlanData = centralReport.BbqMeetingProgramData,
                BbqMeetingProgramPlanGeneratedData = centralReport.BbqMeetingProgramGeneratedData,
                GatheringMeetingProgramPlanData = centralReport.GatheringMeetingProgramData,
                GatheringMeetingProgramPlanGeneratedData = centralReport.GatheringMeetingProgramGeneratedData,
                OtherMeetingProgramPlanData = centralReport.OtherMeetingProgramData,
                OtherMeetingProgramPlanGeneratedData = centralReport.OtherMeetingProgramGeneratedData,


                GroupStudyTeachingLearningProgramPlanData = centralReport.GroupStudyTeachingLearningProgramData,
                GroupStudyTeachingLearningProgramPlanGeneratedData = centralReport.GroupStudyTeachingLearningProgramGeneratedData,
                StudyCircleTeachingLearningProgramPlanData = centralReport.StudyCircleTeachingLearningProgramData,
                StudyCircleTeachingLearningProgramPlanGeneratedData = centralReport.StudyCircleTeachingLearningProgramGeneratedData,
                PracticeDarsTeachingLearningProgramPlanData = centralReport.PracticeDarsTeachingLearningProgramData,
                PracticeDarsTeachingLearningProgramPlanGeneratedData = centralReport.PracticeDarsTeachingLearningProgramGeneratedData,
                StateLearningCampTeachingLearningProgramPlanData = centralReport.StateLearningCampTeachingLearningProgramData,
                StateLearningCampTeachingLearningProgramPlanGeneratedData = centralReport.StateLearningCampTeachingLearningProgramGeneratedData,
                QuranStudyTeachingLearningProgramPlanData = centralReport.QuranStudyTeachingLearningProgramData,
                QuranStudyTeachingLearningProgramPlanGeneratedData = centralReport.QuranStudyTeachingLearningProgramGeneratedData,
                QuranClassTeachingLearningProgramPlanData = centralReport.QuranClassTeachingLearningProgramData,
                QuranClassTeachingLearningProgramPlanGeneratedData = centralReport.QuranClassTeachingLearningProgramGeneratedData,
                MemorizingAyatTeachingLearningProgramPlanData = centralReport.MemorizingAyatTeachingLearningProgramData,
                MemorizingAyatTeachingLearningProgramPlanGeneratedData = centralReport.MemorizingAyatTeachingLearningProgramGeneratedData,
                StateLearningSessionTeachingLearningProgramPlanData = centralReport.StateLearningSessionTeachingLearningProgramData,
                StateLearningSessionTeachingLearningProgramPlanGeneratedData = centralReport.StateLearningSessionTeachingLearningProgramGeneratedData,
                StateQiyamulLailTeachingLearningProgramPlanData = centralReport.StateQiyamulLailTeachingLearningProgramData,
                StateQiyamulLailTeachingLearningProgramPlanGeneratedData = centralReport.StateQiyamulLailTeachingLearningProgramGeneratedData,

                StudyCircleForAssociateMemberTeachingLearningProgramPlanData = centralReport.StudyCircleForAssociateMemberTeachingLearningProgramData,
                StudyCircleForAssociateMemberTeachingLearningProgramPlanGeneratedData = centralReport.StudyCircleForAssociateMemberTeachingLearningProgramGeneratedData,
                HadithTeachingLearningProgramPlanData = centralReport.HadithTeachingLearningProgramData,
                HadithTeachingLearningProgramPlanGeneratedData = centralReport.HadithTeachingLearningProgramGeneratedData,
                WeekendIslamicSchoolTeachingLearningProgramPlanData = centralReport.WeekendIslamicSchoolTeachingLearningProgramData,
                WeekendIslamicSchoolTeachingLearningProgramPlanGeneratedData = centralReport.WeekendIslamicSchoolTeachingLearningProgramGeneratedData,
                MemorizingHadithTeachingLearningProgramPlanData = centralReport.MemorizingHadithTeachingLearningProgramData,
                MemorizingHadithTeachingLearningProgramPlanGeneratedData = centralReport.MemorizingHadithTeachingLearningProgramGeneratedData,
                MemorizingDoaTeachingLearningProgramPlanData = centralReport.MemorizingDoaTeachingLearningProgramData,
                MemorizingDoaTeachingLearningProgramPlanGeneratedData = centralReport.MemorizingDoaTeachingLearningProgramGeneratedData,

                OtherTeachingLearningProgramPlanData = centralReport.OtherTeachingLearningProgramData,
                OtherTeachingLearningProgramPlanGeneratedData = centralReport.OtherTeachingLearningProgramGeneratedData,


                BookSaleMaterialPlanData = centralReport.BookSaleMaterialData,
                BookSaleMaterialPlanGeneratedData = centralReport.BookSaleMaterialGeneratedData,
                BookDistributionMaterialPlanData = centralReport.BookDistributionMaterialData,
                BookDistributionMaterialPlanGeneratedData = centralReport.BookDistributionMaterialGeneratedData,
                BookLibraryStockPlanData = centralReport.BookLibraryStockData,
                BookLibraryStockPlanGeneratedData = centralReport.BookLibraryStockGeneratedData,

                OtherSaleMaterialPlanData = centralReport.OtherSaleMaterialData,
                OtherSaleMaterialPlanGeneratedData = centralReport.OtherSaleMaterialGeneratedData,
                OtherDistributionMaterialPlanData = centralReport.OtherDistributionMaterialData,
                OtherDistributionMaterialPlanGeneratedData = centralReport.OtherDistributionMaterialGeneratedData,
                OtherLibraryStockPlanData = centralReport.OtherLibraryStockData,
                OtherLibraryStockPlanGeneratedData = centralReport.OtherLibraryStockGeneratedData,

                VhsSaleMaterialPlanData = centralReport.VhsSaleMaterialData,
                VhsSaleMaterialPlanGeneratedData = centralReport.VhsSaleMaterialGeneratedData,
                VhsDistributionMaterialPlanData = centralReport.VhsDistributionMaterialData,
                VhsDistributionMaterialPlanGeneratedData = centralReport.VhsDistributionMaterialGeneratedData,
                VhsLibraryStockPlanData = centralReport.VhsLibraryStockData,
                VhsLibraryStockPlanGeneratedData = centralReport.VhsLibraryStockGeneratedData,
                EmailDistributionMaterialPlanData = centralReport.EmailDistributionMaterialData,
                EmailDistributionMaterialPlanGeneratedData = centralReport.EmailDistributionMaterialGeneratedData,
                IpdcLeafletDistributionMaterialPlanData = centralReport.IpdcLeafletDistributionMaterialData,
                IpdcLeafletDistributionMaterialPlanGeneratedData = centralReport.IpdcLeafletDistributionMaterialGeneratedData,


                BaitulMalFinancePlanData = centralReport.BaitulMalFinanceData,
                BaitulMalFinancePlanGeneratedData = centralReport.BaitulMalFinanceGeneratedData,
                ADayMasjidProjectFinancePlanData = centralReport.ADayMasjidProjectFinanceData,
                ADayMasjidProjectFinancePlanGeneratedData = centralReport.ADayMasjidProjectFinanceGeneratedData,
                MasjidTableBankFinancePlanData = centralReport.MasjidTableBankFinanceData,
                MasjidTableBankFinancePlanGeneratedData = centralReport.MasjidTableBankFinanceGeneratedData,


                QardeHasanaSocialWelfarePlanData = centralReport.QardeHasanaSocialWelfareData,
                QardeHasanaSocialWelfarePlanGeneratedData = centralReport.QardeHasanaSocialWelfareGeneratedData,
                PatientVisitSocialWelfarePlanData = centralReport.PatientVisitSocialWelfareData,
                PatientVisitSocialWelfarePlanGeneratedData = centralReport.PatientVisitSocialWelfareGeneratedData,
                SocialVisitSocialWelfarePlanData = centralReport.SocialVisitSocialWelfareData,
                SocialVisitSocialWelfarePlanGeneratedData = centralReport.SocialVisitSocialWelfareGeneratedData,
                TransportSocialWelfarePlanData = centralReport.TransportSocialWelfareData,
                TransportSocialWelfarePlanGeneratedData = centralReport.TransportSocialWelfareGeneratedData,
                ShiftingSocialWelfarePlanData = centralReport.ShiftingSocialWelfareData,
                ShiftingSocialWelfarePlanGeneratedData = centralReport.ShiftingSocialWelfareGeneratedData,
                ShoppingSocialWelfarePlanData = centralReport.ShoppingSocialWelfareData,
                ShoppingSocialWelfarePlanGeneratedData = centralReport.ShoppingSocialWelfareGeneratedData,
                FoodDistributionSocialWelfarePlanData = centralReport.FoodDistributionSocialWelfareData,
                FoodDistributionSocialWelfarePlanGeneratedData = centralReport.FoodDistributionSocialWelfareGeneratedData,
                CleanUpAustraliaSocialWelfarePlanData = centralReport.CleanUpAustraliaSocialWelfareData,
                CleanUpAustraliaSocialWelfarePlanGeneratedData = centralReport.CleanUpAustraliaSocialWelfareGeneratedData,
                OtherSocialWelfarePlanData = centralReport.OtherSocialWelfareData,
                OtherSocialWelfarePlanGeneratedData = centralReport.OtherSocialWelfareGeneratedData,
            };
        }
        public static CentralReportViewModel ConvertToCentralReportViewModel(CentralReport centralReport)
        {
            return new CentralReportViewModel()
            {
                Id = centralReport.Id,
                Description = centralReport.Description,
                Organization = centralReport.Organization,
                ReportingPeriod = centralReport.ReportingPeriod,
                ReportStatus = centralReport.ReportStatus,
                ReOpenedReportStatus = centralReport.ReopenedReportStatus,
                Timestamp = centralReport.Timestamp,
                MemberMemberData = centralReport.MemberMemberData,
                MemberMemberGeneratedData = centralReport.MemberMemberData,
                AssociateMemberData = centralReport.AssociateMemberData,
                AssociateMemberGeneratedData = centralReport.AssociateMemberData,
                PreliminaryMemberData = centralReport.PreliminaryMemberData,
                PreliminaryMemberGeneratedData = centralReport.PreliminaryMemberData,
                SupporterMemberData = centralReport.SupporterMemberData,
                SupporterMemberGeneratedData = centralReport.SupporterMemberData,

                WorkerMeetingProgramData = centralReport.WorkerMeetingProgramData,
                WorkerMeetingProgramGeneratedData = centralReport.WorkerMeetingProgramData,
                DawahMeetingProgramData = centralReport.DawahMeetingProgramData,
                DawahMeetingProgramGeneratedData = centralReport.DawahMeetingProgramGeneratedData,
                StateLeaderMeetingProgramData = centralReport.StateLeaderMeetingProgramData,
                StateLeaderMeetingProgramGeneratedData = centralReport.StateLeaderMeetingProgramGeneratedData,
                StateOutingMeetingProgramData = centralReport.StateOutingMeetingProgramData,
                StateOutingMeetingProgramGeneratedData = centralReport.StateOutingMeetingProgramGeneratedData,
                IftarMeetingProgramData = centralReport.IftarMeetingProgramData,
                IftarMeetingProgramGeneratedData = centralReport.IftarMeetingProgramGeneratedData,
                LearningMeetingProgramData = centralReport.LearningMeetingProgramData,
                LearningMeetingProgramGeneratedData = centralReport.LearningMeetingProgramGeneratedData,
                SocialDawahMeetingProgramData = centralReport.SocialDawahMeetingProgramData,
                SocialDawahMeetingProgramGeneratedData = centralReport.SocialDawahMeetingProgramGeneratedData,
                DawahGroupMeetingProgramData = centralReport.DawahGroupMeetingProgramData,
                DawahGroupMeetingProgramGeneratedData = centralReport.DawahGroupMeetingProgramGeneratedData,
                NextGMeetingProgramData = centralReport.NextGMeetingProgramData,
                NextGMeetingProgramGeneratedData = centralReport.NextGMeetingProgramGeneratedData,

                CmsMeetingProgramData = centralReport.CmsMeetingProgramData,
                CmsMeetingProgramGeneratedData = centralReport.CmsMeetingProgramGeneratedData,
                SmMeetingProgramData = centralReport.SmMeetingProgramData,
                SmMeetingProgramGeneratedData = centralReport.SmMeetingProgramGeneratedData,
                MemberMeetingProgramData = centralReport.MemberMeetingProgramData,
                MemberMeetingProgramGeneratedData = centralReport.MemberMeetingProgramGeneratedData,
                TafsirMeetingProgramData = centralReport.TafsirMeetingProgramData,
                TafsirMeetingProgramGeneratedData = centralReport.TafsirMeetingProgramGeneratedData,
                UnitMeetingProgramData = centralReport.UnitMeetingProgramData,
                UnitMeetingProgramGeneratedData = centralReport.UnitMeetingProgramGeneratedData,
                FamilyVisitMeetingProgramData = centralReport.FamilyVisitMeetingProgramData,
                FamilyVisitMeetingProgramGeneratedData = centralReport.FamilyVisitMeetingProgramGeneratedData,
                EidReunionMeetingProgramData = centralReport.EidReunionMeetingProgramData,
                EidReunionMeetingProgramGeneratedData = centralReport.EidReunionMeetingProgramGeneratedData,
                BbqMeetingProgramData = centralReport.BbqMeetingProgramData,
                BbqMeetingProgramGeneratedData = centralReport.BbqMeetingProgramGeneratedData,
                GatheringMeetingProgramData = centralReport.GatheringMeetingProgramData,
                GatheringMeetingProgramGeneratedData = centralReport.GatheringMeetingProgramGeneratedData,

                OtherMeetingProgramData = centralReport.OtherMeetingProgramData,
                OtherMeetingProgramGeneratedData = centralReport.OtherMeetingProgramGeneratedData,

                GroupStudyTeachingLearningProgramData = centralReport.GroupStudyTeachingLearningProgramData,
                GroupStudyTeachingLearningProgramGeneratedData = centralReport.GroupStudyTeachingLearningProgramGeneratedData,
                StudyCircleTeachingLearningProgramData = centralReport.StudyCircleTeachingLearningProgramData,
                StudyCircleTeachingLearningProgramGeneratedData = centralReport.StudyCircleTeachingLearningProgramGeneratedData,
                PracticeDarsTeachingLearningProgramData = centralReport.PracticeDarsTeachingLearningProgramData,
                PracticeDarsTeachingLearningProgramGeneratedData = centralReport.PracticeDarsTeachingLearningProgramGeneratedData,
                StateLearningCampTeachingLearningProgramData = centralReport.StateLearningCampTeachingLearningProgramData,
                StateLearningCampTeachingLearningProgramGeneratedData = centralReport.StateLearningCampTeachingLearningProgramGeneratedData,
                QuranStudyTeachingLearningProgramData = centralReport.QuranStudyTeachingLearningProgramData,
                QuranStudyTeachingLearningProgramGeneratedData = centralReport.QuranStudyTeachingLearningProgramGeneratedData,
                QuranClassTeachingLearningProgramData = centralReport.QuranClassTeachingLearningProgramData,
                QuranClassTeachingLearningProgramGeneratedData = centralReport.QuranClassTeachingLearningProgramGeneratedData,
                MemorizingAyatTeachingLearningProgramData = centralReport.MemorizingAyatTeachingLearningProgramData,
                MemorizingAyatTeachingLearningProgramGeneratedData = centralReport.MemorizingAyatTeachingLearningProgramGeneratedData,
                StateLearningSessionTeachingLearningProgramData = centralReport.StateLearningSessionTeachingLearningProgramData,
                StateLearningSessionTeachingLearningProgramGeneratedData = centralReport.StateLearningSessionTeachingLearningProgramGeneratedData,
                StateQiyamulLailTeachingLearningProgramData = centralReport.StateQiyamulLailTeachingLearningProgramData,
                StateQiyamulLailTeachingLearningProgramGeneratedData = centralReport.StateQiyamulLailTeachingLearningProgramGeneratedData,

                StudyCircleForAssociateMemberTeachingLearningProgramData = centralReport.StudyCircleForAssociateMemberTeachingLearningProgramData,
                StudyCircleForAssociateMemberTeachingLearningProgramGeneratedData = centralReport.StudyCircleForAssociateMemberTeachingLearningProgramGeneratedData,
                HadithTeachingLearningProgramData = centralReport.HadithTeachingLearningProgramData,
                HadithTeachingLearningProgramGeneratedData = centralReport.HadithTeachingLearningProgramGeneratedData,
                WeekendIslamicSchoolTeachingLearningProgramData = centralReport.WeekendIslamicSchoolTeachingLearningProgramData,
                WeekendIslamicSchoolTeachingLearningProgramGeneratedData = centralReport.WeekendIslamicSchoolTeachingLearningProgramGeneratedData,
                MemorizingHadithTeachingLearningProgramData = centralReport.MemorizingHadithTeachingLearningProgramData,
                MemorizingHadithTeachingLearningProgramGeneratedData = centralReport.MemorizingHadithTeachingLearningProgramGeneratedData,
                MemorizingDoaTeachingLearningProgramData = centralReport.MemorizingDoaTeachingLearningProgramData,
                MemorizingDoaTeachingLearningProgramGeneratedData = centralReport.MemorizingDoaTeachingLearningProgramGeneratedData,
                OtherTeachingLearningProgramData = centralReport.OtherTeachingLearningProgramData,
                OtherTeachingLearningProgramGeneratedData = centralReport.OtherTeachingLearningProgramGeneratedData,

                BookSaleMaterialData = centralReport.BookSaleMaterialData,
                BookSaleMaterialGeneratedData = centralReport.BookSaleMaterialGeneratedData,
                BookDistributionMaterialData = centralReport.BookDistributionMaterialData,
                BookDistributionMaterialGeneratedData = centralReport.BookDistributionMaterialGeneratedData,
                BookLibraryStockData = centralReport.BookLibraryStockData,
                BookLibraryStockGeneratedData = centralReport.BookLibraryStockGeneratedData,
                OtherSaleMaterialData = centralReport.OtherSaleMaterialData,
                OtherSaleMaterialGeneratedData = centralReport.OtherSaleMaterialGeneratedData,
                OtherDistributionMaterialData = centralReport.OtherDistributionMaterialData,
                OtherDistributionMaterialGeneratedData = centralReport.OtherDistributionMaterialGeneratedData,
                OtherLibraryStockData = centralReport.OtherLibraryStockData,
                OtherLibraryStockGeneratedData = centralReport.OtherLibraryStockGeneratedData,
                VhsSaleMaterialData = centralReport.VhsSaleMaterialData,
                VhsSaleMaterialGeneratedData = centralReport.VhsSaleMaterialGeneratedData,
                VhsDistributionMaterialData = centralReport.VhsDistributionMaterialData,
                VhsDistributionMaterialGeneratedData = centralReport.VhsDistributionMaterialGeneratedData,
                VhsLibraryStockData = centralReport.VhsLibraryStockData,
                VhsLibraryStockGeneratedData = centralReport.VhsLibraryStockGeneratedData,
                EmailDistributionMaterialData = centralReport.EmailDistributionMaterialData,
                EmailDistributionMaterialGeneratedData = centralReport.EmailDistributionMaterialGeneratedData,
                IpdcLeafletDistributionMaterialData = centralReport.IpdcLeafletDistributionMaterialData,
                IpdcLeafletDistributionMaterialGeneratedData = centralReport.IpdcLeafletDistributionMaterialGeneratedData,

                BaitulMalFinanceData = centralReport.BaitulMalFinanceData,
                BaitulMalFinanceGeneratedData = centralReport.BaitulMalFinanceGeneratedData,

                ADayMasjidProjectFinanceData = centralReport.ADayMasjidProjectFinanceData,
                ADayMasjidProjectFinanceGeneratedData = centralReport.ADayMasjidProjectFinanceGeneratedData,
                MasjidTableBankFinanceData = centralReport.MasjidTableBankFinanceData,
                MasjidTableBankFinanceGeneratedData = centralReport.MasjidTableBankFinanceGeneratedData,

                QardeHasanaSocialWelfareData = centralReport.QardeHasanaSocialWelfareData,
                QardeHasanaSocialWelfareGeneratedData = centralReport.QardeHasanaSocialWelfareGeneratedData,
                PatientVisitSocialWelfareData = centralReport.PatientVisitSocialWelfareData,
                PatientVisitSocialWelfareGeneratedData = centralReport.PatientVisitSocialWelfareGeneratedData,
                SocialVisitSocialWelfareData = centralReport.SocialVisitSocialWelfareData,
                SocialVisitSocialWelfareGeneratedData = centralReport.SocialVisitSocialWelfareGeneratedData,
                TransportSocialWelfareData = centralReport.TransportSocialWelfareData,
                TransportSocialWelfareGeneratedData = centralReport.TransportSocialWelfareGeneratedData,
                ShiftingSocialWelfareData = centralReport.ShiftingSocialWelfareData,
                ShiftingSocialWelfareGeneratedData = centralReport.ShiftingSocialWelfareGeneratedData,
                ShoppingSocialWelfareData = centralReport.ShoppingSocialWelfareData,
                ShoppingSocialWelfareGeneratedData = centralReport.ShoppingSocialWelfareGeneratedData,
                FoodDistributionSocialWelfareData = centralReport.FoodDistributionSocialWelfareData,
                FoodDistributionSocialWelfareGeneratedData = centralReport.FoodDistributionSocialWelfareGeneratedData,
                CleanUpAustraliaSocialWelfareData = centralReport.CleanUpAustraliaSocialWelfareData,
                CleanUpAustraliaSocialWelfareGeneratedData = centralReport.CleanUpAustraliaSocialWelfareGeneratedData,
                OtherSocialWelfareData = centralReport.OtherSocialWelfareData,
                OtherSocialWelfareGeneratedData = centralReport.OtherSocialWelfareGeneratedData,
            };
        }

        public static ReportViewModel ConvertToReportViewModel(UnitReport unitReport)
        {
            return new ReportViewModel()
            {
                Id = unitReport.Id,
                Description = unitReport.Description,
                Organization = unitReport.Organization,
                ReportingPeriod = unitReport.ReportingPeriod,
                ReportStatus = unitReport.ReportStatus,
                ReOpenedReportStatus = unitReport.ReopenedReportStatus,
                Timestamp = unitReport.Timestamp,
            };
        }
        public static ReportViewModel ConvertToReportViewModel(StateReport stateReport)
        {
            return new ReportViewModel()
            {
                Id = stateReport.Id,
                Description = stateReport.Description,
                Organization = stateReport.Organization,
                ReportingPeriod = stateReport.ReportingPeriod,
                ReportStatus = stateReport.ReportStatus,
                ReOpenedReportStatus = stateReport.ReopenedReportStatus,
                Timestamp = stateReport.Timestamp,
            };
        }

        public static ReportViewModel ConvertToReportViewModel(ZoneReport zoneReport)
        {
            return new ReportViewModel()
            {
                Id = zoneReport.Id,
                Description = zoneReport.Description,
                Organization = zoneReport.Organization,
                ReportingPeriod = zoneReport.ReportingPeriod,
                ReportStatus = zoneReport.ReportStatus,
                ReOpenedReportStatus = zoneReport.ReopenedReportStatus,
                Timestamp = zoneReport.Timestamp,
            };
        }
        public static ReportViewModel ConvertToReportViewModel(CentralReport centralReport)
        {
            return new ReportViewModel()
            {
                Id = centralReport.Id,
                Description = centralReport.Description,
                Organization = centralReport.Organization,
                ReportingPeriod = centralReport.ReportingPeriod,
                ReportStatus = centralReport.ReportStatus,
                ReOpenedReportStatus = centralReport.ReopenedReportStatus,
                Timestamp = centralReport.Timestamp,
            };
        }
    }
}