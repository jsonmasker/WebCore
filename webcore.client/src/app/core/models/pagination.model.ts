export interface PageInformation{
    currentPage: number;
    pageIndex: number;
    pageSize: number;
    totalItems: number;
    totalPages: number;
}
export class PageInformation implements PageInformation {
    currentPage: number = 0;
    pageIndex: number = 1;
    pageSize: number = 10;
    totalItems: number = 0;
    totalPages: number = 0;
}

export interface Pagination<T> extends PageInformation {
    items: T[];
}
export class Pagination<T> implements Pagination<T> {
    currentPage: number = 0;
    pageIndex: number = 0;
    pageSize: number = 0;
    totalItems: number = 0;
    totalPages: number = 0;
    items: T[] = [];
}