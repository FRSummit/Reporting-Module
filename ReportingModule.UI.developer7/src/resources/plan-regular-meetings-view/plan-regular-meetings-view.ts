import { bindable, bindingMode, containerless } from "aurelia-framework";
import { MeetingProgramPlanData } from "models/MeetingProgramPlanData";

@containerless
export class PlanRegularMeetingsView {
    @bindable({ defaultBindingMode: bindingMode.oneWay }) workerMeetingProgramPlanData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) workerMeetingProgramPlanGeneratedData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) cmsMeetingProgramPlanData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) cmsMeetingProgramPlanGeneratedData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) smMeetingProgramPlanData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) smMeetingProgramPlanGeneratedData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) memberMeetingProgramPlanData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) memberMeetingProgramPlanGeneratedData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) dawahMeetingProgramPlanData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) dawahMeetingProgramPlanGeneratedData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) stateLeaderMeetingProgramPlanData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) stateLeaderMeetingProgramPlanGeneratedData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) stateOutingMeetingProgramPlanData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) stateOutingMeetingProgramPlanGeneratedData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) iftarMeetingProgramPlanData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) iftarMeetingProgramPlanGeneratedData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) learningMeetingProgramPlanData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) learningMeetingProgramPlanGeneratedData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) socialDawahMeetingProgramPlanData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) socialDawahMeetingProgramPlanGeneratedData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) dawahGroupMeetingProgramPlanData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) dawahGroupMeetingProgramPlanGeneratedData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) nextGMeetingProgramPlanData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) nextGMeetingProgramPlanGeneratedData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) tafsirMeetingProgramPlanData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) tafsirMeetingProgramPlanGeneratedData: MeetingProgramPlanData; 
    @bindable({ defaultBindingMode: bindingMode.oneWay }) unitMeetingProgramPlanData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) unitMeetingProgramPlanGeneratedData: MeetingProgramPlanData; 
    @bindable({ defaultBindingMode: bindingMode.oneWay }) bbqMeetingProgramPlanData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) bbqMeetingProgramPlanGeneratedData: MeetingProgramPlanData; 
    @bindable({ defaultBindingMode: bindingMode.oneWay }) gatheringMeetingProgramPlanData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) gatheringMeetingProgramPlanGeneratedData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) familyVisitMeetingProgramPlanData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) familyVisitMeetingProgramPlanGeneratedData: MeetingProgramPlanData;  
    @bindable({ defaultBindingMode: bindingMode.oneWay }) eidReunionMeetingProgramPlanData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) eidReunionMeetingProgramPlanGeneratedData: MeetingProgramPlanData;    
    @bindable({ defaultBindingMode: bindingMode.oneWay }) otherMeetingProgramPlanData: MeetingProgramPlanData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) otherMeetingProgramPlanGeneratedData: MeetingProgramPlanData;     

}