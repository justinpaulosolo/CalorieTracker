import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import axios from "axios";
import { User } from "../types";

export function useLogoutUser() {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: () => axios.post("/api/account/logout"),
    onSuccess: () => {
      queryClient.setQueryData(["user"], null);
    }
  });
}

export function useGetUserDetails() {
  return useQuery({
    queryKey: ["user"],
    queryFn: async () => {
      const response = await axios.get("/api/account/user");
      const data: User = response.data;
      return data;
    },
    refetchOnWindowFocus: false,
    refetchOnMount: false,
    retry: false
  });
}
