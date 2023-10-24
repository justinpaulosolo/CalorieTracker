import { useQuery } from "@tanstack/react-query";
import axios from "axios";
import { Navigate, useOutlet } from "react-router-dom";

async function fetchUserInfo() {
    const response = await axios.get('/Account/manage/info');
    const data = response.data;
    return data;
}

function useGetUserInfo() {
    return useQuery({
        queryKey: ['user-info'],
        queryFn: fetchUserInfo,
        refetchOnWindowFocus: false,
        refetchOnMount: false,
        retry: false,
    })
}

function PrivateRoute () {
    const { data, isLoading } = useGetUserInfo();
    const outlet = useOutlet();

    if (isLoading) {
        return <div>Loading...</div>
    }

    if (!data) {
        return <Navigate to="/login" replace />
    }
    
    return <>{outlet}</>
}

export default PrivateRoute;