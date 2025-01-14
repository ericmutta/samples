﻿Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Collections.Generic

Namespace Samples.VB

    <TargetControlType(GetType(Control))> _
    Public Class FocusExtender
        Inherits ExtenderControl

        Private _highlightCssClass As String
        Private _noHighlightCssClass As String

        Public Property HighlightCssClass() As String
            Get
                Return _highlightCssClass
            End Get
            Set(ByVal value As String)
                _highlightCssClass = value
            End Set
        End Property

        Public Property NoHighlightCssClass() As String
            Get
                Return _noHighlightCssClass
            End Get
            Set(ByVal value As String)
                _noHighlightCssClass = value
            End Set
        End Property
' <Snippet14>
        Protected Overrides Function GetScriptReferences() As IEnumerable(Of ScriptReference)
            Dim reference As ScriptReference = New ScriptReference()
			reference.Assembly = "Samples"
			reference.Name = "Samples.FocusBehavior.js"

            Return New ScriptReference() {reference}
        End Function
' </Snippet14>
        Protected Overrides Function GetScriptDescriptors(ByVal targetControl As Control) As IEnumerable(Of ScriptDescriptor)
            Dim descriptor As ScriptBehaviorDescriptor = New ScriptBehaviorDescriptor("Samples.FocusBehavior", targetControl.ClientID)
            descriptor.AddProperty("highlightCssClass", Me.HighlightCssClass)
            descriptor.AddProperty("nohighlightCssClass", Me.NoHighlightCssClass)

            Return New ScriptDescriptor() {descriptor}
        End Function
    End Class
End Namespace
