import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table.tsx";
import { Skeleton } from "@/components/ui/skeleton.tsx";

export default function SavedFoodsSkeleton() {
  return (
    <Table className="animate-pulse">
      <TableHeader>
        <TableRow>
          <TableHead>
            <Skeleton className="h-4" />
          </TableHead>
          <TableHead>
            <Skeleton className="h-4 w-20 text-right" />
          </TableHead>
          <TableHead>
            <Skeleton className="h-4 w-20 text-right" />
          </TableHead>
          <TableHead>
            <Skeleton className="h-4 w-20 text-right" />
          </TableHead>
          <TableHead>
            <Skeleton className="h-4 w-20 text-right" />
          </TableHead>
        </TableRow>
      </TableHeader>
      <TableBody>
        <TableRow>
          <TableCell>
            <Skeleton className="h-4 w-full" />
          </TableCell>
          <TableCell>
            <Skeleton className="h-4 w-full" />
          </TableCell>
          <TableCell>
            <Skeleton className="h-4 w-full" />
          </TableCell>
          <TableCell>
            <Skeleton className="h-4 w-full" />
          </TableCell>
          <TableCell>
            <Skeleton className="h-4 w-full" />
          </TableCell>
        </TableRow>
      </TableBody>
    </Table>
  );
};