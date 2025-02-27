﻿Option Explicit
Option Strict

' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml.Serialization
Imports System.Collections
Imports System.Xml


Public Class Transportation
    ' Override these two XmlElementAttributes.
    <XmlElement(GetType(Car)), _
     XmlElement(GetType(Plane))> _
    Public Vehicles As ArrayList
End Class

Public Class Car
    Public Name As String
End Class

Public Class Plane
    Public Name As String
End Class

Public Class Truck
    Public Name As String
End Class

Public Class Train
    Public Name As String
End Class

Public Class Test
    
    Public Shared Sub Main()
        Dim t As New Test()
        t.SerializeObject("OverrideElement.xml")
    End Sub
    
    
    Public Function CreateOverrider() As XmlSerializer
        ' Create XmlAtrributes and XmlAttributeOverrides instances. 
        Dim attrs As New XmlAttributes()
        
        Dim xOver As New XmlAttributeOverrides()
        
        ' Create an XmlElementAttributes object to override
        ' one of the attributes applied to the Vehicles property. 
        Dim xElement1 As New XmlElementAttribute(GetType(Truck))
        ' Add the XmlElementAttribute to the collection.
        attrs.XmlElements.Add(xElement1)
        
        ' Create a second XmlElementAttribute and
        ' add it to the collection. 
        Dim xElement2 As New XmlElementAttribute(GetType(Train))
        attrs.XmlElements.Add(xElement2)
        
        ' Add the XmlAttributes to the XmlAttributeOverrides,
        ' specifying the member to override. 
        xOver.Add(GetType(Transportation), "Vehicles", attrs)
        
        ' Create the XmlSerializer, and return it.
        Dim xSer As New XmlSerializer(GetType(Transportation), xOver)
        Return xSer
    End Function
    
    
    Public Sub SerializeObject(ByVal filename As String)
        ' Create an XmlSerializer instance.
        Dim xSer As XmlSerializer = CreateOverrider()
        
        ' Create the object.
        Dim myTransportation As New Transportation()
        
        ' Create two new, overriding objects that can be
        ' inserted into the Vehicles array. 
        myTransportation.Vehicles = New ArrayList()
        Dim myTruck As New Truck()
        myTruck.Name = "MyTruck"
        
        Dim myTrain As New Train()
        myTrain.Name = "MyTrain"
        
        myTransportation.Vehicles.Add(myTruck)
        myTransportation.Vehicles.Add(myTrain)
        
        Dim writer As New StreamWriter(filename)
        xSer.Serialize(writer, myTransportation)
    End Sub
End Class

' </Snippet1>
