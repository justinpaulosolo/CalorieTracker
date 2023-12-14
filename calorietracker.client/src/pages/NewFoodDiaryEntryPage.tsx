import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs.tsx";
import FoodDiaryEntryQuickAddForm from "../components/food-diary/forms/food-diary-entry-quick-add-form.tsx";
import FoodDiaryEntryAddForm from "@/components/food-diary/forms/food-diary-entry-add-form.tsx";

export default function NewFoodDiaryEntryPage({ date }: { date: Date }) {
  return (
    <div className="flex justify-center">
      <Tabs defaultValue="quickadd" className="w-[500px]">
        <TabsList className="grid w-full grid-cols-2">
          <TabsTrigger value="quickadd">Quick Add</TabsTrigger>
          <TabsTrigger value="yourfoods">Your Foods</TabsTrigger>
        </TabsList>
        <TabsContent value="quickadd" className="mt-4">
          <FoodDiaryEntryQuickAddForm date={date} />
        </TabsContent>
        <TabsContent value="yourfoods">
          <FoodDiaryEntryAddForm date={date} />
        </TabsContent>
      </Tabs>
    </div>
  );
}
