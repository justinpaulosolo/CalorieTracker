import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import axios from "axios";
import { Login, Register } from "../types";

export function useRegisterUser() {
  return useMutation({
    mutationFn: async (payload: Register) => {
      const response = await axios.post("/api/account/register", payload);
      const data = response.data;
      return data;
    },
  });
}

export function useLoginUser() {
  return useMutation({
    mutationFn: (payload: Login) => axios.post("/api/account/login", payload),
  });
}

export function useLogoutUser() {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: () => axios.post("/api/account/manage/logout"),
    onSuccess: () => {
      queryClient.setQueryData(["user-info"], null);
    },
  });
}

export function useGetUserInfo() {
  return useQuery({
    queryKey: ["user-info"],
    queryFn: async () => {
      const response = await axios.get("/api/account/manage/info");
      const data = response.data;
      return data;
    },
    refetchOnWindowFocus: false,
    refetchOnMount: false,
    retry: false,
  });
}
