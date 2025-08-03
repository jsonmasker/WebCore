export interface BaseAPIResponse{
    success: boolean;
    message: string;
}
export interface APIResponse<T> extends BaseAPIResponse{
    data: T;
}
