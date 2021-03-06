USE [rxgo]
GO
/****** Object:  Table [dbo].[AdminLogin_tbl]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdminLogin_tbl](
	[HospitalId] [bigint] IDENTITY(1,1) NOT NULL,
	[HospitalName] [varchar](100) NULL,
	[HospitalWebsiteUrl] [varchar](100) NULL,
	[Address] [varchar](200) NULL,
	[Phone] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[CountryId] [bigint] NULL,
	[StateId] [bigint] NULL,
	[CityId] [bigint] NULL,
	[IsActive] [bit] NULL CONSTRAINT [DF_AdminLogin_tbl_IsActive]  DEFAULT ((1)),
	[UserType] [varchar](50) NULL CONSTRAINT [DF_AdminLogin_tbl_UserType]  DEFAULT ('ADMIN'),
	[ImgUrl] [varchar](max) NULL,
	[AddedOn] [date] NULL CONSTRAINT [DF_AdminLogin_tbl_AddedOn]  DEFAULT (getdate()),
 CONSTRAINT [PK_AdminLogin_tbl] PRIMARY KEY CLUSTERED 
(
	[HospitalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee_basicdetail_tbl]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee_basicdetail_tbl](
	[EmployeeId] [bigint] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](100) NULL,
	[EmailId] [varchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Phone] [varchar](20) NULL,
	[Age] [varchar](50) NULL,
	[UserTypeId] [bigint] NULL,
	[HospitalId] [bigint] NULL,
	[AddedBy] [bit] NULL CONSTRAINT [DF_Employee_basicdetail_tbl_AddedBy]  DEFAULT ((0)),
	[AddedOn] [date] NULL CONSTRAINT [DF_Employee_basicdetail_tbl_AddedOn]  DEFAULT (getdate()),
	[IsActive] [bit] NULL CONSTRAINT [DF_Employee_basicdetail_tbl_IsActive]  DEFAULT ((1)),
 CONSTRAINT [PK_Employee_basicdetail_tbl] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee_document_tbl]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee_document_tbl](
	[DocumentId] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [bigint] NULL,
	[VoterId] [varchar](max) NULL,
	[PanId] [varchar](max) NULL,
	[AadharId] [varchar](max) NULL,
	[ProfilePic] [varchar](max) NULL,
 CONSTRAINT [PK_Employee_document_tbl] PRIMARY KEY CLUSTERED 
(
	[DocumentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee_Payroll_tbl]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee_Payroll_tbl](
	[PayrollId] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [bigint] NULL,
	[Salary] [decimal](18, 2) NULL,
	[Pf] [decimal](18, 2) NULL,
	[MedicalIncentives] [decimal](18, 2) NULL,
	[ServiceTax] [decimal](18, 2) NULL,
	[Hra] [decimal](18, 2) NULL,
	[HospitalId] [bigint] NULL,
 CONSTRAINT [PK_Employee_Payroll_tbl_1] PRIMARY KEY CLUSTERED 
(
	[PayrollId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Executive_Profile_tbl]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Executive_Profile_tbl](
	[ExecutiveId] [bigint] IDENTITY(1,1) NOT NULL,
	[ExecutiveName] [varchar](100) NULL,
	[ExecutiveEmail] [varchar](50) NULL,
	[ExecutivePhone] [varchar](10) NULL,
	[ExecutiveAge] [varchar](10) NULL,
	[ExecutiveAddress] [varchar](200) NULL,
	[AdminId] [bigint] NULL,
	[IsActive] [bit] NULL CONSTRAINT [DF_Executive_Profile_tbl_IsActive]  DEFAULT ((1)),
	[Password] [nvarchar](50) NULL,
	[CountryId] [bigint] NULL,
	[StateId] [bigint] NULL,
	[CityId] [bigint] NULL,
	[AddedOn] [date] NULL CONSTRAINT [DF_Executive_Profile_tbl_AddedOn]  DEFAULT (getdate()),
 CONSTRAINT [PK_Executive_Profile_tbl] PRIMARY KEY CLUSTERED 
(
	[ExecutiveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Hospital_Services_tbl]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hospital_Services_tbl](
	[ServiceId] [bigint] IDENTITY(1,1) NOT NULL,
	[HospitalId] [bigint] NULL,
	[RoleId] [bigint] NULL,
	[IsActive] [bit] NULL CONSTRAINT [DF_Hospital_Services_tbl_IsActive]  DEFAULT ((1)),
	[OnDate] [date] NULL CONSTRAINT [DF_Hospital_Services_tbl_OnDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_Hospital_Services_tbl] PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Master_AdminLogin_tbl]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Master_AdminLogin_tbl](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[EmailId] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[IsActive] [bit] NULL CONSTRAINT [DF_Master_AdminLogin_tbl_IsActive]  DEFAULT ((1)),
	[UserType] [varchar](50) NULL,
	[Address] [varchar](200) NULL,
	[PhonoNo] [varchar](20) NULL,
	[AddedOn] [date] NULL CONSTRAINT [DF_Master_AdminLogin_tbl_AddedOn]  DEFAULT (getdate()),
 CONSTRAINT [PK_Master_AdminLogin_tbl] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Master_City_tbl]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Master_City_tbl](
	[CityId] [bigint] IDENTITY(1,1) NOT NULL,
	[CountryId] [bigint] NULL,
	[StateId] [bigint] NULL,
	[CityName] [varchar](30) NULL,
	[IsActive] [bit] NULL CONSTRAINT [DF_Master_City_tbl_IsActive]  DEFAULT ((1)),
 CONSTRAINT [PK_Master_City_tbl] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Master_Country_tbl]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Master_Country_tbl](
	[CountryId] [bigint] IDENTITY(1,1) NOT NULL,
	[CountryName] [varchar](100) NULL,
	[IsActive] [bit] NULL CONSTRAINT [DF_Master_Country_tbl_IsActive]  DEFAULT ((1)),
 CONSTRAINT [PK_Master_Country_tbl] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Master_IPDPatient_tbl]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Master_IPDPatient_tbl](
	[IPDNo] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[GuardianName] [varchar](100) NULL,
	[Gender] [varchar](50) NULL,
	[DOB] [date] NULL,
	[Age] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Remarks] [varchar](500) NULL,
	[BloodGroup] [varchar](50) NULL,
	[MaritalStatus] [varchar](50) NULL,
	[PatientPhoto] [varchar](max) NULL,
	[Address] [varchar](500) NULL,
	[AnyKnownAllergies] [varchar](500) NULL,
	[Height] [varchar](50) NULL,
	[Weight] [varchar](50) NULL,
	[Bp] [varchar](50) NULL,
	[Pulse] [varchar](50) NULL,
	[Temperature] [varchar](50) NULL,
	[Respiration] [varchar](50) NULL,
	[SymptomsTitle] [varchar](100) NULL,
	[AppointmentDate] [date] NULL,
	[PCase] [varchar](50) NULL,
	[Casualty] [varchar](50) NULL,
	[Reference] [varchar](100) NULL,
	[ConsultantDoctor] [varchar](100) NULL,
	[CreditLimit] [decimal](18, 2) NULL,
	[PaymentMode] [varchar](100) NULL,
	[OldPatient] [varchar](50) NULL,
	[LiveConsultation] [varchar](50) NULL,
	[Note] [varchar](500) NULL,
	[BedGroup] [varchar](100) NULL,
	[BedNumber] [varchar](100) NULL,
 CONSTRAINT [PK_Master_IPDPatient_tbl] PRIMARY KEY CLUSTERED 
(
	[IPDNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Master_OPDPatient_tbl]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Master_OPDPatient_tbl](
	[PatientId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[GuardianName] [varchar](100) NULL,
	[Gender] [varchar](50) NULL,
	[DOB] [date] NULL,
	[Age] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Remarks] [varchar](500) NULL,
	[BloodGroup] [varchar](50) NULL,
	[MaritalStatus] [varchar](50) NULL,
	[PatientPhoto] [varchar](max) NULL,
	[Address] [varchar](500) NULL,
	[AnyKnownAllergies] [varchar](500) NULL,
	[Height] [varchar](50) NULL,
	[Weight] [varchar](50) NULL,
	[Bp] [varchar](50) NULL,
	[Pulse] [varchar](50) NULL,
	[Temperature] [varchar](50) NULL,
	[Respiration] [varchar](50) NULL,
	[SymptomsTitle] [varchar](100) NULL,
	[AppointmentDate] [date] NULL,
	[PCase] [varchar](50) NULL,
	[Casualty] [varchar](50) NULL,
	[Reference] [varchar](100) NULL,
	[ConsultantDoctor] [varchar](100) NULL,
	[AppliedCharge] [decimal](18, 2) NULL,
	[PaymentMode] [varchar](100) NULL,
	[OldPatient] [varchar](50) NULL,
	[LiveConsultation] [varchar](50) NULL,
	[Note] [varchar](500) NULL,
 CONSTRAINT [PK_Master_OPDPatient_tbl] PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Master_State_tbl]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Master_State_tbl](
	[StateId] [bigint] IDENTITY(1,1) NOT NULL,
	[CountryId] [bigint] NULL,
	[StateName] [varchar](100) NULL,
	[IsActive] [bit] NULL CONSTRAINT [DF_Master_State_tbl_IsActive]  DEFAULT ((1)),
 CONSTRAINT [PK_Master_State_tbl] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PathologyCategory_tbl]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PathologyCategory_tbl](
	[CategoryId] [bigint] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](100) NULL,
	[HospitalId] [bigint] NULL,
	[IsActive] [bit] NULL CONSTRAINT [DF_PathologyCategory_tbl_IsActive]  DEFAULT ((1)),
 CONSTRAINT [PK_PathologyCategory_tbl] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PathologySubcategory_tbl]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PathologySubcategory_tbl](
	[SubCategoryId] [bigint] IDENTITY(1,1) NOT NULL,
	[SubCategoryName] [varchar](100) NULL,
	[CategoryId] [bigint] NULL,
	[HospitalId] [bigint] NULL,
	[IsActive] [bit] NULL CONSTRAINT [DF_PathologySubcategory_tbl_IsActive]  DEFAULT ((1)),
 CONSTRAINT [PK_PathologySubcategory_tbl] PRIMARY KEY CLUSTERED 
(
	[SubCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PathologyTest_tbl]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PathologyTest_tbl](
	[PathologyId] [bigint] IDENTITY(1,1) NOT NULL,
	[TestName] [varchar](100) NULL,
	[ShortName] [varchar](50) NULL,
	[TestType] [varchar](50) NULL,
	[CategoryId] [bigint] NULL,
	[SubCategoryId] [bigint] NULL,
	[Method] [varchar](50) NULL,
	[ReportDays] [varchar](50) NULL,
	[Charge] [decimal](18, 2) NULL,
	[AddedBy] [bigint] NULL,
	[IsActive] [bit] NULL CONSTRAINT [DF_PathologyTest_tbl_IsActive]  DEFAULT ((1)),
 CONSTRAINT [PK_PathologyTest_tbl] PRIMARY KEY CLUSTERED 
(
	[PathologyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role_Master_tbl]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role_Master_tbl](
	[RoleId] [bigint] IDENTITY(1,1) NOT NULL,
	[Services] [varchar](200) NULL,
	[AddedOn] [date] NULL CONSTRAINT [DF_Role_Master_tbl_AddedOn]  DEFAULT (getdate()),
 CONSTRAINT [PK_Role_Master_tbl] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserType_tbl]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserType_tbl](
	[UserTypeId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserType] [varchar](100) NULL,
	[HospitalId] [bigint] NULL,
	[IsActive] [bit] NULL CONSTRAINT [DF_UserType_tbl_IsActive]  DEFAULT ((1)),
 CONSTRAINT [PK_UserType_tbl] PRIMARY KEY CLUSTERED 
(
	[UserTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[Master_View]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Master_View]
AS
SELECT dbo.Master_City_tbl.CountryId, dbo.Master_Country_tbl.CountryName, dbo.Master_City_tbl.StateId, dbo.Master_State_tbl.StateName, dbo.AdminLogin_tbl.HospitalId, dbo.AdminLogin_tbl.HospitalName, 
                  dbo.AdminLogin_tbl.HospitalWebsiteUrl, dbo.AdminLogin_tbl.Address, dbo.AdminLogin_tbl.Phone, dbo.AdminLogin_tbl.Email, dbo.AdminLogin_tbl.Password, dbo.Master_City_tbl.CityName
FROM     dbo.Master_City_tbl CROSS JOIN
                  dbo.Master_Country_tbl CROSS JOIN
                  dbo.Master_State_tbl CROSS JOIN
                  dbo.AdminLogin_tbl

GO
SET IDENTITY_INSERT [dbo].[AdminLogin_tbl] ON 

INSERT [dbo].[AdminLogin_tbl] ([HospitalId], [HospitalName], [HospitalWebsiteUrl], [Address], [Phone], [Email], [Password], [CountryId], [StateId], [CityId], [IsActive], [UserType], [ImgUrl], [AddedOn]) VALUES (11, N'Durgapur Healthworld', N'healthworld.com', N'Durgapur', N'8617008726', N'2qjRZ4pv17msDYK1Bv0jCzN+8p5af3lx', N'oQxxs/c1xk8=', 100, 17, 7, 1, N'ADMIN', NULL, CAST(N'2020-09-25' AS Date))
INSERT [dbo].[AdminLogin_tbl] ([HospitalId], [HospitalName], [HospitalWebsiteUrl], [Address], [Phone], [Email], [Password], [CountryId], [StateId], [CityId], [IsActive], [UserType], [ImgUrl], [AddedOn]) VALUES (13, N'Burdwan Medical College', N'bwdmedical.com', N'Burdwan', N'123456789000', N'2t2Zfemcjv2yBk0VtJ6OPHWoOmdldHyA', N'UnHb7EDg8nIhm4A/q/5mFg==', 100, 17, 7, 1, N'ADMIN', NULL, CAST(N'2020-09-25' AS Date))
INSERT [dbo].[AdminLogin_tbl] ([HospitalId], [HospitalName], [HospitalWebsiteUrl], [Address], [Phone], [Email], [Password], [CountryId], [StateId], [CityId], [IsActive], [UserType], [ImgUrl], [AddedOn]) VALUES (15, N'Durgapur Medical Hospital', N'durgapur.com', N'Durgapur', N'1234569877', N'FsvAirJPT5sQBhR5p+bic28sNxUl8Aye', N'g4xMw5Kwt3E=', 100, 17, 7, 1, N'ADMIN', NULL, CAST(N'2020-09-25' AS Date))
INSERT [dbo].[AdminLogin_tbl] ([HospitalId], [HospitalName], [HospitalWebsiteUrl], [Address], [Phone], [Email], [Password], [CountryId], [StateId], [CityId], [IsActive], [UserType], [ImgUrl], [AddedOn]) VALUES (16, N'Durgapur Medical Hospital', N'dsp.com', N'Burdwan', N'1234456788', N'FRVWFdLWxxGFTn1mk0Q9joAtAeeAeahZ', N'oQxxs/c1xk8=', 100, 35, 6, 1, N'ADMIN', N'~/DataImages/item_0_20201007201734531.png', CAST(N'2020-10-07' AS Date))
INSERT [dbo].[AdminLogin_tbl] ([HospitalId], [HospitalName], [HospitalWebsiteUrl], [Address], [Phone], [Email], [Password], [CountryId], [StateId], [CityId], [IsActive], [UserType], [ImgUrl], [AddedOn]) VALUES (17, N'Deb Nursing', N'debweb.com', N'Burdwan', N'1111111112', N'bWSNk/o/LwriUu+N7OzacA==', N'oQxxs/c1xk8=', 100, 35, 6, 1, N'ADMIN', N'~/DataImages/item_0_20201007203502069.jpg', CAST(N'2020-10-07' AS Date))
INSERT [dbo].[AdminLogin_tbl] ([HospitalId], [HospitalName], [HospitalWebsiteUrl], [Address], [Phone], [Email], [Password], [CountryId], [StateId], [CityId], [IsActive], [UserType], [ImgUrl], [AddedOn]) VALUES (18, N'rg kar college', N'rgcar.com', N'Durgapur', N'1234556788', N'vWBUTLLc586xBwmjeGEZyA==', N'oQxxs/c1xk8=', 100, 34, 5, 1, N'ADMIN', N'~/DataImages/item_0_20201007204054157.jpg', CAST(N'2020-10-07' AS Date))
INSERT [dbo].[AdminLogin_tbl] ([HospitalId], [HospitalName], [HospitalWebsiteUrl], [Address], [Phone], [Email], [Password], [CountryId], [StateId], [CityId], [IsActive], [UserType], [ImgUrl], [AddedOn]) VALUES (19, N'kolkata medical college', N'kolkata.com', N'kolkata', N'1234567789', N'dR0LrmaITWKpKlD5c1ONPilVDL0z8ln5', N'pOxkTc/wQnA7S2NkSokg9A==', 100, 17, 7, 1, N'ADMIN', N'~/DataImages/item_0_20201007204452606.png', CAST(N'2020-10-07' AS Date))
INSERT [dbo].[AdminLogin_tbl] ([HospitalId], [HospitalName], [HospitalWebsiteUrl], [Address], [Phone], [Email], [Password], [CountryId], [StateId], [CityId], [IsActive], [UserType], [ImgUrl], [AddedOn]) VALUES (20, N'Narayana', N'naryana.com', N'Kolkata', N'1234567788', N'zEq0V2Uj0ZgFF6pG9lUzzWfKfxA8wNjF', N'oQxxs/c1xk8=', 100, 17, 8, 1, N'ADMIN', N'~/DataImages/item_0_20201007212842949.png', CAST(N'2020-10-07' AS Date))
INSERT [dbo].[AdminLogin_tbl] ([HospitalId], [HospitalName], [HospitalWebsiteUrl], [Address], [Phone], [Email], [Password], [CountryId], [StateId], [CityId], [IsActive], [UserType], [ImgUrl], [AddedOn]) VALUES (21, N'kolkata', N'kolkata.com', N'kolkata', N'1233444567', N'pOxkTc/wQnC2veoe+CpnwLY/Gw4LomF+', N'oQxxs/c1xk8=', 100, 19, 9, 1, N'ADMIN', N'~/DataImages/item_0_20201007214230288.jpg', CAST(N'2020-10-07' AS Date))
INSERT [dbo].[AdminLogin_tbl] ([HospitalId], [HospitalName], [HospitalWebsiteUrl], [Address], [Phone], [Email], [Password], [CountryId], [StateId], [CityId], [IsActive], [UserType], [ImgUrl], [AddedOn]) VALUES (23, N'test 1', N'test.com', N'Burdwan', N'1234568255', N'XISvLjwmFgBnH3kRbM4QsA==', N'z7HvRjtKMyk=', 100, 17, 7, 1, N'ADMIN', N'~/DataImages/item_0_20201009165805662.png', CAST(N'2020-10-08' AS Date))
INSERT [dbo].[AdminLogin_tbl] ([HospitalId], [HospitalName], [HospitalWebsiteUrl], [Address], [Phone], [Email], [Password], [CountryId], [StateId], [CityId], [IsActive], [UserType], [ImgUrl], [AddedOn]) VALUES (26, N'test', N'test.com', N'Burdwan', N'1234568251', N'u7KCQjkmCK1IF8cq73VM0Q==', N'z7HvRjtKMyk=', 100, 17, 7, 1, N'ADMIN', N'~/DataImages/item_0_20201008010811188.png', CAST(N'2020-10-08' AS Date))
INSERT [dbo].[AdminLogin_tbl] ([HospitalId], [HospitalName], [HospitalWebsiteUrl], [Address], [Phone], [Email], [Password], [CountryId], [StateId], [CityId], [IsActive], [UserType], [ImgUrl], [AddedOn]) VALUES (30, N'Burdwan Medical College1', N'durgapur.com', N'Durgapur', N'1237679754', N'Bg0uwc1WI8eUmXNA8xSkZ6mNJ7kOSdkc', N'oQxxs/c1xk8=', 100, 17, 7, 1, N'ADMIN', NULL, CAST(N'2020-10-16' AS Date))
INSERT [dbo].[AdminLogin_tbl] ([HospitalId], [HospitalName], [HospitalWebsiteUrl], [Address], [Phone], [Email], [Password], [CountryId], [StateId], [CityId], [IsActive], [UserType], [ImgUrl], [AddedOn]) VALUES (31, N'Burdwan Medical College12', N'durgapur22.com', N'Durgapur', N'2222244233', N'FsvAirJPT5sSuLGJCuFDYjouoypKZ3fi', N'JBLMxRwWVx0=', 100, 34, 5, 1, N'ADMIN', N'~/DataImages/item_0_20201016214639210.jpg', CAST(N'2020-10-16' AS Date))
INSERT [dbo].[AdminLogin_tbl] ([HospitalId], [HospitalName], [HospitalWebsiteUrl], [Address], [Phone], [Email], [Password], [CountryId], [StateId], [CityId], [IsActive], [UserType], [ImgUrl], [AddedOn]) VALUES (32, N'dsdd', N'www.google.com', N'Durgapur', N'1244434788', N'h5kaCyBVcmTG6N7gQ2EXsjNKUd8gLnXR', N'53qsjh/Uy+s=', 100, 19, 9, 1, N'ADMIN', NULL, CAST(N'2020-10-16' AS Date))
INSERT [dbo].[AdminLogin_tbl] ([HospitalId], [HospitalName], [HospitalWebsiteUrl], [Address], [Phone], [Email], [Password], [CountryId], [StateId], [CityId], [IsActive], [UserType], [ImgUrl], [AddedOn]) VALUES (34, N'Durgapur Hospital12', N'www.google.com', N'Durgapur', N'5555555544', N'FsvAirJPT5utSjk9LYhBUKX+AxTHyLS4', N'NiLAzBpObQ1jdxtRo3jEiw==', 100, 17, 8, 1, N'ADMIN', NULL, CAST(N'2020-10-16' AS Date))
INSERT [dbo].[AdminLogin_tbl] ([HospitalId], [HospitalName], [HospitalWebsiteUrl], [Address], [Phone], [Email], [Password], [CountryId], [StateId], [CityId], [IsActive], [UserType], [ImgUrl], [AddedOn]) VALUES (35, N'Durgapur Healthworld Test', N'test.com', N'Durgapur', N'5462463777', N'DUfWK3C6z7Y7+ZHkfk4bY6OiP2c0s0vh', N'oQxxs/c1xk8=', 100, 17, 7, 1, N'ADMIN', N'~/DataImages/item_0_20201017113235235.jpg', CAST(N'2020-10-17' AS Date))
INSERT [dbo].[AdminLogin_tbl] ([HospitalId], [HospitalName], [HospitalWebsiteUrl], [Address], [Phone], [Email], [Password], [CountryId], [StateId], [CityId], [IsActive], [UserType], [ImgUrl], [AddedOn]) VALUES (37, N'Durgapur Hospital00', N'durgapur.com', N'Durgapur', N'4454545455', N'FsvAirJPT5tnXCMmj+30UXSt+tRcnS8Z', N'/jQixKFZ8bWzPf2l3z31iQ==', 100, 2, 11, 1, N'ADMIN', NULL, CAST(N'2020-10-17' AS Date))
SET IDENTITY_INSERT [dbo].[AdminLogin_tbl] OFF
SET IDENTITY_INSERT [dbo].[Employee_basicdetail_tbl] ON 

INSERT [dbo].[Employee_basicdetail_tbl] ([EmployeeId], [FullName], [EmailId], [Password], [Phone], [Age], [UserTypeId], [HospitalId], [AddedBy], [AddedOn], [IsActive]) VALUES (1, N'deb', N'deb@gmail.com', N'995811', N'9876567666', N'23', 1, 31, 0, CAST(N'2020-10-22' AS Date), 1)
INSERT [dbo].[Employee_basicdetail_tbl] ([EmployeeId], [FullName], [EmailId], [Password], [Phone], [Age], [UserTypeId], [HospitalId], [AddedBy], [AddedOn], [IsActive]) VALUES (2, N'deb1', N'deb1@gmail.com', N'878787', N'8766556757', N'25', 1, 31, 0, CAST(N'2020-10-22' AS Date), 1)
INSERT [dbo].[Employee_basicdetail_tbl] ([EmployeeId], [FullName], [EmailId], [Password], [Phone], [Age], [UserTypeId], [HospitalId], [AddedBy], [AddedOn], [IsActive]) VALUES (3, N'ddede', N'dd@gmail.com', N'276596', N'8787676766', N'55', 1, 31, 0, CAST(N'2020-10-22' AS Date), 1)
INSERT [dbo].[Employee_basicdetail_tbl] ([EmployeeId], [FullName], [EmailId], [Password], [Phone], [Age], [UserTypeId], [HospitalId], [AddedBy], [AddedOn], [IsActive]) VALUES (4, N'deb das', N'deb@gmail.com', N'924159', N'9876775555', N'21', 1, 31, 0, CAST(N'2020-10-22' AS Date), 1)
INSERT [dbo].[Employee_basicdetail_tbl] ([EmployeeId], [FullName], [EmailId], [Password], [Phone], [Age], [UserTypeId], [HospitalId], [AddedBy], [AddedOn], [IsActive]) VALUES (5, N'gg', N'g@gmail.com', N'657027', N'8788787878', N'55', 1, 31, 0, CAST(N'2020-10-22' AS Date), 1)
INSERT [dbo].[Employee_basicdetail_tbl] ([EmployeeId], [FullName], [EmailId], [Password], [Phone], [Age], [UserTypeId], [HospitalId], [AddedBy], [AddedOn], [IsActive]) VALUES (6, N'debdas ', N'debdas@gmail.com', N'947324', N'9865777766', N'65', 1, 31, 0, CAST(N'2020-10-22' AS Date), 1)
INSERT [dbo].[Employee_basicdetail_tbl] ([EmployeeId], [FullName], [EmailId], [Password], [Phone], [Age], [UserTypeId], [HospitalId], [AddedBy], [AddedOn], [IsActive]) VALUES (7, N'eerrre', N'er@gmail.com', N'517774', N'9876756737', N'66', 1, 31, 0, CAST(N'2020-10-22' AS Date), 1)
INSERT [dbo].[Employee_basicdetail_tbl] ([EmployeeId], [FullName], [EmailId], [Password], [Phone], [Age], [UserTypeId], [HospitalId], [AddedBy], [AddedOn], [IsActive]) VALUES (8, N'hhh', N'hh@gmail.com', N'680765', N'8788777777', N'22', 1, 31, 0, CAST(N'2020-10-22' AS Date), 1)
INSERT [dbo].[Employee_basicdetail_tbl] ([EmployeeId], [FullName], [EmailId], [Password], [Phone], [Age], [UserTypeId], [HospitalId], [AddedBy], [AddedOn], [IsActive]) VALUES (9, N'asddd', N'asdd@gmail.com', N'365148', N'1288888888', N'47', 1, 31, 0, CAST(N'2020-10-22' AS Date), 1)
INSERT [dbo].[Employee_basicdetail_tbl] ([EmployeeId], [FullName], [EmailId], [Password], [Phone], [Age], [UserTypeId], [HospitalId], [AddedBy], [AddedOn], [IsActive]) VALUES (10, N'rr', N'rr@gmail.com', N'475190', N'8878788777', N'77', 1, 31, 0, CAST(N'2020-10-22' AS Date), 1)
INSERT [dbo].[Employee_basicdetail_tbl] ([EmployeeId], [FullName], [EmailId], [Password], [Phone], [Age], [UserTypeId], [HospitalId], [AddedBy], [AddedOn], [IsActive]) VALUES (11, N'rr', N'rr@gmail.com', N'406824', N'9999999999', N'66', 1, 31, 0, CAST(N'2020-10-22' AS Date), 1)
INSERT [dbo].[Employee_basicdetail_tbl] ([EmployeeId], [FullName], [EmailId], [Password], [Phone], [Age], [UserTypeId], [HospitalId], [AddedBy], [AddedOn], [IsActive]) VALUES (12, N'rr', N'rr@gmail.com', N'655187', N'9898988888', N'44', 1, 31, 0, CAST(N'2020-10-22' AS Date), 1)
INSERT [dbo].[Employee_basicdetail_tbl] ([EmployeeId], [FullName], [EmailId], [Password], [Phone], [Age], [UserTypeId], [HospitalId], [AddedBy], [AddedOn], [IsActive]) VALUES (13, N'rr', N'rr@gmail.com', N'027823', N'3333333333', N'33', 1, 31, 0, CAST(N'2020-10-22' AS Date), 1)
INSERT [dbo].[Employee_basicdetail_tbl] ([EmployeeId], [FullName], [EmailId], [Password], [Phone], [Age], [UserTypeId], [HospitalId], [AddedBy], [AddedOn], [IsActive]) VALUES (16, N'rr1', N'rr1@gmail.com', N'165537', N'3333333322', N'22', 1, 31, 0, CAST(N'2020-10-27' AS Date), 1)
INSERT [dbo].[Employee_basicdetail_tbl] ([EmployeeId], [FullName], [EmailId], [Password], [Phone], [Age], [UserTypeId], [HospitalId], [AddedBy], [AddedOn], [IsActive]) VALUES (17, N'rr12', N'rr12@gmail.com', N'957167', N'5434343333', N'44', 1, 31, 0, CAST(N'2020-10-27' AS Date), 1)
INSERT [dbo].[Employee_basicdetail_tbl] ([EmployeeId], [FullName], [EmailId], [Password], [Phone], [Age], [UserTypeId], [HospitalId], [AddedBy], [AddedOn], [IsActive]) VALUES (18, N'ddd', N'dd@gmail.com', N'729970', N'8787655665', N'44', 2, 31, 0, CAST(N'2020-10-27' AS Date), 1)
INSERT [dbo].[Employee_basicdetail_tbl] ([EmployeeId], [FullName], [EmailId], [Password], [Phone], [Age], [UserTypeId], [HospitalId], [AddedBy], [AddedOn], [IsActive]) VALUES (19, N'rintu das', N'rintu1@gmail.com', N'990099', N'8617008726', N'30', 2, 31, 0, CAST(N'2020-10-27' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Employee_basicdetail_tbl] OFF
SET IDENTITY_INSERT [dbo].[Employee_document_tbl] ON 

INSERT [dbo].[Employee_document_tbl] ([DocumentId], [EmployeeId], [VoterId], [PanId], [AadharId], [ProfilePic]) VALUES (1, 7, NULL, NULL, NULL, NULL)
INSERT [dbo].[Employee_document_tbl] ([DocumentId], [EmployeeId], [VoterId], [PanId], [AadharId], [ProfilePic]) VALUES (2, 8, NULL, NULL, NULL, NULL)
INSERT [dbo].[Employee_document_tbl] ([DocumentId], [EmployeeId], [VoterId], [PanId], [AadharId], [ProfilePic]) VALUES (3, 9, NULL, NULL, NULL, NULL)
INSERT [dbo].[Employee_document_tbl] ([DocumentId], [EmployeeId], [VoterId], [PanId], [AadharId], [ProfilePic]) VALUES (4, 10, NULL, NULL, NULL, NULL)
INSERT [dbo].[Employee_document_tbl] ([DocumentId], [EmployeeId], [VoterId], [PanId], [AadharId], [ProfilePic]) VALUES (5, 11, NULL, NULL, NULL, NULL)
INSERT [dbo].[Employee_document_tbl] ([DocumentId], [EmployeeId], [VoterId], [PanId], [AadharId], [ProfilePic]) VALUES (6, 12, NULL, NULL, NULL, NULL)
INSERT [dbo].[Employee_document_tbl] ([DocumentId], [EmployeeId], [VoterId], [PanId], [AadharId], [ProfilePic]) VALUES (7, 13, NULL, NULL, NULL, NULL)
INSERT [dbo].[Employee_document_tbl] ([DocumentId], [EmployeeId], [VoterId], [PanId], [AadharId], [ProfilePic]) VALUES (10, 16, NULL, NULL, NULL, NULL)
INSERT [dbo].[Employee_document_tbl] ([DocumentId], [EmployeeId], [VoterId], [PanId], [AadharId], [ProfilePic]) VALUES (11, 17, N'~/DataImages/F:\heartNsoul Projects\RXGOADMIN\RXGOADMIN\DataImages\papiya-img.jpg', NULL, NULL, NULL)
INSERT [dbo].[Employee_document_tbl] ([DocumentId], [EmployeeId], [VoterId], [PanId], [AadharId], [ProfilePic]) VALUES (12, 18, N'~/DataImages/chuti-img.jpg', N'~/DataImages/papiya-img.jpg', N'~/DataImages/antu-img.jpg', N'~/DataImages/chuti-sig.jpg')
INSERT [dbo].[Employee_document_tbl] ([DocumentId], [EmployeeId], [VoterId], [PanId], [AadharId], [ProfilePic]) VALUES (13, 19, N'~/DataImages/chuti-img.jpg', N'~/DataImages/papiya-img.jpg', N'~/DataImages/antu-img.jpg', N'~/DataImages/chuti-sig.jpg')
SET IDENTITY_INSERT [dbo].[Employee_document_tbl] OFF
SET IDENTITY_INSERT [dbo].[Employee_Payroll_tbl] ON 

INSERT [dbo].[Employee_Payroll_tbl] ([PayrollId], [EmployeeId], [Salary], [Pf], [MedicalIncentives], [ServiceTax], [Hra], [HospitalId]) VALUES (1, 6, CAST(1000.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), 31)
INSERT [dbo].[Employee_Payroll_tbl] ([PayrollId], [EmployeeId], [Salary], [Pf], [MedicalIncentives], [ServiceTax], [Hra], [HospitalId]) VALUES (2, 7, CAST(12111.00 AS Decimal(18, 2)), CAST(111.00 AS Decimal(18, 2)), CAST(111.00 AS Decimal(18, 2)), CAST(1112.00 AS Decimal(18, 2)), CAST(1111.00 AS Decimal(18, 2)), 31)
INSERT [dbo].[Employee_Payroll_tbl] ([PayrollId], [EmployeeId], [Salary], [Pf], [MedicalIncentives], [ServiceTax], [Hra], [HospitalId]) VALUES (3, 8, CAST(10000.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), 31)
INSERT [dbo].[Employee_Payroll_tbl] ([PayrollId], [EmployeeId], [Salary], [Pf], [MedicalIncentives], [ServiceTax], [Hra], [HospitalId]) VALUES (4, 9, CAST(111.00 AS Decimal(18, 2)), CAST(11.00 AS Decimal(18, 2)), CAST(11.00 AS Decimal(18, 2)), CAST(11.00 AS Decimal(18, 2)), CAST(11.00 AS Decimal(18, 2)), 31)
INSERT [dbo].[Employee_Payroll_tbl] ([PayrollId], [EmployeeId], [Salary], [Pf], [MedicalIncentives], [ServiceTax], [Hra], [HospitalId]) VALUES (5, 10, CAST(111111111.00 AS Decimal(18, 2)), CAST(1111.00 AS Decimal(18, 2)), CAST(11111.00 AS Decimal(18, 2)), CAST(1111111.00 AS Decimal(18, 2)), CAST(111111111.00 AS Decimal(18, 2)), 31)
INSERT [dbo].[Employee_Payroll_tbl] ([PayrollId], [EmployeeId], [Salary], [Pf], [MedicalIncentives], [ServiceTax], [Hra], [HospitalId]) VALUES (6, 11, CAST(99999.00 AS Decimal(18, 2)), CAST(9999.00 AS Decimal(18, 2)), CAST(99999.00 AS Decimal(18, 2)), CAST(99999.00 AS Decimal(18, 2)), CAST(99999.00 AS Decimal(18, 2)), 31)
INSERT [dbo].[Employee_Payroll_tbl] ([PayrollId], [EmployeeId], [Salary], [Pf], [MedicalIncentives], [ServiceTax], [Hra], [HospitalId]) VALUES (7, 12, CAST(888.00 AS Decimal(18, 2)), CAST(888.00 AS Decimal(18, 2)), CAST(8888.00 AS Decimal(18, 2)), CAST(888.00 AS Decimal(18, 2)), CAST(888.00 AS Decimal(18, 2)), 31)
INSERT [dbo].[Employee_Payroll_tbl] ([PayrollId], [EmployeeId], [Salary], [Pf], [MedicalIncentives], [ServiceTax], [Hra], [HospitalId]) VALUES (8, 13, CAST(3333.00 AS Decimal(18, 2)), CAST(33333.00 AS Decimal(18, 2)), CAST(33333.00 AS Decimal(18, 2)), CAST(333333.00 AS Decimal(18, 2)), CAST(33333.00 AS Decimal(18, 2)), 31)
INSERT [dbo].[Employee_Payroll_tbl] ([PayrollId], [EmployeeId], [Salary], [Pf], [MedicalIncentives], [ServiceTax], [Hra], [HospitalId]) VALUES (11, 16, CAST(66.00 AS Decimal(18, 2)), CAST(33.00 AS Decimal(18, 2)), CAST(33.00 AS Decimal(18, 2)), CAST(33.00 AS Decimal(18, 2)), CAST(33.00 AS Decimal(18, 2)), 31)
INSERT [dbo].[Employee_Payroll_tbl] ([PayrollId], [EmployeeId], [Salary], [Pf], [MedicalIncentives], [ServiceTax], [Hra], [HospitalId]) VALUES (12, 17, CAST(55.00 AS Decimal(18, 2)), CAST(55.00 AS Decimal(18, 2)), CAST(55.00 AS Decimal(18, 2)), CAST(55.00 AS Decimal(18, 2)), CAST(55.00 AS Decimal(18, 2)), 31)
INSERT [dbo].[Employee_Payroll_tbl] ([PayrollId], [EmployeeId], [Salary], [Pf], [MedicalIncentives], [ServiceTax], [Hra], [HospitalId]) VALUES (13, 18, CAST(44.00 AS Decimal(18, 2)), CAST(44444.00 AS Decimal(18, 2)), CAST(44.00 AS Decimal(18, 2)), CAST(44.00 AS Decimal(18, 2)), CAST(44.00 AS Decimal(18, 2)), 31)
INSERT [dbo].[Employee_Payroll_tbl] ([PayrollId], [EmployeeId], [Salary], [Pf], [MedicalIncentives], [ServiceTax], [Hra], [HospitalId]) VALUES (14, 19, CAST(1000.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), CAST(500.00 AS Decimal(18, 2)), CAST(500.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), 31)
SET IDENTITY_INSERT [dbo].[Employee_Payroll_tbl] OFF
SET IDENTITY_INSERT [dbo].[Executive_Profile_tbl] ON 

INSERT [dbo].[Executive_Profile_tbl] ([ExecutiveId], [ExecutiveName], [ExecutiveEmail], [ExecutivePhone], [ExecutiveAge], [ExecutiveAddress], [AdminId], [IsActive], [Password], [CountryId], [StateId], [CityId], [AddedOn]) VALUES (4, N'Debsankar Das', N'LtaUeX9w5a7A1ITqRAfMox+d82wNx1Uo', N'1234567890', N'26', N'Durgapur', 9, 1, N'UnHb7EDg8nKI3prNkdN2Wg==', 100, 17, 7, CAST(N'2020-10-02' AS Date))
INSERT [dbo].[Executive_Profile_tbl] ([ExecutiveId], [ExecutiveName], [ExecutiveEmail], [ExecutivePhone], [ExecutiveAge], [ExecutiveAddress], [AdminId], [IsActive], [Password], [CountryId], [StateId], [CityId], [AddedOn]) VALUES (18, N'Debsankar', N'deb@gmail.com', N'1234567899', N'25', N'Durgapur City Center', 13, 1, N'UnHb7EDg8nKI3prNkdN2Wg==', 100, 17, 7, CAST(N'2020-10-09' AS Date))
INSERT [dbo].[Executive_Profile_tbl] ([ExecutiveId], [ExecutiveName], [ExecutiveEmail], [ExecutivePhone], [ExecutiveAge], [ExecutiveAddress], [AdminId], [IsActive], [Password], [CountryId], [StateId], [CityId], [AddedOn]) VALUES (20, N'Debsankar Das1', N'mHOGhrqX6Y/DonuW4FHGlJ0L+mUYa6Eb', N'1233232221', N'25', N'Durgapur', 31, 1, N'fDUU2yUK27g=', 100, 17, 8, CAST(N'2020-10-19' AS Date))
SET IDENTITY_INSERT [dbo].[Executive_Profile_tbl] OFF
SET IDENTITY_INSERT [dbo].[Hospital_Services_tbl] ON 

INSERT [dbo].[Hospital_Services_tbl] ([ServiceId], [HospitalId], [RoleId], [IsActive], [OnDate]) VALUES (1, 30, 2, 1, CAST(N'2020-10-16' AS Date))
INSERT [dbo].[Hospital_Services_tbl] ([ServiceId], [HospitalId], [RoleId], [IsActive], [OnDate]) VALUES (2, 31, 2, 1, CAST(N'2020-10-16' AS Date))
INSERT [dbo].[Hospital_Services_tbl] ([ServiceId], [HospitalId], [RoleId], [IsActive], [OnDate]) VALUES (3, 31, 1, 1, CAST(N'2020-10-16' AS Date))
INSERT [dbo].[Hospital_Services_tbl] ([ServiceId], [HospitalId], [RoleId], [IsActive], [OnDate]) VALUES (4, 32, NULL, 1, CAST(N'2020-10-16' AS Date))
INSERT [dbo].[Hospital_Services_tbl] ([ServiceId], [HospitalId], [RoleId], [IsActive], [OnDate]) VALUES (5, 32, 1, 1, CAST(N'2020-10-16' AS Date))
INSERT [dbo].[Hospital_Services_tbl] ([ServiceId], [HospitalId], [RoleId], [IsActive], [OnDate]) VALUES (6, 33, 2, 1, CAST(N'2020-10-16' AS Date))
INSERT [dbo].[Hospital_Services_tbl] ([ServiceId], [HospitalId], [RoleId], [IsActive], [OnDate]) VALUES (7, 33, 2, 1, CAST(N'2020-10-16' AS Date))
INSERT [dbo].[Hospital_Services_tbl] ([ServiceId], [HospitalId], [RoleId], [IsActive], [OnDate]) VALUES (8, 34, 1, 1, CAST(N'2020-10-16' AS Date))
INSERT [dbo].[Hospital_Services_tbl] ([ServiceId], [HospitalId], [RoleId], [IsActive], [OnDate]) VALUES (12, 35, 1, 1, CAST(N'2020-10-17' AS Date))
INSERT [dbo].[Hospital_Services_tbl] ([ServiceId], [HospitalId], [RoleId], [IsActive], [OnDate]) VALUES (13, 35, 2, 1, CAST(N'2020-10-17' AS Date))
INSERT [dbo].[Hospital_Services_tbl] ([ServiceId], [HospitalId], [RoleId], [IsActive], [OnDate]) VALUES (14, 37, 2, 1, CAST(N'2020-10-17' AS Date))
SET IDENTITY_INSERT [dbo].[Hospital_Services_tbl] OFF
SET IDENTITY_INSERT [dbo].[Master_AdminLogin_tbl] ON 

INSERT [dbo].[Master_AdminLogin_tbl] ([UserId], [EmailId], [Password], [IsActive], [UserType], [Address], [PhonoNo], [AddedOn]) VALUES (1, N'rxgo@gmail.com', N'123456', 1, N'MASTER ADMIN', N'Durgapur', N'1234567890', NULL)
SET IDENTITY_INSERT [dbo].[Master_AdminLogin_tbl] OFF
SET IDENTITY_INSERT [dbo].[Master_City_tbl] ON 

INSERT [dbo].[Master_City_tbl] ([CityId], [CountryId], [StateId], [CityName], [IsActive]) VALUES (2, 100, 1, N'Andaman', 1)
INSERT [dbo].[Master_City_tbl] ([CityId], [CountryId], [StateId], [CityName], [IsActive]) VALUES (3, 100, 40, N'Durgapur', 1)
INSERT [dbo].[Master_City_tbl] ([CityId], [CountryId], [StateId], [CityName], [IsActive]) VALUES (5, 100, 34, N'Tamil nadu', 1)
INSERT [dbo].[Master_City_tbl] ([CityId], [CountryId], [StateId], [CityName], [IsActive]) VALUES (6, 100, 35, N'Telangana', 1)
INSERT [dbo].[Master_City_tbl] ([CityId], [CountryId], [StateId], [CityName], [IsActive]) VALUES (7, 100, 17, N'Bangalore', 1)
INSERT [dbo].[Master_City_tbl] ([CityId], [CountryId], [StateId], [CityName], [IsActive]) VALUES (8, 100, 17, N'Mysuru', 1)
INSERT [dbo].[Master_City_tbl] ([CityId], [CountryId], [StateId], [CityName], [IsActive]) VALUES (9, 100, 19, N'Kochi', 1)
INSERT [dbo].[Master_City_tbl] ([CityId], [CountryId], [StateId], [CityName], [IsActive]) VALUES (11, 100, 2, N'Andra Pradesh', 1)
SET IDENTITY_INSERT [dbo].[Master_City_tbl] OFF
SET IDENTITY_INSERT [dbo].[Master_Country_tbl] ON 

INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (1, N'Afghanistan', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (2, N'Albania', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (3, N'Algeria', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (4, N'American Samoa', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (5, N'Andorra', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (6, N'Angola', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (7, N'Anguilla', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (8, N'Antarctica', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (9, N'Antigua and Barbuda', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (10, N'Argentina', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (11, N'Armenia', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (12, N'Aruba', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (13, N'Australia', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (14, N'Austria', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (15, N'Azerbaijan', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (16, N'Bahamas', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (17, N'Bahrain', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (18, N'Bangladesh', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (19, N'Barbados', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (20, N'Belarus', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (21, N'Belgium', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (22, N'Belize', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (23, N'Benin', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (24, N'Bermuda', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (25, N'Bhutan', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (26, N'Bolivia', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (27, N'Bosnia and Herzegovina', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (28, N'Botswana', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (29, N'Bouvet Island', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (30, N'Brazil', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (31, N'British Indian Ocean Territory', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (32, N'Brunei Darussalam', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (33, N'Bulgaria', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (34, N'Burkina Faso', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (35, N'Burundi', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (36, N'Cambodia', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (37, N'Cameroon', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (38, N'Canada', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (39, N'Cape Verde', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (40, N'Cayman Islands', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (41, N'Central African Republic', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (42, N'Chad', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (43, N'Chile', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (44, N'China', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (45, N'Christmas Island', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (46, N'Cocos (Keeling) Islands', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (47, N'Colombia', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (48, N'Comoros', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (49, N'Democratic Republic of the Congo', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (50, N'Republic of Congo', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (51, N'Cook Islands', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (52, N'Costa Rica', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (53, N'Croatia (Hrvatska)', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (54, N'Cuba', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (55, N'Cyprus', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (56, N'Czech Republic', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (57, N'Denmark', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (58, N'Djibouti', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (59, N'Dominica', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (60, N'Dominican Republic', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (61, N'East Timor', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (62, N'Ecuador', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (63, N'Egypt', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (64, N'El Salvador', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (65, N'Equatorial Guinea', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (66, N'Eritrea', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (67, N'Estonia', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (68, N'Ethiopia', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (69, N'Falkland Islands (Malvinas)', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (70, N'Faroe Islands', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (71, N'Fiji', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (72, N'Finland', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (73, N'France', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (74, N'France, Metropolitan', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (75, N'French Guiana', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (76, N'French Polynesia', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (77, N'French Southern Territories', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (78, N'Gabon', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (79, N'Gambia', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (80, N'Georgia', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (81, N'Germany', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (82, N'Ghana', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (83, N'Gibraltar', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (84, N'Guernsey', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (85, N'Greece', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (86, N'Greenland', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (87, N'Grenada', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (88, N'Guadeloupe', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (89, N'Guam', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (90, N'Guatemala', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (91, N'Guinea', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (92, N'Guinea-Bissau', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (93, N'Guyana', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (94, N'Haiti', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (95, N'Heard and Mc Donald Islands', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (96, N'Honduras', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (97, N'Hong Kong', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (98, N'Hungary', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (99, N'Iceland', 0)
GO
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (100, N'India', 1)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (101, N'Isle of Man', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (102, N'Indonesia', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (103, N'Iran (Islamic Republic of)', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (104, N'Iraq', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (105, N'Ireland', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (106, N'Israel', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (107, N'Italy', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (108, N'Ivory Coast', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (109, N'Jersey', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (110, N'Jamaica', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (111, N'Japan', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (112, N'Jordan', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (113, N'Kazakhstan', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (114, N'Kenya', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (115, N'Kiribati', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (116, N'Korea, Democratic People''s Republic of', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (117, N'Korea, Republic of', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (118, N'Kosovo', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (119, N'Kuwait', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (120, N'Kyrgyzstan', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (121, N'Lao People''s Democratic Republic', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (122, N'Latvia', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (123, N'Lebanon', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (124, N'Lesotho', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (125, N'Liberia', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (126, N'Libyan Arab Jamahiriya', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (127, N'Liechtenstein', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (128, N'Lithuania', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (129, N'Luxembourg', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (130, N'Macau', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (131, N'North Macedonia', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (132, N'Madagascar', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (133, N'Malawi', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (134, N'Malaysia', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (135, N'Maldives', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (136, N'Mali', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (137, N'Malta', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (138, N'Marshall Islands', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (139, N'Martinique', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (140, N'Mauritania', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (141, N'Mauritius', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (142, N'Mayotte', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (143, N'Mexico', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (144, N'Micronesia, Federated States of', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (145, N'Moldova, Republic of', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (146, N'Monaco', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (147, N'Mongolia', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (148, N'Montenegro', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (149, N'Montserrat', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (150, N'Morocco', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (151, N'Mozambique', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (152, N'Myanmar', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (153, N'Namibia', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (154, N'Nauru', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (155, N'Nepal', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (156, N'Netherlands', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (157, N'Netherlands Antilles', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (158, N'New Caledonia', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (159, N'New Zealand', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (160, N'Nicaragua', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (161, N'Niger', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (162, N'Nigeria', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (163, N'Niue', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (164, N'Norfolk Island', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (165, N'Northern Mariana Islands', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (166, N'Norway', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (167, N'Oman', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (168, N'Pakistan', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (169, N'Palau', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (170, N'Palestine', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (171, N'Panama', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (172, N'Papua New Guinea', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (173, N'Paraguay', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (174, N'Peru', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (175, N'Philippines', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (176, N'Pitcairn', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (177, N'Poland', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (178, N'Portugal', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (179, N'Puerto Rico', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (180, N'Qatar', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (181, N'Reunion', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (182, N'Romania', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (183, N'Russian Federation', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (184, N'Rwanda', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (185, N'Saint Kitts and Nevis', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (186, N'Saint Lucia', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (187, N'Saint Vincent and the Grenadines', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (188, N'Samoa', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (189, N'San Marino', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (190, N'Sao Tome and Principe', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (191, N'Saudi Arabia', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (192, N'Senegal', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (193, N'Serbia', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (194, N'Seychelles', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (195, N'Sierra Leone', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (196, N'Singapore', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (197, N'Slovakia', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (198, N'Slovenia', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (199, N'Solomon Islands', 0)
GO
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (200, N'Somalia', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (201, N'South Africa', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (202, N'South Georgia South Sandwich Islands', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (203, N'South Sudan', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (204, N'Spain', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (205, N'Sri Lanka', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (206, N'St. Helena', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (207, N'St. Pierre and Miquelon', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (208, N'Sudan', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (209, N'Suriname', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (210, N'Svalbard and Jan Mayen Islands', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (211, N'Swaziland', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (212, N'Sweden', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (213, N'Switzerland', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (214, N'Syrian Arab Republic', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (215, N'Taiwan', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (216, N'Tajikistan', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (217, N'Tanzania, United Republic of', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (218, N'Thailand', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (219, N'Togo', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (220, N'Tokelau', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (221, N'Tonga', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (222, N'Trinidad and Tobago', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (223, N'Tunisia', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (224, N'Turkey', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (225, N'Turkmenistan', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (226, N'Turks and Caicos Islands', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (227, N'Tuvalu', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (228, N'Uganda', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (229, N'Ukraine', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (230, N'United Arab Emirates', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (231, N'United Kingdom', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (232, N'United States', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (233, N'United States minor outlying islands', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (234, N'Uruguay', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (235, N'Uzbekistan', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (236, N'Vanuatu', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (237, N'Vatican City State', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (238, N'Venezuela', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (239, N'Vietnam', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (240, N'Virgin Islands (British)', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (241, N'Virgin Islands (U.S.)', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (242, N'Wallis and Futuna Islands', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (243, N'Western Sahara', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (244, N'Yemen', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (245, N'Zambia', 0)
INSERT [dbo].[Master_Country_tbl] ([CountryId], [CountryName], [IsActive]) VALUES (246, N'Zimbabwe', 0)
SET IDENTITY_INSERT [dbo].[Master_Country_tbl] OFF
SET IDENTITY_INSERT [dbo].[Master_OPDPatient_tbl] ON 

INSERT [dbo].[Master_OPDPatient_tbl] ([PatientId], [Name], [GuardianName], [Gender], [DOB], [Age], [Phone], [Email], [Remarks], [BloodGroup], [MaritalStatus], [PatientPhoto], [Address], [AnyKnownAllergies], [Height], [Weight], [Bp], [Pulse], [Temperature], [Respiration], [SymptomsTitle], [AppointmentDate], [PCase], [Casualty], [Reference], [ConsultantDoctor], [AppliedCharge], [PaymentMode], [OldPatient], [LiveConsultation], [Note]) VALUES (1, N'Debsankar Das', N'Amiya krishna das', N'Male', CAST(N'2010-01-02' AS Date), N'25', N'9475669184', N'deb@gmail.com', N'Nothing', N'B+', N'Single', NULL, N'Khandaghosh', N'Nothing', N'5', N'55', N'122', N'1', N'1', N'1', N'test', CAST(N'2020-11-02' AS Date), N'656', N'No', N'no', N'rintu das', CAST(500.00 AS Decimal(18, 2)), N'Cash', N'No', N'No', N'test')
INSERT [dbo].[Master_OPDPatient_tbl] ([PatientId], [Name], [GuardianName], [Gender], [DOB], [Age], [Phone], [Email], [Remarks], [BloodGroup], [MaritalStatus], [PatientPhoto], [Address], [AnyKnownAllergies], [Height], [Weight], [Bp], [Pulse], [Temperature], [Respiration], [SymptomsTitle], [AppointmentDate], [PCase], [Casualty], [Reference], [ConsultantDoctor], [AppliedCharge], [PaymentMode], [OldPatient], [LiveConsultation], [Note]) VALUES (2, N'Debsankar', N'Amiya krishna das', N'Male', CAST(N'2020-08-01' AS Date), N'25', N'9876776777', N'deb1@gmail.com', N'no', N'B+', N'Single', N'~/DataImages/papiya-img.jpg', N'Khandaghosh', N'no', N'5', N'55', N'122', NULL, N'1', N'1', N'test', CAST(N'2020-11-02' AS Date), N'656', N'No', NULL, N'rintu das', CAST(500.00 AS Decimal(18, 2)), N'Cash', N'No', N'No', N'no')
SET IDENTITY_INSERT [dbo].[Master_OPDPatient_tbl] OFF
SET IDENTITY_INSERT [dbo].[Master_State_tbl] ON 

INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (1, 100, N'Andaman and Nicobar Islands', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (2, 100, N'Andhra Pradesh', 1)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (3, 100, N'Arunachal Pradesh', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (4, 100, N'Assam', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (5, 100, N'Bihar', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (6, 100, N'Chandigarh', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (7, 100, N'Chhattisgarh', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (8, 100, N'Dadra and Nagar Haveli', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (9, 100, N'Daman and Diu', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (10, 100, N'Delhi', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (11, 100, N'Goa', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (12, 100, N'Gujarat', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (13, 100, N'Haryana', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (14, 100, N'Himachal Pradesh', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (15, 100, N'Jammu and Kashmir', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (16, 100, N'Jharkhand', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (17, 100, N'Karnataka', 1)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (18, 100, N'Kenmore', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (19, 100, N'Kerala', 1)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (20, 100, N'Lakshadweep', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (21, 100, N'Madhya Pradesh', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (22, 100, N'Maharashtra', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (23, 100, N'Manipur', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (24, 100, N'Meghalaya', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (25, 100, N'Mizoram', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (26, 100, N'Nagaland', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (27, 100, N'Narora', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (28, 100, N'Natwar', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (29, 100, N'Odisha', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (30, 100, N'Pondicherry', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (31, 100, N'Punjab', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (32, 100, N'Rajasthan', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (33, 100, N'Sikkim', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (34, 100, N'Tamil Nadu', 1)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (35, 100, N'Telangana', 1)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (36, 100, N'Tripura', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (37, 100, N'Uttar Pradesh', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (38, 100, N'Uttarakhand', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (39, 100, N'Vaishali', 0)
INSERT [dbo].[Master_State_tbl] ([StateId], [CountryId], [StateName], [IsActive]) VALUES (40, 100, N'West Bengal', 0)
SET IDENTITY_INSERT [dbo].[Master_State_tbl] OFF
SET IDENTITY_INSERT [dbo].[PathologyCategory_tbl] ON 

INSERT [dbo].[PathologyCategory_tbl] ([CategoryId], [CategoryName], [HospitalId], [IsActive]) VALUES (1, N'test', 18, 1)
INSERT [dbo].[PathologyCategory_tbl] ([CategoryId], [CategoryName], [HospitalId], [IsActive]) VALUES (2, N'test1', 18, 1)
INSERT [dbo].[PathologyCategory_tbl] ([CategoryId], [CategoryName], [HospitalId], [IsActive]) VALUES (5, N'test12', 18, 1)
INSERT [dbo].[PathologyCategory_tbl] ([CategoryId], [CategoryName], [HospitalId], [IsActive]) VALUES (6, N'test121', 18, 1)
SET IDENTITY_INSERT [dbo].[PathologyCategory_tbl] OFF
SET IDENTITY_INSERT [dbo].[PathologySubcategory_tbl] ON 

INSERT [dbo].[PathologySubcategory_tbl] ([SubCategoryId], [SubCategoryName], [CategoryId], [HospitalId], [IsActive]) VALUES (1, N'tttt', 1, 18, 1)
SET IDENTITY_INSERT [dbo].[PathologySubcategory_tbl] OFF
SET IDENTITY_INSERT [dbo].[PathologyTest_tbl] ON 

INSERT [dbo].[PathologyTest_tbl] ([PathologyId], [TestName], [ShortName], [TestType], [CategoryId], [SubCategoryId], [Method], [ReportDays], [Charge], [AddedBy], [IsActive]) VALUES (1, N'tttt', N'ttt', N'ttt', 1, 1, N'aa', N'aa', CAST(1.00 AS Decimal(18, 2)), 18, 1)
SET IDENTITY_INSERT [dbo].[PathologyTest_tbl] OFF
SET IDENTITY_INSERT [dbo].[Role_Master_tbl] ON 

INSERT [dbo].[Role_Master_tbl] ([RoleId], [Services], [AddedOn]) VALUES (1, N'Hospital Management', CAST(N'2020-10-06' AS Date))
INSERT [dbo].[Role_Master_tbl] ([RoleId], [Services], [AddedOn]) VALUES (2, N'Pharmacist Management', CAST(N'2020-10-06' AS Date))
SET IDENTITY_INSERT [dbo].[Role_Master_tbl] OFF
SET IDENTITY_INSERT [dbo].[UserType_tbl] ON 

INSERT [dbo].[UserType_tbl] ([UserTypeId], [UserType], [HospitalId], [IsActive]) VALUES (1, N'CEO', 31, 1)
INSERT [dbo].[UserType_tbl] ([UserTypeId], [UserType], [HospitalId], [IsActive]) VALUES (2, N'Doctor', 31, 1)
SET IDENTITY_INSERT [dbo].[UserType_tbl] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AdminLogin_tbl]    Script Date: 12-11-2020 11:59:21 ******/
ALTER TABLE [dbo].[AdminLogin_tbl] ADD  CONSTRAINT [IX_AdminLogin_tbl] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_AdminLogin_tbl_1]    Script Date: 12-11-2020 11:59:21 ******/
ALTER TABLE [dbo].[AdminLogin_tbl] ADD  CONSTRAINT [IX_AdminLogin_tbl_1] UNIQUE NONCLUSTERED 
(
	[Phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Executive_Profile_tbl]    Script Date: 12-11-2020 11:59:21 ******/
ALTER TABLE [dbo].[Executive_Profile_tbl] ADD  CONSTRAINT [IX_Executive_Profile_tbl] UNIQUE NONCLUSTERED 
(
	[ExecutiveEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Fetch_API_Executive]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Debsankar Das>
-- Create date: <Create Date,,05-10-2020>
-- Description:	<Description,,Fetch Executive>
-- =============================================
CREATE PROCEDURE [dbo].[Fetch_API_Executive]
	-- Add the parameters for the stored procedure here
		@Condition1 varchar(200)=null,
		@Condition2 varchar(200)=null,
		@Condition3 varchar(200)=null,
		@Condition4 varchar(200)=null,
		@Condition5 varchar(200)=null,
		@Condition6 varchar(200)=null,
		@Condition7 varchar(200)=null,
		@Condition8 varchar(200)=null,
		@Condition9 varchar(200)=null,
		@OnTable varchar(100)=null
AS

if(@OnTable='ExecutiveLogin')
	begin
		Select *
		from [dbo].[Executive_Profile_tbl]
		where ExecutiveEmail=@Condition1 and Password =@Condition2
	end
else if(@OnTable='ForgetPassword')
	begin
		select Password from [dbo].[Executive_Profile_tbl] where ExecutiveId=@Condition1
	end
else if(@OnTable='ShowProfile')
	begin
		--Select * from [dbo].[Executive_Profile_tbl] where ExecutiveId=@Condition1
		select e.ExecutiveId,e.ExecutiveName,e.ExecutiveEmail,e.Password,e.ExecutivePhone,e.ExecutiveAddress,
		e.ExecutiveAge,e.IsActive,e.AdminId,c.CountryName,s.StateName,city.CityName,
		e.CountryId,e.StateId,e.CityId
		from Executive_Profile_tbl e
		left join Master_Country_tbl c on c.CountryId=e.CountryId
	    left join Master_State_tbl s on s.StateId=e.StateId
	    left join Master_City_tbl city on city.CityId=e.CityId
		where ExecutiveId=@Condition1
	end

GO
/****** Object:  StoredProcedure [dbo].[FetchAdminLogin_sp]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Create date: <Create Date,, 22-09-2020>
-- Description:	<Description,, Procedure to Fetch login detail>
-- =============================================
CREATE PROCEDURE [dbo].[FetchAdminLogin_sp]
		@Condition1 varchar(200)=null,
		@Condition2 varchar(200)=null,
		@Condition3 varchar(200)=null,
		@Condition4 varchar(200)=null,
		@Condition5 varchar(200)=null,
		@Condition6 varchar(200)=null,
		@Condition7 varchar(200)=null,
		@Condition8 varchar(200)=null,
		@Condition9 varchar(200)=null,
		@OnTable varchar(100)=null
AS

if(@OnTable='FetchAdminLoginUser')
begin
	Select *
	from [dbo].[AdminLogin_tbl]
	where Email=@Condition1 and Password =@Condition2 and IsActive=1 
end

else if(@OnTable='FetchAdmin')
begin
	-----Table 0-----
	--select * from [dbo].[AdminLogin_tbl] where HospitalId=@Condition1 and IsActive=1
		select a.HospitalId,a.HospitalName,a.HospitalWebsiteUrl,a.Phone,a.Email,a.Address,a.Password,c.CountryName,s.StateName,city.CityName,
		a.CountryId,a.StateId,a.CityId
		from AdminLogin_tbl a
		left join Master_Country_tbl c on c.CountryId=a.CountryId
	    left join Master_State_tbl s on s.StateId=a.StateId
	    left join Master_City_tbl city on city.CityId=a.CityId where a.HospitalId=@Condition1
	-----Table 1-----
	select CountryName,CountryId from [dbo].[Master_Country_tbl] where IsActive=1
end
GO
/****** Object:  StoredProcedure [dbo].[FetchEmployee_sp]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Create date: <Create Date,, 22-09-2020>
-- Description:	<Description,, Procedure to Fetch login detail>
-- =============================================
CREATE PROCEDURE [dbo].[FetchEmployee_sp]
		@Condition1 varchar(200)=null,
		@Condition2 varchar(200)=null,
		@Condition3 varchar(200)=null,
		@Condition4 varchar(200)=null,
		@Condition5 varchar(200)=null,
		@Condition6 varchar(200)=null,
		@Condition7 varchar(200)=null,
		@Condition8 varchar(200)=null,
		@Condition9 varchar(200)=null,
		@OnTable varchar(100)=null
AS

if(@OnTable='FetchEmployee')
begin
-----table 0-----
	Select EmployeeId,FullName,EmailId,Phone,Age,IsActive
	from [dbo].[Employee_basicdetail_tbl]
	where HospitalId=@Condition1

----table 1------
Select * from [dbo].[UserType_tbl] where HospitalId=@Condition1

----table 2------
Select * from [dbo].[Employee_basicdetail_tbl] where EmployeeId=@Condition1

----table 3------
Select * from [dbo].[Employee_Payroll_tbl] where EmployeeId=@Condition1

----table 4------
Select * from [dbo].[Employee_document_tbl] where EmployeeId=@Condition1

----table 5------
select u.UserType, u.UserTypeId,e.UserTypeId from UserType_tbl u
left join Employee_basicdetail_tbl e on u.UserTypeId=e.UserTypeId
--Select * from [dbo].[UserType_tbl] where HospitalId=@Condition2
		
end

else if (@Ontable='DeleteEmployee')
begin
    delete from Employee_basicdetail_tbl where EmployeeId=@Condition1
	delete from Employee_Payroll_tbl where EmployeeId=@Condition1
	delete from Employee_document_tbl where EmployeeId=@Condition1
end

else if(@OnTable='ChangeEmployeeStatus')
begin
	update [dbo].[Employee_basicdetail_tbl] set IsActive=@Condition1 where EmployeeId=@Condition2
end

else if(@OnTable='FetchEmployeeLogin')
begin
	Select *
	from [dbo].[Employee_basicdetail_tbl]
	where EmailId=@Condition1 and Password =@Condition2 and IsActive=1 
end

GO
/****** Object:  StoredProcedure [dbo].[FetchHospital_sp]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Create date: <Create Date,, 01 May
-- =============================================
CREATE PROCEDURE [dbo].[FetchHospital_sp]
		@Condition1 varchar(200)=null,
		@Condition2 varchar(200)=null,
		@Condition3 varchar(200)=null,
		@Condition4 varchar(200)=null,
		@Condition5 varchar(200)=null,
		@Condition6 varchar(200)=null,
		@Condition7 varchar(200)=null,
		@Condition8 varchar(200)=null,
		@Condition9 varchar(200)=null,
		@OnTable varchar(100)=null
AS

if(@OnTable='FetchHospitalList')
begin
--------Table 0---------------
	--Select * from [dbo].[AdminLogin_tbl]
	select a.HospitalId,a.HospitalName,a.HospitalWebsiteUrl,a.Email,a.Password,a.Phone,a.Address,a.IsActive,c.CountryName,s.StateName,city.CityName,
		a.CountryId,a.StateId,a.CityId
		from AdminLogin_tbl a
		left join Master_Country_tbl c on c.CountryId=a.CountryId
	    left join Master_State_tbl s on s.StateId=a.StateId
	    left join Master_City_tbl city on city.CityId=a.CityId
-------table 1-----------
--select * from [dbo].[AdminLogin_tbl] where HospitalId=@Condition1
--select * from Master_View where HospitalId=@Condition1
		select a.HospitalId,a.HospitalName,a.HospitalWebsiteUrl,a.Email,a.Password,a.Phone,a.Address,c.CountryName,s.StateName,city.CityName,
		a.CountryId,a.StateId,a.CityId,a.ImgUrl
		from AdminLogin_tbl a
		left join Master_Country_tbl c on c.CountryId=a.CountryId
	    left join Master_State_tbl s on s.StateId=a.StateId
	    left join Master_City_tbl city on city.CityId=a.CityId where a.HospitalId=@Condition1
-------table 2-----------
select CountryName,CountryId from [dbo].[Master_Country_tbl] where IsActive=1
-------table 3-----------
--select * from [dbo].[Hospital_Services_tbl] where HospitalId=@Condition1
select h.ServiceId,h.HospitalId,h.RoleId,r.Services from Hospital_Services_tbl h
left join Role_Master_tbl r on h.RoleId=r.RoleId
where h.HospitalId=@Condition1
-------table 4----------
select * from [dbo].[Role_Master_tbl]
end

--else if(@OnTable='AddHospital')
--begin
---------table 0-----------
--select * from [dbo].[AdminLogin_tbl] where HospitalId=@Condition1
--end

else if (@Ontable='ChangeHospitalStatus')
begin
    update [dbo].[AdminLogin_tbl] set IsActive=@Condition1 where HospitalId=@Condition2
end

else if (@Ontable='DeleteHospital')
begin
    delete from AdminLogin_tbl where HospitalId=@Condition1
end


GO
/****** Object:  StoredProcedure [dbo].[FetchIpdPatient_sp]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Create date: <Create Date,, 22-09-2020>
-- Description:	<Description,, Procedure to Fetch Ipd Patient>
-- =============================================
CREATE PROCEDURE [dbo].[FetchIpdPatient_sp]
		@Condition1 varchar(200)=null,
		@Condition2 varchar(200)=null,
		@Condition3 varchar(200)=null,
		@Condition4 varchar(200)=null,
		@Condition5 varchar(200)=null,
		@Condition6 varchar(200)=null,
		@Condition7 varchar(200)=null,
		@Condition8 varchar(200)=null,
		@Condition9 varchar(200)=null,
		@OnTable varchar(100)=null
AS

if(@OnTable='FetchIpdPatient')
begin
-----table 0-----
	Select IPDNo,Name,GuardianName,Gender,Phone,ConsultantDoctor
	from [dbo].[Master_IPDPatient_tbl]

----table 1------
	Select FullName,EmployeeId
	from [dbo].[Employee_basicdetail_tbl]
	where UserTypeId=2 and IsActive=1 

end

GO
/****** Object:  StoredProcedure [dbo].[FetchMarketingExecutive_sp]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Create date: <Create Date,, 22-09-2020>
-- Description:	<Description,, Procedure to Fetch login detail>
-- =============================================
CREATE PROCEDURE [dbo].[FetchMarketingExecutive_sp]
		@Condition1 varchar(200)=null,
		@Condition2 varchar(200)=null,
		@Condition3 varchar(200)=null,
		@Condition4 varchar(200)=null,
		@Condition5 varchar(200)=null,
		@Condition6 varchar(200)=null,
		@Condition7 varchar(200)=null,
		@Condition8 varchar(200)=null,
		@Condition9 varchar(200)=null,
		@OnTable varchar(100)=null
AS

if(@OnTable='FetchExecutive')
begin
-----table 0-----
	Select *
	from [dbo].[Executive_Profile_tbl]
	where AdminId=@Condition2
-----table 1-----
	--Select *
	--from [dbo].[Executive_Profile_tbl]
	--where ExecutiveId=@Condition1 and IsActive=1 
	select e.ExecutiveId,e.ExecutiveName,e.ExecutiveEmail,e.ExecutivePhone,e.ExecutiveAge,e.ExecutiveAddress,e.Password,c.CountryName,s.StateName,city.CityName,
		e.CountryId,e.StateId,e.CityId
		from Executive_Profile_tbl e
		left join Master_Country_tbl c on c.CountryId=e.CountryId
	    left join Master_State_tbl s on s.StateId=e.StateId
	    left join Master_City_tbl city on city.CityId=e.CityId where e.ExecutiveId=@Condition1
-----table 2-----
	select CountryName,CountryId from [dbo].[Master_Country_tbl] where IsActive=1
end

else if (@Ontable='ChangeExecutiveStatus')
begin
    update [dbo].[Executive_Profile_tbl] set IsActive=@Condition1 where ExecutiveId=@Condition2
end

else if (@Ontable='DeleteExecutive')
begin
    delete from Executive_Profile_tbl where ExecutiveId=@Condition1
end

else if(@OnTable='FetchCity')
begin
	select CityId,CityName from [dbo].[Master_City_tbl] where StateId=@Condition1
end

else if(@OnTable='FetchStateList')
begin
	select StateName,StateId,IsActive from [dbo].[Master_State_tbl] where CountryId=@Condition1 and IsActive=1
end
GO
/****** Object:  StoredProcedure [dbo].[FetchMasterAdminLogin_sp]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Create date: <Create Date,, 22-09-2020>
-- Description:	<Description,, Procedure to Fetch login detail>
-- =============================================
CREATE PROCEDURE [dbo].[FetchMasterAdminLogin_sp]
		@Condition1 varchar(200)=null,
		@Condition2 varchar(200)=null,
		@Condition3 varchar(200)=null,
		@Condition4 varchar(200)=null,
		@Condition5 varchar(200)=null,
		@Condition6 varchar(200)=null,
		@Condition7 varchar(200)=null,
		@Condition8 varchar(200)=null,
		@Condition9 varchar(200)=null,
		@OnTable varchar(100)=null
AS

if(@OnTable='FetchMasterAdminLoginUser')
begin
	Select *
	from [dbo].[Master_AdminLogin_tbl]
	where EmailId=@Condition1 and Password =@Condition2 and IsActive=1 
end

else if(@OnTable='FetchMasterAdmin')
begin
	-----Table 0-----
	select * from [dbo].[Master_AdminLogin_tbl]
	-----Table 1-----
	--select * from [dbo].[Master_AdminLogin_tbl] where UserId=@Condition1
end

GO
/****** Object:  StoredProcedure [dbo].[FetchMasterSetting_sp]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Debsankar Das>
-- Create date: <Create Date,,24-09-2020>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[FetchMasterSetting_sp] 
	-- Add the parameters for the stored procedure here
		@Condition1 varchar(200)=null,
		@Condition2 varchar(200)=null,
		@Condition3 varchar(200)=null,
		@Condition4 varchar(200)=null,
		@Condition5 varchar(200)=null,
		@Condition6 varchar(200)=null,
		@Condition7 varchar(200)=null,
		@Condition8 varchar(200)=null,
		@Condition9 varchar(200)=null,
		@OnTable varchar(100)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if(@OnTable='FetchCountryList')
		begin
			select * from [dbo].[Master_Country_tbl]
		end
	else if(@OnTable='FetchStateList')
		begin
			-----table 0-----
			select CountryName,CountryId from [dbo].[Master_Country_tbl] where IsActive=1
			-----table 1-----
			select StateName,StateId,IsActive from [dbo].[Master_State_tbl] where CountryId=@Condition1 and IsActive=1
			-----table 2-----
			select c.CountryName,s.StateName,city.CityName,city.CityId,city.IsActive from Master_Country_tbl c
			inner join Master_State_tbl s on c.CountryId=s.CountryId
			inner join Master_City_tbl city on s.StateId=city.StateId
			-----table 3-----
			select c.CountryName,s.StateName,city.CityName,city.CityId,city.IsActive,c.CountryId,s.StateId from Master_Country_tbl c
			inner join Master_State_tbl s on c.CountryId=s.CountryId
			inner join Master_City_tbl city on s.StateId=city.StateId where city.CityId=@Condition1
		end
	else if(@OnTable='DeleteCity')
		begin
			delete from Master_City_tbl where CityId=@Condition1
		end
	else if(@OnTable='FetchCity')
		begin
			select CityId,CityName from [dbo].[Master_City_tbl] where StateId=@Condition1
		end
	else if(@OnTable='ChangeCityStatus')
		begin
			update [dbo].[Master_City_tbl] set IsActive=@Condition1 where CityId=@Condition2
		end
END

GO
/****** Object:  StoredProcedure [dbo].[FetchOtpPatient_sp]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Create date: <Create Date,, 22-09-2020>
-- Description:	<Description,, Procedure to Fetch login detail>
-- =============================================
CREATE PROCEDURE [dbo].[FetchOtpPatient_sp]
		@Condition1 varchar(200)=null,
		@Condition2 varchar(200)=null,
		@Condition3 varchar(200)=null,
		@Condition4 varchar(200)=null,
		@Condition5 varchar(200)=null,
		@Condition6 varchar(200)=null,
		@Condition7 varchar(200)=null,
		@Condition8 varchar(200)=null,
		@Condition9 varchar(200)=null,
		@OnTable varchar(100)=null
AS

if(@OnTable='FetchOtpPatient')
begin
-----table 0-----
	Select PatientId,Name,GuardianName,Gender,Phone,ConsultantDoctor
	from [dbo].[Master_OPDPatient_tbl]

----table 1------
	Select FullName,EmployeeId
	from [dbo].[Employee_basicdetail_tbl]
	where UserTypeId=2 and IsActive=1 

end
GO
/****** Object:  StoredProcedure [dbo].[FetchPathologyCategory_sp]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:      <Debsankar Das>
-- =============================================
CREATE PROCEDURE [dbo].[FetchPathologyCategory_sp]
		@Condition1 varchar(200)=null,
		@Condition2 varchar(200)=null,
		@Condition3 varchar(200)=null,
		@Condition4 varchar(200)=null,
		@Condition5 varchar(200)=null,
		@Condition6 varchar(200)=null,
		@Condition7 varchar(200)=null,
		@Condition8 varchar(200)=null,
		@Condition9 varchar(200)=null,
		@OnTable varchar(100)=null
AS

if(@OnTable='FetchPathologyCategory')
begin
-----table 0-----
	Select CategoryId,CategoryName,HospitalId,IsActive
	from [dbo].[PathologyCategory_tbl]

end

else if(@OnTable='DeleteCategory')
begin
	delete from PathologyCategory_tbl where CategoryId=@Condition1
end

else if(@OnTable='ChangePathologyStatus')
begin
	update [dbo].[PathologyCategory_tbl] set IsActive=@Condition1 where CategoryId=@Condition2
end

else if(@OnTable='FetchCategory')
begin
	select CategoryId,CategoryName from PathologyCategory_tbl where CategoryId=@Condition1
end
GO
/****** Object:  StoredProcedure [dbo].[FetchPathologySubCategory_sp]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:      <Debsankar Das>
-- =============================================
CREATE PROCEDURE [dbo].[FetchPathologySubCategory_sp]
		@Condition1 varchar(200)=null,
		@Condition2 varchar(200)=null,
		@Condition3 varchar(200)=null,
		@Condition4 varchar(200)=null,
		@Condition5 varchar(200)=null,
		@Condition6 varchar(200)=null,
		@Condition7 varchar(200)=null,
		@Condition8 varchar(200)=null,
		@Condition9 varchar(200)=null,
		@OnTable varchar(100)=null
AS

if(@OnTable='FetchPathologySubCategory')
begin
-----table 0-----
	Select c.CategoryId,c.CategoryName,s.SubCategoryId,s.SubCategoryName,s.HospitalId,s.IsActive
	from PathologyCategory_tbl c
	inner join PathologySubcategory_tbl s on c.CategoryId=s.CategoryId
-----table 1-----
	select CategoryId,CategoryName from [dbo].[Pathologycategory_tbl] where IsActive=1

end

else if(@OnTable='DeleteSubCategory')
begin
	delete from PathologySubcategory_tbl where SubCategoryId=@Condition1
end

else if(@OnTable='ChangePathologyStatus')
begin
	update [dbo].[PathologySubcategory_tbl] set IsActive=@Condition1 where SubCategoryId=@Condition2
end

GO
/****** Object:  StoredProcedure [dbo].[FetchPathologyTest_sp]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:      <Debsankar Das>
-- =============================================
CREATE PROCEDURE [dbo].[FetchPathologyTest_sp]
		@Condition1 varchar(200)=null,
		@Condition2 varchar(200)=null,
		@Condition3 varchar(200)=null,
		@Condition4 varchar(200)=null,
		@Condition5 varchar(200)=null,
		@Condition6 varchar(200)=null,
		@Condition7 varchar(200)=null,
		@Condition8 varchar(200)=null,
		@Condition9 varchar(200)=null,
		@OnTable varchar(100)=null
AS

if(@OnTable='FetchPathologyTest')
begin
-----table 0-----
	Select p.PathologyId,p.TestName,p.ShortName,p.TestType,p.CategoryId,p.SubCategoryId,p.Method,p.ReportDays,p.Charge,c.CategoryName,s.SubCategoryName,p.IsActive
	from PathologyTest_tbl p
	inner join PathologyCategory_tbl c on p.CategoryId=c.CategoryId
	inner join PathologySubcategory_tbl s on p.SubCategoryId=s.SubCategoryId
-----table 1-----
	select CategoryId,CategoryName from [dbo].[Pathologycategory_tbl] where IsActive=1

end

else if(@OnTable='DeletePathology')
begin
	delete from PathologyTest_tbl where PathologyId=@Condition1
end

else if(@OnTable='FetchSubCategory')
begin
	select SubCategoryId,SubCategoryName from PathologySubcategory_tbl where SubCategoryId=@Condition1
end

else if(@OnTable='ChangePathologyStatus')
begin
	update [dbo].[PathologyTest_tbl] set IsActive=@Condition1 where PathologyId=@Condition2
end


GO
/****** Object:  StoredProcedure [dbo].[FetchRoleMaster]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Debsankar Das>
-- Create date: <Create Date,,05-10-2020>
-- Description:	<Description,,Fetch Executive>
-- =============================================
CREATE PROCEDURE [dbo].[FetchRoleMaster]
	-- Add the parameters for the stored procedure here
		@Condition1 varchar(200)=null,
		@Condition2 varchar(200)=null,
		@Condition3 varchar(200)=null,
		@Condition4 varchar(200)=null,
		@Condition5 varchar(200)=null,
		@Condition6 varchar(200)=null,
		@Condition7 varchar(200)=null,
		@Condition8 varchar(200)=null,
		@Condition9 varchar(200)=null,
		@OnTable varchar(100)=null
AS

if(@OnTable='RoleMaster')
	begin
		Select *
		from [dbo].[Role_Master_tbl]
	end

GO
/****** Object:  StoredProcedure [dbo].[FetchUserList_sp]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Debsankar Das>
-- Create date: <Create Date,,19-10-2020>
-- Description:	<Description,,Fetch Executive>
-- =============================================
CREATE PROCEDURE [dbo].[FetchUserList_sp]
	-- Add the parameters for the stored procedure here
		@Condition1 varchar(200)=null,
		@Condition2 varchar(200)=null,
		@Condition3 varchar(200)=null,
		@Condition4 varchar(200)=null,
		@Condition5 varchar(200)=null,
		@Condition6 varchar(200)=null,
		@Condition7 varchar(200)=null,
		@Condition8 varchar(200)=null,
		@Condition9 varchar(200)=null,
		@OnTable varchar(100)=null
AS

if(@OnTable='UserList')
	begin
		Select *
		from [dbo].[UserType_tbl] where HospitalId=@Condition1
	end


GO
/****** Object:  StoredProcedure [dbo].[InsertCity_Sp]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Debsankar Das>
-- Create date: <Create Date,,25-09-2020>
-- Description:	<Description,,Insert City>
-- =============================================
CREATE PROCEDURE [dbo].[InsertCity_Sp]
	-- Add the parameters for the stored procedure here
	@CityId bigint=0,
	@CountryId bigint=0,
	@StateId bigint=0,
	@CityName varchar(30)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if exists(select * from [dbo].[Master_City_tbl] where CityId=@CityId)
		begin
			update [dbo].[Master_City_tbl]
			set
			CountryId=@CountryId,
			StateId=@StateId,
			CityName=@CityName
			where CityId=@CityId
		end
	else
		begin
			INSERT INTO Master_City_tbl(CountryId,StateId,CityName) values (@CountryId,@StateId,@CityName)
		end
END

GO
/****** Object:  StoredProcedure [dbo].[InsertEmployee_Sp]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Debsankar Das>
-- Create date: <Create Date,,21-10-2020>
-- Description:	<Description,,Employee>
-- =============================================
CREATE PROCEDURE [dbo].[InsertEmployee_Sp]
	-- Add the parameters for the stored procedure here
	@EmployeeId bigint=0,
	@FullName varchar(100)=null,
	@EmailId varchar(50)=null,
	@Password nvarchar(50)=null,
	@Phone varchar(20)=null,
	@Age varchar(50)=null,
	@UserTypeId bigint=0,
	@HospitalId bigint=0,
	@PayrollId bigint=0,
	@Salary decimal(18,2),
	@Pf decimal(18,2),
	@MedicalIncentives decimal(18,2),
	@ServiceTax decimal(18,2),
	@Hra decimal(18,2),
	@DocumentId bigint=0,
	@VoterId varchar(MAX)=null,
	@PanId varchar(MAX)=null,
	@AadharId varchar(MAX)=null,
	@ProfilePic varchar(MAX)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--if exists(select * from [dbo].[Master_City_tbl] where CityId=@CityId)
	--	begin
	--		update [dbo].[Master_City_tbl]
	--		set
	--		CountryId=@CountryId,
	--		StateId=@StateId,
	--		CityName=@CityName
	--		where CityId=@CityId
	--	end
	--else
	--	begin
	--		INSERT INTO Master_City_tbl(CountryId,StateId,CityName) values (@CountryId,@StateId,@CityName)
	--	end

	--declare @no int
	--set @no = LPAD(FLOOR(RAND() * 999999.99), 6, '0');

	INSERT INTO Employee_basicdetail_tbl(FullName,EmailId,Password,Phone,Age,UserTypeId,HospitalId) values (@FullName,@EmailId,@Password,@Phone,@Age,@UserTypeId,@HospitalId)

	--declare @empid bigint
	--set @empid=(select MAX(EmployeeId) from Employee_basicdetail_tbl)

	declare @empid bigint
	set @empid=(SELECT TOP 1 EmployeeId FROM Employee_basicdetail_tbl  
				ORDER BY EmployeeId DESC)

	INSERT INTO Employee_Payroll_tbl(EmployeeId,Salary,Pf,MedicalIncentives,ServiceTax,Hra,HospitalId) values (@empid,@Salary,@Pf,@MedicalIncentives,@ServiceTax,@Hra,@HospitalId)
	
	INSERT INTO Employee_document_tbl(EmployeeId,VoterId,PanId,AadharId,ProfilePic) values (@empid,@VoterId,@PanId,@AadharId,@ProfilePic)

END


GO
/****** Object:  StoredProcedure [dbo].[InsertEmployeePayroll_Sp]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Debsankar Das>
-- Create date: <Create Date,,21-10-2020>
-- Description:	<Description,,Employee>
-- =============================================
CREATE PROCEDURE [dbo].[InsertEmployeePayroll_Sp]
	-- Add the parameters for the stored procedure here
	@PayrollId bigint=0,
	@Salary decimal(18,2),
	@Pf decimal(18,2),
	@MedicalIncentives decimal(18,2),
	@ServiceTax decimal(18,2),
	@Hra decimal(18,2),
	@EmployeeId bigint=0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--if exists(select * from [dbo].[Master_City_tbl] where CityId=@CityId)
	--	begin
	--		update [dbo].[Master_City_tbl]
	--		set
	--		CountryId=@CountryId,
	--		StateId=@StateId,
	--		CityName=@CityName
	--		where CityId=@CityId
	--	end
	--else
	--	begin
	--		INSERT INTO Master_City_tbl(CountryId,StateId,CityName) values (@CountryId,@StateId,@CityName)
	--	end

	--declare @no int
	--set @no = LPAD(FLOOR(RAND() * 999999.99), 6, '0');

	declare @empid bigint
	set @empid=(SELECT TOP 1 EmployeeId FROM Employee_basicdetail_tbl  
				ORDER BY EmployeeId DESC)

	INSERT INTO Employee_Payroll_tbl(EmployeeId,Salary,Pf,MedicalIncentives,ServiceTax,Hra) values (@empid,@Salary,@Pf,@MedicalIncentives,@ServiceTax,@Hra)

END



GO
/****** Object:  StoredProcedure [dbo].[InsertExecutive_Sp]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Debsankar Das>
-- Create date: <Create Date,,26-09-2020>
-- Description:	<Description,,Executive Insert>
-- =============================================
CREATE PROCEDURE [dbo].[InsertExecutive_Sp]
	-- Add the parameters for the stored procedure here
@ExecutiveId bigint=0,
@ExecutiveName varchar(100)=null,
@ExecutiveEmail varchar(50)=null,
@ExecutivePhone varchar(10)=null,
@ExecutiveAge varchar(10)=null,
@ExecutiveAddress varchar(200)=null,
@Password nvarchar(50)=null,
@CountryId bigint,
@StateId bigint,
@CityId bigint,
@AdminId bigint
AS
BEGIN
    -- Insert statements for procedure here
	if exists(select * from [dbo].[Executive_Profile_tbl] where ExecutiveId=@ExecutiveId)
		begin
			update [dbo].[Executive_Profile_tbl] 
			set 
			ExecutiveName =@ExecutiveName,
			ExecutiveEmail=@ExecutiveEmail,
			ExecutivePhone=@ExecutivePhone,
			ExecutiveAge=@ExecutiveAge,
			ExecutiveAddress=@ExecutiveAddress,
			Password=@Password,
			CountryId=@CountryId,
			StateId=@StateId,
			CityId=@CityId,
			AdminId=@AdminId
			where ExecutiveId =@ExecutiveId
		end
	else
		begin
			INSERT INTO Executive_Profile_tbl(ExecutiveName,ExecutiveEmail, ExecutivePhone, ExecutiveAge, ExecutiveAddress, AdminId, Password, CountryId, StateId, CityId)
			VALUES(@ExecutiveName, @ExecutiveEmail, @ExecutivePhone, @ExecutiveAge, @ExecutiveAddress, @AdminId, @Password, @CountryId, @StateId, @CityId)
		end
END

GO
/****** Object:  StoredProcedure [dbo].[InsertHospital_Sp]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Debsankar Das heartNsoul>
-- =============================================

CREATE PROCEDURE [dbo].[InsertHospital_Sp] --0,'Bishnupur','google.com','dsp1@gmail.com','1234','1234567890','dgp' 
(
@HospitalId bigint=0, 
@HospitalName varchar(100)=null, 
@HospitalWebsiteUrl varchar(100)=null,
@Email varchar(50)=null, 
@Password nvarchar(50)=null, 
@Phone varchar(20)=null, 
@Address varchar(200)=null,
@CountryId bigint,
@StateId bigint,
@CityId bigint,
@ImgUrl VARCHAR(max)=NULL
)
AS
BEGIN
if exists(select * from [dbo].[AdminLogin_tbl] where HospitalId = @HospitalId)
 begin
 --update [dbo].[AdminLogin_tbl] 
 --set 
 --HospitalName =@HospitalName,
 --HospitalWebsiteUrl=@HospitalWebsiteUrl,
 --Email=@Email,
 --Password=@Password,
 --Phone=@Phone,
 --Address=@Address,
 --CountryId=@CountryId,
 --StateId=@StateId,
 --CityId=@CityId
 --where HospitalId =@HospitalId
 if(@ImgUrl != '' or @ImgUrl <>null)
 begin
     update [dbo].[AdminLogin_tbl]  set 
     HospitalName=@HospitalName,
     HospitalWebsiteUrl=@HospitalWebsiteUrl,
     Email=@Email,
	 Password=@Password,
	 Phone=@Phone,
	 Address=@Address,
	 CountryId=@CountryId,
	 StateId=@StateId,
	 CityId=@CityId,
     ImgUrl=@ImgUrl
     where HospitalId = @HospitalId
 end
 else
 begin
     update [dbo].[AdminLogin_tbl]  set 
     HospitalName=@HospitalName,
     HospitalWebsiteUrl=@HospitalWebsiteUrl,
     Email=@Email,
	 Password=@Password,
	 Phone=@Phone,
	 Address=@Address,
	 CountryId=@CountryId,
	 StateId=@StateId,
	 CityId=@CityId
     where HospitalId = @HospitalId
 end
 end
 else
 begin
 INSERT INTO AdminLogin_tbl(HospitalName,HospitalWebsiteUrl, Email, Password, Phone, Address, CountryId, StateId, CityId, ImgUrl)
 VALUES(@HospitalName, @HospitalWebsiteUrl, @Email, @Password, @Phone, @Address, @CountryId, @StateId, @CityId, @ImgUrl)	
 end	
END

GO
/****** Object:  StoredProcedure [dbo].[InsertHospitalServices_Sp]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Debsankar Das heartNsoul>
-- =============================================

CREATE PROCEDURE [dbo].[InsertHospitalServices_Sp] --0,'Bishnupur','google.com','dsp1@gmail.com','1234','1234567890','dgp' 
(
@ServiceId bigint=0, 
@HospitalId bigint=0, 
@RoleId varchar(100)=null
)
AS
BEGIN
if exists(select * from [dbo].[Hospital_Services_tbl] where HospitalId = @HospitalId)
 begin
 update [dbo].[Hospital_Services_tbl] 
 set 
 --HospitalId =@HospitalId,
 RoleId=@RoleId
 where HospitalId = @HospitalId
 end
 else
 begin
 declare @hsopitalid bigint
 set @hsopitalid=(select top 1 HospitalId from [dbo].[AdminLogin_tbl] ORDER BY HospitalId DESC)
 INSERT INTO Hospital_Services_tbl(HospitalId,RoleId)
 VALUES(@hsopitalid,@RoleId)	
 end	
END

GO
/****** Object:  StoredProcedure [dbo].[InsertIpdPatient_Sp]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Debsankar Das>
-- Create date: <Create Date,,21-10-2020>
-- Description:	<Description,,Employee>
-- =============================================
CREATE PROCEDURE [dbo].[InsertIpdPatient_Sp]
	-- Add the parameters for the stored procedure here
	@IPDNo varchar(100)=null,
	--@PatientId bigint=0,
	@Name varchar(100)=null,
	@GuardianName varchar(100)=null,
	@Gender varchar(50)=null,
	@DOB date=null,
	@Age varchar(50)=null,
	@Phone varchar(50)=null,
	@Email varchar(50)=null,
	@Remarks varchar(500)=null,
	@BloodGroup varchar(50)=null,
	@MaritalStatus varchar(50)=null,
	@PatientPhoto varchar(MAX)=null,
	@Address varchar(500)=null,
	@AnyKnownAllergies varchar(500)=null,
	@Height varchar(50)=null,
	@Weight varchar(50)=null,
	@Bp varchar(50)=null,
	@Pulse varchar(50)=null,
	@Temperature varchar(50)=null,
	@Respiration varchar(50)=null,
	@SymptomsTitle varchar(100)=null,
	@AppointmentDate date=null,
	@PCase varchar(50)=null,
	@Casualty varchar(50)=null,
	@Reference varchar(100)=null,
	@ConsultantDoctor varchar(100)=null,
	@CreditLimit decimal(18,2),
	@PaymentMode varchar(100)=null,
	@OldPatient varchar(50)=null,
	@LiveConsultation varchar(50)=null,
	@Note varchar(500)=null,
	@BedGroup varchar(100)=null,
	@BedNumber varchar(100)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON

	INSERT INTO Master_IPDPatient_tbl(Name,GuardianName,Gender,DOB,Age,Phone,Email,Remarks,BloodGroup,MaritalStatus,PatientPhoto,Address,AnyKnownAllergies,Height,Weight,Bp,Pulse,Temperature,Respiration,SymptomsTitle,AppointmentDate,PCase,Casualty,Reference,ConsultantDoctor,CreditLimit,PaymentMode,OldPatient,LiveConsultation,Note,BedGroup,BedNumber) 
	values (@Name,@GuardianName,@Gender,@DOB,@Age,@Phone,@Email,@Remarks,@BloodGroup,@MaritalStatus,@PatientPhoto,@Address,@AnyKnownAllergies,@Height,@Weight,@Bp,@Pulse,@Temperature,@Respiration,@SymptomsTitle,@AppointmentDate,@PCase,@Casualty,@Reference,@ConsultantDoctor,@CreditLimit,@PaymentMode,@OldPatient,@LiveConsultation,@Note,@BedGroup,@BedNumber)

END


GO
/****** Object:  StoredProcedure [dbo].[InsertMasterAdmin_Sp]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Debsankar Das>
-- Create date: <Create Date,,01-10-2020>
-- Description:	<Description,,Insert Master Admin>
-- =============================================
CREATE PROCEDURE [dbo].[InsertMasterAdmin_Sp]
	-- Add the parameters for the stored procedure here
	@UserId bigint=0,
	@EmailId varchar(50)=null,
	@Password varchar(50)=null,
	@Address varchar(200)=null,
	@PhonoNo varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if exists(select * from [dbo].[Master_AdminLogin_tbl] where UserId=@UserId)
		begin
			update [dbo].[Master_AdminLogin_tbl]
			set
			EmailId=@EmailId,
			Password=@Password,
			Address=@Address,
			PhonoNo=@PhonoNo
			where UserId=@UserId
		end
	else
		begin
			INSERT INTO Master_AdminLogin_tbl(UserId,EmailId,Password,Address,PhonoNo) values (@UserId,@EmailId,@Password,@Address,@PhonoNo)
		end
END

GO
/****** Object:  StoredProcedure [dbo].[InsertOtpPatient_Sp]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Debsankar Das>
-- Create date: <Create Date,,21-10-2020>
-- Description:	<Description,,Employee>
-- =============================================
CREATE PROCEDURE [dbo].[InsertOtpPatient_Sp]
	-- Add the parameters for the stored procedure here
	@PatientId bigint=0,
	@Name varchar(100)=null,
	@GuardianName varchar(100)=null,
	@Gender varchar(50)=null,
	@DOB date=null,
	@Age varchar(50)=null,
	@Phone varchar(50)=null,
	@Email varchar(50)=null,
	@Remarks varchar(500)=null,
	@BloodGroup varchar(50)=null,
	@MaritalStatus varchar(50)=null,
	@PatientPhoto varchar(MAX)=null,
	@Address varchar(500)=null,
	@AnyKnownAllergies varchar(500)=null,
	@Height varchar(50)=null,
	@Weight varchar(50)=null,
	@Bp varchar(50)=null,
	@Pulse varchar(50)=null,
	@Temperature varchar(50)=null,
	@Respiration varchar(50)=null,
	@SymptomsTitle varchar(100)=null,
	@AppointmentDate date=null,
	@PCase varchar(50)=null,
	@Casualty varchar(50)=null,
	@Reference varchar(100)=null,
	@ConsultantDoctor varchar(100)=null,
	@AppliedCharge decimal(18,2),
	@PaymentMode varchar(100)=null,
	@OldPatient varchar(50)=null,
	@LiveConsultation varchar(50)=null,
	@Note varchar(500)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO Master_OPDPatient_tbl(Name,GuardianName,Gender,DOB,Age,Phone,Email,Remarks,BloodGroup,MaritalStatus,PatientPhoto,Address,AnyKnownAllergies,Height,Weight,Bp,Pulse,Temperature,Respiration,SymptomsTitle,AppointmentDate,PCase,Casualty,Reference,ConsultantDoctor,AppliedCharge,PaymentMode,OldPatient,LiveConsultation,Note) 
	values (@Name,@GuardianName,@Gender,@DOB,@Age,@Phone,@Email,@Remarks,@BloodGroup,@MaritalStatus,@PatientPhoto,@Address,@AnyKnownAllergies,@Height,@Weight,@Bp,@Pulse,@Temperature,@Respiration,@SymptomsTitle,@AppointmentDate,@PCase,@Casualty,@Reference,@ConsultantDoctor,@AppliedCharge,@PaymentMode,@OldPatient,@LiveConsultation,@Note)

END



GO
/****** Object:  StoredProcedure [dbo].[InsertPathologyCategory_Sp]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Debsankar Das>
-- Description:	<Description,,Insert Category>
-- =============================================
CREATE PROCEDURE [dbo].[InsertPathologyCategory_Sp]
	-- Add the parameters for the stored procedure here
	@CategoryId bigint=0,
	@CategoryName varchar(100)=null,
	@HospitalId bigint=0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if exists(select * from [dbo].[PathologyCategory_tbl] where CategoryId=@CategoryId)
		begin
			update [dbo].[PathologyCategory_tbl]
			set
			CategoryName=@CategoryName
			where CategoryId=@CategoryId
		end
	else
		begin
			INSERT INTO PathologyCategory_tbl(CategoryName,HospitalId) values (@CategoryName,@HospitalId)
		end
END


GO
/****** Object:  StoredProcedure [dbo].[InsertPathologySubCategory_Sp]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Debsankar Das>
-- Description:	<Description,,Insert Sub Category>
-- =============================================
CREATE PROCEDURE [dbo].[InsertPathologySubCategory_Sp]
	-- Add the parameters for the stored procedure here
	@SubCategoryId bigint=0,
	@SubCategoryName varchar(100)=null,
	@CategoryId bigint=0,
	@HospitalId bigint=0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if exists(select * from [dbo].[PathologySubcategory_tbl] where SubCategoryId=@SubCategoryId)
		begin
			update [dbo].[PathologySubcategory_tbl]
			set
			SubCategoryName=@SubCategoryName,
			CategoryId=@CategoryId
			where SubCategoryId=@SubCategoryId
		end
	else
		begin
			INSERT INTO PathologySubcategory_tbl(SubCategoryName,CategoryId,HospitalId) values (@SubCategoryName,@CategoryId,@HospitalId)
		end
END



GO
/****** Object:  StoredProcedure [dbo].[InsertPathologyTest_Sp]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Debsankar Das>
-- Description:	<Description,,Insert Pathology Test>
-- =============================================
CREATE PROCEDURE [dbo].[InsertPathologyTest_Sp]
	-- Add the parameters for the stored procedure here
	@PathologyId bigint=0,
	@TestName varchar(100)=null,
	@ShortName varchar(100)=null,
	@TestType varchar(100)=null,
	@CategoryId bigint=0,
	@SubCategoryId bigint=0,
	@Method varchar(50)=null,
	@ReportDays varchar(50)=null,
	@Charge decimal(18,2),
	@AddedBy bigint=0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if exists(select * from [dbo].[PathologyTest_tbl] where PathologyId=@PathologyId)
		begin
			update [dbo].[PathologyTest_tbl]
			set
			TestName=@TestName,
			ShortName=@ShortName,
			TestType=@TestType,
			CategoryId=@CategoryId,
			SubCategoryId=@SubCategoryId,
			Method=@Method,
			ReportDays=@ReportDays,
			Charge=@Charge,
			AddedBy=@AddedBy
			where PathologyId=@PathologyId
		end
	else
		begin
			INSERT INTO PathologyTest_tbl(TestName,ShortName,TestType,CategoryId,SubCategoryId,Method,ReportDays,Charge,AddedBy) values (@TestName,@ShortName,@TestType,@CategoryId,@SubCategoryId,@Method,@ReportDays,@Charge,@AddedBy)
		end
END


GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployee]    Script Date: 12-11-2020 11:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateEmployee] 
	-- Add the parameters for the stored procedure here
	@EmployeeId bigint=0,
	@FullName varchar(100)=null,
	@EmailId varchar(50)=null,
	@Password nvarchar(50)=null,
	@Phone varchar(20)=null,
	@Age varchar(50)=null,
	@UserTypeId bigint=0,
	@HospitalId bigint=0,
	@PayrollId bigint=0,
	@Salary decimal(18,2),
	@Pf decimal(18,2),
	@MedicalIncentives decimal(18,2),
	@ServiceTax decimal(18,2),
	@Hra decimal(18,2),
	@DocumentId bigint=0,
	@VoterId varchar(MAX)=null,
	@PanId varchar(MAX)=null,
	@AadharId varchar(MAX)=null,
	@ProfilePic varchar(MAX)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if exists(select * from [dbo].[Employee_basicdetail_tbl] where EmployeeId=@EmployeeId)
		begin
			update [dbo].[Employee_basicdetail_tbl]
			set
			FullName=@FullName,
			EmailId=@EmailId,
			Phone=@Phone,
			Age=@Age,
			Password=@Password,
			UserTypeId=@UserTypeId,
			HospitalId=@HospitalId
			where EmployeeId=@EmployeeId
		end
	if exists(select * from [dbo].[Employee_Payroll_tbl] where EmployeeId=@EmployeeId)
		begin
			update [dbo].[Employee_Payroll_tbl]
			set
			Salary=@Salary,
			Pf=@Pf,
			MedicalIncentives=@MedicalIncentives,
			ServiceTax=@ServiceTax,
			Hra=@Hra
			where EmployeeId=@EmployeeId
		end
	if exists(select * from [dbo].[Employee_document_tbl] where EmployeeId=@EmployeeId)
		begin
			if(@VoterId != '' or @VoterId <>null and @PanId!='' or @PanId<>null and @AadharId!='' or @AadharId<>null and @ProfilePic!='' or @ProfilePic<>null)
			begin
			update [dbo].[Employee_document_tbl]
			set
			VoterId=@VoterId,
			PanId=@PanId,
			AadharId=@AadharId,
			ProfilePic=@ProfilePic
			where EmployeeId=@EmployeeId
			end
		end
END

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Master_City_tbl"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Master_Country_tbl"
            Begin Extent = 
               Top = 7
               Left = 290
               Bottom = 148
               Right = 484
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Master_State_tbl"
            Begin Extent = 
               Top = 7
               Left = 532
               Bottom = 170
               Right = 726
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AdminLogin_tbl"
            Begin Extent = 
               Top = 7
               Left = 774
               Bottom = 170
               Right = 998
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1404
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Master_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Master_View'
GO
