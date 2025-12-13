import type {TaskEnum} from "./TaskEnums";

export interface TaskDto {
    id: number;
    createDate: Date;
    category: TaskEnum;
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
