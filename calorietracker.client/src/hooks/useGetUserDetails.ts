import { useQuery } from "@tanstack/react-query";
import axios from "axios";
import { User } from "@/utils/types.ts";

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
