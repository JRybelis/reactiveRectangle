import { useState, useCallback } from "react";
import { debounce } from 'lodash';
import { Rectangle, ValidationResponse } from '../types/rectangle';
import { validateRectangle } from "../services/rectangleService";

export const useRectangle = (initialDimensions: Rectangle) => {
    const [dimensions, setDimensions] = useState(initialDimensions);
    const [perimeter, setPerimeter] = useState<number | null>(null);
    const [isValidating, setIsValidating] = useState(false);
    const [error, setError] = useState<string | null>(null);

    const validateDimensions = useCallback(
        debounce(async (newDimensions: Rectangle) => {
            try {
                setIsValidating(true);
                const response = await validateRectangle(newDimensions);
                setPerimeter(response.perimeter ?? null);
                setError(null);
            } catch (error: any) {
                setError(error.response?.data?.message || error.message);
            } finally {
                setIsValidating(false);
            }
        }, 500), []
    );

    return {
        dimensions,
        setDimensions,
        perimeter,
        isValidating,
        error,
        validateDimensions
    };
};