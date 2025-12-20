export const TaskEnums = {
    Task: 1,
    Note: 2,
} as const;

export type TaskEnum = (typeof TaskEnums)[keyof typeof TaskEnums];

export const operationsEnums = {
    add: 1,
    delete: 2,
    edit: 3,
} as const;

export type operationEnum = (typeof operationsEnums)[keyof typeof operationsEnums];
