IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[quanlynguoidung]')) 
   ALTER TABLE [dbo].[quanlynguoidung] 
   DISABLE  CHANGE_TRACKING
GO
