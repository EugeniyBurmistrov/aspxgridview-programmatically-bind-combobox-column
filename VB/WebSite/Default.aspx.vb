Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Collections.Generic
Imports DevExpress.Web

Namespace BindToList
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Private statuses As List(Of BugStatus)
		Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
			ASPxGridView1.DataSource = Bug.GetBugList()
			ASPxGridView1.KeyFieldName = "Id"

			statuses = BugStatus.GetStatusesList()
			CType(ASPxGridView1.Columns("Status"), GridViewDataComboBoxColumn).PropertiesComboBox.DataSource = statuses
		End Sub
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			ASPxGridView1.DataBind()
		End Sub


		Protected Sub ASPxGridView1_CellEditorInitialize(ByVal sender As Object, ByVal e As ASPxGridViewEditorEventArgs)
			If e.Column.FieldName = "Status" Then
				Dim combo As ASPxComboBox = CType(e.Editor, ASPxComboBox)
				combo.DataBind()
			End If
		End Sub

		Protected Sub ASPxGridView1_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
			' this demo does not fully implement editing capabilities
			e.Cancel = True
			ASPxGridView1.CancelEdit()
		End Sub
	End Class
End Namespace
