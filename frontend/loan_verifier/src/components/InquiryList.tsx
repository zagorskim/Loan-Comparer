import Box from "@mui/material/Box";
import { Outlet } from "react-router-dom";
import { useRecoilState, useRecoilValue } from "recoil";
import { UserInquiries, EmployeeRequests } from "../data/UserData";
import { Stack, Fade, CircularProgress, TextField } from "@mui/material";
import { Inquiry } from "./Inquiry";
import { InquiryDetails, OfferData } from "../data/Types";
import { useEffect } from "react";
import axios from "axios";
import {
  GET_INQUIRY_ENDPOINT_ADDRESS,
  GET_ALL_INQUIRIES_ENDPOINT_ADDRESS,
} from "../ConnectionVariables";
import { UserData } from "./../data/UserData";
import Button from "@mui/material/Button";
import { width } from "@mui/system";
import { useState } from "react";
import Typography from "@mui/material/Typography";
import Divider from "@mui/material/Divider";
import { FilteredList, FilterUserName } from "../data/OfferListManipulation";

export const InquiryList: React.FC = () => {
  const [inquiryList, setInquiryList] = useRecoilState(UserInquiries);
  const [offerList, setOfferList] = useRecoilState(EmployeeRequests);
  const [userLogged, setUserLogged] = useRecoilState(UserData);
  const [filter, setFilter] = useRecoilState(FilterUserName);
  const [localFilter, setLocalFilter] = useState("");
  const filteredList = useRecoilValue(FilteredList);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    setLoading(true);
    if (userLogged.accountType.toLowerCase() == "simple") {
      let config = {
        headers: { Authorization: `Bearer ${userLogged.token}` },
      };
      axios
        .get(GET_INQUIRY_ENDPOINT_ADDRESS, config)
        .then((res) => {
          console.log(res);
          setInquiryList(res.data);
          setLoading(false);
        })
        .catch((res) => {
          console.log(res);
          setLoading(false);
        });
    } else {
      let config = {
        headers: { Authorization: `Bearer ${userLogged.token}` },
      };
      axios
        .get(GET_ALL_INQUIRIES_ENDPOINT_ADDRESS, config)
        .then((res) => {
          console.log(res);
          setOfferList(res.data);
          setLoading(false);
        })
        .catch((res) => {
          console.log(res);
          setLoading(false);
        });
    }
  }, [userLogged, filter]);
  return (
    <Box>
      {loading && (
        <Box mt={3}>
          <CircularProgress />
        </Box>
      )}
      {!loading && (
        <Stack direction="column">
          <Typography mb={2} mt={3} variant="h4">
            {userLogged.accountType == "simple" ? "Recent inquiries" : "Recent requests"}
          </Typography>
          <Divider variant="middle" />
          {userLogged.accountType == "employee" && (
            <Stack mt={2} alignSelf="center" spacing={3} direction="row">
              <TextField
                sx={{ alignSelf: "center", width: 160 }}
                placeholder="Search by person name"
                onChange={(x) => {
                  setLocalFilter(x.target.value);
                }}
              ></TextField>
              <Button
                sx={{ height: 50, alignSelf: "center" }}
                value={localFilter}
                onClick={() => {
                  setFilter(localFilter.toString());
                }}
                variant="contained"
              >
                Search
              </Button>
            </Stack>
          )}
          {inquiryList.length == 0 && filteredList.length == 0 && (
            <Box
              sx={{ border: "1px solid #1976d2" }}
              alignSelf="center"
              alignContent="center"
              borderRadius={3}
              padding={2}
              mr={10}
              ml={10}
              mt={3}
              border={2}
            >
              <Typography textAlign="center" variant="h5">
                {userLogged.accountType == "simple" ? "No inquiries yet" : "No requests found"}
              </Typography>
            </Box>
          )}
          {inquiryList.map((x) => {
            if (x.offerFromBank != null) {
              return (
                <Inquiry
                  offerFromBank={
                    {
                      creationDate: new Date(x.offerFromBank.creationDate),
                      id: x.offerFromBank.id,
                      installmentAmount: x.offerFromBank.installmentAmount,
                      moneyAmount: x.offerFromBank.moneyAmount,
                      monthlyInstallment: x.offerFromBank.monthlyInstallment,
                      percentage: x.offerFromBank.percentage,
                      offerStatus: x.offerFromBank.offerStatus,
                    } as OfferData
                  }
                  installmentsAmount={x.installmentsAmount}
                  moneyAmount={x.moneyAmount}
                  creationDate={x.creationDate}
                  bankId={x.bankId}
                  inquiryId={x.inquiryId}
                  id=""
                  documentId=""
                  documentType={0}
                  firstName=""
                  lastName=""
                  incomeLevel={0}
                  jobType={30}
                ></Inquiry>
              );
            }
          })}
          {filteredList.map((x) => {
            return (
              <Inquiry
                bankId={0}
                inquiryId=""
                offerFromBank={{} as OfferData}
                creationDate={new Date(x.creationDate)}
                id={x.id}
                installmentsAmount={x.installmentsCount}
                moneyAmount={x.moneyAmount}
                documentId={x.documentId}
                documentType={x.documentType}
                firstName={x.firstName}
                lastName={x.lastName}
                incomeLevel={x.incomeLevel}
                jobType={x.jobType}
              ></Inquiry>
            );
          })}
          {inquiryList.length != 0 && (
            <Button style={{ margin: 20, alignSelf: "center", width: "150px" }}>View more</Button>
          )}
        </Stack>
      )}
      <Outlet></Outlet>
    </Box>
  );
};
