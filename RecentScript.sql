USE [master]
GO
/****** Object:  Database [UniversityApplicationDatabase]    Script Date: 09-May-16 7:26:13 AM ******/
CREATE DATABASE [UniversityApplicationDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniversityApplicationDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS2\MSSQL\DATA\UniversityApplicationDatabase.mdf' , SIZE = 7232KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UniversityApplicationDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS2\MSSQL\DATA\UniversityApplicationDatabase_log.ldf' , SIZE = 1088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UniversityApplicationDatabase] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversityApplicationDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversityApplicationDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversityApplicationDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversityApplicationDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversityApplicationDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversityApplicationDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversityApplicationDatabase] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [UniversityApplicationDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversityApplicationDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityApplicationDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversityApplicationDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversityApplicationDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversityApplicationDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversityApplicationDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversityApplicationDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversityApplicationDatabase] SET  ENABLE_BROKER 
GO
ALTER DATABASE [UniversityApplicationDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversityApplicationDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversityApplicationDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversityApplicationDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversityApplicationDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversityApplicationDatabase] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [UniversityApplicationDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversityApplicationDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UniversityApplicationDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [UniversityApplicationDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversityApplicationDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversityApplicationDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversityApplicationDatabase] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [UniversityApplicationDatabase]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 09-May-16 7:26:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Classrooms]    Script Date: 09-May-16 7:26:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classrooms](
	[ClassRoomRoomNo] [nvarchar](max) NOT NULL,
	[ClassRoomDepartmentCode] [nvarchar](max) NOT NULL,
	[ClassRoomCourseCode] [nvarchar](max) NOT NULL,
	[ClassRoomWeekDay] [nvarchar](max) NOT NULL,
	[ClassRoomStartsAt] [time](7) NOT NULL,
	[ClassRoomEndssAt] [time](7) NOT NULL,
	[ClassroomId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_dbo.Classrooms] PRIMARY KEY CLUSTERED 
(
	[ClassroomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Courses]    Script Date: 09-May-16 7:26:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseCode] [nvarchar](50) NOT NULL,
	[CourseName] [nvarchar](max) NOT NULL,
	[CourseCredit] [float] NOT NULL,
	[CourseDescription] [nvarchar](max) NULL,
	[CourseDepartmentCode] [nvarchar](max) NOT NULL,
	[CourseSemester] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Courses] PRIMARY KEY CLUSTERED 
(
	[CourseCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CourseStudents]    Script Date: 09-May-16 7:26:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseStudents](
	[CourseStudentID] [int] IDENTITY(1,1) NOT NULL,
	[CourseStudentRegNo] [nvarchar](max) NOT NULL,
	[CourseStudentCourse] [nvarchar](max) NOT NULL,
	[CourseStudentRegDate] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.CourseStudents] PRIMARY KEY CLUSTERED 
(
	[CourseStudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CourseTeachers]    Script Date: 09-May-16 7:26:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseTeachers](
	[CourseTeacherID] [int] IDENTITY(1,1) NOT NULL,
	[CourseTeacherDepartmentCode] [nvarchar](max) NULL,
	[CourseTeacherEmail] [nvarchar](max) NULL,
	[CourseTeacherCourseCode] [nvarchar](max) NULL,
	[CourseTeacherCourseCredit] [float] NULL,
	[CourseTeacherTeacherName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.CourseTeachers] PRIMARY KEY CLUSTERED 
(
	[CourseTeacherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 09-May-16 7:26:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentCode] [nvarchar](7) NOT NULL,
	[DepartmentName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Designations]    Script Date: 09-May-16 7:26:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designations](
	[Designation] [nchar](100) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Results]    Script Date: 09-May-16 7:26:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Results](
	[Grade] [nchar](10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 09-May-16 7:26:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[RoomNo] [nchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Semester]    Script Date: 09-May-16 7:26:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semester](
	[Semester] [nchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentResults]    Script Date: 09-May-16 7:26:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentResults](
	[StudentResultRegNo] [nvarchar](max) NOT NULL,
	[StudentResultCourse] [nvarchar](max) NOT NULL,
	[StudentResultGrade] [nvarchar](max) NOT NULL,
	[StudentResultId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_dbo.StudentResults] PRIMARY KEY CLUSTERED 
(
	[StudentResultId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 09-May-16 7:26:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentRegNo] [nvarchar](128) NOT NULL,
	[StudentName] [nvarchar](max) NOT NULL,
	[StudentContact] [nvarchar](max) NOT NULL,
	[StudentAddress] [nvarchar](max) NOT NULL,
	[StudentDepartmentCode] [nvarchar](max) NOT NULL,
	[StudentEmail] [nvarchar](max) NOT NULL,
	[StudeRegDate] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Students] PRIMARY KEY CLUSTERED 
(
	[StudentRegNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 09-May-16 7:26:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[TeacherEmail] [nvarchar](128) NOT NULL,
	[TeacherDesignation] [nvarchar](max) NOT NULL,
	[TeacherCredit] [float] NOT NULL,
	[TeacherName] [nvarchar](max) NOT NULL,
	[TeacherContact] [nvarchar](max) NOT NULL,
	[TeacherAddress] [nvarchar](max) NOT NULL,
	[TeacherDepartmentCode] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Teachers] PRIMARY KEY CLUSTERED 
(
	[TeacherEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [UniversityApplicationDatabase] SET  READ_WRITE 
GO
