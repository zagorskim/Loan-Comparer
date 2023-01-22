import Box from "@mui/material/Box";
import { UserData } from "./../data/UserData";
import { useRecoilState } from "recoil";
import { InquiryList } from "./InquiryList";
import { useState } from "react";
import { InquiryForm } from "./InquiryForm";

export const LoggedPage: React.FC = () => {
  const [userLogged, setUserLogged] = useRecoilState(UserData);
  const [inquiryForm, setInquiryForm] = useState(false);

  return (
    <Box>
      {inquiryForm && <InquiryForm />}
      {!inquiryForm && <InquiryList />}
    </Box>
  );
};
