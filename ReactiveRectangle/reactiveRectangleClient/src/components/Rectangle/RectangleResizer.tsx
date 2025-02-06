import { ResizableBox } from "react-resizable";
import { Rectangle } from "../../types/rectangle";

interface Props {
    dimensions: Rectangle;
    onResize: (size: Rectangle) => void;
}

export const RectangleResizer: React.FC<Props> = ({ dimensions, onResize }) => (
    <ResizableBox
        height={dimensions.height}
        width={dimensions.width}
        onResize={(_, { size }) => onResize(size)}
        minConstraints={[100, 100]}
        maxConstraints={[500, 500]}
        resizeHandles={['se', 'sw', 'ne', 'nw', 'n', 's', 'e', 'w']}
        className="react-resizable">
            <div className="rectangle"/>
        </ResizableBox>
);