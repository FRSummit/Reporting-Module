import $ from "jquery";

export class AnalyticReportCreate {

    wizard: HTMLElement;
    timestampFromElement: HTMLElement;
    timestampToElement: HTMLElement;
    attached() {
        (<any>$(this.wizard)).smartWizard({
            theme: "arrows",
            showStepURLhash: false,
            toolbarSettings: {
                toolbarExtraButtons: [$("<a class=\"btn btn-submit btn-success text-white\" type=\"button\" href=\"analytic-reports\">Create</a>")]
            }
        });
        const options: any = {
            locale: {
                format: 'DD/M/YYYY hh:mm:ss A'
          },
          minYear: 2019,
          autoUpdateInput: false, // initially empty
          showDropdowns: true,
          timePicker: true,
          timePickerSeconds: true,
          singleDatePicker: true
        };
        $(this.timestampFromElement).daterangepicker(options);
        $(this.timestampToElement).daterangepicker(options);
    }
}