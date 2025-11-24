import { configureStore } from "@reduxjs/toolkit";
import taskReducer from "./features/Task/taskSlice";

// making task store
export const store = configureStore({
    reducer: {
        task: taskReducer,
    },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
