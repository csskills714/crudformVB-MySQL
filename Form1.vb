Imports MySql.Data.MySqlClient




Public Class Form1

    Dim str As String = "server=localhost; uid=root; pwd=alpha1337; database=dpprofile"
    Dim con As New MySqlConnection(str)

    Sub load()
        Dim query As String = "select * from profile"
        Dim adpt As New MySqlDataAdapter(query, con)
        Dim ds As New DataSet
        adpt.Fill(ds, "Emp")
        DataGridView1.DataSource = ds.Tables(0)
        con.Close()
        TextBox1.Clear()
        TextBox5.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick, DataGridView1.CellClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        Try
            'TextBox1.Text = row.Cells(0).Value.ToString()
            TextBox5.Text = row.Cells(1).Value.ToString()
            TextBox3.Text = row.Cells(2).Value.ToString()
            TextBox4.Text = row.Cells(3).Value.ToString()
        Catch ex As Exception

        End Try

    End Sub


    Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnInput.Click

        Dim cmd As MySqlCommand
        con.Open()
        Try
            cmd = con.CreateCommand
            cmd.CommandText = "insert into profile(id,name,email,website)values(,@name,@email,@website,@id);"
            cmd.Parameters.AddWithValue("@id", TextBox1.Text)
            cmd.Parameters.AddWithValue("@name", TextBox5.Text)
            cmd.Parameters.AddWithValue("@email", TextBox3.Text)
            cmd.Parameters.AddWithValue("@website", TextBox4.Text)
            cmd.ExecuteNonQuery()
            load()
            con.Close()

        Catch ex As Exception


        End Try
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        load()

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim cmd As MySqlCommand
        con.Open()

        Try
            cmd = con.CreateCommand
            cmd.CommandText = "update profile set name=@name, email=@email, website=@website where id=@id"
            cmd.Parameters.AddWithValue("@id", TextBox1.Text)
            cmd.Parameters.AddWithValue("@name", TextBox5.Text)
            cmd.Parameters.AddWithValue("@email", TextBox3.Text)
            cmd.Parameters.AddWithValue("@website", TextBox4.Text)
            cmd.ExecuteNonQuery()
            load()

            con.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim cmd As MySqlCommand
        con.Open()
        Try
            cmd = con.CreateCommand
            cmd.CommandText = " delete from profile where id=@id"
            cmd.Parameters.AddWithValue("@id", TextBox1.Text)
            cmd.Parameters.AddWithValue("@name", TextBox5.Text)
            cmd.Parameters.AddWithValue("@email", TextBox3.Text)
            cmd.Parameters.AddWithValue("@website", TextBox4.Text)
            cmd.ExecuteNonQuery()
            load()

            con.Close()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        Dim adapter As MySqlDataAdapter
        Dim ds As New DataSet
        Try
            con.Open()
            adapter = New MySqlDataAdapter("select * from profile where name like '%" & TextBox6.Text & "%'", con)
            adapter.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            con.Close()
            TextBox1.Clear()
            TextBox5.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
        Catch ex As Exception

        End Try
    End Sub
End Class
