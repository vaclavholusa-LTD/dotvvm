﻿using DotVVM.Framework.Compilation.Javascript.Ast;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotVVM.Framework.Tests.Common.Runtime.JavascriptCompilation
{
    [TestClass]
    public class JsFormatterTests
    {
        [TestMethod]
        public void JsFormatter_BinaryOperator()
        {
            Assert.AreEqual("a+5", new JsBinaryExpression(new JsIdentifierExpression("a"), BinaryOperatorType.Plus, new JsLiteral(5)).FormatScript());
        }

        [TestMethod]
        public void JsFormatter_StringLiteral()
        {
            Assert.AreEqual("\"\\\"\"", new JsLiteral("\"").FormatScript());
        }

        [TestMethod]
        public void JsFormatter_MemberAccess()
        {
            Assert.AreEqual("a.b.c", new JsIdentifierExpression("a").Member("b").Member("c").FormatScript());
        }

        [TestMethod]
        public void JsFormatter_Invocation()
        {
            Assert.AreEqual("a.b(4,5)", new JsIdentifierExpression("a").Member("b").Invoke(new JsLiteral(4), new JsLiteral(5)).FormatScript());
        }

        [TestMethod]
        public void JsFormatter_Indexer()
        {
            Assert.AreEqual("a[b]", new JsIdentifierExpression("a").Indexer(new JsIdentifierExpression("b")).FormatScript());
        }
    }
}
