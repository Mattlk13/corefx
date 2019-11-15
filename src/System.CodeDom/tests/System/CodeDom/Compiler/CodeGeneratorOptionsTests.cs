// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Xunit;

namespace System.CodeDom.Compiler.Tests
{
    public class CodeGeneratorOptionsTests
    {
        [Fact]
        public void Ctor_Default()
        {
            var options = new CodeGeneratorOptions();
            Assert.True(options.BlankLinesBetweenMembers);
            Assert.Equal("Block", options.BracingStyle);
            Assert.False(options.ElseOnClosing);
            Assert.Equal("    ", options.IndentString);
            Assert.False(options.VerbatimOrder);
        }

        [Fact]
        public void Item_Set_GetReturnsExpected()
        {
            var options = new CodeGeneratorOptions();
            options["name"] = "value";
            Assert.Equal("value", options["name"]);
        }

        [Fact]
        public void Item_GetNull_ThrowsArgumentNullException()
        {
            var options = new CodeGeneratorOptions();
            Assert.Throws<ArgumentNullException>("key", () => options[null]);
        }

        [Fact]
        public void Item_SetNull_ThrowsArgumentNullException()
        {
            var options = new CodeGeneratorOptions();
            Assert.Throws<ArgumentNullException>("key", () => options[null] = new object());
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void BlankLinesBetweenMembers_Set_GetReturnsExpected(bool value)
        {
            var options = new CodeGeneratorOptions { BlankLinesBetweenMembers = value };
            Assert.Equal(value, options.BlankLinesBetweenMembers);
        }

        [Fact]
        public void BlankLinesBetweenMembers_GetWhenNotBool_ThrowsInvalidCastException()
        {
            var options = new CodeGeneratorOptions();
            options[nameof(CodeGeneratorOptions.BlankLinesBetweenMembers)] = new object();
            Assert.Throws<InvalidCastException>(() => options.BlankLinesBetweenMembers);
        }

        [Fact]
        public void BlankLinesBetweenMembers_GetWhenNull_ReturnsTrue()
        {
            var options = new CodeGeneratorOptions();
            options[nameof(CodeGeneratorOptions.BlankLinesBetweenMembers)] = null;
            Assert.True(options.BlankLinesBetweenMembers);
        }

        [Theory]
        [InlineData(null, "Block")]
        [InlineData("", "")]
        [InlineData("value", "value")]
        public void BracingStyle_Set_GetReturnsExpected(string value, string expected)
        {
            var options = new CodeGeneratorOptions { BracingStyle = value };
            Assert.Equal(expected, options.BracingStyle);
        }

        [Fact]
        public void BracingStyle_GetWhenNotString_ThrowsInvalidCastException()
        {
            var options = new CodeGeneratorOptions();
            options[nameof(CodeGeneratorOptions.BracingStyle)] = new object();
            Assert.Throws<InvalidCastException>(() => options.BracingStyle);
        }

        [Fact]
        public void BracingStyle_GetWhenNull_ReturnsExpected()
        {
            var options = new CodeGeneratorOptions();
            options[nameof(CodeGeneratorOptions.BracingStyle)] = null;
            Assert.Equal("Block", options.BracingStyle);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ElseOnClosing_Set_GetReturnsExpected(bool value)
        {
            var options = new CodeGeneratorOptions { ElseOnClosing = value };
            Assert.Equal(value, options.ElseOnClosing);
        }

        [Fact]
        public void ElseOnClosing_GetWhenNotBool_ThrowsInvalidCastException()
        {
            var options = new CodeGeneratorOptions();
            options[nameof(CodeGeneratorOptions.ElseOnClosing)] = new object();
            Assert.Throws<InvalidCastException>(() => options.ElseOnClosing);
        }

        [Fact]
        public void ElseOnClosing_GetWhenNull_Return()
        {
            var options = new CodeGeneratorOptions();
            options[nameof(CodeGeneratorOptions.ElseOnClosing)] = null;
            Assert.False(options.ElseOnClosing);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("value")]
        public void IndentString__Set_GetReturnsExpected(string value)
        {
            var options = new CodeGeneratorOptions { IndentString = value };
            Assert.Equal(value ?? "    ", options.IndentString);
        }

        [Fact]
        public void IndentString_GetWhenNotString_ThrowsInvalidCastException()
        {
            var options = new CodeGeneratorOptions();
            options[nameof(CodeGeneratorOptions.IndentString)] = new object();
            Assert.Throws<InvalidCastException>(() => options.IndentString);
        }

        [Fact]
        public void IndentString_GetWhenNull_ReturnsExpected()
        {
            var options = new CodeGeneratorOptions();
            options[nameof(CodeGeneratorOptions.IndentString)] = null;
            Assert.Equal("    ", options.IndentString);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void VerbatimOrder_Set_GetReturnsExpected(bool value)
        {
            var options = new CodeGeneratorOptions { VerbatimOrder = value };
            Assert.Equal(value, options.VerbatimOrder);
        }

        [Fact]
        public void VerbatimOrder_GetWhenNotBool_ThrowsInvalidCastException()
        {
            var options = new CodeGeneratorOptions();
            options[nameof(CodeGeneratorOptions.VerbatimOrder)] = new object();
            Assert.Throws<InvalidCastException>(() => options.VerbatimOrder);
        }

        [Fact]
        public void VerbatimOrder_GetWhenNotBoolNull_ReturnsFalse()
        {
            var options = new CodeGeneratorOptions();
            options[nameof(CodeGeneratorOptions.VerbatimOrder)] = null;
            Assert.False(options.VerbatimOrder);
        }
    }
}
