using System;
using System.Collections.Generic;
using System.Drawing;
/*
 * Copyright (c) 2014 Spellscape Ltd
 * http://www.spellscape.co.uk
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

using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSLogView
{
    public class clsFileReader
    {
        private static readonly ConsoleColor[] Colors = {
            ConsoleColor.Gray,
            ConsoleColor.Blue,
            ConsoleColor.Green,
            ConsoleColor.Cyan,
            ConsoleColor.Magenta,
            ConsoleColor.Yellow
        };

        // Vars
        string file_path;
        clsLog_File file_data;

        int line_count = 0;

        clsLog_ModuleList module_list;

        // Remember Current And Last Lines
        clsLog_Line line_current;
        clsLog_Line line_last;

        // Constructor
        public clsFileReader(string strPath, clsLog_File obLogFile)
        {
            file_path = strPath;
            file_data = obLogFile;
            module_list = new clsLog_ModuleList();
        }

        // Read The Contents
        public bool File_Read()
        {
            string line = null;
            
            try
            {
                // Read the file and display it line by line.
                StreamReader file = new StreamReader(file_path);

                // Time Between Log Entries
                TimeSpan duration = new TimeSpan(0, 0, 0);

                while ((line = file.ReadLine()) != null)
                {
                    // Create New Line Object
                    line_current = new clsLog_Line(line_count, line);

                    // Process RAW Line Data
                    if (!Line_Process())
                    {
                        // No TimeStamp, Assume Last

                        // Probably Exception, Double Check It Was Logged As Error Not Warning
                        if (line.Trim().StartsWith("at "))
                        {
                            line_last.line_type = Enum_LogLine.type_error;
                        }

                        // Copy Details Of Last Line
                        line_current.line_module_color  = line_last.line_module_color;
                        line_current.line_module_name   = line_last.line_module_name;
                        line_current.line_module_enum   = line_last.line_module_enum;
                        line_current.line_time          = line_last.line_time;
                        line_current.line_type          = line_last.line_type;

                        line_current.line_continued = true;
                    }
                    else
                    {
                        // How Long Between?
                        if (line_last != null)
                            duration = line_current.line_time - line_last.line_time;

                        // If This Line Is Later Than X Minutes, Add Extra Notification
                        if (duration.TotalMinutes > 30)
                        {
                            clsLog_Line obTimeLine = new clsLog_Line(line_count + 1, "----------------------------- Time Gap " + duration.TotalMinutes.ToString("#") + " Mins -----------------------------");

                            obTimeLine.line_time = line_last.line_time;
                            obTimeLine.line_type = Enum_LogLine.type_notation;
                            obTimeLine.line_module_name = "Time Gap";
                            obTimeLine.line_module_enum = Enum_ModuleCategory.mod_main;
                            obTimeLine.line_module_color = Color.LimeGreen;

                            file_data.log_lines.Add(obTimeLine);

                            line_count++;
                        }
                    }

                    // Add Line To Array
                    file_data.log_lines.Add(line_current);

                    // Set Last Line Reference
                    line_last = line_current;
                }

                file.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
                return false;
            }

            return true;
        }

        private bool Line_Process()
        {
            // Test DateStamp
            if (Test_StartDateStamp())
            {
                // Test Debug Level
                Test_LogLevel();

                // Test Module Name
                Test_Module();

                // Line Valid
                return true;
            }
            else
            {
                // No TimeStamp, Assume Continuation Of Last Line
                return false;
            }
        }

        // Test Start For DateStamp
        private bool Test_StartDateStamp()
        {
            string re1 = "((?:2|1)\\d{3}(?:-|\\/)(?:(?:0[1-9])|(?:1[0-2]))(?:-|\\/)(?:(?:0[1-9])|(?:[1-2][0-9])|(?:3[0-1]))(?:T|\\s)(?:(?:[0-1][0-9])|(?:2[0-3])):(?:[0-5][0-9]):(?:[0-5][0-9]))";	// Time Stamp 1
            string re2 = "(,)";	// Any Single Character 1
            string re3 = "(\\d{3})";	// Any Single Digit 1

            Regex r = new Regex(re1 + re2 + re3, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(line_current.line_formated.Substring(0, 23));
            if (m.Success)
            {
                // Set Date
                line_current.line_time = DateTime.Parse(m.Groups[1].ToString());// TimeStamp

                // Add Milliseconds For Less Chance Of Duplicate TimeStamps
                line_current.line_time = line_current.line_time.AddMilliseconds(Convert.ToDouble(m.Groups[3].ToString()));

                // Remove From Formatted String
                line_current.line_formated = line_current.line_formated.Substring(24, line_current.line_formated.Length - 24);
            }
            else
            {
                line_current.line_time = DateTime.MinValue;
            }

            return m.Success;
        }

        // Test Log Level
        private void Test_LogLevel()
        {
            // Test Log Level (Now At Start Of Formatted String)
            switch (line_current.line_formated.Substring(0, 8))
            {
                case "DEBUG - ":
                    line_current.line_type = Enum_LogLine.type_debug;
                    break;
                case "INFO  - ":
                    line_current.line_type = Enum_LogLine.type_info;
                    break;
                case "WARN  - ":
                    line_current.line_type = Enum_LogLine.type_warn;
                    break;
                case "ERROR - ":
                    line_current.line_type = Enum_LogLine.type_error;
                    break;
                default:
                    line_current.line_type = Enum_LogLine.type_unknown;
                    return;
            }

            // If We Havnt Returned By Now, OK TO Trim LogLevel Off
            line_current.line_formated = line_current.line_formated.Substring(8, line_current.line_formated.Length - 8).Trim();
        }

        // Test Module Name Between []
        private void Test_Module()
        {
            int bracket_index_start     = line_current.line_formated.IndexOf('[');
            int bracket_index_end       = line_current.line_formated.IndexOf(']');

            string module_name          = "Unknown";

            if (bracket_index_start > 0 && bracket_index_end > bracket_index_start)
            {
                // Brackets Found
                module_name = line_current.line_formated.Substring(bracket_index_start + 1, bracket_index_end - bracket_index_start - 1);

                // Trim Module Portion
                line_current.line_formated = line_current.line_formated.Substring(bracket_index_end + 2, line_current.line_formated.Length - bracket_index_end - 2).Trim();

                // Get Module Enum
                line_current.line_module_enum = module_list.GetModuleEnum(module_name);
                line_current.line_module_color = GetModuleColor(module_name);
            }
            else
            {
                // Unknown Module
                line_current.line_module_enum = Enum_ModuleCategory.mod_unknown;

                line_current.line_module_color = Color.Goldenrod;
            }

            line_current.line_module_name = module_name;
        }

        // Gets Color To Show Module Name With
        private Color GetModuleColor(string strModule)
        {
            return Color.FromName(Enum.GetName(typeof(ConsoleColor), Colors[(Math.Abs(strModule.ToUpper().GetHashCode()) % Colors.Length)]));
        }

    }
}
