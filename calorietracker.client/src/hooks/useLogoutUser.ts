import { useMutation, useQueryClient } from "@tanstack/react-query";
import axios from "axios";

export function useLogoutUser() {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: () => axios.post("/api/account/logout"),
    onSuccess: () => {
      queryClient.setQueryData(["user"], null);
    }
  });
}
