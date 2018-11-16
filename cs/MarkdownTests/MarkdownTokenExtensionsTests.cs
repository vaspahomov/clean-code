﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markdown;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace MarkdownTests
{
    [TestFixture]
    class MarkdownTokenExtensionsTests
    {
        [TestCase("f _d", 2, ExpectedResult = true, TestName = "After whitespace")]
        [TestCase("_d", 0, ExpectedResult = true, TestName = "In paragraph beginning")]
        [TestCase("f_d", 1, ExpectedResult = true, TestName = "Without whitespace before")]
        public bool ValidOpeningPositionTest(string text, int openingPosition)
        {
            var token = new MarkdownToken("singleUnderscore", "_", "em");

            return token.ValidOpeningPosition(text, openingPosition);
        }

        [TestCase("d_ d", 1, ExpectedResult = true, TestName = "Before whitespace")]
        [TestCase("d_", 1, ExpectedResult = true, TestName = "In paragraph ending")]
        [TestCase("d_f", 1, ExpectedResult = true, TestName = "Without whitespace after")]
        public bool ValidClosingPositionTest(string text, int closingPosition)
        {
            var token = new MarkdownToken("singleUnderscore", "_", "em");

            return token.ValidClosingPosition(text, closingPosition);
        }

        [TestCase("__f",0, ExpectedResult = "doubleUnderscore", TestName = "Find double underscore")]
        [TestCase("_f", 0, ExpectedResult = "simpleUnderscore", TestName = "Find simple underscore")]
        public string GetOpeningTokenTest(string text, int startIndex)
        {
            var tokens = new List<MarkdownToken>
            {
                new MarkdownToken("doubleUnderscore", "__", "strong"),
                new MarkdownToken("simpleUnderscore", "_", "em")
            };

            return tokens.GetOpeningToken(text, startIndex).Name;
        }

        [TestCase("f__", 1, ExpectedResult = "doubleUnderscore", TestName = "Find double underscore")]
        [TestCase("f_", 1, ExpectedResult = "simpleUnderscore", TestName = "Find simple underscore")]
        public string GetClosingTokenTest(string text, int startIndex)
        {
            var tokens = new List<MarkdownToken>
            {
                new MarkdownToken("doubleUnderscore", "__", "strong"),
                new MarkdownToken("simpleUnderscore", "_", "em")
            };

            return tokens.GetClosingToken(text, startIndex).Name;
        }
    }
}