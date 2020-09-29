import * as moment from "moment";

export class ConvertToLocalDateValueConverter {
  toView(localDate: Date) {
      //moment.utc(localDate).toDate()
      const updated = moment(moment.utc(localDate).toDate());
      //${updated.format("DD")}-${timestamp.format("MMMM")}-${start.format("YYYY")}
      return `Last Updated on ${updated.format("DD")}-${updated.format("MMMM")}-${updated.format("YYYY")} 
      at ${updated.format("HH:mm:ss")}`;
  }
}
