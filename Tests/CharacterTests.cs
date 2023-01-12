using code.Models;
using Xunit;

namespace code.Tests
{
    public class CharacterTests
    {
        [Fact]
        public void Character_WithInvalidInput_ThrowsAnException()
        {
            var character = new Characters
            {
                Name = "myTestingName",
                Class = "Mage",
                Lvl = 1,
                Stat_HP = 1,
                Stat_Strength = 1,
                Stat_Agility = 1,
                Stat_Intelligence = -1,
                Stat_Charisma = -1
   
            };

            Assert.Throws<ArgumentException>(() =>
                character);
        }

        [Fact]
        public void Character_WithValidInput_HaveCorrectProperties()
        {
            int stat_value = 1;
            string char_name = "Testing name";
            string char_class = "Mage";
            
            var character = new Characters
            {
                Name = "myTestingName",
                Class = char_class,
                Lvl = stat_value,
                Stat_HP = stat_value,
                Stat_Strength = stat_value,
                Stat_Agility = stat_value,
                Stat_Intelligence = stat_value,
                Stat_Charisma = stat_value
   
            };

            

            
            Assert.NotNull(character.Id);
            Assert.NotNull(character.CreatedDate);
            Assert.Null(character.ModifiedDate);
            Assert.Equal(char_name, character.Name);
            Assert.Equal(char_class, character.Class);
            Assert.Equal(stat_value, character.Lvl);
            Assert.Equal(stat_value, character.Stat_HP);
            Assert.Equal(stat_value, character.Stat_Strength);
            Assert.Equal(stat_value, character.Stat_Intelligence);
            Assert.Equal(stat_value, character.Stat_Charisma);
            

        }

       
       
    }
}