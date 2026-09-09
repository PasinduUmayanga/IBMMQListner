# IBMMQListner

[![Build status](https://ci.appveyor.com/api/projects/status/yxu3mfpnvs9av5ag?svg=true)](https://ci.appveyor.com/project/Mahadenamuththa/ibmmqlistner)
[![Build History](https://img.shields.io/badge/AppVeyor-Build%20History-blue?logo=appveyor)](https://ci.appveyor.com/project/PasinduUmayanga/IBMMQListner/history)

![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8-512BD4?logo=dotnet&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-Desktop-0078D4?logo=windows&logoColor=white)
![IBM MQ](https://img.shields.io/badge/IBM%20MQ%20Client-9.2.4.0-052FAD?logo=ibm&logoColor=white)
![Newtonsoft.Json](https://img.shields.io/badge/Newtonsoft.Json-13.0.1-004880)

IBMMQListner is a Windows Forms desktop application that connects to one or more IBM MQ endpoints and listens for messages from configured queues. Queue connection details are stored in `MessageQueueConfig.json`, allowing the application to start listeners for multiple queue managers without changing source code.

## Things Used

- .NET Framework 4.8
- Windows Forms
- IBM XMS .NET client (`IBMXMSDotnetClient` 9.2.4.0)
- Newtonsoft.Json 13.0.1
- AppVeyor for CI builds

## Configuration

Queue endpoints are configured in `IBMMQL.Main\MessageQueueConfig.json`.

```json
{
  "IBMMQ_ENDPOINTS": [
    {
      "IpAddress": "127.0.0.1",
      "PortNumber": 1421,
      "CheckTimeIntervalMiliSeconds": 2000,
      "QueueManagerName": "QM_TEST",
      "QueueName": "QM_TEST.LOCAL.ONE",
      "ChannelName": "QM_TEST.SVRCONN",
      "UserName": "SLTESTUSER",
      "Password": "12345678"
    }
  ]
}
```

Each endpoint supports:

- `IpAddress`: IBM MQ server host or IP address
- `PortNumber`: IBM MQ listener port
- `QueueManagerName`: queue manager name
- `QueueName`: queue to consume messages from
- `ChannelName`: server connection channel
- `UserName` and `Password`: optional credentials for authenticated connections
- `CheckTimeIntervalMiliSeconds`: configured polling interval value

Do not commit real production credentials in `MessageQueueConfig.json`.

## How To Use

1. Install Visual Studio with .NET Framework 4.8 targeting support.
2. Clone the repository.
3. Open `IBMMQListner.sln` in Visual Studio.
4. Restore NuGet packages.
5. Update `IBMMQL.Main\MessageQueueConfig.json` with your IBM MQ endpoint details.
6. Build the solution using the `Release` or `Debug` configuration.
7. Run the `IBMMQL.Main` project.
8. Click the listener start button in the application window to begin receiving messages.

## Build From Command Line

```powershell
nuget restore IBMMQListner.sln
msbuild IBMMQListner.sln /p:Configuration=Release /p:Platform="Any CPU"
```

## CI

The repository includes `appveyor.yml` for AppVeyor builds. AppVeyor restores NuGet packages, caches the `packages` directory, and builds the solution in `Release|Any CPU` mode.
