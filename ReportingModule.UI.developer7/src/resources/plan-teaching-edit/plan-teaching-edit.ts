import { bindable, bindingMode } from "aurelia-framework";
import { TeachingLearningProgramPlanData } from "models/TeachingLearningProgramPlanData";

export class PlanTeachingEdit {
    @bindable({ defaultBindingMode: bindingMode.oneWay }) groupStudyTeachingLearningProgramPlanData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) groupStudyTeachingLearningProgramPlanGeneratedData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) studyCircleForAssociateMemberTeachingLearningProgramPlanData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) studyCircleForAssociateMemberTeachingLearningProgramPlanGeneratedData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) studyCircleTeachingLearningProgramPlanData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) studyCircleTeachingLearningProgramPlanGeneratedData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) practiceDarsTeachingLearningProgramPlanData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) practiceDarsTeachingLearningProgramPlanGeneratedData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) stateLearningCampTeachingLearningProgramPlanData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) stateLearningCampTeachingLearningProgramPlanGeneratedData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) quranStudyTeachingLearningProgramPlanData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) quranStudyTeachingLearningProgramPlanGeneratedData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) hadithTeachingLearningProgramPlanData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) hadithTeachingLearningProgramPlanGeneratedData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) quranClassTeachingLearningProgramPlanData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) quranClassTeachingLearningProgramPlanGeneratedData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) weekendIslamicSchoolTeachingLearningProgramPlanData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) weekendIslamicSchoolTeachingLearningProgramPlanGeneratedData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) memorizingAyatTeachingLearningProgramPlanData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) memorizingAyatTeachingLearningProgramPlanGeneratedData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) memorizingHadithTeachingLearningProgramPlanData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) memorizingHadithTeachingLearningProgramPlanGeneratedData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) memorizingDoaTeachingLearningProgramPlanData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) memorizingDoaTeachingLearningProgramPlanGeneratedData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) stateLearningSessionTeachingLearningProgramPlanData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) stateLearningSessionTeachingLearningProgramPlanGeneratedData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) stateQiyamulLailTeachingLearningProgramPlanData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) stateQiyamulLailTeachingLearningProgramPlanGeneratedData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) otherTeachingLearningProgramPlanData: TeachingLearningProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) otherTeachingLearningProgramPlanGeneratedData: TeachingLearningProgramPlanData;

}