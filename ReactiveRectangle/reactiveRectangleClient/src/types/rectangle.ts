export interface Rectangle {
    height: number;
    width: number;
}

export interface ValidationResponse {
    isValid: boolean;
    errorMessage?: string;
    perimeter?: number;
}