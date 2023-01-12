namespace code.Models
{
    public class Characters
    {

    private string _name = default!;
    private string _class = default!;

    private int lvl,hp,strength,agility,intelligence,charisma = default!;

    public Characters(){
        Id = Guid.NewGuid();
        CreatedDate = DateTime.UtcNow;
        ModifiedDate = null;
        // Setting up default values
        if(Lvl == 0) Lvl = 10;
        if(Stat_HP == 0) Stat_HP = 10;
        if(Stat_Strength == 0) Stat_Strength = 10;
        if(Stat_Agility == 0) Stat_Agility = 10;
        if(Stat_Intelligence == 0) Stat_Intelligence = 10;
        if(Stat_Charisma == 0) Stat_Charisma = 10;

        

       

        

    }
    public Guid Id { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public DateTime? ModifiedDate { get;  set; }
    public string Name { 
        get => _name;
        set
        {
            ValidateName(value);
            _name = value;
        }
        } 
    public string Class { get => _class ;  set { ValidateClass(value); _class = value;} }
    public int Lvl { get => lvl;  set { ValidateStats(value); lvl = value;} }
    

    public int Stat_HP { get => hp;  set { ValidateStats(value); hp = value;} }
    public int Stat_Strength { get => strength;  set { ValidateStats(value); strength = value;} }

    public int Stat_Agility { get => agility;  set { ValidateStats(value); agility = value;} }

    public int Stat_Intelligence { get => intelligence;  set { ValidateStats(value); intelligence = value;} }
    

    public int Stat_Charisma { get => charisma;  set { ValidateStats(value); charisma = value;} }

     //throw new ArgumentException($"Name cannot be longer then {maxNameLength} characters");
    public void ValidateName(String name){

        if(!(name.Length < 30)){
            throw new InvalidOperationException("Input invalid character name - too long " + name.Length);
        }
    }

    public void ValidateClass(String cl){

        if(!(cl == "Warrior" ||cl == "Rogue" || cl == "Mage" || cl == "Priest")){
            throw new InvalidOperationException("Input invalid character class " + cl);
        }
    }

    public void ValidateStats(int stat ){

        if(!(stat > 0 && stat <= 100)){
            throw new InvalidOperationException("Input invalid character stat " + stat);
        }

    }
   

    }



    

    
}