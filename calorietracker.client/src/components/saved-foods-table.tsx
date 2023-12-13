import { Table, TableBody, TableCell, TableHeader, TableRow } from "@/components/ui/table.tsx";

export default function SavedFoodsTable() {
  return (
    <Table>
      <TableHeader>
        <TableRow>
          <TableCell>Name</TableCell>
          <TableCell className="text-right">Protein</TableCell>
          <TableCell className="text-right">Carbs</TableCell>
          <TableCell className="text-right">Fat</TableCell>
          <TableCell className="text-right">Calories</TableCell>
          <TableCell className="w-20"></TableCell>
        </TableRow>
      </TableHeader>
      <TableBody>
        <TableRow>
          <TableCell>Chicken Breast</TableCell>
          <TableCell className="text-right">26</TableCell>
          <TableCell className="text-right">0</TableCell>
          <TableCell className="text-right">3</TableCell>
          <TableCell className="text-right">140</TableCell>
          <TableCell className="w-20"></TableCell>
        </TableRow>
        <TableRow>
          <TableCell>Chicken Breast</TableCell>
          <TableCell className="text-right">26</TableCell>
          <TableCell className="text-right">0</TableCell>
          <TableCell className="text-right">3</TableCell>
          <TableCell className="text-right">140</TableCell>
          <TableCell className="w-20"></TableCell>
        </TableRow>
        <TableRow>
          <TableCell>Chicken Breast</TableCell>
          <TableCell className="text-right">26</TableCell>
          <TableCell className="text-right">0</TableCell>
          <TableCell className="text-right">3</TableCell>
          <TableCell className="text-right">140</TableCell>
          <TableCell className="w-20"></TableCell>
        </TableRow>
        <TableRow>
          <TableCell>Chicken Breast</TableCell>
          <TableCell className="text-right">26</TableCell>
          <TableCell className="text-right">0</TableCell>
          <TableCell className="text-right">3</TableCell>
          <TableCell className="text-right">140</TableCell>
          <TableCell className="w-20"></TableCell>
        </TableRow>
      </TableBody>
    </Table>
  );
}