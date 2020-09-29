import * as moment from "moment";

export class ConvertToLocalDateOnlyValueConverter {
  toView(localDate: Date) {
      //moment.utc(localDate).toDate()
      const updated = moment(moment.utc(localDate).toDate());
      //${updated.format("DD")}-${timestamp.format("MMMM")}-${start.format("YYYY")}
      return `${updated.format("DD")}-${updated.format("MMMM")}-${updated.format("YYYY")}`;
  }
}
