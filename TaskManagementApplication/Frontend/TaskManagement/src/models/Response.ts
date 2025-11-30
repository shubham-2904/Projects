export interface Response<T> {
    sucess: boolean;
    message?: string | null;
    data?: T | null;
}
