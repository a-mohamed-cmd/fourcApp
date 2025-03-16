Module Mdl_force
    Private ReadOnly Server = "192.168.43.129\SQLEXPRESS"
    Private ReadOnly Database = "db_fourc"
    Public sqlMethod As New Cls_DataAccessLayer(Database, server)
    Private _dtLogin As DataTable

    Public Property DtLogin As DataTable
        Get
            Return _dtLogin
        End Get
        Set(value As DataTable)
            _dtLogin = value
        End Set
    End Property

End Module
