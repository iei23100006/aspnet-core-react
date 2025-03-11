import * as yup from "yup";

export const activitySchema = yup.object().shape({
  activityName: yup.string().required("Activity Name is required"),
});
