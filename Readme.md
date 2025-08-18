# LittleAnim | 2D Animation Framework

LittleAnim is a 2D animation framework for .NET. It enables the programmatic creation of animations, which can be exported as video files.

## Features

*   **Rendering Engine:** Orchestrates the animation process and generates the frames.
*   **Extensible Drawing System:** Uses an `ICanvas` interface that allows for different rendering backend implementations. The current implementation uses `ImageSharp`.
*   **Drawable Objects:** Represents any object that can be drawn on the canvas.
*   **Animation System:** Applies changes to the properties of `Drawable` objects over time.
*   **Composable Video Export:** Exports the animation directly to a video file using a composable `IExporter` interface. The default implementation uses FFmpeg to create an MP4 video.

## Directory Structure

```
Directory structure:
└── kelisei-littleanim/
    ├── Readme.md
    ├── Dockerfile
    ├── LICENSE
    ├── LittleAnim.csproj
    ├── Animations/
    │   ├── Animation.cs
    │   └── MoveAnimation.cs
    ├── Common/
    │   ├── Color.cs
    │   └── Font.cs
    ├── Core/
    │   └── Engine.cs
    ├── Drawables/
    │   ├── Drawable.cs
    │   └── TextDrawable.cs
    ├── Exporters/
    │   ├── FFmpegExporter.cs
    │   └── IExporter.cs
    └── Rendering/
        ├── ICanvas.cs
        ├── IImage.cs
        ├── ImageSharpCanvas.cs
        └── ImageSharpImage.cs
```

## Getting Started

### Prerequisites

*   .NET 8.0 SDK
*   FFmpeg (must be available in the system's PATH)

### Key Concepts

1.  **`ICanvas`**: The drawing surface. It defines methods for drawing shapes, text, and images. `ImageSharpCanvas` is the default implementation.
2.  **`IExporter`**: Defines the contract for exporting the animation. `FFmpegExporter` is the default implementation for creating video files.
3.  **`Engine`**: The core of the framework. Here you configure global settings such as FPS and duration. The engine handles the processing of each frame.
4.  **`Drawable`**: The base class for any object you want to display in the animation (e.g., `TextDrawable` for text).
5.  **`Animation`**: A class that modifies the properties of a `Drawable` over time. For example, `MoveAnimation` changes an object's position.

### How to Use

The basic workflow is as follows:

1.  **Instantiate an `ICanvas`**: This will be the canvas where your animation is rendered.
2.  **Instantiate an `IExporter`**: Choose an exporter, like `FFmpegExporter`.
3.  **Instantiate the `Engine`**: Pass the canvas and exporter, and define global settings like FPS and duration.
4.  **Create `Drawable`s**: Create all the objects that will appear in your scene.
5.  **Create and Assign `Animation`s**: Create animations and add them to the corresponding `Drawable`s.
6.  **Add `Drawable`s to the Engine**: Register your objects with the animation engine.
7.  **Export the Animation**: Call the `Export` method on the engine with the desired output path.

### Code Example

The following example (from `Program.cs`) creates an animation of a "Hello, World!" text moving diagonally across the screen for one second and exports it as an MP4 file.

```csharp
using System;
using System.Numerics;

namespace LittleAnim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Instantiate a Canvas of 800x800 pixels
            ICanvas canvas = new ImageSharpCanvas(800, 800);

            // 2. Instantiate the Engine at 120 FPS and 1-second duration, using the FFmpegExporter
            Engine engine = new Engine(120, TimeSpan.FromSeconds(1), canvas, new FFmpegExporter());

            // 3. Create a drawable object (a text element)
            Drawable textDrawable = new TextDrawable(
                new Vector2(0, 0), // Initial position
                new Font("Arial", 20, "C:/WINDOWS/FONTS/ARIAL.TTF"), // Ensure the font path is valid
                new Color(0, 0, 0, 255),
                "Hello, World!"
            );

            // 4. Create an animation to move the text
            Animation moveText = new MoveAnimation(
                startTime: 0,   // Start at second 0
                duration: 1,    // Last for 1 second
                from: new Vector2(0, 0),
                to: new Vector2(400, 400)
            );

            // Assign the animation to the text object
            textDrawable.AddAnimation(moveText);

            // 5. Add the drawable object to the engine
            engine.AddDrawable(textDrawable);
            
            // 6. Export the animation to the specified path
            string outputPath = "C:/Path/To/Your/Output/Folder/my_animation.mp4";
            engine.Export(outputPath);
        }
    }
}
```

## Extensibility

You can extend LittleAnim to create your own objects, animations, and exporters.

*   **Create a Custom `Drawable`**: Inherit from the `Drawable` class and implement the `Draw` method.
*   **Create a Custom `Animation`**: Inherit from the `Animation` class and implement the `Apply` method to modify the properties of a `Drawable` over time.
*   **Create a Custom `IExporter`**: Implement the `IExporter` interface to support different output formats or video encoders.

## Docker Usage

The project includes a `Dockerfile` for building and running the application in a container. This provides a consistent build environment but requires modification to include FFmpeg.

To build and run the Docker image:

```bash
# Build the image
docker build -t littleanim .

# Run the container (ensure you mount a volume to get the output files)
docker run --rm -v "C:/Path/To/Your/Output/Folder:/app/output" littleanim
```*Note: You may need to adjust the `Dockerfile` to install FFmpeg, and update the font and output paths in `Program.cs` to function correctly within the container.*

## License

This project is licensed under the Apache 2.0 License. See the [LICENSE](LICENSE) file for details.
