# PDF Conversion Utility

This project provides a utility for interacting with the Muhimbi Document Converter Web Service to perform various document processing tasks such as PDF conversion, watermarking, applying security, and more.

## Features

- Connects to the Muhimbi Document Converter Web Service.
- Supports PDF conversion, watermarking, security application, and batch processing.
- Configurable service endpoint and binding settings.
- Handles large files up to 50MB with extended timeouts.

## Requirements

- **.NET Version**: .NET 8
- **C# Version**: 12.0
- Muhimbi Document Converter Web Service must be accessible.

## Installation

1. Create a CSharp project with the class files.
2. Update the `SERVICE_URL` in `UtilClass.cs` to point to the correct endpoint of the Muhimbi Document Converter Web Service on your conversion server. Just add your server_name to the String.
_static string SERVICE_URL = "http://server_name:41734/Muhimbi.DocumentConverter.WebService/";_


## Usage

### Opening the Service
Use the `OpenService` method to create and open a connection to the web service and instantiate a DocumentConverterServiceClient instance. 
_DocumentConverterServiceClient? client = UtilClass.OpenService();_

### Converting a document
Call the Convert method of the DocumentConverterServiceClient and pass in the required arguments to perform the conversion. 
_byte[] result = client.Convert(sourceFile, openOptions, conversionSettings);_

### Closing the Service
Ensure the service is properly closed after use:
_UtilClass.CloseService(client);_


## Key Classes and Methods

- **`UtilClass`**: Provides utility methods for opening and closing the service.
  - `OpenService()`: Configures and opens the service client.
  - `CloseService(DocumentConverterServiceClient client)`: Closes the service client if it is open.

- **`DocumentConverterServiceClient`**: The client for interacting with the Muhimbi Document Converter Web Service.
  - `Convert(byte[] sourceFile, OpenOptions openOptions, ConversionSettings conversionSettings)`: Converts a document to another format.
  - Additional methods for watermarking, applying security, and batch processing.

## Notes
- Ensure the service URL is accessible and properly configured.
- The project is designed to handle large files and long-running requests with extended timeouts and increased message size limits.

## License
This project is licensed under the [MIT License](LICENSE).

## Support
For issues or questions, please contact the project maintainer or refer to the Muhimbi documentation for additional guidance.

