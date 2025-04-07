
# CustomClient

A custom implementation using `HttpClient`.

## Overview

CustomClient is a C# library designed to provide a custom implementation of the `HttpClient` for making HTTP requests in a more efficient and controlled manner.

## Features

- Simplified HTTP requests
- Customizable request headers
- Support for different HTTP methods (GET, POST, PUT, DELETE)
- Error handling

## Installation

You can install the package via NuGet:

```sh
dotnet add package CustomClient
```

## Usage

Here's a simple example of how to use the CustomClient:

```csharp
using CustomClient;

var client = new CustomHttpClient();
var idIntegration = Guid.NewGuid();

var response = await client.GetBalanceAsync(idIntegration);

Console.WriteLine(response);
```

## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.
```

## Contact

If you have any questions or suggestions, feel free to contact the repository owner.
