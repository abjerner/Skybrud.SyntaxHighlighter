using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.SyntaxHighlighter.Highlighters.Json;

namespace UnitTestProject1 {

    [TestClass]
    public class JsonTests {


        [TestMethod]
        public void EmptyObjectTokens() {

            string json = "{}";

            List<object> tokens = JsonTokenizer.GetTokens(json);

            Assert.AreEqual(3, tokens.Count);

            Assert.AreEqual(typeof(JsonToken), tokens[0].GetType());
            Assert.AreEqual(JsonTokenType.ObjectOpen, ((JsonToken)tokens[0]).Type);
            Assert.AreEqual("{", ((JsonToken)tokens[0]).Value);

            Assert.AreEqual(typeof(List<object>), tokens[1].GetType());
            Assert.AreEqual(0, ((List<object>)tokens[1]).Count);

            Assert.AreEqual(typeof(JsonToken), tokens[2].GetType());
            Assert.AreEqual(JsonTokenType.ObjectClose, ((JsonToken)tokens[2]).Type);
            Assert.AreEqual("}", ((JsonToken)tokens[2]).Value);

        }

        [TestMethod]
        public void EmptyArrayTokens() {

            string json = "[]";

            List<object> tokens = JsonTokenizer.GetTokens(json);

            Assert.AreEqual(3, tokens.Count);

            Assert.AreEqual(typeof(JsonToken), tokens[0].GetType());
            Assert.AreEqual(JsonTokenType.ArrayOpen, ((JsonToken)tokens[0]).Type);
            Assert.AreEqual("[", ((JsonToken)tokens[0]).Value);

            Assert.AreEqual(typeof(List<object>), tokens[1].GetType());
            Assert.AreEqual(0, ((List<object>)tokens[1]).Count);

            Assert.AreEqual(typeof(JsonToken), tokens[2].GetType());
            Assert.AreEqual(JsonTokenType.ArrayClose, ((JsonToken)tokens[2]).Type);
            Assert.AreEqual("]", ((JsonToken)tokens[2]).Value);

        }
        
        [TestMethod]
        public void NumberObjectTokens() {

            string json = "{\"number\":1234}";

            List<object> tokens = JsonTokenizer.GetTokens(json);

            Assert.AreEqual(3, tokens.Count);

            Assert.AreEqual(typeof(JsonToken), tokens[0].GetType());
            Assert.AreEqual(JsonTokenType.ObjectOpen, ((JsonToken)tokens[0]).Type);
            Assert.AreEqual("{", ((JsonToken)tokens[0]).Value);

            Assert.AreEqual(typeof(List<object>), tokens[1].GetType());
            Assert.AreEqual(3, ((List<object>)tokens[1]).Count);

            var list = (List<object>) tokens[1];

            Assert.AreEqual(typeof(JsonToken), list[0].GetType());
            Assert.AreEqual(JsonTokenType.String, ((JsonToken)list[0]).Type);
            Assert.AreEqual("\"number\"", ((JsonToken)list[0]).Value);

            Assert.AreEqual(typeof(JsonToken), list[1].GetType());
            Assert.AreEqual(JsonTokenType.Other, ((JsonToken)list[1]).Type);
            Assert.AreEqual(":", ((JsonToken)list[1]).Value);

            Assert.AreEqual(typeof(JsonToken), list[2].GetType());
            Assert.AreEqual(JsonTokenType.Number, ((JsonToken)list[2]).Type);
            Assert.AreEqual("1234", ((JsonToken)list[2]).Value);

            Assert.AreEqual(typeof(JsonToken), tokens[2].GetType());
            Assert.AreEqual(JsonTokenType.ObjectClose, ((JsonToken)tokens[2]).Type);
            Assert.AreEqual("}", ((JsonToken)tokens[2]).Value);

        }
        
        [TestMethod]
        public void NumberArrayTokens() {

            string json = "[1234]";

            List<object> tokens = JsonTokenizer.GetTokens(json);

            Assert.AreEqual(3, tokens.Count);

            Assert.AreEqual(typeof(JsonToken), tokens[0].GetType());
            Assert.AreEqual(JsonTokenType.ArrayOpen, ((JsonToken)tokens[0]).Type);
            Assert.AreEqual("[", ((JsonToken)tokens[0]).Value);

            Assert.AreEqual(typeof(List<object>), tokens[1].GetType());
            Assert.AreEqual(1, ((List<object>)tokens[1]).Count);

            var list = (List<object>) tokens[1];

            Assert.AreEqual(typeof(JsonToken), list[0].GetType());
            Assert.AreEqual(JsonTokenType.Number, ((JsonToken)list[0]).Type);
            Assert.AreEqual("1234", ((JsonToken)list[0]).Value);

            Assert.AreEqual(typeof(JsonToken), tokens[2].GetType());
            Assert.AreEqual(JsonTokenType.ArrayClose, ((JsonToken)tokens[2]).Type);
            Assert.AreEqual("]", ((JsonToken)tokens[2]).Value);

        }
        
        [TestMethod]
        public void NullObjectTokens() {

            string json = "{\"number\":null}";

            List<object> tokens = JsonTokenizer.GetTokens(json);

            Assert.AreEqual(3, tokens.Count);

            Assert.AreEqual(typeof(JsonToken), tokens[0].GetType());
            Assert.AreEqual(JsonTokenType.ObjectOpen, ((JsonToken)tokens[0]).Type);
            Assert.AreEqual("{", ((JsonToken)tokens[0]).Value);

            Assert.AreEqual(typeof(List<object>), tokens[1].GetType());
            Assert.AreEqual(3, ((List<object>)tokens[1]).Count);

            var list = (List<object>) tokens[1];

            Assert.AreEqual(typeof(JsonToken), list[0].GetType());
            Assert.AreEqual(JsonTokenType.String, ((JsonToken)list[0]).Type);
            Assert.AreEqual("\"number\"", ((JsonToken)list[0]).Value);

            Assert.AreEqual(typeof(JsonToken), list[1].GetType());
            Assert.AreEqual(JsonTokenType.Other, ((JsonToken)list[1]).Type);
            Assert.AreEqual(":", ((JsonToken)list[1]).Value);

            Assert.AreEqual(typeof(JsonToken), list[2].GetType());
            Assert.AreEqual(JsonTokenType.Constant, ((JsonToken)list[2]).Type);
            Assert.AreEqual("null", ((JsonToken)list[2]).Value);

            Assert.AreEqual(typeof(JsonToken), tokens[2].GetType());
            Assert.AreEqual(JsonTokenType.ObjectClose, ((JsonToken)tokens[2]).Type);
            Assert.AreEqual("}", ((JsonToken)tokens[2]).Value);

        }
        
        [TestMethod]
        public void NullArrayTokens() {

            string json = "[null]";

            List<object> tokens = JsonTokenizer.GetTokens(json);

            Assert.AreEqual(3, tokens.Count);

            Assert.AreEqual(typeof(JsonToken), tokens[0].GetType());
            Assert.AreEqual(JsonTokenType.ArrayOpen, ((JsonToken)tokens[0]).Type);
            Assert.AreEqual("[", ((JsonToken)tokens[0]).Value);

            Assert.AreEqual(typeof(List<object>), tokens[1].GetType());
            Assert.AreEqual(1, ((List<object>)tokens[1]).Count);

            var list = (List<object>) tokens[1];

            Assert.AreEqual(typeof(JsonToken), list[0].GetType());
            Assert.AreEqual(JsonTokenType.Constant, ((JsonToken)list[0]).Type);
            Assert.AreEqual("null", ((JsonToken)list[0]).Value);

            Assert.AreEqual(typeof(JsonToken), tokens[2].GetType());
            Assert.AreEqual(JsonTokenType.ArrayClose, ((JsonToken)tokens[2]).Type);
            Assert.AreEqual("]", ((JsonToken)tokens[2]).Value);

        }

    }

}