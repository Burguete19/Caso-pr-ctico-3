Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://localhost/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class Calzado
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function BuscaRegistro(ByVal cadena As String) As DataSet

        Dim ds As New DataSet

        Conexiones.AbrirConexion()

        Conexiones.adaptador = New SqlClient.SqlDataAdapter("select * from Calzado where Marca like'%" & cadena & "%'", Conexiones.Cnn)
        Conexiones.adaptador.Fill(ds)

        Return ds
    End Function

    <WebMethod()>
    Public Function NuevoRegistro(ByVal Marca As String, ByVal Modelo As String, ByVal Talla As String, ByVal Color As String, ByVal Precio As String)
        Conexiones.AbrirConexion()
        Conexiones.Cnn.Open()

        Conexiones.comando = New SqlClient.SqlCommand("insert into Calzado(Marca, Modelo, Talla, Color, Precio) values('" & Marca & "','" & Modelo & "','" & Talla & "','" & Color & "','" & Precio & "')", Conexiones.Cnn)
        Conexiones.comando.ExecuteNonQuery()

        Conexiones.Cnn.Close()
        Return True
    End Function

    <WebMethod()>
    Public Function ActualizarRegistro(ByVal Id_Calzado As Integer, ByVal Marca As String, ByVal Modelo As String, ByVal Talla As String, ByVal Color As String, ByVal Precio As String)
        Conexiones.AbrirConexion()
        Conexiones.Cnn.Open()

        Conexiones.comando = New SqlClient.SqlCommand("update Calzado set Marca='" & Marca & "',Modelo='" & Modelo & "', Talla='" & Talla & "',Color= '" & Color & "'Precio= '" & Precio & "' where Id=" & Id_Calzado, Conexiones.Cnn)
        Conexiones.comando.ExecuteNonQuery()

        Conexiones.Cnn.Close()
        Return True
    End Function

    <WebMethod()>
    Public Function EliminarRegistro(ByVal Id_Calzado As Integer)
        Conexiones.AbrirConexion()
        Conexiones.Cnn.Open()

        Conexiones.comando = New SqlClient.SqlCommand("delete from Calzado where Id_Calzado=" & Id_Calzado, Conexiones.Cnn)
        Conexiones.comando.ExecuteNonQuery()

        Conexiones.Cnn.Close()
        Return True
    End Function


End Class
