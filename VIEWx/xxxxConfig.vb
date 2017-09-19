Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Soap

Module xxxxConfig
    '// �ݒ�t�@�C���ǂݍ���
    Public Sub loadConfig()
        Dim formatter As SoapFormatter = New SoapFormatter

        Try
            Using fs As FileStream = New FileStream(Application.StartupPath & "\\viewx.xml", FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                Dim cls As clsConfig = CType(formatter.Deserialize(fs), clsConfig)

                FormMain.Top = cls.Top
                FormMain.Left = cls.Left
                FormMain.Width = cls.Width
                FormMain.Height = cls.Height

                Select Case cls.SizeMode
                    Case PictureBoxSizeMode.Zoom '// �E�B���h�E�ɍ��킹��
                        FormMain.mnuViewBestfit_Click("", Nothing)
                    Case PictureBoxSizeMode.AutoSize '// �E�B���h�E�Ɏ��߂�
                        FormMain.mnuViewInWindow_Click("", Nothing)
                    Case PictureBoxSizeMode.CenterImage '// ������
                        FormMain.mnuViewActual_Click("", Nothing)
                End Select

                FormMain.mnuViewHScrollBar.Checked = cls.mnuViewHScrollBar
                FormMain.mnuViewToolBar.Checked = cls.mnuViewToolBar
                FormMain.mnuViewStatusBar.Checked = cls.mnuViewStatusBar

                FormMain.mnuViewSpread.Checked = cls.mnuViewSpread
                FormMain.mnuViewSpreadRight.Checked = cls.mnuViewSpreadRight
                FormMain.mnuViewSpreadLeft.Checked = cls.mnuViewSpreadLeft

                '              If FormMain.mnuViewHScrollBar.Checked Then FormMain.Panel1.Show() Else FormMain.Panel1.Hide()
                If FormMain.mnuViewToolBar.Checked Then FormMain.ToolStripContainer1.Show() Else FormMain.ToolStripContainer1.BottomToolStripPanel.Hide()
                If FormMain.mnuViewStatusBar.Checked Then FormMain.tsStatusBar.Show() Else FormMain.tsStatusBar.Hide()

                '// ���בւ�
                FormMain.mnuViewOrderName.Checked = cls.mnuViewOrderName
                FormMain.mnuViewOrderNameNum.Checked = cls.mnuViewOrderNameNum
                FormMain.mnuViewOrderType.Checked = cls.mnuViewOrderType

                FormMain.mnuViewOrderAsc.Checked = cls.mnuViewOrderAsc
                FormMain.mnuViewOrderDesc.Checked = cls.mnuViewOrderDesc

                '// �L�[�ݒ�
                keyConfig = cls.KeyConfig

                '// �ŏI�N������
                lastUpdateCheckDateTime = cls.lastUpdateCheckDateTime

                '// �����A�b�v�f�[�g�`�F�b�N�����邩�ǂ���
                doUpdateCheck = cls.doUpdateCheck

                '// �X���C�h �V���[�̊Ԋu�i�~���b�j
                slideShowInterval = cls.slideShowInterval
            End Using
        Catch ex As Exception
            '�ݒ�t�B�����ǂݍ��߂Ȃ���΃f�t�H���g�̐ݒ�
            'MsgBox("�ݒ�t�@�C����ǂݍ��߂܂���ł����B�f�t�H���g�̒l���g�p���܂��B")

            FormMain.Top = (SystemInformation.WorkingArea.Height - FormMain.Height) / 2
            FormMain.Left = (SystemInformation.WorkingArea.Width - FormMain.Width) / 2

            '// �X�N���[���o�[��\��
            'FormMain.Panel1.Hide()
            FormMain.mnuViewHScrollBar.Checked = False

            '// �c�[���o�[��\��
            FormMain.ToolStripContainer1.BottomToolStripPanel.Hide()
            FormMain.mnuViewToolBar.Checked = False

            '// �X�e�[�^�X�o�[��\��
            FormMain.tsStatusBar.Hide()
            FormMain.mnuViewStatusBar.Checked = False

            '// �E�B���h�E�ɍ��킹��
            FormMain.mnuViewBestfit_Click("", Nothing)

            '// ���J���\������Ȃ�
            'FormMain.SplitContainer1.Panel2Collapsed = True
            FormMain.mnuViewSpread.Checked = False

            '// �E�J��
            FormMain.mnuViewSpreadRight.Checked = True
            FormMain.mnuViewSpreadLeft.Checked = False

            '// ���בւ�
            FormMain.mnuViewOrderName.Checked = True
            FormMain.mnuViewOrderType.Checked = False

            FormMain.mnuViewOrderAsc.Checked = True
            FormMain.mnuViewOrderDesc.Checked = False

            '// �Œ���̃L�[�ݒ�
            keyConfig.Add(8, 1)
            keyConfig.Add(13, 2)
            keyConfig.Add(32, 2)

            '// �����A�b�v�f�[�g�`�F�b�N
            doUpdateCheck = True

            '// �X���C�h �V���[�̊Ԋu�i�~���b�j
            slideShowInterval = 3000
        End Try
    End Sub

    '// �ݒ�t�@�C���ۑ�
    Public Sub saveConfig()
        Dim cls As New clsConfig
        Dim formatter As SoapFormatter = New SoapFormatter

        If FormMain.WindowState = FormWindowState.Maximized Then
            cls.Top = FormMain.Top + 4
            cls.Left = FormMain.Left + 4
            cls.Width = FormMain.Width - 8
            cls.Height = FormMain.Height - 8
        Else
            cls.Top = FormMain.Top
            cls.Left = FormMain.Left
            cls.Width = FormMain.Width
            cls.Height = FormMain.Height
        End If

        cls.mnuViewHScrollBar = FormMain.mnuViewHScrollBar.Checked
        cls.mnuViewToolBar = FormMain.mnuViewToolBar.Checked
        cls.mnuViewStatusBar = FormMain.mnuViewStatusBar.Checked

        If FormMain.mnuViewBestfit.Checked Then cls.SizeMode = PictureBoxSizeMode.Zoom
        If FormMain.mnuViewInWindow.Checked Then cls.SizeMode = PictureBoxSizeMode.AutoSize
        If FormMain.mnuViewActual.Checked Then cls.SizeMode = PictureBoxSizeMode.CenterImage

        cls.mnuViewSpread = FormMain.mnuViewSpread.Checked

        cls.mnuViewSpreadRight = FormMain.mnuViewSpreadRight.Checked
        cls.mnuViewSpreadLeft = FormMain.mnuViewSpreadLeft.Checked

        cls.mnuViewOrderName = FormMain.mnuViewOrderName.Checked
        cls.mnuViewOrderNameNum = FormMain.mnuViewOrderNameNum.Checked
        cls.mnuViewOrderType = FormMain.mnuViewOrderType.Checked

        cls.mnuViewOrderAsc = FormMain.mnuViewOrderAsc.Checked
        cls.mnuViewOrderDesc = FormMain.mnuViewOrderDesc.Checked

        cls.keyConfig = keyConfig

        cls.lastUpdateCheckDateTime = lastUpdateCheckDateTime
        cls.doUpdateCheck = doUpdateCheck

        cls.slideShowInterval = slideShowInterval

        Try
            Using fs As New FileStream(Application.StartupPath & "\\viewx.xml", FileMode.Create, FileAccess.Write, FileShare.ReadWrite)
                formatter.Serialize(fs, cls)
            End Using
        Catch ex As Exception
            MsgBox("�ݒ�t�@�C�����������߂܂���ł���")
        End Try

    End Sub
End Module
