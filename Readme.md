# LittleAnim | 2D Animation Framework

LittleAnim is a 2D animation framework for .NET. It enables the programmatic creation of animations, which can be exported as a sequence of image frames. It is suitable for generating videos.

## Features

*   **Rendering Engine:** Orchestrates the animation process and generates the frames.
*   **Extensible Drawing System:** Uses an `ICanvas` interface that allows for different rendering backend implementations. The current implementation uses `ImageSharp`.
*   **Drawable Objects:** Represents any object that can be drawn on the canvas.
*   **Animation System:** Applies changes to the properties of `Drawable` objects over time.
*   **Frame Export:** Saves the animation as a sequence of PNG images, ready to be converted into a video or GIF.

## Directory Structure

```
└── kelisei-littleanim.git/
    ├── Readme.md
    ├── Animation.cs
    ├── Color.cs
    ├── Dockerfile
    ├── Drawable.cs
    ├── Engine.cs
    ├── Font.cs
    ├── ICanvas.cs
    ├── IImage.cs
    ├── ImageSharpCanvas.cs
    ├── ImageSharpImage.cs
    ├── LICENSE
    ├── LittleAnim.csproj
    ├── MoveAnimation.cs
    ├── Program.cs
    └── TextDrawable.cs
```

## Getting Started

### Prerequisites

*   .NET 8.0 SDK

### Key Concepts

1.  **`ICanvas`**: The drawing surface. It defines methods for drawing shapes, text, and images. `ImageSharpCanvas` is the default implementation.
2.  **`Engine`**: The core of the framework. Here you configure global settings such as FPS and duration. The engine handles the processing of each frame.
3.  **`Drawable`**: The base class for any object you want to display in the animation (e.g., `TextDrawable` for text).
4.  **`Animation`**: A class that modifies the properties of a `Drawable` over time. For example, `MoveAnimation` changes an object's position.

### How to Use

The basic workflow is as follows:

1.  **Instantiate an `ICanvas`**: This will be the canvas where your animation is rendered.
2.  **Instantiate the `Engine`**: Define global settings like FPS and duration here.
3.  **Create `Drawable`s**: Create all the objects that will appear in your scene.
4.  **Create and Assign `Animation`s**: Create animations and add them to the corresponding `Drawable`s.
5.  **Add `Drawable`s to the Engine**: Register your objects with the animation engine.
6.  **Compile the Animation**: The engine will process each frame.
7.  **Export the Files**: Save the generated frames to a folder.

### Code Example

The following example (from `Program.cs`) creates an animation of a "Hello, World!" text moving diagonally across the screen for one second.

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

            // 2. Instantiate the Engine at 30 FPS and 1-second duration
            Engine engine = new Engine(30, TimeSpan.FromSeconds(1), canvas);

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

            // 6. Compile all frames of the animation
            engine.Compile();

            // 7. Save the frames to a destination folder
            engine.ToFile("C:/Path/To/Your/Output/Folder");
        }
    }
}
```

## Extensibility

You can extend LittleAnim to create your own objects and animations.

*   **Create a Custom `Drawable`**: Inherit from the `Drawable` class and implement the `Draw` method.
*   **Create a Custom `Animation`**: Inherit from the `Animation` class and implement the `Apply` method to modify the properties of a `Drawable` over time.

## Docker Usage

The project includes a `Dockerfile` for building and running the application in a container, which provides a consistent build environment.

To build and run the Docker image:

```bash
# Build the image
docker build -t littleanim .

# Run the container (ensure you mount a volume to get the output files)
docker run --rm -v "C:/Path/To/Your/Output/Folder:/app/output" littleanim
```
*Note: You may need to adjust the font and output paths in `Program.cs` to function correctly within the container.*

## License

This project is licensed under the Apache 2.0 License. See the [LICENSE](LICENSE) file for details.

# TO DO
Right now it's exporting the frames as PNG'S, this is not ideal since it's an animation generator, will be adding a composable interface to generate this videos.