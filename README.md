# reactiveRectangle

## Problem Description
Create an interactive web application for drawing and validating rectangle dimensions in real-time. The system reads initial dimensions from a JSON file, allows users to resize the rectangle, validates the dimensions with backend alidation, and persists valid changes.

## Solution Features

### Frontend
* SVG rectangle with real-time resizing via user mouse controls.
* Automatic perimeter calculation display.
* Validation status feedback.
* Error handling with user-friendly messages.
* Debounced API calls for optiman performance.

### Backend
* RESTful validation endpoint with 10-second simulated processing.
* Concurrent request handling with proper resource locking.
* Thread-safe JSON file operations.
* Custom validation rules.
* Cross-Origin Resource Sharing (CORS) enabled.
* OpenAPI documentation.

### Data Flow
1. Rectangle dimensions loaded from JSON on startup.
2. User resizes rectangle through UI controls.
3. Changes trigger debounced API calls.
4. Backend validates dimensions with artificial delay.
5. Valid dimensions persist to JSON storage.
6. Frontend updates with validation result on error.
7. Perimeter of the shape is calculated and returned to frontend for valid rectangles.

***

### Technical Implementation

#### Architecture Patterns
* Clean Architecture with domain-driven design.
* SOLID principles, especially - Interface Segregation - used.
* Repository Pattern for JSON persistence.
* Command-Query Separation (CQS).
* Dependency Injection.
* Reactive UI patterns with hooks.

#### Key Features

##### Concurrent Processing
* SemaphoreSlim ensures thread-safe JSON operations.
* Multiple validation requests handled simultaneously.
* Debounced frontend requests prevent API flooding.

##### Validation Rules
* Width of the shape must not exceed its height.
* Both dimensions must be positive.
* 10-second validation delay simulates complex processing.

##### Error Handling
* Global exception middleware.
* Custom validation exceptions.
* User-friendly error messages.
* Frontend error state management.

#### Technologies
Frontend
* React 19
* TypeScript
* Vite bundler
* React-Resizable
* Axios HTTP client
* Loadash utilities

Backend
* .Net 8.0, C# 12
* Minimal APIs
* xUnit

***

## Setup and Development

### Prerequisites
* .Net 8.0 SDK
* Node.js 18+
* npm/yarn

### Running the App
1. Backend:
```bash
cd ReactiveRectangle/src/ReactiveRectangle.Api
dotnet run
```
2. Frontend:
```bash
npm install
npm run dev
```

### API documentation
Access OpenAPI UI at `https://localhost:7290/swagger` when running the backend.
