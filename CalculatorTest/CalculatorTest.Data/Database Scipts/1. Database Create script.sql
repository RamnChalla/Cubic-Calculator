USE [Master]
GO

CREATE DATABASE [Calculations]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'Calculations', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Calculations.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON
( NAME = N'Calculations_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Calculations_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

USE [Calculations]
GO

CREATE TABLE [dbo].[CalculatorResult]
(   
 [ResultId] [int] IDENTITY(1,1) NOT NULL,
 [FunctionName] [varchar](50) NULL,
 [FunctionResult] [varchar](50) NULL 
) ON [PRIMARY]
GO