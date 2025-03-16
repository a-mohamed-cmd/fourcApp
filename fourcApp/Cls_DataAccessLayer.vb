Imports Guna.UI2.WinForms
Imports Microsoft.Data.SqlClient

Public Class Cls_DataAccessLayer

    Public cn As SqlConnection

#Region "التهيئة وفتح الاتصال"

    ''' <summary>
    ''' إنشاء كائن الاتصال بقاعدة البيانات وتحديد السيرفر وقاعدة البيانات
    ''' </summary>
    Public Sub New(Optional ByVal database As String = "db_fourc", Optional ByVal server As String = ".\SQLEXPRESS")
        Try
            Dim connectionString = $"Server={server};Database={database};User ID =mohamed;Password=125630;TrustServerCertificate=True"

            cn = New SqlConnection(connectionString)
        Catch ex As Exception
            MsgBox("خطأ في الاتصال بقاعدة البيانات:" & vbCrLf & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' فتح الاتصال بقاعدة البيانات إذا لم يكن مفتوحًا
    ''' </summary>
    Public Sub OpenConnection()
        If cn.State <> ConnectionState.Open Then cn.Open()
    End Sub

    ''' <summary>
    ''' إغلاق الاتصال بقاعدة البيانات إذا كان مفتوحًا
    ''' </summary>
    Public Sub CloseConnection()
        If cn.State = ConnectionState.Open Then cn.Close()
    End Sub

#End Region

#Region "استعلامات البيانات"

    ''' <summary>
    ''' تنفيذ استعلام SELECT وإرجاع البيانات في DataTable
    ''' </summary>
    Public Function SelectData(ByVal sql As String) As DataTable
        Dim dt As New DataTable()
        Try
            Using cmd As New SqlCommand(sql, cn)
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            MsgBox("خطأ في جلب البيانات: " & ex.Message)
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' تنفيذ استعلام SELECT وإرجاع البيانات في DataTable
    ''' </summary>
    Function ExecuteSelectData(spName As String, Optional params() As SqlParameter = Nothing) As DataTable
        Dim dt As New DataTable
        Try

            Using cmd As New SqlCommand(spName, cn)
                cmd.CommandType = CommandType.StoredProcedure
                If params IsNot Nothing Then
                    cmd.Parameters.AddRange(params)
                End If
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
            Return dt

        Catch ex As Exception
            MsgBox("خطأ في تنفيذ الإجراء المخزن: " & ex.Message)
            Return dt
        End Try
    End Function

    ''' <summary>
    ''' تنفيذ استعلام INSERT أو UPDATE أو DELETE وإرجاع عدد الصفوف المتأثرة
    ''' </summary>
    Public Function ExecuteNonQuery(ByVal sql As String, Optional params() As SqlParameter = Nothing) As Integer
        Try
            Using cmd As New SqlCommand(sql, cn)
                cmd.CommandType = CommandType.StoredProcedure
                If params IsNot Nothing Then
                    cmd.Parameters.AddRange(params)
                End If
                OpenConnection()
                Dim rows = cmd.ExecuteNonQuery()
                CloseConnection()
                Return rows
            End Using
        Catch ex As Exception
            MsgBox("فشل التنفيذ: " & ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' تنفيذ استعلام وإرجاع نتيجة واحدة فقط (مثل COUNT أو MAX أو ID)
    ''' </summary>
    Public Function ExecuteScalar(ByVal sql As String) As Integer
        Try
            Using cmd As New SqlCommand(sql, cn)
                OpenConnection()
                Dim result = cmd.ExecuteScalar()
                CloseConnection()
                Return Convert.ToInt32(result)
            End Using
        Catch ex As Exception
            MsgBox("فشل الإرجاع: " & ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' تنفيذ استعلام وإرجاع نتيجة واحدة فقط output)
    ''' </summary>
    Public Function ExecuteScalarOutput(ByVal sql As String, parameter As String) As Integer
        Try
            Using cmd As New SqlCommand(sql, cn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add(parameter, SqlDbType.Int).Direction = ParameterDirection.Output
                OpenConnection()
                cmd.ExecuteScalar()
                CloseConnection()
                Return CInt(cmd.Parameters(parameter).Value)
            End Using
        Catch ex As Exception
            MsgBox("فشل الإرجاع: " & ex.Message)
            Return 0
        End Try
    End Function
#End Region

#Region "التعامل مع الصور"

    ''' <summary>
    ''' تنفيذ استعلام SELECT لإرجاع صورة مخزنة كـ Byte Array
    ''' </summary>
    Public Function SelectImage(ByVal sql As String) As Byte()
        Try
            Using cmd As New SqlCommand(sql, cn)
                OpenConnection()
                Dim imgData = CType(cmd.ExecuteScalar(), Byte())
                CloseConnection()
                Return imgData
            End Using
        Catch ex As Exception
            CloseConnection()
            MsgBox("خطأ في جلب الصورة: " & ex.Message)
            Return Nothing
        End Try
    End Function

#End Region

#Region "حفظ التعديلات بالجملة"

    ''' <summary>
    ''' حفظ التعديلات التي تمت على DataTable باستخدام SqlDataAdapter
    ''' </summary>
    Public Shared Function SaveData(ByVal adapter As SqlDataAdapter, ByVal dt As DataTable) As Integer
        Try
            Dim builder As New SqlCommandBuilder(adapter)
            adapter.UpdateCommand = builder.GetUpdateCommand()
            Dim affectedRows = adapter.Update(dt)
            If affectedRows > 0 Then dt.AcceptChanges()
            Return affectedRows
        Catch ex As Exception
            MsgBox("خطأ أثناء الحفظ: " & ex.Message)
            Return 0
        End Try
    End Function

#End Region

#Region "نسخة احتياطية واستعادة"

    ''' <summary>
    ''' عمل نسخة احتياطية من قاعدة البيانات إلى المسار المحدد
    ''' </summary>
    Public Function BackupDatabase(Optional ByVal path As String = "D:\") As Boolean
        Try
            CloseConnection()
            Dim cmd As New SqlCommand("BACKUP DATABASE doctor TO DISK='" & path & "'", cn)
            OpenConnection()
            cmd.ExecuteNonQuery()
            CloseConnection()
            MsgBox("تم النسخ الاحتياطي بنجاح")
            Return True
        Catch ex As Exception
            MsgBox("فشل النسخ الاحتياطي: " & ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' استعادة نسخة احتياطية من قاعدة البيانات من المسار المحدد
    ''' </summary>
    Public Function RestoreDatabase(Optional ByVal database As String = "doctor", Optional ByVal path As String = "D:\") As Boolean
        Try
            CloseConnection()
            Dim cmd As New SqlCommand($"RESTORE DATABASE {database} FROM DISK='{path}'", cn)
            OpenConnection()
            cmd.ExecuteNonQuery()
            CloseConnection()
            MsgBox("تم استعادة النسخة الاحتياطية بنجاح")
            Return True
        Catch ex As Exception
            MsgBox("فشل استعادة النسخة: " & ex.Message)
            Return False
        End Try
    End Function

#End Region

#Region "أدوات مساعدة"

    ''' <summary>
    ''' مسح جميع TextBox داخل عنصر الحاوية المحدد
    ''' </summary>
    Public Shared Sub ClearTextBoxes(ByVal container As Control)
        For Each ctrl As Control In container.Controls
            If TypeOf ctrl Is Guna2TextBox Then CType(ctrl, Guna2TextBox).Clear()

        Next
    End Sub

    ''' <summary>
    ''' السماح فقط بكتابة الأرقام (مع خيار السماح بالنقطة العشرية)
    ''' </summary>
    Public Shared Sub AllowOnlyNumbers(ByVal e As KeyPressEventArgs, Optional allowDecimal As Boolean = False)
        If Char.IsDigit(e.KeyChar) OrElse e.KeyChar = ChrW(Keys.Back) Then
            e.Handled = False
        ElseIf allowDecimal AndAlso e.KeyChar = "."c Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' السماح فقط بكتابة الحروف
    ''' </summary>
    Public Shared Sub AllowOnlyLetters(ByVal e As KeyPressEventArgs)
        If Char.IsLetter(e.KeyChar) OrElse e.KeyChar = ChrW(Keys.Back) OrElse e.KeyChar = ChrW(Keys.Space) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

#End Region

    ''' <summary>
    ''' تنفيذ إجراء مخزن (Stored Procedure) مع باراميترات
    ''' </summary>
    ''' <param name="spName">اسم الإجراء المخزن</param>
    ''' <param name="params">مصفوفة الباراميترات</param>
    Function ExecuteStoredProcedure(spName As String, params() As SqlParameter) As Integer
        Try
            Using cmd As New SqlCommand(spName, cn)
                cmd.CommandType = CommandType.StoredProcedure
                If params IsNot Nothing Then
                    cmd.Parameters.AddRange(params)
                End If
                OpenConnection()
                Dim result = cmd.ExecuteNonQuery()
                CloseConnection()
                Return result
            End Using
        Catch ex As Exception
            MsgBox("خطأ في تنفيذ الإجراء المخزن: " & ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' تنفيذ إجراء مخزن (Stored Procedure) وإرجاع قيمة واحدة
    ''' </summary>
    ''' <param name="spName">اسم الإجراء</param>
    ''' <param name="params">مصفوفة الباراميترات</param>
    Function ExecuteStoredScalar(spName As String, Optional params() As SqlParameter = Nothing) As Object
        Try
            Using cmd As New SqlCommand(spName, cn)
                cmd.CommandType = CommandType.StoredProcedure
                If params IsNot Nothing Then
                    cmd.Parameters.AddRange(params)
                End If
                OpenConnection()
                Dim result = cmd.ExecuteScalar()
                CloseConnection()
                Return result
            End Using
        Catch ex As Exception
            MsgBox("خطأ في تنفيذ ExecuteScalar: " & ex.Message)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' تنفيذ مجموعة أوامر داخل Transaction مع إمكانية التراجع في حالة حدوث خطأ
    ''' </summary>
    ''' <param name="commands">قائمة الأوامر المطلوب تنفيذها داخل المعاملة</param>
    Function ExecuteWithTransaction(commands As List(Of SqlCommand)) As Boolean
        Dim trans As SqlTransaction = Nothing
        Try
            OpenConnection()
            trans = cn.BeginTransaction()

            For Each cmd In commands
                cmd.Connection = cn
                cmd.Transaction = trans
                cmd.ExecuteNonQuery()
            Next

            trans.Commit()
            CloseConnection()
            Return True
        Catch ex As Exception
            If trans IsNot Nothing Then
                trans.Rollback()
            End If
            CloseConnection()
            MsgBox("حدث خطأ وتم التراجع عن العمليات: " & ex.Message)
            Return False
        End Try
    End Function

End Class
