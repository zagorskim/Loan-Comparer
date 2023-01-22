import Box from "@mui/material/Box";
import { Stack } from "@mui/material";
import Typography from "@mui/material/Typography";
import { Outlet, useNavigate } from "react-router-dom";
import { useRecoilState } from "recoil";
import { UserData } from "./../data/UserData";
import Grid from "@mui/material/Grid";
import { UserLogged } from "../../../../../../../React/Parkly semester project/Repo/frontend/src/data/AppModeData";
import Person2Icon from "@mui/icons-material/Person2";
import Divider from "@mui/material/Divider";

export const ProfilePage: React.FC = () => {
  const [userLogged, setUserLogged] = useRecoilState(UserData);
  console.log(userLogged);
  return (
    <Box margin="auto" width="30%">
      <Stack marginTop="100px" spacing={1}>
        <Person2Icon sx={{ alignSelf: "center", height: "80px", width: "80px" }} />
        <Typography sx={{ alignSelf: "center" }} component="h1" variant="h5">
          Profile details
        </Typography>
        <Box sx={{ border: "1px solid #1565c0" }} borderRadius={1}>
          <Grid>
            <Grid item xs={12}>
              <Typography ml={2} align="left" variant="h6">
                Name: {userLogged.firstName}
              </Typography>
            </Grid>
            <Divider variant="middle"></Divider>
            <Grid ml={2} item xs={12}>
              <Typography align="left" variant="h6">
                Surname: {userLogged.lastName}
              </Typography>
            </Grid>
            <Divider variant="middle"></Divider>

            <Grid ml={2} item xs={12}>
              <Typography align="left" variant="h6">
                Email: {userLogged.email}
              </Typography>
            </Grid>
            <Divider variant="middle"></Divider>

            <Grid ml={2} item xs={12}>
              <Typography align="left" variant="h6">
                Birth date: {new Date(userLogged.birthDate).toDateString()}
              </Typography>
            </Grid>
            <Divider variant="middle"></Divider>

            <Grid ml={2} item xs={12}>
              <Typography align="left" variant="h6">
                Job: {userLogged.jobType.toString()}
              </Typography>
            </Grid>
            <Divider variant="middle"></Divider>

            <Grid ml={2} item xs={12}>
              <Typography align="left" variant="h6">
                Job started: {new Date(userLogged.jobStartDate).toDateString()}
              </Typography>
            </Grid>
            <Divider variant="middle"></Divider>

            <Grid ml={2} item xs={12}>
              <Typography align="left" variant="h6">
                Employed until: {new Date(userLogged.jobEndDate).toDateString()}
              </Typography>
            </Grid>
            <Divider variant="middle"></Divider>

            <Grid ml={2} item xs={12}>
              <Typography align="left" variant="h6">
                Account type: {userLogged.accountType}
              </Typography>
            </Grid>
            <Divider variant="middle"></Divider>

            <Grid ml={2} item xs={12}>
              <Typography align="left" variant="h6">
                Government ID type: {userLogged.governmentIdType.toString()}
              </Typography>
            </Grid>
            <Divider variant="middle"></Divider>

            <Grid ml={2} item xs={12}>
              <Typography align="left" variant="h6">
                Government ID code: {userLogged.governmentId}
              </Typography>
            </Grid>
          </Grid>
        </Box>
      </Stack>
      <Outlet />
    </Box>
  );
};
