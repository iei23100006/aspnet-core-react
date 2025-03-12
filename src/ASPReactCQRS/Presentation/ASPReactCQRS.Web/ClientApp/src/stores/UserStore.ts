import { makeAutoObservable } from "mobx";
import { User } from "../models/User";

export default class UserStore {
  user: User | undefined | null;

  constructor() {
    makeAutoObservable(this);
  }

  setUser = (user: User | undefined | null) => {
    this.user = user;
  };
}
