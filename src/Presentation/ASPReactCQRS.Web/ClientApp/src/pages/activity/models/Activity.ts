export interface Activity {
  id?: number;
  activityName: string;
  createdAt?: string;
  createdBy?: string;
  updatedAt?: string;
  updatedBy?: string;
  deletedAt?: string;
  deletedBy?: string;
}

export interface ResponseActivity {
  pageIndex: number;
  pageSize: number;
  totalRows: number;
  activities: Activity[];
}

export interface CreateActivity {
  activityName: string;
}

export interface UpdateActivity extends CreateActivity {
  id?: number;
}
