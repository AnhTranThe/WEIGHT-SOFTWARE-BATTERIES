IF NOT EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[quanlynguoidung]')) 
   ALTER TABLE [dbo].[quanlynguoidung] 
   ENABLE  CHANGE_TRACKING
GO
