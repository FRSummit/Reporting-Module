/*using FluentNHibernate.Mapping;
using ReportingModule.Core.Fluent;

namespace NsbWeb.ReportingModule.ViewModels.Dal
{
    public class StatePlanViewModelMap : ClassMap<StatePlanViewModel>
    {
        public StatePlanViewModelMap()
        {
            Not.LazyLoad();
            ReadOnly();

            Table("Report");
            Where("IsDeleted = 0 AND OrganizationOrganizationType = 3");
            Id(x => x.Id);
            Map(x => x.Description);
            this.MapComponentWithPrefix(x => x.Organization);
            this.MapComponentWithPrefix(x => x.ReportingPeriod);
            Map(x => x.ReportStatus);
            Map(x => x.ReOpenedReportStatus);
            Map(x => x.Timestamp);
            Join("MemberMemberData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MemberMemberPlanData);
                    j.Optional();
                });
            Join("MemberMemberGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MemberMemberPlanGeneratedData);
                    j.Optional();
                });
            Join("AssociateMemberData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.AssociateMemberPlanData);
                    j.Optional();
                });
            Join("AssociateMemberGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.AssociateMemberPlanGeneratedData);
                    j.Optional();
                });
            Join("PreliminaryMemberData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.PreliminaryMemberPlanData);
                    j.Optional();
                });
            Join("PreliminaryMemberGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.PreliminaryMemberPlanGeneratedData);
                    j.Optional();
                });
            Join("SupporterMemberData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.SupporterMemberPlanData);
                    j.Optional();
                });
            Join("SupporterMemberGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.SupporterMemberPlanGeneratedData);
                    j.Optional();
                });
            Join("WorkerMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.WorkerMeetingProgramPlanData);
                    j.Optional();
                });
            Join("WorkerMeetingGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.WorkerMeetingProgramPlanGeneratedData);
                    j.Optional();
                });
            Join("DawahMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.DawahMeetingProgramPlanData);
                    j.Optional();
                });
            Join("DawahMeetingGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.DawahMeetingProgramPlanGeneratedData);
                    j.Optional();
                });
            Join("StateLeaderMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.StateLeaderMeetingProgramPlanData);
                    j.Optional();
                });
            Join("StateLeaderMeetingGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.StateLeaderMeetingProgramPlanGeneratedData);
                        j.Optional();
                    });
            Join("StateOutingMeetingData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.StateOutingMeetingProgramPlanData);
                        j.Optional();
                    });
            Join("StateOutingMeetingGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.StateOutingMeetingProgramPlanGeneratedData);
                        j.Optional();
                    });
            Join("IftarMeetingData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.IftarMeetingProgramPlanData);
                        j.Optional();
                    });
            Join("IftarMeetingGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.IftarMeetingProgramPlanGeneratedData);
                        j.Optional();
                    });
            Join("LearningMeetingData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.LearningMeetingProgramPlanData);
                        j.Optional();
                    });
            Join("LearningMeetingGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.LearningMeetingProgramPlanGeneratedData);
                        j.Optional();
                    });
            Join("SocialDawahMeetingData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.SocialDawahMeetingProgramPlanData);
                        j.Optional();
                    });
            Join("SocialDawahMeetingGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.SocialDawahMeetingProgramPlanGeneratedData);
                        j.Optional();
                    });
            Join("DawahGroupMeetingData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.DawahGroupMeetingProgramPlanData);
                        j.Optional();
                    });
            Join("DawahGroupMeetingGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.DawahGroupMeetingProgramPlanGeneratedData);
                        j.Optional();
                    });
            Join("NextGMeetingData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.NextGMeetingProgramPlanData);
                        j.Optional();
                    });
            Join("NextGMeetingGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.NextGMeetingProgramPlanGeneratedData);
                        j.Optional();
                    });


            Join("CmsMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.CmsMeetingProgramPlanData);
                    j.Optional();
                });
            Join("CmsMeetingGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.CmsMeetingProgramPlanGeneratedData);
                    j.Optional();
                });
            Join("SmMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.SmMeetingProgramPlanData);
                    j.Optional();
                });
            Join("SmMeetingGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.SmMeetingProgramPlanGeneratedData);
                    j.Optional();
                });
            Join("MemberMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MemberMeetingProgramPlanData);
                    j.Optional();
                });
            Join("MemberMeetingGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MemberMeetingProgramPlanGeneratedData);
                    j.Optional();
                });
            Join("TafsirMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.TafsirMeetingProgramPlanData);
                    j.Optional();
                });
            Join("TafsirMeetingGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.TafsirMeetingProgramPlanGeneratedData);
                    j.Optional();
                });
            Join("UnitMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.UnitMeetingProgramPlanData);
                    j.Optional();
                });
            Join("UnitMeetingGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.UnitMeetingProgramPlanGeneratedData);
                    j.Optional();
                });
            Join("FamilyVisitMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.FamilyVisitMeetingProgramPlanData);
                    j.Optional();
                });
            Join("FamilyVisitMeetingGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.FamilyVisitMeetingProgramPlanGeneratedData);
                    j.Optional();
                });
            Join("EidReunionMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.EidReunionMeetingProgramPlanData);
                    j.Optional();
                });
            Join("EidReunionMeetingGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.EidReunionMeetingProgramPlanGeneratedData);
                    j.Optional();
                });
            Join("BbqMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BbqMeetingProgramPlanData);
                    j.Optional();
                });
            Join("BbqMeetingGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BbqMeetingProgramPlanGeneratedData);
                    j.Optional();
                });
            Join("GatheringMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.GatheringMeetingProgramPlanData);
                    j.Optional();
                });
            Join("GatheringMeetingGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.GatheringMeetingProgramPlanGeneratedData);
                    j.Optional();
                });
            Join("OtherMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherMeetingProgramPlanData);
                    j.Optional();
                });
            Join("OtherMeetingGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherMeetingProgramPlanGeneratedData);
                    j.Optional();
                });

            Join("GroupStudyTeachingLearningProgramData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.GroupStudyTeachingLearningProgramPlanData);
                        j.Optional();
                    });
            Join("GroupStudyTeachingLearningProgramGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId"); 
                        j.Component(x => x.GroupStudyTeachingLearningProgramPlanGeneratedData);
                        j.Optional();
                    });

            Join("StudyCircleTeachingLearningProgramData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.StudyCircleTeachingLearningProgramPlanData);
                        j.Optional();
                    });
            Join("StudyCircleTeachingLearningProgramGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.StudyCircleTeachingLearningProgramPlanGeneratedData);
                        j.Optional();
                    });

            Join("PracticeDarsTeachingLearningProgramData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.PracticeDarsTeachingLearningProgramPlanData);
                        j.Optional();
                    });
            Join("PracticeDarsTeachingLearningProgramGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.PracticeDarsTeachingLearningProgramPlanGeneratedData);
                        j.Optional();
                    });

            Join("StateLearningCampTeachingLearningProgramData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.StateLearningCampTeachingLearningProgramPlanData);
                        j.Optional();
                    });
            Join("StateLearningCampTeachingLearningProgramGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.StateLearningCampTeachingLearningProgramPlanGeneratedData);
                        j.Optional();
                    });

            Join("QuranStudyTeachingLearningProgramData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.QuranStudyTeachingLearningProgramPlanData);
                        j.Optional();
                    });
            Join("QuranStudyTeachingLearningProgramGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.QuranStudyTeachingLearningProgramPlanGeneratedData);
                        j.Optional();
                    });

            Join("QuranClassTeachingLearningProgramData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.QuranClassTeachingLearningProgramPlanData);
                        j.Optional();
                    });
            Join("QuranClassTeachingLearningProgramGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.QuranClassTeachingLearningProgramPlanGeneratedData);
                        j.Optional();
                    });

            Join("MemorizingAyatTeachingLearningProgramData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.MemorizingAyatTeachingLearningProgramPlanData);
                        j.Optional();
                    });
            Join("MemorizingAyatTeachingLearningProgramGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.MemorizingAyatTeachingLearningProgramPlanGeneratedData);
                        j.Optional();
                    });

            Join("StateLearningSessionTeachingLearningProgramData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.StateLearningSessionTeachingLearningProgramPlanData);
                        j.Optional();
                    });
            Join("StateLearningSessionTeachingLearningProgramGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.StateLearningSessionTeachingLearningProgramPlanGeneratedData);
                        j.Optional();
                    });

            Join("StateQiyamulLailTeachingLearningProgramData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.StateQiyamulLailTeachingLearningProgramPlanData);
                        j.Optional();
                    });
            Join("StateQiyamulLailTeachingLearningProgramGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.StateQiyamulLailTeachingLearningProgramPlanGeneratedData);
                        j.Optional();
                    });
            Join("StudyCircleForAssociateMemberTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.StudyCircleForAssociateMemberTeachingLearningProgramPlanData);
                    j.Optional();
                });
            Join("StudyCircleForAssociateMemberTeachingLearningProgramGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.StudyCircleForAssociateMemberTeachingLearningProgramPlanGeneratedData);
                    j.Optional();
                });

            Join("HadithTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.HadithTeachingLearningProgramPlanData);
                    j.Optional();
                });
            Join("HadithTeachingLearningProgramGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.HadithTeachingLearningProgramPlanGeneratedData);
                    j.Optional();
                });

            Join("WeekendIslamicSchoolTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.WeekendIslamicSchoolTeachingLearningProgramPlanData);
                    j.Optional();
                });
            Join("WeekendIslamicSchoolTeachingLearningProgramGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.WeekendIslamicSchoolTeachingLearningProgramPlanGeneratedData);
                    j.Optional();
                });
            Join("MemorizingHadithTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MemorizingHadithTeachingLearningProgramPlanData);
                    j.Optional();
                });
            Join("MemorizingHadithTeachingLearningProgramGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MemorizingHadithTeachingLearningProgramPlanGeneratedData);
                    j.Optional();
                });
            Join("MemorizingDoaTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MemorizingDoaTeachingLearningProgramPlanData);
                    j.Optional();
                });
            Join("MemorizingDoaTeachingLearningProgramGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MemorizingDoaTeachingLearningProgramPlanGeneratedData);
                    j.Optional();
                });

            Join("OtherTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherTeachingLearningProgramPlanData);
                    j.Optional();
                });
            Join("OtherTeachingLearningProgramGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherTeachingLearningProgramPlanGeneratedData);
                    j.Optional();
                });

            Join("BookSaleMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BookSaleMaterialPlanData);
                    j.Optional();
                });
            Join("BookSaleMaterialGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BookSaleMaterialPlanGeneratedData);
                    j.Optional();
                });
            Join("BookDistributionMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BookDistributionMaterialPlanData);
                    j.Optional();
                });
            Join("BookDistributionMaterialGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BookDistributionMaterialPlanGeneratedData);
                    j.Optional();
                });
            Join("BookLibraryStockData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BookLibraryStockPlanData);
                    j.Optional();
                });
            Join("BookLibraryStockGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BookLibraryStockPlanGeneratedData);
                    j.Optional();
                });
            Join("OtherSaleMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherSaleMaterialPlanData);
                    j.Optional();
                });
            Join("OtherSaleMaterialGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherSaleMaterialPlanGeneratedData);
                    j.Optional();
                });

            
            Join("OtherDistributionMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherDistributionMaterialPlanData);
                    j.Optional();
                });
            Join("OtherDistributionMaterialGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherDistributionMaterialPlanGeneratedData);
                    j.Optional();
                });
            
            Join("OtherLibraryStockData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherLibraryStockPlanData);
                    j.Optional();
                });
            Join("OtherLibraryStockGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherLibraryStockPlanGeneratedData);
                    j.Optional();
                });
            Join("VhsSaleMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.VhsSaleMaterialPlanData);
                    j.Optional();
                });
            Join("VhsSaleMaterialGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.VhsSaleMaterialPlanGeneratedData);
                    j.Optional();
                });

            Join("VhsDistributionMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.VhsDistributionMaterialPlanData);
                    j.Optional();
                });
            Join("VhsDistributionMaterialGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.VhsDistributionMaterialPlanGeneratedData);
                    j.Optional();
                });
            Join("VhsLibraryStockData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.VhsLibraryStockPlanData);
                    j.Optional();
                });
            Join("VhsLibraryStockGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.VhsLibraryStockPlanGeneratedData);
                    j.Optional();
                });
            Join("EmailDistributionMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.EmailDistributionMaterialPlanData);
                    j.Optional();
                });
            Join("EmailDistributionMaterialGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.EmailDistributionMaterialPlanGeneratedData);
                    j.Optional();
                });

            Join("IpdcLeafletDistributionMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.IpdcLeafletDistributionMaterialPlanData);
                    j.Optional();
                });
            Join("IpdcLeafletDistributionMaterialGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.IpdcLeafletDistributionMaterialPlanGeneratedData);
                    j.Optional();
                });


            Join("BaitulMalFinanceData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BaitulMalFinancePlanData);
                    j.Optional();
                });
            Join("BaitulMalFinanceGeneratedData",
                            j =>
                            {
                                j.KeyColumn("ReportId");
                                j.Component(x => x.BaitulMalFinancePlanGeneratedData);
                                j.Optional();
                            });
            Join("ADayMasjidProjectFinanceData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.ADayMasjidProjectFinancePlanData);
                    j.Optional();
                });
            Join("ADayMasjidProjectFinanceGeneratedData",
                            j =>
                            {
                                j.KeyColumn("ReportId");
                                j.Component(x => x.ADayMasjidProjectFinancePlanGeneratedData);
                                j.Optional();
                            });
            Join("MasjidTableBankFinanceData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MasjidTableBankFinancePlanData);
                    j.Optional();
                });
            Join("MasjidTableBankFinanceGeneratedData",
                            j =>
                            {
                                j.KeyColumn("ReportId");
                                j.Component(x => x.MasjidTableBankFinancePlanGeneratedData);
                                j.Optional();
                            });



            Join("QardeHasanaSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.QardeHasanaSocialWelfarePlanData);
                    j.Optional();
                });
            Join("QardeHasanaSocialWelfareGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.QardeHasanaSocialWelfarePlanGeneratedData);
                    j.Optional();
                });
            Join("PatientVisitSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.PatientVisitSocialWelfarePlanData);
                    j.Optional();
                });
            Join("PatientVisitSocialWelfareGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.PatientVisitSocialWelfarePlanGeneratedData);
                    j.Optional();
                });
            Join("SocialVisitSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.SocialVisitSocialWelfarePlanData);
                    j.Optional();
                });
            Join("SocialVisitSocialWelfareGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.SocialVisitSocialWelfarePlanGeneratedData);
                    j.Optional();
                });
            Join("TransportSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.TransportSocialWelfarePlanData);
                    j.Optional();
                });
            Join("TransportSocialWelfareGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.TransportSocialWelfarePlanGeneratedData);
                    j.Optional();
                });
            Join("ShiftingSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.ShiftingSocialWelfarePlanData);
                    j.Optional();
                });
            Join("ShiftingSocialWelfareGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.ShiftingSocialWelfarePlanGeneratedData);
                    j.Optional();
                });
            Join("ShoppingSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.ShoppingSocialWelfarePlanData);
                    j.Optional();
                });
            Join("ShoppingSocialWelfareGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.ShoppingSocialWelfarePlanGeneratedData);
                    j.Optional();
                });
            Join("FoodDistributionSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.FoodDistributionSocialWelfarePlanData);
                    j.Optional();
                });
            Join("FoodDistributionSocialWelfareGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.FoodDistributionSocialWelfarePlanGeneratedData);
                    j.Optional();
                });
            Join("CleanUpAustraliaSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.CleanUpAustraliaSocialWelfarePlanData);
                    j.Optional();
                });
            Join("CleanUpAustraliaSocialWelfareGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.CleanUpAustraliaSocialWelfarePlanGeneratedData);
                    j.Optional();
                });
            Join("OtherSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherSocialWelfarePlanData);
                    j.Optional();
                });
            Join("OtherSocialWelfareGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherSocialWelfarePlanGeneratedData);
                    j.Optional();
                });

        }
    }
}*/