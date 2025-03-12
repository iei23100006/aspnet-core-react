import {
  MaterialReactTable,
  useMaterialReactTable,
} from "material-react-table";
import { observer } from "mobx-react-lite";
import { useActivityColumns } from "../hooks/useActivityColumns";
import { useStore } from "@/stores/store";
import { CreateActivity, UpdateActivity } from "../models/Activity";
import { themeColors } from "@/config/theme/theme";
import ThemeButton from "@/components/common/ThemeButton";
import { Box, IconButton, Tooltip } from "@mui/material";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import RestoreIcon from "@mui/icons-material/Restore";
import ActivityForm from "./ActivityForm";
import {
  useCreateActivity,
  useDeleteActivity,
  useGetActivities,
  useRestoreActivity,
  useUpdateActivity,
} from "../hooks/useActivities";
import { useEffect } from "react";

function ActivityTable() {
  const { activityStore } = useStore();
  const columns = useActivityColumns();

  // Calling the API to get the sectors
  const {
    data: responseActvities,
    isError: isLoadingModelsError,
    isFetching: isFetchingModels,
    isLoading: isLoadingModels,
  } = useGetActivities();

  // Calling the mutation
  const { mutateAsync: createActivity } = useCreateActivity();

  const handleCreateActivity = async (data: CreateActivity) => {
    await createActivity(data);
  };

  const { mutateAsync: updateActivity } = useUpdateActivity();

  const handleUpdateActivity = async (data: UpdateActivity) => {
    await updateActivity(data);
  };

  const { mutateAsync: deleteActivity } = useDeleteActivity();

  const { mutateAsync: restoreActivity } = useRestoreActivity();

  const handleDeleteActivity = (id: number) => {
    if (window.confirm("Are you sure you want to delete this activity?")) {
      deleteActivity(id);
    }
  };

  const handleRestoreActivity = (id: number) => {
    if (window.confirm("Are you sure you want to restore this activity?")) {
      restoreActivity(id);
    }
  };

  const table = useMaterialReactTable({
    // styles
    muiTableHeadCellProps: {
      sx: {
        backgroundColor: themeColors.primary,
        "& .MuiButtonBase-root": {
          color: "white",
          fontWeight: "bold",
          opacity: 0.7,
        },
        "& .Mui-TableHeadCell-Content-Labels": {
          color: "white",
        },
        "& .MuiTableSortLabel-root:hover": {
          color: "white",
        },
        "& .MuiTableSortLabel-icon": {
          color: "white !important",
        },
      },
    },
    columns,
    data: responseActvities?.activities ?? [],
    createDisplayMode: "modal", //default ('row', and 'custom' are also available)
    editDisplayMode: "modal", //default ('row', 'cell', 'table', and 'custom' are also available)
    enableEditing: true,
    enableSorting: false,
    enableFilters: false,
    enableGlobalFilter: false,
    manualPagination: true,
    manualFiltering: false,
    enableColumnDragging: true,
    enableColumnOrdering: true,
    getRowId: (row) => (row.id ? row.id.toString() : ""),
    onPaginationChange: activityStore.updatePagination,
    rowCount: responseActvities?.totalRows ?? 0,
    renderTopToolbarCustomActions: ({ table }) => (
      <ThemeButton
        variant="contained"
        onClick={() => {
          table.setCreatingRow(true);
        }}
        className="normal-case"
      >
        Create New Activity
      </ThemeButton>
    ),
    renderRowActions: ({ row, table }) => (
      <Box sx={{ display: "flex" }}>
        {activityStore.active ? (
          <>
            {/* Edit Icon */}
            <Tooltip title="Edit">
              <IconButton onClick={() => table.setEditingRow(row)}>
                <EditIcon sx={{ color: themeColors.primary }} />
              </IconButton>
            </Tooltip>

            {/* Delete Icon */}
            <Tooltip title="Delete">
              <IconButton
                color="error"
                onClick={() => handleDeleteActivity(row.original.id!)}
              >
                <DeleteIcon />
              </IconButton>
            </Tooltip>
          </>
        ) : (
          // Restore Icon
          <>
            <Tooltip title="Restore">
              <IconButton
                color="secondary"
                onClick={() => handleRestoreActivity(row.original.id!)}
              >
                <RestoreIcon />
              </IconButton>
            </Tooltip>
          </>
        )}
      </Box>
    ),
    renderCreateRowDialogContent: () => (
      <ActivityForm
        title="Create New Activity"
        onSubmit={handleCreateActivity}
      />
    ),
    renderEditRowDialogContent: ({ row }) => (
      <ActivityForm
        title="Edit Activity"
        initialData={row.original}
        onSubmit={handleUpdateActivity}
      />
    ),
    initialState: {
      columnVisibility: {
        id: false,
      },
      showColumnFilters: true,
    },
    state: {
      isLoading: isLoadingModels,
      showAlertBanner: isLoadingModelsError,
      showProgressBars: isFetchingModels,
      pagination: activityStore.pagination,
    },
  });

  useEffect(() => {
    if (table) {
      activityStore.setTable(table);
    }
  }, [table, activityStore]);

  return <MaterialReactTable table={table} />;
}

export default observer(ActivityTable);
