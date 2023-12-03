import { useMutation, useQueryClient } from "@tanstack/react-query";
import axios from "axios";
import { LoginUser } from "@/utils/types.ts";

export function useLoginUser() {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: (payload: LoginUser) => axios.post("/api/account/login", payload).then((res) => res.data),
    onSuccess: (user) => {
      queryClient.setQueryData(["user"], user);
    }
  });
}