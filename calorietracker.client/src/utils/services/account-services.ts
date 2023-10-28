import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import axios from "axios";

export function useLoginUser() {
    return useMutation({
        mutationFn: (user: {username: string, password: string}) =>
        axios.post('/Account/login', user)
    })
}

export function useLogoutUser() {
    const queryClient = useQueryClient()
    return useMutation({
        mutationFn: () => axios.post('/Account/manage/logout'),
        onSuccess: () => {
            queryClient.setQueryData(['user-info'], null)
        },
    })
}

export function useGetUserInfo() {
    return useQuery({
        queryKey: ['user-info'],
        queryFn: async () => {
            const response = await axios.get('/Account/manage/info');
            const data = response.data;
            return data;
        },
        refetchOnWindowFocus: false,
        refetchOnMount: false,
        retry: false,
    })
}