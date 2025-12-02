Imports MySql.Data.MySqlClient

Public Class Form1

    Dim conn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click

        conn = New MySqlConnection
        conn.ConnectionString = "server=localhost; userid=root; password=root; database=patient_record_system;"

        Try

            conn.Open()
            MessageBox.Show("Connected!")

        Catch ex As Exception

            MessageBox.Show(ex.Message)
            conn.Close()

        End Try


    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click

        Dim query As String = "INSERT INTO `patient_record_system`.`patient_record_system` (`id`, `name`, `age`, `room_number`) VALUES (@id, @name, @age, @room_number);"
        Try
            Using conn As New MySqlConnection("server=localhost; userid=root; password=root; database=patient_record_system;")

                conn.Open()
                Using cmd As New MySqlCommand(query, conn)

                    cmd.Parameters.AddWithValue("@id", CInt(txtPatientID.Text))
                    cmd.Parameters.AddWithValue("@name", txtPatientName.Text)
                    cmd.Parameters.AddWithValue("@age", CInt(txtPatientAge.Text))
                    cmd.Parameters.AddWithValue("@room_number", CInt(txtRoomNumber.Text))

                    cmd.ExecuteNonQuery()

                    MessageBox.Show("Record insert successful!")

                    txtPatientID.Clear()
                    txtPatientName.Clear()
                    txtPatientAge.Clear()
                    txtRoomNumber.Clear()

                End Using

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnRead_Click(sender As Object, e As EventArgs) Handles btnRead.Click

        Dim query As String = "SELECT * FROM patient_record_system.patient_record_system"

        Try
            Using conn As New MySqlConnection("server=localhost; userid=root; password=root; database=patient_record_system;")

                Dim adapter As New MySqlDataAdapter(query, conn)
                Dim table As New DataTable()

                adapter.Fill(table)
                DataGridView1.DataSource = table

                DataGridView1.Columns("id").Visible = False

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick

        If e.RowIndex >= 0 Then

            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

            txtPatientID.Text = selectedRow.Cells("id").Value.ToString()
            txtPatientName.Text = selectedRow.Cells("name").Value.ToString()
            txtPatientAge.Text = selectedRow.Cells("age").Value.ToString()
            txtRoomNumber.Text = selectedRow.Cells("room_number").Value.ToString()

        End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        'Dim query As String = "DELETE FROM `crud_demo_db`.`students_tbl` WHERE (`id` = @id);"
        Dim query As String = "UPDATE `patient_record_system`.`patient_record_system` 
                                WHERE (`id` = @id);"

        Try
            Using conn As New MySqlConnection("server=localhost; userid=root; password=root; database=patient_record_system;")

                conn.Open()
                Using cmd As New MySqlCommand(query, conn)

                    cmd.Parameters.AddWithValue("@id", CInt(txtPatientID.Text))

                    cmd.ExecuteNonQuery()

                    MessageBox.Show("Record deleted successfully!")

                    txtPatientID.Clear()
                    txtPatientName.Clear()
                    txtPatientAge.Clear()
                    txtRoomNumber.Clear()

                End Using

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Dim query As String = "UPDATE `patient_record_system`.`patient_record_system` 
                                SET `id` = @id,
                                    `name` = @name,
                                    `age` = @age
                                    `room_number` = @room_number 
                                     WHERE (`id` = @id);"

        Try
            Using conn As New MySqlConnection("server=localhost; userid=root; password=root; database=patient_record_system;")

                conn.Open()
                Using cmd As New MySqlCommand(query, conn)

                    cmd.Parameters.AddWithValue("@id", CInt(txtPatientID.Text))
                    cmd.Parameters.AddWithValue("@name", (txtPatientName.Text))
                    cmd.Parameters.AddWithValue("@age", CInt(txtPatientAge.Text))
                    cmd.Parameters.AddWithValue("@room_number", CInt(txtRoomNumber.Text))

                    cmd.ExecuteNonQuery()

                    MessageBox.Show("Record updated successfully!")

                    txtPatientID.Clear()
                    txtPatientName.Clear()
                    txtPatientAge.Clear()
                    txtRoomNumber.Clear()

                End Using

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

End Class
