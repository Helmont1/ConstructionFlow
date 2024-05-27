import { Construction } from "./construction.model";
import { DefaultActivity } from "./default-activity.model";
import { Status } from "./status.model";

export interface Activity {
  id?: number,
  budget?: number,
  status: Status,
  construction?: Construction,
  startDate: Date,
  endDate: Date,
  defaultActivity: DefaultActivity,
  order?: number
}
