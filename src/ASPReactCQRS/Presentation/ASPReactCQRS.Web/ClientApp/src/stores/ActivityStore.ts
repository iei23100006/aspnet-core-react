import { Activity } from "@/pages/activity/models/Activity";
import {
  MRT_ColumnFiltersState,
  MRT_PaginationState,
  MRT_TableInstance,
} from "material-react-table";
import { makeAutoObservable } from "mobx";

export default class ActivityStore {
  table: MRT_TableInstance<Activity> | null = null;
  active: boolean = true;
  pagination: MRT_PaginationState = {
    pageIndex: 0,
    pageSize: 30,
  };
  columnFilters: MRT_ColumnFiltersState = [];

  // Initializes the MobX store and binds methods to the instance.
  constructor() {
    makeAutoObservable(this);
  }

  // Setters
  setTable = (table: MRT_TableInstance<Activity> | null) => {
    this.table = table;
  };

  setActive = (active: boolean) => {
    this.active = active;
  };

  setPagination = (pagination: MRT_PaginationState) => {
    this.pagination = pagination;
  };

  setColumnFilters = (columnFilters: MRT_ColumnFiltersState) => {
    this.columnFilters = columnFilters;
  };

  // Methods
  handleActiveChange = () => {
    this.setActive(!this.active);
  };

  updatePagination = (
    updaterOrValue:
      | MRT_PaginationState
      | ((old: MRT_PaginationState) => MRT_PaginationState)
  ) => {
    const newPagination =
      typeof updaterOrValue === "function"
        ? updaterOrValue(this.pagination)
        : updaterOrValue;
    this.setPagination(newPagination);
  };
}
