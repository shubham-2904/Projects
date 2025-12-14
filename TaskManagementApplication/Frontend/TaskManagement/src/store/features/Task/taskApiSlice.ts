import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import type { TaskDto } from "../../../models/TaskModel";
import type { Response } from "../../../models/Response";

const BASE_URL = "http://localhost:5276/api";

export const taskApiSlice = createApi({
    reducerPath: "taskApi",
    baseQuery: fetchBaseQuery({ baseUrl: BASE_URL }),
    tagTypes: ["Task"] as const,
    endpoints: (builder) => {
        return {
            getAllTask: builder.query<Response<TaskDto[]>, void>({
                query: () => "/taskmanager/get-all-tasks",
                providesTags: ["Task"],
            }),
            createTask: builder.mutation<Response<TaskDto>, TaskDto>({
                query: (body) => ({
                    url: "/taskmanager/create-task",
                    method: "POST",
                    body,
                }),
                invalidatesTags: ["Task"],
            }),
            deleteTask: builder.mutation<Response<number>, number>({
                query: (taskIdToDelete) => {
                    return {
                        url: `/taskmanager/delete-task/${taskIdToDelete}`,
                        method: "DELETE",
                    };
                },
                invalidatesTags: ["Task"],
            }),
            getTask: builder.query<Response<TaskDto>, number>({
                query: (taskId) => `/taskmanager/get-task/${taskId}`,
            }),
            updateTask: builder.mutation<Response<number>, TaskDto>({
                query: (updatedTask) => {
                    return {
                        url: `/taskmanager/update-task/`,
                        method: "POST",
                        body: updatedTask,
                    };
                },
                invalidatesTags: ["Task"],
            }),
        };
    },
});

export const {
    useGetAllTaskQuery,
    useCreateTaskMutation,
    useDeleteTaskMutation,
    useGetTaskQuery,
    useUpdateTaskMutation,
} = taskApiSlice;
