import Box from "@mui/material/Box";
import { UserData } from "./../data/UserData";
import { useRecoilState } from "recoil";
import { InquiryList } from "./InquiryList";
import { useState } from "react";
import { InquiryForm } from "./InquiryForm";
import TextField from "@mui/material/TextField";
import { Stack, Typography } from "@mui/material";
import Button from "@mui/material/Button";
import axios from "axios";
import { SEARCH_OFFER_ENDPOINT_ADDRESS } from "../ConnectionVariables";
import Container from "@mui/material/Container";

export const SearchGuestOffer: React.FC = () => {
  const [offerId, setOfferId] = useState("");

  return (
    <Box
      sx={{
        marginTop: 8,
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
      }}
    >
      <Stack spacing={3} direction="column" width={300}>
        <Typography variant="h5">Enter Offer ID</Typography>
        <TextField
          value={offerId}
          onChange={(e) => setOfferId(e.target.value)}
          placeholder="Offer ID"
        ></TextField>
        <Button
          variant="contained"
          onClick={(e) => {
            axios
              .get(SEARCH_OFFER_ENDPOINT_ADDRESS + "?offerId=" + offerId)
              .then((res) => {
                console.log(res);
              })
              .catch((res) => {
                console.log(res);
              });
          }}
        >
          Search
        </Button>
      </Stack>
    </Box>
  );
};
