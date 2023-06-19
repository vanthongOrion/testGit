Imports Oracle.ManagedDataAccess.Client
Imports Oracle.ManagedDataAccess.Types
Imports System
Imports System.Data

Module Program
    Sub Main(args As String())

        Dim dt = InitDt()

        Dim jmemidList = dt.AsEnumerable.Select(Function(v) v.Field(Of String)("jmemid")).ToList


        jmemidList.ForEach(Sub(jmemid)

                               Using datatable As DataTable = dt.AsEnumerable.Where(Function(x) x.Field(Of String)("jmemid") = jmemid).CopyToDataTable

                                   Dim row As DataRow = datatable.NewRow
                                   row(2) = "thong"
                                   datatable.Rows.InsertAt(row, 0)



                               End Using

                           End Sub)

    End Sub

    Private Sub doSub()
        Dim oCol As DataColumn
        Dim oRow As DataRow

        Using oTable As New DataTable
            oCol = New DataColumn
            oTable.Columns.Add(oCol)
            oRow = oTable.NewRow
            oRow(0) = "FALSE"
            oTable.Rows.Add(oRow)

            Console.WriteLine(oRow(0))

            oTable.Select.ToList.ForEach(Sub(Row) Row(0) = CStr(Row(0)).ToLower)


            Console.WriteLine(oRow(0))
        End Using

        doSub()
        Dim oColumns As List(Of DataColumn)
        Dim oRows As List(Of DataRow)
        'Dim oRow As DataRow

        Using oTable As New DataTable
            oTable.Columns.Add(New DataColumn("Weight", GetType(Integer)))
            oTable.Columns.Add(New DataColumn("IsHeavy", GetType(String)))
            oRow = oTable.NewRow
            oRow(0) = 123
            oRow(1) = "False"
            oTable.Rows.Add(oRow)
            oColumns = oTable.Columns.Cast(Of DataColumn).Where(Function(Column) Column.DataType = GetType(String)).ToList

            Console.WriteLine(oRow(1))

            oRows = oTable.Select.ToList
            oRows.ForEach(Sub(Row)
                              oColumns.ForEach(Sub(Column)
                                                   If Boolean.TryParse(oRow(Column.Ordinal), Nothing) Then
                                                       Row(Column.Ordinal) = CStr(oRow(Column.Ordinal)).ToLower
                                                   End If
                                               End Sub)
                          End Sub)



            Console.WriteLine(oRow(1))
        End Using

        Console.ReadKey()
    End Sub

    Private Function InitDt() As DataTable



        Dim dataTable As New DataTable
        Dim dataColumn1 = New DataColumn("jmemid")
        Dim dataColumn2 = New DataColumn("jname")
        Dim dataColumn3 = New DataColumn("jtel")
        Dim dataColumn4 = New DataColumn("jadr")
        Dim dataColumn5 = New DataColumn("nmemid")
        Dim dataColumn6 = New DataColumn("name")
        Dim dataColumn7 = New DataColumn("ntel")
        Dim dataColumn8 = New DataColumn("nadr")

        dataTable.Columns.Add(dataColumn1)
        dataTable.Columns.Add(dataColumn2)
        dataTable.Columns.Add(dataColumn3)
        dataTable.Columns.Add(dataColumn4)
        dataTable.Columns.Add(dataColumn5)
        dataTable.Columns.Add(dataColumn6)
        dataTable.Columns.Add(dataColumn7)
        dataTable.Columns.Add(dataColumn8)

        Dim rows As DataRow
        rows = dataTable.NewRow

        rows.Item(0) = "1"
        rows.Item(1) = "thong"
        rows.Item(2) = "1234000"
        rows.Item(3) = "tokyo"
        rows.Item(4) = "1234"
        rows.Item(5) = "thuyet"
        rows.Item(6) = "1789"
        rows.Item(7) = "tochigi"

        Dim rows2 = dataTable.NewRow

        rows2.Item(0) = "1"
        rows2.Item(1) = "thong"
        rows2.Item(2) = "1234000"
        rows2.Item(3) = "tokyo"
        rows2.Item(4) = "456"
        rows2.Item(5) = "khoa"
        rows2.Item(6) = "789"
        rows2.Item(7) = "nghean"

        Dim rows3 = dataTable.NewRow

        rows3.Item(0) = "2"
        rows3.Item(1) = "kiet"
        rows3.Item(2) = "999999"
        rows3.Item(3) = "yenthanh"
        rows3.Item(4) = "1"
        rows3.Item(5) = "thong"
        rows3.Item(6) = "1234000"
        rows3.Item(7) = "tokyo"


        dataTable.Rows.Add(rows)
        dataTable.Rows.Add(rows2)
        dataTable.Rows.Add(rows3)
        dataTable.AcceptChanges()

        Return dataTable
    End Function
End Module
