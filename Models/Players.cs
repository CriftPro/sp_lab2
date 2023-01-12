using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace code.Models
{
    public class Players
    {

        private string _name = default!;
        private string _pass = default!;
        public Players()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
            ModifiedDate = null;
            Playable_character = "";

        }

        public Guid Id { get; private set; }

        public DateTime CreatedDate { get; private set; }
        public DateTime? ModifiedDate { get; set; }

        public string Nickname { get => _name;  set { ValidateName(value); _name = value;} }
        public string Password { get => _pass;  set { ValidatePassword(value); _pass = value; }}

        public string Email { get;  set; } = default!;

        public string Playable_character { get;  set; } = default!;


        public void ValidateName(String name){

        if(!(name.Length < 30 && name.Length > 5)){
            throw new InvalidOperationException("Input invalid player name - too long/short " + name.Length);
        }
        }

        public void ValidatePassword(String pass){

        if(!(pass.Length > 6)){
            throw new InvalidOperationException("Input invalid player pass - too short " + pass.Length);
        }
        }
    }
}


    
