ALTER VIEW dbo.unitreportview 
AS
  SELECT dbo.report.id 
         AS 
            ReportId, 
         dbo.report.description 
         AS 
            ReportDescription, 
         dbo.report.organizationid, 
         dbo.report.organizationdescription, 
         dbo.report.organizationorganizationtype, 
         dbo.report.organizationreportingfrequency, 
         dbo.report.reportingperiodyear, 
         dbo.report.reportingperiodreportingfrequency, 
         dbo.report.reportingperiodreportingterm, 
         dbo.report.reportingperiodstartdate, 
         dbo.report.reportingperiodenddate, 
         dbo.report.reportstatus, 
         dbo.report.reopenedreportstatus, 
		 dbo.report.Comment,
         dbo.report.timestamp, 
         dbo.organization.parentid, 
         dbo.organization.parentdescription, 
         dbo.associatememberdata.nameandcontactnumber 
         AS 
         AssociateMemberNameAndContactNumber, 
         dbo.associatememberdata.lastperiod 
         AS 
            AssociateMemberLastPeriod, 
         dbo.associatememberdata.action 
         AS 
            AssociateMemberAction, 
         dbo.associatememberdata.upgradetarget 
         AS 
            AssociateMemberUpgradeTarget, 
         dbo.associatememberdata.increased 
         AS 
            AssociateMemberIncreased, 
         dbo.associatememberdata.decreased 
         AS 
            AssociateMemberDecreased, 
         dbo.associatememberdata.comment 
         AS 
            AssociateMemberComment, 
         dbo.associatememberdata.personalcontact 
         AS 
            AssociateMemberPersonalContact, 
         dbo.preliminarymemberdata.nameandcontactnumber 
         AS 
         PreliminaryMemberNameAndContactNumber, 
         dbo.preliminarymemberdata.lastperiod 
         AS 
            PreliminaryMemberLastPeriod, 
         dbo.preliminarymemberdata.action 
         AS 
            PreliminaryMemberAction, 
         dbo.preliminarymemberdata.upgradetarget 
         AS 
            PreliminaryMemberUpgradeTarget, 
         dbo.preliminarymemberdata.increased 
         AS 
            PreliminaryMemberIncreased, 
         dbo.preliminarymemberdata.decreased 
         AS 
            PreliminaryMemberDecreased, 
         dbo.preliminarymemberdata.comment 
         AS 
            PreliminaryMemberComment, 
         dbo.preliminarymemberdata.personalcontact 
         AS 
            PreliminaryMemberPersonalContact, 
         dbo.workermeetingdata.target 
         AS 
            WorkerMeetingTarget, 
         dbo.workermeetingdata.dateandaction 
         AS 
            WorkerMeetingDateAndAction, 
         dbo.workermeetingdata.actual 
         AS 
            WorkerMeetingActual, 
         dbo.workermeetingdata.averageattendance 
         AS 
            WorkerMeetingAverageAttendance, 
         dbo.workermeetingdata.comment 
         AS 
            WorkerMeetingComment, 
         dbo.stateleadermeetingdata.actual 
         AS 
            StateLeaderMeetingActual, 
         dbo.stateleadermeetingdata.averageattendance 
         AS 
         StateLeaderMeetingAverageAttendance, 
         dbo.stateleadermeetingdata.comment 
         AS 
            StateLeaderMeetingComment, 
         dbo.stateleadermeetingdata.dateandaction 
         AS 
            StateLeaderMeetingDateAndAction, 
         dbo.stateleadermeetingdata.target 
         AS 
            StateLeaderMeetingTarget, 
         dbo.stateoutingmeetingdata.actual 
         AS 
            StateOutingMeetingActual, 
         dbo.stateoutingmeetingdata.averageattendance 
         AS 
         StateOutingMeetingAverageAttendance, 
         dbo.stateoutingmeetingdata.comment 
         AS 
            StateOutingMeetingComment, 
         dbo.stateoutingmeetingdata.dateandaction 
         AS 
            StateOutingMeetingDateAndAction, 
         dbo.stateoutingmeetingdata.target 
         AS 
            StateOutingMeetingTarget, 
         dbo.iftarmeetingdata.actual 
         AS 
            IftarMeetingActual, 
         dbo.iftarmeetingdata.averageattendance 
         AS 
            IftarMeetingAverageAttendance, 
         dbo.iftarmeetingdata.comment 
         AS 
            IftarMeetingComment, 
         dbo.iftarmeetingdata.dateandaction 
         AS 
            IftarMeetingDateAndAction, 
         dbo.iftarmeetingdata.target 
         AS 
            IftarMeetingTarget, 
         dbo.socialdawahmeetingdata.actual 
         AS 
            SocialDawahMeetingActual, 
         dbo.socialdawahmeetingdata.averageattendance 
         AS 
         SocialDawahMeetingAverageAttendance, 
         dbo.socialdawahmeetingdata.comment 
         AS 
            SocialDawahMeetingComment, 
         dbo.socialdawahmeetingdata.dateandaction 
         AS 
            SocialDawahMeetingDateAndAction, 
         dbo.socialdawahmeetingdata.target 
         AS 
            SocialDawahMeetingTarget, 
         dbo.dawahgroupmeetingdata.actual 
         AS 
            DawahGroupMeetingActual, 
         dbo.dawahgroupmeetingdata.averageattendance 
         AS 
         DawahGroupMeetingAverageAttendance, 
         dbo.dawahgroupmeetingdata.comment 
         AS 
            DawahGroupMeetingComment, 
         dbo.dawahgroupmeetingdata.dateandaction 
         AS 
            DawahGroupMeetingDateAndAction, 
         dbo.dawahgroupmeetingdata.target 
         AS 
            DawahGroupMeetingTarget, 
         dbo.nextgmeetingdata.actual 
         AS 
            NextGMeetingActual, 
         dbo.nextgmeetingdata.averageattendance 
         AS 
            NextGMeetingAverageAttendance, 
         dbo.nextgmeetingdata.comment 
         AS 
            NextGMeetingComment, 
         dbo.nextgmeetingdata.dateandaction 
         AS 
            NextGMeetingDateAndAction, 
         dbo.nextgmeetingdata.target 
         AS 
            NextGMeetingTarget, 
         dbo.membermemberdata.action 
         AS 
            MemberMemberAction, 
         dbo.membermemberdata.comment 
         AS 
            MemberMemberComment, 
         dbo.membermemberdata.decreased 
         AS 
            MemberMemberDecreased, 
         dbo.membermemberdata.increased 
         AS 
            MemberMemberIncreased, 
         dbo.membermemberdata.lastperiod 
         AS 
            MemberMemberLastPeriod, 
         dbo.membermemberdata.nameandcontactnumber 
         AS 
            MemberMemberNameAndContactNumber, 
         dbo.membermemberdata.personalcontact 
         AS 
            MemberMemberPersonalContact, 
         dbo.membermemberdata.upgradetarget 
         AS 
            MemberMemberUpgradeTarget, 
         dbo.baitulmalfinancedata.action 
         AS 
            BaitulMalFinanceAction, 
         dbo.baitulmalfinancedata.collectionamount 
         AS 
            BaitulMalFinanceCollectionAmount, 
         dbo.baitulmalfinancedata.collectioncurrency 
         AS 
         BaitulMalFinanceCollectionCurrency, 
         dbo.baitulmalfinancedata.comment 
         AS 
            BaitulMalFinanceComment, 
         dbo.baitulmalfinancedata.expenseamount 
         AS 
            BaitulMalFinanceExpenseAmount, 
         dbo.baitulmalfinancedata.expensecurrency 
         AS 
            BaitulMalFinanceExpenseCurrency, 
         dbo.baitulmalfinancedata.nisabpaidtocentralamount 
         AS 
         BaitulMalFinanceNisabPaidToCentralAmount, 
         dbo.baitulmalfinancedata.nisabpaidtocentralcurrency 
         AS 
         BaitulMalFinanceNisabPaidToCentralCurrency, 
         dbo.baitulmalfinancedata.othersourceaction 
         AS 
            BaitulMalFinanceOtherSourceAction, 
         dbo.baitulmalfinancedata.othersourceincreasetargetamount 
         AS 
         BaitulMalFinanceOtherSourceIncreaseTargetAmount, 
         dbo.baitulmalfinancedata.othersourceincreasetargetcurrency 
         AS 
         BaitulMalFinanceOtherSourceIncreaseTargetCurrency, 
         dbo.baitulmalfinancedata.workerpromisedecreasedamount 
         AS 
         BaitulMalFinanceWorkerPromiseDecreasedAmount, 
         dbo.baitulmalfinancedata.workerpromisedecreasedcurrency 
         AS 
         BaitulMalFinanceWorkerPromiseDecreasedCurrency, 
         dbo.baitulmalfinancedata.workerpromiseincreasedamount 
         AS 
         BaitulMalFinanceWorkerPromiseIncreasedAmount, 
         dbo.baitulmalfinancedata.workerpromiseincreasedcurrency 
         AS 
         BaitulMalFinanceWorkerPromiseIncreasedCurrency, 
         dbo.baitulmalfinancedata.workerpromiseincreasetargetamount 
         AS 
         BaitulMalFinanceWorkerPromiseIncreaseTargetAmount, 
         dbo.baitulmalfinancedata.workerpromiseincreasetargetcurrency 
         AS 
         BaitulMalFinanceWorkerPromiseIncreaseTargetCurrency, 
         dbo.baitulmalfinancedata.workerpromiselastperiodamount 
         AS 
         BaitulMalFinanceWorkerPromiseLastPeriodAmount, 
         dbo.baitulmalfinancedata.workerpromiselastperiodcurrency 
         AS 
         BaitulMalFinanceWorkerPromiseLastPeriodCurrency, 
         dbo.qardehasanasocialwelfaredata.actual 
         AS 
            QardeHasanaSocialWelfareActual, 
         dbo.qardehasanasocialwelfaredata.comment 
         AS 
            QardeHasanaSocialWelfareComment, 
         dbo.qardehasanasocialwelfaredata.dateandaction 
         AS 
         QardeHasanaSocialWelfareDateAndAction, 
         dbo.qardehasanasocialwelfaredata.target 
         AS 
            QardeHasanaSocialWelfareTarget, 
         dbo.patientvisitsocialwelfaredata.actual 
         AS 
            PatientVisitSocialWelfareActual, 
         dbo.patientvisitsocialwelfaredata.comment 
         AS 
            PatientVisitSocialWelfareComment, 
         dbo.patientvisitsocialwelfaredata.dateandaction 
         AS 
         PatientVisitSocialWelfareDateAndAction, 
         dbo.patientvisitsocialwelfaredata.target 
         AS 
            PatientVisitSocialWelfareTarget, 
         dbo.socialvisitsocialwelfaredata.actual 
         AS 
            SocialVisitSocialWelfareActual, 
         dbo.socialvisitsocialwelfaredata.comment 
         AS 
            SocialVisitSocialWelfareComment, 
         dbo.socialvisitsocialwelfaredata.dateandaction 
         AS 
         SocialVisitSocialWelfareDateAndAction, 
         dbo.socialvisitsocialwelfaredata.target 
         AS 
            SocialVisitSocialWelfareTarget, 
         dbo.transportsocialwelfaredata.actual 
         AS 
            TransportSocialWelfareActual, 
         dbo.transportsocialwelfaredata.comment 
         AS 
            TransportSocialWelfareComment, 
         dbo.transportsocialwelfaredata.dateandaction 
         AS 
         TransportSocialWelfareDateAndAction, 
         dbo.transportsocialwelfaredata.target 
         AS 
            TransportSocialWelfareTarget, 
         dbo.shiftingsocialwelfaredata.actual 
         AS 
            ShiftingSocialWelfareActual, 
         dbo.shiftingsocialwelfaredata.comment 
         AS 
            ShiftingSocialWelfareComment, 
         dbo.shiftingsocialwelfaredata.dateandaction 
         AS 
         ShiftingSocialWelfareDateAndAction, 
         dbo.shiftingsocialwelfaredata.target 
         AS 
            ShiftingSocialWelfareTarget, 
         dbo.shoppingsocialwelfaredata.actual 
         AS 
            ShoppingSocialWelfareActual, 
         dbo.shoppingsocialwelfaredata.comment 
         AS 
            ShoppingSocialWelfareComment, 
         dbo.shoppingsocialwelfaredata.dateandaction 
         AS 
         ShoppingSocialWelfareDateAndAction, 
         dbo.shoppingsocialwelfaredata.target 
         AS 
            ShoppingSocialWelfareTarget, 
         dbo.booksalematerialdata.actual 
         AS 
            BookSaleMaterialActual, 
         dbo.booksalematerialdata.comment 
         AS 
            BookSaleMaterialComment, 
         dbo.booksalematerialdata.dateandaction 
         AS 
            BookSaleMaterialDateAndAction, 
         dbo.booksalematerialdata.target 
         AS 
            BookSaleMaterialTarget, 
         dbo.bookdistributionmaterialdata.actual 
         AS 
            BookDistributionMaterialActual, 
         dbo.bookdistributionmaterialdata.comment 
         AS 
            BookDistributionMaterialComment, 
         dbo.bookdistributionmaterialdata.dateandaction 
         AS 
         BookDistributionMaterialDateAndAction, 
         dbo.bookdistributionmaterialdata.target 
         AS 
            BookDistributionMaterialTarget, 
         dbo.vhssalematerialdata.actual 
         AS 
            VhsSaleMaterialActual, 
         dbo.vhssalematerialdata.comment 
         AS 
            VhsSaleMaterialComment, 
         dbo.vhssalematerialdata.dateandaction 
         AS 
            VhsSaleMaterialDateAndAction, 
         dbo.vhssalematerialdata.target 
         AS 
            VhsSaleMaterialTarget, 
         dbo.vhsdistributionmaterialdata.actual 
         AS 
            VhsDistributionMaterialActual, 
         dbo.vhsdistributionmaterialdata.comment 
         AS 
            VhsDistributionMaterialComment, 
         dbo.vhsdistributionmaterialdata.dateandaction 
         AS 
         VhsDistributionMaterialDateAndAction, 
         dbo.vhsdistributionmaterialdata.target 
         AS 
            VhsDistributionMaterialTarget, 
         dbo.emaildistributionmaterialdata.actual 
         AS 
            EmailDistributionMaterialActual, 
         dbo.emaildistributionmaterialdata.comment 
         AS 
            EmailDistributionMaterialComment, 
         dbo.emaildistributionmaterialdata.dateandaction 
         AS 
         EmailDistributionMaterialDateAndAction, 
         dbo.emaildistributionmaterialdata.target 
         AS 
            EmailDistributionMaterialTarget, 
         dbo.ipdcleafletdistributionmaterialdata.actual 
         AS 
         IpdcLeafletDistributionMaterialActual, 
         dbo.ipdcleafletdistributionmaterialdata.comment 
         AS 
         IpdcLeafletDistributionMaterialComment, 
         dbo.ipdcleafletdistributionmaterialdata.dateandaction 
         AS 
         IpdcLeafletDistributionMaterialDateAndAction, 
         dbo.ipdcleafletdistributionmaterialdata.target 
         AS 
         IpdcLeafletDistributionMaterialTarget, 
         dbo.booklibrarystockdata.comment 
         AS 
            BookLibraryStockComment, 
         dbo.booklibrarystockdata.decreased 
         AS 
            BookLibraryStockDecreased, 
         dbo.booklibrarystockdata.increased 
         AS 
            BookLibraryStockIncreased, 
         dbo.booklibrarystockdata.lastperiod 
         AS 
            BookLibraryStockLastPeriod, 
         dbo.vhslibrarystockdata.comment 
         AS 
            VhsLibraryStockComment, 
         dbo.vhslibrarystockdata.decreased 
         AS 
            VhsLibraryStockDecreased, 
         dbo.vhslibrarystockdata.increased 
         AS 
            VhsLibraryStockIncreased, 
         dbo.vhslibrarystockdata.lastperiod 
         AS 
            VhsLibraryStockLastPeriod, 
         dbo.groupstudyteachinglearningprogramdata.actual 
         AS 
         GroupStudyTeachingLearningProgramActual, 
         dbo.groupstudyteachinglearningprogramdata.averageattendance 
         AS 
         GroupStudyTeachingLearningProgramAverageAttendance, 
         dbo.groupstudyteachinglearningprogramdata.comment 
         AS 
         GroupStudyTeachingLearningProgramComment, 
         dbo.groupstudyteachinglearningprogramdata.dateandaction 
         AS 
         GroupStudyTeachingLearningProgramDateAndAction, 
         dbo.groupstudyteachinglearningprogramdata.target 
         AS 
         GroupStudyTeachingLearningProgramTarget, 
         dbo.studycircleteachinglearningprogramdata.actual 
         AS 
         StudyCircleTeachingLearningProgramActual, 
         dbo.studycircleteachinglearningprogramdata.averageattendance 
         AS 
         StudyCircleTeachingLearningProgramAverageAttendance, 
         dbo.studycircleteachinglearningprogramdata.comment 
         AS 
         StudyCircleTeachingLearningProgramComment, 
         dbo.studycircleteachinglearningprogramdata.dateandaction 
         AS 
         StudyCircleTeachingLearningProgramDateAndAction, 
         dbo.studycircleteachinglearningprogramdata.target 
         AS 
         StudyCircleTeachingLearningProgramTarget, 
         dbo.practicedarsteachinglearningprogramdata.actual 
         AS 
         PracticeDarsTeachingLearningProgramActual, 
         dbo.practicedarsteachinglearningprogramdata.averageattendance 
         AS 
         PracticeDarsTeachingLearningProgramAverageAttendance, 
         dbo.practicedarsteachinglearningprogramdata.comment 
         AS 
         PracticeDarsTeachingLearningProgramComment, 
         dbo.practicedarsteachinglearningprogramdata.dateandaction 
         AS 
         PracticeDarsTeachingLearningProgramDateAndAction, 
         dbo.practicedarsteachinglearningprogramdata.target 
         AS 
         PracticeDarsTeachingLearningProgramTarget, 
         dbo.statelearningcampteachinglearningprogramdata.actual 
         AS 
         StateLearningCampTeachingLearningProgramActual, 
         dbo.statelearningcampteachinglearningprogramdata.averageattendance 
         AS 
         StateLearningCampTeachingLearningProgramAverageAttendance, 
         dbo.statelearningcampteachinglearningprogramdata.comment 
         AS 
         StateLearningCampTeachingLearningProgramComment, 
         dbo.statelearningcampteachinglearningprogramdata.dateandaction 
         AS 
         StateLearningCampTeachingLearningProgramDateAndAction, 
         dbo.statelearningcampteachinglearningprogramdata.target 
         AS 
         StateLearningCampTeachingLearningProgramTarget,          
         dbo.organization.description 
         AS 
            OrganizaDescription, 
         dbo.organization.isdeleted 
         AS 
            OrganizaIsDeleted, 
         dbo.organization.organizationtype 
         AS 
            OrganizaOrganizationType, 
         dbo.organization.parentdescription 
         AS 
            OrganizaParentDescription, 
         dbo.organization.reportingfrequency 
         AS 
            OrganizaReportingFrequency, 
         dbo.organization.timestamp 
         AS 
            OrganizaTimestamp, 
         dbo.quranstudyteachinglearningprogramdata.actual 
         AS 
         QuranStudyTeachingLearningProgramActual, 
         dbo.quranstudyteachinglearningprogramdata.averageattendance 
         AS 
         QuranStudyTeachingLearningProgramAverageAttendance, 
         dbo.quranstudyteachinglearningprogramdata.comment 
         AS 
         QuranStudyTeachingLearningProgramComment, 
         dbo.quranstudyteachinglearningprogramdata.dateandaction 
         AS 
         QuranStudyTeachingLearningProgramDateAndAction, 
         dbo.quranstudyteachinglearningprogramdata.target 
         AS 
         QuranStudyTeachingLearningProgramTarget,          
         dbo.quranclassteachinglearningprogramdata.actual 
         AS 
         QuranClassTeachingLearningProgramActual, 
         dbo.quranclassteachinglearningprogramdata.averageattendance 
         AS 
         QuranClassTeachingLearningProgramAverageAttendance, 
         dbo.quranclassteachinglearningprogramdata.comment 
         AS 
         QuranClassTeachingLearningProgramComment, 
         dbo.quranclassteachinglearningprogramdata.dateandaction 
         AS 
         QuranClassTeachingLearningProgramDateAndAction, 
         dbo.quranclassteachinglearningprogramdata.target 
         AS 
         QuranClassTeachingLearningProgramTarget, 
         dbo.memorizingayatteachinglearningprogramdata.actual 
         AS 
         MemorizingAyatTeachingLearningProgramActual, 
         dbo.memorizingayatteachinglearningprogramdata.averageattendance 
         AS 
         MemorizingAyatTeachingLearningProgramAverageAttendance, 
         dbo.memorizingayatteachinglearningprogramdata.comment 
         AS 
         MemorizingAyatTeachingLearningProgramComment, 
         dbo.memorizingayatteachinglearningprogramdata.dateandaction 
         AS 
         MemorizingAyatTeachingLearningProgramDateAndAction, 
         dbo.memorizingayatteachinglearningprogramdata.target 
         AS 
         MemorizingAyatTeachingLearningProgramTarget, 
         dbo.statelearningsessionteachinglearningprogramdata.actual 
         AS 
         StateLearningSessionTeachingLearningProgramActual, 
         dbo.statelearningsessionteachinglearningprogramdata.averageattendance 
         AS 
         StateLearningSessionTeachingLearningProgramAverageAttendance, 
         dbo.statelearningsessionteachinglearningprogramdata.comment 
         AS 
         StateLearningSessionTeachingLearningProgramComment, 
         dbo.statelearningsessionteachinglearningprogramdata.dateandaction 
         AS 
         StateLearningSessionTeachingLearningProgramDateAndAction, 
         dbo.statelearningsessionteachinglearningprogramdata.target 
         AS 
         StateLearningSessionTeachingLearningProgramTarget, 
         dbo.stateqiyamullailteachinglearningprogramdata.actual 
         AS 
         StateQiyamulLailTeachingLearningProgramActual, 
         dbo.stateqiyamullailteachinglearningprogramdata.averageattendance 
         AS 
         StateQiyamulLailTeachingLearningProgramAverageAttendance, 
         dbo.stateqiyamullailteachinglearningprogramdata.comment 
         AS 
         StateQiyamulLailTeachingLearningProgramComment, 
         dbo.stateqiyamullailteachinglearningprogramdata.dateandaction 
         AS 
         StateQiyamulLailTeachingLearningProgramDateAndAction, 
         dbo.stateqiyamullailteachinglearningprogramdata.target 
         AS 
         StateQiyamulLailTeachingLearningProgramTarget, 
         dbo.supportermemberdata.action 
         AS 
            SupporterMemberAction, 
         dbo.supportermemberdata.comment 
         AS 
            SupporterMemberComment, 
         dbo.supportermemberdata.decreased 
         AS 
            SupporterMemberDecreased, 
         dbo.supportermemberdata.increased 
         AS 
            SupporterMemberIncreased, 
         dbo.supportermemberdata.lastperiod 
         AS 
            SupporterMemberLastPeriod, 
         dbo.supportermemberdata.nameandcontactnumber 
         AS 
         SupporterMemberNameAndContactNumber, 
         dbo.supportermemberdata.personalcontact 
         AS 
            SupporterMemberPersonalContact, 
         dbo.supportermemberdata.upgradetarget 
         AS 
            SupporterMemberUpgradeTarget, 
         dbo.adaymasjidprojectfinancedata.action 
         AS 
            ADayMasjidProjectFinanceAction, 
         dbo.adaymasjidprojectfinancedata.collectionamount 
         AS 
         ADayMasjidProjectFinanceCollectionAmount, 
         dbo.adaymasjidprojectfinancedata.collectioncurrency 
         AS 
         ADayMasjidProjectFinanceCollectionCurrency, 
         dbo.adaymasjidprojectfinancedata.comment 
         AS 
            ADayMasjidProjectFinanceComment, 
         dbo.adaymasjidprojectfinancedata.expenseamount 
         AS 
         ADayMasjidProjectFinanceExpenseAmount, 
         dbo.adaymasjidprojectfinancedata.expensecurrency 
         AS 
         ADayMasjidProjectFinanceExpenseCurrency, 
         dbo.adaymasjidprojectfinancedata.nisabpaidtocentralamount 
         AS 
         ADayMasjidProjectFinanceNisabPaidToCentralAmount, 
         dbo.adaymasjidprojectfinancedata.nisabpaidtocentralcurrency 
         AS 
         ADayMasjidProjectFinanceNisabPaidToCentralCurrency, 
         dbo.adaymasjidprojectfinancedata.othersourceaction 
         AS 
         ADayMasjidProjectFinanceOtherSourceAction, 
         dbo.adaymasjidprojectfinancedata.othersourceincreasetargetamount 
         AS 
         ADayMasjidProjectFinanceOtherSourceIncreaseTargetAmount, 
         dbo.adaymasjidprojectfinancedata.othersourceincreasetargetcurrency 
         AS 
         ADayMasjidProjectFinanceOtherSourceIncreaseTargetCurrency, 
         dbo.adaymasjidprojectfinancedata.workerpromisedecreasedamount 
         AS 
         ADayMasjidProjectFinanceWorkerPromiseDecreasedAmount, 
         dbo.adaymasjidprojectfinancedata.workerpromisedecreasedcurrency 
         AS 
         ADayMasjidProjectFinanceWorkerPromiseDecreasedCurrency, 
         dbo.adaymasjidprojectfinancedata.workerpromiseincreasedamount 
         AS 
         ADayMasjidProjectFinanceWorkerPromiseIncreasedAmount, 
         dbo.adaymasjidprojectfinancedata.workerpromiseincreasedcurrency 
         AS 
         ADayMasjidProjectFinanceWorkerPromiseIncreasedCurrency, 
         dbo.adaymasjidprojectfinancedata.workerpromiseincreasetargetamount 
         AS 
         ADayMasjidProjectFinanceWorkerPromiseIncreaseTargetAmount, 
         dbo.adaymasjidprojectfinancedata.workerpromiseincreasetargetcurrency 
         AS 
         ADayMasjidProjectFinanceWorkerPromiseIncreaseTargetCurrency, 
         dbo.adaymasjidprojectfinancedata.workerpromiselastperiodamount 
         AS 
         ADayMasjidProjectFinanceWorkerPromiseLastPeriodAmount, 
         dbo.adaymasjidprojectfinancedata.workerpromiselastperiodcurrency 
         AS 
         ADayMasjidProjectFinanceWorkerPromiseLastPeriodCurrency, 
         dbo.dawahmeetingdata.actual 
         AS 
            DawahMeetingActual, 
         dbo.dawahmeetingdata.averageattendance 
         AS 
            DawahMeetingAverageAttendance, 
         dbo.dawahmeetingdata.comment 
         AS 
            DawahMeetingComment, 
         dbo.dawahmeetingdata.dateandaction 
         AS 
            DawahMeetingDateAndAction, 
         dbo.dawahmeetingdata.target 
         AS 
            DawahMeetingTarget, 
         dbo.masjidtablebankfinancedata.action 
         AS 
            MasjidTableBankFinanceAction, 
         dbo.masjidtablebankfinancedata.collectionamount 
         AS 
         MasjidTableBankFinanceCollectionAmount, 
         dbo.masjidtablebankfinancedata.collectioncurrency 
         AS 
         MasjidTableBankFinanceCollectionCurrency, 
         dbo.masjidtablebankfinancedata.comment 
         AS 
            MasjidTableBankFinanceComment, 
         dbo.masjidtablebankfinancedata.expenseamount 
         AS 
         MasjidTableBankFinanceExpenseAmount, 
         dbo.masjidtablebankfinancedata.expensecurrency 
         AS 
         MasjidTableBankFinanceExpenseCurrency, 
         dbo.masjidtablebankfinancedata.nisabpaidtocentralamount 
         AS 
         MasjidTableBankFinanceNisabPaidToCentralAmount, 
         dbo.masjidtablebankfinancedata.nisabpaidtocentralcurrency 
         AS 
         MasjidTableBankFinanceNisabPaidToCentralCurrency, 
         dbo.masjidtablebankfinancedata.othersourceaction 
         AS 
         MasjidTableBankFinanceOtherSourceAction, 
         dbo.masjidtablebankfinancedata.othersourceincreasetargetamount 
         AS 
         MasjidTableBankFinanceOtherSourceIncreaseTargetAmount, 
         dbo.masjidtablebankfinancedata.othersourceincreasetargetcurrency 
         AS 
         MasjidTableBankFinanceOtherSourceIncreaseTargetCurrency, 
         dbo.masjidtablebankfinancedata.workerpromisedecreasedamount 
         AS 
         MasjidTableBankFinanceWorkerPromiseDecreasedAmount, 
         dbo.masjidtablebankfinancedata.workerpromisedecreasedcurrency 
         AS 
         MasjidTableBankFinanceWorkerPromiseDecreasedCurrency, 
         dbo.masjidtablebankfinancedata.workerpromiseincreasedamount 
         AS 
         MasjidTableBankFinanceWorkerPromiseIncreasedAmount, 
         dbo.masjidtablebankfinancedata.workerpromiseincreasedcurrency 
         AS 
         MasjidTableBankFinanceWorkerPromiseIncreasedCurrency, 
         dbo.masjidtablebankfinancedata.workerpromiseincreasetargetamount 
         AS 
         MasjidTableBankFinanceWorkerPromiseIncreaseTargetAmount, 
         dbo.masjidtablebankfinancedata.workerpromiseincreasetargetcurrency 
         AS 
         MasjidTableBankFinanceWorkerPromiseIncreaseTargetCurrency, 
         dbo.masjidtablebankfinancedata.workerpromiselastperiodamount 
         AS 
         MasjidTableBankFinanceWorkerPromiseLastPeriodAmount, 
         dbo.masjidtablebankfinancedata.workerpromiselastperiodcurrency 
         AS 
         MasjidTableBankFinanceWorkerPromiseLastPeriodCurrency, 
         dbo.learningmeetingdata.actual 
         AS 
            LearningMeetingActual, 
         dbo.learningmeetingdata.averageattendance 
         AS 
            LearningMeetingAverageAttendance, 
         dbo.learningmeetingdata.comment 
         AS 
            LearningMeetingComment, 
         dbo.learningmeetingdata.dateandaction 
         AS 
            LearningMeetingDateAndAction, 
         dbo.learningmeetingdata.target 
         AS 
            LearningMeetingTarget 
  FROM   dbo.report 
         INNER JOIN dbo.organization 
                 ON dbo.report.organizationid = dbo.organization.id 
         INNER JOIN dbo.associatememberdata 
                 ON dbo.report.id = dbo.associatememberdata.reportid 
         INNER JOIN dbo.preliminarymemberdata 
                 ON dbo.report.id = dbo.preliminarymemberdata.reportid 
         INNER JOIN dbo.workermeetingdata 
                 ON dbo.report.id = dbo.workermeetingdata.reportid 
         INNER JOIN dbo.stateleadermeetingdata 
                 ON dbo.report.id = dbo.stateleadermeetingdata.reportid 
         INNER JOIN dbo.stateoutingmeetingdata 
                 ON dbo.report.id = dbo.stateoutingmeetingdata.reportid 
         INNER JOIN dbo.iftarmeetingdata 
                 ON dbo.report.id = dbo.iftarmeetingdata.reportid 
         INNER JOIN dbo.socialdawahmeetingdata 
                 ON dbo.report.id = dbo.socialdawahmeetingdata.reportid 
         INNER JOIN dbo.dawahgroupmeetingdata 
                 ON dbo.report.id = dbo.dawahgroupmeetingdata.reportid 
         INNER JOIN dbo.nextgmeetingdata 
                 ON dbo.report.id = dbo.nextgmeetingdata.reportid 
         INNER JOIN dbo.membermemberdata 
                 ON dbo.report.id = dbo.membermemberdata.reportid 
         INNER JOIN dbo.baitulmalfinancedata 
                 ON dbo.report.id = dbo.baitulmalfinancedata.reportid 
         INNER JOIN dbo.qardehasanasocialwelfaredata 
                 ON dbo.report.id = dbo.qardehasanasocialwelfaredata.reportid 
         INNER JOIN dbo.patientvisitsocialwelfaredata 
                 ON dbo.report.id = dbo.patientvisitsocialwelfaredata.reportid 
         INNER JOIN dbo.socialvisitsocialwelfaredata 
                 ON dbo.report.id = dbo.socialvisitsocialwelfaredata.reportid 
         INNER JOIN dbo.transportsocialwelfaredata 
                 ON dbo.report.id = dbo.transportsocialwelfaredata.reportid 
         INNER JOIN dbo.shiftingsocialwelfaredata 
                 ON dbo.report.id = dbo.shiftingsocialwelfaredata.reportid 
         INNER JOIN dbo.shoppingsocialwelfaredata 
                 ON dbo.report.id = dbo.shoppingsocialwelfaredata.reportid 
         INNER JOIN dbo.booksalematerialdata 
                 ON dbo.report.id = dbo.booksalematerialdata.reportid 
         INNER JOIN dbo.bookdistributionmaterialdata 
                 ON dbo.report.id = dbo.bookdistributionmaterialdata.reportid 
         INNER JOIN dbo.vhssalematerialdata 
                 ON dbo.report.id = dbo.vhssalematerialdata.reportid 
         INNER JOIN dbo.vhsdistributionmaterialdata 
                 ON dbo.report.id = dbo.vhsdistributionmaterialdata.reportid 
         INNER JOIN dbo.emaildistributionmaterialdata 
                 ON dbo.report.id = dbo.emaildistributionmaterialdata.reportid 
         INNER JOIN dbo.ipdcleafletdistributionmaterialdata 
                 ON dbo.report.id = dbo.ipdcleafletdistributionmaterialdata.reportid 
         INNER JOIN dbo.booklibrarystockdata 
                 ON dbo.report.id = dbo.booklibrarystockdata.reportid 
         INNER JOIN dbo.vhslibrarystockdata 
                 ON dbo.report.id = dbo.vhslibrarystockdata.reportid 
         INNER JOIN dbo.groupstudyteachinglearningprogramdata 
                 ON dbo.report.id = dbo.groupstudyteachinglearningprogramdata.reportid 
         INNER JOIN dbo.studycircleteachinglearningprogramdata 
                 ON dbo.report.id = 
                    dbo.studycircleteachinglearningprogramdata.reportid 
         INNER JOIN dbo.practicedarsteachinglearningprogramdata 
                 ON dbo.report.id = 
                    dbo.practicedarsteachinglearningprogramdata.reportid 
         INNER JOIN dbo.statelearningcampteachinglearningprogramdata 
                 ON dbo.report.id = 
                    dbo.statelearningcampteachinglearningprogramdata.reportid 
         INNER JOIN dbo.quranstudyteachinglearningprogramdata 
                 ON dbo.report.id = dbo.quranstudyteachinglearningprogramdata.reportid 
         INNER JOIN dbo.quranclassteachinglearningprogramdata 
                 ON dbo.report.id = dbo.quranclassteachinglearningprogramdata.reportid 
         INNER JOIN dbo.memorizingayatteachinglearningprogramdata 
                 ON dbo.report.id = 
                    dbo.memorizingayatteachinglearningprogramdata.reportid 
         INNER JOIN dbo.statelearningsessionteachinglearningprogramdata 
                 ON dbo.report.id = 
                    dbo.statelearningsessionteachinglearningprogramdata.reportid 
         INNER JOIN dbo.stateqiyamullailteachinglearningprogramdata 
                 ON dbo.report.id = 
                    dbo.stateqiyamullailteachinglearningprogramdata.reportid 
         INNER JOIN dbo.supportermemberdata 
                 ON dbo.report.id = dbo.supportermemberdata.reportid 
         INNER JOIN dbo.adaymasjidprojectfinancedata 
                 ON dbo.report.id = dbo.adaymasjidprojectfinancedata.reportid 
         INNER JOIN dbo.dawahmeetingdata 
                 ON dbo.report.id = dbo.dawahmeetingdata.reportid 
         INNER JOIN dbo.masjidtablebankfinancedata 
                 ON dbo.report.id = dbo.masjidtablebankfinancedata.reportid 
         INNER JOIN dbo.learningmeetingdata 
                 ON dbo.report.id = dbo.learningmeetingdata.id 
  WHERE  ( dbo.report.isdeleted = 0 ) 
         AND ( dbo.organization.organizationtype = 1 ) 