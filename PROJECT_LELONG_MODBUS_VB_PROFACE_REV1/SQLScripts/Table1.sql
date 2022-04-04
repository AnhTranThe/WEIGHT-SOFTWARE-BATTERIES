IF NOT EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[Table1]')) 
   ALTER TABLE [dbo].[Table1] 
   ENABLE  CHANGE_TRACKING
GO
