import Box from "@mui/material/Box";
import { Outlet } from "react-router-dom";
import { InquiryList } from "./InquiryList";
import { InquiryForm } from "./InquiryForm";

export const GuestPage: React.FC = () => {
  return (
    <Box>
      <InquiryForm />
      <Outlet></Outlet>
    </Box>
  );
};
