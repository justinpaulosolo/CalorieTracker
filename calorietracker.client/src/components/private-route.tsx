import { Navigate, useOutlet } from "react-router-dom";
import Header from "./header.tsx";
import { useGetUserDetails } from "@/hooks/useGetUserDetails.ts";
import Footer from "@/components/footer.tsx";

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
    return <Navigate to="/login" />;
  }

  return (
    <div className="h-screen flex flex-col space-y-6">
      <Header />
      <div className="container max-w-5xl flex-grow">
        <main>{outlet}</main>
      </div>
      <Footer />
    </div>
  );
}

export default PrivateRoute;
