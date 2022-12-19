using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace code.Models
{
    public class Characters
    {

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
    public string Name { get;  set; } = default!;
    public string Class { get;  set; } = default!;
    public int Lvl { get;  set; } = default!;
    

    public int Stat_HP { get;  set; } = default!;
    public int Stat_Strength { get;  set; } = default!;

    public int Stat_Agility { get;  set; } = default!;

    public int Stat_Intelligence { get;  set; } = default!;
    

    public int Stat_Charisma { get;  set; } = default!;


    //public Array InInventroy { get; private set; } = default!;

    }

    

    
}