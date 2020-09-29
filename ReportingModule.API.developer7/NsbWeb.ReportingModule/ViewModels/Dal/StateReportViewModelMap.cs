/*using FluentNHibernate.Mapping;
using ReportingModule.Core.Fluent;

namespace NsbWeb.ReportingModule.ViewModels.Dal
{
    public class StateReportViewModelMap : ClassMap<StateReportViewModel>
    {
        public StateReportViewModelMap()
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
            Map(x => x.Comment);
            Map(x => x.Timestamp);
            Join("MemberMemberData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MemberMemberData);
                    j.Optional();
                });
            Join("MemberMemberGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MemberMemberGeneratedData);
                    j.Optional();
                });
            Join("AssociateMemberData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.AssociateMemberData);
                    j.Optional();
                });
            Join("AssociateMemberGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.AssociateMemberGeneratedData);
                    j.Optional();
                });
            Join("PreliminaryMemberData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.PreliminaryMemberData);
                    j.Optional();
                });
            Join("PreliminaryMemberGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.PreliminaryMemberGeneratedData);
                    j.Optional();
                });
            Join("SupporterMemberData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.SupporterMemberData);
                    j.Optional();
                });
            Join("SupporterMemberGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.SupporterMemberGeneratedData);
                    j.Optional();
                });
            Join("WorkerMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.WorkerMeetingProgramData);
                    j.Optional();
                });
            Join("WorkerMeetingGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.WorkerMeetingProgramGeneratedData);
                    j.Optional();
                });

            Join("DawahMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.DawahMeetingProgramData);
                    j.Optional();
                });
            Join("DawahMeetingGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.DawahMeetingProgramGeneratedData);
                    j.Optional();
                });
            Join("StateLeaderMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.StateLeaderMeetingProgramData);
                    j.Optional();
                });
            Join("StateLeaderMeetingGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.StateLeaderMeetingProgramGeneratedData);
                        j.Optional();
                    });
            Join("StateOutingMeetingData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.StateOutingMeetingProgramData);
                        j.Optional();
                    });
            Join("StateOutingMeetingGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.StateOutingMeetingProgramGeneratedData);
                        j.Optional();
                    });
            Join("IftarMeetingData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.IftarMeetingProgramData);
                        j.Optional();
                    });
            Join("IftarMeetingGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.IftarMeetingProgramGeneratedData);
                        j.Optional();
                    });
            Join("LearningMeetingData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.LearningMeetingProgramData);
                        j.Optional();
                    });
            Join("LearningMeetingGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.LearningMeetingProgramGeneratedData);
                        j.Optional();
                    });
            Join("SocialDawahMeetingData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.SocialDawahMeetingProgramData);
                        j.Optional();
                    });
            Join("SocialDawahMeetingGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.SocialDawahMeetingProgramGeneratedData);
                        j.Optional();
                    });
            Join("DawahGroupMeetingData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.DawahGroupMeetingProgramData);
                        j.Optional();
                    });
            Join("DawahGroupMeetingGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.DawahGroupMeetingProgramGeneratedData);
                        j.Optional();
                    });
            Join("NextGMeetingData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.NextGMeetingProgramData);
                        j.Optional();
                    });
            Join("NextGMeetingGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.NextGMeetingProgramGeneratedData);
                        j.Optional();
                    });


            Join("CmsMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.CmsMeetingProgramData);
                    j.Optional();
                });
            Join("CmsMeetingGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.CmsMeetingProgramGeneratedData);
                    j.Optional();
                });
            Join("SmMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.SmMeetingProgramData);
                    j.Optional();
                });
            Join("SmMeetingGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.SmMeetingProgramGeneratedData);
                    j.Optional();
                });
            Join("MemberMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MemberMeetingProgramData);
                    j.Optional();
                });
            Join("MemberMeetingGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MemberMeetingProgramGeneratedData);
                    j.Optional();
                });
            Join("TafsirMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.TafsirMeetingProgramData);
                    j.Optional();
                });
            Join("TafsirMeetingGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.TafsirMeetingProgramGeneratedData);
                    j.Optional();
                });
            Join("UnitMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.UnitMeetingProgramData);
                    j.Optional();
                });
            Join("UnitMeetingGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.UnitMeetingProgramGeneratedData);
                    j.Optional();
                });
            Join("FamilyVisitMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.FamilyVisitMeetingProgramData);
                    j.Optional();
                });
            Join("FamilyVisitMeetingGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.FamilyVisitMeetingProgramGeneratedData);
                    j.Optional();
                });
            Join("EidReunionMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.EidReunionMeetingProgramData);
                    j.Optional();
                });
            Join("EidReunionMeetingGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.EidReunionMeetingProgramGeneratedData);
                    j.Optional();
                });
            Join("BbqMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BbqMeetingProgramData);
                    j.Optional();
                });
            Join("BbqMeetingGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BbqMeetingProgramGeneratedData);
                    j.Optional();
                });
            Join("GatheringMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.GatheringMeetingProgramData);
                    j.Optional();
                });
            Join("GatheringMeetingGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.GatheringMeetingProgramGeneratedData);
                    j.Optional();
                });

            Join("OtherMeetingData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherMeetingProgramData);
                    j.Optional();
                });
            Join("OtherMeetingGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherMeetingProgramGeneratedData);
                    j.Optional();
                });


            Join("GroupStudyTeachingLearningProgramData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.GroupStudyTeachingLearningProgramData);
                        j.Optional();
                    });
            Join("GroupStudyTeachingLearningProgramGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.GroupStudyTeachingLearningProgramGeneratedData);
                        j.Optional();
                    });

            Join("StudyCircleTeachingLearningProgramData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.StudyCircleTeachingLearningProgramData);
                        j.Optional();
                    });
            Join("StudyCircleTeachingLearningProgramGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.StudyCircleTeachingLearningProgramGeneratedData);
                        j.Optional();
                    });

            Join("PracticeDarsTeachingLearningProgramData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.PracticeDarsTeachingLearningProgramData);
                        j.Optional();
                    });
            Join("PracticeDarsTeachingLearningProgramGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.PracticeDarsTeachingLearningProgramGeneratedData);
                        j.Optional();
                    });

            Join("StateLearningCampTeachingLearningProgramData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.StateLearningCampTeachingLearningProgramData);
                        j.Optional();
                    });
            Join("StateLearningCampTeachingLearningProgramGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.StateLearningCampTeachingLearningProgramGeneratedData);
                        j.Optional();
                    });

            Join("QuranStudyTeachingLearningProgramData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.QuranStudyTeachingLearningProgramData);
                        j.Optional();
                    });
            Join("QuranStudyTeachingLearningProgramGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.QuranStudyTeachingLearningProgramGeneratedData);
                        j.Optional();
                    });

            Join("QuranClassTeachingLearningProgramData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.QuranClassTeachingLearningProgramData);
                        j.Optional();
                    });
            Join("QuranClassTeachingLearningProgramGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.QuranClassTeachingLearningProgramGeneratedData);
                        j.Optional();
                    });

            Join("MemorizingAyatTeachingLearningProgramData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.MemorizingAyatTeachingLearningProgramData);
                        j.Optional();
                    });
            Join("MemorizingAyatTeachingLearningProgramGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.MemorizingAyatTeachingLearningProgramGeneratedData);
                        j.Optional();
                    });

            Join("StateLearningSessionTeachingLearningProgramData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.StateLearningSessionTeachingLearningProgramData);
                        j.Optional();
                    });
            Join("StateLearningSessionTeachingLearningProgramGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.StateLearningSessionTeachingLearningProgramGeneratedData);
                        j.Optional();
                    });

            Join("StateQiyamulLailTeachingLearningProgramData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.StateQiyamulLailTeachingLearningProgramData);
                        j.Optional();
                    });
            Join("StateQiyamulLailTeachingLearningProgramGeneratedData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.StateQiyamulLailTeachingLearningProgramGeneratedData);
                        j.Optional();
                    });

            Join("StudyCircleForAssociateMemberTeachingLearningProgramData",
                    j =>
                    {
                        j.KeyColumn("ReportId");
                        j.Component(x => x.StudyCircleForAssociateMemberTeachingLearningProgramData);
                        j.Optional();
                    });
            Join("StudyCircleForAssociateMemberTeachingLearningProgramGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.StudyCircleForAssociateMemberTeachingLearningProgramGeneratedData);
                    j.Optional();
                });

            Join("HadithTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.HadithTeachingLearningProgramData);
                    j.Optional();
                });
            Join("HadithTeachingLearningProgramGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.HadithTeachingLearningProgramGeneratedData);
                    j.Optional();
                });

            Join("WeekendIslamicSchoolTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.WeekendIslamicSchoolTeachingLearningProgramData);
                    j.Optional();
                });
            Join("WeekendIslamicSchoolTeachingLearningProgramGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.WeekendIslamicSchoolTeachingLearningProgramGeneratedData);
                    j.Optional();
                });
            Join("MemorizingHadithTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MemorizingHadithTeachingLearningProgramData);
                    j.Optional();
                });
            Join("MemorizingHadithTeachingLearningProgramGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MemorizingHadithTeachingLearningProgramGeneratedData);
                    j.Optional();
                });
            Join("MemorizingDoaTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MemorizingDoaTeachingLearningProgramData);
                    j.Optional();
                });
            Join("MemorizingDoaTeachingLearningProgramGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MemorizingDoaTeachingLearningProgramGeneratedData);
                    j.Optional();
                });

            Join("OtherTeachingLearningProgramData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherTeachingLearningProgramData);
                    j.Optional();
                });
            Join("OtherTeachingLearningProgramGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherTeachingLearningProgramGeneratedData);
                    j.Optional();
                });

            Join("BookSaleMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BookSaleMaterialData);
                    j.Optional();
                });
            Join("BookSaleMaterialGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BookSaleMaterialGeneratedData);
                    j.Optional();
                });

            Join("BookDistributionMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BookDistributionMaterialData);
                    j.Optional();
                });
            Join("BookDistributionMaterialGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BookDistributionMaterialGeneratedData);
                    j.Optional();
                });
            Join("BookLibraryStockData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BookLibraryStockData);
                    j.Optional();
                });
            Join("BookLibraryStockGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BookLibraryStockGeneratedData);
                    j.Optional();
                });


            Join("OtherSaleMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherSaleMaterialData);
                    j.Optional();
                });
            Join("OtherSaleMaterialGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherSaleMaterialGeneratedData);
                    j.Optional();
                });
            Join("OtherDistributionMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherDistributionMaterialData);
                    j.Optional();
                });
            Join("OtherDistributionMaterialGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherDistributionMaterialGeneratedData);
                    j.Optional();
                });
            Join("OtherLibraryStockData",
               j =>
               {
                   j.KeyColumn("ReportId");
                   j.Component(x => x.OtherLibraryStockData);
                   j.Optional();
               });
            Join("OtherLibraryStockGeneratedData",
                            j =>
                            {
                                j.KeyColumn("ReportId");
                                j.Component(x => x.OtherLibraryStockGeneratedData);
                                j.Optional();
                            });


            Join("VhsSaleMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.VhsSaleMaterialData);
                    j.Optional();
                });

            Join("VhsSaleMaterialGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.VhsSaleMaterialGeneratedData);
                    j.Optional();
                });

            Join("VhsDistributionMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.VhsDistributionMaterialData);
                    j.Optional();
                });
            Join("VhsDistributionMaterialGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.VhsDistributionMaterialGeneratedData);
                    j.Optional();
                });
            Join("VhsLibraryStockData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.VhsLibraryStockData);
                    j.Optional();
                });
            Join("VhsLibraryStockGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.VhsLibraryStockGeneratedData);
                    j.Optional();
                });
            Join("EmailDistributionMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.EmailDistributionMaterialData);
                    j.Optional();
                });
            Join("EmailDistributionMaterialGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.EmailDistributionMaterialGeneratedData);
                    j.Optional();
                });

            Join("IpdcLeafletDistributionMaterialData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.IpdcLeafletDistributionMaterialData);
                    j.Optional();
                });
            Join("IpdcLeafletDistributionMaterialGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.IpdcLeafletDistributionMaterialGeneratedData);
                    j.Optional();
                });

            Join("BaitulMalFinanceData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BaitulMalFinanceData);
                    j.Optional();
                });
            Join("BaitulMalFinanceGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.BaitulMalFinanceGeneratedData);
                    j.Optional();
                });
            
            Join("ADayMasjidProjectFinanceData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.ADayMasjidProjectFinanceData);
                    j.Optional();
                });
            Join("ADayMasjidProjectFinanceGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.ADayMasjidProjectFinanceGeneratedData);
                    j.Optional();
                });
            Join("MasjidTableBankFinanceData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MasjidTableBankFinanceData);
                    j.Optional();
                });
            Join("MasjidTableBankFinanceGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.MasjidTableBankFinanceGeneratedData);
                    j.Optional();
                });



            Join("QardeHasanaSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.QardeHasanaSocialWelfareData);
                    j.Optional();
                });
            Join("QardeHasanaSocialWelfareGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.QardeHasanaSocialWelfareGeneratedData);
                    j.Optional();
                });
            Join("PatientVisitSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.PatientVisitSocialWelfareData);
                    j.Optional();
                });
            Join("PatientVisitSocialWelfareGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.PatientVisitSocialWelfareGeneratedData);
                    j.Optional();
                });
            Join("SocialVisitSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.SocialVisitSocialWelfareData);
                    j.Optional();
                });
            Join("SocialVisitSocialWelfareGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.SocialVisitSocialWelfareGeneratedData);
                    j.Optional();
                });
            Join("TransportSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.TransportSocialWelfareData);
                    j.Optional();
                });
            Join("TransportSocialWelfareGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.TransportSocialWelfareGeneratedData);
                    j.Optional();
                });
            Join("ShiftingSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.ShiftingSocialWelfareData);
                    j.Optional();
                });
            Join("ShiftingSocialWelfareGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.ShiftingSocialWelfareGeneratedData);
                    j.Optional();
                });
            Join("ShoppingSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.ShoppingSocialWelfareData);
                    j.Optional();
                });
            Join("ShoppingSocialWelfareGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.ShoppingSocialWelfareGeneratedData);
                    j.Optional();
                });
            Join("FoodDistributionSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.FoodDistributionSocialWelfareData);
                    j.Optional();
                });
            Join("FoodDistributionSocialWelfareGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.FoodDistributionSocialWelfareGeneratedData);
                    j.Optional();
                });
            Join("CleanUpAustraliaSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.CleanUpAustraliaSocialWelfareData);
                    j.Optional();
                });
            Join("CleanUpAustraliaSocialWelfareGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.CleanUpAustraliaSocialWelfareGeneratedData);
                    j.Optional();
                });
            Join("OtherSocialWelfareData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherSocialWelfareData);
                    j.Optional();
                });
            Join("OtherSocialWelfareGeneratedData",
                j =>
                {
                    j.KeyColumn("ReportId");
                    j.Component(x => x.OtherSocialWelfareGeneratedData);
                    j.Optional();
                });
        }
    }
}*/