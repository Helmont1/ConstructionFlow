import { Construction } from "./construction.model";
import { DefaultActivity } from "./default-activity.model";
import { Status } from "./status.model";

export interface Activity {
  id?: number,
  budget?: number,
  status?: Status,
  statusId?: number,
  construction?: Construction,
  constructionId?: number,
  startDate: Date,
  endDate: Date,
  defaultActivity?: DefaultActivity,
  defaultActivityId?: string,
  order?: number
}
