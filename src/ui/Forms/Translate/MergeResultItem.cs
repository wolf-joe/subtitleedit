﻿namespace Nikse.SubtitleEdit.Forms.Translate
{
    public static partial class MergeAndSplitHelper
    {
        public class MergeResultItem
        {
            public string Text { get; set; }
            public int StartIndex { get; set; }
            public int EndIndex { get; set; }
            public bool AllItalic { get; set; }
            public bool AllBold { get; set; }
            public bool Continious { get; set; }
            public char EndChar { get; set; }
            public int EndCharOccurences { get; set; }
            public bool IsEmpty { get; set; }
            public bool HasError { get; set; }
            public int TextIndexStart { get; set; }
            public int TextIndexEnd { get; set; }
        }
    }
}
