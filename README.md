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
>GetFullDepthChart
>AddPlayerToDepthChart
>RemovePlayerFromDepthChart
>GetBackUp

```

### Setup detail

##### Environment Setup detail

> Download/install   	

> 1. [![VS2022](https://img.shields.io/badge/VS-2022-blue.svg)](https://visualstudio.microsoft.com/vs/) 
>	2. [![.Net Framework](https://img.shields.io/badge/-.NET%206.0-blueviolet)](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.411-windows-x64-installer)

| # |Package | Recommended Version
| ---| ---  | ---           
| 1 | .Net | 6.0 
| 2| VS | 2022

##### Project Setup detail

>   1. Please clone or download the repository from [![github](https://img.shields.io/badge/git-hub-blue.svg?style=plastic)](https://github.com/srinivasteella/DepthChart) 

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
<img width="848" alt="DepthChartSwagger" src="https://github.com/srinivasteella/DepthChart/assets/37522670/f3dd0ec8-c760-4d06-a6fc-3822499316a2">
<img width="550" alt="FullDepthChart" src="https://github.com/srinivasteella/DepthChart/assets/37522670/90f270a7-3fde-40a8-a3b6-f515cacadffb">
<img width="541" alt="AddPlayer" src="https://github.com/srinivasteella/DepthChart/assets/37522670/1422ae74-32c1-4f82-a207-e0d97eb5127f">
<img width="541" alt="RemovePlayer" src="https://github.com/srinivasteella/DepthChart/assets/37522670/d89dd260-bc0b-4d5a-8b96-0517eae506ff">
<img width="542" alt="GetBackup" src="https://github.com/srinivasteella/DepthChart/assets/37522670/f6988b22-2e9c-44d6-a758-52b8442d6b5e">


