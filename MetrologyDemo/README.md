# WPF Metrology & CMM Data Visualizer

A modern, high-performance WPF demonstration project showcasing strict MVVM architecture, Clean Code principles, and asynchronous data handling in **.NET 10**. 
This repository was created as a portfolio piece to demonstrate architectural best practices for desktop applications in the metrology, CAD, and 3D coordinate processing industry.

## Architectural Highlights

This project strictly adheres to the **Model-View-ViewModel (MVVM)** pattern, specifically designed to handle the complexities of 3D spatial data processing:
* **Zero UI Code-Behind:** The `MainWindow.xaml.cs` contains no logic. All interactions are handled via Data Binding and `ICommand` implementations, ensuring the View is entirely decoupled from the business logic.
* **Composition Root:** The ViewModel is injected into the View at startup (`App.xaml.cs`), adhering to dependency inversion principles and making the application highly testable.
* **Asynchronous Operations:** Simulates the loading of massive point clouds (typical of Coordinate Measuring Machines) using `async/await` to guarantee the UI thread remains completely responsive during heavy I/O or database operations.
* **Property Change Routing:** Implements a highly efficient `ViewModelBase` utilizing `CallerMemberName` and `EqualityComparer` to prevent redundant UI updates—a critical optimization when dealing with high-frequency spatial data streams.

## Domain Context: Metrology & 3D Spatial Data

While this is a simplified demo, the architecture is built to scale for real-world metrology requirements:
* The `MeasurementPoint` model acts as an anemic domain model, structured so it could easily be converted into an immutable `readonly record struct` for high-performance memory management of millions of data points.
* The architecture allows for the seamless future integration of 3D rendering engines (e.g., Helix Toolkit, OpenGL) without requiring any changes to the ViewModel or Model layers.

# Getting Started

## Prerequisites
* [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
* Visual Studio 2026 (or your preferred IDE)

## Installation & Run
1. Clone the repository:
   ```bash
   git clone [https://github.com/MrPrototypeBPS/MetrologyDemo.git](https://github.com/MrPrototypeBPS/MetrologyDemo.git)
2. Open MetrologyDemo.sln in Visual Studio.
3. Set MetrologyDemo as the startup project and press F5 to run.

# Future Enhancements
If this were to be expanded into a production application, the following steps would be taken:
* Source Generators: Replace the boilerplate ViewModelBase and RelayCommand with the .NET Community Toolkit (CommunityToolkit.Mvvm) source generators to reduce verbosity.
* Hardware Abstraction: Introduce an ICmmDeviceService interface and inject it into the MainViewModel via Dependency Injection (e.g., Microsoft.Extensions.DependencyInjection) to communicate with actual metrology hardware.
* Unit Testing: Add an xUnit test project to verify the MainViewModel logic, taking advantage of the decoupled architecture.


Authored by Marcus Harteker - https://www.linkedin.com/in/marcus-harteker-2b0a003a4/