﻿using System.Collections.Generic;
using System.Linq;

namespace Markdown
{
    public static class MarkupExtensions
    {
        public static bool ValidOpeningPosition(this Markup markup, string text, int startIndex)
        {
            if (startIndex < 0 || startIndex + markup.Template.Length >= text.Length)
                return false;
            if (startIndex != 0 && text[startIndex - 1] != ' ')
                return false;

            return markup.Template.Equals(text.Substring(startIndex, markup.Template.Length));
        }

        public static bool ValidClosingPosition(this Markup markup, string text, int startIndex)
        {
            if (startIndex <= 0 || startIndex + markup.Template.Length > text.Length)
                return false;
            if (startIndex + markup.Template.Length != text.Length
                && text[startIndex + markup.Template.Length] != ' ')
                return false;

            return markup.Template.Equals(text.Substring(startIndex, markup.Template.Length));
        }

        public static Markup GetClosingMarkup(this List<Markup> markups, string text, int startIndex)
        {
            return markups.FirstOrDefault(markup => ValidClosingPosition((Markup) markup, text, startIndex));
        }

        public static Markup GetOpeningMarkup(this List<Markup> markups, string text, int startIndex)
        {
            return markups.FirstOrDefault(markup => markup.ValidOpeningPosition(text, startIndex));
        } 
    }
}