-- 비디오 테이블
CREATE TABLE [dbo].[Videos]
(
	[Id] Int Not Null Identity(1, 1) Primary Key,
	[Created] DateTimeOffset(7) 
		Default(SysDateTimeOffset() AT TIME ZONE 'Korea Standard Time'),

	[Title] NVarChar(255) Not Null,			-- 제목
	[Url] NVarChar(Max) Null,				-- URL

	[Name] NVarChar(50) Null,				-- 이름
	[Company] NVarChar(255) Null,			-- 회사
)
Go
