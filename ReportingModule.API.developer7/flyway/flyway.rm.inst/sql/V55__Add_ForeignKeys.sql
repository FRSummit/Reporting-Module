ALTER TABLE dbo.ADayMasjidProjectFinanceData ADD CONSTRAINT FK_ADayMasjidProjectFinanceData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.ADayMasjidProjectFinanceGeneratedData ADD CONSTRAINT FK_ADayMasjidProjectFinanceGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.AssociateMemberData ADD CONSTRAINT FK_AssociateMemberData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.AssociateMemberGeneratedData ADD CONSTRAINT FK_AssociateMemberGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.BaitulMalFinanceData ADD CONSTRAINT FK_BaitulMalFinanceData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.BaitulMalFinanceGeneratedData ADD CONSTRAINT FK_BaitulMalFinanceGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.BbqMeetingData ADD CONSTRAINT FK_BbqMeetingData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.BbqMeetingGeneratedData ADD CONSTRAINT FK_BbqMeetingGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.BookDistributionMaterialData ADD CONSTRAINT FK_BookDistributionMaterialData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.BookDistributionMaterialGeneratedData ADD CONSTRAINT FK_BookDistributionMaterialGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.BookLibraryStockData ADD CONSTRAINT FK_BookLibraryStockData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.BookLibraryStockGeneratedData ADD CONSTRAINT FK_BookLibraryStockGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.BookSaleMaterialData ADD CONSTRAINT FK_BookSaleMaterialData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.BookSaleMaterialGeneratedData ADD CONSTRAINT FK_BookSaleMaterialGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.CmsMeetingData ADD CONSTRAINT FK_CmsMeetingData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.CmsMeetingGeneratedData ADD CONSTRAINT FK_CmsMeetingGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.DawahGroupMeetingData ADD CONSTRAINT FK_DawahGroupMeetingData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.DawahGroupMeetingGeneratedData ADD CONSTRAINT FK_DawahGroupMeetingGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.DawahMeetingData ADD CONSTRAINT FK_DawahMeetingData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.DawahMeetingGeneratedData ADD CONSTRAINT FK_DawahMeetingGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.EidReunionMeetingData ADD CONSTRAINT FK_EidReunionMeetingData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.EidReunionMeetingGeneratedData ADD CONSTRAINT FK_EidReunionMeetingGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.EmailDistributionMaterialData ADD CONSTRAINT FK_EmailDistributionMaterialData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.EmailDistributionMaterialGeneratedData ADD CONSTRAINT FK_EmailDistributionMaterialGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.FamilyVisitMeetingData ADD CONSTRAINT FK_FamilyVisitMeetingData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.FamilyVisitMeetingGeneratedData ADD CONSTRAINT FK_FamilyVisitMeetingGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.FoodDistributionSocialWelfareData ADD CONSTRAINT FK_FoodDistributionSocialWelfareData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.FoodDistributionSocialWelfareGeneratedData ADD CONSTRAINT FK_FoodDistributionSocialWelfareGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.GatheringMeetingData ADD CONSTRAINT FK_GatheringMeetingData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.GatheringMeetingGeneratedData ADD CONSTRAINT FK_GatheringMeetingGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.GroupStudyTeachingLearningProgramData ADD CONSTRAINT FK_GroupStudyTeachingLearningProgramData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.GroupStudyTeachingLearningProgramGeneratedData ADD CONSTRAINT FK_GroupStudyTeachingLearningProgramGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.HadithTeachingLearningProgramData ADD CONSTRAINT FK_HadithTeachingLearningProgramData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.HadithTeachingLearningProgramGeneratedData ADD CONSTRAINT FK_HadithTeachingLearningProgramGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.IftarMeetingData ADD CONSTRAINT FK_IftarMeetingData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.IftarMeetingGeneratedData ADD CONSTRAINT FK_IftarMeetingGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.IpdcLeafletDistributionMaterialData ADD CONSTRAINT FK_IpdcLeafletDistributionMaterialData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.IpdcLeafletDistributionMaterialGeneratedData ADD CONSTRAINT FK_IpdcLeafletDistributionMaterialGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.LearningMeetingData ADD CONSTRAINT FK_LearningMeetingData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.LearningMeetingGeneratedData ADD CONSTRAINT FK_LearningMeetingGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.MasjidTableBankFinanceData ADD CONSTRAINT FK_MasjidTableBankFinanceData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.MasjidTableBankFinanceGeneratedData ADD CONSTRAINT FK_MasjidTableBankFinanceGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.MemberMeetingData ADD CONSTRAINT FK_MemberMeetingData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.MemberMeetingGeneratedData ADD CONSTRAINT FK_MemberMeetingGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.MemberMemberData ADD CONSTRAINT FK_MemberMemberData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.MemberMemberGeneratedData ADD CONSTRAINT FK_MemberMemberGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.MemorizingAyatTeachingLearningProgramData ADD CONSTRAINT FK_MemorizingAyatTeachingLearningProgramData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.MemorizingAyatTeachingLearningProgramGeneratedData ADD CONSTRAINT FK_MemorizingAyatTeachingLearningProgramGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.MemorizingDoaTeachingLearningProgramData ADD CONSTRAINT FK_MemorizingDoaTeachingLearningProgramData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.MemorizingDoaTeachingLearningProgramGeneratedData ADD CONSTRAINT FK_MemorizingDoaTeachingLearningProgramGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.MemorizingHadithTeachingLearningProgramGeneratedData ADD CONSTRAINT FK_MemorizingHadithTeachingLearningProgramGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.MemorizingHadithTeachingLearningProgramData ADD CONSTRAINT FK_MemorizingHadithTeachingLearningProgramData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.NextGMeetingData ADD CONSTRAINT FK_NextGMeetingData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.NextGMeetingGeneratedData ADD CONSTRAINT FK_NextGMeetingGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.OtherDistributionMaterialData ADD CONSTRAINT FK_OtherDistributionMaterialData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.OtherDistributionMaterialGeneratedData ADD CONSTRAINT FK_OtherDistributionMaterialGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.OtherLibraryStockData ADD CONSTRAINT FK_OtherLibraryStockData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.OtherLibraryStockGeneratedData ADD CONSTRAINT FK_OtherLibraryStockGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.OtherMeetingData ADD CONSTRAINT FK_OtherMeetingData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.OtherMeetingGeneratedData ADD CONSTRAINT FK_OtherMeetingGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.OtherSaleMaterialData ADD CONSTRAINT FK_OtherSaleMaterialData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.OtherSaleMaterialGeneratedData ADD CONSTRAINT FK_OtherSaleMaterialGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.OtherSocialWelfareData ADD CONSTRAINT FK_OtherSocialWelfareData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.OtherSocialWelfareGeneratedData ADD CONSTRAINT FK_OtherSocialWelfareGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.OtherTeachingLearningProgramData ADD CONSTRAINT FK_OtherTeachingLearningProgramData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.OtherTeachingLearningProgramGeneratedData ADD CONSTRAINT FK_OtherTeachingLearningProgramGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.PatientVisitSocialWelfareData ADD CONSTRAINT FK_PatientVisitSocialWelfareData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.PatientVisitSocialWelfareGeneratedData ADD CONSTRAINT FK_PatientVisitSocialWelfareGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.PracticeDarsTeachingLearningProgramData ADD CONSTRAINT FK_PracticeDarsTeachingLearningProgramData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.PracticeDarsTeachingLearningProgramGeneratedData ADD CONSTRAINT FK_PracticeDarsTeachingLearningProgramGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.PreliminaryMemberData ADD CONSTRAINT FK_PreliminaryMemberData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.PreliminaryMemberGeneratedData ADD CONSTRAINT FK_PreliminaryMemberGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.QardeHasanaSocialWelfareData ADD CONSTRAINT FK_QardeHasanaSocialWelfareData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.QardeHasanaSocialWelfareGeneratedData ADD CONSTRAINT FK_QardeHasanaSocialWelfareGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.QuranClassTeachingLearningProgramData ADD CONSTRAINT FK_QuranClassTeachingLearningProgramData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.QuranClassTeachingLearningProgramGeneratedData ADD CONSTRAINT FK_QuranClassTeachingLearningProgramGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.QuranStudyTeachingLearningProgramData ADD CONSTRAINT FK_QuranStudyTeachingLearningProgramData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.QuranStudyTeachingLearningProgramGeneratedData ADD CONSTRAINT FK_QuranStudyTeachingLearningProgramGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.ReportEventLog ADD CONSTRAINT FK_ReportEventLog FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.ShiftingSocialWelfareData ADD CONSTRAINT FK_ShiftingSocialWelfareData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.ShiftingSocialWelfareGeneratedData ADD CONSTRAINT FK_ShiftingSocialWelfareGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.ShoppingSocialWelfareData ADD CONSTRAINT FK_ShoppingSocialWelfareData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.ShoppingSocialWelfareGeneratedData ADD CONSTRAINT FK_ShoppingSocialWelfareGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.SmMeetingData ADD CONSTRAINT FK_SmMeetingData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.SmMeetingGeneratedData ADD CONSTRAINT FK_SmMeetingGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.SocialDawahMeetingData ADD CONSTRAINT FK_SocialDawahMeetingData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.SocialDawahMeetingGeneratedData ADD CONSTRAINT FK_SocialDawahMeetingGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.SocialVisitSocialWelfareData ADD CONSTRAINT FK_SocialVisitSocialWelfareData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.SocialVisitSocialWelfareGeneratedData ADD CONSTRAINT FK_SocialVisitSocialWelfareGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.StateLeaderMeetingData ADD CONSTRAINT FK_StateLeaderMeetingData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.StateLeaderMeetingGeneratedData ADD CONSTRAINT FK_StateLeaderMeetingGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.StateLearningCampTeachingLearningProgramData ADD CONSTRAINT FK_StateLearningCampTeachingLearningProgramData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.StateLearningCampTeachingLearningProgramGeneratedData ADD CONSTRAINT FK_StateLearningCampTeachingLearningProgramGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.StateLearningSessionTeachingLearningProgramData ADD CONSTRAINT FK_StateLearningSessionTeachingLearningProgramData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.StateLearningSessionTeachingLearningProgramGeneratedData ADD CONSTRAINT FK_StateLearningSessionTeachingLearningProgramGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.StateOutingMeetingData ADD CONSTRAINT FK_StateOutingMeetingData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.StateOutingMeetingGeneratedData ADD CONSTRAINT FK_StateOutingMeetingGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.StateQiyamulLailTeachingLearningProgramData ADD CONSTRAINT FK_StateQiyamulLailTeachingLearningProgramData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.StateQiyamulLailTeachingLearningProgramGeneratedData ADD CONSTRAINT FK_StateQiyamulLailTeachingLearningProgramGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.StudyCircleForAssociateMemberTeachingLearningProgramGeneratedData ADD CONSTRAINT FK_StudyCircleForAssociateMemberTeachingLearningProgramGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.StudyCircleForAssociateMemberTeachingLearningProgramData ADD CONSTRAINT FK_StudyCircleForAssociateMemberTeachingLearningProgramData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.StudyCircleTeachingLearningProgramData ADD CONSTRAINT FK_StudyCircleTeachingLearningProgramData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.StudyCircleTeachingLearningProgramGeneratedData ADD CONSTRAINT FK_StudyCircleTeachingLearningProgramGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.SupporterMemberData ADD CONSTRAINT FK_SupporterMemberData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.SupporterMemberGeneratedData ADD CONSTRAINT FK_SupporterMemberGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.TafsirMeetingData ADD CONSTRAINT FK_TafsirMeetingData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.TafsirMeetingGeneratedData ADD CONSTRAINT FK_TafsirMeetingGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.TransportSocialWelfareData ADD CONSTRAINT FK_TransportSocialWelfareData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.TransportSocialWelfareGeneratedData ADD CONSTRAINT FK_TransportSocialWelfareGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.UnitMeetingData ADD CONSTRAINT FK_UnitMeetingData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.UnitMeetingGeneratedData ADD CONSTRAINT FK_UnitMeetingGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.VhsDistributionMaterialData ADD CONSTRAINT FK_VhsDistributionMaterialData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.VhsDistributionMaterialGeneratedData ADD CONSTRAINT FK_VhsDistributionMaterialGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.VhsLibraryStockData ADD CONSTRAINT FK_VhsLibraryStockData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.VhsLibraryStockGeneratedData ADD CONSTRAINT FK_VhsLibraryStockGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.VhsSaleMaterialData ADD CONSTRAINT FK_VhsSaleMaterialData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.VhsSaleMaterialGeneratedData ADD CONSTRAINT FK_VhsSaleMaterialGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.WeekendIslamicSchoolTeachingLearningProgramData ADD CONSTRAINT FK_WeekendIslamicSchoolTeachingLearningProgramData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.WeekendIslamicSchoolTeachingLearningProgramGeneratedData ADD CONSTRAINT FK_WeekendIslamicSchoolTeachingLearningProgramGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.WorkerMeetingData ADD CONSTRAINT FK_WorkerMeetingData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
ALTER TABLE dbo.WorkerMeetingGeneratedData ADD CONSTRAINT FK_WorkerMeetingGeneratedData FOREIGN KEY (ReportId)
      REFERENCES Report (Id)
      GO
