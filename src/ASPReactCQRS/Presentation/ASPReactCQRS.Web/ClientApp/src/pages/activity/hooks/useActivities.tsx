import { useStore } from "@/stores/store";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import {
  CreateActivity,
  ResponseActivity,
  UpdateActivity,
} from "../models/Activity";
import agent from "@/api/agent";
import formatCustomDate from "@/utils/formatCustomDate";

// Get Activity
function useGetActivities() {
  const { activityStore } = useStore();
  const { pagination, active, columnFilters } = activityStore;

  return useQuery<ResponseActivity>({
    queryKey: ["activities", pagination, active, columnFilters],
    queryFn: async () => {
      //send api request here
      return await agent.ActivityAPI.list(
        pagination.pageIndex,
        pagination.pageSize,
        active
      );
    },
    enabled: true,
    staleTime: 30_000,
  });
}

// Create Activity
function useCreateActivity() {
  const queryClient = useQueryClient();
  const { userStore, activityStore } = useStore();
  const { table, pagination, active, columnFilters } = activityStore;

  return useMutation({
    mutationFn: async (activity: CreateActivity) => {
      // Send API create request here
      return await agent.ActivityAPI.create(activity);
    },
    onMutate: async (newActivity: CreateActivity) => {
      // Cancel any outgoing refetches to avoid overwriting our optimistic update
      await queryClient.cancelQueries({
        queryKey: ["activities", pagination, active, columnFilters],
      });

      // Snapshot the previous value
      const previousActivities = queryClient.getQueryData<ResponseActivity>([
        "activities",
        pagination,
        active,
        columnFilters,
      ]);

      // Optimistically update to the new value
      if (previousActivities) {
        queryClient.setQueryData<ResponseActivity>(
          ["activities", pagination, active, columnFilters],
          {
            ...previousActivities,
            activities: [
              ...previousActivities.activities,
              {
                ...newActivity,
                id: Date.now(), // Temporary ID, will be replaced with the real one from the server
                createdAt: formatCustomDate(new Date()),
                createdBy: userStore.user?.name ?? "",
              },
            ],
            totalRows: previousActivities.totalRows + 1,
          }
        );
      }

      // Return a context object with the snapshotted value
      return { previousActivities };
    },
    onSuccess: () => {
      table?.setCreatingRow(null);
    },
    onError: (_, __, context) => {
      // If the mutation fails, use the context returned from onMutate to roll back
      if (context?.previousActivities) {
        queryClient.setQueryData<ResponseActivity>(
          ["activities", pagination, active, columnFilters],
          context.previousActivities
        );
      }
    },
    onSettled: () => {
      // Always refetch after error or success to ensure we have the correct data
      queryClient.invalidateQueries({
        queryKey: ["activities", pagination, active, columnFilters],
      });
    },
  });
}

// Update Activity
function useUpdateActivity() {
  const { activityStore } = useStore();
  const { table, pagination, active } = activityStore;
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: async (activity: UpdateActivity) => {
      return await agent.ActivityAPI.update(activity);
    },
    onMutate: async (updatedActivity: UpdateActivity) => {
      await queryClient.cancelQueries({ queryKey: ["activities"] });

      const previousActivities = queryClient.getQueryData<ResponseActivity>([
        "activities",
        pagination,
        active,
      ]);

      if (previousActivities) {
        queryClient.setQueryData<ResponseActivity>(
          ["activities", pagination, active],
          {
            ...previousActivities,
            activities: previousActivities.activities.map((activity) =>
              activity.id === updatedActivity.id
                ? { ...activity, ...updatedActivity }
                : activity
            ),
          }
        );
      }

      return { previousActivities };
    },
    onSuccess: () => {
      table?.setEditingRow(null);
    },
    onError: (_, __, context) => {
      if (context?.previousActivities) {
        Object.entries(context.previousActivities).forEach(([key, value]) => {
          const isActive = key === "active";
          queryClient.setQueryData<ResponseActivity>(
            ["activities", pagination, isActive],
            value
          );
        });
      }
    },
    onSettled: () => {
      queryClient.invalidateQueries({ queryKey: ["activities"] });
    },
  });
}

// Delete Activity
function useDeleteActivity() {
  const queryClient = useQueryClient();
  const { activityStore } = useStore();
  const { table, pagination, active, columnFilters } = activityStore;

  return useMutation({
    mutationFn: async (id: number) => {
      return await agent.ActivityAPI.delete(id);
    },
    onMutate: async (deletedId: number) => {
      // Cancel any outgoing refetches to avoid overwriting our optimistic update
      await queryClient.cancelQueries({
        queryKey: ["activities", pagination, active, columnFilters],
      });

      const previousActiveActivities =
        queryClient.getQueryData<ResponseActivity>([
          "activities",
          pagination,
          true, // Active filter
          columnFilters,
        ]);

      const previousInactiveActivities =
        queryClient.getQueryData<ResponseActivity>([
          "activities",
          pagination,
          false, // Inactive filter
          columnFilters,
        ]);

      // If it's an active activity, remove it from active and add to inactive
      if (previousActiveActivities) {
        const updatedActiveActivities =
          previousActiveActivities.activities.filter(
            (activity) => activity.id !== deletedId
          );

        queryClient.setQueryData<ResponseActivity>(
          ["activities", pagination, true, columnFilters],
          {
            ...previousActiveActivities,
            activities: updatedActiveActivities,
            totalRows: previousActiveActivities.totalRows - 1,
          }
        );
      }

      // Add deleted activity to inactive list
      if (previousInactiveActivities) {
        const deletedActivity = previousActiveActivities?.activities.find(
          (activity) => activity.id === deletedId
        );

        if (deletedActivity) {
          queryClient.setQueryData<ResponseActivity>(
            ["activities", pagination, false, columnFilters],
            {
              ...previousInactiveActivities,
              activities: [
                ...previousInactiveActivities.activities,
                deletedActivity,
              ],
              totalRows: previousInactiveActivities.totalRows + 1,
            }
          );
        }
      }
      return { previousActiveActivities, previousInactiveActivities };
    },
    onSuccess: () => {
      table?.setEditingRow(null);
    },
    onError: (_, __, context) => {
      if (context?.previousActiveActivities) {
        queryClient.setQueryData<ResponseActivity>(
          ["activities", pagination, true, columnFilters],
          context.previousActiveActivities
        );
      }

      if (context?.previousInactiveActivities) {
        queryClient.setQueryData<ResponseActivity>(
          ["activities", pagination, false, columnFilters],
          context.previousInactiveActivities
        );
      }
    },
    onSettled: () => {
      // Always refetch after error or success to ensure we have the correct data
      queryClient.invalidateQueries({
        queryKey: ["activities", pagination, true, columnFilters],
      });

      queryClient.invalidateQueries({
        queryKey: ["activities", pagination, false, columnFilters],
      });
    },
  });
}

// Restore User
function useRestoreActivity() {
  const queryClient = useQueryClient();
  const { activityStore } = useStore();
  const { table, pagination, active, columnFilters } = activityStore;

  return useMutation({
    mutationFn: async (id: number) => {
      return await agent.ActivityAPI.undelete(id);
    },
    onMutate: async (restoredId: number) => {
      // Cancel any outgoing refetches to avoid overwriting our optimistic update
      await queryClient.cancelQueries({
        queryKey: ["activities", pagination, active, columnFilters],
      });

      const previousActiveActivities =
        queryClient.getQueryData<ResponseActivity>([
          "activities",
          pagination,
          true, // Active filter
          columnFilters,
        ]);

      const previousInactiveActivities =
        queryClient.getQueryData<ResponseActivity>([
          "activities",
          pagination,
          false, // Inactive filter
          columnFilters,
        ]);

      // Remove the restored activity from inactive and add it to active
      if (previousInactiveActivities) {
        const updatedInactiveActivities =
          previousInactiveActivities.activities.filter(
            (activity) => activity.id !== restoredId
          );

        queryClient.setQueryData<ResponseActivity>(
          ["activities", pagination, false, columnFilters],
          {
            ...previousInactiveActivities,
            activities: updatedInactiveActivities,
            totalRows: previousInactiveActivities.totalRows - 1,
          }
        );
      }

      // Add restored activity to active list
      if (previousActiveActivities) {
        const restoredActivity = previousInactiveActivities?.activities.find(
          (activity) => activity.id === restoredId
        );

        if (restoredActivity) {
          queryClient.setQueryData<ResponseActivity>(
            ["activities", pagination, true, columnFilters],
            {
              ...previousActiveActivities,
              activities: [
                ...previousActiveActivities.activities,
                restoredActivity,
              ],
              totalRows: previousActiveActivities.totalRows + 1,
            }
          );
        }
      }
      return { previousActiveActivities, previousInactiveActivities };
    },
    onSuccess: () => {
      table?.setEditingRow(null);
    },
    onError: (_, __, context) => {
      if (context?.previousActiveActivities) {
        queryClient.setQueryData<ResponseActivity>(
          ["activities", pagination, true, columnFilters],
          context.previousActiveActivities
        );
      }

      if (context?.previousInactiveActivities) {
        queryClient.setQueryData<ResponseActivity>(
          ["activities", pagination, false, columnFilters],
          context.previousInactiveActivities
        );
      }
    },
    onSettled: () => {
      // Always refetch after error or success to ensure we have the correct data
      queryClient.invalidateQueries({
        queryKey: ["activities", pagination, true, columnFilters],
      });

      queryClient.invalidateQueries({
        queryKey: ["activities", pagination, false, columnFilters],
      });
    },
  });
}

export {
  useGetActivities,
  useCreateActivity,
  useUpdateActivity,
  useDeleteActivity,
  useRestoreActivity,
};
