import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import type { TaskDto } from "../../../models/TaskModel";
import type { Response } from "../../../models/Response";

const BASE_URL = "http://localhost:5276/api";

export const taskApiSlice = createApi({
    reducerPath: "taskApi",
    baseQuery: fetchBaseQuery({ baseUrl: BASE_URL }),
    endpoints: (builder) => {
        return {
            getAllTask: builder.query<Response<TaskDto[]>, void>({
                query: () => "/taskmanager/get-all-tasks",
            }),
        };
    },
});

export const { useGetAllTaskQuery } = taskApiSlice;
