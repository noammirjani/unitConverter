# Unit Converter

## Overview
This project is a unit converter that supports conversions for length, weight, and temperature. It provides a simple interface to convert between different units within these categories.

## Features
- **Length Conversion**: Convert between meters, kilometers, miles, yards, feet, and inches.
- **Weight Conversion**: Convert between grams, kilograms, pounds, and ounces.
- **Temperature Conversion**: Convert between Celsius, Fahrenheit, and Kelvin.

## Installation
To install the necessary dependencies, run:
```bash
npm install
```

## Usage
To start the application, run:
```bash
dotnet run
```

## Examples
### Length Conversion
```csharp
ConvertLength(1, "meter", "kilometer"); // 0.001
```

### Weight Conversion
```csharp
ConvertWeight(1000, "gram", "kilogram"); // 1
```

### Temperature Conversion
```csharp
ConvertTemperature(32, "Fahrenheit", "Celsius"); // 0
```


## Contributing
Contributions are welcome! Please fork the repository and submit a pull request.

## License
This project is licensed under the MIT License.