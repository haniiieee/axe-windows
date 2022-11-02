﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using Axe.Windows.Core.Attributes;
using Axe.Windows.Core.Bases;
using Axe.Windows.Core.Types;
using System;
using UIAutomationClient;

namespace Axe.Windows.Desktop.UIAutomation.Patterns
{
    /// <summary>
    /// Control pattern wrapper for Text Control Pattern
    /// </summary>
    public class TextPattern2 : A11yPattern
    {
        IUIAutomationTextPattern2 Pattern;

        public TextPattern2(A11yElement e, IUIAutomationTextPattern2 p) : base(e, PatternType.UIA_TextPattern2Id)
        {
            Pattern = p;
        }

        [PatternMethod]
        public TextRange GetCaretRange(out int isActive)
        {
            return new TextRange(Pattern.GetCaretRange(out isActive), null);
        }

        [PatternMethod]
        public TextRange RangeFromAnnotation(A11yElement e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));

            return new TextRange(Pattern.RangeFromAnnotation(e.PlatformObject), null);
        }

        protected override void Dispose(bool disposing)
        {
            if (Pattern != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Pattern);
                Pattern = null;
            }

            base.Dispose(disposing);
        }
    }
}
