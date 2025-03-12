import { createContext, useContext } from "react";
import UserStore from "./UserStore";
import ActivityStore from "./ActivityStore";

interface Store {
  userStore: UserStore;
  activityStore: ActivityStore;
}

export const store: Store = {
  userStore: new UserStore(),
  activityStore: new ActivityStore(),
};

export const StoreContext = createContext(store);

export function useStore() {
  return useContext(StoreContext);
}
