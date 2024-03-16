Imports System.Web
Imports System.Data.SqlClient

Public Class Conexiones
    Public Shared adaptador As SqlClient.SqlDataAdapter
    Public Shared comando As SqlClient.SqlCommand
    Public Shared Cnn As SqlClient.SqlConnection

    Public Shared Sub AbrirConexion()
        Cnn = New SqlConnection("Server=localhost\SQLEXPRESS;Database=BD_Tienda;User Id=Yolanda;Password=5690*;")

    End Sub

End Class
