USE [HrApplication]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 6/8/2018 5:10:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 6/8/2018 5:10:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] [nvarchar](450) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 6/8/2018 5:10:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 6/8/2018 5:10:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 6/8/2018 5:10:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 6/8/2018 5:10:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 6/8/2018 5:10:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[RegistrationDate] [datetime] NULL,
	[LastLoginDate] [datetime] NULL,
	[PersonIdColumn] [int] NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Education]    Script Date: 6/8/2018 5:10:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Education](
	[EducationId] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[SpecialityName] [varchar](100) NULL,
	[EducationalInstitutionName] [varchar](100) NULL,
	[StartDate] [date] NULL,
	[FinishDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[EducationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Interview]    Script Date: 6/8/2018 5:10:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Interview](
	[InterviewId] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NULL,
	[InterviewDate] [datetime] NULL,
	[Point] [int] NULL,
	[Comment] [varchar](1000) NULL,
	[FileResume] [varchar](200) NULL,
	[FileTest] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[InterviewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Job]    Script Date: 6/8/2018 5:10:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job](
	[JobId] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NULL,
	[JobName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[JobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Knowledge_of_language]    Script Date: 6/8/2018 5:10:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Knowledge_of_language](
	[LanguageId] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[TypeLanguageId] [int] NOT NULL,
	[LanguageLevelId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Language_level]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language_level](
	[LanguageLevelId] [int] IDENTITY(1,1) NOT NULL,
	[LanguageLevelName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[LanguageLevelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationUserId] [varchar](100) NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[Birthday] [date] NULL,
	[City] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Phone] [varchar](20) NULL,
	[Salary] [int] NULL,
	[WorkExpireance] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonTypeJob]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonTypeJob](
	[PersonTypeJobId] [int] IDENTITY(1,1) NOT NULL,
	[TypeJobId] [int] NULL,
	[PersonId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonTypeJobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfessionalSkill]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfessionalSkill](
	[ProfessionalSkillId] [int] IDENTITY(1,1) NOT NULL,
	[SkillName] [varchar](100) NULL,
	[PersonId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProfessionalSkillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeJob]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeJob](
	[TypeJobId] [int] IDENTITY(1,1) NOT NULL,
	[TypeJobName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[TypeJobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeLanguage]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeLanguage](
	[TypeLanguageId] [int] IDENTITY(1,1) NOT NULL,
	[LanguageName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[TypeLanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Work_experience]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Work_experience](
	[WorkExperienceId] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[PositionName] [varchar](100) NULL,
	[CompanyName] [varchar](100) NULL,
	[StartDate] [date] NULL,
	[FinishDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[WorkExperienceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Education]  WITH CHECK ADD FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Education]  WITH CHECK ADD FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Interview]  WITH CHECK ADD FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Interview]  WITH CHECK ADD FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Knowledge_of_language]  WITH CHECK ADD FOREIGN KEY([LanguageLevelId])
REFERENCES [dbo].[Language_level] ([LanguageLevelId])
GO
ALTER TABLE [dbo].[Knowledge_of_language]  WITH CHECK ADD FOREIGN KEY([LanguageLevelId])
REFERENCES [dbo].[Language_level] ([LanguageLevelId])
GO
ALTER TABLE [dbo].[Knowledge_of_language]  WITH CHECK ADD FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Knowledge_of_language]  WITH CHECK ADD FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Knowledge_of_language]  WITH CHECK ADD FOREIGN KEY([TypeLanguageId])
REFERENCES [dbo].[TypeLanguage] ([TypeLanguageId])
GO
ALTER TABLE [dbo].[Knowledge_of_language]  WITH CHECK ADD FOREIGN KEY([TypeLanguageId])
REFERENCES [dbo].[TypeLanguage] ([TypeLanguageId])
GO
ALTER TABLE [dbo].[PersonTypeJob]  WITH CHECK ADD FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[PersonTypeJob]  WITH CHECK ADD FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[PersonTypeJob]  WITH CHECK ADD FOREIGN KEY([TypeJobId])
REFERENCES [dbo].[TypeJob] ([TypeJobId])
GO
ALTER TABLE [dbo].[PersonTypeJob]  WITH CHECK ADD FOREIGN KEY([TypeJobId])
REFERENCES [dbo].[TypeJob] ([TypeJobId])
GO
ALTER TABLE [dbo].[ProfessionalSkill]  WITH CHECK ADD FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[ProfessionalSkill]  WITH CHECK ADD FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Work_experience]  WITH CHECK ADD FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Work_experience]  WITH CHECK ADD FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
/****** Object:  StoredProcedure [dbo].[sp_AddEducation]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddEducation]
			@PersonId					int,
			@SpecialityName				varchar(100),
			@EducationalInstitutionName	varchar(100),
			@StartDate					date,
			@FinishDate					date
AS
BEGIN
	INSERT INTO Education
    ( 
			PersonId,
			SpecialityName,
			EducationalInstitutionName,
			StartDate,
			FinishDate          
     ) 
     VALUES 
     ( 
            @PersonId,
			@SpecialityName,
			@EducationalInstitutionName,
			@StartDate,
			@FinishDate
     ) 
END





GO
/****** Object:  StoredProcedure [dbo].[sp_AddInterview]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddInterview]
            @PersonId                   int = null,
            @InterviewDate              date = null,
            @Point						int = null,
            @Comment                    varchar(1000) = null,
            @FileResume                 varchar(200) = null,
			@FileTest                 varchar(200) = null
AS
BEGIN
    INSERT INTO Interview
    (
            PersonId,
            InterviewDate,
            Point,
            Comment,
            FileResume,
			FileTest          
     )
     VALUES
     (
            @PersonId,
            @InterviewDate,
            @Point,
            @Comment,
            @FileResume,
			@FileTest 
     )
END






GO
/****** Object:  StoredProcedure [dbo].[sp_AddJob]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddJob]
            @PersonId                   int = null,
			@JobName	                varchar(100) = null
AS
BEGIN
    INSERT INTO Job
    (
            PersonId,
            JobName     
     )
     VALUES
     (
            @PersonId,
            @JobName
     )
END






GO
/****** Object:  StoredProcedure [dbo].[sp_AddLanguage]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddLanguage]
            @PersonId                   int = null,
			@LanguageLevelName	        varchar(100) = null,
			@LanguageName				varchar(100) = null
AS
BEGIN
    

	 INSERT INTO Knowledge_of_language(
			PersonId,
			TypeLanguageId,
			LanguageLevelId
	 )
	  VALUES
     (
            @PersonId,
			(SELECT TypeLanguage.TypeLanguageId FROM TypeLanguage
			WHERE LanguageName = @LanguageName),
			(SELECT Language_level.LanguageLevelId FROM Language_level
			WHERE LanguageLevelName = @LanguageLevelName)
     )
END






GO
/****** Object:  StoredProcedure [dbo].[sp_AddLanguageLevel]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddLanguageLevel]
			@LanguageLevelName		varchar(100)
AS
BEGIN
	INSERT INTO Language_level
    ( 
			LanguageLevelName         
     ) 
     VALUES 
     ( 
            @LanguageLevelName
     ) 
END




GO
/****** Object:  StoredProcedure [dbo].[sp_AddPerson]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddPerson]
			@FirstName		varchar(100),
			@LastName		varchar(100),
			@Birthday		date,
			@City			varchar(100),
			@Email			varchar(100),
			@Phone			varchar(20),
			@Salary			int,
			@WorkExpireance float,
			@ApplicationUserId			varchar(100)
AS
BEGIN
	INSERT INTO Person
    ( 
			FirstName,
			LastName,
			Birthday,
			City,
			Email,
			Phone,
			Salary,
			WorkExpireance,
			ApplicationUserId           
     ) 
     VALUES 
     ( 
            @FirstName,
			@LastName,
			@Birthday,
			@City,
			@Email,
			@Phone,
			@Salary,
			@WorkExpireance,
			@ApplicationUserId 
     ) 
END







GO
/****** Object:  StoredProcedure [dbo].[sp_AddProfessionalSkill]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddProfessionalSkill]
            @PersonId                   int = null,
			@SkillName					varchar(100) = null
AS
BEGIN
	 INSERT INTO ProfessionalSkill
	 (
			PersonId,
			SkillName
			
	 )
	  VALUES
     (
            @PersonId,
			@SkillName
	 )
END






GO
/****** Object:  StoredProcedure [dbo].[sp_AddTypeJob]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddTypeJob]
            @PersonId                   int = null,
			@TypeJobName				varchar(100) = null
AS
BEGIN
	 INSERT INTO PersonTypeJob
	 (
			PersonId,
			TypeJobId
	 )
	  VALUES
     (
            @PersonId,
			(SELECT TypeJob.TypeJobId FROM TypeJob
			WHERE TypeJobName = @TypeJobName)
	 )
END






GO
/****** Object:  StoredProcedure [dbo].[sp_AddTypeJobsName]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddTypeJobsName]
			@TypeJobName		varchar(100)
AS
BEGIN
	INSERT INTO TypeJob
    ( 
			TypeJobName	         
     ) 
     VALUES 
     ( 
            @TypeJobName
     ) 
END




GO
/****** Object:  StoredProcedure [dbo].[sp_AddTypeLanguage]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddTypeLanguage]
			@LanguageName		varchar(100)
AS
BEGIN
	INSERT INTO TypeLanguage
    ( 
			LanguageName         
     ) 
     VALUES 
     ( 
            @LanguageName
     ) 
END




GO
/****** Object:  StoredProcedure [dbo].[sp_AddWorkExperience]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddWorkExperience]
            @PersonId                   int = null,
			@PositionName				varchar(100) = null,
			@CompanyName				varchar(100) = null,
			@StartDate					date = null,
			@FinishDate					date = null
AS
BEGIN
	 INSERT INTO Work_experience
	 (
			PersonId,
			PositionName,
			CompanyName,
			StartDate,
			FinishDate
			
	 )
	  VALUES
     (
            @PersonId,
			@PositionName,
			@CompanyName,
			@StartDate,
			@FinishDate
	 )
END





GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteEducation]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteEducation]
	@EducationId	int
AS
BEGIN
	DELETE FROM Education
	WHERE EducationId=@EducationId
END




GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteInterview]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteInterview]
	@InterviewId			int
AS
BEGIN
	DELETE FROM Interview
	WHERE InterviewId=@InterviewId
END




GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteJob]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteJob]
	@JobId				int
AS
BEGIN
	DELETE FROM Job
	WHERE JobId=@JobId
END




GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteLanguage]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteLanguage]
	@LanguageId	int
AS
BEGIN
	DELETE FROM Knowledge_of_language
	WHERE LanguageId=@LanguageId
END




GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteLanguageLevel]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteLanguageLevel]
	@LanguageLevelId	int
AS
BEGIN
	DELETE FROM Language_level
	WHERE LanguageLevelId=@LanguageLevelId
END



GO
/****** Object:  StoredProcedure [dbo].[sp_DeletePerson]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeletePerson]
	@PersonId	int
AS
BEGIN

	DELETE FROM Education
	WHERE PersonId=@PersonId

	DELETE FROM Interview
	WHERE PersonId=@PersonId

	DELETE FROM Job
	WHERE PersonId=@PersonId

	DELETE FROM Knowledge_of_language
	WHERE PersonId=@PersonId

	DELETE FROM PersonTypeJob
	WHERE PersonId=@PersonId

	DELETE FROM ProfessionalSkill
	WHERE PersonId=@PersonId

	DELETE FROM Work_experience
	WHERE PersonId=@PersonId

	DELETE FROM Person
	WHERE PersonId=@PersonId
END




GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteProfessionalSkill]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteProfessionalSkill]
	@ProfessionalSkillId	int
AS
BEGIN
	DELETE FROM ProfessionalSkill
	WHERE ProfessionalSkillId=@ProfessionalSkillId
END




GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteTypeJob]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteTypeJob]
	@PersonTypeJobId				int
AS
BEGIN
	DELETE FROM PersonTypeJob
	WHERE PersonTypeJobId=@PersonTypeJobId
END




GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteTypeJobsName]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteTypeJobsName]
	@TypeJobsNameId	int
AS
BEGIN
	DELETE FROM TypeJob
	WHERE TypeJobId=@TypeJobsNameId
END



GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteTypeLanguage]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteTypeLanguage]
	@TypeLanguageId	int
AS
BEGIN
	DELETE FROM TypeLanguage
	WHERE TypeLanguageId=@TypeLanguageId
END



GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteWorkExperience]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteWorkExperience]
	@WorkExperienceId	int
AS
BEGIN
	DELETE FROM Work_experience
	WHERE WorkExperienceId=@WorkExperienceId
END




GO
/****** Object:  StoredProcedure [dbo].[sp_EditEducation]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EditEducation]
			@EducationId				int,
			@SpecialityName				varchar(100)	= null,
			@EducationalInstitutionName	varchar(100)	= null,
			@StartDate					date			= null,
			@FinishDate					date			= null
AS
BEGIN
	UPDATE Education
    SET SpecialityName				=ISNULL(@SpecialityName,SpecialityName), 
        EducationalInstitutionName	=ISNULL(@EducationalInstitutionName, EducationalInstitutionName), 
		StartDate					=ISNULL(@StartDate, StartDate), 
		FinishDate					=ISNULL(@FinishDate, FinishDate)
    WHERE EducationId=@EducationId
END




GO
/****** Object:  StoredProcedure [dbo].[sp_EditInterview]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EditInterview]
			@InterviewId				int,
			@InterviewDate				varchar(100)	= null,
			@Point						int				= null,
			@Comment					varchar(1000)	= null,
			@FileResume					varchar(1000)	= null,
			@FileTest					varchar(1000)	= null
AS
BEGIN
	UPDATE Interview
    SET InterviewDate				=ISNULL(@InterviewDate,InterviewDate), 
        Point						=ISNULL(@Point, Point), 
		Comment					=ISNULL(@Comment, Comment), 
		FileResume					=ISNULL(@FileResume, FileResume),
		FileTest					=ISNULL(@FileTest, FileTest)
    WHERE InterviewId=@InterviewId
END




GO
/****** Object:  StoredProcedure [dbo].[sp_EditJob]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EditJob]
	@JobId				int,
	@JobName			varchar(100)	= null
AS
BEGIN
	UPDATE Job
    SET JobName				=ISNULL(@JobName, JobName)
    WHERE JobId=@JobId
END




GO
/****** Object:  StoredProcedure [dbo].[sp_EditLanguage]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EditLanguage]
			@LanguageId                 int,
			@LanguageLevelName	        varchar(100) = null,
			@LanguageName				varchar(100) = null
AS
BEGIN
	UPDATE Knowledge_of_language
    SET TypeLanguageId				=ISNULL((SELECT TypeLanguage.TypeLanguageId FROM TypeLanguage
											 WHERE LanguageName = @LanguageName),TypeLanguageId), 
        LanguageLevelId				=ISNULL((SELECT Language_level.LanguageLevelId FROM Language_level
			WHERE LanguageLevelName = @LanguageLevelName), LanguageLevelId)
    WHERE LanguageId=@LanguageId
END




GO
/****** Object:  StoredProcedure [dbo].[sp_EditLanguageLevel]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EditLanguageLevel]
			@LanguageLevelId				int,
			@LanguageLevelName				varchar(100)	= null
AS
BEGIN
	UPDATE Language_level
    SET LanguageLevelName				=ISNULL(@LanguageLevelName,LanguageLevelName)
    WHERE LanguageLevelId=@LanguageLevelId
END



GO
/****** Object:  StoredProcedure [dbo].[sp_EditPerson]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EditPerson]
			@PersonId		int,
			@FirstName		varchar(100)	= null,
			@LastName		varchar(100)	= null,
			@Birthday		date			= null,
			@City			varchar(100)	= null,
			@Email			varchar(100)	= null,
			@Phone			varchar(20)		= null,
			@Salary			int				= null,
			@WorkExpireance float			= null
AS
BEGIN
	UPDATE Person
    SET FirstName				=ISNULL(@FirstName,FirstName), 
        LastName				=ISNULL(@LastName, LastName), 
		Birthday				=ISNULL(@Birthday, Birthday), 
		City					=ISNULL(@City, City),
		Email					=ISNULL(@Email, Email),
		Phone					=ISNULL(@Phone, Phone),
		Salary					=ISNULL(@Salary, Salary),
		WorkExpireance			=ISNULL(@WorkExpireance, WorkExpireance)
    WHERE PersonId=@PersonId
END






GO
/****** Object:  StoredProcedure [dbo].[sp_EditProfessionalSkill]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EditProfessionalSkill]
			@ProfessionalSkillId		int,
			@SkillName					varchar(100)	= null
AS
BEGIN
	UPDATE ProfessionalSkill
    SET SkillName				=ISNULL(@SkillName,SkillName)
    WHERE ProfessionalSkillId=@ProfessionalSkillId
END




GO
/****** Object:  StoredProcedure [dbo].[sp_EditTypeJob]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EditTypeJob]
	@PersonTypeJobId				int,
	@TypeJobName			varchar(100)	= null
AS
BEGIN
	UPDATE PersonTypeJob
    SET TypeJobId				=ISNULL((SELECT TypeJob.TypeJobId FROM TypeJob
			WHERE TypeJobName = @TypeJobName), PersonTypeJobId)
    WHERE @PersonTypeJobId=PersonTypeJobId
END




GO
/****** Object:  StoredProcedure [dbo].[sp_EditTypeJobsName]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EditTypeJobsName]
			@TypeJobsNameId				int,
			@TypeJobName				varchar(100)	= null
AS
BEGIN
	UPDATE TypeJob
    SET TypeJobName				=ISNULL(@TypeJobName,TypeJobName)
    WHERE TypeJobId=@TypeJobsNameId
END



GO
/****** Object:  StoredProcedure [dbo].[sp_EditTypeLanguage]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EditTypeLanguage]
			@TypeLanguageId				int,
			@LanguageName				varchar(100)	= null
AS
BEGIN
	UPDATE TypeLanguage
    SET LanguageName				=ISNULL(@LanguageName,LanguageName)
    WHERE TypeLanguageId=@TypeLanguageId
END



GO
/****** Object:  StoredProcedure [dbo].[sp_EditWorkExperience]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EditWorkExperience]
			@WorkExperienceId			int,
			@PositionName				varchar(100)	= null,
			@CompanyName				varchar(100)	= null,
			@StartDate					date			= null,
			@FinishDate					date			= null
AS
BEGIN
	UPDATE Work_experience
    SET PositionName				=ISNULL(@PositionName,PositionName), 
        CompanyName					=ISNULL(@CompanyName, CompanyName), 
		StartDate					=ISNULL(@StartDate, StartDate), 
		FinishDate					=ISNULL(@FinishDate, FinishDate)
    WHERE WorkExperienceId=@WorkExperienceId
END




GO
/****** Object:  StoredProcedure [dbo].[sp_GetCountPersons]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetCountPersons]
@ApplicationUserId				varchar(100) = null
AS
BEGIN
	SELECT	COUNT(*)
	FROM	Person
		WHERE 		ApplicationUserId = @ApplicationUserId
END








GO
/****** Object:  StoredProcedure [dbo].[sp_GetCountPersonsWhere]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetCountPersonsWhere]
  @Page					int = 1,
			@Count					int = 10,

			@PersonId				int = null,
			@FirstName				varchar(100) = null,
			@LastName				varchar(100) = null,
			@AgeStart				int = null,
			@AgeFinish				int = null,
			@City					varchar(100) = null,
			@Email					varchar(100) = null,
			@Phone					varchar(100) = null,
			@SalaryStart			int = null,
			@SalaryFinish			int = null,
			@WorkExpireanceStart	int = null,
			@WorkExpireanceFinish	int = null,

			@SpecialityName			varchar(100) = null,
			@EducationalInstitutionName	varchar(100) = null,
			@EducationStartDate		date = null,
			@EducationFinishDate	date = null,

			@InterviewStartDate		date = null,
			@InterviewFinishDate	date = null,

			@LanguageName			varchar(100) = null,
			@LanguageLevelName		varchar(100) = null,

			@JobName				varchar(100) = null,

			@TypeJobName			varchar(100) = null,

			@PositionName			varchar(100) = null,
			@CompanyName			varchar(100) = null,
			@ExperienceStartDate	date = null,
			@ExperienceFinishDate	date = null,

			@SkillName				varchar(100) = null
			
AS
BEGIN
	
	SELECT  Knowledge_of_language.LanguageId, TypeLanguage.LanguageName,
            Language_level.LanguageLevelName, Knowledge_of_language.PersonId
    INTO    #tempLanguage
    FROM    Knowledge_of_language
    INNER JOIN Language_level ON Language_level.LanguageLevelId=Knowledge_of_language.LanguageLevelId
    INNER JOIN TypeLanguage ON TypeLanguage.TypeLanguageId=Knowledge_of_language.TypeLanguageId

	SELECT  PersonTypeJob.PersonTypeJobId, PersonTypeJob.PersonId,
            TypeJob.TypeJobName
    INTO    #tempTypeJob
    FROM    PersonTypeJob
    INNER JOIN TypeJob ON PersonTypeJob.TypeJobId = TypeJob.TypeJobId

	SELECT DISTINCT	COUNT(*)
	FROM	(SELECT PersonTable.PersonId, PersonTable.Email, PersonTable.FirstName, 
						PersonTable.LastName, PersonTable.Phone, PersonTable.Salary, 
						PersonTable.Birthday, PersonTable.City,PersonTable.WorkExpireance
						FROM (	SELECT DISTINCT	Person.PersonId, Person.Email, Person.FirstName, 
						Person.LastName, Person.Phone, Person.Salary, 
						Person.Birthday, Person.City,Person.WorkExpireance
										 
				FROM	Person

				INNER JOIN ( SELECT Person.PersonId FROM Person
	LEFT JOIN Education ON Person.PersonId = Education.PersonId
		AND (@SpecialityName IS NULL OR (Education.SpecialityName LIKE '%' + @SpecialityName  + '%')) 
		AND (@EducationalInstitutionName IS NULL OR (Education.EducationalInstitutionName LIKE '%' + @EducationalInstitutionName  + '%')) 
		AND (@EducationStartDate IS NULL OR (Education.StartDate <= @EducationStartDate)) 
		AND	(@EducationFinishDate IS NULL OR (Education.FinishDate >= @EducationFinishDate))

	INNER JOIN Interview ON Person.PersonId = Interview.PersonId
		AND (@InterviewStartDate IS NULL OR (Interview.InterviewDate >= @InterviewStartDate)) 
		AND (@InterviewFinishDate IS NULL OR (Interview.InterviewDate <= @InterviewFinishDate)) 

	INNER JOIN #tempLanguage ON Person.PersonId = #tempLanguage.PersonId 
		AND	(@LanguageName IS NULL OR (#tempLanguage.LanguageName LIKE '%' + @LanguageName + '%')) 
		AND (@LanguageLevelName IS NULL OR (#tempLanguage.LanguageLevelName LIKE '%' + @LanguageLevelName + '%'))
	
	LEFT JOIN Job ON Person.PersonId = Job.PersonId
		AND (@JobName IS NULL OR (Job.JobName LIKE '%' + @JobName  + '%'))

	INNER JOIN #tempTypeJob ON Person.PersonId = #tempTypeJob.PersonId 
		AND (@TypeJobName IS NULL OR (#tempTypeJob.TypeJobName LIKE '%' + @TypeJobName  + '%'))
	
	INNER JOIN Work_experience ON Person.PersonId = Work_experience.PersonId
		AND (@CompanyName IS NULL OR (Work_experience.CompanyName LIKE '%' + @CompanyName + '%')) 
		AND (@PositionName IS NULL OR (Work_experience.PositionName LIKE '%' + @PositionName + '%')) 

	LEFT JOIN ProfessionalSkill ON Person.PersonId = ProfessionalSkill.PersonId
		AND (@SkillName IS NULL OR (ProfessionalSkill.SkillName LIKE '%' + @SkillName  + '%'))) JoinTable
	ON Person.PersonId = JoinTable.PersonId 
				WHERE	(@PersonId IS NULL OR (Person.PersonId = @PersonId)) AND
						(@FirstName IS NULL OR (Person.FirstName LIKE '%' + @FirstName + '%')) AND
						(@LastName IS NULL OR (Person.LastName LIKE '%' + @LastName + '%')) AND
						(@City IS NULL OR (Person.City LIKE '%' + @City + '%')) AND
						(@Email IS NULL OR (Person.Email LIKE '%' + @Email + '%')) AND
						(@Phone IS NULL OR (Person.Phone LIKE '%' + @Phone + '%')) AND
						(@SalaryStart IS NULL OR (Person.Salary >= @SalaryStart)) AND
						(@SalaryFinish IS NULL OR (Person.Salary <= @SalaryFinish)) AND
						(@WorkExpireanceStart IS NULL OR (Person.WorkExpireance >= @WorkExpireanceStart)) AND
						(@WorkExpireanceFinish IS NULL OR (Person.WorkExpireance <= @WorkExpireanceFinish))

	) PersonTable
	) TempPerson
END


GO
/****** Object:  StoredProcedure [dbo].[sp_GetEducationById]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetEducationById]
    @EducationId int 
AS   
BEGIN
      SELECT Education.EducationId, Education.PersonId, Education.SpecialityName, Education.EducationalInstitutionName,
			 Education.StartDate, Education.FinishDate

      FROM	 dbo.Education WHERE EducationId=@EducationId
END









GO
/****** Object:  StoredProcedure [dbo].[sp_GetEducations]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetEducations]
AS   
BEGIN
      SELECT Education.EducationId, Education.PersonId, Education.SpecialityName,
			 Education.EducationalInstitutionName, Education.StartDate, Education.FinishDate

      FROM	 dbo.Education
END









GO
/****** Object:  StoredProcedure [dbo].[sp_GetEducationsWhere]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetEducationsWhere]
	@PersonId int = null,
	@SpecialityName varchar(100) = null,
	@EducationalInstitutionName varchar(100) = null

AS
BEGIN
      SELECT Education.EducationId, Education.PersonId, Education.SpecialityName,
			 Education.EducationalInstitutionName, Education.StartDate, Education.FinishDate

      FROM	 dbo.Education

	  WHERE	 (@PersonId IS NULL OR (Education.PersonId = @PersonId)) AND
			 (@SpecialityName IS NULL OR (Education.SpecialityName LIKE '%' + @SpecialityName  + '%')) AND
			 (@EducationalInstitutionName IS NULL OR (Education.EducationalInstitutionName LIKE '%' + @EducationalInstitutionName  + '%'))
END









GO
/****** Object:  StoredProcedure [dbo].[sp_GetInterviewById]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetInterviewById]
			@InterviewId int
AS
BEGIN
	SELECT	Interview.InterviewId, Interview.PersonId, 
			Interview.InterviewDate, Interview.Point, 
			Interview.Comment, Interview.FileResume, Interview.FileTest

	FROM	Interview

	WHERE	Interview.InterviewId = @InterviewId
END







GO
/****** Object:  StoredProcedure [dbo].[sp_GetInterviews]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetInterviews]
AS
BEGIN
	SELECT	Interview.InterviewId, Interview.PersonId, 
			Interview.InterviewDate, Interview.Point, 
			Interview.Comment, Interview.FileResume, Interview.FileTest

	FROM	Interview
END









GO
/****** Object:  StoredProcedure [dbo].[sp_GetInterviewsWhere]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetInterviewsWhere]
			@PersonId int = null,
			@Point int = null
AS
BEGIN
	SELECT	Interview.InterviewId, Interview.PersonId, 
			Interview.InterviewDate, Interview.Point, 
			Interview.Comment, Interview.FileResume, Interview.FileTest

	FROM	Interview

	WHERE	(@PersonId IS NULL OR (Interview.PersonId = @PersonId))
END









GO
/****** Object:  StoredProcedure [dbo].[sp_GetJobById]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetJobById]
    @JobId int 
AS   
BEGIN
      SELECT Job.JobId, Job.PersonId, Job.JobName

      FROM	 dbo.Job WHERE JobId=@JobId
END









GO
/****** Object:  StoredProcedure [dbo].[sp_GetJobs]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetJobs]
AS   
BEGIN
      SELECT Job.JobId, Job.PersonId, Job.JobName

      FROM	 dbo.Job
END









GO
/****** Object:  StoredProcedure [dbo].[sp_GetJobsWhere]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetJobsWhere]
	@PersonId int = null,
	@JobName varchar(100) = null

AS
BEGIN
      SELECT Job.JobId, Job.PersonId, Job.JobName

      FROM	 dbo.Job

	  WHERE	 (@PersonId IS NULL OR (Job.PersonId = @PersonId)) AND
			 (@JobName IS NULL OR (Job.JobName LIKE '%' + @JobName  + '%'))
END









GO
/****** Object:  StoredProcedure [dbo].[sp_GetLanguageById]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetLanguageById]
			@LanguageId int
AS
BEGIN
	SELECT	Knowledge_of_language.LanguageId, TypeLanguage.LanguageName, 
			Language_level.LanguageLevelName, Knowledge_of_language.PersonId

	FROM	Knowledge_of_language
	INNER JOIN Language_level ON Language_level.LanguageLevelId=Knowledge_of_language.LanguageLevelId
	INNER JOIN TypeLanguage ON TypeLanguage.TypeLanguageId=Knowledge_of_language.TypeLanguageId

	WHERE	Knowledge_of_language.LanguageId = @LanguageId
END







GO
/****** Object:  StoredProcedure [dbo].[sp_GetLanguageLevel]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetLanguageLevel]
AS
BEGIN
	SELECT	Language_level.LanguageLevelId, Language_level.LanguageLevelName

	FROM	Language_level
END








GO
/****** Object:  StoredProcedure [dbo].[sp_GetLanguageLevelById]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetLanguageLevelById]
	@LanguageLevelId int
AS   
BEGIN
      SELECT Language_level.LanguageLevelId, Language_level.LanguageLevelName

      FROM	 dbo.Language_level

	  WHERE @LanguageLevelId=LanguageLevelId
END








GO
/****** Object:  StoredProcedure [dbo].[sp_GetLanguages]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetLanguages]
AS
BEGIN
	SELECT	Knowledge_of_language.LanguageId, TypeLanguage.LanguageName, 
			Language_level.LanguageLevelName, Knowledge_of_language.PersonId

	FROM	Knowledge_of_language
	INNER JOIN Language_level ON Language_level.LanguageLevelId=Knowledge_of_language.LanguageLevelId
	INNER JOIN TypeLanguage ON TypeLanguage.TypeLanguageId=Knowledge_of_language.TypeLanguageId
END









GO
/****** Object:  StoredProcedure [dbo].[sp_GetLanguagesWhere]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetLanguagesWhere]
			@PersonId int = null,
			@LanguageName varchar(100) = null,
			@LanguageLevelName varchar(100) = null
AS
BEGIN
	SELECT	Knowledge_of_language.LanguageId, TypeLanguage.LanguageName, 
			Language_level.LanguageLevelName, Knowledge_of_language.PersonId

	FROM	Knowledge_of_language
	INNER JOIN Language_level ON Language_level.LanguageLevelId=Knowledge_of_language.LanguageLevelId
	INNER JOIN TypeLanguage ON TypeLanguage.TypeLanguageId=Knowledge_of_language.TypeLanguageId

	WHERE	(@PersonId IS NULL OR (Knowledge_of_language.PersonId = @PersonId)) AND
			(@LanguageName IS NULL OR (TypeLanguage.LanguageName LIKE '%' + @LanguageName + '%')) AND
			(@LanguageLevelName IS NULL OR (Language_level.LanguageLevelName LIKE '%' + @LanguageLevelName + '%'))
END









GO
/****** Object:  StoredProcedure [dbo].[sp_GetPersonById]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPersonById]
			@PersonId int
AS
BEGIN
	SELECT	* 
	INTO	#tempEducation 
	FROM	Education
	WHERE	PersonId = @PersonId

	SELECT	* 
	INTO	#tempInterview 
	FROM	Interview
	WHERE	PersonId = @PersonId

	SELECT	Knowledge_of_language.LanguageId, TypeLanguage.LanguageName, 
			Language_level.LanguageLevelName, Knowledge_of_language.PersonId
	INTO	#tempLanguage
	FROM	Knowledge_of_language
	INNER JOIN Language_level ON Language_level.LanguageLevelId=Knowledge_of_language.LanguageLevelId
	INNER JOIN TypeLanguage ON TypeLanguage.TypeLanguageId=Knowledge_of_language.TypeLanguageId
	WHERE	PersonId = @PersonId

	SELECT	*
	INTO	#tempJob
	FROM	Job
	WHERE	PersonId = @PersonId

	SELECT  PersonTypeJob.PersonTypeJobId, PersonTypeJob.PersonId,
		    TypeJob.TypeJobName
	INTO	#tempTypeJob
	FROM	PersonTypeJob 
	INNER JOIN TypeJob ON PersonTypeJob.TypeJobId = TypeJob.TypeJobId 
	WHERE	PersonId = @PersonId

	SELECT	*
	INTO	#tempWorkExpireance
	FROM	Work_experience
	WHERE	PersonId = @PersonId

	SELECT	*
	INTO	#tempProfessionalSkill
	FROM	ProfessionalSkill
	WHERE	PersonId = @PersonId

	SELECT	Person.PersonId, Person.Email, Person.FirstName, 
			Person.LastName, Person.Phone, Person.Salary, 
			Person.Birthday, Person.City,Person.WorkExpireance 
    INTO	#tempPersonTable
	FROM	Person
	WHERE	PersonId = @PersonId
	
	SELECT * FROM #tempPersonTable	
			

	SELECT * FROM #tempEducation
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM #tempInterview
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM #tempLanguage
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM #tempJob
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM #tempTypeJob
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM #tempWorkExpireance
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM #tempProfessionalSkill
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)
END








GO
/****** Object:  StoredProcedure [dbo].[sp_GetPersons]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPersons]
			@Page					int = 1,
			@Count					int = 10
AS
BEGIN
	SELECT	* 
	INTO	#tempEducation 
	FROM	Education

	SELECT	* 
	INTO	#tempInterview 
	FROM	Interview

	SELECT	Knowledge_of_language.LanguageId, TypeLanguage.LanguageName, 
			Language_level.LanguageLevelName, Knowledge_of_language.PersonId
	INTO	#tempLanguage
	FROM	Knowledge_of_language
	INNER JOIN Language_level ON Language_level.LanguageLevelId=Knowledge_of_language.LanguageLevelId
	INNER JOIN TypeLanguage ON TypeLanguage.TypeLanguageId=Knowledge_of_language.TypeLanguageId

	SELECT	*
	INTO	#tempJob
	FROM	Job

	SELECT  PersonTypeJob.PersonTypeJobId, PersonTypeJob.PersonId,
		    TypeJob.TypeJobName
	INTO	#tempTypeJob
	FROM	PersonTypeJob 
	INNER JOIN TypeJob ON PersonTypeJob.TypeJobId = TypeJob.TypeJobId 

	SELECT	*
	INTO	#tempWorkExpireance
	FROM	Work_experience

	SELECT	*
	INTO	#tempProfessionalSkill
	FROM	ProfessionalSkill

	SELECT DISTINCT	TempPerson.PersonId, TempPerson.Email, TempPerson.FirstName, 
			TempPerson.LastName, TempPerson.Phone, TempPerson.Salary, 
			TempPerson.Birthday, TempPerson.City,TempPerson.WorkExpireance 
    INTO	#tempPersonTable
	FROM	(SELECT PersonTable.PersonId, PersonTable.Email, PersonTable.FirstName, 
						PersonTable.LastName, PersonTable.Phone, PersonTable.Salary, 
						PersonTable.Birthday, PersonTable.City,PersonTable.WorkExpireance, ROW_NUMBER() OVER (ORDER BY PersonTable.PersonId) as row
						FROM (	SELECT DISTINCT	Person.PersonId, Person.Email, Person.FirstName, 
						Person.LastName, Person.Phone, Person.Salary, 
						Person.Birthday, Person.City,Person.WorkExpireance
						 
				FROM	Person
				
	) PersonTable
	) TempPerson
	WHERE (row > ((@Page*@Count)-@Count) and row <= @Page*@Count)
	
	SELECT * FROM #tempPersonTable	
			

	SELECT * FROM #tempEducation
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM #tempInterview
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM #tempLanguage
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM #tempJob
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM #tempTypeJob
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM #tempWorkExpireance
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM #tempProfessionalSkill
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)
END



/****** Object:  StoredProcedure [dbo].[sp_GetPersons]    Script Date: 21.04.2017 18:56:40 ******/
SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[sp_GetPersonsByAppUserId]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPersonsByAppUserId]
			@Page					int = 1,
			@Count					int = 10,

			@ApplicationUserId		varchar(100) = null
			
AS
BEGIN
	
	SELECT	Knowledge_of_language.LanguageId, TypeLanguage.LanguageName, 
			Language_level.LanguageLevelName, Knowledge_of_language.PersonId
	INTO	#tempLanguage
	FROM	Knowledge_of_language
	INNER JOIN Language_level ON Language_level.LanguageLevelId=Knowledge_of_language.LanguageLevelId
	INNER JOIN TypeLanguage ON TypeLanguage.TypeLanguageId=Knowledge_of_language.TypeLanguageId
	
	SELECT  PersonTypeJob.PersonTypeJobId, PersonTypeJob.PersonId,
		    TypeJob.TypeJobName
	INTO	#tempTypeJob
	FROM	PersonTypeJob 
	INNER JOIN TypeJob ON PersonTypeJob.TypeJobId = TypeJob.TypeJobId 

	SELECT DISTINCT	TempPerson.PersonId, TempPerson.Email, TempPerson.FirstName, 
			TempPerson.LastName, TempPerson.Phone, TempPerson.Salary, 
			TempPerson.Birthday, TempPerson.City,TempPerson.WorkExpireance, TempPerson.ApplicationUserId	
    INTO	#tempPersonTable
	FROM	(SELECT PersonTable.PersonId, PersonTable.Email, PersonTable.FirstName, 
						PersonTable.LastName, PersonTable.Phone, PersonTable.Salary, 
						PersonTable.Birthday, PersonTable.City,PersonTable.WorkExpireance,PersonTable.ApplicationUserId, ROW_NUMBER() OVER (ORDER BY PersonTable.PersonId) as row
						FROM (	SELECT DISTINCT	Person.PersonId, Person.Email, Person.FirstName, 
						Person.LastName, Person.Phone, Person.Salary, 
						Person.Birthday, Person.City,Person.WorkExpireance, Person.ApplicationUserId
						 
				FROM	Person

				INNER JOIN ( SELECT Person.PersonId FROM Person
	LEFT JOIN Education ON Person.PersonId = Education.PersonId

	INNER JOIN Interview ON Person.PersonId = Interview.PersonId

	INNER JOIN #tempLanguage ON Person.PersonId = #tempLanguage.PersonId 
	
	LEFT JOIN Job ON Person.PersonId = Job.PersonId

	INNER JOIN #tempTypeJob ON Person.PersonId = #tempTypeJob.PersonId 
	
	INNER JOIN Work_experience ON Person.PersonId = Work_experience.PersonId

	LEFT JOIN ProfessionalSkill ON Person.PersonId = ProfessionalSkill.PersonId) JoinTable
	ON Person.PersonId = JoinTable.PersonId 
				WHERE	(@ApplicationUserId IS NULL OR (Person.ApplicationUserId LIKE '%' + @ApplicationUserId + '%'))

	) PersonTable
	) TempPerson
	WHERE (row > ((@Page*@Count)-@Count) and row <= @Page*@Count)
	
	SELECT * FROM #tempPersonTable	
			
	SELECT * FROM Education
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM Interview
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM #tempLanguage
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM Job
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM #tempTypeJob
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM Work_experience
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM ProfessionalSkill
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

END


GO
/****** Object:  StoredProcedure [dbo].[sp_GetPersonsByHrId]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPersonsByHrId]
			@Page					int = 1,
			@Count					int = 10,
			@ApplicationUserId		varchar(100) = null
AS
BEGIN
	SELECT	* 
	INTO	#tempEducation 
	FROM	Education

	SELECT	* 
	INTO	#tempInterview 
	FROM	Interview

	SELECT	Knowledge_of_language.LanguageId, TypeLanguage.LanguageName, 
			Language_level.LanguageLevelName, Knowledge_of_language.PersonId
	INTO	#tempLanguage
	FROM	Knowledge_of_language
	INNER JOIN Language_level ON Language_level.LanguageLevelId=Knowledge_of_language.LanguageLevelId
	INNER JOIN TypeLanguage ON TypeLanguage.TypeLanguageId=Knowledge_of_language.TypeLanguageId

	SELECT	*
	INTO	#tempJob
	FROM	Job

	SELECT  PersonTypeJob.PersonTypeJobId, PersonTypeJob.PersonId,
		    TypeJob.TypeJobName
	INTO	#tempTypeJob
	FROM	PersonTypeJob 
	INNER JOIN TypeJob ON PersonTypeJob.TypeJobId = TypeJob.TypeJobId 

	SELECT	*
	INTO	#tempWorkExpireance
	FROM	Work_experience

	SELECT	*
	INTO	#tempProfessionalSkill
	FROM	ProfessionalSkill

	SELECT DISTINCT	TempPerson.PersonId, TempPerson.Email, TempPerson.FirstName, 
			TempPerson.LastName, TempPerson.Phone, TempPerson.Salary, 
			TempPerson.Birthday, TempPerson.City,TempPerson.WorkExpireance, TempPerson.ApplicationUserId 
    INTO	#tempPersonTable
	FROM	(SELECT PersonTable.PersonId, PersonTable.Email, PersonTable.FirstName, 
						PersonTable.LastName, PersonTable.Phone, PersonTable.Salary, 
						PersonTable.Birthday, PersonTable.City,PersonTable.WorkExpireance, PersonTable.ApplicationUserId, ROW_NUMBER() OVER (ORDER BY PersonTable.ApplicationUserId) as row
						FROM (	SELECT DISTINCT	Person.PersonId, Person.Email, Person.FirstName, 
						Person.LastName, Person.Phone, Person.Salary, 
						Person.Birthday, Person.City,Person.WorkExpireance, Person.ApplicationUserId
						 
				FROM	Person  WHERE  (Person.ApplicationUserId LIKE '%' + @ApplicationUserId + '%')
				
	) PersonTable
	) TempPerson
	WHERE (row > ((@Page*@Count)-@Count) and row <= @Page*@Count)
	
	SELECT * FROM #tempPersonTable	
			

	SELECT * FROM #tempEducation
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM #tempInterview
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM #tempLanguage
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM #tempJob
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM #tempTypeJob
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM #tempWorkExpireance
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM #tempProfessionalSkill
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)
END




GO
/****** Object:  StoredProcedure [dbo].[sp_GetPersonsWhere]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPersonsWhere]
         @Page					int = 1,
			@Count					int = 10,

			@PersonId				int = null,
			@FirstName				varchar(100) = null,
			@LastName				varchar(100) = null,
			@AgeStart				int = null,
			@AgeFinish				int = null,
			@City					varchar(100) = null,
			@Email					varchar(100) = null,
			@Phone					varchar(100) = null,
			@SalaryStart			int = null,
			@SalaryFinish			int = null,
			@WorkExpireanceStart	int = null,
			@WorkExpireanceFinish	int = null,
			@ApplicationUserId		varchar(100) = null,

			@SpecialityName			varchar(100) = null,
			@EducationalInstitutionName	varchar(100) = null,
			@EducationStartDate		date = null,
			@EducationFinishDate	date = null,

			@InterviewStartDate		date = null,
			@InterviewFinishDate	date = null,

			@LanguageName			varchar(100) = null,
			@LanguageLevelName		varchar(100) = null,

			@JobName				varchar(100) = null,

			@TypeJobName			varchar(100) = null,

			@PositionName			varchar(100) = null,
			@CompanyName			varchar(100) = null,
			@ExperienceStartDate	date = null,
			@ExperienceFinishDate	date = null,

			@SkillName				varchar(100) = null

			
AS
BEGIN
	
	SELECT	Knowledge_of_language.LanguageId, TypeLanguage.LanguageName, 
			Language_level.LanguageLevelName, Knowledge_of_language.PersonId
	INTO	#tempLanguage
	FROM	Knowledge_of_language
	INNER JOIN Language_level ON Language_level.LanguageLevelId=Knowledge_of_language.LanguageLevelId
	INNER JOIN TypeLanguage ON TypeLanguage.TypeLanguageId=Knowledge_of_language.TypeLanguageId
	
	SELECT  PersonTypeJob.PersonTypeJobId, PersonTypeJob.PersonId,
		    TypeJob.TypeJobName
	INTO	#tempTypeJob
	FROM	PersonTypeJob 
	INNER JOIN TypeJob ON PersonTypeJob.TypeJobId = TypeJob.TypeJobId 

	SELECT DISTINCT	TempPerson.PersonId, TempPerson.Email, TempPerson.FirstName, 
			TempPerson.LastName, TempPerson.Phone, TempPerson.Salary, 
			TempPerson.Birthday, TempPerson.City,TempPerson.WorkExpireance 
    INTO	#tempPersonTable
	FROM	(SELECT PersonTable.PersonId, PersonTable.Email, PersonTable.FirstName, 
						PersonTable.LastName, PersonTable.Phone, PersonTable.Salary, 
						PersonTable.Birthday, PersonTable.City,PersonTable.WorkExpireance, ROW_NUMBER() OVER (ORDER BY PersonTable.PersonId) as row
						FROM (	SELECT DISTINCT	Person.PersonId, Person.Email, Person.FirstName, 
						Person.LastName, Person.Phone, Person.Salary, 
						Person.Birthday, Person.City,Person.WorkExpireance
						 
				FROM	Person

				INNER JOIN ( SELECT Person.PersonId FROM Person
	LEFT JOIN Education ON Person.PersonId = Education.PersonId
		AND (@SpecialityName IS NULL OR (Education.SpecialityName LIKE '%' + @SpecialityName  + '%')) 
		AND (@EducationalInstitutionName IS NULL OR (Education.EducationalInstitutionName LIKE '%' + @EducationalInstitutionName  + '%')) 
		AND (@EducationStartDate IS NULL OR (Education.StartDate <= @EducationStartDate)) 
		AND	(@EducationFinishDate IS NULL OR (Education.FinishDate >= @EducationFinishDate))

	INNER JOIN Interview ON Person.PersonId = Interview.PersonId
		AND (@InterviewStartDate IS NULL OR (Interview.InterviewDate >= @InterviewStartDate)) 
		AND (@InterviewFinishDate IS NULL OR (Interview.InterviewDate <= @InterviewFinishDate)) 

	INNER JOIN #tempLanguage ON Person.PersonId = #tempLanguage.PersonId 
		AND	(@LanguageName IS NULL OR (#tempLanguage.LanguageName LIKE '%' + @LanguageName + '%')) 
		AND (@LanguageLevelName IS NULL OR (#tempLanguage.LanguageLevelName LIKE '%' + @LanguageLevelName + '%'))
	
	LEFT JOIN Job ON Person.PersonId = Job.PersonId
		AND (@JobName IS NULL OR (Job.JobName LIKE '%' + @JobName  + '%'))

	INNER JOIN #tempTypeJob ON Person.PersonId = #tempTypeJob.PersonId 
		AND (@TypeJobName IS NULL OR (#tempTypeJob.TypeJobName LIKE '%' + @TypeJobName  + '%'))
	
	INNER JOIN Work_experience ON Person.PersonId = Work_experience.PersonId
		AND (@CompanyName IS NULL OR (Work_experience.CompanyName LIKE '%' + @CompanyName + '%')) 
		AND (@PositionName IS NULL OR (Work_experience.PositionName LIKE '%' + @PositionName + '%')) 

	LEFT JOIN ProfessionalSkill ON Person.PersonId = ProfessionalSkill.PersonId
		AND (@SkillName IS NULL OR (ProfessionalSkill.SkillName LIKE '%' + @SkillName  + '%'))) JoinTable
	ON Person.PersonId = JoinTable.PersonId 
				WHERE	(@PersonId IS NULL OR (Person.PersonId = @PersonId)) AND
						(@FirstName IS NULL OR (Person.FirstName LIKE '%' + @FirstName + '%')) AND
						(@LastName IS NULL OR (Person.LastName LIKE '%' + @LastName + '%')) AND
						(@City IS NULL OR (Person.City LIKE '%' + @City + '%')) AND
						(@Email IS NULL OR (Person.Email LIKE '%' + @Email + '%')) AND
						(@Phone IS NULL OR (Person.Phone LIKE '%' + @Phone + '%')) AND
						(@SalaryStart IS NULL OR (Person.Salary >= @SalaryStart)) AND
						(@SalaryFinish IS NULL OR (Person.Salary <= @SalaryFinish)) AND
						(@WorkExpireanceStart IS NULL OR (Person.WorkExpireance >= @WorkExpireanceStart)) AND
						(@WorkExpireanceFinish IS NULL OR (Person.WorkExpireance <= @WorkExpireanceFinish))AND
						(@ApplicationUserId IS NULL OR (Person.ApplicationUserId LIKE '%' + @ApplicationUserId + '%'))

	) PersonTable
	) TempPerson
	WHERE (row > ((@Page*@Count)-@Count) and row <= @Page*@Count)
	
	SELECT * FROM #tempPersonTable	
			
	SELECT * FROM Education
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM Interview
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM #tempLanguage
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM Job
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM #tempTypeJob
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM Work_experience
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

	SELECT * FROM ProfessionalSkill
	WHERE PersonId IN (SELECT PersonId FROM #tempPersonTable)

END


GO
/****** Object:  StoredProcedure [dbo].[sp_GetProfessionalSkillById]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetProfessionalSkillById]
    @ProfessionalSkillId int 
AS   
BEGIN
      SELECT ProfessionalSkill.ProfessionalSkillId, ProfessionalSkill.PersonId, 
			 ProfessionalSkill.SkillName

      FROM	 dbo.ProfessionalSkill WHERE ProfessionalSkill.ProfessionalSkillId=@ProfessionalSkillId
END









GO
/****** Object:  StoredProcedure [dbo].[sp_GetProfessionalSkills]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetProfessionalSkills]
AS   
BEGIN
      SELECT ProfessionalSkill.ProfessionalSkillId, ProfessionalSkill.PersonId, 
			 ProfessionalSkill.SkillName

      FROM	 dbo.ProfessionalSkill
END









GO
/****** Object:  StoredProcedure [dbo].[sp_GetProfessionalSkillsWhere]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetProfessionalSkillsWhere]
	@PersonId int = null,
	@SkillName varchar(100) = null

AS
BEGIN
      SELECT ProfessionalSkill.ProfessionalSkillId, ProfessionalSkill.PersonId, 
			 ProfessionalSkill.SkillName

      FROM	 dbo.ProfessionalSkill

	  WHERE	 (@PersonId IS NULL OR (ProfessionalSkill.PersonId = @PersonId)) AND
			 (@SkillName IS NULL OR (ProfessionalSkill.SkillName LIKE '%' + @SkillName  + '%'))
END









GO
/****** Object:  StoredProcedure [dbo].[sp_GetTypeJobById]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetTypeJobById]
    @PersonTypeJobId int 
AS   
BEGIN
      SELECT PersonTypeJob.PersonTypeJobId, PersonTypeJob.PersonId,
			 TypeJob.TypeJobName

      FROM	 dbo.PersonTypeJob 

	  INNER JOIN dbo.TypeJob ON PersonTypeJob.TypeJobId = TypeJob.TypeJobId 

	  WHERE PersonTypeJob.PersonTypeJobId=@PersonTypeJobId
END









GO
/****** Object:  StoredProcedure [dbo].[sp_GetTypeJobs]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetTypeJobs]
AS   
BEGIN
      SELECT PersonTypeJob.PersonTypeJobId, PersonTypeJob.PersonId,
			 TypeJob.TypeJobName

      FROM	 dbo.PersonTypeJob 

	  INNER JOIN dbo.TypeJob ON PersonTypeJob.TypeJobId = TypeJob.TypeJobId 
END









GO
/****** Object:  StoredProcedure [dbo].[sp_GetTypeJobsName]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetTypeJobsName]
AS
BEGIN
	SELECT	TypeJob.TypeJobId, TypeJob.TypeJobName

	FROM	TypeJob
END








GO
/****** Object:  StoredProcedure [dbo].[sp_GetTypeJobsNameById]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetTypeJobsNameById] 
@TypeLanguageId int 
AS 
BEGIN 
SELECT TypeJob.TypeJobId, TypeJob.TypeJobName 

FROM dbo.TypeJob 

WHERE @TypeLanguageId=TypeJobId 
END 

GO
/****** Object:  StoredProcedure [dbo].[sp_GetTypeJobsWhere]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetTypeJobsWhere]
	@PersonId int = null,
	@TypeJobName varchar(100) = null

AS
BEGIN
      SELECT PersonTypeJob.PersonTypeJobId, PersonTypeJob.PersonId,
			 TypeJob.TypeJobName

      FROM	 dbo.PersonTypeJob 

	  INNER JOIN dbo.TypeJob ON PersonTypeJob.TypeJobId = TypeJob.TypeJobId 

	  WHERE	 (@PersonId IS NULL OR (PersonTypeJob.PersonId = @PersonId)) AND
			 (@TypeJobName IS NULL OR (TypeJob.TypeJobName LIKE '%' + @TypeJobName  + '%'))
END









GO
/****** Object:  StoredProcedure [dbo].[sp_GetTypeLanguage]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetTypeLanguage]
AS
BEGIN
	SELECT	TypeLanguage.TypeLanguageId, TypeLanguage.LanguageName

	FROM	TypeLanguage
END






GO
/****** Object:  StoredProcedure [dbo].[sp_GetTypeLanguageById]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetTypeLanguageById]
	@TypeLanguageId int
AS   
BEGIN
      SELECT TypeLanguage.TypeLanguageId, TypeLanguage.LanguageName

      FROM	 dbo.TypeLanguage

	  WHERE @TypeLanguageId=TypeLanguageId
END








GO
/****** Object:  StoredProcedure [dbo].[sp_GetWorkExperienceById]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetWorkExperienceById]
			@WorkExperienceId int
AS
BEGIN
	SELECT	Work_experience.WorkExperienceId,Work_experience.PersonId, 
			Work_experience.PositionName, Work_experience.CompanyName,
			Work_experience.StartDate, Work_experience.FinishDate

	FROM	Work_experience

	WHERE	Work_experience.WorkExperienceId = @WorkExperienceId
END







GO
/****** Object:  StoredProcedure [dbo].[sp_GetWorkExperiences]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetWorkExperiences]
AS
BEGIN
	SELECT	Work_experience.WorkExperienceId,Work_experience.PersonId, 
			Work_experience.PositionName, Work_experience.CompanyName,
			Work_experience.StartDate, Work_experience.FinishDate

	FROM	Work_experience
END









GO
/****** Object:  StoredProcedure [dbo].[sp_GetWorkExperiencesWhere]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetWorkExperiencesWhere]
			@PersonId int = null,
			@CompanyName varchar(100) = null,
			@PositionName varchar(100) = null
AS
BEGIN
	SELECT	Work_experience.WorkExperienceId,Work_experience.PersonId, 
			Work_experience.PositionName, Work_experience.CompanyName,
			Work_experience.StartDate, Work_experience.FinishDate

	FROM	Work_experience

	WHERE	(@PersonId IS NULL OR (Work_experience.PersonId = @PersonId)) AND
			(@CompanyName IS NULL OR (Work_experience.CompanyName LIKE '%' + @CompanyName + '%')) AND
			(@PositionName IS NULL OR (Work_experience.PositionName LIKE '%' + @PositionName + '%'))
END



GO
/****** Object:  StoredProcedure [dbo].[sp_SOme]    Script Date: 6/8/2018 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SOme]
AS
BEGIN
	 SELECT * INTO #tmpSortedBooks FROM Person
	Select * FROM Education
	SELECT * from #tmpSortedBooks
	
END
--execute sp_SOme

GO
