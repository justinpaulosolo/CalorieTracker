import { useMutation } from "@tanstack/react-query";
import axios from "axios";

export function useLoginUser() {
    return useMutation({
        mutationFn: (user: {username: string, password: string}) =>
        axios.post('/Account/login?useCookies=true&useSessionCookies=true', user)
    })
}
