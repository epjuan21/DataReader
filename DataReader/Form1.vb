Imports System.Data.SqlClient
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Cadena de Conexion
        Dim builder As New SqlConnectionStringBuilder
        builder("Data Source") = "SERVIDOR01\SQLEXPRESS"
        builder("Integrated Security") = True
        builder("Initial Catalog") = "AdventureWorks2012"

        Using connection As New SqlConnection(builder.ConnectionString)
            connection.Open()
            Dim dt As New DataTable("HumanResources.Employee")
            dt.Columns.Add("NationalIDNumber")
            dt.Columns.Add("JobTitle")
            dt.Columns.Add("BirthDate")

            Dim cmd As New SqlCommand("Select NationalIDNumber,JobTitle,BirthDate From HumanResources.Employee", connection)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                Dim row As DataRow = dt.NewRow
                row(0) = dr.GetString(0)
                row(1) = dr.GetString(1)
                row(2) = dr.GetDateTime(2)
                dt.Rows.Add(row)
            End While
            DataGridView1.DataSource = dt



        End Using
    End Sub
End Class
