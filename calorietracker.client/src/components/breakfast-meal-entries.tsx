import {
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableHeader,
    TableRow,
  } from '@/components/ui/table';
  import {
    Card,
    CardContent,
    CardDescription,
    CardHeader,
    CardTitle,
  } from '@/components/ui/card';
  import {
    DropdownMenu,
    DropdownMenuContent,
    DropdownMenuItem,
    DropdownMenuLabel,
    DropdownMenuTrigger,
  } from '@/components/ui/dropdown-menu';
  import { Button } from '@/components/ui/button';
  import { MoreHorizontal } from 'lucide-react';
  import { Skeleton } from '@/components/ui/skeleton';
import { useBreakfastMealEnties } from '@/utils/services/meal-entries-services';
import { MealEntries } from '@/utils/types';
  
  export default function BreakfastMealEntries({date}:{date:string}) {
    const { data, isLoading } = useBreakfastMealEnties({date});
    if (isLoading) {
      return (
        <div className="flex items-center space-x-4">
          <Skeleton className="h-12 w-12 rounded-full" />
          <div className="space-y-2">
            <Skeleton className="h-4 w-[250px]" />
            <Skeleton className="h-4 w-[200px]" />
          </div>
        </div>
      );
    }
  
    return (
      <Card>
        <CardHeader>
          <CardTitle>Breakfast</CardTitle>
          <CardDescription></CardDescription>
        </CardHeader>
        <CardContent>
          <div className="w-full">
            <Table>
              <TableHeader>
                <TableRow>
                  <TableHead className="font-medium">Name</TableHead>
                  <TableHead className="font-medium w-20">Proteins</TableHead>
                  <TableHead className="font-medium w-20">Carbs</TableHead>
                  <TableHead className="font-medium w-20">Fats</TableHead>
                  <TableHead className="font-medium w-20">Calories</TableHead>
                </TableRow>
              </TableHeader>
              <TableBody>
                {data.map((entry: MealEntries) => (
                  <TableRow key={entry.foodEntryId}>
                    <TableCell>{entry.name}</TableCell>
                    <TableCell>{entry.proteins}</TableCell>
                    <TableCell>{entry.carbs}</TableCell>
                    <TableCell>{entry.fats}</TableCell>
                    <TableCell>{entry.calories}</TableCell>
                    <TableCell className='w-20'>
                      <DropdownMenu>
                        <DropdownMenuTrigger asChild>
                          <Button variant="ghost" className="h-8 w-8 p-0">
                            <span className="sr-only">Open menu</span>
                            <MoreHorizontal className="h-4 w-4" />
                          </Button>
                        </DropdownMenuTrigger>
                        <DropdownMenuContent align="end">
                          <DropdownMenuLabel>Actions</DropdownMenuLabel>
                          <DropdownMenuItem
                            onClick={() => console.log(entry.foodEntryId, 'edit')}
                          >
                            Edit
                          </DropdownMenuItem>
                          <DropdownMenuItem
                            onClick={() => {
                              console.log(entry.foodEntryId, 'delete');
                            }}
                          >
                            Delete
                          </DropdownMenuItem>
                        </DropdownMenuContent>
                      </DropdownMenu>
                    </TableCell>
                  </TableRow>
                ))}
              </TableBody>
            </Table>
          </div>
        </CardContent>
      </Card>
    );
  }