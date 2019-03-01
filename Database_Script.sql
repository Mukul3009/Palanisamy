USE [Ang7WebAPI]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 2/25/2019 9:37:11 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [varchar](50) NULL,
	[DateOfBirth] [date] NULL,
	[EmailId] [varchar](50) NULL,
	[Gender] [varchar](10) NULL,
	[Address] [varchar](100) NULL,
	[PinCode] [varchar](50) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


