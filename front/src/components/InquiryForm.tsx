import Box from "@mui/material/Box";
import { UserData } from "./../data/UserData";
import { useRecoilState } from "recoil";
import Container from "@mui/material/Container";
import CssBaseline from "@mui/material/CssBaseline";
import Typography from "@mui/material/Typography";
import LoginIcon from "@mui/icons-material/LoginOutlined";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import Grid from "@mui/material/Grid";
import { useState } from "react";
import axios from "axios";
import {
  ValidateNumeric,
  ValidateNumericLoan,
  ValidateLetters,
  ValidateEmail,
  ValidateDates,
  ValidatePassword,
} from "../data/HelperFunctions";
import AttachMoneyIcon from "@mui/icons-material/AttachMoney";
import {
  CREATE_INQUIRY_ENDPOINT_ADDRESS,
  SEND_REQUEST_ENDPOINT_ADDRESS,
} from "../ConnectionVariables";
import {
  InquiryDetails,
  GovernmentDocumentTypes,
  JobTypes,
  OfferDetails,
  BankNames,
} from "../data/Types";
import { CircularProgress, Fade, Stack } from "@mui/material";
import { document } from "../assets/document";
import { DesktopDatePicker } from "@mui/x-date-pickers/DesktopDatePicker";
import Autocomplete from "@mui/material/Autocomplete";
import Person2Icon from "@mui/icons-material/Person2";
import {
  SEND_ANONYMOUS_REQUEST_ENDPOINT_ADDRESS,
  CREATE_ANONYMOUS_INQUIRY_ENDPOINT_ADDRESS,
} from "../ConnectionVariables";

export const InquiryForm: React.FC = () => {
  const [userName, setUserName] = useState("");
  const [userSurname, setUserSurname] = useState("");
  const [email, setEmail] = useState("");
  const [jobType, setJobType] = useState("");
  const [jobStartDate, setJobStartDate] = useState("01/01/2022");
  const [jobEndDate, setJobEndDate] = useState("02/01/2022");
  const [incomeLevel, setIncomeLevel] = useState("");
  const [governmentIdType, setGovernmentIdType] = useState("");
  const [governmentId, setGovernmentId] = useState("");
  const [birthDate, setBirthDate] = useState("02/09/2000");
  const [moneyAmount, setMoneyAmount] = useState("");
  const [installmentsAmount, setInstallmentsAmount] = useState("");
  const [errorMessage, setErrorMessage] = useState("");
  const [loading, setLoading] = useState(false);
  const [userLogged, setUserLogged] = useRecoilState(UserData);
  const [selection, setSelection] = useState(false);
  const [offers, setOffers] = useState([{} as OfferDetails]);

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    setErrorMessage("");
    setLoading(true);
    event.preventDefault();
    if (userLogged.accountType == "simple") {
      const config = {
        headers: { Authorization: `Bearer ${userLogged.token}` },
      };
      const inquiryObject = {
        value: Number.parseInt(moneyAmount),
        installmentsNumber: Number.parseInt(installmentsAmount),
        personalData: {
          firstName: userLogged.firstName,
          lastName: userLogged.lastName,
          birthDate: userLogged.birthDate,
        },
        governmentDocument: {
          typeId: Number.parseInt(
            Object.keys(GovernmentDocumentTypes)[
              Object.values(GovernmentDocumentTypes).indexOf(
                userLogged.governmentIdType
              ) as GovernmentDocumentTypes
            ]
          ),
          name: "name",
          description: "description",
          number: userLogged.governmentId,
        },
        jobDetails: {
          typeId: Number.parseInt(
            Object.keys(JobTypes)[Object.values(JobTypes).indexOf(userLogged.jobType) as JobTypes]
          ),
          name: "name",
          description: "description",
          jobStartDate: userLogged.jobStartDate,
          jobEndDate: userLogged.jobEndDate,
        },
      } as InquiryDetails;
      axios
        .post(CREATE_INQUIRY_ENDPOINT_ADDRESS, inquiryObject, config)
        .then((res) => {
          console.log(res);
          setOffers(res.data.offers);
          // WHY THIS ENDPOINT SAVES INQUIRY IF I AM SUPPOSED TO DISPLAY AVAILABLE LOANS OPTIONS AND CHOOSE ONE???
          setLoading(false);
          setSelection(true);
        })
        .catch((res) => {
          console.log(res);
          setErrorMessage("Inquiry sending error");
          setLoading(false);
        });
    } else if (userLogged.accountType == "guest") {
      const inquiryObject = {
        value: Number.parseInt(moneyAmount),
        installmentsNumber: Number.parseInt(installmentsAmount),
        personalData: {
          firstName: userName,
          lastName: userSurname,
          birthDate: new Date(birthDate),
        },
        governmentDocument: {
          typeId: Number.parseInt(
            Object.keys(GovernmentDocumentTypes)[
              Object.values(GovernmentDocumentTypes).indexOf(
                governmentIdType
              ) as GovernmentDocumentTypes
            ]
          ),
          name: "name",
          description: "description",
          number: governmentId,
        },
        jobDetails: {
          typeId: Number.parseInt(
            Object.keys(JobTypes)[Object.values(JobTypes).indexOf(jobType) as JobTypes]
          ),
          name: "name",
          description: "description",
          jobStartDate: new Date(jobStartDate),
          jobEndDate: new Date(jobEndDate),
        },
      } as InquiryDetails;
      axios
        .post(CREATE_ANONYMOUS_INQUIRY_ENDPOINT_ADDRESS, inquiryObject)
        .then((res) => {
          console.log(res);
          setOffers(res.data.offers);
          setSelection(true);
          setLoading(false);
        })
        .catch((res) => {
          console.log(res);
          setErrorMessage("Inquiry sending error");
          setLoading(false);
        });
    }
  };

  const onSelection = (index: number) => {
    let file = new File([document] as BlobPart[], "formFile");
    let formFile = new FormData();
    formFile.append("id", offers[index].id);
    formFile.append("inquiryId", offers[index].inquiryId);
    formFile.append("bankId", (offers[index].bankId as number).toString());
    formFile.append("externalOfferId", offers[index].externalOfferId);
    formFile.append("formFile", file, "formFile");
    if (userLogged.accountType == "simple") {
      const config = {
        headers: { Authorization: `Bearer ${userLogged.token}` },
      };
      axios
        .post(SEND_REQUEST_ENDPOINT_ADDRESS, formFile, config)
        .then((res) => {
          console.log(res);
          setErrorMessage("Request sent successfully!");
        })
        .catch((res) => {
          console.log(res);
        });
      setSelection(false);
    } else if (userLogged.accountType == "guest") {
      // GUEST REQUEST SENDING
      formFile.append("email", email);
      console.log(
        email,
        file,
        offers[index].externalOfferId,
        (offers[index].bankId as number).toString(),
        offers[index].inquiryId,
        offers[index].id
      );
      axios
        .post(SEND_ANONYMOUS_REQUEST_ENDPOINT_ADDRESS, formFile)
        .then((res) => {
          console.log(res);
          setErrorMessage("Success! Offer ID: " + [offers[index].id]);
        })
        .catch((res) => {
          console.log(res);
          setErrorMessage("Error occured while sending request");
        });
      setSelection(false);
    }
  };

  return (
    <Box>
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 3,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <Typography variant="h5" mb={3} style={{ fontWeight: 3 }} color="error">
            {errorMessage}
          </Typography>
          {!selection && (
            <AttachMoneyIcon sx={{ marginBottom: "20px", height: "60px", width: "60px" }} />
          )}
          {!selection && (
            <Typography component="h1" variant="h5">
              Enter loan details
            </Typography>
          )}
          {!selection && (
            <Box component="form" onSubmit={handleSubmit} sx={{ mt: 1 }}>
              <TextField
                margin="normal"
                required
                fullWidth
                id="moneyAmount"
                label="Loan Value"
                name="moneyAmount"
                value={moneyAmount}
                autoFocus
                onChange={(x) => setMoneyAmount(x.target.value)}
                error={!ValidateNumericLoan(moneyAmount)}
                helperText={
                  !ValidateNumericLoan(moneyAmount) && "Only numeric values higher than 0"
                }
              />
              <TextField
                margin="normal"
                required
                fullWidth
                name="installmentsAmount"
                label="Installments Number"
                id="installmentsAmount"
                value={installmentsAmount}
                onChange={(x) => setInstallmentsAmount(x.target.value)}
                error={!ValidateNumericLoan(installmentsAmount)}
                helperText={
                  !ValidateNumericLoan(installmentsAmount) &&
                  "Password too weak (must be at least 8-character long and contain one lower case letter, one upper case letter, one number and one special character)"
                }
              />
              {userLogged.accountType == "guest" && (
                <Box component="form" onSubmit={handleSubmit} sx={{ mt: 3 }}>
                  <Person2Icon sx={{ alignSelf: "center", height: "60px", width: "60px" }} />
                  <Typography sx={{ alignSelf: "center" }} component="h1" variant="h5">
                    Fill personal information
                  </Typography>
                  <Grid container spacing={2}>
                    <Grid width="100%" item marginBottom={1}></Grid>
                    <Grid item xs={12} sm={6}>
                      <TextField
                        autoComplete="given-name"
                        name="firstName"
                        required
                        fullWidth
                        id="firstName"
                        label="First Name"
                        autoFocus
                        value={userName}
                        onChange={(x) => setUserName(x.target.value)}
                        error={!ValidateLetters(userName)}
                        helperText={
                          !ValidateLetters(userName) &&
                          "Only letter allowed, must start with uppercase letter"
                        }
                      />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <TextField
                        required
                        fullWidth
                        id="lastName"
                        label="Last Name"
                        name="lastName"
                        autoComplete="family-name"
                        value={userSurname}
                        onChange={(x) => setUserSurname(x.target.value)}
                        error={!ValidateLetters(userSurname)}
                        helperText={
                          !ValidateLetters(userSurname) &&
                          "Only letter allowed, must start with uppercase letter"
                        }
                      />
                    </Grid>
                    <Grid item xs={12}>
                      <TextField
                        required
                        fullWidth
                        id="email"
                        label="Email Address"
                        name="email"
                        autoComplete="email"
                        value={email}
                        onChange={(x) => setEmail(x.target.value)}
                        error={!ValidateEmail(email)}
                        helperText={!ValidateEmail(email) && "Wrong email format"}
                      />
                    </Grid>
                    <Grid item xs={12}>
                      <DesktopDatePicker
                        label="Birth date"
                        inputFormat="MM/DD/YYYY"
                        value={birthDate}
                        onChange={(x: any) => setBirthDate(x)}
                        renderInput={(params: any) => (
                          <TextField
                            {...params}
                            sx={{ width: "100%" }}
                            // helperText="MM/DD/YYYY"
                          />
                        )}
                      />
                    </Grid>
                    <Grid item xs={12}>
                      <Autocomplete
                        disablePortal
                        fullWidth
                        id="jobType"
                        options={Object.values(JobTypes).slice(
                          0,
                          Object.values(JobTypes).length / 2
                        )}
                        renderInput={(params) => <TextField {...params} label="Job Type" />}
                        value={jobType}
                        onChange={(event, value) => {
                          setJobType(value as string);
                        }}
                      />
                    </Grid>
                    <Grid item xs={6}>
                      <DesktopDatePicker
                        label="Job start date"
                        inputFormat="MM/DD/YYYY"
                        value={jobStartDate}
                        onChange={(x: any) => setJobStartDate(x)}
                        renderInput={(params: any) => (
                          <TextField
                            {...params}
                            error={ValidateDates(jobStartDate, jobEndDate)}
                            helperText={
                              ValidateDates(jobStartDate, jobEndDate) &&
                              "Job starts later than ends"
                            }
                          />
                        )}
                      />
                    </Grid>
                    <Grid item xs={6}>
                      <DesktopDatePicker
                        label="Job end date"
                        inputFormat="MM/DD/YYYY"
                        value={jobEndDate}
                        onChange={(x: any) => setJobEndDate(x)}
                        renderInput={(params: any) => (
                          <TextField
                            {...params}
                            error={ValidateDates(jobStartDate, jobEndDate)}
                            helperText={
                              ValidateDates(jobStartDate, jobEndDate) &&
                              "Job ends earlier than starts"
                            }
                          />
                        )}
                      />
                    </Grid>
                    <Grid item xs={12}>
                      <TextField
                        required
                        fullWidth
                        name="incomeLevel"
                        label="Income Level"
                        type="incomeLevel"
                        id="incomeLevel"
                        autoComplete="new-password"
                        value={incomeLevel}
                        onChange={(x) => setIncomeLevel(x.target.value)}
                        error={!ValidateNumeric(incomeLevel)}
                        helperText={!ValidateNumeric(incomeLevel) && "Only numbers allowed"}
                      />
                    </Grid>
                    <Grid item xs={12}>
                      <Autocomplete
                        disablePortal
                        fullWidth
                        id="governmentIdType"
                        options={Object.values(GovernmentDocumentTypes).slice(
                          0,
                          Object.values(GovernmentDocumentTypes).length / 2
                        )}
                        renderInput={(params) => (
                          <TextField {...params} label="Government ID Type" />
                        )}
                        value={governmentIdType}
                        onChange={(event, value) => {
                          setGovernmentIdType(value as string);
                        }}
                      />
                    </Grid>
                    <Grid item xs={12}>
                      <TextField
                        required
                        fullWidth
                        name="governmentId"
                        label="Government ID"
                        type="governmentId"
                        id="governmentId"
                        autoComplete="new-password"
                        value={governmentId}
                        onChange={(x) => setGovernmentId(x.target.value)}
                      />
                    </Grid>
                  </Grid>
                </Box>
              )}
              <Button type="submit" fullWidth variant="contained" sx={{ mt: 3, mb: 2 }}>
                Submit
              </Button>
              <Box mt={3} sx={{ height: 40 }}></Box>
              <Grid spacing={1} container>
                <Grid width="100%" item></Grid>
                <Grid width="100%" item></Grid>
              </Grid>
            </Box>
          )}
        </Box>
        {selection && (
          <Box>
            <Typography mb={2} component="h1" variant="h5">
              Choose offer
            </Typography>
            <Stack direction="column" spacing={2}>
              {offers.map((value, index) => {
                return (
                  <Box
                    padding={1}
                    sx={{
                      "&:hover": { backgroundColor: "primary.main", opacity: [0.9, 0.8, 0.7] },
                      border: "1px solid #1565c0",
                    }}
                    borderRadius={2}
                    onClick={() => onSelection(index)}
                  >
                    <Typography mb={1} variant="h6">
                      {BankNames[value.bankId]} offer
                    </Typography>
                    <Typography mb={1}>Percentage: {value.percentage}</Typography>
                    <Typography>Monthly installment: {value.monthlyInstallment}</Typography>
                  </Box>
                );
              })}
            </Stack>
          </Box>
        )}
        <Fade in={loading} unmountOnExit>
          <CircularProgress sx={{ marginBottom: 20 }} />
        </Fade>
      </Container>
    </Box>
  );
};
