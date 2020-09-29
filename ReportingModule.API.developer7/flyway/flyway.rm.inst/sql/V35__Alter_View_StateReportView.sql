ALTER VIEW dbo.statereportview 
AS 
  SELECT 
  dbo.report.id 
  AS 
  ReportId, 
         dbo.report.description 
            AS ReportDescription, 
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
         dbo.report.timestamp, 
         dbo.organization.parentid, 
         dbo.organization.parentdescription, 
         dbo.associatememberdata.nameandcontactnumber 
            AS 
         AssociateMemberNameAndContactNumber, 
         dbo.associatememberdata.lastperiod 
            AS AssociateMemberLastPeriod, 
         dbo.associatememberdata.action 
            AS AssociateMemberAction, 
         dbo.associatememberdata.upgradetarget 
            AS AssociateMemberUpgradeTarget, 
         dbo.associatememberdata.increased 
            AS AssociateMemberIncreased, 
         dbo.associatememberdata.decreased 
            AS AssociateMemberDecreased, 
         dbo.associatememberdata.comment 
            AS AssociateMemberComment, 
         dbo.associatememberdata.personalcontact 
            AS AssociateMemberPersonalContact, 
         dbo.associatemembergenerateddata.nameandcontactnumber 
            AS 
         AssociateMemberGeneratedNameAndContactNumber, 
         dbo.associatemembergenerateddata.lastperiod 
            AS 
         AssociateMemberGeneratedLastPeriod, 
         dbo.associatemembergenerateddata.action 
            AS AssociateMemberGeneratedAction, 
         dbo.associatemembergenerateddata.upgradetarget 
            AS 
         AssociateMemberGeneratedUpgradeTarget, 
         dbo.associatemembergenerateddata.increased 
            AS AssociateMemberGeneratedIncreased, 
         dbo.associatemembergenerateddata.decreased 
            AS AssociateMemberGeneratedDecreased, 
         dbo.associatemembergenerateddata.comment 
            AS AssociateMemberGeneratedComment, 
         dbo.associatemembergenerateddata.personalcontact 
            AS 
         AssociateMemberGeneratedPersonalContact, 
         dbo.preliminarymemberdata.nameandcontactnumber 
            AS 
         PreliminaryMemberNameAndContactNumber, 
         dbo.preliminarymemberdata.lastperiod 
            AS PreliminaryMemberLastPeriod, 
         dbo.preliminarymemberdata.action 
            AS PreliminaryMemberAction, 
         dbo.preliminarymemberdata.upgradetarget 
            AS PreliminaryMemberUpgradeTarget, 
         dbo.preliminarymemberdata.increased 
            AS PreliminaryMemberIncreased, 
         dbo.preliminarymemberdata.decreased 
            AS PreliminaryMemberDecreased, 
         dbo.preliminarymemberdata.comment 
            AS PreliminaryMemberComment, 
         dbo.preliminarymemberdata.personalcontact 
            AS PreliminaryMemberPersonalContact, 
         dbo.preliminarymembergenerateddata.nameandcontactnumber 
            AS 
         PreliminaryMemberGeneratedNameAndContactNumber, 
         dbo.preliminarymembergenerateddata.lastperiod 
            AS 
         PreliminaryMemberGeneratedLastPeriod, 
         dbo.preliminarymembergenerateddata.action 
            AS PreliminaryMemberGeneratedAction, 
         dbo.preliminarymembergenerateddata.upgradetarget 
            AS 
         PreliminaryMemberGeneratedUpgradeTarget, 
         dbo.preliminarymembergenerateddata.increased 
            AS 
         PreliminaryMemberGeneratedIncreased, 
         dbo.preliminarymembergenerateddata.decreased 
            AS 
         PreliminaryMemberGeneratedDecreased, 
         dbo.preliminarymembergenerateddata.comment 
            AS PreliminaryMemberGeneratedComment, 
         dbo.preliminarymembergenerateddata.personalcontact 
            AS 
         PreliminaryMemberGeneratedPersonalContact, 
         dbo.workermeetingdata.target 
            AS WorkerMeetingTarget, 
         dbo.workermeetingdata.dateandaction 
            AS WorkerMeetingDateAndAction, 
         dbo.workermeetingdata.actual 
            AS WorkerMeetingActual, 
         dbo.workermeetingdata.averageattendance 
            AS WorkerMeetingAverageAttendance, 
         dbo.workermeetingdata.comment 
            AS WorkerMeetingComment, 
         dbo.workermeetinggenerateddata.target 
            AS WorkerMeetingGeneratedTarget, 
         dbo.workermeetinggenerateddata.dateandaction 
            AS 
         WorkerMeetingGeneratedDateAndAction, 
         dbo.workermeetinggenerateddata.actual 
            AS WorkerMeetingGeneratedActual, 
         dbo.workermeetinggenerateddata.averageattendance 
            AS 
         WorkerMeetingGeneratedAverageAttendance, 
         dbo.workermeetinggenerateddata.comment 
            AS WorkerMeetingGeneratedComment, 
         dbo.stateleadermeetingdata.actual 
            AS StateLeaderMeetingActual, 
         dbo.stateleadermeetingdata.averageattendance 
            AS 
         StateLeaderMeetingAverageAttendance, 
         dbo.stateleadermeetingdata.comment 
            AS StateLeaderMeetingComment, 
         dbo.stateleadermeetingdata.dateandaction 
            AS StateLeaderMeetingDateAndAction, 
         dbo.stateleadermeetingdata.target 
            AS StateLeaderMeetingTarget, 
         dbo.stateleadermeetinggenerateddata.actual 
            AS StateLeaderMeetingGeneratedActual, 
         dbo.stateleadermeetinggenerateddata.averageattendance 
            AS 
         StateLeaderMeetingGeneratedAverageAttendance, 
         dbo.stateleadermeetinggenerateddata.comment 
            AS 
         StateLeaderMeetingGeneratedComment, 
         dbo.stateleadermeetinggenerateddata.dateandaction 
            AS 
         StateLeaderMeetingGeneratedDateAndAction, 
         dbo.stateleadermeetinggenerateddata.target 
            AS StateLeaderMeetingGeneratedTarget, 
         dbo.stateoutingmeetingdata.actual 
            AS StateOutingMeetingActual, 
         dbo.stateoutingmeetingdata.averageattendance 
            AS 
         StateOutingMeetingAverageAttendance, 
         dbo.stateoutingmeetingdata.comment 
            AS StateOutingMeetingComment, 
         dbo.stateoutingmeetingdata.dateandaction 
            AS StateOutingMeetingDateAndAction, 
         dbo.stateoutingmeetingdata.target 
            AS StateOutingMeetingTarget, 
         dbo.stateoutingmeetinggenerateddata.actual 
            AS StateOutingMeetingGeneratedActual, 
         dbo.stateoutingmeetinggenerateddata.averageattendance 
            AS 
         StateOutingMeetingGeneratedAverageAttendance, 
         dbo.stateoutingmeetinggenerateddata.comment 
            AS 
         StateOutingMeetingGeneratedComment, 
         dbo.stateoutingmeetinggenerateddata.dateandaction 
            AS 
         StateOutingMeetingGeneratedDateAndAction, 
         dbo.stateoutingmeetinggenerateddata.target 
            AS StateOutingMeetingGeneratedTarget, 
         dbo.iftarmeetingdata.actual 
            AS IftarMeetingActual, 
         dbo.iftarmeetingdata.averageattendance 
            AS IftarMeetingAverageAttendance, 
         dbo.iftarmeetingdata.comment 
            AS IftarMeetingComment, 
         dbo.iftarmeetingdata.dateandaction 
            AS IftarMeetingDateAndAction, 
         dbo.iftarmeetingdata.target 
            AS IftarMeetingTarget, 
         dbo.iftarmeetinggenerateddata.actual 
            AS IftarMeetingGeneratedActual, 
         dbo.iftarmeetinggenerateddata.averageattendance 
            AS 
         IftarMeetingGeneratedAverageAttendance, 
         dbo.iftarmeetinggenerateddata.comment 
            AS IftarMeetingGeneratedComment, 
         dbo.iftarmeetinggenerateddata.dateandaction 
            AS 
         IftarMeetingGeneratedDateAndAction, 
         dbo.iftarmeetinggenerateddata.target 
            AS IftarMeetingGeneratedTarget, 
         dbo.socialdawahmeetingdata.actual 
            AS SocialDawahMeetingActual, 
         dbo.socialdawahmeetingdata.averageattendance 
            AS 
         SocialDawahMeetingAverageAttendance, 
         dbo.socialdawahmeetingdata.comment 
            AS SocialDawahMeetingComment, 
         dbo.socialdawahmeetingdata.dateandaction 
            AS SocialDawahMeetingDateAndAction, 
         dbo.socialdawahmeetingdata.target 
            AS SocialDawahMeetingTarget, 
         dbo.socialdawahmeetinggenerateddata.actual 
            AS SocialDawahMeetingGeneratedActual, 
         dbo.socialdawahmeetinggenerateddata.averageattendance 
            AS 
         SocialDawahMeetingGeneratedAverageAttendance, 
         dbo.socialdawahmeetinggenerateddata.comment 
            AS 
         SocialDawahMeetingGeneratedComment, 
         dbo.socialdawahmeetinggenerateddata.dateandaction 
            AS 
         SocialDawahMeetingGeneratedDateAndAction, 
         dbo.socialdawahmeetinggenerateddata.target 
            AS SocialDawahMeetingGeneratedTarget, 
         dbo.dawahgroupmeetingdata.actual 
            AS DawahGroupMeetingActual, 
         dbo.dawahgroupmeetingdata.averageattendance 
            AS 
         DawahGroupMeetingAverageAttendance, 
         dbo.dawahgroupmeetingdata.comment 
            AS DawahGroupMeetingComment, 
         dbo.dawahgroupmeetingdata.dateandaction 
            AS DawahGroupMeetingDateAndAction, 
         dbo.dawahgroupmeetingdata.target 
            AS DawahGroupMeetingTarget, 
         dbo.dawahgroupmeetinggenerateddata.actual 
            AS DawahGroupMeetingGeneratedActual, 
         dbo.dawahgroupmeetinggenerateddata.averageattendance 
            AS 
         DawahGroupMeetingGeneratedAverageAttendance, 
         dbo.dawahgroupmeetinggenerateddata.comment 
            AS DawahGroupMeetingGeneratedComment, 
         dbo.dawahgroupmeetinggenerateddata.dateandaction 
            AS 
         DawahGroupMeetingGeneratedDateAndAction, 
         dbo.dawahgroupmeetinggenerateddata.target 
            AS DawahGroupMeetingGeneratedTarget, 
         dbo.nextgmeetingdata.actual 
            AS NextGMeetingActual, 
         dbo.nextgmeetingdata.averageattendance 
            AS NextGMeetingAverageAttendance, 
         dbo.nextgmeetingdata.comment 
            AS NextGMeetingComment, 
         dbo.nextgmeetingdata.dateandaction 
            AS NextGMeetingDateAndAction, 
         dbo.nextgmeetingdata.target 
            AS NextGMeetingTarget, 
         dbo.nextgmeetinggenerateddata.actual 
            AS NextGMeetingGeneratedActual, 
         dbo.nextgmeetinggenerateddata.averageattendance 
            AS 
         NextGMeetingGeneratedAverageAttendance, 
         dbo.nextgmeetinggenerateddata.comment 
            AS NextGMeetingGeneratedComment, 
         dbo.nextgmeetinggenerateddata.dateandaction 
            AS 
         NextGMeetingGeneratedDateAndAction, 
         dbo.nextgmeetinggenerateddata.target 
            AS NextGMeetingGeneratedTarget, 
         dbo.membermemberdata.action 
            AS MemberMemberAction, 
         dbo.membermemberdata.comment 
            AS MemberMemberComment, 
         dbo.membermemberdata.decreased 
            AS MemberMemberDecreased, 
         dbo.membermemberdata.increased 
            AS MemberMemberIncreased, 
         dbo.membermemberdata.lastperiod 
            AS MemberMemberLastPeriod, 
         dbo.membermemberdata.nameandcontactnumber 
            AS MemberMemberNameAndContactNumber, 
         dbo.membermemberdata.personalcontact 
            AS MemberMemberPersonalContact, 
         dbo.membermemberdata.upgradetarget 
            AS MemberMemberUpgradeTarget, 
         dbo.membermembergenerateddata.action 
            AS MemberMemberGeneratedAction, 
         dbo.membermembergenerateddata.comment 
            AS MemberMemberGeneratedComment, 
         dbo.membermembergenerateddata.decreased 
            AS MemberMemberGeneratedDecreased, 
         dbo.membermembergenerateddata.increased 
            AS MemberMemberGeneratedIncreased, 
         dbo.membermembergenerateddata.lastperiod 
            AS MemberMemberGeneratedLastPeriod, 
         dbo.membermembergenerateddata.nameandcontactnumber 
            AS 
         MemberMemberGeneratedNameAndContactNumber, 
         dbo.membermembergenerateddata.personalcontact 
            AS 
         MemberMemberGeneratedPersonalContact, 
         dbo.membermembergenerateddata.upgradetarget 
            AS 
         MemberMemberGeneratedUpgradeTarget, 
         dbo.baitulmalfinancedata.action 
            AS BaitulMalFinanceAction, 
         dbo.baitulmalfinancedata.collectionamount 
            AS BaitulMalFinanceCollectionAmount, 
         dbo.baitulmalfinancedata.collectioncurrency 
            AS 
         BaitulMalFinanceCollectionCurrency, 
         dbo.baitulmalfinancedata.comment 
            AS BaitulMalFinanceComment, 
         dbo.baitulmalfinancedata.expenseamount 
            AS BaitulMalFinanceExpenseAmount, 
         dbo.baitulmalfinancedata.expensecurrency 
            AS BaitulMalFinanceExpenseCurrency, 
         dbo.baitulmalfinancedata.nisabpaidtocentralamount 
            AS 
         BaitulMalFinanceNisabPaidToCentralAmount, 
         dbo.baitulmalfinancedata.nisabpaidtocentralcurrency 
            AS 
         BaitulMalFinanceNisabPaidToCentralCurrency, 
         dbo.baitulmalfinancedata.othersourceaction 
            AS BaitulMalFinanceOtherSourceAction, 
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
         dbo.baitulmalfinancegenerateddata.action 
            AS BaitulMalFinanceGeneratedAction, 
         dbo.baitulmalfinancegenerateddata.collectionamount 
            AS 
         BaitulMalFinanceGeneratedCollectionAmount, 
         dbo.baitulmalfinancegenerateddata.collectioncurrency 
            AS 
         BaitulMalFinanceGeneratedCollectionCurrency, 
         dbo.baitulmalfinancegenerateddata.comment 
            AS BaitulMalFinanceGeneratedComment, 
         dbo.baitulmalfinancegenerateddata.expenseamount 
            AS 
         BaitulMalFinanceGeneratedExpenseAmount, 
         dbo.baitulmalfinancegenerateddata.expensecurrency 
            AS 
         BaitulMalFinanceGeneratedExpenseCurrency, 
         dbo.baitulmalfinancegenerateddata.nisabpaidtocentralamount 
            AS 
         BaitulMalFinanceGeneratedNisabPaidToCentralAmount, 
         dbo.baitulmalfinancegenerateddata.nisabpaidtocentralcurrency 
            AS 
         BaitulMalFinanceGeneratedNisabPaidToCentralCurrency, 
         dbo.baitulmalfinancegenerateddata.othersourceaction 
            AS 
         BaitulMalFinanceGeneratedOtherSourceAction, 
         dbo.baitulmalfinancegenerateddata.othersourceincreasetargetamount 
            AS 
         BaitulMalFinanceGeneratedOtherSourceIncreaseTargetAmount, 
         dbo.baitulmalfinancegenerateddata.othersourceincreasetargetcurrency 
            AS 
         BaitulMalFinanceGeneratedOtherSourceIncreaseTargetCurrency, 
         dbo.baitulmalfinancegenerateddata.workerpromisedecreasedamount 
            AS 
         BaitulMalFinanceGeneratedWorkerPromiseDecreasedAmount, 
         dbo.baitulmalfinancegenerateddata.workerpromisedecreasedcurrency 
            AS 
         BaitulMalFinanceGeneratedWorkerPromiseDecreasedCurrency, 
         dbo.baitulmalfinancegenerateddata.workerpromiseincreasedamount 
            AS 
         BaitulMalFinanceGeneratedWorkerPromiseIncreasedAmount, 
         dbo.baitulmalfinancegenerateddata.workerpromiseincreasedcurrency 
            AS 
         BaitulMalFinanceGeneratedWorkerPromiseIncreasedCurrency, 
         dbo.baitulmalfinancegenerateddata.workerpromiseincreasetargetamount 
            AS 
         BaitulMalFinanceGeneratedWorkerPromiseIncreaseTargetAmount, 
         dbo.baitulmalfinancegenerateddata.workerpromiseincreasetargetcurrency 
            AS 
         BaitulMalFinanceGeneratedWorkerPromiseIncreaseTargetCurrency, 
         dbo.baitulmalfinancegenerateddata.workerpromiselastperiodamount 
            AS 
         BaitulMalFinanceGeneratedWorkerPromiseLastPeriodAmount, 
         dbo.baitulmalfinancegenerateddata.workerpromiselastperiodcurrency 
            AS 
         BaitulMalFinanceGeneratedWorkerPromiseLastPeriodCurrency, 
         dbo.qardehasanasocialwelfaredata.actual 
            AS QardeHasanaSocialWelfareActual, 
         dbo.qardehasanasocialwelfaredata.comment 
            AS QardeHasanaSocialWelfareComment, 
         dbo.qardehasanasocialwelfaredata.dateandaction 
            AS 
         QardeHasanaSocialWelfareDateAndAction, 
         dbo.qardehasanasocialwelfaredata.target 
            AS QardeHasanaSocialWelfareTarget, 
         dbo.qardehasanasocialwelfaregenerateddata.actual 
            AS 
         QardeHasanaSocialWelfareGeneratedActual, 
         dbo.qardehasanasocialwelfaregenerateddata.comment 
            AS 
         QardeHasanaSocialWelfareGeneratedComment, 
         dbo.qardehasanasocialwelfaregenerateddata.dateandaction 
            AS 
         QardeHasanaSocialWelfareGeneratedDateAndAction, 
         dbo.qardehasanasocialwelfaregenerateddata.target 
            AS 
         QardeHasanaSocialWelfareGeneratedTarget, 
         dbo.patientvisitsocialwelfaredata.actual 
            AS PatientVisitSocialWelfareActual, 
         dbo.patientvisitsocialwelfaredata.comment 
            AS PatientVisitSocialWelfareComment, 
         dbo.patientvisitsocialwelfaredata.dateandaction 
            AS 
         PatientVisitSocialWelfareDateAndAction, 
         dbo.patientvisitsocialwelfaredata.target 
            AS PatientVisitSocialWelfareTarget, 
         dbo.patientvisitsocialwelfaregenerateddata.actual 
            AS 
         PatientVisitSocialWelfareGeneratedActual, 
         dbo.patientvisitsocialwelfaregenerateddata.comment 
            AS 
         PatientVisitSocialWelfareGeneratedComment, 
         dbo.patientvisitsocialwelfaregenerateddata.dateandaction 
            AS 
         PatientVisitSocialWelfareGeneratedDateAndAction, 
         dbo.patientvisitsocialwelfaregenerateddata.target 
            AS 
         PatientVisitSocialWelfareGeneratedTarget, 
         dbo.socialvisitsocialwelfaredata.actual 
            AS SocialVisitSocialWelfareActual, 
         dbo.socialvisitsocialwelfaredata.comment 
            AS SocialVisitSocialWelfareComment, 
         dbo.socialvisitsocialwelfaredata.dateandaction 
            AS 
         SocialVisitSocialWelfareDateAndAction, 
         dbo.socialvisitsocialwelfaredata.target 
            AS SocialVisitSocialWelfareTarget, 
         dbo.socialvisitsocialwelfaregenerateddata.actual 
            AS 
         SocialVisitSocialWelfareGeneratedActual, 
         dbo.socialvisitsocialwelfaregenerateddata.comment 
            AS 
         SocialVisitSocialWelfareGeneratedComment, 
         dbo.socialvisitsocialwelfaregenerateddata.dateandaction 
            AS 
         SocialVisitSocialWelfareGeneratedDateAndAction, 
         dbo.socialvisitsocialwelfaregenerateddata.target 
            AS 
         SocialVisitSocialWelfareGeneratedTarget, 
         dbo.transportsocialwelfaredata.actual 
            AS TransportSocialWelfareActual, 
         dbo.transportsocialwelfaredata.comment 
            AS TransportSocialWelfareComment, 
         dbo.transportsocialwelfaredata.dateandaction 
            AS 
         TransportSocialWelfareDateAndAction, 
         dbo.transportsocialwelfaredata.target 
            AS TransportSocialWelfareTarget, 
         dbo.transportsocialwelfaregenerateddata.actual 
            AS 
         TransportSocialWelfareGeneratedActual, 
         dbo.transportsocialwelfaregenerateddata.comment 
            AS 
         TransportSocialWelfareGeneratedComment, 
         dbo.transportsocialwelfaregenerateddata.dateandaction 
            AS 
         TransportSocialWelfareGeneratedDateAndAction, 
         dbo.transportsocialwelfaregenerateddata.target 
            AS 
         TransportSocialWelfareGeneratedTarget, 
         dbo.shiftingsocialwelfaredata.actual 
            AS ShiftingSocialWelfareActual, 
         dbo.shiftingsocialwelfaredata.comment 
            AS ShiftingSocialWelfareComment, 
         dbo.shiftingsocialwelfaredata.dateandaction 
            AS 
         ShiftingSocialWelfareDateAndAction, 
         dbo.shiftingsocialwelfaredata.target 
            AS ShiftingSocialWelfareTarget, 
         dbo.shiftingsocialwelfaregenerateddata.actual 
            AS 
         ShiftingSocialWelfareGeneratedActual, 
         dbo.shiftingsocialwelfaregenerateddata.comment 
            AS 
         ShiftingSocialWelfareGeneratedComment, 
         dbo.shiftingsocialwelfaregenerateddata.dateandaction 
            AS 
         ShiftingSocialWelfareGeneratedDateAndAction, 
         dbo.shiftingsocialwelfaregenerateddata.target 
            AS 
         ShiftingSocialWelfareGeneratedTarget, 
         dbo.shoppingsocialwelfaredata.actual 
            AS ShoppingSocialWelfareActual, 
         dbo.shoppingsocialwelfaredata.comment 
            AS ShoppingSocialWelfareComment, 
         dbo.shoppingsocialwelfaredata.dateandaction 
            AS 
         ShoppingSocialWelfareDateAndAction, 
         dbo.shoppingsocialwelfaredata.target 
            AS ShoppingSocialWelfareTarget, 
         dbo.shoppingsocialwelfaregenerateddata.actual 
            AS 
         ShoppingSocialWelfareGeneratedActual, 
         dbo.shoppingsocialwelfaregenerateddata.comment 
            AS 
         ShoppingSocialWelfareGeneratedComment, 
         dbo.shoppingsocialwelfaregenerateddata.dateandaction 
            AS 
         ShoppingSocialWelfareGeneratedDateAndAction, 
         dbo.shoppingsocialwelfaregenerateddata.target 
            AS 
         ShoppingSocialWelfareGeneratedTarget, 
         dbo.booksalematerialdata.actual 
            AS BookSaleMaterialActual, 
         dbo.booksalematerialdata.comment 
            AS BookSaleMaterialComment, 
         dbo.booksalematerialdata.dateandaction 
            AS BookSaleMaterialDateAndAction, 
         dbo.booksalematerialdata.target 
            AS BookSaleMaterialTarget, 
         dbo.booksalematerialgenerateddata.actual 
            AS BookSaleMaterialGeneratedActual, 
         dbo.booksalematerialgenerateddata.comment 
            AS BookSaleMaterialGeneratedComment, 
         dbo.booksalematerialgenerateddata.dateandaction 
            AS 
         BookSaleMaterialGeneratedDateAndAction, 
         dbo.booksalematerialgenerateddata.target 
            AS BookSaleMaterialGeneratedTarget, 
         dbo.bookdistributionmaterialdata.actual 
            AS BookDistributionMaterialActual, 
         dbo.bookdistributionmaterialdata.comment 
            AS BookDistributionMaterialComment, 
         dbo.bookdistributionmaterialdata.dateandaction 
            AS 
         BookDistributionMaterialDateAndAction, 
         dbo.bookdistributionmaterialdata.target 
            AS BookDistributionMaterialTarget, 
         dbo.bookdistributionmaterialgenerateddata.actual 
            AS 
         BookDistributionMaterialGeneratedActual, 
         dbo.bookdistributionmaterialgenerateddata.comment 
            AS 
         BookDistributionMaterialGeneratedComment, 
         dbo.bookdistributionmaterialgenerateddata.dateandaction 
            AS 
         BookDistributionMaterialGeneratedDateAndAction, 
         dbo.bookdistributionmaterialgenerateddata.target 
            AS 
         BookDistributionMaterialGeneratedTarget, 
         dbo.vhssalematerialdata.actual 
            AS VhsSaleMaterialActual, 
         dbo.vhssalematerialdata.comment 
            AS VhsSaleMaterialComment, 
         dbo.vhssalematerialdata.dateandaction 
            AS VhsSaleMaterialDateAndAction, 
         dbo.vhssalematerialdata.target 
            AS VhsSaleMaterialTarget, 
         dbo.vhssalematerialgenerateddata.actual 
            AS VhsSaleMaterialGeneratedActual, 
         dbo.vhssalematerialgenerateddata.comment 
            AS VhsSaleMaterialGeneratedComment, 
         dbo.vhssalematerialgenerateddata.dateandaction 
            AS 
         VhsSaleMaterialGeneratedDateAndAction, 
         dbo.vhssalematerialgenerateddata.target 
            AS VhsSaleMaterialGeneratedTarget, 
         dbo.vhsdistributionmaterialdata.actual 
            AS VhsDistributionMaterialActual, 
         dbo.vhsdistributionmaterialdata.comment 
            AS VhsDistributionMaterialComment, 
         dbo.vhsdistributionmaterialdata.dateandaction 
            AS 
         VhsDistributionMaterialDateAndAction, 
         dbo.vhsdistributionmaterialdata.target 
            AS VhsDistributionMaterialTarget, 
         dbo.vhsdistributionmaterialgenerateddata.actual 
            AS 
         VhsDistributionMaterialGeneratedActual, 
         dbo.vhsdistributionmaterialgenerateddata.comment 
            AS 
         VhsDistributionMaterialGeneratedComment, 
         dbo.vhsdistributionmaterialgenerateddata.dateandaction 
            AS 
         VhsDistributionMaterialGeneratedDateAndAction, 
         dbo.vhsdistributionmaterialgenerateddata.target 
            AS 
         VhsDistributionMaterialGeneratedTarget, 
         dbo.emaildistributionmaterialdata.actual 
            AS EmailDistributionMaterialActual, 
         dbo.emaildistributionmaterialdata.comment 
            AS EmailDistributionMaterialComment, 
         dbo.emaildistributionmaterialdata.dateandaction 
            AS 
         EmailDistributionMaterialDateAndAction, 
         dbo.emaildistributionmaterialdata.target 
            AS EmailDistributionMaterialTarget, 
         dbo.emaildistributionmaterialgenerateddata.actual 
            AS 
         EmailDistributionMaterialGeneratedActual, 
         dbo.emaildistributionmaterialgenerateddata.comment 
            AS 
         EmailDistributionMaterialGeneratedComment, 
         dbo.emaildistributionmaterialgenerateddata.dateandaction 
            AS 
         EmailDistributionMaterialGeneratedDateAndAction, 
         dbo.emaildistributionmaterialgenerateddata.target 
            AS 
         EmailDistributionMaterialGeneratedTarget, 
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
         dbo.ipdcleafletdistributionmaterialgenerateddata.actual 
            AS 
         IpdcLeafletDistributionMaterialGeneratedActual, 
         dbo.ipdcleafletdistributionmaterialgenerateddata.comment 
            AS 
         IpdcLeafletDistributionMaterialGeneratedComment, 
         dbo.ipdcleafletdistributionmaterialgenerateddata.dateandaction 
            AS 
         IpdcLeafletDistributionMaterialGeneratedDateAndAction, 
         dbo.ipdcleafletdistributionmaterialgenerateddata.target 
            AS 
         IpdcLeafletDistributionMaterialGeneratedTarget, 
         dbo.booklibrarystockdata.comment 
            AS BookLibraryStockComment, 
         dbo.booklibrarystockdata.decreased 
            AS BookLibraryStockDecreased, 
         dbo.booklibrarystockdata.increased 
            AS BookLibraryStockIncreased, 
         dbo.booklibrarystockdata.lastperiod 
            AS BookLibraryStockLastPeriod, 
         dbo.booklibrarystockgenerateddata.comment 
            AS BookLibraryStockGeneratedComment, 
         dbo.booklibrarystockgenerateddata.decreased 
            AS 
         BookLibraryStockGeneratedDecreased, 
         dbo.booklibrarystockgenerateddata.increased 
            AS 
         BookLibraryStockGeneratedIncreased, 
         dbo.booklibrarystockgenerateddata.lastperiod 
            AS 
         BookLibraryStockGeneratedLastPeriod, 
         dbo.vhslibrarystockdata.comment 
            AS VhsLibraryStockComment, 
         dbo.vhslibrarystockdata.decreased 
            AS VhsLibraryStockDecreased, 
         dbo.vhslibrarystockdata.increased 
            AS VhsLibraryStockIncreased, 
         dbo.vhslibrarystockdata.lastperiod 
            AS VhsLibraryStockLastPeriod, 
         dbo.vhslibrarystockgenerateddata.comment 
            AS VhsLibraryStockGeneratedComment, 
         dbo.vhslibrarystockgenerateddata.decreased 
            AS VhsLibraryStockGeneratedDecreased, 
         dbo.vhslibrarystockgenerateddata.increased 
            AS VhsLibraryStockGeneratedIncreased, 
         dbo.vhslibrarystockgenerateddata.lastperiod 
            AS 
         VhsLibraryStockGeneratedLastPeriod, 
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
         dbo.groupstudyteachinglearningprogramgenerateddata.actual 
            AS 
         GroupStudyTeachingLearningProgramGeneratedActual, 
         dbo.groupstudyteachinglearningprogramgenerateddata.averageattendance 
            AS 
         GroupStudyTeachingLearningProgramGeneratedAverageAttendance, 
         dbo.groupstudyteachinglearningprogramgenerateddata.comment 
            AS 
         GroupStudyTeachingLearningProgramGeneratedComment, 
         dbo.groupstudyteachinglearningprogramgenerateddata.dateandaction 
            AS 
         GroupStudyTeachingLearningProgramGeneratedDateAndAction, 
         dbo.groupstudyteachinglearningprogramgenerateddata.target 
            AS 
         GroupStudyTeachingLearningProgramGeneratedTarget, 
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
         dbo.studycircleteachinglearningprogramgenerateddata.actual 
            AS 
         StudyCircleTeachingLearningProgramGeneratedActual, 
         dbo.studycircleteachinglearningprogramgenerateddata.averageattendance 
            AS 
         StudyCircleTeachingLearningProgramGeneratedAverageAttendance, 
         dbo.studycircleteachinglearningprogramgenerateddata.comment 
            AS 
         StudyCircleTeachingLearningProgramGeneratedComment, 
         dbo.studycircleteachinglearningprogramgenerateddata.dateandaction 
            AS 
         StudyCircleTeachingLearningProgramGeneratedDateAndAction, 
         dbo.studycircleteachinglearningprogramgenerateddata.target 
            AS 
         StudyCircleTeachingLearningProgramGeneratedTarget, 
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
         dbo.practicedarsteachinglearningprogramgenerateddata.actual 
            AS 
         PracticeDarsTeachingLearningProgramGeneratedActual, 
         dbo.practicedarsteachinglearningprogramgenerateddata.averageattendance 
            AS 
         PracticeDarsTeachingLearningProgramGeneratedAverageAttendance, 
         dbo.practicedarsteachinglearningprogramgenerateddata.comment 
            AS 
         PracticeDarsTeachingLearningProgramGeneratedComment, 
         dbo.practicedarsteachinglearningprogramgenerateddata.dateandaction 
            AS 
         PracticeDarsTeachingLearningProgramGeneratedDateAndAction, 
         dbo.practicedarsteachinglearningprogramgenerateddata.target 
            AS 
         PracticeDarsTeachingLearningProgramGeneratedTarget,          
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
         dbo.statelearningcampteachinglearningprogramgenerateddata.actual 
            AS 
         StateLearningCampTeachingLearningProgramGeneratedActual, 
  dbo.statelearningcampteachinglearningprogramgenerateddata.averageattendance 
  AS 
  StateLearningCampTeachingLearningProgramGeneratedAverageAttendance, 
  dbo.statelearningcampteachinglearningprogramgenerateddata.comment 
  AS 
         StateLearningCampTeachingLearningProgramGeneratedComment, 
         dbo.statelearningcampteachinglearningprogramgenerateddata.dateandaction 
  AS 
         StateLearningCampTeachingLearningProgramGeneratedDateAndAction, 
         dbo.statelearningcampteachinglearningprogramgenerateddata.target 
  AS 
         StateLearningCampTeachingLearningProgramGeneratedTarget, 
         dbo.organization.description 
  AS OrganizaDescription, 
         dbo.organization.isdeleted 
  AS OrganizaIsDeleted, 
         dbo.organization.organizationtype 
  AS OrganizaOrganizationType, 
         dbo.organization.parentdescription 
  AS OrganizaParentDescription, 
         dbo.organization.reportingfrequency 
  AS OrganizaReportingFrequency, 
         dbo.organization.timestamp 
  AS OrganizaTimestamp, 
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
         dbo.quranstudyteachinglearningprogramgenerateddata.actual 
  AS 
         QuranStudyTeachingLearningProgramGeneratedActual, 
         dbo.quranstudyteachinglearningprogramgenerateddata.averageattendance 
  AS 
         QuranStudyTeachingLearningProgramGeneratedAverageAttendance, 
         dbo.quranstudyteachinglearningprogramgenerateddata.comment 
  AS 
         QuranStudyTeachingLearningProgramGeneratedComment, 
         dbo.quranstudyteachinglearningprogramgenerateddata.dateandaction 
  AS 
         QuranStudyTeachingLearningProgramGeneratedDateAndAction, 
         dbo.quranstudyteachinglearningprogramgenerateddata.target 
  AS 
         QuranStudyTeachingLearningProgramGeneratedTarget, 
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
         dbo.quranclassteachinglearningprogramgenerateddata.actual 
  AS 
         QuranClassTeachingLearningProgramGeneratedActual, 
         dbo.quranclassteachinglearningprogramgenerateddata.averageattendance 
  AS 
         QuranClassTeachingLearningProgramGeneratedAverageAttendance, 
         dbo.quranclassteachinglearningprogramgenerateddata.comment 
  AS 
         QuranClassTeachingLearningProgramGeneratedComment, 
         dbo.quranclassteachinglearningprogramgenerateddata.dateandaction 
  AS 
         QuranClassTeachingLearningProgramGeneratedDateAndAction, 
         dbo.quranclassteachinglearningprogramgenerateddata.target 
  AS 
         QuranClassTeachingLearningProgramGeneratedTarget, 
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
         dbo.memorizingayatteachinglearningprogramgenerateddata.actual 
  AS 
         MemorizingAyatTeachingLearningProgramGeneratedActual, 
  dbo.memorizingayatteachinglearningprogramgenerateddata.averageattendance 
  AS 
         MemorizingAyatTeachingLearningProgramGeneratedAverageAttendance, 
         dbo.memorizingayatteachinglearningprogramgenerateddata.comment 
  AS 
         MemorizingAyatTeachingLearningProgramGeneratedComment, 
         dbo.memorizingayatteachinglearningprogramgenerateddata.dateandaction 
  AS 
         MemorizingAyatTeachingLearningProgramGeneratedDateAndAction, 
         dbo.memorizingayatteachinglearningprogramgenerateddata.target 
  AS 
         MemorizingAyatTeachingLearningProgramGeneratedTarget, 
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
         dbo.statelearningsessionteachinglearningprogramgenerateddata.actual 
  AS 
         StateLearningSessionTeachingLearningProgramGeneratedActual, 
  dbo.statelearningsessionteachinglearningprogramgenerateddata.averageattendance 
  AS 
  StateLearningSessionTeachingLearningProgramGeneratedAverageAttendance, 
  dbo.statelearningsessionteachinglearningprogramgenerateddata.comment 
  AS 
  StateLearningSessionTeachingLearningProgramGeneratedComment, 
  dbo.statelearningsessionteachinglearningprogramgenerateddata.dateandaction 
  AS 
  StateLearningSessionTeachingLearningProgramGeneratedDateAndAction, 
  dbo.statelearningsessionteachinglearningprogramgenerateddata.target 
  AS 
  StateLearningSessionTeachingLearningProgramGeneratedTarget, 
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
  dbo.stateqiyamullailteachinglearningprogramgenerateddata.actual 
  AS 
  StateQiyamulLailTeachingLearningProgramGeneratedActual, 
  dbo.stateqiyamullailteachinglearningprogramgenerateddata.averageattendance 
  AS 
  StateQiyamulLailTeachingLearningProgramGeneratedAverageAttendance, 
  dbo.stateqiyamullailteachinglearningprogramgenerateddata.comment 
  AS 
  StateQiyamulLailTeachingLearningProgramGeneratedComment, 
  dbo.stateqiyamullailteachinglearningprogramgenerateddata.dateandaction 
  AS 
  StateQiyamulLailTeachingLearningProgramGeneratedDateAndAction, 
  dbo.stateqiyamullailteachinglearningprogramgenerateddata.target 
  AS 
  StateQiyamulLailTeachingLearningProgramGeneratedTarget, 
  dbo.supportermembergenerateddata.action 
  AS 
  SupporterMemberGeneratedAction, 
  dbo.supportermembergenerateddata.comment 
  AS 
  SupporterMemberGeneratedComment, 
  dbo.supportermembergenerateddata.decreased 
  AS 
  SupporterMemberGeneratedDecreased, 
  dbo.supportermembergenerateddata.increased 
  AS 
  SupporterMemberGeneratedIncreased, 
  dbo.supportermembergenerateddata.lastperiod 
  AS 
  SupporterMemberGeneratedLastPeriod, 
  dbo.supportermembergenerateddata.nameandcontactnumber 
  AS 
  SupporterMemberGeneratedNameAndContactNumber, 
  dbo.supportermembergenerateddata.personalcontact 
  AS 
  SupporterMemberGeneratedPersonalContact, 
  dbo.supportermembergenerateddata.upgradetarget 
  AS 
  SupporterMemberGeneratedUpgradeTarget, 
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
  dbo.adaymasjidprojectfinancegenerateddata.action 
  AS 
  ADayMasjidProjectFinanceGeneratedAction, 
  dbo.adaymasjidprojectfinancegenerateddata.collectionamount 
  AS 
  ADayMasjidProjectFinanceGeneratedCollectionAmount, 
  dbo.adaymasjidprojectfinancegenerateddata.collectioncurrency 
  AS 
  ADayMasjidProjectFinanceGeneratedCollectionCurrency, 
  dbo.adaymasjidprojectfinancegenerateddata.comment 
  AS 
  ADayMasjidProjectFinanceGeneratedComment, 
  dbo.adaymasjidprojectfinancegenerateddata.expenseamount 
  AS 
  ADayMasjidProjectFinanceGeneratedExpenseAmount, 
  dbo.adaymasjidprojectfinancegenerateddata.expensecurrency 
  AS 
  ADayMasjidProjectFinanceGeneratedExpenseCurrency, 
  dbo.adaymasjidprojectfinancegenerateddata.nisabpaidtocentralamount 
  AS 
  ADayMasjidProjectFinanceGeneratedNisabPaidToCentralAmount, 
  dbo.adaymasjidprojectfinancegenerateddata.nisabpaidtocentralcurrency 
  AS 
  ADayMasjidProjectFinanceGeneratedNisabPaidToCentralCurrency, 
  dbo.adaymasjidprojectfinancegenerateddata.othersourceaction 
  AS 
  ADayMasjidProjectFinanceGeneratedOtherSourceAction, 
  dbo.adaymasjidprojectfinancegenerateddata.othersourceincreasetargetamount 
  AS 
  ADayMasjidProjectFinanceGeneratedOtherSourceIncreaseTargetAmount, 
  dbo.adaymasjidprojectfinancegenerateddata.othersourceincreasetargetcurrency 
  AS 
  ADayMasjidProjectFinanceGeneratedOtherSourceIncreaseTargetCurrency, 
  dbo.adaymasjidprojectfinancegenerateddata.workerpromisedecreasedamount 
  AS 
  ADayMasjidProjectFinanceGeneratedWorkerPromiseDecreasedAmount, 
  dbo.adaymasjidprojectfinancegenerateddata.workerpromisedecreasedcurrency 
  AS 
  ADayMasjidProjectFinanceGeneratedWorkerPromiseDecreasedCurrency, 
  dbo.adaymasjidprojectfinancegenerateddata.workerpromiseincreasedamount 
  AS 
  ADayMasjidProjectFinanceGeneratedWorkerPromiseIncreasedAmount, 
  dbo.adaymasjidprojectfinancegenerateddata.workerpromiseincreasedcurrency 
  AS 
  ADayMasjidProjectFinanceGeneratedWorkerPromiseIncreasedCurrency, 
  dbo.adaymasjidprojectfinancegenerateddata.workerpromiseincreasetargetamount 
  AS 
  ADayMasjidProjectFinanceGeneratedWorkerPromiseIncreaseTargetAmount, 
  dbo.adaymasjidprojectfinancegenerateddata.workerpromiseincreasetargetcurrency 
  AS 
  ADayMasjidProjectFinanceGeneratedWorkerPromiseIncreaseTargetCurrency, 
  dbo.adaymasjidprojectfinancegenerateddata.workerpromiselastperiodamount 
  AS 
  ADayMasjidProjectFinanceGeneratedWorkerPromiseLastPeriodAmount, 
  dbo.adaymasjidprojectfinancegenerateddata.workerpromiselastperiodcurrency 
  AS 
  ADayMasjidProjectFinanceGeneratedWorkerPromiseLastPeriodCurrency, 
  dbo.dawahmeetinggenerateddata.actual 
  AS 
  DawahMeetingGeneratedActual, 
  dbo.dawahmeetinggenerateddata.averageattendance 
  AS 
  DawahMeetingGeneratedAverageAttendance, 
  dbo.dawahmeetinggenerateddata.comment 
  AS 
  DawahMeetingGeneratedComment, 
  dbo.dawahmeetinggenerateddata.dateandaction 
  AS 
  DawahMeetingGeneratedDateAndAction, 
  dbo.dawahmeetinggenerateddata.target 
  AS 
  DawahMeetingGeneratedTarget, 
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
  LearningMeetingTarget, 
  dbo.masjidtablebankfinancegenerateddata.action 
  AS 
  MasjidTableBankFinanceGeneratedAction, 
  dbo.masjidtablebankfinancegenerateddata.collectionamount 
  AS 
  MasjidTableBankFinanceGeneratedCollectionAmount, 
  dbo.masjidtablebankfinancegenerateddata.collectioncurrency 
  AS 
  MasjidTableBankFinanceGeneratedCollectionCurrency, 
  dbo.masjidtablebankfinancegenerateddata.comment 
  AS 
  MasjidTableBankFinanceGeneratedComment, 
  dbo.masjidtablebankfinancegenerateddata.expenseamount 
  AS 
  MasjidTableBankFinanceGeneratedExpenseAmount, 
  dbo.masjidtablebankfinancegenerateddata.expensecurrency 
  AS 
  MasjidTableBankFinanceGeneratedExpenseCurrency, 
  dbo.masjidtablebankfinancegenerateddata.nisabpaidtocentralamount 
  AS 
  MasjidTableBankFinanceGeneratedNisabPaidToCentralAmount, 
  dbo.masjidtablebankfinancegenerateddata.nisabpaidtocentralcurrency 
  AS 
  MasjidTableBankFinanceGeneratedNisabPaidToCentralCurrency, 
  dbo.masjidtablebankfinancegenerateddata.othersourceaction 
  AS 
  MasjidTableBankFinanceGeneratedOtherSourceAction, 
  dbo.masjidtablebankfinancegenerateddata.othersourceincreasetargetamount 
  AS 
  MasjidTableBankFinanceGeneratedOtherSourceIncreaseTargetAmount, 
  dbo.masjidtablebankfinancegenerateddata.othersourceincreasetargetcurrency 
  AS 
  MasjidTableBankFinanceGeneratedOtherSourceIncreaseTargetCurrency, 
  dbo.masjidtablebankfinancegenerateddata.workerpromisedecreasedamount 
  AS 
  MasjidTableBankFinanceGeneratedWorkerPromiseDecreasedAmount, 
  dbo.masjidtablebankfinancegenerateddata.workerpromisedecreasedcurrency 
  AS 
  MasjidTableBankFinanceGeneratedWorkerPromiseDecreasedCurrency, 
  dbo.masjidtablebankfinancegenerateddata.workerpromiseincreasedamount 
  AS 
  MasjidTableBankFinanceGeneratedWorkerPromiseIncreasedAmount, 
  dbo.masjidtablebankfinancegenerateddata.workerpromiseincreasedcurrency 
  AS 
  MasjidTableBankFinanceGeneratedWorkerPromiseIncreasedCurrency, 
  dbo.masjidtablebankfinancegenerateddata.workerpromiseincreasetargetamount 
  AS 
  MasjidTableBankFinanceGeneratedWorkerPromiseIncreaseTargetAmount, 
  dbo.masjidtablebankfinancegenerateddata.workerpromiseincreasetargetcurrency 
  AS 
  MasjidTableBankFinanceGeneratedWorkerPromiseIncreaseTargetCurrency, 
  dbo.masjidtablebankfinancegenerateddata.workerpromiselastperiodamount 
  AS 
  MasjidTableBankFinanceGeneratedWorkerPromiseLastPeriodAmount, 
  dbo.masjidtablebankfinancegenerateddata.workerpromiselastperiodcurrency 
  AS 
  MasjidTableBankFinanceGeneratedWorkerPromiseLastPeriodCurrency, 
  dbo.learningmeetinggenerateddata.actual 
  AS 
  LearningMeetingGeneratedActual, 
  dbo.learningmeetinggenerateddata.averageattendance 
  AS 
  LearningMeetingGeneratedAverageAttendance, 
  dbo.learningmeetinggenerateddata.comment 
  AS 
  LearningMeetingGeneratedComment, 
  dbo.learningmeetinggenerateddata.dateandaction 
  AS 
  LearningMeetingGeneratedDateAndAction, 
  dbo.learningmeetinggenerateddata.target 
  AS 
  LearningMeetingGeneratedTarget 
  FROM   dbo.report 
         INNER JOIN dbo.organization 
                 ON dbo.report.organizationid = dbo.organization.id 
         INNER JOIN dbo.associatememberdata 
                 ON dbo.report.id = dbo.associatememberdata.reportid 
         INNER JOIN dbo.associatemembergenerateddata 
                 ON dbo.report.id = dbo.associatemembergenerateddata.reportid 
         INNER JOIN dbo.preliminarymemberdata 
                 ON dbo.report.id = dbo.preliminarymemberdata.reportid 
         INNER JOIN dbo.preliminarymembergenerateddata 
                 ON dbo.report.id = dbo.preliminarymembergenerateddata.reportid 
         INNER JOIN dbo.workermeetingdata 
                 ON dbo.report.id = dbo.workermeetingdata.reportid 
         INNER JOIN dbo.workermeetinggenerateddata 
                 ON dbo.report.id = dbo.workermeetinggenerateddata.reportid 
         INNER JOIN dbo.stateleadermeetingdata 
                 ON dbo.report.id = dbo.stateleadermeetingdata.reportid 
         INNER JOIN dbo.stateleadermeetinggenerateddata 
                 ON dbo.report.id = dbo.stateleadermeetinggenerateddata.reportid 
         INNER JOIN dbo.stateoutingmeetingdata 
                 ON dbo.report.id = dbo.stateoutingmeetingdata.reportid 
         INNER JOIN dbo.stateoutingmeetinggenerateddata 
                 ON dbo.report.id = dbo.stateoutingmeetinggenerateddata.reportid 
         INNER JOIN dbo.iftarmeetingdata 
                 ON dbo.report.id = dbo.iftarmeetingdata.reportid 
         INNER JOIN dbo.iftarmeetinggenerateddata 
                 ON dbo.report.id = dbo.iftarmeetinggenerateddata.reportid 
         INNER JOIN dbo.socialdawahmeetingdata 
                 ON dbo.report.id = dbo.socialdawahmeetingdata.reportid 
         INNER JOIN dbo.socialdawahmeetinggenerateddata 
                 ON dbo.report.id = dbo.socialdawahmeetinggenerateddata.reportid 
         INNER JOIN dbo.dawahgroupmeetingdata 
                 ON dbo.report.id = dbo.dawahgroupmeetingdata.reportid 
         INNER JOIN dbo.dawahgroupmeetinggenerateddata 
                 ON dbo.report.id = dbo.dawahgroupmeetinggenerateddata.reportid 
         INNER JOIN dbo.nextgmeetingdata 
                 ON dbo.report.id = dbo.nextgmeetingdata.reportid 
         INNER JOIN dbo.nextgmeetinggenerateddata 
                 ON dbo.report.id = dbo.nextgmeetinggenerateddata.reportid 
         INNER JOIN dbo.membermemberdata 
                 ON dbo.report.id = dbo.membermemberdata.reportid 
         INNER JOIN dbo.membermembergenerateddata 
                 ON dbo.report.id = dbo.membermembergenerateddata.reportid 
         INNER JOIN dbo.baitulmalfinancedata 
                 ON dbo.report.id = dbo.baitulmalfinancedata.reportid 
         INNER JOIN dbo.baitulmalfinancegenerateddata 
                 ON dbo.report.id = dbo.baitulmalfinancegenerateddata.reportid 
         INNER JOIN dbo.qardehasanasocialwelfaredata 
                 ON dbo.report.id = dbo.qardehasanasocialwelfaredata.reportid 
         INNER JOIN dbo.qardehasanasocialwelfaregenerateddata 
                 ON dbo.report.id = dbo.qardehasanasocialwelfaregenerateddata.reportid 
         INNER JOIN dbo.patientvisitsocialwelfaredata 
                 ON dbo.report.id = dbo.patientvisitsocialwelfaredata.reportid 
         INNER JOIN dbo.patientvisitsocialwelfaregenerateddata 
                 ON dbo.report.id = 
                    dbo.patientvisitsocialwelfaregenerateddata.reportid 
         INNER JOIN dbo.socialvisitsocialwelfaredata 
                 ON dbo.report.id = dbo.socialvisitsocialwelfaredata.reportid 
         INNER JOIN dbo.socialvisitsocialwelfaregenerateddata 
                 ON dbo.report.id = dbo.socialvisitsocialwelfaregenerateddata.reportid 
         INNER JOIN dbo.transportsocialwelfaredata 
                 ON dbo.report.id = dbo.transportsocialwelfaredata.reportid 
         INNER JOIN dbo.transportsocialwelfaregenerateddata 
                 ON dbo.report.id = dbo.transportsocialwelfaregenerateddata.reportid 
         INNER JOIN dbo.shiftingsocialwelfaredata 
                 ON dbo.report.id = dbo.shiftingsocialwelfaredata.reportid 
         INNER JOIN dbo.shiftingsocialwelfaregenerateddata 
                 ON dbo.report.id = dbo.shiftingsocialwelfaregenerateddata.reportid 
         INNER JOIN dbo.shoppingsocialwelfaredata 
                 ON dbo.report.id = dbo.shoppingsocialwelfaredata.reportid 
         INNER JOIN dbo.shoppingsocialwelfaregenerateddata 
                 ON dbo.report.id = dbo.shoppingsocialwelfaregenerateddata.reportid 
         INNER JOIN dbo.booksalematerialdata 
                 ON dbo.report.id = dbo.booksalematerialdata.reportid 
         INNER JOIN dbo.booksalematerialgenerateddata 
                 ON dbo.report.id = dbo.booksalematerialgenerateddata.reportid 
         INNER JOIN dbo.bookdistributionmaterialdata 
                 ON dbo.report.id = dbo.bookdistributionmaterialdata.reportid 
         INNER JOIN dbo.bookdistributionmaterialgenerateddata 
                 ON dbo.report.id = dbo.bookdistributionmaterialgenerateddata.reportid 
         INNER JOIN dbo.vhssalematerialdata 
                 ON dbo.report.id = dbo.vhssalematerialdata.reportid 
         INNER JOIN dbo.vhssalematerialgenerateddata 
                 ON dbo.report.id = dbo.vhssalematerialgenerateddata.reportid 
         INNER JOIN dbo.vhsdistributionmaterialdata 
                 ON dbo.report.id = dbo.vhsdistributionmaterialdata.reportid 
         INNER JOIN dbo.vhsdistributionmaterialgenerateddata 
                 ON dbo.report.id = dbo.vhsdistributionmaterialgenerateddata.reportid 
         INNER JOIN dbo.emaildistributionmaterialdata 
                 ON dbo.report.id = dbo.emaildistributionmaterialdata.reportid 
         INNER JOIN dbo.emaildistributionmaterialgenerateddata 
                 ON dbo.report.id = 
                    dbo.emaildistributionmaterialgenerateddata.reportid 
         INNER JOIN dbo.ipdcleafletdistributionmaterialdata 
                 ON dbo.report.id = dbo.ipdcleafletdistributionmaterialdata.reportid 
         INNER JOIN dbo.ipdcleafletdistributionmaterialgenerateddata 
                 ON dbo.report.id = 
                    dbo.ipdcleafletdistributionmaterialgenerateddata.reportid 
         INNER JOIN dbo.booklibrarystockdata 
                 ON dbo.report.id = dbo.booklibrarystockdata.reportid 
         INNER JOIN dbo.booklibrarystockgenerateddata 
                 ON dbo.report.id = dbo.booklibrarystockgenerateddata.reportid 
         INNER JOIN dbo.vhslibrarystockdata 
                 ON dbo.report.id = dbo.vhslibrarystockdata.reportid 
         INNER JOIN dbo.vhslibrarystockgenerateddata 
                 ON dbo.report.id = dbo.vhslibrarystockgenerateddata.reportid 
         INNER JOIN dbo.groupstudyteachinglearningprogramdata 
                 ON dbo.report.id = dbo.groupstudyteachinglearningprogramdata.reportid 
         INNER JOIN dbo.groupstudyteachinglearningprogramgenerateddata 
                 ON dbo.report.id = 
                    dbo.groupstudyteachinglearningprogramgenerateddata.reportid 
         INNER JOIN dbo.studycircleteachinglearningprogramdata 
                 ON dbo.report.id = 
                    dbo.studycircleteachinglearningprogramdata.reportid 
         INNER JOIN dbo.studycircleteachinglearningprogramgenerateddata 
                 ON dbo.report.id = 
                    dbo.studycircleteachinglearningprogramgenerateddata.reportid 
         INNER JOIN dbo.practicedarsteachinglearningprogramdata 
                 ON dbo.report.id = 
                    dbo.practicedarsteachinglearningprogramdata.reportid 
         INNER JOIN dbo.practicedarsteachinglearningprogramgenerateddata 
                 ON dbo.report.id = 
                    dbo.practicedarsteachinglearningprogramgenerateddata.reportid          
         INNER JOIN dbo.statelearningcampteachinglearningprogramdata 
                 ON dbo.report.id = 
                    dbo.statelearningcampteachinglearningprogramdata.reportid 
         INNER JOIN dbo.statelearningcampteachinglearningprogramgenerateddata 
                 ON dbo.report.id = 
                    dbo.statelearningcampteachinglearningprogramgenerateddata.reportid 
         INNER JOIN dbo.quranstudyteachinglearningprogramdata 
                 ON dbo.report.id = dbo.quranstudyteachinglearningprogramdata.reportid          
         INNER JOIN dbo.quranstudyteachinglearningprogramgenerateddata 
                 ON dbo.report.id = 
                    dbo.quranstudyteachinglearningprogramgenerateddata.reportid 
         INNER JOIN dbo.quranclassteachinglearningprogramdata 
                 ON dbo.report.id = dbo.quranclassteachinglearningprogramdata.reportid 
         INNER JOIN dbo.quranclassteachinglearningprogramgenerateddata 
                 ON dbo.report.id = 
                    dbo.quranclassteachinglearningprogramgenerateddata.reportid 
         INNER JOIN dbo.memorizingayatteachinglearningprogramdata 
                 ON dbo.report.id = 
                    dbo.memorizingayatteachinglearningprogramdata.reportid 
         INNER JOIN dbo.memorizingayatteachinglearningprogramgenerateddata 
                 ON dbo.report.id = 
                    dbo.memorizingayatteachinglearningprogramgenerateddata.reportid 
         INNER JOIN dbo.statelearningsessionteachinglearningprogramdata 
                 ON dbo.report.id = 
                    dbo.statelearningsessionteachinglearningprogramdata.reportid 
         INNER JOIN dbo.statelearningsessionteachinglearningprogramgenerateddata 
                 ON dbo.report.id = 
  dbo.statelearningsessionteachinglearningprogramgenerateddata.reportid 
  INNER JOIN dbo.stateqiyamullailteachinglearningprogramdata 
  ON dbo.report.id = dbo.stateqiyamullailteachinglearningprogramdata.reportid 
  INNER JOIN dbo.supportermemberdata 
  ON dbo.report.id = dbo.supportermemberdata.reportid 
  INNER JOIN dbo.stateqiyamullailteachinglearningprogramgenerateddata 
  ON dbo.report.id = 
  dbo.stateqiyamullailteachinglearningprogramgenerateddata.reportid 
  INNER JOIN dbo.supportermembergenerateddata 
  ON dbo.report.id = dbo.supportermembergenerateddata.reportid 
  INNER JOIN dbo.adaymasjidprojectfinancedata 
  ON dbo.report.id = dbo.adaymasjidprojectfinancedata.reportid 
  INNER JOIN dbo.dawahmeetingdata 
  ON dbo.report.id = dbo.dawahmeetingdata.reportid 
  INNER JOIN dbo.adaymasjidprojectfinancegenerateddata 
  ON dbo.report.id = dbo.adaymasjidprojectfinancegenerateddata.reportid 
  INNER JOIN dbo.dawahmeetinggenerateddata 
  ON dbo.report.id = dbo.dawahmeetinggenerateddata.reportid 
  INNER JOIN dbo.masjidtablebankfinancedata 
  ON dbo.report.id = dbo.masjidtablebankfinancedata.reportid 
  INNER JOIN dbo.learningmeetingdata 
  ON dbo.report.id = dbo.learningmeetingdata.reportid 
  INNER JOIN dbo.masjidtablebankfinancegenerateddata 
  ON dbo.report.id = dbo.masjidtablebankfinancegenerateddata.reportid 
  INNER JOIN dbo.learningmeetinggenerateddata 
  ON dbo.report.id = dbo.learningmeetinggenerateddata.reportid 
  WHERE  ( dbo.report.isdeleted = 0 ) 
         AND ( dbo.organization.organizationtype = 3 ) 