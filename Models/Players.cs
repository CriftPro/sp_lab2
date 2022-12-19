using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace code.Models
{
    public class Players
    {
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

        public string Nickname { get;  set; } = default!;
        public string Password { get;  set; } = default!;

        public string Email { get;  set; } = default!;

        public string Playable_character { get;  set; } = default!;




    }
}