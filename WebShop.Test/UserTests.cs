using System;
using WebShop.Logic;
using Xunit;

namespace WebShop.Test
{
    public class UserTests
    {
        [Fact]

        public void TestCreateUser()
        {
            string mail = GetRandomText();

            UserManager.Create(mail, "testname", "testpass");

            var user = UserManager.GetByEmail(mail);

            //ja asertacija ir pareiza->tests veiksmigs
            Assert.NotNull(user);
            Assert.Equal(user.Email, mail);
        }

        [Fact]

        //vai lietotaja pec paroles testa tiek veiksmigi atrasts
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


        //nodrosina teksta generesanu
        public static string GetRandomText()
        {
            //atgriez 8 simbolus no jaunas generetas virknes
            return Guid.NewGuid().ToString("N").Substring(0, 8);

        }
    }
}
