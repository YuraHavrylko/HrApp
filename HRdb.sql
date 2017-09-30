USE [master]
GO
/****** Object:  Database [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF]    Script Date: 07.04.2017 13:36:34 ******/
CREATE DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HRDataBase', FILENAME = N'C:\intership\HRui\HrApp\App_Data\HRDataBase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HRDataBase_log', FILENAME = N'C:\intership\HRui\HrApp\App_Data\HRDataBase_log.ldf' , SIZE = 2304KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET ARITHABORT OFF 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET  ENABLE_BROKER 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET  MULTI_USER 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET DB_CHAINING OFF 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET QUERY_STORE = OFF
GO
USE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF]
GO
/****** Object:  Table [dbo].[Education]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  Table [dbo].[Interview]    Script Date: 07.04.2017 13:36:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Interview](
	[InterviewId] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NULL,
	[InterviewDate] [date] NULL,
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
/****** Object:  Table [dbo].[Job]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  Table [dbo].[Knowledge_of_language]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  Table [dbo].[Language_level]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  Table [dbo].[Person]    Script Date: 07.04.2017 13:36:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[Birthday] [date] NULL,
	[City] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Phone] [varchar](20) NULL,
	[Salary] [int] NULL,
	[WorkExpireance] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PersonTypeJob]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  Table [dbo].[ProfessionalSkill]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  Table [dbo].[TypeJob]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  Table [dbo].[TypeLanguage]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  Table [dbo].[Work_experience]    Script Date: 07.04.2017 13:36:34 ******/
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
ALTER TABLE [dbo].[Education]  WITH CHECK ADD FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Interview]  WITH CHECK ADD FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Knowledge_of_language]  WITH CHECK ADD FOREIGN KEY([LanguageLevelId])
REFERENCES [dbo].[Language_level] ([LanguageLevelId])
GO
ALTER TABLE [dbo].[Knowledge_of_language]  WITH CHECK ADD FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Knowledge_of_language]  WITH CHECK ADD FOREIGN KEY([TypeLanguageId])
REFERENCES [dbo].[TypeLanguage] ([TypeLanguageId])
GO
ALTER TABLE [dbo].[PersonTypeJob]  WITH CHECK ADD FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[PersonTypeJob]  WITH CHECK ADD FOREIGN KEY([TypeJobId])
REFERENCES [dbo].[TypeJob] ([TypeJobId])
GO
ALTER TABLE [dbo].[ProfessionalSkill]  WITH CHECK ADD FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Work_experience]  WITH CHECK ADD FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
/****** Object:  StoredProcedure [dbo].[sp_AddInterview]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_AddJob]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_AddLanguage]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_AddProfessionalSkill]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_AddTypeJob]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_AddWorkExperience]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetCountPersonsWhere]    Script Date: 07.04.2017 13:36:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetCountPersonsWhere]
			@PersonId int = null,
			@FirstName varchar(100) = null,
			@LastName varchar(100) = null,
			@City varchar(100) = null
AS
BEGIN
	SELECT	COUNT(*)

	FROM	Person

	WHERE	(@PersonId IS NULL OR (Person.PersonId = @PersonId)) AND
			(@FirstName IS NULL OR (Person.FirstName LIKE '%' + @FirstName + '%')) AND
			(@LastName IS NULL OR (Person.LastName LIKE '%' + @LastName + '%')) AND
			(@City IS NULL OR (Person.City LIKE '%' + @City + '%'))
END



GO
/****** Object:  StoredProcedure [dbo].[sp_GetEducationById]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetEducations]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetEducationsWhere]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetInterviewById]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetInterviews]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetInterviewsWhere]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetJobById]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetJobs]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetJobsWhere]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetLanguageById]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetLanguages]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetLanguagesWhere]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetPersonById]    Script Date: 07.04.2017 13:36:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPersonById]
			@PersonId int
AS
BEGIN
	SELECT	Person.PersonId, Person.FirstName, 
			Person.LastName, Person.Birthday, 
			Person.City, Person.Email, Person.Phone,
			Person.Salary, Person.WorkExpireance 

	FROM	Person

	WHERE	Person.PersonId = @PersonId
END



GO
/****** Object:  StoredProcedure [dbo].[sp_GetPersons]    Script Date: 07.04.2017 13:36:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPersons]
AS
BEGIN
	SELECT	Person.PersonId, Person.Email, Person.FirstName, 
			Person.LastName, Person.Phone, Person.Salary, 
			Person.Birthday, Person.City,Person.WorkExpireance 

	FROM	Person
END



GO
/****** Object:  StoredProcedure [dbo].[sp_GetPersonsWhere]    Script Date: 07.04.2017 13:36:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPersonsWhere]
			@PersonId int = null,
			@FirstName varchar(100) = null,
			@LastName varchar(100) = null,
			@City varchar(100) = null,
			@Page int = 1,
			@Count int = 10
AS
BEGIN
	SELECT	Person.PersonId, Person.Email, Person.FirstName, 
			Person.LastName, Person.Phone, Person.Salary, 
			Person.Birthday, Person.City,Person.WorkExpireance 

	FROM	(SELECT *, ROW_NUMBER() OVER (ORDER BY Person.PersonId) as row FROM Person) Person

	WHERE	(@PersonId IS NULL OR (Person.PersonId = @PersonId)) AND
			(@FirstName IS NULL OR (Person.FirstName LIKE '%' + @FirstName + '%')) AND
			(@LastName IS NULL OR (Person.LastName LIKE '%' + @LastName + '%')) AND
			(@City IS NULL OR (Person.City LIKE '%' + @City + '%')) AND
			(row > ((@Page*@Count)-@Count) and row <= @Page*@Count)
END



GO
/****** Object:  StoredProcedure [dbo].[sp_GetProfessionalSkillById]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetProfessionalSkills]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetProfessionalSkillsWhere]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetTypeJobById]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetTypeJobs]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetTypeJobsWhere]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetWorkExperienceById]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetWorkExperiences]    Script Date: 07.04.2017 13:36:34 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetWorkExperiencesWhere]    Script Date: 07.04.2017 13:36:34 ******/
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
USE [master]
GO
ALTER DATABASE [C:\intership\HRui\HrApp\App_Data\HRDATABASE.MDF] SET  READ_WRITE 
GO
