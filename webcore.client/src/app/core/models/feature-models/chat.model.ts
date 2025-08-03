export interface ChatViewModel {
    request: string;
    model: string;
    response: string;
    context: [];
    stream: boolean;
}