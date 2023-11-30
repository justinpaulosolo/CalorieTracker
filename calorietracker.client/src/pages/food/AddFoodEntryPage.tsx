import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";
import FoodQuickAddForm from "./forms/food-quick-add-form";

export default function AddFoodEntryPage() {
  return (
    <Tabs defaultValue="quickadd" className="w-[500px]">
      <TabsList className="grid w-full grid-cols-2">
        <TabsTrigger value="quickadd">Quick Add</TabsTrigger>
        <TabsTrigger value="yourfoods">Your Foods</TabsTrigger>
      </TabsList>
      <TabsContent value="quickadd">
        <Card>
          <CardHeader>
            <CardTitle>Food Diary</CardTitle>
            <CardDescription>
              Add a food entry to your diary. You can add a new food or select
              from your foods.
            </CardDescription>
          </CardHeader>
          <CardContent className="space-y-2">
            <FoodQuickAddForm />
          </CardContent>
        </Card>
      </TabsContent>
      <TabsContent value="yourfoods">
        <Card>
          <CardHeader>
            <CardTitle>Password</CardTitle>
            <CardDescription>
              Change your password here. After saving, you'll be logged out.
            </CardDescription>
          </CardHeader>
          <CardContent className="space-y-2">
            <div className="space-y-1">
              <Label htmlFor="current">Current password</Label>
              <Input id="current" type="password" />
            </div>
            <div className="space-y-1">
              <Label htmlFor="new">New password</Label>
              <Input id="new" type="password" />
            </div>
          </CardContent>
          <CardFooter>
            <Button>Save password</Button>
          </CardFooter>
        </Card>
      </TabsContent>
    </Tabs>
  );
}
