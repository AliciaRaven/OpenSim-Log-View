/*
 * Copyright (c) 2014 Spellscape Ltd
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *     * Redistributions of source code must retain the above copyright
 *       notice, this list of conditions and the following disclaimer.
 *     * Redistributions in binary form must reproduce the above copyright
 *       notice, this list of conditions and the following disclaimer in the
 *       documentation and/or other materials provided with the distribution.
 *
 * THIS SOFTWARE IS PROVIDED BY THE DEVELOPERS ``AS IS'' AND ANY
 * EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE CONTRIBUTORS BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSLogView
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void mnuFile_Open_Click(object sender, EventArgs e)
        {
            // Get File To Load
            DialogResult obResult = openFileDialog1.ShowDialog();

            if (obResult == DialogResult.OK)
            {
                // Get File Info (To Get File Name Only)
                FileInfo obFile = new FileInfo(openFileDialog1.FileName);

                // Load The Log File
                File_Load(obFile.Name, obFile.FullName);
            }
        }

        private void File_Load(string strFileName, string strFilePath)
        {
            // Create Log File Object
            clsLog_File obLogFile = new clsLog_File();

            // Read Data To It
            clsFileReader obReader = new clsFileReader(strFilePath, obLogFile);

            // Read Data
            obReader.File_Read();

            // Display File
            File_Display(obLogFile);
        }

        private void File_Display(clsLog_File obLogFile)
        {
            this.Cursor = Cursors.WaitCursor;
            Color colText;
            // Reset
            txtRaw.SuspendLayout();
            txtRaw.Clear();

            foreach (clsLog_Line obLine in obLogFile.log_lines)
            {
                colText = Color.White;

                // Extra Line Break For Time Gaps
                if (obLine.line_type == Enum_LogLine.type_notation)
                    txtRaw.AppendText(Environment.NewLine);

                // Date
                PrintColorText(obLine.line_time.ToShortDateString() + " - " + obLine.line_time.ToShortTimeString(), Color.White);

                switch (obLine.line_type)
                {
                    case Enum_LogLine.type_error:
                        colText = Color.Red;
                        break;
                    case Enum_LogLine.type_warn:
                        colText = Color.Yellow;
                        break;
                    case Enum_LogLine.type_debug:
                        colText = Color.DimGray;
                        break;
                    case Enum_LogLine.type_info:
                        colText = Color.Silver;
                        break;
                    case Enum_LogLine.type_notation:
                        colText = Color.ForestGreen;
                        break;
                    default:
                        colText = Color.White;
                        break;
                }

                // Print Module Name
                PrintColorText(" [", Color.White);

                if (obLine.line_module_enum != Enum_ModuleCategory.mod_unknown)
                {
                    PrintColorText(obLine.line_module_name, obLine.line_module_color);
                }
                else
                {
                    PrintColorText("?" + obLine.line_module_name + "?", Color.Orange);
                }

                PrintColorText("]: ", Color.White);

                // Print Color
                PrintColorText(obLine.line_formated, colText);

                // New Line
                txtRaw.AppendText(Environment.NewLine);

                // Extra Line Break For Time Gaps
                if (obLine.line_type == Enum_LogLine.type_notation)
                    txtRaw.AppendText(Environment.NewLine);
            }

            // Post Processing Color Highlights
            PostProcess_UUIDs();

            // Enable Draw
            txtRaw.ResumeLayout();
            this.Cursor = Cursors.Default;
        }

        // Display Helpers
        private void PrintColorText(string strText, Color colValue)
        {
            txtRaw.SelectionStart = txtRaw.TextLength;
            txtRaw.SelectionLength = 0;

            // Set Color Of Word Depending On Type
            txtRaw.SelectionColor = colValue;

            // Append Word
            txtRaw.AppendText(strText);

            txtRaw.SelectionColor = txtRaw.ForeColor;
        }

        // Post Proccessing RegEx Matches
        private void PostProcess_UUIDs()
        {
            string re1 = "([A-Z0-9]{8}-[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{12})";	// SQL GUID 1

            Regex regex = new Regex(re1, RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(txtRaw.Text);

            if (matches.Count > 0)
            {
                foreach (Match m in matches)
                {
                    txtRaw.Select(m.Index, m.Length);
                    txtRaw.SelectionColor = Color.DarkSeaGreen;
                }
            }
        }

        private void mnuAbout_Info_Click(object sender, EventArgs e)
        {
            frmAbout obFrmAbout = new frmAbout();

            obFrmAbout.ShowDialog();
        }
    }
}
