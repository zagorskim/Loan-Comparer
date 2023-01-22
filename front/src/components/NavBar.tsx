import * as React from "react";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import IconButton from "@mui/material/IconButton";
import Typography from "@mui/material/Typography";
import Menu from "@mui/material/Menu";
import MenuIcon from "@mui/icons-material/Menu";
import Container from "@mui/material/Container";
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import Tooltip from "@mui/material/Tooltip";
import MenuItem from "@mui/material/MenuItem";
import AppIcon from "@mui/icons-material/RequestPage";
import { useRecoilState } from "recoil";
import { useRecoilValue } from "recoil";
import { NavBarProfile, NavBarSubpages } from "../data/AppModeData";
import Divider from "@mui/material/Divider";
import { width } from "@mui/system";
import { UserData } from "./../data/UserData";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Stack } from "@mui/material";
import { GoogleAuthData } from "../data/UserData";
import { UserDetails } from "../data/Types";
import { useGoogleLogout } from "react-google-login";
import axios from "axios";
import { ACCOUNT_INFO_ENDPOINT_ADDRESS } from "../ConnectionVariables";

const pages1 = ["NEW INQUIRY"];
const pages2 = [] as Array<string>;
const pages3 = ["FIND REQUEST"] as Array<string>;
const pages4 = [] as Array<string>;
const pages5 = [] as Array<string>;
const settings1 = ["Profile", "Logout"];

// MUI template navigation bar
export const NavBar: React.FC = () => {
  const [anchorElNav, setAnchorElNav] = React.useState<null | HTMLElement>(null);
  const [anchorElUser, setAnchorElUser] = React.useState<null | HTMLElement>(null);
  const [userLogged, setUserLogged] = useRecoilState(UserData);
  const [googleAuthData, setGoogleAuthData] = useRecoilState(GoogleAuthData);

  const profileState = useRecoilValue(NavBarProfile);
  const pagesState = useRecoilValue(NavBarSubpages);
  const navigate = useNavigate();

  const handleOpenNavMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElNav(event.currentTarget);
  };
  const handleOpenUserMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElUser(event.currentTarget);
  };

  const handleCloseNavMenu = () => {
    setAnchorElNav(null);
  };

  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };

  const newInquiryHandler = () => {
    if (userLogged.accountType == "guest") navigate("/guest/inquiry");
    else navigate("/home/inquiry");
  };

  const findRequestHandler = () => {
    navigate("/guest/search");
  };
  const logoutHandler = () => {
    const temp = {} as UserDetails;
    setUserLogged(temp);
    setGoogleAuthData({});
    //signOut();
    sessionStorage.removeItem("email");
    sessionStorage.removeItem("token");
    navigate("/");
  };

  const profileHandler = () => {
    navigate("profile");
  };

  //const { signOut, loaded } = useGoogleLogout({});
  let pages;
  if (userLogged.accountType == "simple") pages = pages1;
  else if (userLogged.accountType == "employee") pages = pages2;
  else if (userLogged.accountType == "guest") pages = pages3;
  else if (userLogged.accountType == "admin") pages = pages4;
  else pages = pages5;

  return (
    <AppBar>
      {/* LOGO AND APP NAME DESKTOP*/}
      <Container>
        <Toolbar disableGutters>
          <AppIcon sx={{ display: { xs: "none", md: "flex" }, mr: 1, fontSize: 70, margin: 2 }} />
          <Typography
            fontSize={30}
            variant="h6"
            noWrap
            component="a"
            onClick={() => {
              if (
                userLogged.accountType == "" ||
                userLogged.accountType == "guest" ||
                userLogged.accountType == undefined
              ) {
                setUserLogged({} as UserDetails);
                navigate("/");
              } else navigate("home");
            }}
            sx={{
              cursor: "pointer",
              mr: 2,
              display: { xs: "none", md: "flex" },
              fontFamily: "monospace",
              fontWeight: 700,
              letterSpacing: ".3rem",
              color: "inherit",
              textDecoration: "none",
            }}
          >
            LOAN COMPARER
          </Typography>
          {userLogged.accountType != "" && userLogged.accountType != undefined && (
            <Divider
              orientation="vertical"
              variant="middle"
              flexItem
              sx={{ display: { xs: "none", md: "flex" } }}
            ></Divider>
          )}

          {/* PAGES MOBILE*/}
          {pagesState && (
            <Box sx={{ flexGrow: 1, display: { xs: "flex", md: "none" } }}>
              <IconButton
                size="large"
                aria-label="account of current user"
                aria-controls="menu-appbar"
                aria-haspopup="true"
                onClick={handleOpenNavMenu}
                color="inherit"
              >
                <MenuIcon />
              </IconButton>
              <Menu
                id="menu-appbar"
                anchorEl={anchorElNav}
                anchorOrigin={{
                  vertical: "bottom",
                  horizontal: "left",
                }}
                keepMounted
                transformOrigin={{
                  vertical: "top",
                  horizontal: "left",
                }}
                open={Boolean(anchorElNav)}
                onClose={handleCloseNavMenu}
                sx={{
                  display: { xs: "block", md: "none" },
                }}
              >
                {pages.map((page) => (
                  <MenuItem
                    key={page}
                    onClick={() => {
                      handleCloseNavMenu();
                      if (page == "NEW INQUIRY") newInquiryHandler();
                      else if (page == "FIND REQUEST") findRequestHandler();
                    }}
                  >
                    <Typography textAlign="center">{page}</Typography>
                  </MenuItem>
                ))}
              </Menu>
            </Box>
          )}

          {/* LOGO AND APP NAME MOBILE */}
          <AppIcon sx={{ display: { xs: "flex", md: "none" }, mr: 1 }} />
          <Typography
            variant="h5"
            noWrap
            component="a"
            href={
              userLogged.accountType == "" ||
              userLogged.accountType == "guest" ||
              userLogged.accountType === undefined
                ? "/"
                : "home"
            }
            sx={{
              mr: 2,
              display: { xs: "flex", md: "none" },
              flexGrow: 1,
              fontFamily: "monospace",
              fontWeight: 700,
              letterSpacing: ".3rem",
              color: "inherit",
              textDecoration: "none",
            }}
          >
            LOAN COMPARER
          </Typography>

          {/* PAGES DESKTOP */}
          <Box sx={{ marginLeft: 2, flexGrow: 1, display: { xs: "none", md: "flex" } }}>
            {pages.map((page) => (
              <Button
                key={page}
                onClick={() => {
                  handleCloseNavMenu();
                  if (page == "NEW INQUIRY") newInquiryHandler();
                  else if (page == "FIND REQUEST") findRequestHandler();
                }}
                sx={{ fontSize: 20, my: 2, color: "white", display: "block" }}
              >
                {page}
              </Button>
            ))}
          </Box>
          {/* PROFILE SETTINGS */}
          <Stack
            spacing={3}
            direction="row"
            alignItems="center"
            textAlign="right"
            sx={{ alignContent: "right", flexGrow: 0 }}
          >
            {userLogged.accountType != undefined && (
              <Stack direction="column">
                <Typography textAlign="left">
                  {userLogged.firstName + " " + userLogged.lastName}
                </Typography>
                <Typography textAlign="left">
                  {userLogged.accountType != "guest"
                    ? userLogged.accountType + " account type"
                    : "Logged as guest"}
                </Typography>
              </Stack>
            )}
            {profileState && (
              <Box>
                <Tooltip title="Open settings">
                  <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
                    <Avatar alt="Remy Sharp" src="/static/images/avatar/2.jpg" />
                  </IconButton>
                </Tooltip>
                <Menu
                  sx={{ mt: "45px" }}
                  id="menu-appbar"
                  anchorEl={anchorElUser}
                  anchorOrigin={{
                    vertical: "top",
                    horizontal: "right",
                  }}
                  keepMounted
                  transformOrigin={{
                    vertical: "top",
                    horizontal: "right",
                  }}
                  open={Boolean(anchorElUser)}
                  onClose={handleCloseUserMenu}
                >
                  {settings1.map((setting) => (
                    <MenuItem
                      key={setting}
                      onClick={() => {
                        handleCloseUserMenu();
                        if (setting == "Logout") logoutHandler();
                        else if (setting == "Profile") profileHandler();
                      }}
                    >
                      <Typography textAlign="center">{setting}</Typography>
                    </MenuItem>
                  ))}
                </Menu>
              </Box>
            )}
          </Stack>
        </Toolbar>
      </Container>
    </AppBar>
  );
};
