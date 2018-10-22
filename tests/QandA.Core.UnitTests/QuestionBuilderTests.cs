using Microsoft.VisualStudio.TestTools.UnitTesting;
using QandA.Core.Answers;
using QandA.Core.Builders;
using QandA.Core.Questions;
using System;
using System.Linq;

namespace QandA.Core.UnitTests
{
    [TestClass]
    public class QuestionBuilderTests
    {
        private IQuestionBuilder _builder;
        private IQuestion _question;

        [TestInitialize]
        public void TestInit()
        {
            _builder = new QuestionBuilder();
            _question = new Question();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            _builder = null;
        }

        [TestMethod]
        public void Default_Constructor_Returns_Valid_Class()
        {
            Assert.IsNotNull(_builder);
        }

        [TestMethod]
        public void Add_Question_Changes_Item_Count()
        {
            _builder.AddQuestion(_question);

            Assert.IsTrue(_builder.Items.Any());
        }

        [TestMethod]
        public void Add_Question_Null_Argument_Throws_Exception()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _builder.AddQuestion(null));
        }

        [TestMethod]
        public void Add_Answer_Null_Argument_Throws_Exception()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _builder.AddAnswer(_question, null));
        }

        [TestMethod]
        public void Add_Answer_Invalid_Question_Throws_Exception()
        {
            Assert.ThrowsException<ArgumentException>(() => _builder.AddAnswer(_question, new Answer()));
        }
    }
}