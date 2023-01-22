import { atom, selector } from "recoil";
import { EmployeeRequests } from "./UserData";
import { OfferData, RequestData } from "./Types";

export const FilterUserName = atom({
  key: "FilterUserName",
  default: "",
});

export const FilteredList = selector({
  key: "FilteredList",
  get: ({ get }) => {
    const list = get(EmployeeRequests);
    const filter = get(FilterUserName);
    let res = [] as RequestData[];
    if (filter == "") {
      return list;
    } else {
      let i = 0;
      list.forEach((x, index) => {
        if (
          x.firstName.toLowerCase().search(filter) != -1 ||
          x.lastName.toLowerCase().search(filter) != -1
        ) {
          res[i] = x;
          i++;
        } else return;
      });
    }
    return res as RequestData[];
  },
});
