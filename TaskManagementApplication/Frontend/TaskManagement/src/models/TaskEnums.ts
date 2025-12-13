export const TaskEnums = {
  Task: 1,
  Note: 2
} as const;

export type TaskEnum = typeof TaskEnums[keyof typeof TaskEnums];