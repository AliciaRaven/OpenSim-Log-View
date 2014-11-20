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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLogView
{
    public enum Enum_LogLine
    {
        type_unknown = 0,
        type_debug = 1,
        type_info = 2,
        type_warn = 3,
        type_error = 4,
        type_notation = 5 // Used For Time Gaps
    }

    public class clsLog_Line
    {
        // ID
        public int              line_number;
        public Enum_LogLine     line_type;

        // String Data
        public string           line_raw;
        public string           line_formated;

        // Time
        public DateTime         line_time;

        // Module
        public Enum_ModuleCategory line_module_enum;
        public string line_module_name;
        public Color line_module_color;

        public bool line_continued = false;

        public clsLog_Line(int intLineNo, string strRawLine)
        {
            line_number = intLineNo;
            line_raw = strRawLine;
            line_formated = strRawLine;
        }
    }
}
