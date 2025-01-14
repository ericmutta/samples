﻿' <Snippet1>
Imports System
Imports System.Xml

public class Sample 

  public shared sub Main() 
 
    ' Create the XmlDocument.
    Dim doc as XmlDocument = new XmlDocument()
    doc.LoadXml("<item><name>wrench</name></item>")

    ' Add a price element.
    Dim newElem as XmlElement = doc.CreateElement("price")
    newElem.InnerText = "10.95"
    doc.DocumentElement.AppendChild(newElem)

    ' Save the document to a file. White space is
    ' preserved (no white space).
    doc.PreserveWhitespace = true
    doc.Save("data.xml")
 
  end sub
end class
' </Snippet1>