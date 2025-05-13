use db_fourc
--users Tables
CREATE SCHEMA Users;
go
create table Users.TB_UsersType(
userType_ID int primary key  identity (1,1),
userType_Name nvarchar(10) not null);

go



create table Users.TB_Users(
users_ID int identity (1001,1) primary key,
user_NameAr nvarchar(50) not null unique ,
user_NameEn nvarchar(50) not null unique,
user_userName nvarchar(20) not null unique,
user_password nvarchar(255) not null,
userType_ID int default 1,
user_IsActive bit default 1

constraint fk_users_Type foreign key (userType_ID) References Users.TB_UsersType (userType_ID)
on update cascade

);
go


create table Users.TB_UsersPermissionType(
userperType_ID int primary key identity (1,1),
userperType_Name nvarchar (100) not null unique
);
go


create table Users.TB_UsersPermission(
userper_ID int primary key identity(1,1) ,
users_ID int not null,
userperType_ID int not null,
userPer_ISActive bit default 0

constraint fk_users foreign key (users_ID) References Users.TB_Users (users_ID)
on update cascade,
constraint fk_userspermissiontype foreign key (userperType_ID) References Users.TB_UsersPermissionType (userperType_ID)
on update cascade
);
 go


 -- users table End 
 -- User Permission Data

insert into Users.TB_UsersPermissionType values ('اداره المستخدمين');-- الدخول علي صفحه المستخدمين فقط لتغيير كلمه السر
go
insert into users.TB_UsersPermissionType values('اضافه المستخدمين'); -- وuser اضافه مستخدمين بصلاحيات افتراضيه فقط
go
insert into users.TB_UsersPermissionType values('صلاحيات المستخدمين');-- التحكم في صلاحيات كل المستخدمين
go
insert into users.TB_UsersPermissionType values('اضافه الاصناف');-- اضافه صنف جديد
go
insert into users.TB_UsersPermissionType values('تعديل الاصناف');-- تعديل صنف قديم 
go
insert into users.TB_UsersPermissionType values('حذف الاصناف');-- حذف صنف قديم 
go
insert into users.TB_UsersPermissionType values('اضافه فواتير مشتريات');-- اضافه فواتير مشتريات 
go
insert into users.TB_UsersPermissionType values('تعديل فواتير المشتريات');-- تعديل فواتير المشتريات 
go
insert into users.TB_UsersPermissionType values('حذف فواتير المشتريات');
go
insert into users.TB_UsersPermissionType values('اضافه فواتير مبيعات');
go
insert into users.TB_UsersPermissionType values('تعديل فواتير المبيعات');
go
insert into users.TB_UsersPermissionType values('حذف فواتير المبيعات');
go
insert into users.TB_UsersPermissionType values('اضافه سندات تحويلات');
go
insert into users.TB_UsersPermissionType values('تعديل سندات تحويلات');
go
insert into users.TB_UsersPermissionType values('حذف سندات تحويلات');
go
insert into users.TB_UsersPermissionType values('اضافه سندات اهلاك');
go
insert into users.TB_UsersPermissionType values('تعديل سندات اهلاك');
go
insert into users.TB_UsersPermissionType values('حذف سندات اهلاك');
go
insert into users.TB_UsersPermissionType values('اضافه سندات مصروفات');
go
insert into users.TB_UsersPermissionType values('تعديل سندات مصروفات');
go
insert into users.TB_UsersPermissionType values('حذف سندات مصروفات');
go
insert into users.TB_UsersPermissionType values('اضافه عملاء');
go
insert into users.TB_UsersPermissionType values('تعديل عملاء');
go
insert into users.TB_UsersPermissionType values('حذف عملاء');
go
insert into users.TB_UsersPermissionType values('عرض كشوفات حساب العملاء');
go
insert into users.TB_UsersPermissionType values('اضافه موردين');
go
insert into users.TB_UsersPermissionType values('تعديل موردين');
go
insert into users.TB_UsersPermissionType values('حذف موردين');
go
insert into users.TB_UsersPermissionType values('عرض كشوفات حساب الموردين');
go
insert into users.TB_UsersPermissionType values('عرض تقارير المشتريات');
go
insert into users.TB_UsersPermissionType values('عرض تقارير المبيعات');
go
insert into users.TB_UsersPermissionType values('عرض تقارير التحويلات');
go
insert into users.TB_UsersPermissionType values('عرض تقارير الاهلاكات');
go


-- create items tables
create schema Items;
go

create table Items.TB_CategoryOne(
CategoryOne_ID int identity(1,1) primary key ,
CategoryOne_Name nvarchar(100) unique);

create table Items.TB_CategoryTwo(
CategoryTwo_ID int identity(1,1) primary key,
CategoryTwo_Name nvarchar(100) unique);

create table Items.TB_CategoryThree(
CategoryThree_ID int identity(1,1) primary key,
CategoryThree_Name nvarchar(100) unique);

create table Items.TB_CategoryFour(
CategoryFour_ID int identity(1,1) primary key,
CategoryFour_Name nvarchar(100) unique);

create table Items.TB_Unit(
Unit_ID int identity (1,1) primary key,
Unit_Name nvarchar (10) unique);

go
insert into Items.TB_Unit values ('حبه')
go

create table Items.TB_Items(
Items_ID int identity(1,1) primary key , 
Items_Code nvarchar(20) unique,
Items_NameAR nvarchar(200) unique,
Items_NameEn nvarchar(200) unique,
Unit_ID int,
Items_pricesale decimal(18,3),
CategoryOne_ID int,
CategoryTwo_ID int,
CategoryThree_ID int,
CategoryFour_ID int,
Items_Cost decimal(10,4)default 0,
Items_QtyBalance int default 0
constraint Fk_TB_Unit foreign key (Unit_ID) References Items.TB_Unit(Unit_ID) on update cascade,
constraint Fk_TB_CategoryOne foreign key (CategoryOne_ID) References Items.TB_CategoryOne(CategoryOne_ID) on update cascade,
constraint Fk_TB_CategoryTwo foreign key (CategoryTwo_ID) References Items.TB_CategoryTwo(CategoryTwo_ID) on update cascade,
constraint Fk_TB_CategoryThree foreign key (CategoryThree_ID) References Items.TB_CategoryThree(CategoryThree_ID) on update cascade,
constraint Fk_TB_CategoryFour foreign key (CategoryFour_ID) References Items.TB_CategoryFour(CategoryFour_ID) on update cascade,);
go


create table Items.Tb_ItemMove(
ItemMove_ID int primary key identity(1,1),
Items_ID int,
Department_ID int,
Funtion_ID int,
ItemMove_Cost decimal(10,4) null,
ItemMove_Qty int default 0,
Invoice_ID int null ,
constraint FK_tb_items foreign key (Items_ID) References items.TB_Items(Items_ID),
constraint Fk_tb_Department foreign key (Department_ID) References Stores.TB_Departments(Department_ID) ,
constraint Fk_tb_AccFunction foreign key (Funtion_ID) References Accounts.AccountFunctionCode(AccountFun_Code)on update cascade
);

-- suppliers and customers and accounts tables

create schema personal;
go 
create schema Accounts;
go

create table personal.TB_Country(
country_ID int primary key identity(1,1),
Country_Name nvarchar(10) unique,
Country_PhoneKey nvarchar(5) unique);

go

insert into personal.TB_Country values('مصر','+20')
go
insert into personal.TB_Country values('السعودية','+966')
go
insert into personal.TB_Country values('الإمارات','+971')
go
insert into personal.TB_Country values('الكويت','+965')
go
insert into personal.TB_Country values('قطر','+974')
go
insert into personal.TB_Country values('البحرين','+973')
go
insert into personal.TB_Country values('عمان','+968')
go
insert into personal.TB_Country values('لبنان','+961')
go
insert into personal.TB_Country values('الأردن','+962')
go
insert into personal.TB_Country values('العراق','+964')
go
insert into personal.TB_Country values('سوريا','+963')
go
insert into personal.TB_Country values('ليبيا','+218')
go
insert into personal.TB_Country values('السودان','+249')
go
insert into personal.TB_Country values('الجزائر','+213')
go
insert into personal.TB_Country values('المغرب','+212')
go
insert into personal.TB_Country values('تونس','+216')
go
insert into personal.TB_Country values('اليمن','+967')
go
insert into personal.TB_Country values('فرنسا','+33')
go
insert into personal.TB_Country values('ألمانيا','+49')
go
insert into personal.TB_Country values('كندا','+1')
go
insert into personal.TB_Country values('تركيا','+90')
go
insert into personal.TB_Country values('الهند','+91')
go
insert into personal.TB_Country values('الصين','+86')
go
insert into personal.TB_Country values('روسيا','+7')
go


create table Accounts.TB_AccountsGeneral(
AccountGen_ID int primary key identity (100000,1001),
AccountGen_NameAr nvarchar(50) unique not null,
);
go

create table personal.TB_Suppliers(
supplier_ID int primary key identity(220000,1),
supplier_Name nvarchar(150) unique,
country_ID int not null,
supplier_phone nvarchar(15) unique not null,
supplier_fax nvarchar(15) unique ,
supplier_Email nvarchar(50)unique ,
supplier_Address nvarchar(100) ,
supplier_ISActive bit default 1
constraint Fk_TB_Country_Supplier foreign key (country_ID) References  personal.TB_Country(country_ID)on update cascade
);
go

create table personal.TB_Customers(
Customer_ID int primary key identity(550000,1),
Customer_Name nvarchar(150) unique,
country_ID int not null,
Customer_phone nvarchar(15) unique not null,
Customer_fax nvarchar(15) unique ,
Customer_Email nvarchar(50)unique ,
Customer_Address nvarchar(100) ,
Customer_ISActive bit default 1
constraint Fk_TB_Country_Customer foreign key (country_ID) References  personal.TB_Country(country_ID)on update cascade);

go
create table Accounts.TB_AccountsSub(
AccountSub_ID int primary key identity(1,1),
AccountSub_Code int not null unique ,
AccountGen_ID int not null ,
AccountSub_Name nvarchar(150) not null unique,
AccountSub_ISActive bit default 1 
constraint FK_TB_AccountsGeneral foreign key (AccountGen_ID)References Accounts.TB_AccountsGeneral(AccountGen_ID)

go

-- جدول خاص بالقيود التلقائيه
create table Accounts.AccountFunction(
AccFunction_ID int primary key identity (1,1),
AccFunction_Depit Decimal (18,3) not null,
AccFunction_Credit Decimal (18,3) not null,
AccFunction_Note nvarchar(500) not null ,
AccFunction_Code int not null ,
AccountSub_Code int not null ,
AccFunction_Date date NOT NULL

constraint FK_TB_AccountsSub foreign key (AccountSub_Code) References Accounts.TB_AccountsSub (AccountSub_Code) on update cascade
);

go
-- الحسابات الاساسيه
insert into Accounts.TB_AccountsGeneral values ('مخازن ومعارض');
go
insert into Accounts.TB_AccountsGeneral values ('الموردين');
go
insert into Accounts.TB_AccountsGeneral values ('المصروفات');
go
insert into Accounts.TB_AccountsGeneral values ('قسم المحاسبه');
go
insert into Accounts.TB_AccountsGeneral values ('العملاء');
go 
insert into Accounts.TB_AccountsGeneral values ('المبيعات');
go 
insert into Accounts.TB_AccountsSub values(660001,(select AccountGen_ID from Accounts.TB_AccountsGeneral where AccountGen_NameAr= 'المبيعات') ,'المبيعات',1)
go
insert into Accounts.TB_AccountsSub values(1020021,(select AccountGen_ID from Accounts.TB_AccountsGeneral where AccountGen_NameAr= 'المصروفات') ,'تكلفه المبيعات',1)
go


--stores and departments tabls

create schema Stores;
go

create table Stores.TB_Stores(
Store_ID int identity(100000,1) primary key,
Store_Name nvarchar(30) unique not null,
Store_Location nvarchar (30) not null,
store_IsActive bit default 1 );
go


create table Stores.TB_Departments(
Department_ID int identity(1,1) primary key,
Department_Name nvarchar(20) not null unique,
Department_Note nvarchar(30) , 
Store_ID int
constraint FK_TB_Stores foreign key (Store_ID) References Stores.TB_Stores(Store_ID) on update cascade ) ;
go

alter table Accounts.TB_AccountsSub
add constraint FK_TB_Stores_AccountsSub foreign key (AccountSub_Code) References Stores.TB_Stores(Store_ID);
go

-- payment table


create table Accounts.AccountFunctionCode(
AccountFun_ID int primary key identity(1,1),
AccountFun_Code int  unique not null);
go



create table Accounts.TB_payments(
payment_ID int identity(1,1) primary key ,
payment_Date date not null ,
payment_invoiceNo nvarchar(10) unique not null,
AccountSub_Code int not null ,
Department_ID int null,
Store_IDs int null,
payment_Amount decimal(18,3) not null,
payment_Note nvarchar(500) not null ,
AccFunction_Code int not null,

constraint FK_TB_AccountsSub_payments foreign key (AccountSub_Code) References Accounts.TB_AccountsSub (AccountSub_Code) on update cascade,
constraint FK_TB_Departments foreign key (Department_ID) References Stores.TB_Departments(Department_ID) on update cascade,
constraint Fk_StoreID_tb_payment foreign key (Store_IDs) References Stores.Tb_Stores(Store_ID) ,
constraint Fk_AccountFunction foreign key (AccFunction_Code) References Accounts.AccountFunctionCode(AccountFun_Code) on update cascade

);
go

alter table [Accounts].[TB_payments]
 
add constraint Fk_AccountFunction foreign key (AccFunction_Code) References Accounts.AccountFunctionCode(AccountFun_Code) on update cascade
go

alter table Accounts.AccountFunction
add constraint Fk_AccountFunction_code foreign key (AccFunction_Code) References Accounts.AccountFunctionCode(AccountFun_Code) on update cascade
go



-- purchase, sales,transfar,deprecaition table 

create schema Invoices;
go

create table Invoices.TB_Purchases(
purchase_ID int primary key identity(1000,1),
AccFunction_Code int not null , 
supplier_ID int not null , 
purchase_invoiceDate date not null , 
purchase_invoiceNo nvarchar(10) not null ,
Department_ID int not null , 
Items_ID int not null ,
Unit_ID int not null,
purchase_Note nvarchar(100) ,
purchase_Qty int not null ,
purchase_price decimal(18,3) not null , 
Items_Cost decimal(10,4) null,
ISActive bit default 1
constraint Fk_TB_Unit_purchase foreign key (Unit_ID) References Items.TB_Unit(Unit_ID)  ,
constraint Fk_TB_Supliers_Purchases foreign key (supplier_ID) References personal.TB_Suppliers(supplier_ID) ,
constraint Fk_AccountFunction_Purchases foreign key (AccFunction_Code) References Accounts.AccountFunctionCode(AccountFun_Code) ,
constraint FK_TB_Departments_Purchases foreign key (Department_ID) References Stores.TB_Departments(Department_ID) ,
constraint Fk_TB_Items_Purchases foreign key (Items_ID) References Items.TB_Items(Items_ID) 
);
go


create table Invoices.TB_Sales(
sales_ID int primary key identity(1000,1),
AccFunction_Code int not null , 
Customer_ID int not null , 
Customer_invoiceDate date not null , 
Customer_invoiceNo nvarchar(10) not null ,
Department_ID int not null , 
Items_ID int not null ,
Unit_ID int not null,
Customer_Note nvarchar(100) ,
Customer_Qty int not null ,
Customer_price decimal(18,3) not null , 
Items_Cost decimal(10,4)  null,
ISActive bit default 1
constraint Fk_TB_Unit_Sales foreign key (Unit_ID) References Items.TB_Unit(Unit_ID)  ,
constraint Fk_TB_Customer_Sales foreign key (Customer_ID) References personal.TB_Customers(Customer_ID)  ,
constraint Fk_AccountFunction_Sales foreign key (AccFunction_Code) References Accounts.AccountFunctionCode(AccountFun_Code)  ,
constraint FK_TB_Departments_Sales foreign key (Department_ID) References Stores.TB_Departments(Department_ID)  ,
constraint Fk_TB_Items_Sales foreign key (Items_ID) References Items.TB_Items(Items_ID) 
);
go


create table Invoices.TB_Depreciation(
Depreciation_ID int primary key identity(1000,1),
AccFunction_Code int not null ,  
Depreciation_invoiceDate date not null , 
Department_ID int not null , 
Items_ID int not null ,
Unit_ID int not null,
Depreciation_Case nvarchar(200) ,
Depreciation_Qty int not null ,
Depreciation_cost decimal(10,4) not null ,
ISActive bit default 1

constraint Fk_TB_Unit_Depreciation foreign key (Unit_ID) References Items.TB_Unit(Unit_ID) ,

constraint Fk_AccountFunction_Depreciation foreign key (AccFunction_Code) References Accounts.AccountFunctionCode(AccountFun_Code)  ,
constraint FK_TB_Departments_Depreciation foreign key (Department_ID) References Stores.TB_Departments(Department_ID)  ,
constraint Fk_TB_Items_Depreciation foreign key (Items_ID) References Items.TB_Items(Items_ID)  
);
go


create table Invoices.TB_Transfar(
Transfar_ID int primary key identity(1000,1),
AccFunction_Code int not null ,  
Transfar_invoiceDate date not null , 
Transfar_invoiceNo nvarchar(10) null ,
Department_ID int not null , 
AccountSub_Code_Out int not null,
AccountSub_Code_IN int not null,
Items_ID int not null ,
Unit_ID int not null,
Transfar_note nvarchar(200) ,
Transfar_Qty int not null ,
Transfar_cost decimal(10,4)  null ,
ISActive bit default 1

constraint Fk_TB_Unit_Transfar foreign key (Unit_ID) References Items.TB_Unit(Unit_ID)  ,

constraint Fk_AccountFunction_Transfar foreign key (AccFunction_Code) References Accounts.AccountFunctionCode(AccountFun_Code) ,
constraint FK_TB_Departments_Transfar foreign key (Department_ID) References Stores.TB_Departments(Department_ID) ,
constraint Fk_TB_Items_Transfar foreign key (Items_ID) References Items.TB_Items(Items_ID)  
);
go


-- trigers --

create trigger trg_insertAccountsupplier
on personal.TB_Suppliers
after insert
as
Begin
insert into Accounts.TB_AccountsSub(AccountSub_Code,AccountGen_ID,AccountSub_Name,AccountSub_ISActive) 
select i.supplier_ID,(select AccountGen_ID from Accounts.TB_AccountsGeneral where AccountGen_NameAr in ('الموردين')),
i.supplier_Name,i.supplier_ISActive from inserted i
end;
go

create trigger trg_insertAccountCustomer
on personal.TB_Customers
after insert
as
Begin
insert into Accounts.TB_AccountsSub(AccountSub_Code,AccountGen_ID,AccountSub_Name,AccountSub_ISActive) 
select i.Customer_ID,(select AccountGen_ID from Accounts.TB_AccountsGeneral where AccountGen_NameAr in ('العملاء')),
i.Customer_Name,i.Customer_ISActive from inserted i
end;
go


create trigger trg_updatesupplier
on personal.TB_Suppliers
after update
as
begin
update Accounts.TB_AccountsSub set AccountSub_Name=i.supplier_Name , AccountSub_ISActive= i.supplier_ISActive 
from Accounts.TB_AccountsSub sub
join inserted i on i.supplier_ID = sub.AccountSub_Code
end;
go

create trigger trg_updateCustomer
on personal.TB_Customers
after update
as
begin
update Accounts.TB_AccountsSub set AccountSub_Name=i.Customer_Name , AccountSub_ISActive= i.Customer_ISActive 
from Accounts.TB_AccountsSub sub
join inserted i on i.Customer_ID = sub.AccountSub_Code
end;
go

-- لا يمكن عمل ذلك لانه سوف يوقف الاضافه كاملتاً
--create trigger trg_stopinsertSuppliers
--on Accounts.TB_AccountsSub
--instead of insert ,update

--as 
--begin
--if exists(select * from inserted where AccountGen_ID in (select AccountGen_ID from Accounts.TB_AccountsGeneral where AccountGen_NameAr in ('العملاء','الموردين','مخازن ومعارض')))
--begin
--raisError ('لا يمكن اضافه حسابات الموردين والعملاء والمخازن او التعديل عليها من هنا ',1,16)
--end
--end;
--go


create trigger trg_InsertStore
on Stores.TB_Stores
after insert
as
begin
insert into Accounts.TB_AccountsSub(AccountSub_Code,AccountGen_ID,AccountSub_Name) 
select i.Store_ID,(select AccountGen_ID from Accounts.TB_AccountsGeneral where AccountGen_NameAr in ('مخازن ومعارض')),i.Store_Name from inserted i
end;
go

create trigger trg_updateStore
on Stores.TB_Stores
after update
as 
begin
update Accounts.TB_AccountsSub set AccountSub_Name=i.Store_Name , AccountSub_ISActive= i.store_IsActive 
from Accounts.TB_AccountsSub sub
join inserted i on i.Store_ID = sub.AccountSub_Code
end;
go 



alter table Accounts.AccountFunctionCode
add AccFunction_type nvarchar(10) not null;
go

alter table stores.Tb_Departments
add Dep_TotalBalance int Default 0;
go
-- trigger of the invoices


----------------------------------

----------------------------------
--trigger Depreciation---
------------------------------------
alter Trigger invoices.Trg_isert_ItemMoveDeprecaition
on [Invoices].[TB_Depreciation]
after insert
as 
begin
-- تسجيل الحركه الاصناف
insert into Items.Tb_ItemMove (Items_ID,Department_ID,ItemMove_Qty,ItemMove_Cost,Funtion_ID,Invoice_ID)
select i.Items_ID ,i.Department_ID,(-1*i.Depreciation_Qty) ,0,i.AccFunction_Code,i.Depreciation_ID from inserted i

----تحديث المخزون في القسم
--update Stores.TB_Departments set Dep_TotalBalance = Dep_TotalBalance - i. Depreciation_Qty 
--from Stores.TB_Departments dep
--join inserted i on i.Department_ID = dep.Department_ID

-- تعديل نوع القيد الي مشتريات
 update Accounts.AccountFunctionCode set AccFunction_type = 'اهـــلاك'
 from Accounts.AccountFunctionCode code
 join inserted i on code.AccountFun_Code = i.AccFunction_Code
end;
go


alter Trigger [Invoices].[Trg_update_ItemMoveDeprecaition]
on [Invoices].[TB_Depreciation]
after update
as 
begin
-- تسجيل الحركه الاصناف
-- تم الحذف في trigger القيود والتكاليف
--delete   Items.Tb_ItemMove from Items.Tb_ItemMove
--join inserted i on i.AccFunction_Code = Tb_ItemMove.Funtion_ID
--where i.Items_ID = Tb_ItemMove.Items_ID
--and i.Department_ID = Tb_ItemMove.Department_ID
--and i.Depreciation_ID= Tb_ItemMove.Invoice_ID


insert into Items.Tb_ItemMove (Items_ID,Department_ID,ItemMove_Qty,ItemMove_Cost,Funtion_ID,Invoice_ID)
select i.Items_ID ,i.Department_ID,(-1*i.Depreciation_Qty) ,0,i.AccFunction_Code,i.Depreciation_ID from inserted i

--update Items.Tb_ItemMove set Items_ID = i.Items_ID ,Department_ID=i.Department_ID,ItemMove_Qty=-1*(i.Depreciation_Qty),ItemMove_Cost=0
--from Items.Tb_ItemMove itemmove
--join inserted i on i.AccFunction_Code = itemmove.Funtion_ID
--where i.Items_ID = itemmove.Items_ID

----تحديث المخزون في القسم
--update Stores.TB_Departments set Dep_TotalBalance = Dep_TotalBalance +de.Depreciation_Qty - i. Depreciation_Qty 
--from Stores.TB_Departments dep 
--join inserted i on i.Department_ID = dep.Department_ID 
--join deleted de on de.Department_ID = dep.Department_ID

end;
go

alter trigger invoices.trg_ReinsertDeprecaitionCost
on invoices.TB_Depreciation
instead of insert 
as
begin
-- حذف العناصر المرتبطه من tb_itemsMove
 -- حذف الحركه قبل الحصول علي التكلف
--delete   Items.Tb_ItemMove from Items.Tb_ItemMove
--join inserted i on i.AccFunction_Code = Tb_ItemMove.Funtion_ID
--where i.Items_ID = Tb_ItemMove.Items_ID
--and i.Department_ID = Tb_ItemMove.Department_ID
--and i.Depreciation_ID = Tb_ItemMove.Invoice_ID

 declare @itemID int;
 Declare @DepartmentID int;
 select @itemID=Items_ID,@DepartmentID = Department_ID from inserted
 
  -- فحص الكميه المتاحه في القسم 
   declare @item_Balance int;
 select @item_Balance=Item_Qty from  items.fun_ItemCostAndBalanceINDepartment(@itemID,@DepartmentID)
 -- لو الكميه المراد اهلاكها اقل من 0 ايقاف الاضافه 
 declare @Item_order int ;
 select @Item_order =Depreciation_Qty from inserted

 if @item_Balance- @Item_order <0 
 begin
 RAISERROR (N'الكميه المتاحه لا تكفي لعمل الاهلاك', 16, 1);
 return;
 end;
    -- تكلفه العنصر 
  declare @costItem decimal(10,4) ;
  select @costItem= avg_Cost from  items.fun_ItemAvgCostINDepartment(@itemID,@DepartmentID)

  --ادخال قيمه Cost_Item في جمله الادخال
  insert into [Invoices].TB_Depreciation
           ([AccFunction_Code]
           ,[Depreciation_invoiceDate]
           ,[Department_ID]
           ,[Items_ID]
           ,[Unit_ID]
           ,[Depreciation_Case]
           ,[Depreciation_Qty]
           ,[Depreciation_cost]
           ,[ISActive])
   
   select 
  [AccFunction_Code]
           ,[Depreciation_invoiceDate]
           ,[Department_ID]
           ,[Items_ID]
           ,[Unit_ID]
           ,[Depreciation_Case]
           ,[Depreciation_Qty]
           ,@costItem
           ,[ISActive] from inserted 
end;
go

alter trigger invoices.trg_ReupdateDeprecaitionCost
on invoices.TB_Depreciation
instead of update 
as
begin
-- حذف العناصر المرتبطه من tb_itemsMove
 -- حذف الحركه قبل الحصول علي التكلف
delete   Items.Tb_ItemMove from Items.Tb_ItemMove
join inserted i on i.AccFunction_Code = Tb_ItemMove.Funtion_ID
where i.Items_ID = Tb_ItemMove.Items_ID
and i.Department_ID = Tb_ItemMove.Department_ID
and i.Depreciation_ID = Tb_ItemMove.Invoice_ID

-- تقليل الكميه من balance tb_department


 declare @itemID int;
 Declare @DepartmentID int;
 select @itemID=Items_ID,@DepartmentID = Department_ID from inserted

   -- فحص الكميه المتاحه في القسم 
   declare @item_Balance int;
 select @item_Balance=Item_Qty from  items.fun_ItemCostAndBalanceINDepartment(@itemID,@DepartmentID)
 -- لو الكميه المراد اهلاكها اقل من 0 ايقاف الاضافه 
 declare @Item_order int ;
 select @Item_order =Depreciation_Qty from inserted

 if @item_Balance- @Item_order <0 
 begin
 RAISERROR (N'الكميه المتاحه لا تكفي لعمل الاهلاك', 16, 1);
 return;
 end;
   -- تكلفه العنصر 
  declare @costItem decimal(10,4) ;
  select @costItem= avg_Cost from  items.fun_ItemAvgCostINDepartment(@itemID,@DepartmentID)

  --ادخال قيمه Cost_Item في جمله الادخال
  update TB_Depreciation set  [AccFunction_Code] = i.AccFunction_Code
      ,[Depreciation_invoiceDate] = i.Depreciation_invoiceDate
      ,[Department_ID] = i.Department_ID
      ,[Items_ID] = i.Items_ID
      ,[Unit_ID] = i.Unit_ID
      ,[Depreciation_Case] = i.Depreciation_Case
      ,[Depreciation_Qty] = i.Depreciation_Qty
      ,[Depreciation_cost] = @costItem
      ,[ISActive] = i.ISActive
	  from TB_Depreciation
	  join inserted i on TB_Depreciation.Depreciation_ID = i.Depreciation_ID
end;
go

alter trigger invoices.trg_DeleteDeprecaitionCost
on invoices.TB_Depreciation
after delete
as
begin
-- حذف العناصر المرتبطه من tb_itemsMove
 -- حذف الحركه قبل الحصول علي التكلف
delete   Items.Tb_ItemMove from Items.Tb_ItemMove
join inserted i on i.Depreciation_ID = Tb_ItemMove.Invoice_ID
and i.AccFunction_Code = Tb_ItemMove.Funtion_ID
end;
go
------------------------------------------
------------------------------------------



----------------------------------
alter table invoices.tb_transfar
add Department_IDIN int not null 
constraint FK_DepartmentIN foreign key (department_IDIN) References [Stores].[TB_Departments]([Department_ID]);

-----------------------------------
--trigger transfar---
------------------------------------
alter Trigger invoices.Trg_insert_ItemMoveTransfar
on [Invoices].[TB_Transfar]
after insert
as 
begin
--الاضافه تسجيل الحركه الاصناف
insert into Items.Tb_ItemMove (Items_ID,Department_ID,ItemMove_Qty,ItemMove_Cost,Funtion_ID,Invoice_ID)
select i.Items_ID ,i.Department_IDIN,i.Transfar_Qty ,i.Transfar_cost,i.AccFunction_Code ,i.Transfar_ID from inserted i

----تحديث المخزون في القسم
--update Stores.TB_Departments set Dep_TotalBalance = Dep_TotalBalance + i. Transfar_Qty 
--from Stores.TB_Departments dep
--join inserted i on i.Department_IDIN = dep.Department_ID


--الحزف تسجيل الحركه الاصناف
insert into Items.Tb_ItemMove (Items_ID,Department_ID,ItemMove_Qty,ItemMove_Cost,Funtion_ID,Invoice_ID)
select i.Items_ID ,i.Department_ID,(-1*i.Transfar_Qty) ,(-1*i.Transfar_cost),i.AccFunction_Code ,i.Transfar_ID from inserted i

----تحديث المخزون في القسم
--update Stores.TB_Departments set Dep_TotalBalance = Dep_TotalBalance - i. Transfar_Qty 
--from Stores.TB_Departments dep
--join inserted i on i.Department_ID = dep.Department_ID

end;
go


alter Trigger invoices.Trg_update_ItemMoveTransfar
on [Invoices].[TB_Transfar]
after update
as 
begin
-- تسجيل الحركه الاصناف الحذف

-- تم الحذف في trigger القيود والتكاليف
--delete   Items.Tb_ItemMove from Items.Tb_ItemMove
--join inserted i on i.AccFunction_Code = Tb_ItemMove.Funtion_ID
--where i.Items_ID = Tb_ItemMove.Items_ID
--and i.Department_ID = Tb_ItemMove.Department_ID
--and i.Transfar_ID= Tb_ItemMove.Invoice_ID

insert into Items.Tb_ItemMove (Items_ID,Department_ID,ItemMove_Qty,ItemMove_Cost,Funtion_ID,Invoice_ID)
select i.Items_ID ,i.Department_IDIN,i.Transfar_Qty ,i.Transfar_cost,i.AccFunction_Code ,i.Transfar_ID from inserted i

----تحديث المخزون في القسم
--update Stores.TB_Departments set Dep_TotalBalance = Dep_TotalBalance + i. Transfar_Qty 
--from Stores.TB_Departments dep
--join inserted i on i.Department_IDIN = dep.Department_ID


--الحزف تسجيل الحركه الاصناف
insert into Items.Tb_ItemMove (Items_ID,Department_ID,ItemMove_Qty,ItemMove_Cost,Funtion_ID,Invoice_ID)
select i.Items_ID ,i.Department_ID,(-1*i.Transfar_Qty) ,(-1*i.Transfar_cost),i.AccFunction_Code ,i.Transfar_ID from inserted i

--update Items.Tb_ItemMove set Items_ID = i.Items_ID ,Department_ID=i.Department_ID,ItemMove_Qty=-1*(i.Transfar_Qty),ItemMove_Cost=(-1*i.Transfar_cost )
--from Items.Tb_ItemMove itemmove
--join inserted i on i.AccFunction_Code = itemmove.Funtion_ID 
--where i.Department_ID = itemmove.Department_ID 
--and  i.Items_ID = itemmove.Items_ID

---- تعديل حركه الاضافه
--update Items.Tb_ItemMove set Items_ID = i.Items_ID ,Department_ID=i.Department_IDIN,ItemMove_Qty= i.Transfar_Qty,ItemMove_Cost= i.Transfar_cost 
--from Items.Tb_ItemMove itemmove
--join inserted i on i.AccFunction_Code = itemmove.Funtion_ID 
--where i.Department_IDIN = itemmove.Department_ID
-- and  i.Items_ID = itemmove.Items_ID

----تحديث المخزون في القسم الحذف
--update Stores.TB_Departments set Dep_TotalBalance = Dep_TotalBalance +de.Transfar_Qty - i. Transfar_Qty 
--from Stores.TB_Departments dep 
--join inserted i on i.Department_ID = dep.Department_ID 
--join deleted de on de.Department_ID = dep.Department_ID

----تحديث المخزون في القسم الزياده
--update Stores.TB_Departments set Dep_TotalBalance = Dep_TotalBalance -de.Transfar_Qty + i. Transfar_Qty 
--from Stores.TB_Departments dep 
--join inserted i on i.Department_IDIN = dep.Department_ID 
--join deleted de on de.Department_IDIN = dep.Department_ID
end;
go

alter trigger invoices.trg_ReinsertTransfarCost
on [Invoices].[TB_Transfar]
instead of insert 
as
begin
-- حذف العناصر المرتبطه من tb_itemsMove
 -- حذف الحركه قبل الحصول علي التكلف
--delete   Items.Tb_ItemMove from Items.Tb_ItemMove
--join inserted i on i.AccFunction_Code = Tb_ItemMove.Funtion_ID
--where i.Items_ID = Tb_ItemMove.Items_ID
--and i.Department_ID = Tb_ItemMove.Department_ID
--and i.sales_ID = Tb_ItemMove.Invoice_ID


 declare @itemID int;
 Declare @DepartmentID int;
 select @itemID=Items_ID,@DepartmentID = Department_ID from inserted

     -- فحص الكميه المتاحه في القسم 
   declare @item_Balance int;
 select @item_Balance=Item_Qty from  items.fun_ItemCostAndBalanceINDepartment(@itemID,@DepartmentID)
 -- لو الكميه المراد اهلاكها اقل من 0 ايقاف الاضافه 
 declare @Item_order int ;
 select @Item_order =Transfar_Qty from inserted

 if @item_Balance- @Item_order <0 
 begin
 RAISERROR (N'الكميه المتاحه لا تكفي لعمليه التحويل', 16, 1);
 return;
 end;

  -- تكلفه العنصر 
  declare @costItem decimal(10,4) ;
  select @costItem= avg_Cost from  items.fun_ItemAvgCostINDepartment(@itemID,@DepartmentID)

  --ادخال قيمه Cost_Item في جمله الادخال
  insert into [Invoices].[TB_Transfar]
           ([AccFunction_Code]
           ,[Transfar_invoiceDate]
           ,[Transfar_invoiceNo]
           ,[Department_ID]
		   ,[Department_IDIN]
           ,[Items_ID]
           ,[Unit_ID]
           ,[Transfar_note]
           ,[Transfar_Qty]
           ,[Transfar_cost]
           ,[ISActive]
           )
   
   select 
           [AccFunction_Code]
           ,[Transfar_invoiceDate]
           ,[Transfar_invoiceNo]
           ,[Department_ID]
		   ,[Department_IDIN] 
           ,[Items_ID]
           ,[Unit_ID]
           ,[Transfar_note]
           ,[Transfar_Qty]
           ,@costItem
           ,[ISActive]
from inserted 
end;
go
--*************************
create trigger invoices.trg_DeleteTransfarCost
on [Invoices].[TB_Transfar]
after delete
as
begin
-- حذف العناصر المرتبطه من tb_itemsMove
 -- حذف الحركه قبل الحصول علي التكلف
delete   Items.Tb_ItemMove from Items.Tb_ItemMove
join deleted i on i.AccFunction_Code = Tb_ItemMove.Funtion_ID
where i.Items_ID = Tb_ItemMove.Items_ID
and i.Transfar_ID = Tb_ItemMove.Invoice_ID
end;
go

alter trigger invoices.trg_ReupdateTransfarCost
on [Invoices].[TB_Transfar]
instead of update 
as
begin
-- حذف العناصر المرتبطه من tb_itemsMove
 -- حذف الحركه قبل الحصول علي التكلف
delete   Items.Tb_ItemMove from Items.Tb_ItemMove
join inserted i on i.AccFunction_Code = Tb_ItemMove.Funtion_ID
where i.Items_ID = Tb_ItemMove.Items_ID
and i.Transfar_ID = Tb_ItemMove.Invoice_ID

-- تقليل الكميه من balance tb_department


 declare @itemID int;
 Declare @DepartmentID int;
 select @itemID=Items_ID,@DepartmentID = Department_ID from inserted
     -- فحص الكميه المتاحه في القسم 
   declare @item_Balance int;
 select @item_Balance=Item_Qty from  items.fun_ItemCostAndBalanceINDepartment(@itemID,@DepartmentID)
 -- لو الكميه المراد اهلاكها اقل من 0 ايقاف الاضافه 
 declare @Item_order int ;
 select @Item_order =Transfar_Qty from inserted

 if @item_Balance- @Item_order <0 
 begin
 RAISERROR (N'الكميه المتاحه لا تكفي لعمليه التحويل', 16, 1);
 return;
 end;
  -- تكلفه العنصر 
  declare @costItem decimal(10,4) ;
  select @costItem= avg_Cost from  items.fun_ItemAvgCostINDepartment(@itemID,@DepartmentID)

  --ادخال قيمه Cost_Item في جمله الادخال
  UPDATE [Invoices].[TB_Transfar]
   SET [AccFunction_Code] = i.AccFunction_Code 
      ,[Transfar_invoiceDate] = i.Transfar_invoiceDate 
      ,[Transfar_invoiceNo] = i.Transfar_invoiceNo 
      ,[Department_ID] = i.Department_ID 
      ,[Department_IDIN] = i.Department_IDIN 
      ,[Items_ID] = i.Items_ID 
      ,[Unit_ID] = i.Unit_ID 
      ,[Transfar_note] = i.Transfar_note 
      ,[Transfar_Qty] = i.Transfar_Qty 
      ,[Transfar_cost] =@costItem
      ,[ISActive] = i.ISActive 
	  from [Invoices].[TB_Transfar]
	  join inserted i on [TB_Transfar].Transfar_ID = i.Transfar_ID
end;
go

-- عمل trigger لاضافه قيود في كل من invoices
alter trigger Invoices.Trg_insert_Trans_Function
--اضافه قيد التحويلات
on [Invoices].TB_Transfar
after insert,update ,delete
as
begin
--حذف القيد القديم
declare @function_Code int; 
select @function_Code= accfunction_code from inserted
if @function_Code is null 
begin
select @function_Code= accfunction_code from deleted
end;
Exec Accounts.DeleteFunction @functionCode=@function_Code
--اضافه قيد جديد --
-- اضافه الجانب المدين --
insert into Accounts.AccountFunction(
AccFunction_Depit,
AccFunction_Credit,
AccFunction_Note,
AccFunction_Code,
AccountSub_Code,
AccFunction_Date)
select 
Item_Cost,
0,
Transfar_invoiceNo +'فاتوره تحويلات رقم',
AccFunction_Code,
Store_ID,
FunctionDate  
 from invoices.View_InvoiceTransfar_FunDepit 
  where AccFunction_Code= @function_Code
--اضافه الجانب الدائن--
insert into Accounts.AccountFunction(
AccFunction_Depit,
AccFunction_Credit,
AccFunction_Note,
AccFunction_Code,
AccountSub_Code,
AccFunction_Date)
select 0,
Item_Cost,
Transfar_invoiceNo +'فاتوره تحويلات رقم',
AccFunction_Code,
Store_ID,
FunctionDate from 
 invoices.View_InvoiceTransfar_FunCredit 
  where AccFunction_Code= @function_Code
 -- تعديل نوع القيد الي مشتريات
 update Accounts.AccountFunctionCode set AccFunction_type = 'تحويلات'
 from Accounts.AccountFunctionCode code
 join inserted i on code.AccountFun_Code = i.AccFunction_Code
end;
go

------------------------
--trigger payment--
-----------------------
alter Trigger accounts.Trg_insert_ItemMovePayment
-- تسجيل التكلفه لكل عنصر بناءا علي المصروف المدفوع للقسم
-- المصروف / عدد الوحدات داخل القسم * عدد الاصناف
on accounts.Tb_payments
after insert
as 
begin
-- تسجيل الحركه الاصناف
--هنا يتم الحفظ برقم ID_payment وذلك للرجوع اليه عند عمليه التعديل

declare @department int = null;
select @department = Department_ID from inserted


IF @department is not null
begin
-- عند ارسال القسم بقيمه وتحديد القسم يقوم بتحميل الاصناف بالتكلفه
insert into Items.Tb_ItemMove (Items_ID,Department_ID,ItemMove_Qty,ItemMove_Cost,Funtion_ID,Invoice_ID)
select item.Items_ID ,i.Department_ID,0,((i.payment_Amount /dep.Dep_TotalBalance)* item.Item_Qty) as ItemMove_Cost,i.AccFunction_Code,i.payment_ID 
from inserted i 
join stores.Fun_StoresDepartmentCostAndBalance() item on item.Department_ID = i.Department_ID
join Stores.TB_Departments dep on i.Department_ID = dep.Department_ID
end;
Else 
begin
-- عند ارسال القسم بدون قيمه ولم يتم تحديد القسم يقوم بتحميل الاصناف بالتكلفه
-- يتم تحميل كل الاقسام وكل الاصناف وتحميلها بالتكلفه 
-- توزيع التكلفه علي اكثر من قسم اي توزيع التكلفه علي المخزن ككل

--عدد الاقسام داخل المخزن
declare @countofDepartment int;
select @countofDepartment = Count(dep.Department_ID) 
from Stores.TB_Departments dep
join inserted i on i.Store_IDs = dep.Store_ID
where dep.Dep_TotalBalance <>0;
 
-- توزيع تكلفه المصروف علي الاقسام داخل المخزن بالتساوي 
-- بقسمه مبلغ التكلفه علي عدد الاقسام داخل المخزن ومن ثم توزيعها طبيعي
insert into Items.Tb_ItemMove (Items_ID,Department_ID,ItemMove_Qty,ItemMove_Cost,Funtion_ID,Invoice_ID)
select item.Items_ID 
,dep.Department_ID
,0,
(((i.payment_Amount /@countofDepartment)/dep.Dep_TotalBalance)* item.Item_Qty) as ItemMove_Cost
,i.AccFunction_Code
,i.payment_ID 
from inserted i 
join Stores.TB_Departments dep on i.Store_IDs = dep.Store_ID
join stores.Fun_StoresDepartmentCostAndBalance() item on item.Department_ID = dep.Department_ID

end;
end;
go

 

 

alter Trigger accounts.Trg_Update_ItemMovePayment
on accounts.Tb_payments
after update
as 
begin
-- تسجيل الحركه الاصناف
-- اول خطوه حذف القديم الاول
delete   Items.Tb_ItemMove from Items.Tb_ItemMove
join inserted i on i.AccFunction_Code = Tb_ItemMove.Funtion_ID
and i.payment_ID = Tb_ItemMove.Invoice_ID


declare @department int = null;
select @department = Department_ID from inserted


IF @department Is not null 
begin
-- عند ارسال القسم بقيمه وتحديد القسم يقوم بتحميل الاصناف بالتكلفه
-- بعد كدا -- تسجيل التكلفه لكل عنصر بناءا علي المصروف المدفوع للقسم
-- المصروف / عدد الوحدات داخل القسم * عدد الاصناف 
--هنا يتم الحفظ برقم ID_payment وذلك للرجوع اليه عند عمليه التعديل

insert into Items.Tb_ItemMove (Items_ID,Department_ID,ItemMove_Qty,ItemMove_Cost,Funtion_ID,Invoice_ID)
select item.Items_ID ,i.Department_ID,0,
((i.payment_Amount /dep.Dep_TotalBalance)* item.Item_Qty) as ItemMove_Cost,i.AccFunction_Code,i.payment_ID 
from inserted i 
join stores.Fun_StoresDepartmentCostAndBalance() item on item.Department_ID = i.Department_ID
join Stores.TB_Departments dep on i.Department_ID = dep.Department_ID
end;
else
begin
-- عند ارسال القسم بدون قيمه ولم يتم تحديد القسم يقوم بتحميل الاصناف بالتكلفه
-- يتم تحميل كل الاقسام وكل الاصناف وتحميلها بالتكلفه 
-- توزيع التكلفه علي اكثر من قسم اي توزيع التكلفه علي المخزن ككل

--عدد الاقسام داخل المخزن
declare @countofDepartment int;
select @countofDepartment = Count(dep.Department_ID) 
from Stores.TB_Departments dep
join inserted i on i.Store_IDs = dep.Store_ID
where dep.Dep_TotalBalance <>0;
 
-- توزيع تكلفه المصروف علي الاقسام داخل المخزن بالتساوي 
-- بقسمه مبلغ التكلفه علي عدد الاقسام داخل المخزن ومن ثم توزيعها طبيعي
insert into Items.Tb_ItemMove (Items_ID,Department_ID,ItemMove_Qty,ItemMove_Cost,Funtion_ID,Invoice_ID)
select item.Items_ID 
,dep.Department_ID
,0,
(((i.payment_Amount /@countofDepartment)/dep.Dep_TotalBalance)* item.Item_Qty) as ItemMove_Cost
,i.AccFunction_Code
,i.payment_ID 
from inserted i 
join Stores.TB_Departments dep on i.Store_IDs = dep.Store_ID
join stores.Fun_StoresDepartmentCostAndBalance() item on item.Department_ID = dep.Department_ID

end;
end;
go

--select item.Items_ID 
--,dep.Department_ID
--,0,
--(((1000 /2)/dep.Dep_TotalBalance)* item.Item_Qty) as ItemMove_Cost
--,Item_Qty
--,i.AccFunction_Code
--,i.payment_ID 
--from Accounts.TB_payments i 
-- join Stores.TB_Departments dep on i.Store_IDs = dep.Store_ID
--join stores.Fun_StoresDepartmentCostAndBalance() item on item.Department_ID = dep.Department_ID
--where i.payment_ID=3

--select * from stores.Fun_StoresDepartmentCostAndBalance() where Department_ID in (2)

alter Trigger accounts.Trg_Delete_ItemMovePayment
on accounts.Tb_payments
after delete
as 
begin
-- تسجيل الحركه الاصناف
-- حذف جميع الحركات المتعلقه بالمصروف بناءا علي payment_ID
delete   Items.Tb_ItemMove from Items.Tb_ItemMove
join deleted de on de.AccFunction_Code = Tb_ItemMove.Funtion_ID
where
 de.payment_ID = Tb_ItemMove.Invoice_ID

end;
go

-- عمل trigger لاضافه قيود في كل من invoices
alter trigger Accounts.Trg_insert_Payment_Function
--اضافه قيد المشتريات
on [Accounts].[TB_payments]
after insert,update ,delete
as
begin
--حذف القيد القديم
declare @function_Code int; 
select @function_Code= accfunction_code from inserted
Exec Accounts.DeleteFunction @functionCode=@function_Code
if @function_Code is null 
begin
 select @function_Code= accfunction_code from deleted
Exec Accounts.DeleteFunction @functionCode=@function_Code
end; 
--اضافه قيد جديد --
-- اضافه الجانب المدين --
insert into Accounts.AccountFunction(AccFunction_Depit,
AccFunction_Credit,
AccFunction_Note,
AccFunction_Code,
AccountSub_Code,
AccFunction_Date)
select payment_Amount,
0,
payment_invoiceNo +'فاتوره مصروفات رقم',
AccFunction_Code,
Store_ID,
FunctionDate  
 from invoices.View_InvoicePayment_FunDepit  
    where AccFunction_Code= @function_Code
--اضافه الجانب الدائن--
insert into Accounts.AccountFunction(
AccFunction_Depit,
AccFunction_Credit,
AccFunction_Note,
AccFunction_Code,
AccountSub_Code,
AccFunction_Date)
select 0,
payment_Amount,
payment_invoiceNo +'فاتوره مصروفات رقم',
AccFunction_Code,
AccountSub_Code,
FunctionDate from 
 invoices.View_InvoicePayment_FunCreadit
  where AccFunction_Code= @function_Code
 -- تعديل نوع القيد الي مصروفات
 update Accounts.AccountFunctionCode set AccFunction_type = 'مصروفات'
 from Accounts.AccountFunctionCode code
 join inserted i on code.AccountFun_Code = i.AccFunction_Code
end;
go
----------------------------------------
-- trigger Balance in tb_Department--
--------------------------------------
alter trigger items.trg_DeleteITemsMove
on [Items].[Tb_ItemMove]
after Delete
as
begin
--تحديث المخزون في القسم الحذف
update Stores.TB_Departments set Dep_TotalBalance = Dep_TotalBalance - de. ItemMove_Qty 
from Stores.TB_Departments dep 
 
join deleted de on de.Department_ID = dep.Department_ID
end;
go

create trigger items.trg_InsertTemsMove
on [Items].[Tb_ItemMove]
after insert
as
begin
--تحديث المخزون في القسم
update Stores.TB_Departments set Dep_TotalBalance = Dep_TotalBalance + i. ItemMove_Qty 
from Stores.TB_Departments dep 
join inserted i on i.Department_ID = dep.Department_ID 
 

end;
go
------------------------------------------------
-- trigger Purchares
------------------------------------------------
alter Trigger invoices.Trg_isert_ItemMove
on [Invoices].[TB_Purchases]
after insert
as 
begin
-- تسجيل الحركه الاصناف
insert into Items.Tb_ItemMove (Items_ID,Department_ID,ItemMove_Qty,ItemMove_Cost,Funtion_ID,Invoice_ID)
select i.Items_ID ,i.Department_ID,i.purchase_Qty,i.purchase_price,i.AccFunction_Code,purchase_ID from inserted i

----تحديث المخزون في القسم
--update Stores.TB_Departments set Dep_TotalBalance = Dep_TotalBalance + i. purchase_Qty 
--from Stores.TB_Departments dep
--join inserted i on i.Department_ID = dep.Department_ID

end;

go

alter Trigger invoices.Trg_update_ItemMove
on [Invoices].[TB_Purchases]
after update
as 
begin
-- تسجيل الحركه الاصناف

--update Items.Tb_ItemMove set Items_ID = i.Items_ID ,Department_ID=i.Department_ID,ItemMove_Qty=i.purchase_Qty,ItemMove_Cost=i.purchase_price 
--from Items.Tb_ItemMove itemmove
--join inserted i on i.AccFunction_Code = itemmove.Funtion_ID
--where i.Items_ID = itemmove.Items_ID

--تحديث المخزون في القسم
--update Stores.TB_Departments set Dep_TotalBalance = Dep_TotalBalance -de.purchase_Qty + i. purchase_Qty 
--from Stores.TB_Departments dep 
--join inserted i on i.Department_ID = dep.Department_ID 
--join deleted de on de.Department_ID = dep.Department_ID
-- تم الحذف في trigger القيود والتكاليف
delete Items.Tb_ItemMove from Items.Tb_ItemMove
join inserted i on i.AccFunction_Code = Tb_ItemMove.Funtion_ID
where i.Items_ID = Tb_ItemMove.Items_ID
and i.purchase_ID = Tb_ItemMove.Invoice_ID
and i.Department_ID = Tb_ItemMove.Department_ID

insert into Items.Tb_ItemMove (Items_ID,Department_ID,ItemMove_Qty,ItemMove_Cost,Funtion_ID,Invoice_ID)
select i.Items_ID ,i.Department_ID,( i.purchase_Qty) ,( i.purchase_price),i.AccFunction_Code,i.purchase_ID from inserted i

end;
go

create trigger invoices.trg_ReinsertPurchaseCost
on [Invoices].[TB_Purchases]
instead of insert 
as
begin
-- حذف العناصر المرتبطه من tb_itemsMove
 -- حذف الحركه قبل الحصول علي التكلف
--delete   Items.Tb_ItemMove from Items.Tb_ItemMove
--join inserted i on i.AccFunction_Code = Tb_ItemMove.Funtion_ID
--where i.Items_ID = Tb_ItemMove.Items_ID
--and i.Department_ID = Tb_ItemMove.Department_ID
--and i.sales_ID = Tb_ItemMove.Invoice_ID


 declare @itemID int;
 Declare @DepartmentID int;
 select @itemID=Items_ID,@DepartmentID = Department_ID from inserted
 

  -- تكلفه العنصر 
  declare @costItem decimal(10,4) ;
  select @costItem= avg_Cost from  items.fun_ItemAvgCostINDepartment(@itemID,@DepartmentID)

  --ادخال قيمه Cost_Item في جمله الادخال
  insert into [Invoices].[TB_Purchases]
           ([AccFunction_Code]
           ,[supplier_ID]
           ,[purchase_invoiceDate]
           ,[purchase_invoiceNo]
           ,[Department_ID]
           ,[Items_ID]
           ,[Unit_ID]
           ,[purchase_Note]
           ,[purchase_Qty]
           ,[purchase_price]
           ,[Items_Cost]
           ,[ISActive])
   
   select 
           [AccFunction_Code]
           ,[supplier_ID]
           ,[purchase_invoiceDate]
           ,[purchase_invoiceNo]
           ,[Department_ID]
           ,[Items_ID]
           ,[Unit_ID]
           ,[purchase_Note]
           ,[purchase_Qty]
           ,[purchase_price]
           ,@costItem
           ,[ISActive] from inserted 
end;
go

alter trigger invoices.trg_Deletepurchaseinvoice
on [Invoices].[TB_Purchases]
after delete
as
begin
-- حذف العناصر المرتبطه من tb_itemsMove
 -- حذف الحركه قبل الحصول علي التكلف
delete   Items.Tb_ItemMove from Items.Tb_ItemMove
join deleted i on i.purchase_ID = Tb_ItemMove.Invoice_ID
where i.AccFunction_Code= Tb_ItemMove.Funtion_ID
end;
go

create trigger invoices.trg_ReupdatePurchaseCost
on [Invoices].[TB_Purchases]
instead of update 
as
begin
-- حذف العناصر المرتبطه من tb_itemsMove
 -- حذف الحركه قبل الحصول علي التكلف
delete   Items.Tb_ItemMove from Items.Tb_ItemMove
join inserted i on i.AccFunction_Code = Tb_ItemMove.Funtion_ID
where i.Items_ID = Tb_ItemMove.Items_ID
and i.Department_ID = Tb_ItemMove.Department_ID
and i.purchase_ID = Tb_ItemMove.Invoice_ID

-- تقليل الكميه من balance tb_department


 declare @itemID int;
 Declare @DepartmentID int;
 select @itemID=Items_ID,@DepartmentID = Department_ID from inserted

  -- تكلفه العنصر 
  declare @costItem decimal(10,4) ;
  select @costItem= avg_Cost from  items.fun_ItemAvgCostINDepartment(@itemID,@DepartmentID)

  --ادخال قيمه Cost_Item في جمله الادخال
  UPDATE [Invoices].[TB_Purchases]
   SET [AccFunction_Code] = i.AccFunction_Code 
      ,[supplier_ID] = i.supplier_ID 
      ,[purchase_invoiceDate] = i.purchase_invoiceDate 
      ,[purchase_invoiceNo] = i.purchase_invoiceNo 
      ,[Department_ID] = i.Department_ID 
      ,[Items_ID] = i.Items_ID 
      ,[Unit_ID] = i.Unit_ID 
      ,[purchase_Note] = i.purchase_Note 
      ,[purchase_Qty] = i.purchase_Qty 
      ,[purchase_price] = i.purchase_price 
      ,[Items_Cost] = @costItem
      ,[ISActive] = i.ISActive 
	  from TB_Purchases
	  join inserted i on TB_Purchases.purchase_ID = i.purchase_ID
end;
go

--/////////////////////////////////
-- عمل trigger لاضافه قيود في كل من invoices
alter trigger Invoices.Trg_insert_purchase_Function
--اضافه قيد المشتريات
on [Invoices].[TB_Purchases]
after insert,update
as
begin
--حذف القيد القديم
declare @function_Code int; 
select @function_Code= accfunction_code from inserted
Exec Accounts.DeleteFunction @functionCode=@function_Code
--اضافه قيد جديد --
-- اضافه الجانب المدين --
insert into Accounts.AccountFunction(AccFunction_Depit,
AccFunction_Credit,
AccFunction_Note,
AccFunction_Code,
AccountSub_Code,
AccFunction_Date)
select purchase_price,
0,
purchase_invoiceNo +'فاتوره مشتريات رقم',
AccFunction_Code,
Store_ID,
FunctionDate  
 from invoices.View_Invoicepurchase_FunDepit
 where AccFunction_Code= @function_Code
--اضافه الجانب الدائن--
insert into Accounts.AccountFunction(AccFunction_Depit,
AccFunction_Credit,
AccFunction_Note,
AccFunction_Code,
AccountSub_Code,
AccFunction_Date)
select 0,
purchase_price,
purchase_invoiceNo +'فاتوره مشتريات رقم',
AccFunction_Code,
supplier_ID,
FunctionDate from 
 invoices.View_Invoicepurchase_FunCreadit
  where AccFunction_Code= @function_Code
 -- تعديل نوع القيد الي مشتريات
 update Accounts.AccountFunctionCode set AccFunction_type = 'مشتريات'
 from Accounts.AccountFunctionCode code
 join inserted i on code.AccountFun_Code = i.AccFunction_Code
end;
go

create trigger Invoices.Trg_Delete_purchase_Function
--حذف قيد المشتريات
on [Invoices].[TB_Purchases]
after Delete
as
begin
--حذف القيد القديم
declare @function_Code int; 
select @function_Code= accfunction_code from deleted
Exec Accounts.DeleteFunction @functionCode=@function_Code
--اضافه قيد جديد --
-- اضافه الجانب المدين --
insert into Accounts.AccountFunction(AccFunction_Depit,
AccFunction_Credit,
AccFunction_Note,
AccFunction_Code,
AccountSub_Code,
AccFunction_Date)
select purchase_price,
0,
purchase_invoiceNo +'فاتوره مشتريات رقم',
AccFunction_Code,
Store_ID,
FunctionDate  
 from invoices.View_Invoicepurchase_FunDepit
 where AccFunction_Code= @function_Code
--اضافه الجانب الدائن--
insert into Accounts.AccountFunction(AccFunction_Depit,
AccFunction_Credit,
AccFunction_Note,
AccFunction_Code,
AccountSub_Code,
AccFunction_Date)
select 0,
purchase_price,
purchase_invoiceNo +'فاتوره مشتريات رقم',
AccFunction_Code,
supplier_ID,
FunctionDate from 
 invoices.View_Invoicepurchase_FunCreadit
  where AccFunction_Code= @function_Code
 -- تعديل نوع القيد الي مشتريات
 update Accounts.AccountFunctionCode set AccFunction_type = 'مشتريات'
 from Accounts.AccountFunctionCode code
 join deleted i on code.AccountFun_Code = i.AccFunction_Code
end;
go
----------------------------------
--trigger Sales ----
----------------------------------
--trigger sales---

alter Trigger invoices.Trg_isert_ItemMovesales
on [Invoices].[TB_Sales]
after insert
as 
begin
-- -- تكلفه العنصر 
--declare @item_Cost decimal;
--select @item_Cost= TB_Sales.Items_Cost from Invoices.TB_Sales 
--join inserted i on i.sales_ID = TB_Sales.sales_ID

---- تم الحذف في trigger القيود والتكاليف
--delete   Items.Tb_ItemMove from Items.Tb_ItemMove
--join inserted i on i.AccFunction_Code = Tb_ItemMove.Funtion_ID
--where i.Items_ID = Tb_ItemMove.Items_ID
--and i.Department_ID = Tb_ItemMove.Department_ID

-- تسجيل الحركه الاصناف
insert into Items.Tb_ItemMove (Items_ID,Department_ID,ItemMove_Qty,ItemMove_Cost,Funtion_ID,Invoice_ID)
select i.Items_ID ,i.Department_ID,(-1*i.Customer_Qty) ,(-1*i.Items_Cost),i.AccFunction_Code,i.sales_ID from inserted i

----تحديث المخزون في القسم
--update Stores.TB_Departments set Dep_TotalBalance = Dep_TotalBalance - i. Customer_Qty 
--from Stores.TB_Departments dep
--join inserted i on i.Department_ID = dep.Department_ID

end;
go


alter Trigger invoices.Trg_update_ItemMovesales
on [Invoices].[TB_Sales]
after update
as 
begin
---- تسجيل الحركه الاصناف
--declare @item_Cost decimal;
--select @item_Cost= TB_Sales.Items_Cost from Invoices.TB_Sales 
--join inserted i on i.sales_ID = TB_Sales.sales_ID

---- تم الحذف في trigger القيود والتكاليف
--delete   Items.Tb_ItemMove from Items.Tb_ItemMove
--join inserted i on i.AccFunction_Code = Tb_ItemMove.Funtion_ID
--where i.Items_ID = Tb_ItemMove.Items_ID
--and i.Department_ID = Tb_ItemMove.Department_ID

insert into Items.Tb_ItemMove (Items_ID,Department_ID,ItemMove_Qty,ItemMove_Cost,Funtion_ID,Invoice_ID)
select i.Items_ID ,i.Department_ID,(-1*i.Customer_Qty) ,(-1*i.Items_Cost),i.AccFunction_Code,i.sales_ID from inserted i

----تحديث المخزون في القسم
--update Stores.TB_Departments set Dep_TotalBalance = Dep_TotalBalance - i. Customer_Qty 
--from Stores.TB_Departments dep 
--join inserted i on i.Department_ID = dep.Department_ID 
--join deleted de on de.Department_ID = dep.Department_ID

end;
go

alter trigger invoices.trg_DeleteSalesinvoice
on invoices.tb_sales
after delete
as
begin
-- حذف العناصر المرتبطه من tb_itemsMove
 -- حذف الحركه قبل الحصول علي التكلف
delete   Items.Tb_ItemMove from Items.Tb_ItemMove
join deleted i on i.sales_ID = Tb_ItemMove.Invoice_ID
where i.AccFunction_Code= Tb_ItemMove.Funtion_ID

end;
go

alter trigger invoices.trg_ReinsertSalesCost
on invoices.Tb_sales
instead of insert 
as
begin
-- حذف العناصر المرتبطه من tb_itemsMove
 -- حذف الحركه قبل الحصول علي التكلف
--delete   Items.Tb_ItemMove from Items.Tb_ItemMove
--join inserted i on i.AccFunction_Code = Tb_ItemMove.Funtion_ID
--where i.Items_ID = Tb_ItemMove.Items_ID
--and i.Department_ID = Tb_ItemMove.Department_ID
--and i.sales_ID = Tb_ItemMove.Invoice_ID


 declare @itemID int;
 Declare @DepartmentID int;
 select @itemID=Items_ID,@DepartmentID = Department_ID from inserted
    -- فحص الكميه المتاحه في القسم 
   declare @item_Balance int;
 select @item_Balance=Item_Qty from  items.fun_ItemCostAndBalanceINDepartment(@itemID,@DepartmentID)
 -- لو الكميه المراد اهلاكها اقل من 0 ايقاف الاضافه 
 declare @Item_order int ;
 select @Item_order =Customer_Qty from inserted

 if @item_Balance- @Item_order <0 
 begin
 RAISERROR (N'الكميه المتاحه لا تكفي لعمليه البيع', 16, 1);
 return;
 end;
  -- تكلفه العنصر 
  declare @costItem decimal(10,4) ;
  select @costItem= avg_Cost from  items.fun_ItemAvgCostINDepartment(@itemID,@DepartmentID)

  --ادخال قيمه Cost_Item في جمله الادخال
  insert into [Invoices].[TB_Sales]
           ([AccFunction_Code]
           ,[Customer_ID]
           ,[Customer_invoiceDate]
           ,[Customer_invoiceNo]
           ,[Department_ID]
           ,[Items_ID]
           ,[Unit_ID]
           ,[Customer_Note]
           ,[Customer_Qty]
           ,[Customer_price]
           ,[Items_Cost]
           ,[ISActive])
   
   select 
   [AccFunction_Code]
           ,[Customer_ID]
           ,[Customer_invoiceDate]
           ,[Customer_invoiceNo]
           ,[Department_ID]
           ,[Items_ID]
           ,[Unit_ID]
           ,[Customer_Note]
           ,[Customer_Qty]
           ,[Customer_price]
           ,@costItem
           ,[ISActive] from inserted 
end;
go

alter trigger invoices.trg_ReupdateSalesCost
on invoices.Tb_sales
instead of update 
as
begin
-- حذف العناصر المرتبطه من tb_itemsMove
 -- حذف الحركه قبل الحصول علي التكلف
delete   Items.Tb_ItemMove from Items.Tb_ItemMove
join inserted i on i.AccFunction_Code = Tb_ItemMove.Funtion_ID
where i.Items_ID = Tb_ItemMove.Items_ID
and i.Department_ID = Tb_ItemMove.Department_ID
and i.sales_ID = Tb_ItemMove.Invoice_ID

-- تقليل الكميه من balance tb_department


 declare @itemID int;
 Declare @DepartmentID int;
 select @itemID=Items_ID,@DepartmentID = Department_ID from inserted
    -- فحص الكميه المتاحه في القسم 
   declare @item_Balance int;
 select @item_Balance=Item_Qty from  items.fun_ItemCostAndBalanceINDepartment(@itemID,@DepartmentID)
 -- لو الكميه المراد اهلاكها اقل من 0 ايقاف الاضافه 
 declare @Item_order int ;
 select @Item_order =Customer_Qty from inserted

 if @item_Balance- @Item_order <0
 begin
 RAISERROR (N'الكميه المتاحه لا تكفي لعمليه البيع', 16, 1);
 end;
  -- تكلفه العنصر 
  declare @costItem decimal(10,4) ;
  select @costItem= avg_Cost from  items.fun_ItemAvgCostINDepartment(@itemID,@DepartmentID)

  --ادخال قيمه Cost_Item في جمله الادخال
  update TB_Sales set [AccFunction_Code] = i.AccFunction_Code
      ,[Customer_ID] = i.Customer_ID
      ,[Customer_invoiceDate] = i.Customer_invoiceDate
      ,[Customer_invoiceNo] = i.Customer_invoiceNo
      ,[Department_ID] = i.Department_ID
      ,[Items_ID] = i.Items_ID
      ,[Unit_ID] = i.Unit_ID
      ,[Customer_Note] = i.Customer_Note
      ,[Customer_Qty] = i.Customer_Qty 
      ,[Customer_price] = i.Customer_price
      ,[Items_Cost] = @costItem  
      ,[ISActive] = i.ISActive  
	  from tb_sales
	  join inserted i on tb_sales.sales_id = i.sales_id
end;
go

alter trigger Invoices.Trg_insert_Sales_Function
--اضافه قيد المبيعات
on [Invoices].Tb_sales
after insert
as
begin
--حذف القيد القديم
declare @function_Code int; 
select @function_Code= accfunction_code from inserted
Exec Accounts.DeleteFunction @functionCode=@function_Code
--اضافه قيد جديد --
-- اضافه الجانب المدين --
insert into Accounts.AccountFunction(AccFunction_Depit,
AccFunction_Credit,
AccFunction_Note,
AccFunction_Code,
AccountSub_Code,
AccFunction_Date)
select purchase_price,
0,
Customer_invoiceNo +'فاتوره مبيعات رقم',
AccFunction_Code,
Customer_ID,
FunctionDate  
 from invoices.View_InvoiceSales_FunDepit
  where AccFunction_Code= @function_Code
--اضافه الجانب الدائن--
insert into Accounts.AccountFunction(AccFunction_Depit,
AccFunction_Credit,
AccFunction_Note,
AccFunction_Code,
AccountSub_Code,
AccFunction_Date)
select 0,
purchase_price,
Customer_invoiceNo +'فاتوره مبيعات رقم',
AccFunction_Code,
660001,
FunctionDate from 
 invoices.View_InvoiceSales_FunCredit
   where AccFunction_Code= @function_Code
-- -- فيد تكلفه المبيعات
-- -- تكلفه العنصر 
-- declare @itemID int;
-- Declare @DepartmentID int;
-- select @itemID=Items_ID,@DepartmentID = Department_ID from inserted

--  declare @costItem int ;
--  select @costItem= Item_Cost from  items.fun_ItemCostAndBalanceINDepartment(@itemID,@DepartmentID)

---- حفظ التكلفه العنصر في فاتوره المشتريات
--update TB_Sales set Items_Cost = @costItem 
--from TB_Sales 
--join inserted i on i.sales_ID = TB_Sales.sales_ID



--قيد التكلفه اضافه الجانب المدين --
insert into Accounts.AccountFunction(AccFunction_Depit,
AccFunction_Credit,
AccFunction_Note,
AccFunction_Code,
AccountSub_Code,
AccFunction_Date)
select item_Cost,
0,
Customer_invoiceNo +'تكلفه المبيعات لفاتوره رقم',
AccFunction_Code,
1020021,
FunctionDate  
 from invoices.View_InvoiceSales_FunDepit
    where AccFunction_Code= @function_Code
--قيد التكلفه اضافه الجانب الدائه --
insert into Accounts.AccountFunction(AccFunction_Depit,
AccFunction_Credit,
AccFunction_Note,
AccFunction_Code,
AccountSub_Code,
AccFunction_Date)
select 0,
Item_Cost,
Customer_invoiceNo +'تكلفه المبيعات لفاتوره رقم',
AccFunction_Code,
Store_ID,
FunctionDate from 
 invoices.View_InvoiceSales_FunCredit
    where AccFunction_Code= @function_Code
 -- تعديل نوع القيد الي المبيعات
 update Accounts.AccountFunctionCode set AccFunction_type = 'مبيعات'
 from Accounts.AccountFunctionCode code
 join inserted i on code.AccountFun_Code = i.AccFunction_Code
end;

go

alter trigger Invoices.Trg_Update_Sales_Function
--اضافه قيد المبيعات
on [Invoices].Tb_sales
after update
as
begin
--حذف القيد القديم
declare @function_Code int; 
select @function_Code= accfunction_code from inserted
Exec Accounts.DeleteFunction @functionCode=@function_Code
--اضافه قيد جديد --
-- اضافه الجانب المدين --
insert into Accounts.AccountFunction(AccFunction_Depit,
AccFunction_Credit,
AccFunction_Note,
AccFunction_Code,
AccountSub_Code,
AccFunction_Date)
select purchase_price,
0,
Customer_invoiceNo +'فاتوره مبيعات رقم',
AccFunction_Code,
Customer_ID,
FunctionDate  
 from invoices.View_InvoiceSales_FunDepit
   where AccFunction_Code= @function_Code
--اضافه الجانب الدائن--
insert into Accounts.AccountFunction(AccFunction_Depit,
AccFunction_Credit,
AccFunction_Note,
AccFunction_Code,
AccountSub_Code,
AccFunction_Date)
select 0,
purchase_price,
Customer_invoiceNo +'فاتوره مبيعات رقم',
AccFunction_Code,
660001,
FunctionDate from 
 invoices.View_InvoiceSales_FunCredit
    where AccFunction_Code= @function_Code
 -- فيد تكلفه المبيعات
 -- حذف للبنود المضافه من عنصر قبل التعديل من جدول tb_itemsmove
-- -- حذف الحركه قبل الحصول علي التكلف
--delete   Items.Tb_ItemMove from Items.Tb_ItemMove
--join inserted i on i.AccFunction_Code = Tb_ItemMove.Funtion_ID
--where i.Items_ID = Tb_ItemMove.Items_ID
--and i.Department_ID = Tb_ItemMove.Department_ID

 ---- تكلفه العنصر 
 --declare @itemID int;
 --Declare @DepartmentID int;
 --select @itemID=Items_ID,@DepartmentID = Department_ID from inserted

 -- declare @costItem int ;
 -- select @costItem= Item_Cost from  items.fun_ItemCostAndBalanceINDepartment(@itemID,@DepartmentID)

-- حفظ التكلفه العنصر في فاتوره المشتريات
--update TB_Sales set Items_Cost = @costItem 
--from TB_Sales 
--join inserted i on i.sales_ID = TB_Sales.sales_ID



--قيد التكلفه اضافه الجانب المدين --
insert into Accounts.AccountFunction(AccFunction_Depit,
AccFunction_Credit,
AccFunction_Note,
AccFunction_Code,
AccountSub_Code,
AccFunction_Date)
select item_Cost,
0,
Customer_invoiceNo +'تكلفه المبيعات لفاتوره رقم',
AccFunction_Code,
1020021,
FunctionDate  
 from invoices.View_InvoiceSales_FunDepit
    where AccFunction_Code= @function_Code
--قيد التكلفه اضافه الجانب الدائه --
insert into Accounts.AccountFunction(AccFunction_Depit,
AccFunction_Credit,
AccFunction_Note,
AccFunction_Code,
AccountSub_Code,
AccFunction_Date)
select 0,
Item_Cost,
Customer_invoiceNo +'تكلفه المبيعات لفاتوره رقم',
AccFunction_Code,
Store_ID,
FunctionDate from 
 invoices.View_InvoiceSales_FunCredit
    where AccFunction_Code= @function_Code
 -- تعديل نوع القيد الي المبيعات
 update Accounts.AccountFunctionCode set AccFunction_type = 'مبيعات'
 from Accounts.AccountFunctionCode code
 join inserted i on code.AccountFun_Code = i.AccFunction_Code


end;
go

alter trigger Invoices.Trg_Delete_Sales_Function
--اضافه قيد المبيعات
on [Invoices].Tb_sales
after delete
as
begin
--حذف القيد القديم
declare @function_Code int; 
select @function_Code= accfunction_code from deleted
Exec Accounts.DeleteFunction @functionCode=@function_Code
--اضافه قيد جديد --
-- اضافه الجانب المدين --
insert into Accounts.AccountFunction(AccFunction_Depit,
AccFunction_Credit,
AccFunction_Note,
AccFunction_Code,
AccountSub_Code,
AccFunction_Date)
select purchase_price,
0,
Customer_invoiceNo +'فاتوره مبيعات رقم',
AccFunction_Code,
Customer_ID,
FunctionDate  
 from invoices.View_InvoiceSales_FunDepit
   where AccFunction_Code= @function_Code
--اضافه الجانب الدائن--
insert into Accounts.AccountFunction(AccFunction_Depit,
AccFunction_Credit,
AccFunction_Note,
AccFunction_Code,
AccountSub_Code,
AccFunction_Date)
select 0,
purchase_price,
Customer_invoiceNo +'فاتوره مبيعات رقم',
AccFunction_Code,
660001,
FunctionDate from 
 invoices.View_InvoiceSales_FunCredit
    where AccFunction_Code= @function_Code
 -- فيد تكلفه المبيعات
 -- حذف للبنود المضافه من عنصر قبل التعديل من جدول tb_itemsmove
-- -- حذف الحركه قبل الحصول علي التكلف
--delete   Items.Tb_ItemMove from Items.Tb_ItemMove
--join inserted i on i.AccFunction_Code = Tb_ItemMove.Funtion_ID
--where i.Items_ID = Tb_ItemMove.Items_ID
--and i.Department_ID = Tb_ItemMove.Department_ID

 ---- تكلفه العنصر 
 --declare @itemID int;
 --Declare @DepartmentID int;
 --select @itemID=Items_ID,@DepartmentID = Department_ID from inserted

 -- declare @costItem int ;
 -- select @costItem= Item_Cost from  items.fun_ItemCostAndBalanceINDepartment(@itemID,@DepartmentID)

-- حفظ التكلفه العنصر في فاتوره المشتريات
--update TB_Sales set Items_Cost = @costItem 
--from TB_Sales 
--join inserted i on i.sales_ID = TB_Sales.sales_ID



--قيد التكلفه اضافه الجانب المدين --
insert into Accounts.AccountFunction(AccFunction_Depit,
AccFunction_Credit,
AccFunction_Note,
AccFunction_Code,
AccountSub_Code,
AccFunction_Date)
select item_Cost,
0,
Customer_invoiceNo +'تكلفه المبيعات لفاتوره رقم',
AccFunction_Code,
1020021,
FunctionDate  
 from invoices.View_InvoiceSales_FunDepit
    where AccFunction_Code= @function_Code
--قيد التكلفه اضافه الجانب الدائه --
insert into Accounts.AccountFunction(AccFunction_Depit,
AccFunction_Credit,
AccFunction_Note,
AccFunction_Code,
AccountSub_Code,
AccFunction_Date)
select 0,
Item_Cost,
Customer_invoiceNo +'تكلفه المبيعات لفاتوره رقم',
AccFunction_Code,
Store_ID,
FunctionDate from 
 invoices.View_InvoiceSales_FunCredit
    where AccFunction_Code= @function_Code
 -- تعديل نوع القيد الي المبيعات
 update Accounts.AccountFunctionCode set AccFunction_type = 'مبيعات'
 from Accounts.AccountFunctionCode code
 join deleted i on code.AccountFun_Code = i.AccFunction_Code


end;
go
-------------------------------------------
--Trigger USers
-------------------------------------------
alter Trigger Users.AddNew_USerPermession
--اضافه الصلاحيات كلها للمستخدم ولكن بقيمه false
on  [Users].[TB_Users]
after insert
As 
Begin

Declare @New_User_ID int;
select @New_User_ID=Users_ID from inserted
--اضافه صلاحيات user ب Null في بدايه الاضافه
insert into [Users].[TB_UsersPermission] (users_ID,userperType_ID) 
select @New_User_ID ,userperType_ID from [Users].[TB_UsersPermissionType]
 End;
 Go 
         
------------------------------------------
------------------------------------------
--views--
--كل الحركات
alter view stores.view_storesDepartmentitems
--كل الحركات
as
select item.Items_ID,
item.Items_Code,
item.Items_NameAR,
TB_Unit.Unit_Name,
item.Items_pricesale,
TB_CategoryOne.CategoryOne_Name,
CategoryTwo_Name,
CategoryThree_Name,
CategoryFour_Name,
TB_Departments.Department_ID,
TB_Departments.Department_Name,
TB_Stores.Store_Name ,
Tb_ItemMove.ItemMove_Qty as 'Item_Qty',
tb_ItemMove.ItemMove_Cost as 'Item_Cost',
Tb_ItemMove.Funtion_ID as 'function_ID'

 from Items.TB_Items item
right join Items.TB_Unit on item.Unit_ID = TB_Unit.Unit_ID 
right join Items.TB_CategoryOne on item.CategoryOne_ID = TB_CategoryOne.CategoryOne_ID
right join Items.TB_CategoryTwo on item.CategoryTwo_ID = TB_CategoryTwo.CategoryTwo_ID
right join Items.TB_CategoryThree on item.CategoryThree_ID = TB_CategoryThree.CategoryThree_ID
right join Items.TB_CategoryFour on item.CategoryFour_ID = TB_CategoryFour.CategoryFour_ID
right join Items.Tb_ItemMove on item.Items_ID = Tb_ItemMove.Items_ID
left join Stores.TB_Departments on Tb_ItemMove.Department_ID= TB_Departments.Department_ID 
left join Stores.TB_Stores on TB_Departments.Store_ID= TB_Stores.Store_ID

go
alter view Users.view_Users
as
select 
		[users_ID]
      ,[user_NameAr]
      ,[user_NameEn]
      ,[user_userName]
      ,[user_password]
      ,TB_Users.userType_ID
      ,[user_IsActive]
	  ,TB_UsersType.userType_Name
 from 
		Users.TB_Users
left join Users.TB_UsersType on TB_Users.userType_ID = TB_UsersType.userType_ID
go 

alter view Items.view_items
--كل الحركات
as
select item.Items_ID,
item.Items_Code,
item.Items_NameAR,
Item.Items_NameEn,
TB_Unit.Unit_ID,
TB_Unit.Unit_Name,
item.Items_pricesale,
TB_CategoryOne.CategoryOne_ID,
TB_CategoryOne.CategoryOne_Name,
TB_CategoryTwo.CategoryTwo_ID,
TB_CategoryTwo.CategoryTwo_Name,
TB_CategoryThree.CategoryThree_ID,
CategoryThree_Name,
TB_CategoryFour.Categoryfour_ID,
TB_CategoryFour.CategoryFour_Name
  from Items.TB_Items item
left join Items.TB_Unit on item.Unit_ID = TB_Unit.Unit_ID 
left join Items.TB_CategoryOne on item.CategoryOne_ID = TB_CategoryOne.CategoryOne_ID
left join Items.TB_CategoryTwo on item.CategoryTwo_ID = TB_CategoryTwo.CategoryTwo_ID
left join Items.TB_CategoryThree on item.CategoryThree_ID = TB_CategoryThree.CategoryThree_ID
left join Items.TB_CategoryFour on item.CategoryFour_ID = TB_CategoryFour.CategoryFour_ID
 
go
----------------------------------------
-- قيود المبيعات 
-----------------------------------------
alter view invoices.View_InvoiceSales_FunCredit
-- عرض الجانب الدائن للقيد المبيعات 
as
select sum(Customer_price * Customer_Qty) as purchase_price,
sum(Items_Cost * Customer_Qty) as Item_Cost ,
AccFunction_Code,
dep.Store_ID,

Customer_invoiceNo,
FORMAT(GETDATE(),'yyyy-MM-dd')as FunctionDate
 from [Invoices].TB_Sales pur
 join Stores.TB_Departments dep on dep.Department_ID =  pur.Department_ID
 group by   AccFunction_Code,Store_ID ,Customer_invoiceNo
 go

alter view invoices.View_InvoiceSales_FunDepit
-- عرض الجانب المدين للقيد المبيعات 
as
select sum(Customer_price * Customer_Qty) as purchase_price,
sum(Items_Cost* Customer_Qty) as item_Cost ,
AccFunction_Code,
Customer_ID,
Customer_invoiceNo,
FORMAT(GETDATE(),'yyyy-MM-dd')as FunctionDate
 from [Invoices].TB_Sales pur
 group by   AccFunction_Code,Customer_ID ,Customer_invoiceNo
 go
 -----------------------------------------
 ------------------------------------------
 -- قيود التحويلات 
 ------------------------------------------
 create view invoices.View_InvoiceTransfar_FunCredit
-- عرض الجانب الدائن للقيد للتحويلات 
as
select  
sum(Transfar_cost * Transfar_Qty) as Item_Cost ,
AccFunction_Code,
dep.Store_ID,

Transfar_invoiceNo,
FORMAT(GETDATE(),'yyyy-MM-dd')as FunctionDate
 from [Invoices].TB_Transfar pur
 join Stores.TB_Departments dep on dep.Department_ID =  pur.Department_ID
 group by   AccFunction_Code,Store_ID ,Transfar_invoiceNo
 go

  create view invoices.View_InvoiceTransfar_FunDepit
-- عرض الجانب المدين للقيد للتحويلات 
as
select  
sum(Transfar_cost * Transfar_Qty) as Item_Cost ,
AccFunction_Code,
dep.Store_ID,
Transfar_invoiceNo,
FORMAT(GETDATE(),'yyyy-MM-dd')as FunctionDate
 from [Invoices].TB_Transfar pur
 join Stores.TB_Departments dep on dep.Department_ID =  pur.Department_IDIN
 group by   AccFunction_Code,Store_ID ,Transfar_invoiceNo
 go

 ---------------------------------------
 --قيود المصروفات
 -----------------------------------------
 alter view invoices.View_InvoicePayment_FunDepit
-- عرض الجانب المدين للقيد المصروفات 
as
select sum(payment_Amount) as payment_Amount,
AccFunction_Code,
dep.Store_ID,
payment_invoiceNo,
FORMAT(GETDATE(),'yyyy-MM-dd')as FunctionDate
 from [Accounts].[TB_payments] pur
 join Stores.TB_Departments dep on dep.Department_ID =  pur.Department_ID
 --join Stores.TB_Departments st on pur.Store_IDs = st.Store_ID
 group by   AccFunction_Code,dep.Store_ID ,payment_invoiceNo
 union all
 select sum(payment_Amount) as payment_Amount,
AccFunction_Code,
st.Store_ID,
payment_invoiceNo,
FORMAT(GETDATE(),'yyyy-MM-dd')as FunctionDate
 from [Accounts].[TB_payments] pur
 --join Stores.TB_Departments dep on dep.Department_ID =  pur.Department_ID
 join Stores.TB_Stores st on  st.Store_ID=pur.Store_IDs 
 group by   AccFunction_Code,st.Store_ID ,payment_invoiceNo;
 go


  alter view invoices.View_InvoicePayment_FunCreadit
-- عرض الجانب الدائن للقيد المصروفات 
as
select sum(payment_Amount) as payment_Amount,
AccFunction_Code,
AccountSub_Code,
payment_invoiceNo,
FORMAT(GETDATE(),'yyyy-MM-dd')as FunctionDate
 from [Accounts].[TB_payments] pur
 group by   AccFunction_Code,AccountSub_Code ,payment_invoiceNo
 go
 ----------------------------------------
-- قيود المشتريات 
-----------------------------------------

alter view invoices.View_Invoicepurchase_FunDepit
-- عرض الجانب المدين للقيد المشتريات 
as
select sum(purchase_price* purchase_Qty) as purchase_price,
AccFunction_Code,

dep.Store_ID,
purchase_invoiceNo,
FORMAT(GETDATE(),'yyyy-MM-dd')as FunctionDate
 from [Invoices].[TB_Purchases] pur
 join Stores.TB_Departments dep on dep.Department_ID =  pur.Department_ID
 group by   AccFunction_Code,Store_ID ,purchase_invoiceNo
 go

 alter view invoices.View_Invoicepurchase_FunCreadit
-- عرض الجانب الدائن للقيد المشتريات 
as
select sum(purchase_price*purchase_Qty) as purchase_price,
AccFunction_Code,
supplier_ID,
purchase_invoiceNo,
FORMAT(GETDATE(),'yyyy-MM-dd')as FunctionDate
 from [Invoices].[TB_Purchases] pur
 group by   AccFunction_Code,supplier_ID ,purchase_invoiceNo
 go

create view Stores.view_DepartmentandStores
--عرض كل المخازن والاقسام التابعه لها 
as
select 
Department_ID,
Department_Name,
Department_Note,
TB_Stores.Store_ID,
Store_Name,
Store_Location,
store_IsActive
 from Stores.TB_Departments
right join Stores.TB_Stores on TB_Departments.Store_ID = TB_Stores.Store_ID
go
***************************************
alter view Invoices.View_PurchaseInvoics
as
select
[purchase_ID]
      ,[AccFunction_Code]
      ,TB_Purchases.supplier_ID
	  ,TB_Suppliers.supplier_Name
      ,[purchase_invoiceDate]
      ,[purchase_invoiceNo]
      ,tb_purchases.[Department_ID]
	  ,TB_Departments.Store_ID
      ,tb_items.[Items_ID]
	  ,TB_Items.Items_Code
	  ,TB_Items.Items_NameAR
      ,tb_purchases.[Unit_ID]
	  ,tb_unit.unit_name
      ,[purchase_Note]
      ,[purchase_Qty]
      ,[purchase_price]
      ,TB_Purchases.Items_Cost
      ,[ISActive] 
 from invoices.TB_Purchases
 left join personal.TB_Suppliers on TB_Purchases.supplier_ID = TB_Suppliers.supplier_ID
 left join Stores.TB_Departments on TB_Purchases.Department_ID = TB_Departments.Department_ID
 left join Items.TB_Items on TB_Purchases.Items_ID= TB_Items.Items_ID
 left join Items.TB_Unit on TB_Purchases.Unit_ID = TB_Unit.Unit_ID

 go

 create view Invoices.View_SalesInvoics
as
select
		[sales_ID]
      ,[AccFunction_Code]
      ,TB_Customers.Customer_ID
	  ,TB_Customers.Customer_Name
      ,[Customer_invoiceDate]
      ,[Customer_invoiceNo]
      ,TB_Sales.[Department_ID]
	  ,TB_Departments.Store_ID
      ,tb_items.[Items_ID]
	  ,TB_Items.Items_Code
	  ,TB_Items.Items_NameAR
      ,TB_Sales.[Unit_ID]
	  ,tb_unit.unit_name
      ,[Customer_Note]
      ,[Customer_Qty]
      ,[Customer_price]
      ,TB_Sales.Items_Cost
      ,[ISActive] 
 from invoices.TB_Sales
 left join personal.TB_Customers on TB_Sales.Customer_ID = TB_Customers.Customer_ID
 left join Stores.TB_Departments on TB_Sales.Department_ID = TB_Departments.Department_ID
 left join Items.TB_Items on TB_Sales.Items_ID= TB_Items.Items_ID
 left join Items.TB_Unit on TB_Sales.Unit_ID = TB_Unit.Unit_ID

 go

  alter view Accounts.View_PaymentsInvoics
as
select
		payment_ID
      ,[AccFunction_Code]
      ,payment_Date
      ,payment_invoiceNo
	  ,tb_payments.AccountSub_Code
	  ,AccountSub_Name
      ,TB_payments.Department_ID
	  , Department_Name
	  ,TB_payments.Store_IDs
	  ,Store_Name
	  ,TB_Departments.Store_ID 
      ,payment_Note
      ,payment_Amount
 from Accounts.TB_payments
 left join Stores.TB_Departments on TB_payments.Department_ID = TB_Departments.Department_ID
 left join Stores.TB_Stores on TB_payments.Store_IDs= TB_Stores.Store_ID
 left join Accounts.TB_AccountsSub on TB_payments.AccountSub_Code = TB_AccountsSub.AccountSub_Code
 go


  create view Invoices.View_TransfarInvoics
as
select
		Transfar_ID
      ,[AccFunction_Code]
      ,Transfar_invoiceDate
      ,Transfar_invoiceNo
      ,TB_Transfar.[Department_ID] as Department_out
	  ,department_out.Store_ID as store_out
	  ,tb_Transfar.Department_IDIN
	  ,department_in.Store_ID as store_In
      ,tb_items.[Items_ID]
	  ,TB_Items.Items_Code
	  ,TB_Items.Items_NameAR
      ,TB_Transfar.[Unit_ID]
	  ,tb_unit.unit_name
      ,Transfar_note
      ,[Transfar_Qty]
      ,[Transfar_cost]
      ,[ISActive] 
 from invoices.TB_Transfar
 left join Stores.TB_Departments as department_out on TB_Transfar.Department_ID = department_out.Department_ID
 left join Stores.TB_Departments department_in on TB_Transfar.Department_IDIN = department_in.Department_ID
 left join Items.TB_Items on TB_Transfar.Items_ID= TB_Items.Items_ID
 left join Items.TB_Unit on TB_Transfar.Unit_ID = TB_Unit.Unit_ID

 go

 create view Invoices.View_DeprecationInvoics
as
select
		Depreciation_ID
      ,[AccFunction_Code]
      ,Depreciation_invoiceDate
      ,TB_Departments.[Department_ID]
	  ,TB_Departments.Store_ID
      ,tb_items.[Items_ID]
	  ,TB_Items.Items_Code
	  ,TB_Items.Items_NameAR
      ,TB_Depreciation.[Unit_ID]
	  ,tb_unit.unit_name
      ,Depreciation_Case
      ,Depreciation_Qty
      ,Depreciation_cost
      ,[ISActive] 
 from invoices.TB_Depreciation
 left join Stores.TB_Departments on TB_Depreciation.Department_ID = TB_Departments.Department_ID
 left join Items.TB_Items on TB_Depreciation.Items_ID= TB_Items.Items_ID
 left join Items.TB_Unit on TB_Depreciation.Unit_ID = TB_Unit.Unit_ID

 go
 ----------------------------
-- procedures--
----------------------------------
create procedure invoices.Delete_salesInvoice
				@sales_ID int
as
begin
delete TB_Sales 
where sales_ID = @sales_ID
end;

create procedure invoices.Delete_TransInvoice
				@Transfar_ID int
as
begin
delete TB_Transfar 
where Transfar_ID = @Transfar_ID
end;

create procedure invoices.Delete_DeprecationInvoice
				@Depreciation_ID int
as
begin
delete TB_Depreciation 
where Depreciation_ID = @Depreciation_ID

end;

create procedure invoices.Delete_PurchaseInvoice
				@Purchase_ID int
as
begin
delete TB_Purchases 
where purchase_ID = @Purchase_ID 
end;

alter procedure personal.pro_View_Supplier_Code
		@Supplier_Code nvarchar (max)
as
begin
  select [supplier_ID]
      ,[supplier_Name]
      ,[supplier_phone]
      ,[supplier_fax]
      ,[supplier_Email]
      ,[supplier_Address]
      ,[supplier_ISActive]
	  ,TB_Country.country_ID
	  ,Country_Name
	  ,Country_PhoneKey
	   from personal.TB_Suppliers
	  left join TB_Country on TB_Suppliers.country_ID= TB_Country.country_ID
where cast( supplier_ID as nvarchar) like  '%'+@Supplier_Code+'%' 
 order by supplier_ID
end;
go

alter procedure personal.pro_View_Supplier_Name
		@Supplier_Name nvarchar(Max)
as
begin
  select [supplier_ID]
      ,[supplier_Name]
      ,[supplier_phone]
      ,[supplier_fax]
      ,[supplier_Email]
      ,[supplier_Address]
      ,[supplier_ISActive]
	  ,TB_Country.country_ID
	  ,Country_Name
	  ,Country_PhoneKey from personal.TB_Suppliers
	  left join TB_Country on TB_Suppliers.country_ID = TB_Country.country_ID
where supplier_Name like  '%'+@Supplier_Name+'%' 
 order by supplier_Name
end;
go
---------------------------------------------------
create procedure personal.pro_View_Customer_Code
		@Customer_Code nvarchar (max)
as
begin
  select [customer_ID]
      ,[customer_Name]
      ,[customer_phone]
      ,[customer_fax]
      ,[customer_Email]
      ,[customer_Address]
      ,[customer_ISActive]
	  ,TB_Country.country_ID
	  ,Country_Name
	  ,Country_PhoneKey
	   from personal.TB_Customers
	  left join TB_Country on TB_Customers.country_ID= TB_Country.country_ID
where cast( customer_ID as nvarchar) like  '%'+@Customer_Code+'%' 
 order by customer_ID
end;
go

create procedure personal.pro_View_Customer_Name
		@Customer_Name nvarchar(Max)
as
begin
  select [Customer_ID]
      ,[Customer_Name]
      ,[Customer_phone]
      ,[Customer_fax]
      ,[Customer_Email]
      ,[Customer_Address]
      ,[Customer_ISActive]
	  ,TB_Country.country_ID
	  ,Country_Name
	  ,Country_PhoneKey from personal.TB_Customers
	  left join TB_Country on TB_Customers.country_ID = TB_Country.country_ID
where Customer_Name like  '%'+@Customer_Name+'%' 
 order by Customer_Name
end;
go
-----------------------------------------
alter procedure Items.pro_View_Items_Code
		@Items_Code nvarchar(max)
as
begin
  select * from Items.view_items
where Items_Code like  '%'+@Items_Code+'%' 
 order by Items_Code
end;
go

alter procedure Items.Pro_View_Items_NameAr
		@Items_NameAr nvarchar(max)
as
begin
select * from Items.view_items
where Items_NameAR like '%'+ @Items_NameAr +'%'
order by Items_NameAR
end;
go

alter procedure Items.Pro_View_Items_NameEn
		@Items_NameEn nvarchar(max)
as
begin
select * from Items.view_items
where Items_NameEn like '%'+ @Items_NameEn +'%'
order by Items_NameEn
end;
go

alter procedure Items.pro_view_Units
as 
begin
select * from Items.TB_Unit
order by Unit_ID
end;
go

alter procedure Items.pro_view_items
as
begin
select * from Items.view_items
 order by Items_ID
end;
go

exec users.pro_view_Users

create procedure users.pro_view_Users
as
begin
select * from Users.view_Users
 order by users_ID
end;
go

create procedure Stores.pro_View_DepartmentandStores
as
begin
select * from Stores.view_DepartmentandStores
end
go
alter procedure Items.pro_View_CategoryOne
as
begin
select * from Items.TB_CategoryOne
order by CategoryOne_ID
end;
go

alter procedure Items.pro_View_CategoryTwo
as
begin
select * from Items.TB_CategoryTwo
order by CategoryTwo_ID
end;
go
alter procedure Items.pro_View_CategoryThree
as
begin
select * from Items.TB_CategoryThree
order by CategoryThree_ID
end;
go
alter procedure Items.pro_View_CategoryFour
as
begin
select * from Items.TB_CategoryFour
order by CategoryFour_ID
end;
go
create procedure Accounts.DeleteFunction
 @functionCode int
as
-- حذف function -- حذف قيد بناءا علي رقم القيد
begin
delete Accounts.AccountFunction where AccFunction_Code= @FunctionCode
end;
go

alter procedure Accounts.viewpaymentsAccounts
as
begin
declare @Acc_general int;
select @Acc_general=AccountGen_ID from Accounts.TB_AccountsGeneral 
where AccountGen_NameAr ='المصروفات'

select [AccountSub_ID]
      ,[AccountSub_Code]
      ,TB_AccountsSub.[AccountGen_ID]
	,AccountGen_NameAr
      ,[AccountSub_Name]
      ,[AccountSub_ISActive] from [Accounts].[TB_AccountsSub]
	  left join TB_AccountsGeneral on TB_AccountsGeneral.AccountGen_ID = TB_AccountsSub.AccountGen_ID
	  where TB_AccountsSub.[AccountGen_ID]= @Acc_general
end;
go

create procedure Accounts.AddNewPayment
@paymentName nvarchar(150),
@IsActive bit = 1
-- اضافه مصروف جديد للحسابات tb_accountsub

As
Begin
-- الحصول علي رقم الحساب الرئيسي للمصروفات
declare @Acc_general int;
select @Acc_general=AccountGen_ID from Accounts.TB_AccountsGeneral 
where AccountGen_NameAr ='المصروفات'

-- استقبال قيمه رقم الحساب الجديد
declare @AccountSub_Code int;
select @AccountSub_Code= Invoices.fun_NewAccountSub_Payment_Code(@Acc_general);

-- حفظ حساب المصروف الجديد 
insert into  [Accounts].[TB_AccountsSub]
           ([AccountSub_Code]
           ,[AccountGen_ID]
           ,[AccountSub_Name]
           ,[AccountSub_ISActive])
		   values
		   (@AccountSub_Code
		   ,@Acc_general
		   ,@paymentName
		   ,@IsActive
		   );
end
go

create procedure Accounts.Update_Payment
@paymentName nvarchar(150),
@IsActive bit = 1,
@AccountSub_ID int
-- اضافه مصروف جديد للحسابات tb_accountsub

As
Begin
-- حفظ حساب المصروف الجديد 
UPDATE [Accounts].[TB_AccountsSub]
   SET
      [AccountSub_Name] = @paymentName 
      ,[AccountSub_ISActive] = @IsActive 
 WHERE AccountSub_ID = @AccountSub_ID
end
go
--------------------------------------------------------
INSERT INTO [Users].[TB_UsersType]
           ([userType_Name])
     VALUES
           ('Admin')
		   ,('Accountant')
		   ,('Manger');
go


 create procedure Accounts.funNew_Function_NO
 @Function_Code int output
 --توليد رقم function جيد لاستعماله في invoices.procedure
 
 as 
 begin 
 
 select @Function_Code = Max(AccountFun_Code) 
 from Accounts.AccountFunctionCode
 
 --الرقم الجديد حفظه
 set @function_Code=isnull (@function_Code,0) +1 ;

 insert into Accounts.AccountFunctionCode (AccountFun_Code)
 values (@function_Code);

 return @function_Code ;
 End;
 go
---------------------------------------
create procedure stores.NewStore
--حفظ مستودع جديد 
	@storeName nvarchar(30),
	@storeLocateion nvarchar(30)=null,
	@isActive bit =1

	as
	begin
--حفظ بيانات المخزن الجديد والعوده برقم 1 عند الحفظ
 insert into [Stores].[TB_Stores]
           ([Store_Name]
           ,[Store_Location]
           ,[store_IsActive])
     VALUES
           (@storeName,
		   @storeLocateion,
		   @isActive
		   );
	End;
GO

alter procedure stores.UpdateStore
--تعديل مستودع جديد 
	@storeName nvarchar(30),
	@storeLocateion nvarchar(30)=null,
	@isActive bit =1,
	@ID_store int
	as
	begin
--تعديل بيانات المخزن الجديد والعوده برقم 1 عند الحفظ
 UPDATE [Stores].[TB_Stores]
   SET [Store_Name] = @storeName 
      ,[Store_Location] = @storeLocateion 
      ,[store_IsActive] = @isActive 
 WHERE Store_ID= @ID_store
	End;
GO
--------------------------------------
alter procedure stores.NewDepartment
--حفظ قسم جديد 
			@Department_Name nvarchar(20)
           ,@Department_Note nvarchar(30)
           ,@Store_ID int
           ,@Dep_TotalBalance int =0


	as
	begin
--حفظ بيانات قسم الجديد والعوده برقم 1 عند الحفظ
INSERT INTO [Stores].[TB_Departments]
           ([Department_Name]
           ,[Department_Note]
           ,[Store_ID]
           ,[Dep_TotalBalance])
     VALUES
           (@Department_Name
           ,@Department_Note
           ,@Store_ID
           ,@Dep_TotalBalance);
	End;
GO

alter procedure stores.UpdateDepartment
--تعديل قسم جديد 
			@Department_Name nvarchar(20)
           ,@Department_Note nvarchar(30)=Null
           ,@Store_ID int
		   ,@Department_ID int


	as
	begin
--تعديل بيانات قسم الجديد والعوده برقم 1 عند الحفظ
UPDATE [Stores].[TB_Departments]
   SET [Department_Name] = @Department_Name 
      ,[Department_Note] = @Department_Note 
      ,[Store_ID] = @Store_ID 
 
 WHERE Department_ID =@Department_ID
	End;
GO
--------------------------------------------
alter procedure Accounts.AddNew_Payment_Invoice
-- اضافه فاتوره مصاريف جديده
		  @payment_Date  date 
           ,@payment_invoiceNo  nvarchar(10) 
           ,@AccountSub_Code  int 
           ,@Department_ID  int =Null
           ,@Store_IDs  int =Null
           ,@payment_Amount  decimal(18,3) 
           ,@payment_Note  nvarchar(500 )=Null
           ,@AccFunction_Code  int 
		   As
		   Begin
INSERT INTO [Accounts].[TB_payments]
           ([payment_Date]
           ,[payment_invoiceNo]
           ,[AccountSub_Code]
           ,[Department_ID]
           ,[Store_IDs]
           ,[payment_Amount]
           ,[payment_Note]
           ,[AccFunction_Code])
     VALUES
           (@payment_Date 
           ,@payment_invoiceNo 
           ,@AccountSub_Code 
           ,@Department_ID 
           ,@Store_IDs 
           ,@payment_Amount 
           ,@payment_Note 
           ,@AccFunction_Code )

		   End;
go

create procedure Accounts.Update_Payment_Invoice
--تعديل فاتوره مصروفات 
		  @payment_Date  date 
           ,@payment_invoiceNo  nvarchar(10) 
           ,@AccountSub_Code  int 
           ,@Department_ID  int =Null
           ,@Store_IDs  int =Null
           ,@payment_Amount  decimal(18,3) 
           ,@payment_Note  nvarchar(500 )=Null
           ,@AccFunction_Code  int 
		   ,@payment_ID int
		   As
		   Begin
UPDATE [Accounts].[TB_payments]
   SET [payment_Date] = @payment_Date 
      ,[payment_invoiceNo] = @payment_invoiceNo 
      ,[AccountSub_Code] = @AccountSub_Code 
      ,[Department_ID] = @Department_ID 
      ,[Store_IDs] = @Store_IDs 
      ,[payment_Amount] = @payment_Amount 
      ,[payment_Note] = @payment_Note 
      ,[AccFunction_Code] = @AccFunction_Code 
 WHERE payment_ID=@payment_ID
		   End;
go

create procedure Accounts.Delete_Payment_Invoice
--حذف مصروفات 
		@payment_ID int
		As
		begin
	DELETE FROM [Accounts].[TB_payments]
      WHERE payment_ID= @payment_ID;
	  End;


---------------------------------------------------

create procedure Items.AddNew_CategoryOne
-- اضافه كاتوجري أولي
			@CategoryOne_Name nvarchar(100)

		As 
		Begin
		INSERT INTO [Items].[TB_CategoryOne]
           ([CategoryOne_Name])
     VALUES
           (@CategoryOne_Name )
		End;
go

create procedure Items.AddNew_CategoryTwo
-- اضافه كاتوجري ثانوي
			@CategoryTwo_Name nvarchar(100)

		As 
		Begin
		INSERT INTO [Items].[TB_CategoryTwo]
           ([CategoryTwo_Name])
     VALUES
           (@CategoryTwo_Name )
		End;
go

create procedure Items.AddNew_CategoryThree
-- اضافه كاتوجري ثلاثي
			@CategoryThree_Name nvarchar(100)

		As 
		Begin
		INSERT INTO [Items].[TB_CategoryThree]
           ([CategoryThree_Name])
     VALUES
           (@CategoryThree_Name )
		End;
go


alter procedure Items.AddNew_CategoryFour
-- اضافه كاتوجري رابع
			@CategoryFour_Name nvarchar(100)

		As 
		Begin
		INSERT INTO [Items].[TB_CategoryFour]
           ([CategoryFour_Name])
     VALUES
           (@CategoryFour_Name  )
		End;
go

create procedure Items.Update_CategoryOne
-- تعديل الكاتيجوري الاول
	@CategoryONe_Name nvarchar(100),
	@Category_ID int
	As 
	Begin
	UPDATE [Items].[TB_CategoryOne]
   SET [CategoryOne_Name] = @CategoryOne_Name 
 WHERE CategoryOne_ID=@Category_ID
	End;
GO

create procedure Items.Update_CategoryTwo
-- تعديل الكاتيجوري الثاني
	@CategoryTwo_Name nvarchar(100),
	@Category_ID int
	As 
	Begin
UPDATE [Items].[TB_CategoryTwo]
   SET [CategoryTwo_Name] = @CategoryTwo_Name 
 WHERE CategoryTwo_ID = @Category_ID
	End;
GO

create procedure Items.Update_CategoryThree
-- تعديل الكاتيجوري الثالث
	@CategoryThree_Name nvarchar(100),
	@Category_ID int
	As 
	Begin
 UPDATE [Items].[TB_CategoryThree]
   SET [CategoryThree_Name] = @CategoryThree_Name 
 WHERE CategoryThree_ID = @Category_ID;
	End;
GO

create procedure Items.Update_CategoryFour
--تعديل الكاتيجوري الرابع
	@CategoryFour_Name nvarchar(100),
	@Category_ID int
	As 
	Begin
UPDATE [Items].[TB_CategoryFour]
   SET [CategoryFour_Name] = @CategoryFour_Name 
 WHERE CategoryFour_ID=@Category_ID;
	End;
GO

-----------------------------------------------------
create procedure Items.AddNew_Item
		@Items_Code  nvarchar(20) 
           ,@Items_NameAR  nvarchar(200) 
           ,@Items_NameEn  nvarchar(200) =Null
           ,@Unit_ID  int 
           ,@Items_pricesale  decimal(18,3) 
           ,@CategoryOne_ID  int =Null
           ,@CategoryTwo_ID  int =Null
           ,@CategoryThree_ID  int =Null
           ,@CategoryFour_ID  int =Null
           ,@Items_Cost  decimal(10,4) =Null
           ,@Items_QtyBalance int	=Null

		   As
		   Begin
INSERT INTO [Items].[TB_Items]
           ([Items_Code]
           ,[Items_NameAR]
           ,[Items_NameEn]
           ,[Unit_ID]
           ,[Items_pricesale]
           ,[CategoryOne_ID]
           ,[CategoryTwo_ID]
           ,[CategoryThree_ID]
           ,[CategoryFour_ID]
           ,[Items_Cost]
           ,[Items_QtyBalance])
     VALUES
           (@Items_Code 
           ,@Items_NameAR 
           ,@Items_NameEn 
           ,@Unit_ID 
           ,@Items_pricesale 
           ,@CategoryOne_ID 
           ,@CategoryTwo_ID 
           ,@CategoryThree_ID 
           ,@CategoryFour_ID 
           ,@Items_Cost 
           ,@Items_QtyBalance )
	End;
go

create procedure Items.Update_Item
		@Items_Code  nvarchar(20) 
           ,@Items_NameAR  nvarchar(200) 
           ,@Items_NameEn  nvarchar(200) =Null
           ,@Unit_ID  int 
           ,@Items_pricesale  decimal(18,3) 
           ,@CategoryOne_ID  int =Null
           ,@CategoryTwo_ID  int =Null
           ,@CategoryThree_ID  int =Null
           ,@CategoryFour_ID  int =Null
           ,@Items_Cost  decimal(10,4) =Null
           ,@Items_QtyBalance int	=Null
		   ,@ITems_ID int
		   As
		   Begin
UPDATE [Items].[TB_Items]
   SET [Items_Code] = @Items_Code 
      ,[Items_NameAR] = @Items_NameAR 
      ,[Items_NameEn] = @Items_NameEn  
      ,[Unit_ID] = @Unit_ID 
      ,[Items_pricesale] = @Items_pricesale 
      ,[CategoryOne_ID] = @CategoryOne_ID 
      ,[CategoryTwo_ID] = @CategoryTwo_ID 
      ,[CategoryThree_ID] = @CategoryThree_ID 
      ,[CategoryFour_ID] = @CategoryFour_ID 
      ,[Items_Cost] = @Items_Cost 
      ,[Items_QtyBalance] = @Items_QtyBalance 
 WHERE Items_ID=@ITems_ID
	End;
go

--------------------------------------------------------
create procedure Items.AddNew_Unit
	@Unit_Name  nvarchar(10)

as 
Begin
INSERT INTO [Items].[TB_Unit]
           ([Unit_Name])
     VALUES
           (@Unit_Name )
End;
Go

create procedure Items.Update_Unit
	@Unit_Name  nvarchar(10)
	,@Unit_ID int
as
begin
UPDATE [Items].[TB_Unit]
   SET [Unit_Name] = @Unit_Name 
 WHERE Unit_ID=@Unit_ID
End;
Go
-----------------------------------------------------
alter procedure personal.AddNew_Customer
		  @Customer_Name  nvarchar(150) 
           ,@country_ID  int 
           ,@Customer_phone  nvarchar(15) 
           ,@Customer_fax  nvarchar(15) =Null
           ,@Customer_Email  nvarchar(50) =Null
           ,@Customer_Address  nvarchar(100) =Null
           ,@Customer_ISActive  bit =1
	As
	Begin
	INSERT INTO [personal].[TB_Customers]
           ([Customer_Name]
           ,[country_ID]
           ,[Customer_phone]
           ,[Customer_fax]
           ,[Customer_Email]
           ,[Customer_Address]
           ,[Customer_ISActive])
     VALUES
           (@Customer_Name 
           ,@country_ID 
           ,@Customer_phone 
           ,@Customer_fax 
           ,@Customer_Email 
           ,@Customer_Address 
           ,@Customer_ISActive )
	End;
Go

alter procedure personal.Update_Customer
		  @Customer_Name  nvarchar(150) 
           ,@country_ID  int 
           ,@Customer_phone  nvarchar(15) 
           ,@Customer_fax  nvarchar(15) =Null
           ,@Customer_Email  nvarchar(50) =Null
           ,@Customer_Address  nvarchar(100) =Null
           ,@Customer_ISActive  bit =1
		   ,@Customer_ID int
As
Begin
UPDATE [personal].[TB_Customers]
   SET [Customer_Name] = @Customer_Name 
      ,[country_ID] = @country_ID 
      ,[Customer_phone] = @Customer_phone 
      ,[Customer_fax] = @Customer_fax 
      ,[Customer_Email] = @Customer_Email 
      ,[Customer_Address] = @Customer_Address 
      ,[Customer_ISActive] = @Customer_ISActive 
 WHERE Customer_ID=@Customer_ID
End;
Go			
-------------------------------------------------------
create procedure personal.AddNew_Supplier
			  @supplier_Name  nvarchar(150) 
           ,@country_ID  int 
           ,@supplier_phone  nvarchar(15) 
           ,@supplier_fax  nvarchar(15) =Null
           ,@supplier_Email  nvarchar(50)=Null 
           ,@supplier_Address  nvarchar(100) =Null
           ,@supplier_ISActive  bit =1

As
Begin
INSERT INTO [personal].[TB_Suppliers]
           ([supplier_Name]
           ,[country_ID]
           ,[supplier_phone]
           ,[supplier_fax]
           ,[supplier_Email]
           ,[supplier_Address]
           ,[supplier_ISActive])
     VALUES
           (@supplier_Name 
           ,@country_ID 
           ,@supplier_phone 
           ,@supplier_fax 
           ,@supplier_Email 
           ,@supplier_Address 
           ,@supplier_ISActive )
End;
go

create procedure personal.Update_Supplier
		  @supplier_Name  nvarchar(150) 
           ,@country_ID  int 
           ,@supplier_phone  nvarchar(15) 
           ,@supplier_fax  nvarchar(15) =Null
           ,@supplier_Email  nvarchar(50)=Null 
           ,@supplier_Address  nvarchar(100) =Null
           ,@supplier_ISActive  bit =1
		   ,@supplier_ID int
As
Begin
UPDATE [personal].[TB_Suppliers]
   SET [supplier_Name] = @supplier_Name 
      ,[country_ID] = @country_ID 
      ,[supplier_phone] = @supplier_phone 
      ,[supplier_fax] = @supplier_fax 
      ,[supplier_Email] = @supplier_Email 
      ,[supplier_Address] = @supplier_Address 
      ,[supplier_ISActive] = @supplier_ISActive 
 WHERE supplier_ID= @supplier_ID
End;
Go
--------------------------------------------------------
create procedure  Users.AddNew_Users 
	@user_NameAr  nvarchar(50)
           ,@user_NameEn  nvarchar(50)=Null
           ,@user_userName  nvarchar(20)
           ,@user_password  nvarchar(255)
           ,@userType_ID  int
           ,@user_IsActive  bit=1
	As
	Begin
	INSERT INTO [Users].[TB_Users]
           ([user_NameAr]
           ,[user_NameEn]
           ,[user_userName]
           ,[user_password]
           ,[userType_ID]
           ,[user_IsActive])
     VALUES
           (@user_NameAr 
           ,@user_NameEn 
           ,@user_userName 
           ,@user_password 
           ,@userType_ID 
           ,@user_IsActive )
	End;
	Go

alter procedure Users.Update_Users
		@user_NameAr  nvarchar(50)
           ,@user_NameEn  nvarchar(50)=Null
           ,@user_userName  nvarchar(20)
           ,@userType_ID  int
           ,@user_IsActive  bit=1
		   ,@User_ID int
As
Begin
UPDATE [Users].[TB_Users]
   SET [user_NameAr] = @user_NameAr 
      ,[user_NameEn] = @user_NameEn  
      ,[user_userName] = @user_userName 
      ,[userType_ID] = @userType_ID 
      ,[user_IsActive] = @user_IsActive 
 WHERE users_ID =@User_ID;
End;
Go

alter procedure Users.Update_Users_Password
		@old_user_password  nvarchar(255)
		,@user_userName nvarchar(255)
		   ,@user_password nvarchar(255)
As
Begin
UPDATE [Users].[TB_Users]
   SET [user_password] = @user_password 
 WHERE user_userName =@user_userName
	and user_password = @old_user_password;
End;
Go

alter procedure Users.update_UsersPermission
		@userPer_ISActive bit
		,@Userper_type nvarchar(max)
		,@users_ID int
as 
begin
UPDATE [Users].[TB_UsersPermission]
   SET [userPer_ISActive] = @userPer_ISActive from TB_UsersPermission
  left join TB_UsersPermissionType as user_type on user_Type.userperType_ID = TB_UsersPermission.userperType_ID
 WHERE user_type.userperType_Name=@Userper_type and users_ID =@users_ID
End;
go
 
create procedure Users.Users_Login
			@user_userName nvarchar(max)
			,@user_Password nvarchar(max)
as 
begin
select 
TB_Users.users_ID
      ,[user_NameAr]
      ,[user_NameEn]
      ,[user_userName]
      ,[user_password]
      ,[userType_ID]
      ,[user_IsActive]
	  , [userper_ID]
      ,TB_UsersPermission.[userperType_ID]
      ,[userperType_Name]
	   ,[userPer_ISActive]
 from TB_Users 
	left join TB_UsersPermission on TB_UsersPermission.users_ID = TB_Users.users_ID
  left join TB_UsersPermissionType as user_type on user_Type.userperType_ID = TB_UsersPermission.userperType_ID
 WHERE TB_Users.user_userName = @user_userName and TB_Users.user_password = @user_Password
End;
go


----------------------------------------------
create procedure Invoices.AddNew_purchase
	@AccFunction_Code  int 
           ,@supplier_ID  int 
           ,@purchase_invoiceDate  date 
           ,@purchase_invoiceNo nvarchar(10) 
           ,@Department_ID  int 
           ,@Items_ID  int
           ,@Unit_ID  int
           ,@purchase_Note  nvarchar(100)=Null
           ,@purchase_Qty int
           ,@purchase_price decimal(18,3) 
           ,@Items_Cost decimal(10,4)=Null
           ,@ISActive  bit =1
	As
	Begin
	INSERT INTO [Invoices].[TB_Purchases]
           ([AccFunction_Code]
           ,[supplier_ID]
           ,[purchase_invoiceDate]
           ,[purchase_invoiceNo]
           ,[Department_ID]
           ,[Items_ID]
           ,[Unit_ID]
           ,[purchase_Note]
           ,[purchase_Qty]
           ,[purchase_price]
           ,[Items_Cost]
           ,[ISActive])
     VALUES
           (@AccFunction_Code 
           ,@supplier_ID 
           ,@purchase_invoiceDate 
           ,@purchase_invoiceNo 
           ,@Department_ID 
           ,@Items_ID 
           ,@Unit_ID 
           ,@purchase_Note 
           ,@purchase_Qty 
           ,@purchase_price 
           ,@Items_Cost 
           ,@ISActive )
End;
go

alter procedure Invoices.Update_Purchase
		@AccFunction_Code  int 
           ,@supplier_ID  int 
           ,@purchase_invoiceDate  date 
           ,@purchase_invoiceNo nvarchar(10) 
           ,@Department_ID  int 
           ,@Items_ID  int
           ,@Unit_ID  int
           ,@purchase_Note  nvarchar(100)=Null
           ,@purchase_Qty int
           ,@purchase_price decimal(18,3) 
           ,@ISActive  bit =1
		   ,@purchase_ID int
	As
	Begin
	UPDATE [Invoices].[TB_Purchases]
   SET [AccFunction_Code] = @AccFunction_Code 
      ,[supplier_ID] = @supplier_ID 
      ,[purchase_invoiceDate] = @purchase_invoiceDate 
      ,[purchase_invoiceNo] = @purchase_invoiceNo 
      ,[Department_ID] = @Department_ID 
      ,[Items_ID] = @Items_ID 
      ,[Unit_ID] = @Unit_ID 
      ,[purchase_Note] = @purchase_Note 
      ,[purchase_Qty] = @purchase_Qty 
      ,[purchase_price] = @purchase_price 
      ,[ISActive] = @ISActive 
 WHERE purchase_ID= @purchase_ID;
 End;
 go

 -------------------------------------------------
 create procedure Invoices.AddNew_sales
			@AccFunction_Code  int
           ,@Customer_ID  int
           ,@Customer_invoiceDate  date
           ,@Customer_invoiceNo nvarchar(10)
           ,@Department_ID int
           ,@Items_ID int
           ,@Unit_ID int
           ,@Customer_Note nvarchar(100) =Null
           ,@Customer_Qty int
           ,@Customer_price decimal(18,3)
           ,@Items_Cost decimal(10,4) =Null
           ,@ISActive bit =1

	As
	Begin
	INSERT INTO [Invoices].[TB_Sales]
           ([AccFunction_Code]
           ,[Customer_ID]
           ,[Customer_invoiceDate]
           ,[Customer_invoiceNo]
           ,[Department_ID]
           ,[Items_ID]
           ,[Unit_ID]
           ,[Customer_Note]
           ,[Customer_Qty]
           ,[Customer_price]
           ,[Items_Cost]
           ,[ISActive])
     VALUES
           ( @AccFunction_Code  
           ,@Customer_ID  
           ,@Customer_invoiceDate  
           ,@Customer_invoiceNo 
           ,@Department_ID  
           ,@Items_ID  
           ,@Unit_ID 
           ,@Customer_Note 
           ,@Customer_Qty 
           ,@Customer_price 
           ,@Items_Cost
           ,@ISActive );
End;
Go

create procedure Invoices.Update_Sales
				@AccFunction_Code  int
           ,@Customer_ID  int
           ,@Customer_invoiceDate  date
           ,@Customer_invoiceNo nvarchar(10)
           ,@Department_ID int
           ,@Items_ID int
           ,@Unit_ID int
           ,@Customer_Note nvarchar(100) =Null
           ,@Customer_Qty int
           ,@Customer_price decimal(18,3)
           ,@Items_Cost decimal(10,4) =Null
           ,@ISActive bit =1
		   ,@Sales_ID int

	As
	Begin
UPDATE [Invoices].[TB_Sales]
   SET [AccFunction_Code] = @AccFunction_Code  
      ,[Customer_ID] = @Customer_ID  
      ,[Customer_invoiceDate] = @Customer_invoiceDate  
      ,[Customer_invoiceNo] = @Customer_invoiceNo  
      ,[Department_ID] = @Department_ID  
      ,[Items_ID] = @Items_ID  
      ,[Unit_ID] = @Unit_ID  
      ,[Customer_Note] = @Customer_Note  
      ,[Customer_Qty] = @Customer_Qty  
      ,[Customer_price] = @Customer_price  
      ,[Items_Cost] = @Items_Cost 
      ,[ISActive] = @ISActive  
 WHERE sales_ID= @Sales_ID

 End;
 Go
 --------------------------------------------------
 create procedure Invoices.AddNew_Transfar
			 @AccFunction_Code  int 
            ,@Transfar_invoiceDate  date 
            ,@Transfar_invoiceNo  nvarchar(10) 
            ,@Department_ID  int 
            ,@Department_IDIN  int 
            ,@Items_ID  int 
            ,@Unit_ID  int 
            ,@Transfar_note  nvarchar(200) =Null
            ,@Transfar_Qty  int 
            ,@Transfar_cost  decimal(10,4)=Null 
            ,@ISActive  bit =1
	As 
	Begin
	INSERT INTO [Invoices].[TB_Transfar]
           ([AccFunction_Code]
           ,[Transfar_invoiceDate]
           ,[Transfar_invoiceNo]
           ,[Department_ID]
           ,[Department_IDIN]
           ,[Items_ID]
           ,[Unit_ID]
           ,[Transfar_note]
           ,[Transfar_Qty]
           ,[Transfar_cost]
           ,[ISActive])
     VALUES
           ( @AccFunction_Code  
           ,@Transfar_invoiceDate  
           ,@Transfar_invoiceNo  
           ,@Department_ID  
           ,@Department_IDIN  
           ,@Items_ID  
           ,@Unit_ID  
           ,@Transfar_note  
           ,@Transfar_Qty  
           ,@Transfar_cost  
           ,@ISActive  )
	End;
	Go

create procedure Invoices.Update_Transfar
			 @AccFunction_Code  int 
            ,@Transfar_invoiceDate  date 
            ,@Transfar_invoiceNo  nvarchar(10) 
            ,@Department_ID  int 
            ,@Department_IDIN  int 
            ,@Items_ID  int 
            ,@Unit_ID  int 
            ,@Transfar_note  nvarchar(200) =Null
            ,@Transfar_Qty  int 
            ,@Transfar_cost  decimal(10,4)=Null 
            ,@ISActive  bit =1
			,@Transfar_ID int 
as
Begin
UPDATE [Invoices].[TB_Transfar]
   SET  [AccFunction_Code] = @AccFunction_Code  
      ,[Transfar_invoiceDate] = @Transfar_invoiceDate  
      ,[Transfar_invoiceNo] = @Transfar_invoiceNo  
      ,[Department_ID] = @Department_ID  
      ,[Department_IDIN] = @Department_IDIN  
      ,[Items_ID] = @Items_ID  
      ,[Unit_ID] = @Unit_ID  
      ,[Transfar_note] = @Transfar_note  
      ,[Transfar_Qty] = @Transfar_Qty  
      ,[Transfar_cost] = @Transfar_cost  
      ,[ISActive] = @ISActive  
 WHERE Transfar_ID= @Transfar_ID
End;
Go
--------------------------------------------------------
 create procedure Invoices.AddNew_Depreciation
			@AccFunction_Code  int 
           ,@Depreciation_invoiceDate  date 
           ,@Department_ID  int 
           ,@Items_ID  int 
           ,@Unit_ID  int 
           ,@Depreciation_Case  nvarchar(200) =Null
           ,@Depreciation_Qty  int 
           ,@Depreciation_cost  decimal(10,4) =Null
           ,@ISActive  bit =1
	As 
	Begin
	INSERT INTO [Invoices].[TB_Depreciation]
           ([AccFunction_Code]
           ,[Depreciation_invoiceDate]
           ,[Department_ID]
           ,[Items_ID]
           ,[Unit_ID]
           ,[Depreciation_Case]
           ,[Depreciation_Qty]
           ,[Depreciation_cost]
           ,[ISActive])
     VALUES
           (@AccFunction_Code 
           ,@Depreciation_invoiceDate 
           ,@Department_ID 
           ,@Items_ID 
           ,@Unit_ID 
           ,@Depreciation_Case 
           ,@Depreciation_Qty 
           ,@Depreciation_cost 
           ,@ISActive )
	End;
	Go

alter procedure Invoices.Update_Depreciation
			@AccFunction_Code  int 
           ,@Depreciation_invoiceDate  date 
           ,@Department_ID  int 
           ,@Items_ID  int 
           ,@Unit_ID  int 
           ,@Depreciation_Case  nvarchar(200) =Null
           ,@Depreciation_Qty  int 
           ,@Depreciation_cost  decimal(10,4) =Null
           ,@ISActive  bit =1
		   ,@Depreciation_ID  int 
as
Begin
UPDATE [Invoices].[TB_Depreciation]
   SET [AccFunction_Code] = @AccFunction_Code    
      ,[Depreciation_invoiceDate] = @Depreciation_invoiceDate 
      ,[Department_ID] = @Department_ID 
      ,[Items_ID] = @Items_ID 
      ,[Unit_ID] = @Unit_ID 
      ,[Depreciation_Case] = @Depreciation_Case 
      ,[Depreciation_Qty] = @Depreciation_Qty 
      ,[Depreciation_cost] = @Depreciation_cost 
      ,[ISActive] = @ISActive 
 WHERE Depreciation_ID=@Depreciation_ID;
End;
Go

create procedure personal.pro_view_Country
as 
begin
select * from [personal].[TB_Country]
order by country_ID
end;
go

alter procedure personal.pro_view_suppliers
as 
begin
select [supplier_ID]
      ,[supplier_Name]
      ,[supplier_phone]
      ,[supplier_fax]
      ,[supplier_Email]
      ,[supplier_Address]
      ,[supplier_ISActive]
	  ,TB_Country.country_ID
	  ,Country_Name
	  ,Country_PhoneKey
 from personal.TB_Suppliers
left join personal.TB_Country on TB_Suppliers.country_ID = TB_Country.country_ID
order by supplier_ID 
End;
go

create procedure personal.pro_view_Customers
as 
begin
select * from personal.TB_Customers
left join personal.TB_Country on TB_Customers.country_ID = TB_Country.country_ID
order by Customer_ID 
End;
go
***************
create procedure Invoices.pro_View_PurchaseInvoics_Code

as
begin
select 
[AccFunction_Code]
    
 from Invoices.View_PurchaseInvoics
 group by AccFunction_Code 
end;
go

 alter procedure Invoices.pro_View_Purchase_Code
 @AccFunction_code int
 as 
 begin 
 select * from Invoices.View_PurchaseInvoics
 where AccFunction_Code=@AccFunction_code
 order by purchase_ID
 end;
 go
 --------------------------------------------
 create procedure Invoices.pro_View_SalesInvoics_Code

as
begin
select 
[AccFunction_Code]
    
 from Invoices.View_SalesInvoics
 group by AccFunction_Code 
end;
go
-------------------------------------
 create procedure Accounts.pro_View_PaymentsInvoics_Code

as
begin
select 
[AccFunction_Code]
    
 from Accounts.View_PaymentsInvoics
 group by AccFunction_Code 
end;
go

 create procedure Invoices.pro_View_TransfarInvoics_Code

as
begin
select 
[AccFunction_Code]
    
 from Invoices.View_TransfarInvoics
 group by AccFunction_Code 
end;
go
 create procedure Invoices.pro_View_DeprecationInvoics_Code

as
begin
select 
[AccFunction_Code]
    
 from Invoices.View_DeprecationInvoics
 group by AccFunction_Code 
end;
go
 create procedure Invoices.pro_View_Sales_Code
 @AccFunction_code int
 as 
 begin 
 select * from Invoices.View_SalesInvoics
 where AccFunction_Code=@AccFunction_code
 order by sales_ID
 end;
 go

  create procedure accounts.pro_View_Payments_Code
 @AccFunction_code int
 as 
 begin 
 select * from Accounts.View_PaymentsInvoics
 where AccFunction_Code=@AccFunction_code
 order by payment_ID
 end;
 go


  create procedure Invoices.pro_View_Trans_Code
 @AccFunction_code int
 as 
 begin 
 select * from Invoices.View_TransfarInvoics
 where AccFunction_Code=@AccFunction_code
 order by Transfar_ID
 end;
 go

  alter procedure Invoices.pro_View_Deprecation_Code
 @AccFunction_code int
 as 
 begin 
 select * from Invoices.View_DeprecationInvoics
 where AccFunction_Code=@AccFunction_code
 order by Depreciation_ID
 end;
 go
 ------------------------------------------------
 create procedure Stores.pro_View_Stores
 as
 begin
 select * from Stores.TB_Stores 
 end;
 go


  create procedure Accounts.pro_View_Payments
 as
 begin
 select * from Accounts.TB_AccountsSub
 where AccountGen_ID =  102002
 end;
 go


 alter procedure Stores.pro_View_Department
 @store_ID int
 as 
 begin
 select * from TB_Departments 
 where Store_ID= @store_ID
 end;
 go

  create procedure Users.pro_View_userType
 
 as 
 begin
 select * from TB_UsersType 
 order by TB_UsersType.userType_ID
 end;
 go

 alter procedure Items.pro_ItemBalance 
				@item_ID int
-- الرصيد من العنصر في كله
as
begin
select sum(Item_Qty) as Item_Qty
from Stores.Fun_StoresDepartmentCostAndBalance()
 where Items_ID = @item_ID
end;
go


 alter procedure Items.pro_ItemBalanceInDepartment 
				@item_ID int
				,@DepartmentID int
				
-- الرصيد من العنصر في كله
as
begin
select * from  items.fun_ItemCostAndBalanceINDepartment(@item_ID,@DepartmentID)
end;
go

alter procedure Stores.pro_DetailsMove
					@Items_ID int,
					@info nvarchar(10),
					@Department int

as
begin
select Items_ID,
		Info,
		total,
		Item_Cost,
		Item_Qty,
		balance.Department_ID,
		balance.Department_Name,
		Store_Name 
		 ,function_ID
		 ,tb_function.AccFunction_type
		 from Stores.Fun_StoresAllMove() balance 
		right join 
Stores.TB_Departments on balance.Department_ID= TB_Departments.Department_ID
left join Accounts.AccountFunctionCode tb_function on tb_function.AccountFun_Code = balance.function_ID
where balance.Items_ID= @Items_ID and CAST( Info as nvarchar(10) )=@info
and balance.Department_ID = @Department
order by balance.Department_ID
end;
go

create procedure Stores.pro_AllMoves
					@Items_ID int

as
begin
select 
	Items_ID,
	Info,
	sum(total) as total,
	sum(Item_Cost)as Item_Cost,
	sum(Item_Qty) as Item_Qty,
	Department_ID,
	Department_Name,
	Store_Name
 from (
select Items_ID,
		Info,
		total,
		Item_Cost,
		Item_Qty,
		balance.Department_ID,
		balance.Department_Name,
		Store_Name
		
		 from Stores.Fun_StoresAllMove() balance 
		right join 
Stores.TB_Departments on balance.Department_ID= TB_Departments.Department_ID
where balance.Items_ID= @Items_ID) s
group by Items_ID,info,Department_ID,Department_Name,Store_Name
order by  Department_ID
end;
go

alter procedure Stores.pro_AvgCostAndBalans
			@Items_ID int
--تكلفه العنصر في كل المخازن وفي اي قسم 
as
begin
select Items_ID,Items_NameAR,
    
(sum (total)/ sum(Item_Qty)) as avg_Cost, 
sum(Item_Qty)as item_Qty 
 
from Stores.Fun_StoresDepartmentAVGCostAndBalance()
  where Items_ID = @Items_ID 
 group by Items_ID,Items_NameAR ;
end;
go

alter procedure Stores.pro_Department_Balance
				@Department_ID int 
				as
				begin
select * from  stores.Fun_BalanceItems()
where Department_ID= @Department_ID
end;
go

alter procedure Users.UsersPermision
				@userID int 
				as
				begin

select [userper_ID]
      ,[users_ID]
      ,TB_UsersPermission.userperType_ID
	  ,userperType_Name
      ,[userPer_ISActive]
 from  Users.TB_UsersPermission
 join users.TB_UsersPermissionType on TB_UsersPermissionType.userperType_ID = TB_UsersPermission.userperType_ID
where [users_ID]= @userID
order by userperType_ID
end;
go
----------------
---------------------
--Functions
-------------------------------------

alter function items.fun_ItemCostAndBalance(@item_ID int)
-- استقبال قيمه للتكلفه الحاليه لعنصر معين والرصيد المخزني له 
-- في كل قسم علي حدي وكل مخزن علي حدي 
-- اجمالي الرصيد النهائي واجمالي مبلغ كل الحركات علي المخزن
returns table
as return
(select * 
from Stores.Fun_StoresDepartmentCostAndBalance()
 where Items_ID = @item_ID);
 go

alter function items.fun_ItemCostAndBalanceINDepartment(@item_ID int,@Department_ID int)
-- استقبال قيمه للتكلفه الحاليه لعنصر معين والرصيد المخزني له 
-- في قسم معين داخل مخزن معين
returns table
as return

select * 
from Stores.Fun_StoresDepartmentCostAndBalance()
 where Items_ID = @item_ID and Department_ID= @Department_ID;
 
 go

 ALTER function [Stores].[Fun_StoresDepartmentAVGCostAndBalance]()
-- التكلفه المتوسطه لكل الاصناف
--بيجيب توتل للعناصر اجمالي المشتريات والتحويلات (( المدخلات )) والكميه واجمالي المصاريف للعنصر 
returns table
as 
return
(select Items_ID,Items_NameAR,
    CASE 
            WHEN Item_Qty = 0 THEN 'تكاليف' -- في حاله المصروفات 
			when Item_Cost=0 then 'اهـــلاك'  -- في حاله الاهلاك
            ELSE  'مدخلات'
        END AS Info,
    CASE 
            WHEN Item_Qty = 0 THEN Item_Cost * 1 -- في حاله المصروفات 
			when Item_Cost=0 then 0  -- في حاله الاهلاك
            ELSE  Item_Qty * Item_Cost
        END AS total,
 
Item_Cost,
Item_Qty,
Department_ID ,
Department_Name,Store_Name 
from Stores.view_storesDepartmentitems 
where Item_Qty >=0 or Item_Cost>=0
--group by Items_ID,Items_NameAR,Department_Name,Department_ID,Store_Name
);
go

 alter function [Stores].[Fun_StoresAllMove]()
-- التكلفه المتوسطه لكل الاصناف
--بيجيب توتل للعناصر اجمالي المشتريات والتحويلات (( المدخلات )) والكميه واجمالي المصاريف للعنصر 
returns table
as 
return
(select Items_ID,Items_NameAR,
    CASE 
            WHEN Item_Qty = 0 THEN 'تكاليف' -- في حاله المصروفات 
			when Item_Cost=0 then 'اهـــلاك' -- في حاله الاهلاك
			when  Item_Qty < 0 then 'مخرجات'  -- في حاله المخرجات
            ELSE  'مدخلات'
        END AS Info,
    CASE 
            WHEN Item_Qty = 0 THEN Item_Cost * 1 -- في حاله المصروفات 
			when Item_Cost=0 then 0  -- في حاله الاهلاك
			when  Item_Qty < 0 then 0 -- في حاله المخرجات
            ELSE  Item_Qty * Item_Cost
        END AS total,
 
 case 
 when Item_Cost <0 then 0 
 else Item_Cost
 end as Item_Cost,
Item_Qty,
Department_ID ,
Department_Name,Store_Name ,function_ID
from Stores.view_storesDepartmentitems 
--group by Items_ID,Items_NameAR,Department_Name,Department_ID,Store_Name
);
go

alter function items.fun_ItemAvgCostINDepartment(@item_ID int,@Department_ID int)
-- استقبال قيمه للتكلفه الحاليه لعنصر معين متوسط التكلفه 
-- دا الجمله النهائيه لحساب تكلفه العنصر واجمالي الكميه المشتراه والمحوله 
-- في قسم معين داخل مخزن معين
returns table
as return

select Items_ID,Items_NameAR,
    
(sum (total)/ sum(Item_Qty)) as avg_Cost, 
sum(Item_Qty)as item_Qty ,
Department_ID ,
Department_Name,Store_Name  
from Stores.Fun_StoresDepartmentAVGCostAndBalance()
  where Items_ID = @item_ID and Department_ID= @Department_ID
 group by Items_ID,Items_NameAR,Department_Name,Department_ID,Store_Name;

 go

 create Function Invoices.fun_NewAccountSub_Payment_Code
 (@Account_Gen int)
 -- يرجع قيمه جديده لرقم حساب المصروفا الجديد 
 -- المراد اضافته
 Returns int
 As
 begin
 declare @account_SubNew int;
 select @account_SubNew= MAX(AccountSub_Code) from Accounts.TB_AccountsSub
 where AccountGen_ID = @Account_Gen
 -- اضافه 1 الي القيمه المرتجعه 
 set @account_SubNew = @account_SubNew +1
 return @account_SubNew
 end
 go

alter function stores.Fun_StoresDepartmentCostAndBalance()
-- اظهار كل الاصناف بالمجموع للتكلفه والمخزون
returns table
as 
return
(select Items_ID,Items_NameAR,
--sum(Item_Cost * Item_Qty)as Item_Cost,
sum(Item_Qty)as Item_Qty ,
Department_ID ,
Department_Name,Store_Name 
from Stores.view_storesDepartmentitems 
group by Items_ID,Items_NameAR,Department_Name,Department_ID,Store_Name);

go

alter function stores.Fun_BalanceItems()
-- اظهار كل الاصناف بالمجموع للتكلفه والمخزون
returns table
as 
return
(select Items_ID,Items_Code,Items_NameAR,
--sum(Item_Cost * Item_Qty)as Item_Cost,
sum(Item_Qty)as Item_Qty ,
Department_ID ,
Department_Name,Store_Name 
from Stores.view_storesDepartmentitems 
group by Items_ID,Items_Code,Items_NameAR,Department_Name,Department_ID,Store_Name);

go


--------------------------------------
--functions--
------------------------------------------

 -- حساب التكلفه للعنصر
select * from  items.fun_ItemAvgCostINDepartment(3,3)
-- بنود الحركه في العنصر مدخلات وتكاليف واهلاك
select * from stores.Fun_StoresDepartmentAVGCostAndBalance() where Items_ID = 3 and Department_ID= 3 ;
--عرض من كل الاقسام والمخازن
select * from stores.Fun_StoresDepartmentAVGCostAndBalance() balance join 
Stores.TB_Departments on balance.Department_ID= TB_Departments.Department_ID
where balance.Items_ID= 1
order by balance.Department_ID
-- كل حركات المخازن
select *  from Stores.view_storesDepartmentitems 
where Item_Qty >=0 or Item_Cost >=0 and Items_ID=1 and Department_ID=3
-- الرصيد الحالي من العنصر 
select *  from items.fun_ItemCostAndBalanceINDepartment(3,4)
--عرض الرصيد من كل عنصر وموقعه
select *  from stores.Fun_StoresDepartmentCostAndBalance()
--عرض رصيد الصنف في اي مخزن 
select * from items.fun_ItemCostAndBalance(3)
-- عرض الرصيد الاجمالي 
exec Items.pro_ItemBalance 1
-- عرض رصيد العنصر في قسم ومخزن معين 
select * from  items.fun_ItemCostAndBalanceINDepartment(1,6)
--اضافه مصروف جديد الي الحسابات
exec Accounts.AddNewPayment 'عدد وأدوات'
--رقم جديد function
declare @new int;
exec Accounts.funNew_Function_NO @function_Code = @New output;
select @new


-- حفط بيانات المستخدمين
exec Users.update_UsersPermission
exec Users.Update_Users
exec Users.AddNew_Users





--=======================================================
--=======================================================

-- حفظ بيانات المخازن
exec stores.UpdateStore
exec stores.NewStore
---------------------------------------------------
-- حفظ بيانات الاقسام
exec stores.UpdateDepartment
exec stores.NewDepartment
-----------------------------------------------------
-- تعديل بيانات الكاتيجوري
exec Items.Update_CategoryFour 
exec Items.Update_CategoryThree
exec Items.Update_CategoryTwo
exec Items.Update_CategoryOne
-- حفظ بيانات الكاتيجوري
exec Items.AddNew_CategoryFour 
exec Items.AddNew_CategoryThree
exec Items.AddNew_CategoryTwo
exec Items.AddNew_CategoryOne

-- حفظ بيانات الوحدات
exec Items.Update_Unit
exec Items.AddNew_Unit
exec Items.pro_View_Items_Code 
exec Items.pro_View_Items_NameAr 'اعشاب'
exec Items.pro_view_items
exec Items.Pro_View_Items_NameEn
exec items.pro_ItemBalanceInDepartment
exec items.pro_ItemBalance
-- حفظ بيانات الموردين
exec personal.Update_Supplier
exec personal.AddNew_Supplier
exec personal.pro_View_Supplier_Name
exec personal.pro_View_Supplier_Code
exec personal.pro_view_suppliers
-- حفظ بيانات العملاء
exec personal.Update_Customer
exec personal.AddNew_Customer
exec personal.pro_View_Customer_Name
exec personal.pro_View_Customer_Code
-- حفظ فاتوره بيع
exec Invoices.Update_Sales
exec Invoices.AddNew_sales
exec invoices.Delete_salesInvoice
exec Invoices.pro_View_SalesInvoics_Code
exec Invoices.pro_View_Sales_Code
-- حفظ فاتور شراء
 exec Invoices.Update_Purchase
exec Invoices.AddNew_purchase
exec invoices.Delete_PurchaseInvoice
exec Invoices.pro_View_PurchaseInvoics_Code
exec Invoices.pro_View_Purchase_Code
-- حفظ فاتوره تحويل
exec Invoices.Update_Transfar 
exec Invoices.AddNew_Transfar

--حفظ سند اهلاك
exec Invoices.Update_Depreciation
exec Invoices.AddNew_Depreciation
exec Invoices.Delete_DeprecationInvoice
exec Invoices.pro_View_Deprecation_Code
exec Invoices.pro_View_DeprecationInvoics_Code


-- حفظ فاتوره مصروفات
exec Accounts.Delete_Payment_Invoice
exec Accounts.Update_Payment_Invoice
exec Accounts.AddNew_Payment_Invoice

-- حفط بيانات المستخدمين
exec Users.update_UsersPermission
exec Users.Update_Users
exec Users.AddNew_Users
exec Users.Update_Users_Password
-- عرض المخازن والاقسام
exec Stores.pro_View_DepartmentandStores
-- عرض الانواع 
exec Items.pro_View_CategoryOne
exec Items.pro_View_CategoryTwo
exec Items.pro_View_CategoryThree
exec Items.pro_View_CategoryFour
--عرض العناصر
exec Items.pro_view_items
--عرض الوحدات
exec Items.pro_view_Units
--عرض البلدان
exec personal.pro_view_Country
--عرض الموردين
exec personal.pro_view_suppliers
--عرض ارقام فواتير المشتريات
exec Invoices.pro_View_PurchaseInvoics_Code
-- عرض الفواتير بناءا علي رقم القيد
exec Invoices.pro_View_Purchase_Code 202503001
--عرض قائمه المخازن
exec Stores.pro_View_Stores
-- عرض قائمه الاقسام بناءا علي المخزن 
exec Stores.pro_View_Department 100020

select * from Stores.TB_Departments