import { createSlice, type PayloadAction } from "@reduxjs/toolkit";

interface TaskState {
    value: string[];
}

const initialState: TaskState = {
    value: [],
};

export const taskSlice = createSlice({
    name: "task",
    initialState,
    reducers: {
        addTask: (state, action: PayloadAction<string>) => {
            state.value.push(action.payload);
        },
        deleteTask: (state, action: PayloadAction<number>) => {
            state.value.splice(action.payload, 1);
        },
    },
});

export const { addTask, deleteTask } = taskSlice.actions;

export default taskSlice.reducer;
