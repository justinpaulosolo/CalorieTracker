import { useMutation } from "@tanstack/react-query";
import axios from "axios";

export function useRegisterUser() {
  return useMutation({
    mutationFn: async (payload) => {
      const response = await axios.post("/api/account/register", payload);
      const data: string = response.data;
      return data;
    }
  });
}