using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSV.Model;
using Xunit.Sdk;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFeedback()
        {
            Feedback feedback = new Feedback();

            feedback.Kom = false;
            feedback.Komentar = "Test";

            Assert.AreEqual(feedback.Kom, false);
            Assert.AreEqual(feedback.Komentar, "Test");
        }

        [TestMethod]
        public void TestUser()
        {
            User user = new User();

            user.Deleted = false;
            user.Email = "test@gmail.com";

            Assert.AreEqual(user.Deleted, false);
            Assert.AreEqual(user.Email, "test@gmail.com");
        }
    }
}
