
## Depth Chart API

---------------------------------------

## Repository code base

The repository consists of projects as below:

| # |Project Name | Project detail | Environment |
| ---| ---  | ---           | ---          |
| 1 | DepthChart | .Net 6.0 API | [![.Net Framework](https://img.shields.io/badge/-.NET%206.0-blueviolet)](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.411-windows-x64-installer)|
| 2 | DepthChartTest | Unit Tests for DepathChart API | [![.Net 6.0](https://img.shields.io/badge/-.NET%206.0-blueviolet)](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.411-windows-x64-installer)

### Summary

This Depth Chart API allows Add and Remove and provides the official player ranking for each position on the team.
```
>	GetFullDepthChart
>	AddPlayerToDepthChart
> RemovePlayerFromDepthChart
> GetBackUp

```

### Setup detail

##### Environment Setup detail

> Download/install   	

> 1. [![VS2022](https://img.shields.io/badge/VS-2022-blue.svg)](https://git-scm.com/downloads) 
>	2. [![.Net Framework](https://img.shields.io/badge/-.NET%206.0-blueviolet)](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.411-windows-x64-installer)
>
| # |Package | Recommended Version
| ---| ---  | ---           
| 1 | .Net | 6.0 
| 2| VS | 2022

##### Project Setup detail

>   1. Please clone or download the repository from [![github](https://img.shields.io/badge/git-hub-blue.svg?style=plastic)](https://github.com/srinivasteella/DepthChart) 

>   
##### (a) To run the API
   
>   1. Open solution in **Visual Studio 2022** 
>   2. Press F5 to run the APP

##### (b) Database
>   1. NFLPlayers.json has a List of NFL Teams and Players
>   2. NFLDepthChart.json to store depth chart information of NFL teams

##### (C) To run the unit test project
>   1. Open solution in **Visual Studio 2022**
>   2. Select Test Project -> Run Tests

##### API { Swagger Page }
==========================================================================
![Home](https://github.com/srinivasteella/DepthChart/blob/master/DepthChartSwagger.PNG")

![AddPlayer]
(https://github.com/srinivasteella/DepthChart/blob/master/AddPlayer.PNG)

![RemovePlayer]
(https://github.com/srinivasteella/DepthChart/blob/master/RemovePlayer.PNG)

![GetBackup]
(https://github.com/srinivasteella/DepthChart/blob/master/GetBackup.PNG)

![FullDepthChart]
(https://github.com/srinivasteella/DepthChart/blob/master/FullDepthChart.PNG)

