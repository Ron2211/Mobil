USE [master]
GO
/****** Object:  Database [Mobil]    Script Date: 18/06/2021 3:19:57 PM ******/
CREATE DATABASE [Mobil]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Mobil', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Mobil.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Mobil_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Mobil_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Mobil] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Mobil].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Mobil] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Mobil] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Mobil] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Mobil] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Mobil] SET ARITHABORT OFF 
GO
ALTER DATABASE [Mobil] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Mobil] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Mobil] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Mobil] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Mobil] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Mobil] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Mobil] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Mobil] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Mobil] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Mobil] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Mobil] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Mobil] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Mobil] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Mobil] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Mobil] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Mobil] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Mobil] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Mobil] SET RECOVERY FULL 
GO
ALTER DATABASE [Mobil] SET  MULTI_USER 
GO
ALTER DATABASE [Mobil] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Mobil] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Mobil] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Mobil] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Mobil] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Mobil] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Mobil', N'ON'
GO
ALTER DATABASE [Mobil] SET QUERY_STORE = OFF
GO
USE [Mobil]
GO
/****** Object:  Table [dbo].[tbl_DailySheet]    Script Date: 18/06/2021 3:19:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_DailySheet](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[D_ID] [bigint] NULL,
	[Name] [varchar](50) NULL,
	[Date] [date] NULL,
	[Time] [datetime] NULL,
	[Day] [varchar](50) NULL,
	[Tank_one_dip] [decimal](18, 2) NULL,
	[Tank_two_dip] [decimal](18, 2) NULL,
	[Tank_three_dip] [decimal](18, 2) NULL,
	[Tank_four_dip] [decimal](18, 2) NULL,
	[Tank_five_dip] [decimal](18, 2) NULL,
	[Tank_six_dip] [decimal](18, 2) NULL,
	[TF_price_e10] [decimal](4, 3) NULL,
	[TF_price_91] [decimal](4, 3) NULL,
	[TF_price_98] [decimal](4, 3) NULL,
	[TF_price_Diesel] [decimal](4, 3) NULL,
	[TLS_e10] [decimal](18, 2) NULL,
	[TLS_91] [decimal](18, 2) NULL,
	[TLS_98] [decimal](18, 2) NULL,
	[TLS_Diesel] [decimal](18, 2) NULL,
	[TD_e10] [decimal](18, 2) NULL,
	[TD_91] [decimal](18, 2) NULL,
	[TD_98] [decimal](18, 2) NULL,
	[TD_Diesel] [decimal](18, 2) NULL,
	[TLS_Total] [decimal](18, 2) NULL,
	[TD_Total] [decimal](18, 2) NULL,
	[HotFood] [decimal](18, 2) NULL,
	[Pai] [decimal](18, 2) NULL,
	[ColdFood] [decimal](18, 2) NULL,
	[Coffee] [decimal](18, 2) NULL,
	[TotalHotFood] [decimal](18, 2) NOT NULL,
	[Total_efpost] [decimal](18, 2) NOT NULL,
	[E_efpost] [decimal](18, 2) NULL,
	[MotorPass] [decimal](18, 2) NULL,
	[MotorCharge] [decimal](18, 2) NULL,
	[FleetCard] [decimal](18, 2) NULL,
	[SafeDrop] [decimal](18, 2) NOT NULL,
	[CashPaidout] [decimal](18, 2) NULL,
	[Accounts] [decimal](18, 2) NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[TotalSale] [decimal](18, 2) NOT NULL,
	[Shopsale] [decimal](18, 2) NOT NULL,
	[Cigartte] [decimal](18, 2) NULL,
	[E_pay] [decimal](18, 2) NULL,
	[Refund] [decimal](18, 2) NULL,
	[MISC] [decimal](18, 2) NULL,
	[ATMFilled] [decimal](18, 2) NULL,
	[Diffrence] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_tbl_DailySheet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Delivery_Fuel]    Script Date: 18/06/2021 3:19:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Delivery_Fuel](
	[D_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Tank1_98] [decimal](18, 2) NULL,
	[Tank2_Diesel] [decimal](18, 2) NULL,
	[Tank3_E10] [decimal](18, 2) NULL,
	[Tank4_E10] [decimal](18, 2) NULL,
	[Tank5_91] [decimal](18, 2) NULL,
	[Tank6_91] [decimal](18, 2) NULL,
 CONSTRAINT [PK_tbl_Delivery_Fuel] PRIMARY KEY CLUSTERED 
(
	[D_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_User]    Script Date: 18/06/2021 3:19:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_User](
	[UID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserTypeID] [bigint] NULL,
	[UName] [varchar](50) NULL,
	[UPass] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[MobileNo] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_User] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_UserType]    Script Date: 18/06/2021 3:19:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_UserType](
	[UserTypeID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserType] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_UserType] PRIMARY KEY CLUSTERED 
(
	[UserTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_DailySheet]  WITH CHECK ADD  CONSTRAINT [FK_tbl_DailySheet_tbl_Delivery_Fuel] FOREIGN KEY([D_ID])
REFERENCES [dbo].[tbl_Delivery_Fuel] ([D_ID])
GO
ALTER TABLE [dbo].[tbl_DailySheet] CHECK CONSTRAINT [FK_tbl_DailySheet_tbl_Delivery_Fuel]
GO
ALTER TABLE [dbo].[tbl_User]  WITH CHECK ADD  CONSTRAINT [FK_tbl_User_tbl_UserType] FOREIGN KEY([UserTypeID])
REFERENCES [dbo].[tbl_UserType] ([UserTypeID])
GO
ALTER TABLE [dbo].[tbl_User] CHECK CONSTRAINT [FK_tbl_User_tbl_UserType]
GO
/****** Object:  StoredProcedure [dbo].[sp_CheckDateTimeDailySheet]    Script Date: 18/06/2021 3:19:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_CheckDateTimeDailySheet]
@Date Date
	AS
BEGIN
Select * from tbl_DailySheet where Date=@Date ;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_DailySheet]    Script Date: 18/06/2021 3:19:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_DailySheet]
@Name Varchar(50),
@Date Date,
@Time Datetime,
@Day Varchar(50),
@Tank_one_dip decimal(18,2),
@Tank_two_dip decimal(18,2),
@Tank_three_dip decimal(18,2),
@Tank_four_dip decimal(18,2),
@Tank_five_dip decimal(18,2),
@Tank_six_dip decimal(18,2),
@TF_price_e10 decimal(4,3),
@TF_price_91 decimal(4,3),
@TF_price_98 decimal(4,3),
@TF_price_Diesel decimal(4,3),
@TLS_e10 decimal(18,2),
@TLS_91 decimal(18,2),
@TLS_98 decimal(18,2),
@TLS_Diesel decimal(18,2),
@TD_e10 decimal(18,2),
@TD_91 decimal(18,2),
@TD_98 decimal(18,2),
@TD_Diesel decimal(18,2),
@TLS_Total decimal(18,2),
@TD_Total decimal(18,2),
@HotFood decimal(18,2),
@Pai decimal(18,2),
@ColdFood decimal(18,2),
@Coffee decimal(18,2),
@TotalHotFood decimal(18,2),
@Total_efpost decimal(18,2),
@E_efpost decimal(18,2),
@MotorPass decimal(18,2),
@MotorCharge decimal(18,2),
@FleetCard decimal(18,2),
@SafeDrop decimal(18,2),
@CashPaidout decimal(18,2),
@Accounts decimal(18,2),
@Total decimal(18,2),
@TotalSale decimal(18,2),
@Shopsale decimal(18,2),
@Cigartte decimal(18,2),
@E_Pay decimal(18,2),
@Refund decimal(18,2),
@MISC decimal(18,2),
@ATMFilled decimal(18,2),
@Diffrence decimal(18,2)

AS
BEGIN
	INSERT INTO tbl_DailySheet(Name,Date,Time,Day,Tank_one_dip,Tank_two_dip,Tank_three_dip,Tank_four_dip,Tank_five_dip,Tank_six_dip,
	TF_price_e10,TF_price_91,TF_price_98,TF_price_Diesel,TLS_e10,TLS_91,TLS_98,TLS_Diesel,TD_e10,TD_91,TD_98,TD_Diesel,
	TLS_Total,TD_Total, HotFood,Pai,ColdFood,Coffee,TotalHotFood,Total_efpost,E_efpost,MotorPass,MotorCharge,FleetCard,SafeDrop,CashPaidout,
	Accounts,Total,TotalSale,Shopsale,Cigartte,E_pay,Refund,MISC,ATMFilled,Diffrence) VALUES (@Name,@Date,@Time,@Day,@Tank_one_dip,
	@Tank_two_dip,@Tank_three_dip,@Tank_four_dip,@Tank_five_dip,@Tank_six_dip,
	@TF_price_e10,@TF_price_91,@TF_price_98,@TF_price_Diesel,@TLS_e10,@TLS_91,@TLS_98,@TLS_Diesel,@TD_e10,@TD_91,@TD_98,@TD_Diesel,
	@TLS_Total,@TD_Total,@HotFood,@Pai,@ColdFood,@Coffee,@TotalHotFood,@Total_efpost,@E_efpost,@MotorPass,@MotorCharge,@FleetCard,@SafeDrop,@CashPaidout,
	@Accounts,@Total,@TotalSale,@Shopsale,@Cigartte,@E_Pay,@Refund,@MISC,@ATMFilled,@Diffrence);
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllDataDailySheet]    Script Date: 18/06/2021 3:19:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAllDataDailySheet]
AS
BEGIN
	SELECT * FROM tbl_DailySheet
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDailySheetRecordByID_Get]    Script Date: 18/06/2021 3:19:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetDailySheetRecordByID_Get]
@ID bigint
AS
BEGIN
	select * from tbl_DailySheet where ID=@ID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UserLogin_get]    Script Date: 18/06/2021 3:19:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UserLogin_get]
	@UName nvarchar(50),
	@UPass nvarchar(50)
AS
BEGIN
	SELECT UID, UName, UserTypeID FROM tbl_User WHERE UName = @UName AND UPass = @UPass
END
GO
/****** Object:  StoredProcedure [dbo].[usp_CheckDailySheetExistsWhileUpdate_GetByDate]    Script Date: 18/06/2021 3:19:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_CheckDailySheetExistsWhileUpdate_GetByDate]
	@Date Date,
	@ID BIGINT
AS
BEGIN
	SELECT * FROM tbl_DailySheet WHERE Date = @Date AND ID <> @ID
END
GO
USE [master]
GO
ALTER DATABASE [Mobil] SET  READ_WRITE 
GO
