import { useMutation } from "@tanstack/react-query";
import axios from "axios";
import { LoginUser } from "@/utils/types.ts";

export function useLoginUser() {
  return useMutation({
    mutationFn: (payload: LoginUser) => axios.post("/api/account/login", payload)
  });
}