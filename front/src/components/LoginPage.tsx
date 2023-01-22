import * as React from "react";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import TextField from "@mui/material/TextField";
import Link from "@mui/material/Link";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import GoogleButton from "react-google-button";
import LoginIcon from "@mui/icons-material/LoginOutlined";
import { useNavigate } from "react-router-dom";
import { useRecoilState } from "recoil";
import { UserData } from "./../data/UserData";
import { GoogleLogin } from "react-google-login";
import { gapi } from "gapi-script";
import { useEffect } from "react";
import { GoogleAuthData } from "../data/UserData";
import { UserDetails } from "../data/Types";
import { ValidateEmail, ValidatePassword } from "../data/HelperFunctions";
import { useState } from "react";
import axios from "axios";
import { EXT_LOGIN_ENDPOINT_ADDRESS, GOOGLE_CLIENT_ID as clientId } from "../ConnectionVariables";
import { LOGIN_ENDPOINT_ADDRESS } from "../ConnectionVariables";
import { ACCOUNT_COUNT_ENDPOINT_ADDRESS } from "../ConnectionVariables";
import { ACCOUNT_INFO_ENDPOINT_ADDRESS } from "../ConnectionVariables";
import { string } from "yargs";

export const LoginPage: React.FC = () => {
  const [userLogged, setUserLogged] = useRecoilState(UserData);
  const [googleAuthData, setGoogleAuthData] = useRecoilState(GoogleAuthData);
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [token, setToken] = useState("");
  const [errorMessage, setErrorMessage] = useState("");
  const navigate = useNavigate();

  useEffect(() => {
    sessionStorage.setItem("guest", "false");
    setUserLogged({} as UserDetails);
    sessionStorage.removeItem("email");
    sessionStorage.removeItem("token");
    const initClient = () => {
      gapi.client.init({
        clientId: clientId,
        scope: "",
      });
    };
    gapi.load("client: auth2", initClient);
  }, []);

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    setErrorMessage("");
    event.preventDefault();

    const data = new FormData(event.currentTarget);
    await axios
      .post(LOGIN_ENDPOINT_ADDRESS, { email: data.get("email"), password: data.get("password") })
      .then((res) => {
        setToken(res.data);
        return res.data;
      })
      .then((res) => {
        const token = res;
        sessionStorage.setItem("token", token);
        sessionStorage.setItem("email", data.get("email") as string);
        const config = {
          headers: { Authorization: `Bearer ${res}` },
        };
        axios
          .get(ACCOUNT_INFO_ENDPOINT_ADDRESS, config)
          .then((res) => {
            console.log(res.data);
            setUserLogged({
              firstName: res.data.firstName,
              creationDate: res.data.creationDate,
              governmentId: res.data.governmentId,
              governmentIdType: res.data.governmentIdType,
              jobEndDate: res.data.jobEndDate,
              jobStartDate: res.data.jobStartDate,
              jobType: res.data.jobType,
              lastName: res.data.lastName,
              levelIncome: res.data.levelIncome,
              accountType: (res.data.role as string).toLowerCase(),
              email: data.get("email") as string,
              token: token,
              birthDate: new Date(res.data.birthDate),
            });
            navigate("/home");
          })
          .catch((res) => {
            console.log(res);
          });
        // TBD: use localStorage to keep account info and fetch when refreshing etc.
      })
      .catch((res) => {
        console.log(res);
        if (res.code == "ERR_BAD_REQUEST") setErrorMessage("Wrong credentials");
        else setErrorMessage("Authentication error");
      });
  };

  const onSuccess = (res: any) => {
    setErrorMessage("");
    // FETCHING LOGGED USER DATA FROM BACKEND AND REGISTRATION VERIFICATION TO BE IMPLEMENTED
    const temp = {
      email: res.profileObj.email,
      firstName: res.profileObj.givenName,
      lastName: res.profileObj.familyName,
    };
    setGoogleAuthData(res);
    let config = {
      headers: { Authorization: `Bearer ${res.tokenId}` },
    };
    axios
      .post(EXT_LOGIN_ENDPOINT_ADDRESS, {}, config)
      .then((res) => {
        // TBD: Fill config with retrieved token and get user data from backend
        config = {
          headers: { Authorization: `Bearer ${res.data}` },
        };
        if (res.data == "Need to register.") setErrorMessage("Not registered");
        else {
          const token = res.data;
          sessionStorage.setItem("token", token);
          sessionStorage.setItem("email", temp.email);
          axios
            .get(ACCOUNT_INFO_ENDPOINT_ADDRESS, config)
            .then((res) => {
              console.log(res.data);
              setUserLogged({
                firstName: temp.firstName,
                creationDate: res.data.creationDate,
                governmentId: res.data.governmentId,
                governmentIdType: res.data.governmentIdType,
                jobEndDate: res.data.jobEndDate,
                jobStartDate: res.data.jobStartDate,
                jobType: res.data.jobType,
                lastName: temp.lastName,
                levelIncome: res.data.levelIncome,
                accountType: (res.data.role as String).toLowerCase(),
                email: temp.email,
                token: token,
                birthDate: res.data.birthDate,
              });
              navigate("/home");
            })
            .catch((res) => {
              console.log(res);
              if (res.code == "ERR_BAD_REQUEST") setErrorMessage("Wrong credentials");
              else setErrorMessage("Authentication error");
            });
        }
        // TBD: use localStorage to keep account info and fetch when refreshing etc.
      })
      .catch((res) => {
        setErrorMessage("Google account not registered");
        console.log(res);
      });
  };
  const onFailure = (err: any) => {
    setErrorMessage("Google authentication failed");
    console.log("failed:", err);
  };

  return (
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
        <LoginIcon sx={{ marginBottom: "20px", height: "60px", width: "60px" }} />
        <Typography component="h1" variant="h5">
          Sign in
        </Typography>
        <Box component="form" onSubmit={handleSubmit} sx={{ mt: 1 }}>
          <TextField
            margin="normal"
            required
            fullWidth
            id="email"
            label="Email Address"
            name="email"
            value={email}
            autoComplete="email"
            autoFocus
            onChange={(x) => setEmail(x.target.value)}
            error={!ValidateEmail(email)}
            helperText={!ValidateEmail(email) && "Wrong email format"}
          />
          <TextField
            margin="normal"
            required
            fullWidth
            name="password"
            label="Password"
            type="password"
            id="password"
            autoComplete="current-password"
            onChange={(x) => setPassword(x.target.value)}
            error={!ValidatePassword(password)}
            helperText={
              !ValidatePassword(password) &&
              "Password too weak (must be at least 8-character long and contain one lower case letter, one upper case letter, one number and one special character)"
            }
          />
          {/* <FormControlLabel
                    control={<Checkbox value="remember" color="primary" />}
                    label="Remember me"
                    /> */}
          <Button type="submit" fullWidth variant="contained" sx={{ mt: 3, mb: 2 }}>
            Sign In
          </Button>
          <Grid spacing={1} container>
            {/* <Grid item xs>
                        <Link href="#" variant="body2">
                        Forgot password?
                        </Link>
                    </Grid> */}
            <Grid width="100%" item>
              <GoogleLogin
                clientId={clientId}
                buttonText="Sign in with Google"
                onSuccess={onSuccess}
                onFailure={onFailure}
                cookiePolicy={"single_host_origin"}
                isSignedIn={false}
              />
            </Grid>
            <Grid width="100%" item>
              <Link href="register" variant="body2">
                {"Don't have an account? Sign Up"}
              </Link>
            </Grid>
          </Grid>
        </Box>
      </Box>
    </Container>
  );
};
