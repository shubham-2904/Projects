export type TaskEnums = 1 | 2;

export interface TaskDto {
    id: number;
    createDate: Date;
    category: TaskEnums;
    title?: string | null;
    description?: string | null;
    details?: TaskDetailDto[] | null;
}

export interface TaskDetailDto {
    id: number;
    taskId: number;
    detail?: string | null;
    isCompleted: boolean;
}
