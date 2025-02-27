﻿Option Explicit
Option Strict

Imports System
Imports System.Data

    
Module Module1

  Sub Main()
    DemonstrateReadWriteXMLSchemaWithReader()
    Console.WriteLine("Press any key to continue.")
    Console.ReadKey()
  End Sub
' <Snippet1>
  Private Sub DemonstrateReadWriteXMLSchemaWithReader()
    Dim table As DataTable = CreateTestTable("XmlDemo")
    PrintSchema(table, "Original table")

    ' Write the schema to XML in a memory stream.
    Dim xmlStream As New System.IO.MemoryStream()
    table.WriteXmlSchema(xmlStream)

    ' Rewind the memory stream.
    xmlStream.Position = 0

    Dim newTable As New DataTable
    Dim reader As New System.IO.StreamReader(xmlStream)
    newTable.ReadXmlSchema(reader)

    ' Print out values in the table.
    PrintSchema(newTable, "New Table")
  End Sub

  Private Function CreateTestTable(ByVal tableName As String) _
    As DataTable

    ' Create a test DataTable with two columns and a few rows.
    Dim table As New DataTable(tableName)
    Dim column As New DataColumn("id", GetType(System.Int32))
    column.AutoIncrement = True
    table.Columns.Add(column)

    column = New DataColumn("item", GetType(System.String))
    table.Columns.Add(column)

    ' Add ten rows.
    Dim row As DataRow
    For i As Integer = 0 To 9
      row = table.NewRow()
      row("item") = "item " & i
      table.Rows.Add(row)
    Next i

    table.AcceptChanges()
    Return table
  End Function

  Private Sub PrintSchema(ByVal table As DataTable, _
    ByVal label As String)

    ' Display the schema of the supplied DataTable:
    Console.WriteLine(label)
    For Each column As DataColumn In table.Columns
      Console.WriteLine("{0}{1}: {2}", ControlChars.Tab, _
        column.ColumnName, column.DataType.Name)
    Next column
  End Sub
' </Snippet1>

End Module
