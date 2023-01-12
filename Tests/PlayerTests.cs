using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using code.Models;
namespace code.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void Player_WithInvalidInput_ThrowsAnException()
        {
            var player = new Players
            {
                Nickname = "John",
                Password = "123",
                Email = "test@gmail.com"
   
            };

            Assert.Throws<ArgumentException>(() =>
                player);
        }

        [Fact]
        public void Player_WithValidInput_HaveCorrectProperties()
        {
            string test_name = "Mike";
            string test_pass = "12345678";
            string test_email = "test@gmail.com";
            var player = new Players
            {
                Nickname = test_name,
                Password = test_pass,
                Email = test_email
   
            };

            Assert.NotNull(player.Id);
            Assert.NotNull(player.CreatedDate);
            Assert.Null(player.ModifiedDate);
            Assert.Equal(test_name, player.Nickname);
            Assert.Equal(test_pass, player.Password);
            Assert.Equal(test_email, player.Email);
        }
    }
}