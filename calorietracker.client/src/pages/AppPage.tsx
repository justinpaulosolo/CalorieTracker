import { Button } from "@/components/ui/button";

function AppPage() {
    return (
        <div>
            <h1 id="tabelLabel">App Page</h1>
            <div>
                <Button onClick={() => getLogout()}>Log out</Button>
            </div>
        </div>
    );

    async function getLogout() {
        await fetch('/Account/logout',{ method: 'POST' });
    }
}

export default AppPage;