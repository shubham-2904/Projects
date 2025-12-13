import { configureStore } from "@reduxjs/toolkit";
import taskReducer from "./features/Task/taskSlice";
import { taskApiSlice } from "./features/Task/taskApiSlice";

// making task store
export const store = configureStore({
    reducer: {
        task: taskReducer,
        [taskApiSlice.reducerPath]: taskApiSlice.reducer,
    },
    middleware: (getDefaultMiddleware) => {
        return getDefaultMiddleware().concat(taskApiSlice.middleware);
    },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
