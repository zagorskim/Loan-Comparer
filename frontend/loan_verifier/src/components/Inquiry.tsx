import Box from "@mui/material/Box";
import { Outlet } from "react-router-dom";
import {
  InquiryDetails,
  InquiryData,
  BankNames,
  JobTypes,
  GovernmentDocumentTypes,
} from "../data/Types";
import { useState } from "react";
import Typography from "@mui/material/Typography";
import { Stack, Dialog, DialogTitle } from "@mui/material";
import Button from "@mui/material/Button";
import { useRecoilState } from "recoil";
import { UserData } from "../data/UserData";
import axios from "axios";
import {
  ACCEPT_OFFER_ENDPOINT_ADDRESS,
  REJECT_OFFER_ENDPOINT_ADDRESS,
} from "../ConnectionVariables";

export const Inquiry: React.FC<InquiryData> = (props) => {
  const [data, setData] = useState(props);
  const [userLogged, setUserLogged] = useRecoilState(UserData);
  const [details, setDetails] = useState(false);

  const onDelete = () => {};

  const onAccept = () => {
    let config = {
      headers: { Authorization: `Bearer ${userLogged.token}` },
    };

    axios
      .post(ACCEPT_OFFER_ENDPOINT_ADDRESS + "?offerId=" + data.offerFromBank.id, {}, config)
      .then((res) => {
        console.log(res);
      })
      .catch((res) => {
        console.log(res);
      });
  };

  const onRefuse = () => {
    let config = {
      headers: { Authorization: `Bearer ${userLogged.token}` },
    };
    axios
      .post(REJECT_OFFER_ENDPOINT_ADDRESS + "?offerId=" + data.offerFromBank.id, {}, config)
      .then((res) => {
        console.log(res);
      })
      .catch((res) => {
        console.log(res);
      });
  };

  return (
    <Box
      sx={{ border: "1px solid #1976d2" }}
      borderRadius={3}
      padding={2}
      mr={10}
      ml={10}
      mt={3}
      border={1}
      display="flex"
    >
      {userLogged.accountType.toLowerCase() == "simple" && (
        <Dialog open={details} onClose={() => setDetails(false)}>
          <DialogTitle textAlign="center">Inquiry Details</DialogTitle>
          <Typography ml={2} mr={2}>
            Loan value: {data.moneyAmount}
          </Typography>
          <Typography ml={2} mr={2}>
            Installments number: {data.installmentsAmount}
          </Typography>
          <Typography ml={2} mr={2}>
            Monthly installment: {data.offerFromBank.monthlyInstallment}
          </Typography>
          <Typography ml={2} mr={2}>
            Percentage: {data.offerFromBank.percentage}
          </Typography>
          <Typography ml={2} mr={2}>
            Creation date: {new Date(data.creationDate).toDateString()}
          </Typography>
          <Typography ml={2} mr={2}>
            Inquiry ID: {data.inquiryId}
          </Typography>
          <Typography ml={2} mr={2}>
            Offer ID: {data.offerFromBank.id}
          </Typography>
          <Typography mb={2} ml={2} mr={2}>
            Bank ID: {data.bankId}
          </Typography>
        </Dialog>
      )}
      {userLogged.accountType.toLowerCase() == "employee" && (
        <Dialog open={details} onClose={() => setDetails(false)}>
          <DialogTitle textAlign="center">Request Details</DialogTitle>
          <Typography ml={2} mr={2}>
            First name: {data.firstName}
          </Typography>
          <Typography ml={2} mr={2}>
            Last name: {data.lastName}
          </Typography>
          <Typography ml={2} mr={2}>
            Job type: {Object.keys(JobTypes)[data.jobType]}
          </Typography>
          <Typography ml={2} mr={2}>
            Income level: {data.incomeLevel}
          </Typography>
          <Typography ml={2} mr={2}>
            Creation date: {new Date(data.creationDate).toDateString()}
          </Typography>
          <Typography ml={2} mr={2}>
            Government document type: {Object.values(GovernmentDocumentTypes)[data.documentType]}
          </Typography>
          <Typography ml={2} mr={2}>
            Government document ID: {data.documentId}
          </Typography>
          <Typography ml={2} mr={2}>
            Offer ID: {data.id}
          </Typography>
          <Typography ml={2} mr={2}>
            Loan value: {data.moneyAmount}
          </Typography>
          <Typography mb={2} ml={2} mr={2}>
            Installments number: {data.installmentsAmount}
          </Typography>
        </Dialog>
      )}
      {userLogged.accountType.toLowerCase() == "simple" && (
        <Stack direction="row" spacing={6}>
          <Typography ml={2} textAlign="left" width={200} component="label" variant="h6">
            Bank: {Object.values(BankNames)[data.bankId]}
          </Typography>
          <Typography textAlign="left" component="label" width={150} variant="h6">
            Installments: {data.installmentsAmount}
          </Typography>
          <Typography textAlign="left" component="label" width={150} variant="h6">
            Value: {data.moneyAmount}
          </Typography>
          <Typography textAlign="left" component="label" width={180} variant="h6">
            Percentage: {data.offerFromBank.percentage}
          </Typography>
          <Typography textAlign="left" component="label" width={180} variant="h6">
            Status: {data.offerFromBank.offerStatus}
          </Typography>
        </Stack>
      )}

      {userLogged.accountType.toLowerCase() == "employee" && (
        <Stack direction="row" spacing={6}>
          <Typography ml={2} textAlign="left" width={200} component="label" variant="h6">
            {data.firstName + " " + data.lastName}
          </Typography>
          <Typography textAlign="left" component="label" width={150} variant="h6">
            Installments: {data.installmentsAmount}
          </Typography>
          <Typography textAlign="left" component="label" width={150} variant="h6">
            Value: {data.moneyAmount}
          </Typography>
          <Typography textAlign="left" component="label" width={180} variant="h6">
            Income: {data.incomeLevel}
          </Typography>
        </Stack>
      )}

      {userLogged.accountType.toLowerCase() == "simple" && (
        <Box width="100%" display="flex" justifyContent="flex-end">
          <Stack spacing={2} direction="row">
            <Button onClick={() => setDetails(true)} variant="contained">
              Details
            </Button>
            <Button onClick={onDelete} sx={{ backgroundColor: "red" }} variant="contained">
              Cancel
            </Button>
          </Stack>
        </Box>
      )}
      {userLogged.accountType.toLowerCase() == "employee" && (
        <Box width="100%" display="flex" justifyContent="flex-end">
          <Stack spacing={2} direction="row">
            <Button onClick={onAccept} sx={{ backgroundColor: "green" }} variant="contained">
              Accept
            </Button>
            <Button onClick={onRefuse} sx={{ backgroundColor: "red" }} variant="contained">
              Reject
            </Button>
            <Button onClick={() => setDetails(true)} variant="contained">
              Details
            </Button>
          </Stack>
        </Box>
      )}
      <Outlet></Outlet>
    </Box>
  );
};
