import { Navigate, useOutlet } from "react-router-dom";
import Navbar from "./navbar";
import { useGetUserDetails } from "@/utils/services/account-services";

function PrivateRoute() {
  const { data: User, isLoading } = useGetUserDetails();
  const outlet = useOutlet();

  if (isLoading) {
    return (
      <div className="flex justify-center items-center h-screen">
        <div className="animate-spin rounded-full h-32 w-32 border-t-2 border-b-2 border-gray-900"></div>
      </div>
    );
  }

  if (!User) {
    return <Navigate to="/login" replace />;
  }

  return (
    <div className="h-screen flex flex-col space-y-6">
      <Navbar />
      <div className="container max-w-4xl">
        <main>{outlet}</main>
      </div>
    </div>
  );
}

export default PrivateRoute;
