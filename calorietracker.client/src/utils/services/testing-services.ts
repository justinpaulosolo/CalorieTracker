import { useMutation } from "@tanstack/react-query";

export function useTestingMutation() {
  return useMutation({
    mutationFn: () => new Promise(resolve => setTimeout(resolve, 5000)),
  });
}
