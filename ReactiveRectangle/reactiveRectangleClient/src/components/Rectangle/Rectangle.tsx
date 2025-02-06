import { RectangleResizer } from "./RectangleResizer";
import { useRectangle } from "../../hooks/useRectangle";

export const Rectangle = () => {
    const {
        dimensions,
        perimeter,
        isValidating,
        error,
        validateDimensions,
        setDimensions
    } = useRectangle({ height: 220, width: 360});

    const handleResize = (newDimensions: {height: number; width: number}) => {
        setDimensions(newDimensions);
        validateDimensions(newDimensions);
    };

    return (
        <>
            <div className="resize-container">
                <RectangleResizer dimensions={dimensions} onResize={handleResize}/>
            </div>
        
            <div className="status">
            {isValidating && "Validating the rectangle dimensions..."}
            {error && <div className="error">{error}</div>}
            {perimeter && !error && `Perimeter of the shape: ${perimeter.toFixed(2)}px`}
            </div>
        </>
    );
};