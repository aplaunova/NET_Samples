using System;
using WebShop.Logic;
using Xunit;

namespace WebShop.Tests
{
    public class UserTests
    {
        [Fact]
        //vai korekti tika izveidoti lietotaji
        public void TestCreateUser()
        {
            string mail = GetRandomText();

            UserManager.Create(mail, "testname", "testpass");

                var user = UserManager.GetByEmail(mail);

            //ja asertacija ir pareiza->teksts ir veiksmigs
            Assert.NotNull(user);

            Assert.Equal(user.Email, mail);
        }


        [Fact]
        //vai korekti tika izveidoti lietotaji
        public void TestGetUser()
        {
            string mail = GetRandomText();
            string password = "testpass";
            UserManager.Create(mail, "testname", password);

            var user = UserManager.GetByEmailAndPassword(mail, password);

            Assert.NotNull(user);
            Assert.Equal(user.Email, mail);
            Assert.Equal(user.Password, password);

        }

            //metode nodrosina teksta generesanu
            public static string GetRandomText()
        {
            //Guid glaba ciparus, burtus, svitrinas
            //atgriez virkni no 8 simboliem
            return Guid.NewGuid().ToString("N").Substring(0, 8);
        }
    }
}
