import * as React from "react";
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import TextField from "@mui/material/TextField";
import FormControlLabel from "@mui/material/FormControlLabel";
import Checkbox from "@mui/material/Checkbox";
import Link from "@mui/material/Link";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import RegisterIcon from "@mui/icons-material/AccountBoxOutlined";
import GoogleLogin from "react-google-login";
import { useState } from "react";
import { UserData, GoogleAuthData } from "../data/UserData";
import { JobTypes, UserDetails, GovernmentDocumentTypes } from "../data/Types";
import { DesktopDatePicker } from "@mui/x-date-pickers/DesktopDatePicker";
import { DatePicker } from "@mui/x-date-pickers";
import Select from "@mui/material/Select";
import Autocomplete from "@mui/material/Autocomplete";
import { useNavigate } from "react-router-dom";
import { useRecoilState } from "recoil";
import {
  ValidatePassword,
  ValidateEmail,
  ValidateNumeric,
  ValidateLetters,
  ValidateDates,
} from "../data/HelperFunctions";
import axios from "axios";
import {
  REGISTER_ENDPOINT_ADDRESS,
  EXT_REGISTER_ENDPOINT_ADDRESS,
  LOGIN_ENDPOINT_ADDRESS,
} from "../ConnectionVariables";
import { GOOGLE_CLIENT_ID as clientId, EXT_LOGIN_ENDPOINT_ADDRESS } from "../ConnectionVariables";
import { json } from "stream/consumers";

export const RegisterPage: React.FC = () => {
  const [userData, setUserData] = useState({});
  const [userName, setUserName] = useState("");
  const [userSurname, setUserSurname] = useState("");
  const [email, setEmail] = useState("");
  const [jobType, setJobType] = useState("");
  const [jobStartDate, setJobStartDate] = useState("01/01/2022");
  const [jobEndDate, setJobEndDate] = useState("02/01/2022");
  const [incomeLevel, setIncomeLevel] = useState("");
  const [governmentIdType, setGovernmentIdType] = useState("");
  const [governmentId, setGovernmentId] = useState("");
  const [password, setPassword] = useState("");
  const [repeatPassword, setRepeatPassword] = useState("");
  const [googleRegister, setGoogleRegister] = useState(false);
  const [birthDate, setBirthDate] = useState("02/09/2000");
  const [userLogged, setUserLogged] = useRecoilState(UserData);
  const [googleAuthData, setGoogleAuthData] = useRecoilState(GoogleAuthData);
  const [errorMessage, setErrorMessage] = useState("");
  const navigate = useNavigate();

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    setErrorMessage("");
    event.preventDefault();
    if (!googleRegister) {
      let tempData = {
        firstName: userName,
        lastName: userSurname,
        email: email,
        jobType: Number.parseInt(
          Object.keys(JobTypes)[Object.values(JobTypes).indexOf(jobType) as JobTypes]
        ),
        jobStartDate: new Date(jobStartDate),
        jobEndDate: new Date(jobEndDate),
        levelIncome: Number.parseInt(incomeLevel),
        governmentIdType: Number.parseInt(
          Object.keys(GovernmentDocumentTypes)[
            Object.values(GovernmentDocumentTypes).indexOf(
              governmentIdType
            ) as GovernmentDocumentTypes
          ]
        ),
        governmentId: governmentId,
        password: password,
        confirmPassword: repeatPassword,
        birthDate: new Date(birthDate),
      };
      console.log(tempData);
      setUserData(tempData);
      axios
        .post(REGISTER_ENDPOINT_ADDRESS, tempData)
        .then((res) => {
          alert("Successfully registered!");
          navigate("/");
        })
        .catch((res) => console.log(res));
    } else {
      let tempData = {
        firstName: userName,
        lastName: userSurname,
        jobType: Number.parseInt(
          Object.keys(JobTypes)[Object.values(JobTypes).indexOf(jobType) as JobTypes]
        ),
        jobStartDate: new Date(jobStartDate),
        jobEndDate: new Date(jobEndDate),
        levelIncome: Number.parseInt(incomeLevel),
        governmentIdType: Number.parseInt(
          Object.keys(GovernmentDocumentTypes)[
            Object.values(GovernmentDocumentTypes).indexOf(
              governmentIdType
            ) as GovernmentDocumentTypes
          ]
        ),
        governmentId: governmentId,
        birthDate: new Date(birthDate),
      };
      console.log(tempData);
      let config = {
        headers: { Authorization: `Bearer ${(googleAuthData as any).tokenId}` },
      };
      axios
        .post(EXT_REGISTER_ENDPOINT_ADDRESS, tempData, config)
        .then((res) => {
          console.log(res);
          //TBD: set user data
          // setUserData({});
          alert("Successfully registered!");
          navigate("/");
        })
        .catch((res) => {
          setErrorMessage("Registration failed");
          console.log(res);
        });
    }
  };

  const onSuccess = (res: any) => {
    setErrorMessage("");
    // TBD: verification of already existing account
    const temp = {
      firstName: res.profileObj.givenName,
      lastName: res.profileObj.familyName,
      email: res.profileObj.email,
    };
    setGoogleAuthData(res);
    let config = {
      headers: { Authorization: `Bearer ${res.tokenId}` },
    };
    axios
      .post(EXT_LOGIN_ENDPOINT_ADDRESS, {}, config)
      .then((res) => {
        console.log(res);
        if (res.data == "Need to register.") {
          console.log(googleAuthData);
          setGoogleRegister(true);
          setUserName(temp.firstName);
          setUserSurname(temp.lastName);
          setEmail(temp.email);
          (document.getElementById("email") as any).disabled = true;
        } else setErrorMessage("Account already registered");
        // TBD: normal external login
      })
      .catch((res) => {
        console.log(res);
        setErrorMessage("Google authentication failed");
      });
    // TBD: use localStorage to keep account info and fetch when refreshing etc.
  };
  const onFailure = (err: any) => {
    console.log("failed:", err);
  };

  return (
    <Box>
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <Typography variant="h5" mb={3} style={{ fontWeight: 3 }} color="error">
            {errorMessage}
          </Typography>
          <RegisterIcon sx={{ marginBottom: "20px", height: "60px", width: "60px" }} />
          <Typography component="h1" variant="h5">
            {!googleRegister ? "Sign up" : "Fill account details"}
          </Typography>
          <Box component="form" onSubmit={handleSubmit} sx={{ mt: 3 }}>
            <Grid container spacing={2}>
              <Grid width="100%" item marginBottom={1}>
                {!googleRegister && (
                  <GoogleLogin
                    clientId={clientId}
                    buttonText="Sign up with Google"
                    onSuccess={onSuccess}
                    onFailure={onFailure}
                    cookiePolicy={"single_host_origin"}
                    isSignedIn={false}
                  ></GoogleLogin>
                )}
              </Grid>
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
                  options={Object.values(JobTypes).slice(0, Object.values(JobTypes).length / 2)}
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
                        ValidateDates(jobStartDate, jobEndDate) && "Job starts later than ends"
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
                        ValidateDates(jobStartDate, jobEndDate) && "Job ends earlier than starts"
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
                  renderInput={(params) => <TextField {...params} label="Government ID Type" />}
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
              {!googleRegister && (
                <Grid item xs={6}>
                  <TextField
                    required
                    fullWidth
                    name="password"
                    label="Password"
                    type="password"
                    id="password"
                    autoComplete="new-password"
                    value={password}
                    onChange={(x) => setPassword(x.target.value)}
                    error={!ValidatePassword(password)}
                    helperText={
                      !ValidatePassword(password) &&
                      "Password too weak (must be at least 8-character long and contain one lower case letter, one upper case letter, one number and one special character)"
                    }
                  />
                </Grid>
              )}
              {!googleRegister && (
                <Grid item xs={6}>
                  <TextField
                    required
                    fullWidth
                    name="repeatPassword"
                    label="Repeat Password"
                    type="password"
                    id="repeatPassword"
                    autoComplete="new-password"
                    value={repeatPassword}
                    onChange={(x) => setRepeatPassword(x.target.value)}
                    error={repeatPassword != password && repeatPassword != ""}
                    helperText={
                      repeatPassword != password &&
                      repeatPassword != "" &&
                      "Entry doesn't match password"
                    }
                  />
                </Grid>
              )}
            </Grid>
            <Button type="submit" fullWidth variant="contained" sx={{ mt: 3, mb: 2 }}>
              Sign Up
            </Button>
            <Grid container>
              <Grid item xs={12}>
                <Link pb={10} href="login" variant="body2">
                  Already have an account? Sign in
                </Link>
              </Grid>
            </Grid>
          </Box>
        </Box>
      </Container>
    </Box>
  );
};
