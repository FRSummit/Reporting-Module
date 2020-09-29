CREATE TABLE [dbo].[UnitReportData](
  [Id] [int] IDENTITY(1, 1) NOT NULL, 
  ReportID int NOT NULL,
  MemberMemberData VARCHAR(MAX) NULL,  
  AssociateMemberData VARCHAR(MAX) NULL,  
  PreliminaryMemberData VARCHAR(MAX) NULL,  
  SupporterMemberData VARCHAR(MAX) NULL,  
  WorkerMeetingProgramData VARCHAR(MAX) NULL,  
  DawahMeetingProgramData VARCHAR(MAX) NULL,  
  StateLeaderMeetingProgramData VARCHAR(MAX) NULL,  
  StateOutingMeetingProgramData VARCHAR(MAX) NULL,  
  IftarMeetingProgramData VARCHAR(MAX) NULL,  
  LearningMeetingProgramData VARCHAR(MAX) NULL,  
  SocialDawahMeetingProgramData VARCHAR(MAX) NULL,  
  DawahGroupMeetingProgramData VARCHAR(MAX) NULL,  
  NextGMeetingProgramData VARCHAR(MAX) NULL,  
  CmsMeetingProgramData VARCHAR(MAX) NULL,  
  SmMeetingProgramData VARCHAR(MAX) NULL,  
  MemberMeetingProgramData VARCHAR(MAX) NULL,  
  TafsirMeetingProgramData VARCHAR(MAX) NULL,  
  UnitMeetingProgramData VARCHAR(MAX) NULL,  
  FamilyVisitMeetingProgramData VARCHAR(MAX) NULL,  
  EidReunionMeetingProgramData VARCHAR(MAX) NULL,  
  BbqMeetingProgramData VARCHAR(MAX) NULL,  
  GatheringMeetingProgramData VARCHAR(MAX) NULL,  
  OtherMeetingProgramData VARCHAR(MAX) NULL,  
  GroupStudyTeachingLearningProgramData VARCHAR(MAX) NULL,  
  StudyCircleTeachingLearningProgramData VARCHAR(MAX) NULL,  
  PracticeDarsTeachingLearningProgramData VARCHAR(MAX) NULL,  
  StateLearningCampTeachingLearningProgramData VARCHAR(MAX) NULL,  
  QuranStudyTeachingLearningProgramData VARCHAR(MAX) NULL,  
  QuranClassTeachingLearningProgramData VARCHAR(MAX) NULL,  
  MemorizingAyatTeachingLearningProgramData VARCHAR(MAX) NULL,  
  StateLearningSessionTeachingLearningProgramData VARCHAR(MAX) NULL,  
  StateQiyamulLailTeachingLearningProgramData VARCHAR(MAX) NULL,  
  BookSaleMaterialData VARCHAR(MAX) NULL,  
  BookDistributionMaterialData VARCHAR(MAX) NULL,  
  BookLibraryStockData VARCHAR(MAX) NULL,  
  OtherSaleMaterialData VARCHAR(MAX) NULL,  
  OtherDistributionMaterialData VARCHAR(MAX) NULL,  
  OtherLibraryStockData VARCHAR(MAX) NULL,  
  VhsSaleMaterialData VARCHAR(MAX) NULL,  
  VhsDistributionMaterialData VARCHAR(MAX) NULL,  
  VhsLibraryStockData VARCHAR(MAX) NULL,  
  EmailDistributionMaterialData VARCHAR(MAX) NULL,  
  IpdcLeafletDistributionMaterialData VARCHAR(MAX) NULL,  
  BaitulMalFinanceData VARCHAR(MAX) NULL,  
  ADayMasjidProjectFinanceData VARCHAR(MAX) NULL,  
  MasjidTableBankFinanceData VARCHAR(MAX) NULL,  
  QardeHasanaSocialWelfareData VARCHAR(MAX) NULL,  
  PatientVisitSocialWelfareData VARCHAR(MAX) NULL,  
  SocialVisitSocialWelfareData VARCHAR(MAX) NULL,  
  TransportSocialWelfareData VARCHAR(MAX) NULL,  
  ShiftingSocialWelfareData VARCHAR(MAX) NULL,  
  ShoppingSocialWelfareData VARCHAR(MAX) NULL,  
  FoodDistributionSocialWelfareData VARCHAR(MAX) NULL,  
  CleanUpAustraliaSocialWelfareData VARCHAR(MAX) NULL,  
  OtherSocialWelfareData VARCHAR(MAX) NULL,  
  StudyCircleForAssociateMemberTeachingLearningProgramData VARCHAR(MAX) NULL,  
  HadithTeachingLearningProgramData VARCHAR(MAX) NULL,  
  WeekendIslamicSchoolTeachingLearningProgramData VARCHAR(MAX) NULL,  
  MemorizingHadithTeachingLearningProgramData VARCHAR(MAX) NULL,  
  MemorizingDoaTeachingLearningProgramData VARCHAR(MAX) NULL,  
  OtherTeachingLearningProgramData VARCHAR(MAX) NULL,  
  CONSTRAINT [PK_UnitReportData] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (
    PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, 
    IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, 
    ALLOW_PAGE_LOCKS = ON
  ) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE UnitReportData
ADD CONSTRAINT FK_UnitReportData
FOREIGN KEY (ReportID) REFERENCES Report(ID);

GO
