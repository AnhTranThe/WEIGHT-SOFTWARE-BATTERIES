﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PROJECT_LELONG_MODBUS_VB_PROFACE_REV1 {
    
    
    public partial class quan_ly_san_luong_can_LELONGCacheClientSyncProvider : Microsoft.Synchronization.Data.SqlServerCe.SqlCeClientSyncProvider {
        
        public quan_ly_san_luong_can_LELONGCacheClientSyncProvider() {
   
        }
        
        public quan_ly_san_luong_can_LELONGCacheClientSyncProvider(string connectionString) {
            this.ConnectionString = connectionString;
        }
    }
    
    public partial class quan_ly_san_luong_can_LELONGCacheSyncAgent : Microsoft.Synchronization.SyncAgent {
        
        private quanlynguoidungSyncTable _quanlynguoidungSyncTable;
        
        private Table1SyncTable _table1SyncTable;
        
        partial void OnInitialized();
        
        public quan_ly_san_luong_can_LELONGCacheSyncAgent() {
            this.InitializeSyncProviders();
            this.InitializeSyncTables();
            this.OnInitialized();
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public quanlynguoidungSyncTable quanlynguoidung {
            get {
                return this._quanlynguoidungSyncTable;
            }
            set {
                this.Configuration.SyncTables.Remove(this._quanlynguoidungSyncTable);
                this._quanlynguoidungSyncTable = value;
                this.Configuration.SyncTables.Add(this._quanlynguoidungSyncTable);
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public Table1SyncTable Table1 {
            get {
                return this._table1SyncTable;
            }
            set {
                this.Configuration.SyncTables.Remove(this._table1SyncTable);
                this._table1SyncTable = value;
                this.Configuration.SyncTables.Add(this._table1SyncTable);
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitializeSyncProviders() {
            // Create SyncProviders.
            this.RemoteProvider = new quan_ly_san_luong_can_LELONGCacheServerSyncProvider();
            this.LocalProvider = new quan_ly_san_luong_can_LELONGCacheClientSyncProvider();
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitializeSyncTables() {
            // Create SyncTables.
            this._quanlynguoidungSyncTable = new quanlynguoidungSyncTable();
            this._quanlynguoidungSyncTable.SyncGroup = new Microsoft.Synchronization.Data.SyncGroup("quanlynguoidungSyncTableSyncGroup");
            this.Configuration.SyncTables.Add(this._quanlynguoidungSyncTable);
            this._table1SyncTable = new Table1SyncTable();
            this._table1SyncTable.SyncGroup = new Microsoft.Synchronization.Data.SyncGroup("Table1SyncTableSyncGroup");
            this.Configuration.SyncTables.Add(this._table1SyncTable);
        }
        
        public partial class quanlynguoidungSyncTable : Microsoft.Synchronization.Data.SyncTable {
            
            partial void OnInitialized();
            
            public quanlynguoidungSyncTable() {
                this.InitializeTableOptions();
                this.OnInitialized();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private void InitializeTableOptions() {
                this.TableName = "quanlynguoidung";
                this.CreationOption = Microsoft.Synchronization.Data.TableCreationOption.DropExistingOrCreateNewTable;
            }
        }
        
        public partial class Table1SyncTable : Microsoft.Synchronization.Data.SyncTable {
            
            partial void OnInitialized();
            
            public Table1SyncTable() {
                this.InitializeTableOptions();
                this.OnInitialized();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private void InitializeTableOptions() {
                this.TableName = "Table1";
                this.CreationOption = Microsoft.Synchronization.Data.TableCreationOption.DropExistingOrCreateNewTable;
            }
        }
    }
}
namespace PROJECT_LELONG_MODBUS_VB_PROFACE_REV1 {
    
    
    public partial class quanlynguoidungSyncAdapter : Microsoft.Synchronization.Data.Server.SyncAdapter {
        
        partial void OnInitialized();
        
        public quanlynguoidungSyncAdapter() {
            this.InitializeCommands();
            this.InitializeAdapterProperties();
            this.OnInitialized();
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitializeCommands() {
            // quanlynguoidungSyncTableInsertCommand command.
            this.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this.InsertCommand.CommandText = @";WITH CHANGE_TRACKING_CONTEXT (@sync_client_id_binary) INSERT INTO dbo.quanlynguoidung ([tendangnhap], [matkhau], [quyenhan]) VALUES (@tendangnhap, @matkhau, @quyenhan) SET @sync_row_count = @@rowcount; IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'dbo.quanlynguoidung')) > @sync_last_received_anchor RAISERROR (N'SQL Server Change Tracking has cleaned up tracking information for table ''%s''. To recover from this error, the client must reinitialize its local database and try again',16,3,N'dbo.quanlynguoidung') ";
            this.InsertCommand.CommandType = System.Data.CommandType.Text;
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tendangnhap", System.Data.SqlDbType.NVarChar));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@matkhau", System.Data.SqlDbType.NVarChar));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@quyenhan", System.Data.SqlDbType.NVarChar));
            System.Data.SqlClient.SqlParameter insertcommand_sync_row_countParameter = new System.Data.SqlClient.SqlParameter("@sync_row_count", System.Data.SqlDbType.Int);
            insertcommand_sync_row_countParameter.Direction = System.Data.ParameterDirection.Output;
            this.InsertCommand.Parameters.Add(insertcommand_sync_row_countParameter);
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            // quanlynguoidungSyncTableDeleteCommand command.
            this.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this.DeleteCommand.CommandText = @";WITH CHANGE_TRACKING_CONTEXT (@sync_client_id_binary) DELETE dbo.quanlynguoidung FROM dbo.quanlynguoidung JOIN CHANGETABLE(VERSION dbo.quanlynguoidung, ([tendangnhap], [matkhau]), (@tendangnhap, @matkhau)) CT  ON CT.[tendangnhap] = dbo.quanlynguoidung.[tendangnhap] AND CT.[matkhau] = dbo.quanlynguoidung.[matkhau] WHERE (@sync_force_write = 1 OR CT.SYS_CHANGE_VERSION IS NULL OR CT.SYS_CHANGE_VERSION <= @sync_last_received_anchor OR (CT.SYS_CHANGE_CONTEXT IS NOT NULL AND CT.SYS_CHANGE_CONTEXT = @sync_client_id_binary)) SET @sync_row_count = @@rowcount; IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'dbo.quanlynguoidung')) > @sync_last_received_anchor RAISERROR (N'SQL Server Change Tracking has cleaned up tracking information for table ''%s''. To recover from this error, the client must reinitialize its local database and try again',16,3,N'dbo.quanlynguoidung') ";
            this.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary));
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tendangnhap", System.Data.SqlDbType.NVarChar));
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@matkhau", System.Data.SqlDbType.NVarChar));
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_force_write", System.Data.SqlDbType.Bit));
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            System.Data.SqlClient.SqlParameter deletecommand_sync_row_countParameter = new System.Data.SqlClient.SqlParameter("@sync_row_count", System.Data.SqlDbType.Int);
            deletecommand_sync_row_countParameter.Direction = System.Data.ParameterDirection.Output;
            this.DeleteCommand.Parameters.Add(deletecommand_sync_row_countParameter);
            // quanlynguoidungSyncTableUpdateCommand command.
            this.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this.UpdateCommand.CommandText = @";WITH CHANGE_TRACKING_CONTEXT (@sync_client_id_binary) UPDATE dbo.quanlynguoidung SET [quyenhan] = @quyenhan FROM dbo.quanlynguoidung  JOIN CHANGETABLE(VERSION dbo.quanlynguoidung, ([tendangnhap], [matkhau]), (@tendangnhap, @matkhau)) CT  ON CT.[tendangnhap] = dbo.quanlynguoidung.[tendangnhap] AND CT.[matkhau] = dbo.quanlynguoidung.[matkhau] WHERE (@sync_force_write = 1 OR CT.SYS_CHANGE_VERSION IS NULL OR CT.SYS_CHANGE_VERSION <= @sync_last_received_anchor OR (CT.SYS_CHANGE_CONTEXT IS NOT NULL AND CT.SYS_CHANGE_CONTEXT = @sync_client_id_binary)) SET @sync_row_count = @@rowcount; IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'dbo.quanlynguoidung')) > @sync_last_received_anchor RAISERROR (N'SQL Server Change Tracking has cleaned up tracking information for table ''%s''. To recover from this error, the client must reinitialize its local database and try again',16,3,N'dbo.quanlynguoidung') ";
            this.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@quyenhan", System.Data.SqlDbType.NVarChar));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tendangnhap", System.Data.SqlDbType.NVarChar));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@matkhau", System.Data.SqlDbType.NVarChar));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_force_write", System.Data.SqlDbType.Bit));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary));
            System.Data.SqlClient.SqlParameter updatecommand_sync_row_countParameter = new System.Data.SqlClient.SqlParameter("@sync_row_count", System.Data.SqlDbType.Int);
            updatecommand_sync_row_countParameter.Direction = System.Data.ParameterDirection.Output;
            this.UpdateCommand.Parameters.Add(updatecommand_sync_row_countParameter);
            // quanlynguoidungSyncTableSelectConflictDeletedRowsCommand command.
            this.SelectConflictDeletedRowsCommand = new System.Data.SqlClient.SqlCommand();
            this.SelectConflictDeletedRowsCommand.CommandText = @"SELECT CT.[tendangnhap], CT.[matkhau], CT.SYS_CHANGE_CONTEXT, CT.SYS_CHANGE_VERSION FROM CHANGETABLE(CHANGES dbo.quanlynguoidung, @sync_last_received_anchor) CT WHERE (CT.[tendangnhap] = @tendangnhap AND CT.[matkhau] = @matkhau AND CT.SYS_CHANGE_OPERATION = 'D')";
            this.SelectConflictDeletedRowsCommand.CommandType = System.Data.CommandType.Text;
            this.SelectConflictDeletedRowsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            this.SelectConflictDeletedRowsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tendangnhap", System.Data.SqlDbType.NVarChar));
            this.SelectConflictDeletedRowsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@matkhau", System.Data.SqlDbType.NVarChar));
            // quanlynguoidungSyncTableSelectConflictUpdatedRowsCommand command.
            this.SelectConflictUpdatedRowsCommand = new System.Data.SqlClient.SqlCommand();
            this.SelectConflictUpdatedRowsCommand.CommandText = @"SELECT dbo.quanlynguoidung.[tendangnhap], dbo.quanlynguoidung.[matkhau], [quyenhan], CT.SYS_CHANGE_CONTEXT, CT.SYS_CHANGE_VERSION FROM dbo.quanlynguoidung JOIN CHANGETABLE(VERSION dbo.quanlynguoidung, ([tendangnhap], [matkhau]), (@tendangnhap, @matkhau)) CT  ON CT.[tendangnhap] = dbo.quanlynguoidung.[tendangnhap] AND CT.[matkhau] = dbo.quanlynguoidung.[matkhau]";
            this.SelectConflictUpdatedRowsCommand.CommandType = System.Data.CommandType.Text;
            this.SelectConflictUpdatedRowsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tendangnhap", System.Data.SqlDbType.NVarChar));
            this.SelectConflictUpdatedRowsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@matkhau", System.Data.SqlDbType.NVarChar));
            // quanlynguoidungSyncTableSelectIncrementalInsertsCommand command.
            this.SelectIncrementalInsertsCommand = new System.Data.SqlClient.SqlCommand();
            this.SelectIncrementalInsertsCommand.CommandText = @"IF @sync_initialized = 0 SELECT dbo.quanlynguoidung.[tendangnhap], dbo.quanlynguoidung.[matkhau], [quyenhan] FROM dbo.quanlynguoidung LEFT OUTER JOIN CHANGETABLE(CHANGES dbo.quanlynguoidung, @sync_last_received_anchor) CT ON CT.[tendangnhap] = dbo.quanlynguoidung.[tendangnhap] AND CT.[matkhau] = dbo.quanlynguoidung.[matkhau] WHERE (CT.SYS_CHANGE_CONTEXT IS NULL OR CT.SYS_CHANGE_CONTEXT <> @sync_client_id_binary) ELSE  BEGIN SELECT dbo.quanlynguoidung.[tendangnhap], dbo.quanlynguoidung.[matkhau], [quyenhan] FROM dbo.quanlynguoidung JOIN CHANGETABLE(CHANGES dbo.quanlynguoidung, @sync_last_received_anchor) CT ON CT.[tendangnhap] = dbo.quanlynguoidung.[tendangnhap] AND CT.[matkhau] = dbo.quanlynguoidung.[matkhau] WHERE (CT.SYS_CHANGE_OPERATION = 'I' AND CT.SYS_CHANGE_CREATION_VERSION  <= @sync_new_received_anchor AND (CT.SYS_CHANGE_CONTEXT IS NULL OR CT.SYS_CHANGE_CONTEXT <> @sync_client_id_binary)); IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'dbo.quanlynguoidung')) > @sync_last_received_anchor RAISERROR (N'SQL Server Change Tracking has cleaned up tracking information for table ''%s''. To recover from this error, the client must reinitialize its local database and try again',16,3,N'dbo.quanlynguoidung')  END ";
            this.SelectIncrementalInsertsCommand.CommandType = System.Data.CommandType.Text;
            this.SelectIncrementalInsertsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_initialized", System.Data.SqlDbType.Bit));
            this.SelectIncrementalInsertsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            this.SelectIncrementalInsertsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary));
            this.SelectIncrementalInsertsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_new_received_anchor", System.Data.SqlDbType.BigInt));
            // quanlynguoidungSyncTableSelectIncrementalDeletesCommand command.
            this.SelectIncrementalDeletesCommand = new System.Data.SqlClient.SqlCommand();
            this.SelectIncrementalDeletesCommand.CommandText = @"IF @sync_initialized > 0  BEGIN SELECT CT.[tendangnhap], CT.[matkhau] FROM CHANGETABLE(CHANGES dbo.quanlynguoidung, @sync_last_received_anchor) CT WHERE (CT.SYS_CHANGE_OPERATION = 'D' AND CT.SYS_CHANGE_VERSION <= @sync_new_received_anchor AND (CT.SYS_CHANGE_CONTEXT IS NULL OR CT.SYS_CHANGE_CONTEXT <> @sync_client_id_binary)); IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'dbo.quanlynguoidung')) > @sync_last_received_anchor RAISERROR (N'SQL Server Change Tracking has cleaned up tracking information for table ''%s''. To recover from this error, the client must reinitialize its local database and try again',16,3,N'dbo.quanlynguoidung')  END ";
            this.SelectIncrementalDeletesCommand.CommandType = System.Data.CommandType.Text;
            this.SelectIncrementalDeletesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_initialized", System.Data.SqlDbType.Bit));
            this.SelectIncrementalDeletesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            this.SelectIncrementalDeletesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_new_received_anchor", System.Data.SqlDbType.BigInt));
            this.SelectIncrementalDeletesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary));
            // quanlynguoidungSyncTableSelectIncrementalUpdatesCommand command.
            this.SelectIncrementalUpdatesCommand = new System.Data.SqlClient.SqlCommand();
            this.SelectIncrementalUpdatesCommand.CommandText = @"IF @sync_initialized > 0  BEGIN SELECT dbo.quanlynguoidung.[tendangnhap], dbo.quanlynguoidung.[matkhau], [quyenhan] FROM dbo.quanlynguoidung JOIN CHANGETABLE(CHANGES dbo.quanlynguoidung, @sync_last_received_anchor) CT ON CT.[tendangnhap] = dbo.quanlynguoidung.[tendangnhap] AND CT.[matkhau] = dbo.quanlynguoidung.[matkhau] WHERE (CT.SYS_CHANGE_OPERATION = 'U' AND CT.SYS_CHANGE_VERSION <= @sync_new_received_anchor AND (CT.SYS_CHANGE_CONTEXT IS NULL OR CT.SYS_CHANGE_CONTEXT <> @sync_client_id_binary)); IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'dbo.quanlynguoidung')) > @sync_last_received_anchor RAISERROR (N'SQL Server Change Tracking has cleaned up tracking information for table ''%s''. To recover from this error, the client must reinitialize its local database and try again',16,3,N'dbo.quanlynguoidung')  END ";
            this.SelectIncrementalUpdatesCommand.CommandType = System.Data.CommandType.Text;
            this.SelectIncrementalUpdatesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_initialized", System.Data.SqlDbType.Bit));
            this.SelectIncrementalUpdatesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            this.SelectIncrementalUpdatesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_new_received_anchor", System.Data.SqlDbType.BigInt));
            this.SelectIncrementalUpdatesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary));
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitializeAdapterProperties() {
            this.TableName = "quanlynguoidung";
        }
    }
    
    public partial class Table1SyncAdapter : Microsoft.Synchronization.Data.Server.SyncAdapter {
        
        partial void OnInitialized();
        
        public Table1SyncAdapter() {
            this.InitializeCommands();
            this.InitializeAdapterProperties();
            this.OnInitialized();
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitializeCommands() {
            // Table1SyncTableInsertCommand command.
            this.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this.InsertCommand.CommandText = @";WITH CHANGE_TRACKING_CONTEXT (@sync_client_id_binary) INSERT INTO dbo.Table1 ([STT], [MaSoLoHang], [QuyCach], [NguoiThaoTac], [TLBinhTieuChuan], [DSD], [DST], [DSL], [DSH]) VALUES (@STT, @MaSoLoHang, @QuyCach, @NguoiThaoTac, @TLBinhTieuChuan, @DSD, @DST, @DSL, @DSH) SET @sync_row_count = @@rowcount; IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'dbo.Table1')) > @sync_last_received_anchor RAISERROR (N'SQL Server Change Tracking has cleaned up tracking information for table ''%s''. To recover from this error, the client must reinitialize its local database and try again',16,3,N'dbo.Table1') ";
            this.InsertCommand.CommandType = System.Data.CommandType.Text;
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@STT", System.Data.SqlDbType.NChar));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MaSoLoHang", System.Data.SqlDbType.VarChar));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@QuyCach", System.Data.SqlDbType.VarChar));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NguoiThaoTac", System.Data.SqlDbType.VarChar));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TLBinhTieuChuan", System.Data.SqlDbType.Int));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSD", System.Data.SqlDbType.Real));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DST", System.Data.SqlDbType.Real));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSL", System.Data.SqlDbType.Real));
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSH", System.Data.SqlDbType.Int));
            System.Data.SqlClient.SqlParameter insertcommand_sync_row_countParameter = new System.Data.SqlClient.SqlParameter("@sync_row_count", System.Data.SqlDbType.Int);
            insertcommand_sync_row_countParameter.Direction = System.Data.ParameterDirection.Output;
            this.InsertCommand.Parameters.Add(insertcommand_sync_row_countParameter);
            this.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            // Table1SyncTableDeleteCommand command.
            this.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this.DeleteCommand.CommandText = @";WITH CHANGE_TRACKING_CONTEXT (@sync_client_id_binary) DELETE dbo.Table1 FROM dbo.Table1 JOIN CHANGETABLE(VERSION dbo.Table1, ([MaSoLoHang]), (@MaSoLoHang)) CT  ON CT.[MaSoLoHang] = dbo.Table1.[MaSoLoHang] WHERE (@sync_force_write = 1 OR CT.SYS_CHANGE_VERSION IS NULL OR CT.SYS_CHANGE_VERSION <= @sync_last_received_anchor OR (CT.SYS_CHANGE_CONTEXT IS NOT NULL AND CT.SYS_CHANGE_CONTEXT = @sync_client_id_binary)) SET @sync_row_count = @@rowcount; IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'dbo.Table1')) > @sync_last_received_anchor RAISERROR (N'SQL Server Change Tracking has cleaned up tracking information for table ''%s''. To recover from this error, the client must reinitialize its local database and try again',16,3,N'dbo.Table1') ";
            this.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary));
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MaSoLoHang", System.Data.SqlDbType.VarChar));
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_force_write", System.Data.SqlDbType.Bit));
            this.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            System.Data.SqlClient.SqlParameter deletecommand_sync_row_countParameter = new System.Data.SqlClient.SqlParameter("@sync_row_count", System.Data.SqlDbType.Int);
            deletecommand_sync_row_countParameter.Direction = System.Data.ParameterDirection.Output;
            this.DeleteCommand.Parameters.Add(deletecommand_sync_row_countParameter);
            // Table1SyncTableUpdateCommand command.
            this.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this.UpdateCommand.CommandText = @";WITH CHANGE_TRACKING_CONTEXT (@sync_client_id_binary) UPDATE dbo.Table1 SET [STT] = @STT, [QuyCach] = @QuyCach, [NguoiThaoTac] = @NguoiThaoTac, [TLBinhTieuChuan] = @TLBinhTieuChuan, [DSD] = @DSD, [DST] = @DST, [DSL] = @DSL, [DSH] = @DSH FROM dbo.Table1  JOIN CHANGETABLE(VERSION dbo.Table1, ([MaSoLoHang]), (@MaSoLoHang)) CT  ON CT.[MaSoLoHang] = dbo.Table1.[MaSoLoHang] WHERE (@sync_force_write = 1 OR CT.SYS_CHANGE_VERSION IS NULL OR CT.SYS_CHANGE_VERSION <= @sync_last_received_anchor OR (CT.SYS_CHANGE_CONTEXT IS NOT NULL AND CT.SYS_CHANGE_CONTEXT = @sync_client_id_binary)) SET @sync_row_count = @@rowcount; IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'dbo.Table1')) > @sync_last_received_anchor RAISERROR (N'SQL Server Change Tracking has cleaned up tracking information for table ''%s''. To recover from this error, the client must reinitialize its local database and try again',16,3,N'dbo.Table1') ";
            this.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@STT", System.Data.SqlDbType.NChar));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@QuyCach", System.Data.SqlDbType.VarChar));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NguoiThaoTac", System.Data.SqlDbType.VarChar));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TLBinhTieuChuan", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSD", System.Data.SqlDbType.Real));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DST", System.Data.SqlDbType.Real));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSL", System.Data.SqlDbType.Real));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSH", System.Data.SqlDbType.Int));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MaSoLoHang", System.Data.SqlDbType.VarChar));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_force_write", System.Data.SqlDbType.Bit));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            this.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary));
            System.Data.SqlClient.SqlParameter updatecommand_sync_row_countParameter = new System.Data.SqlClient.SqlParameter("@sync_row_count", System.Data.SqlDbType.Int);
            updatecommand_sync_row_countParameter.Direction = System.Data.ParameterDirection.Output;
            this.UpdateCommand.Parameters.Add(updatecommand_sync_row_countParameter);
            // Table1SyncTableSelectConflictDeletedRowsCommand command.
            this.SelectConflictDeletedRowsCommand = new System.Data.SqlClient.SqlCommand();
            this.SelectConflictDeletedRowsCommand.CommandText = "SELECT CT.[MaSoLoHang], CT.SYS_CHANGE_CONTEXT, CT.SYS_CHANGE_VERSION FROM CHANGET" +
                "ABLE(CHANGES dbo.Table1, @sync_last_received_anchor) CT WHERE (CT.[MaSoLoHang] =" +
                " @MaSoLoHang AND CT.SYS_CHANGE_OPERATION = \'D\')";
            this.SelectConflictDeletedRowsCommand.CommandType = System.Data.CommandType.Text;
            this.SelectConflictDeletedRowsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            this.SelectConflictDeletedRowsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MaSoLoHang", System.Data.SqlDbType.VarChar));
            // Table1SyncTableSelectConflictUpdatedRowsCommand command.
            this.SelectConflictUpdatedRowsCommand = new System.Data.SqlClient.SqlCommand();
            this.SelectConflictUpdatedRowsCommand.CommandText = @"SELECT [STT], dbo.Table1.[MaSoLoHang], [QuyCach], [NguoiThaoTac], [TLBinhTieuChuan], [DSD], [DST], [DSL], [DSH], CT.SYS_CHANGE_CONTEXT, CT.SYS_CHANGE_VERSION FROM dbo.Table1 JOIN CHANGETABLE(VERSION dbo.Table1, ([MaSoLoHang]), (@MaSoLoHang)) CT  ON CT.[MaSoLoHang] = dbo.Table1.[MaSoLoHang]";
            this.SelectConflictUpdatedRowsCommand.CommandType = System.Data.CommandType.Text;
            this.SelectConflictUpdatedRowsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MaSoLoHang", System.Data.SqlDbType.VarChar));
            // Table1SyncTableSelectIncrementalInsertsCommand command.
            this.SelectIncrementalInsertsCommand = new System.Data.SqlClient.SqlCommand();
            this.SelectIncrementalInsertsCommand.CommandText = @"IF @sync_initialized = 0 SELECT [STT], dbo.Table1.[MaSoLoHang], [QuyCach], [NguoiThaoTac], [TLBinhTieuChuan], [DSD], [DST], [DSL], [DSH] FROM dbo.Table1 LEFT OUTER JOIN CHANGETABLE(CHANGES dbo.Table1, @sync_last_received_anchor) CT ON CT.[MaSoLoHang] = dbo.Table1.[MaSoLoHang] WHERE (CT.SYS_CHANGE_CONTEXT IS NULL OR CT.SYS_CHANGE_CONTEXT <> @sync_client_id_binary) ELSE  BEGIN SELECT [STT], dbo.Table1.[MaSoLoHang], [QuyCach], [NguoiThaoTac], [TLBinhTieuChuan], [DSD], [DST], [DSL], [DSH] FROM dbo.Table1 JOIN CHANGETABLE(CHANGES dbo.Table1, @sync_last_received_anchor) CT ON CT.[MaSoLoHang] = dbo.Table1.[MaSoLoHang] WHERE (CT.SYS_CHANGE_OPERATION = 'I' AND CT.SYS_CHANGE_CREATION_VERSION  <= @sync_new_received_anchor AND (CT.SYS_CHANGE_CONTEXT IS NULL OR CT.SYS_CHANGE_CONTEXT <> @sync_client_id_binary)); IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'dbo.Table1')) > @sync_last_received_anchor RAISERROR (N'SQL Server Change Tracking has cleaned up tracking information for table ''%s''. To recover from this error, the client must reinitialize its local database and try again',16,3,N'dbo.Table1')  END ";
            this.SelectIncrementalInsertsCommand.CommandType = System.Data.CommandType.Text;
            this.SelectIncrementalInsertsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_initialized", System.Data.SqlDbType.Bit));
            this.SelectIncrementalInsertsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            this.SelectIncrementalInsertsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary));
            this.SelectIncrementalInsertsCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_new_received_anchor", System.Data.SqlDbType.BigInt));
            // Table1SyncTableSelectIncrementalDeletesCommand command.
            this.SelectIncrementalDeletesCommand = new System.Data.SqlClient.SqlCommand();
            this.SelectIncrementalDeletesCommand.CommandText = @"IF @sync_initialized > 0  BEGIN SELECT CT.[MaSoLoHang] FROM CHANGETABLE(CHANGES dbo.Table1, @sync_last_received_anchor) CT WHERE (CT.SYS_CHANGE_OPERATION = 'D' AND CT.SYS_CHANGE_VERSION <= @sync_new_received_anchor AND (CT.SYS_CHANGE_CONTEXT IS NULL OR CT.SYS_CHANGE_CONTEXT <> @sync_client_id_binary)); IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'dbo.Table1')) > @sync_last_received_anchor RAISERROR (N'SQL Server Change Tracking has cleaned up tracking information for table ''%s''. To recover from this error, the client must reinitialize its local database and try again',16,3,N'dbo.Table1')  END ";
            this.SelectIncrementalDeletesCommand.CommandType = System.Data.CommandType.Text;
            this.SelectIncrementalDeletesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_initialized", System.Data.SqlDbType.Bit));
            this.SelectIncrementalDeletesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            this.SelectIncrementalDeletesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_new_received_anchor", System.Data.SqlDbType.BigInt));
            this.SelectIncrementalDeletesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary));
            // Table1SyncTableSelectIncrementalUpdatesCommand command.
            this.SelectIncrementalUpdatesCommand = new System.Data.SqlClient.SqlCommand();
            this.SelectIncrementalUpdatesCommand.CommandText = @"IF @sync_initialized > 0  BEGIN SELECT [STT], dbo.Table1.[MaSoLoHang], [QuyCach], [NguoiThaoTac], [TLBinhTieuChuan], [DSD], [DST], [DSL], [DSH] FROM dbo.Table1 JOIN CHANGETABLE(CHANGES dbo.Table1, @sync_last_received_anchor) CT ON CT.[MaSoLoHang] = dbo.Table1.[MaSoLoHang] WHERE (CT.SYS_CHANGE_OPERATION = 'U' AND CT.SYS_CHANGE_VERSION <= @sync_new_received_anchor AND (CT.SYS_CHANGE_CONTEXT IS NULL OR CT.SYS_CHANGE_CONTEXT <> @sync_client_id_binary)); IF CHANGE_TRACKING_MIN_VALID_VERSION(object_id(N'dbo.Table1')) > @sync_last_received_anchor RAISERROR (N'SQL Server Change Tracking has cleaned up tracking information for table ''%s''. To recover from this error, the client must reinitialize its local database and try again',16,3,N'dbo.Table1')  END ";
            this.SelectIncrementalUpdatesCommand.CommandType = System.Data.CommandType.Text;
            this.SelectIncrementalUpdatesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_initialized", System.Data.SqlDbType.Bit));
            this.SelectIncrementalUpdatesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_last_received_anchor", System.Data.SqlDbType.BigInt));
            this.SelectIncrementalUpdatesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_new_received_anchor", System.Data.SqlDbType.BigInt));
            this.SelectIncrementalUpdatesCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sync_client_id_binary", System.Data.SqlDbType.VarBinary));
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitializeAdapterProperties() {
            this.TableName = "Table1";
        }
    }
    
    public partial class quan_ly_san_luong_can_LELONGCacheServerSyncProvider : Microsoft.Synchronization.Data.Server.DbServerSyncProvider {
        
        private quanlynguoidungSyncAdapter _quanlynguoidungSyncAdapter;
        
        private Table1SyncAdapter _table1SyncAdapter;
        
        partial void OnInitialized();
        
        public quan_ly_san_luong_can_LELONGCacheServerSyncProvider() {
         //   string connectionString = global::PROJECT_LELONG_MODBUS_VB_PROFACE_REV1.Properties.Settings.Default.quan_ly_san_luong_can_LELONGConnectionString;
           // this.InitializeConnection(connectionString);
            this.InitializeSyncAdapters();
            this.InitializeNewAnchorCommand();
            this.OnInitialized();
        }
        
        public quan_ly_san_luong_can_LELONGCacheServerSyncProvider(string connectionString) {
            this.InitializeConnection(connectionString);
            this.InitializeSyncAdapters();
            this.InitializeNewAnchorCommand();
            this.OnInitialized();
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public quanlynguoidungSyncAdapter quanlynguoidungSyncAdapter {
            get {
                return this._quanlynguoidungSyncAdapter;
            }
            set {
                this._quanlynguoidungSyncAdapter = value;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public Table1SyncAdapter Table1SyncAdapter {
            get {
                return this._table1SyncAdapter;
            }
            set {
                this._table1SyncAdapter = value;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitializeConnection(string connectionString) {
            this.Connection = new System.Data.SqlClient.SqlConnection(connectionString);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitializeSyncAdapters() {
            // Create SyncAdapters.
            this._quanlynguoidungSyncAdapter = new quanlynguoidungSyncAdapter();
            this.SyncAdapters.Add(this._quanlynguoidungSyncAdapter);
            this._table1SyncAdapter = new Table1SyncAdapter();
            this.SyncAdapters.Add(this._table1SyncAdapter);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitializeNewAnchorCommand() {
            // selectNewAnchorCmd command.
            this.SelectNewAnchorCommand = new System.Data.SqlClient.SqlCommand();
            this.SelectNewAnchorCommand.CommandText = "Select @sync_new_received_anchor = CHANGE_TRACKING_CURRENT_VERSION()";
            this.SelectNewAnchorCommand.CommandType = System.Data.CommandType.Text;
            System.Data.SqlClient.SqlParameter selectnewanchorcommand_sync_new_received_anchorParameter = new System.Data.SqlClient.SqlParameter("@sync_new_received_anchor", System.Data.SqlDbType.BigInt);
            selectnewanchorcommand_sync_new_received_anchorParameter.Direction = System.Data.ParameterDirection.Output;
            this.SelectNewAnchorCommand.Parameters.Add(selectnewanchorcommand_sync_new_received_anchorParameter);
        }
    }
}
