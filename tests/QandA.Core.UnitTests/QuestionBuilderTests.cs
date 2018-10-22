using Microsoft.VisualStudio.TestTools.UnitTesting;
using QandA.Core.Builders;
using QandA.Core.Questions;
using System.Linq;

namespace QandA.Core.UnitTests
{
    [TestClass]
    public class QuestionBuilderTests
    {
        [TestMethod]
        public void Default_Constructor_Returns_Valid_Class()
        {
            var builder = new QuestionBuilder();
            Assert.IsNotNull(builder);
        }

        [TestMethod]
        public void Add_Question_Changes_Item_Count()
        {
            var builder = new QuestionBuilder();
            builder.AddQuestion(new Question());

            Assert.IsTrue(builder.Items.Any());
        }
    }
}
