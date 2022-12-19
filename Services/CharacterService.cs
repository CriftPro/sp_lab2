using Microsoft.EntityFrameworkCore;
using code.DataModels;
using Code.Models;
using code.Models;

namespace Code.Services;


public class CharacterService
{
    private readonly CharacterContext _dbContext;

    public CharacterService(CharacterContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Characters>> GetCharacters()
    {
        var characters = await _dbContext.Characters.ToListAsync();
        return characters;
    }

    public async Task<List<Characters>> GetCharacter(Guid id)
    {
        var character = await _dbContext.Characters.Where(c => c.Id == id).ToListAsync();
        if( character == null){
            throw new InvalidOperationException("Such character with id doesnt exist ");
        }  

        return character;
    }

    public async Task<Characters> Create(Characters character)
    {
        CharacterCheck(character);

        
        await _dbContext.Characters.AddAsync(character);
        await _dbContext.SaveChangesAsync();
        return character;
    }

    public async Task<Characters> Update(Guid id,Characters character)
    {
        CharacterCheck(character);
        
        Characters ch = _dbContext.Characters.Where(c => c.Id == id).FirstOrDefault();
        if (ch == null) throw new Exception("");
        
        ch.ModifiedDate = DateTime.UtcNow;
        ch.Name = character.Name;
        ch.Class = character.Class;

        ch.Stat_HP = character.Stat_HP;
        ch.Stat_Strength = character.Stat_Strength;
        ch.Stat_Agility = character.Stat_Agility;
        ch.Stat_Intelligence = character.Stat_Intelligence;
        ch.Stat_Charisma = character.Stat_Charisma;
        
        await _dbContext.SaveChangesAsync();
        return ch;
    }



 public async Task<Characters> Delete(Guid id)
    {
       
        Characters character = _dbContext.Characters.Where(c => c.Id == id).FirstOrDefault();
         if (character == null) throw new Exception("");
        
        _dbContext.Characters.Attach(character);
        _dbContext.Characters.Remove(character);
        
        
        await _dbContext.SaveChangesAsync();

       return character;

    }


    public void CharacterCheck(Characters character){

        if(!(character.Name.Length < 30)){
            throw new InvalidOperationException("Input invalid character name - too long " + character.Name.Length);
        }

        if(!(character.Class == "Warrior" || character.Class == "Rogue" || character.Class == "Mage" || character.Class == "Priest")){
            throw new InvalidOperationException("Input invalid character class " + character.Class);
        }

        if(!(character.Lvl > 0 && character.Lvl <= 100)){
            throw new InvalidOperationException("Input invalid character lvl " + character.Lvl);
        }

        if(!(character.Stat_HP > 0 && character.Stat_HP <= 100)){
            throw new InvalidOperationException("Input invalid character hp " + character.Stat_HP);
        }

        if(!(character.Stat_Strength > 0 && character.Stat_Strength <= 100)){
            throw new InvalidOperationException("Input invalid character strength " + character.Stat_Strength);
        }

        if(!(character.Stat_Agility > 0 && character.Stat_Agility <= 100)){
            throw new InvalidOperationException("Input invalid character agility " + character.Stat_Agility);
        }

        if(!(character.Stat_Intelligence > 0 && character.Stat_Intelligence <= 100)){
            throw new InvalidOperationException("Input invalid character intelligence " + character.Stat_Intelligence);
        }

        if(!(character.Stat_Intelligence > 0 && character.Stat_Intelligence <= 100)){
            throw new InvalidOperationException("Input invalid character intelligence " + character.Stat_Intelligence);
        }

         if(!(character.Stat_Charisma > 0 && character.Stat_Charisma <= 100)){
            throw new InvalidOperationException("Input invalid character charisma " + character.Stat_Charisma);
        }




    }
}