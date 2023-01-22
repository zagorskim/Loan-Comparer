import { Box, Stack } from "@mui/material";
import { Button } from "@mui/material/";
import { width } from "@mui/system";
import { useRecoilState } from "recoil";
import { UserData } from "./../data/UserData";
import { useNavigate, Outlet } from "react-router-dom";
import { UserDetails } from "../data/Types";
import { useEffect } from "react";
import { ACCOUNT_COUNT_ENDPOINT_ADDRESS } from "../ConnectionVariables";
import axios from "axios";
import { useState } from "react";
import Typography from "@mui/material/Typography";
import Person2Icon from "@mui/icons-material/Person2";

export const SessionChoicePage: React.FC = () => {
  const [userLogged, setUserLogged] = useRecoilState(UserData);
  const [usersCount, setUsersCount] = useState("");

  const navigate = useNavigate();

  useEffect(() => {
    sessionStorage.setItem("guest", "false");
    setUserLogged({} as UserDetails);
    sessionStorage.removeItem("email");
    sessionStorage.removeItem("token");
    axios
      .get(ACCOUNT_COUNT_ENDPOINT_ADDRESS)
      .then((res) => {
        setUsersCount(res.data);
      })
      .catch((res) => console.log(res));
  }, []);
  return (
    <Box margin="auto" width="30%">
      <Stack marginTop="100px" spacing={3}>
        <Box sx={{ border: "1px solid #1565c0" }} borderRadius={3}>
          <Typography ml={1} mt={1} textAlign="left">
            It is a website used for comparing different banks' offers for loans.
          </Typography>
          <Typography ml={1} mt={1} textAlign="left">
            A user can send an inquiry for a loan (with specified money amount, income etc.), then
            get offers from three different banks and choose one.
          </Typography>
          <Typography mt={1} mb={1} variant="h6">
            Number of accounts registered: {usersCount}.
          </Typography>
        </Box>
        <Button sx={{ height: 50 }} variant="contained" onClick={() => navigate("login")}>
          Log in
        </Button>
        <Button
          sx={{ height: 50 }}
          variant="outlined"
          onClick={() => {
            const temp = { accountType: "guest", firstName: "", lastName: "" } as UserDetails;
            sessionStorage.setItem("guest", "true");
            setUserLogged(temp);
            navigate("guest");
          }}
        >
          Continue as a guest
        </Button>
        <Button
          sx={{ height: 50 }}
          variant="outlined"
          onClick={() => {
            navigate("register");
          }}
        >
          Register
        </Button>
      </Stack>
      <Outlet />
    </Box>
  );
};

// import { render, screen, cleanup } from "@testing-library/react";
// // Importing the jest testing library
// import '@testing-library/jest-dom'
// import { SessionChoicePage } from './SessionChoicePage';

// // afterEach function runs after each test suite is executed
// afterEach(() => {
//     cleanup(); // Resets the DOM after each test suite
// })

// describe("Button Component" ,() => {
//     const setToggle= jest.fn();
//     render(<SessionChoicePage/>);
//     const button = screen.getByTestId("button");

//     // Test 1
//     test("Button Rendering", () => {
//         expect(button).toBeInTheDocument();
//     })

//     // Test 2
//     test("Button1 Text", () => {
//         expect(button).toHaveTextContent("Log in");
//     })

//         // Test 3
//         test("Button2 Text", () => {
//             expect(button).toHaveTextContent("Continue as a guest");
//         })

//             // Test 4
//     test("Button3 Text", () => {
//         expect(button).toHaveTextContent("Click Me!");
//     })
// })
