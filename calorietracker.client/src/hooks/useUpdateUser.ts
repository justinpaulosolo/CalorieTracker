import { useMutation } from "@tanstack/react-query";
import { UpdateAccountDto } from "@/utils/types.ts";
import axios, { AxiosError } from "axios";

declare module "@tanstack/react-query" {
  interface Register {
    defaultError: AxiosError;
  }
}

export function useUpdateUser() {
  return useMutation({
    mutationFn: async (payload: UpdateAccountDto) => {
      const response = await axios.put("/api/account/update", payload);
      return response.data.response;
    },
  });
}
