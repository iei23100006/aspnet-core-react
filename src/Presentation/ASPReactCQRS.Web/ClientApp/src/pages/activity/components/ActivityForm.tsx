import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { TextField, Button } from "@mui/material";
import { activitySchema } from "../validation/activitySchema";
import ThemeButton from "@/components/common/ThemeButton";
import { themeColors } from "@/config/theme/theme";
import { Activity, CreateActivity, UpdateActivity } from "../models/Activity";
import { useStore } from "@/stores/store";
interface ActivityFormProps {
  title: string;
  initialData?: Activity;
  onSubmit: (data: CreateActivity | UpdateActivity) => void;
}

export default function ActivityForm({
  initialData,
  onSubmit,
  title,
}: ActivityFormProps) {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(activitySchema),
    defaultValues: initialData,
  });

  const { activityStore } = useStore();

  return (
    <>
      <div className="p-4">
        <div className="font-semibold text-2xl mb-5">{title}</div>

        <form
          className="space-y-4 md:space-y-6"
          onSubmit={handleSubmit(onSubmit)}
        >
          <TextField
            fullWidth
            label="Activity Name"
            size="small"
            {...register("activityName")}
            error={!!errors.activityName}
            helperText={errors.activityName?.message}
          />
          <div className="flex justify-end gap-5">
            <Button
              className="w-28"
              sx={{
                color: themeColors.primary,
                "&:hover": {
                  backgroundColor: themeColors.background.selected,
                },
              }}
              onClick={() => {
                activityStore.table?.setEditingRow(null);
                activityStore.table?.setCreatingRow(null);
              }}
            >
              Cancel
            </Button>
            <ThemeButton type="submit" variant="contained" className="w-28">
              Save
            </ThemeButton>
          </div>
        </form>
      </div>
    </>
  );
}
