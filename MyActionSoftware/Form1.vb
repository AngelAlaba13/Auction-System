Public Class Form1

    ' Declare panels and controls
    Private panelContainer As Panel
    Private backgroundPanel As Panel
    Private userNameBox As TextBox
    Private passwordBox As TextBox
    Private underlineUsername As Label
    Private underlinePassword As Label
    Private logInButton As Button
    Private createAccountLabel As Label

    ' This event fires when the form is loaded
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ensure the form starts maximized
        Me.WindowState = FormWindowState.Maximized
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.White

        ' STEP 1: Initialize and add background panel first
        backgroundPanel = New Panel()
        backgroundPanel.Size = New Size(950, 700) ' Smaller background panel
        backgroundPanel.BackColor = Color.Transparent
        backgroundPanel.BorderStyle = BorderStyle.Fixed3D
        Me.Controls.Add(backgroundPanel) ' Add to form first!
        AddHandler backgroundPanel.Paint, AddressOf BackgroundPanel_Paint ' Enable custom painting

        ' STEP 2: Initialize and add panelContainer inside backgroundPanel
        panelContainer = New Panel()
        panelContainer.Size = New Size(400, 250) ' Set fixed size
        panelContainer.BackColor = Color.White
        panelContainer.BorderStyle = BorderStyle.FixedSingle
        backgroundPanel.Controls.Add(panelContainer) ' Now it's safe to add

        ' STEP 3: Initialize Username TextBox
        userNameBox = New TextBox()
        userNameBox.Width = 300
        userNameBox.BorderStyle = BorderStyle.None
        userNameBox.Font = New Font("Arial", 14, FontStyle.Regular)
        userNameBox.TextAlign = HorizontalAlignment.Center
        panelContainer.Controls.Add(userNameBox)

        ' STEP 4: Initialize Password TextBox
        passwordBox = New TextBox()
        passwordBox.Width = 300
        passwordBox.BorderStyle = BorderStyle.None
        passwordBox.Font = New Font("Arial", 14, FontStyle.Regular)
        passwordBox.TextAlign = HorizontalAlignment.Center
        passwordBox.PasswordChar = "*"
        panelContainer.Controls.Add(passwordBox)

        ' STEP 5: Initialize underline for Username
        underlineUsername = New Label()
        underlineUsername.BackColor = Color.Firebrick
        underlineUsername.Height = 2
        underlineUsername.Width = userNameBox.Width
        panelContainer.Controls.Add(underlineUsername)

        ' STEP 6: Initialize underline for Password
        underlinePassword = New Label()
        underlinePassword.BackColor = Color.Firebrick
        underlinePassword.Height = 2
        underlinePassword.Width = passwordBox.Width
        panelContainer.Controls.Add(underlinePassword)

        ' STEP 7: Initialize Login Button
        logInButton = New Button()
        logInButton.Text = "Login"
        logInButton.BackColor = Color.Firebrick
        logInButton.ForeColor = Color.White
        logInButton.Font = New Font("Arial", 10, FontStyle.Regular)
        logInButton.Width = 120
        logInButton.Height = 40
        panelContainer.Controls.Add(logInButton)

        ' STEP 8: Initialize "Create Account" Label
        createAccountLabel = New Label()
        createAccountLabel.Text = "Create Account"
        createAccountLabel.Font = New Font("Arial", 10, FontStyle.Underline)
        createAccountLabel.ForeColor = Color.Black
        createAccountLabel.Cursor = Cursors.Hand
        createAccountLabel.AutoSize = True
        panelContainer.Controls.Add(createAccountLabel)

        ' STEP 9: Add click event for "Create Account"
        AddHandler createAccountLabel.Click, AddressOf CreateAccountLabel_Click

        ' DO NOT CALL UpdateControlsPosition() HERE!
        ' Call it in Form_Shown instead
    End Sub

    ' This event ensures all controls are loaded before adjusting positions
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        UpdateControlsPosition()
    End Sub

    ' Paint event for background panel (2-color effect)
    Private Sub BackgroundPanel_Paint(sender As Object, e As PaintEventArgs)
        If backgroundPanel Is Nothing Then Exit Sub ' Prevent crash

        Dim g As Graphics = e.Graphics
        Dim rectTop As New Rectangle(0, 0, backgroundPanel.Width, backgroundPanel.Height \ 2)
        Dim rectBottom As New Rectangle(0, backgroundPanel.Height \ 2, backgroundPanel.Width, backgroundPanel.Height \ 2)

        g.FillRectangle(New SolidBrush(Color.Firebrick), rectTop) ' White Top
        g.FillRectangle(New SolidBrush(Color.White), rectBottom) ' Red Bottom
    End Sub

    ' Event handler for resizing the form
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        UpdateControlsPosition()
        If backgroundPanel IsNot Nothing Then
            backgroundPanel.Invalidate() ' Redraw background panel on resize
        End If
    End Sub

    ' Method to center controls dynamically
    Private Sub UpdateControlsPosition()
        If backgroundPanel Is Nothing OrElse panelContainer Is Nothing Then Exit Sub ' Prevent crash

        ' Center backgroundPanel in the form
        backgroundPanel.Left = (Me.ClientSize.Width - backgroundPanel.Width) \ 2
        backgroundPanel.Top = (Me.ClientSize.Height - backgroundPanel.Height) \ 2

        ' Center panelContainer inside backgroundPanel
        panelContainer.Left = (backgroundPanel.Width - panelContainer.Width) \ 2
        panelContainer.Top = (backgroundPanel.Height - panelContainer.Height) \ 2

        ' Set padding inside the panel
        Dim padding As Integer = 20
        Dim panelWidth As Integer = panelContainer.ClientSize.Width

        ' Center Username TextBox
        userNameBox.Left = (panelWidth - userNameBox.Width) \ 2
        userNameBox.Top = padding

        ' Position underline for Username
        underlineUsername.Left = userNameBox.Left
        underlineUsername.Top = userNameBox.Bottom

        ' Center Password TextBox below Username
        passwordBox.Left = (panelWidth - passwordBox.Width) \ 2
        passwordBox.Top = underlineUsername.Bottom + 20

        ' Position underline for Password
        underlinePassword.Left = passwordBox.Left
        underlinePassword.Top = passwordBox.Bottom

        ' Center Login Button below Password
        logInButton.Left = (panelWidth - logInButton.Width) \ 2
        logInButton.Top = underlinePassword.Bottom + 30

        ' Center "Create Account" label below Login Button
        createAccountLabel.Left = (panelWidth - createAccountLabel.Width) \ 2
        createAccountLabel.Top = logInButton.Bottom + 15
    End Sub

    ' Event for when "Create Account" is clicked
    Private Sub CreateAccountLabel_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Create Account Clicked!")
    End Sub

End Class
