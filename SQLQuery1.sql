CREATE TABLE [Category]([Id] int identity primary key,	[Name] nvarchar(100) not null);

CREATE TABLE [TypeBalanceChange]([Id] int identity primary key,	[Name] nvarchar(100) not null);

INSERT INTO TypeBalanceChange ([Name]) VALUES (N'Доход'), (N'Расход');

CREATE TABLE [Transactions]([Id] int identity primary key,	[Name] nvarchar(100) not null,	[Description] nvarchar(100) not null,	[Date] date not null,	[Amount of money] int not null,	[CategoryId] int not null,	constraint [CategoryID_FK] foreign key([CategoryId]) references [Category]([Id]),	[TypeBalanceChangeId] int not null,	constraint [TypeBalanceChangeId] foreign key([TypeBalanceChangeId]) references [TypeBalanceChange]([Id]));