import { bindable, bindingMode, containerless } from "aurelia-framework";
import { MeetingProgramData } from "models/MeetingProgramData";

@containerless
export class ReportRegularMeetingsView {
    @bindable({ defaultBindingMode: bindingMode.oneWay }) workerMeetingProgramData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) workerMeetingProgramGeneratedData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) cmsMeetingProgramData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) cmsMeetingProgramGeneratedData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) smMeetingProgramData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) smMeetingProgramGeneratedData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) memberMeetingProgramData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) memberMeetingProgramGeneratedData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) dawahMeetingProgramData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) dawahMeetingProgramGeneratedData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) stateLeaderMeetingProgramData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) stateLeaderMeetingProgramGeneratedData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) stateOutingMeetingProgramData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) stateOutingMeetingProgramGeneratedData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) iftarMeetingProgramData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) iftarMeetingProgramGeneratedData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) learningMeetingProgramData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) learningMeetingProgramGeneratedData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) socialDawahMeetingProgramData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) socialDawahMeetingProgramGeneratedData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) dawahGroupMeetingProgramData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) dawahGroupMeetingProgramGeneratedData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) nextGMeetingProgramData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) nextGMeetingProgramGeneratedData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) tafsirMeetingProgramData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) tafsirMeetingProgramGeneratedData: MeetingProgramData; 
    @bindable({ defaultBindingMode: bindingMode.oneWay }) unitMeetingProgramData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) unitMeetingProgramGeneratedData: MeetingProgramData; 
    @bindable({ defaultBindingMode: bindingMode.oneWay }) bbqMeetingProgramData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) bbqMeetingProgramGeneratedData: MeetingProgramData; 
    @bindable({ defaultBindingMode: bindingMode.oneWay }) gatheringMeetingProgramData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) gatheringMeetingProgramGeneratedData: MeetingProgramData; 
    @bindable({ defaultBindingMode: bindingMode.oneWay }) familyVisitMeetingProgramData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) familyVisitMeetingProgramGeneratedData: MeetingProgramData; 
    @bindable({ defaultBindingMode: bindingMode.oneWay }) eidReunionMeetingProgramData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) eidReunionMeetingProgramGeneratedData: MeetingProgramData;  
    @bindable({ defaultBindingMode: bindingMode.oneWay }) otherMeetingProgramData: MeetingProgramData;
    @bindable({ defaultBindingMode: bindingMode.oneWay }) otherMeetingProgramGeneratedData: MeetingProgramData;
}