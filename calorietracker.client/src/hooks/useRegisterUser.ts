import { useMutation } from "@tanstack/react-query";
import { RegisterUser } from "@/utils/types.ts";
import axios, { AxiosError } from "axios";

declare module "@tanstack/react-query" {
  interface Register {
    defaultError: AxiosError;
  }
}

export function useRegisterUser() {
  return useMutation({
    mutationFn: async (payload: RegisterUser) => {
      const response = await axios.post("/api/account/register", payload);
      return response.data.response.data;
    },
  });
}
