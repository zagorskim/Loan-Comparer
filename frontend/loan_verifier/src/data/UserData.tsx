import { atom, selector } from "recoil";
import { number } from "yargs";
import {
  UserDetails,
  InquiryDetails,
  InquiryData,
  RequestData,
  JobTypes,
  GovernmentDocumentTypes,
} from "./Types";

export const UserData = atom({
  key: "UserData",
  default: { accountType: "", firstName: "", lastName: "" } as UserDetails,
});

export const UserInquiries = atom({
  key: "UserInquiries",
  default: [
    //     {
    //     moneyAmount: 0,
    //     installmentsAmount: 0,
    //     inquiryId: '',
    //     bankId: 0,
    //     creationDate: new Date(),
    //     offerFromBank: {
    //         moneyAmount: 0,
    //         installmentAmount: 0,
    //         creationDate: new Date(),
    //         id: '',
    //         monthlyInstallment: 0,
    //         percentage: 0,
    //     }
    //   }
  ] as InquiryData[],
});

export const EmployeeRequests = atom({
  key: "EmployeeRequests",
  default: [
    //     {
    //     moneyAmount: 0,
    //     installmentsCount: 0,
    //     id: '',
    //     firstName: '',
    //     lastName: '',
    //     creationDate: new Date(),
    //     jobType: 30,
    //     incomeLevel: 0,
    //     documentId: '',
    //     documentType: 1,
    //   }
  ] as RequestData[],
});

export const GoogleAuthData = atom({
  key: "GoogleAuthData",
  default: {},
});
