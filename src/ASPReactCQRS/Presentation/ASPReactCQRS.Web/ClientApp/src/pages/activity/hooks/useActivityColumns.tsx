import { type MRT_ColumnDef } from "material-react-table";
import { Activity } from "../models/Activity";
import { useStore } from "@/stores/store";

export const useActivityColumns = () => {
  const { activityStore } = useStore();
  const columns: MRT_ColumnDef<Activity>[] = [
    {
      accessorKey: "id",
      header: "Id",
      enableEditing: false,
      Edit: () => null,
      size: 0,
      visibleInShowHideMenu: false,
    },
    {
      accessorKey: "activityName",
      header: "Activity Name",
    },
    {
      accessorKey: "createdAt",
      header: "Created At",
      enableEditing: false,
      enableColumnFilter: false,

      Edit: () => null,
    },
    {
      accessorKey: "createdBy",
      header: "Created By",
      enableEditing: false,
      enableColumnFilter: false,

      Edit: () => null,
    },
    ...(activityStore.active
      ? [
          {
            accessorKey: "updatedAt",
            header: "Updated At",
            enableEditing: false,
            enableColumnFilter: false,

            Edit: () => null,
          },
          {
            accessorKey: "updatedBy",
            header: "Updated By",
            enableEditing: false,
            enableColumnFilter: false,

            Edit: () => null,
          },
        ]
      : [
          {
            accessorKey: "deletedAt",
            header: "Deleted At",
            enableEditing: false,
            enableColumnFilter: false,

            Edit: () => null,
          },
          {
            accessorKey: "deletedBy",
            header: "Deleted By",
            enableEditing: false,
            enableColumnFilter: false,

            Edit: () => null,
          },
        ]),
  ];

  return columns;
};
