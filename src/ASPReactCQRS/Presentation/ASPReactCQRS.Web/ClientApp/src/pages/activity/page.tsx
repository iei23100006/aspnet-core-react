import { useStore } from "@/stores/store";
import { Switch } from "@mui/material";
import { observer } from "mobx-react-lite";
import ActivityTable from "./components/ActivityTable";

function Activity() {
  const { activityStore } = useStore();
  return (
    <>
      <div className="text-center font-semibold text-2xl my-5">
        Activity Table
      </div>
      <div className="text-right my-3">
        <span>{activityStore.active ? "Active" : "Inactive"}</span>
        <Switch defaultChecked onChange={activityStore.handleActiveChange} />
      </div>
      <div>
        <ActivityTable />
      </div>
    </>
  );
}

export default observer(Activity);
