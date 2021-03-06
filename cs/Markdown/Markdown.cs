﻿namespace Markdown
{
    public class Markdown
    {
        public string Render(string mdText)
        {
            var tokens = new TokenFinder().FindTokens(mdText);

            var validHtmlTags = new TokenValidator().GetParagraphsWithValidTokens(tokens, mdText);

            return new Md2HtmlTranslator().TranslateMdToHtml(mdText, validHtmlTags);
        }
    }
}
