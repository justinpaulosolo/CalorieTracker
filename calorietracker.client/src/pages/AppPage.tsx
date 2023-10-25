import FoodEntryForm from "@/components/food-entry-form";
import {
    Table,
    TableBody,
    TableCaption,
    TableCell,
    TableHead,
    TableHeader,
    TableRow,
} from "@/components/ui/table"

function AppPage() {
    return (
        <div className="fle flex-col space-y-4">
            <FoodEntryForm />
            <div>
                <Table>
                    <TableCaption>A list of your recent invoices.</TableCaption>
                    <TableHeader>
                        <TableRow>
                            <TableHead className="w-[100px]">Name</TableHead>
                            <TableHead>Proteins</TableHead>
                            <TableHead>Carbs</TableHead>
                            <TableHead>Fats</TableHead>
                            <TableHead className="text-right">Calories</TableHead>
                        </TableRow>
                    </TableHeader>
                    <TableBody>
                        <TableRow>
                            <TableCell className="font-medium">Chicken Breast</TableCell>
                            <TableCell>100g</TableCell>
                            <TableCell>0g</TableCell>
                            <TableCell>1g</TableCell>
                            <TableCell className="text-right">$250.00</TableCell>
                        </TableRow>
                    </TableBody>
                </Table>

            </div>
        </div>
    );
}

export default AppPage;