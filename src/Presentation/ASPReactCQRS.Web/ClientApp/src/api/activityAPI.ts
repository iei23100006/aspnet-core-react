import {
  Activity,
  CreateActivity,
  ResponseActivity,
  UpdateActivity,
} from "@/pages/activity/models/Activity";
import { requests } from "./agent";

export const ActivityAPI = {
  list: (pageIndex: number, pageSize: number, active: boolean) =>
    requests.get<ResponseActivity>(
      `/api/activity?pageIndex=${pageIndex}&pageSize=${pageSize}&isActive=${active}`
    ),
  create: (activity: CreateActivity) =>
    requests.post<Activity>("/api/activity", activity),
  update: (activity: UpdateActivity) =>
    requests.patch<Activity>("/api/activity", activity),
  delete: (id: number) => requests.del<Activity>(`/api/activity/${id}`),
  undelete: (id: number) => requests.put<Activity>(`/api/activity/${id}`, {}),
};
