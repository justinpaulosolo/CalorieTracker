import { LoginFormInputs } from "@/pages/LoginPage";
import { RegisterFormInputs } from "@/pages/RegisterPage";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import axios from "axios";

export function useRegisterUser() {
  return useMutation({
    mutationFn: async (user: RegisterFormInputs) => {
      const response = await axios.post("api/account/register", user);
      const data = response.data;
      return data;
    },
  });
}

export function useLoginUser() {
  return useMutation({
    mutationFn: (user: LoginFormInputs) =>
      axios.post("api/account/login", user),
  });
}

export function useLogoutUser() {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: () => axios.post("api/account/manage/logout"),
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
