import { Customer } from "./customer.model";
import { Status } from "./status.model";
import { User } from "./user.model";

export interface Construction {
  constructionId: string,
  status: Status,
  startDate: Date,
  endDate: Date,
  customer: Customer,
  user: User
}
