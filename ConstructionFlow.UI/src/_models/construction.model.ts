import { Customer } from "./customer.model";
import { Status } from "./status.model";
import { User } from "./user.model";

export interface Construction {
  id: number,
  statusId: number,
  startDate: Date,
  endDate: Date,
  customerId: number,
  userId: number
}