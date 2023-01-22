import { atom, selector } from "recoil";
import { UserData } from "./UserData";

export const NavBarProfile = selector({
  key: "NavBarProfile",
  get: ({ get }) => {
    const user = get(UserData);
    switch (user.accountType) {
      case "":
        return false;
        break;
      case "guest":
        return false;
        break;
      case "simple":
        return true;
        break;
      case "employee":
        return true;
        break;
      case "admin":
        return true;
        break;
    }
  },
});

export const NavBarSubpages = selector({
  key: "NavBarSubpages",
  get: ({ get }) => {
    const user = get(UserData);
    switch (user.accountType) {
      case "":
        return false;
        break;
      case "guest":
        return true;
        break;
      case "simple":
        return true;
        break;
      case "employee":
        return false;
        break;
      case "admin":
        return false;
        break;
    }
  },
});
