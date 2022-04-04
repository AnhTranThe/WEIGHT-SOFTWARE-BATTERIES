-- This code can be used to disable change tracking within your database
-- Please ensure all tables have stopped using chagne tracking before executing this code
    
IF EXISTS (SELECT * FROM sys.change_tracking_databases WHERE database_id = DB_ID(N'E:\QATECH\PROJECT\2020\LE LONG PROJECT - SQL - COPY\PROJECT_LELONG_MODBUS_VB_PROFACE_REV1\QUAN LY SAN LUONG CAN LELONG.MDF')) 
  ALTER DATABASE [E:\QATECH\PROJECT\2020\LE LONG PROJECT - SQL - COPY\PROJECT_LELONG_MODBUS_VB_PROFACE_REV1\QUAN LY SAN LUONG CAN LELONG.MDF] 
  SET  CHANGE_TRACKING = OFF
GO
