import { bindable, bindingMode } from "aurelia-framework";
import { TeachingLearningProgramData } from "models/TeachingLearningProgramData";

export class ReportTeachingEdit {
    @bindable({ defaultBindingMode: bindingMode.oneWay }) groupStudyTeachingLearningProgramData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) groupStudyTeachingLearningProgramGeneratedData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) studyCircleForAssociateMemberTeachingLearningProgramData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) studyCircleForAssociateMemberTeachingLearningProgramGeneratedData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) studyCircleTeachingLearningProgramData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) studyCircleTeachingLearningProgramGeneratedData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) practiceDarsTeachingLearningProgramData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) practiceDarsTeachingLearningProgramGeneratedData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) stateLearningCampTeachingLearningProgramData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) stateLearningCampTeachingLearningProgramGeneratedData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) quranStudyTeachingLearningProgramData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) quranStudyTeachingLearningProgramGeneratedData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) hadithTeachingLearningProgramData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) hadithTeachingLearningProgramGeneratedData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) quranClassTeachingLearningProgramData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) quranClassTeachingLearningProgramGeneratedData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) weekendIslamicSchoolTeachingLearningProgramData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) weekendIslamicSchoolTeachingLearningProgramGeneratedData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) memorizingAyatTeachingLearningProgramData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) memorizingAyatTeachingLearningProgramGeneratedData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) memorizingHadithTeachingLearningProgramData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) memorizingHadithTeachingLearningProgramGeneratedData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) memorizingDoaTeachingLearningProgramData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) memorizingDoaTeachingLearningProgramGeneratedData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) stateLearningSessionTeachingLearningProgramData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) stateLearningSessionTeachingLearningProgramGeneratedData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) stateQiyamulLailTeachingLearningProgramData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) stateQiyamulLailTeachingLearningProgramGeneratedData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) otherTeachingLearningProgramData: TeachingLearningProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) otherTeachingLearningProgramGeneratedData: TeachingLearningProgramData;
}