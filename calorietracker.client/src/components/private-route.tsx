import { Navigate, useOutlet } from "react-router-dom";
import Navbar from "./navbar";
import { useGetUserInfo } from "@/services/account-services";

function PrivateRoute () {
    const { data, isLoading } = useGetUserInfo();
    const outlet = useOutlet();

    if (isLoading) {
        return <div>Loading...</div>
    }

    if (!data) {
        return <Navigate to="/login" replace />
    }
    
    return (
        <div className="h-screen flex flex-col space-y-6">
            <Navbar />
            <div className="container max-w-4xl">
                <main>{outlet}</main>
            </div>
        </div>
    )
}

export default PrivateRoute;