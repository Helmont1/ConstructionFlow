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
  startDate: Date | string,
  endDate: Date | string,
  defaultActivity?: DefaultActivity,
  defaultActivityId?: string,
  activityName: string,
  icon: string,
  order?: number,
  usedMaterial?: 0,
  wastedMaterial?: 0
}
