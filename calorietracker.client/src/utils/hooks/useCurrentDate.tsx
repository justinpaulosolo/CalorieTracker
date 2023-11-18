import { useState } from "react";

export default function useCurrentDate() {
  return useState<string>(() => {
    const now = new Date();
    const timezoneOffset = now.getTimezoneOffset() * 60000;
    return new Date(now.getTime() - timezoneOffset).toISOString().split("T")[0];
  });
}
