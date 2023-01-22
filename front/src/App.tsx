import React from "react";
import "./App.css";
import { SessionChoicePage } from "./components/SessionChoicePage";
import { Routes } from "react-router-dom";
import { Route } from "react-router-dom";
import { Error404Page } from "./components/Error404Page";
import { NavBar } from "./components/NavBar";
import { GuestPage } from "./components/GuestPage";
import { LoginPage } from "./components/LoginPage";
import { LoggedPage } from "./components/LoggedPage";
import { RegisterPage } from "./components/RegisterPage";
import { InquiryForm } from "./components/InquiryForm";
import { useEffect } from "react";
import { ProfilePage } from "./components/ProfilePage";
import { useRecoilState } from "recoil";
import { ACCOUNT_INFO_ENDPOINT_ADDRESS } from "./ConnectionVariables";
import axios from "axios";
import { UserDetails } from "./data/Types";
import { UserData } from "./data/UserData";
import { SearchGuestOffer } from "./components/SearchGuestOffer";

function App() {
  const [userLogged, setUserLogged] = useRecoilState(UserData);

  useEffect(() => {
    const config = {
      headers: { Authorization: `Bearer ${sessionStorage.getItem("token")}` },
    };
    axios
      .get(ACCOUNT_INFO_ENDPOINT_ADDRESS, config)
      .then((res) => {
        console.log(res);
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
          email: sessionStorage.getItem("email") as string,
          token: sessionStorage.getItem("token") as string,
          birthDate: res.data.birthDate,
        });
      })
      .catch((res) => {
        console.log(res);
        if (sessionStorage.getItem("guest") == "true")
          setUserLogged({ accountType: "guest", firstName: "", lastName: "" } as UserDetails);
        else setUserLogged({} as UserDetails);
      });
  }, []);

  return (
    <div style={{ position: "static" }} className="App">
      <div style={{ height: 110 }} />
      <NavBar />
      <Routes>
        <Route path="/" element={<SessionChoicePage />} />
        <Route path="login" element={<LoginPage />} />
        <Route path="guest" element={<GuestPage />} />
        <Route path="guest/inquiry" element={<InquiryForm />} />
        <Route path="guest/search" element={<SearchGuestOffer />} />
        <Route path="home" element={<LoggedPage />} />
        <Route path="home/inquiry" element={<InquiryForm />} />
        <Route path="register" element={<RegisterPage />} />
        <Route path="profile" element={<ProfilePage />} />
        <Route path="*" element={<Error404Page />} />
      </Routes>
    </div>
  );
}

export default App;
