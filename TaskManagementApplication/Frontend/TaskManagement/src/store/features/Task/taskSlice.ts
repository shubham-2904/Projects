import { createSlice, type PayloadAction } from "@reduxjs/toolkit";
import type { TaskState } from "../../../models/TaskModel";

const initialState: TaskState = {
    value: null,
};

export const taskSlice = createSlice({
    name: "task",
    initialState,
    reducers: {
        editTask: (state, action: PayloadAction<TaskState>) => {
            state.value = action.payload.value;
            state.operation = action.payload.operation;
        },
        clearTask: (state) => {
            state.value = null;
            state.operation = undefined;
        }
    },
});

export const { editTask, clearTask } = taskSlice.actions;

export default taskSlice.reducer;
