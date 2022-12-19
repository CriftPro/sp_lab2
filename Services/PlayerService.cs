using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using code.DataModels;
using code.Models;
using Microsoft.EntityFrameworkCore;

namespace code.Services
{
    public class PlayerService
    {
        private readonly PlayerContext _dbContext;

        public PlayerService(PlayerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Players>> GetPlayers()
        {
        var players = await _dbContext.Players.ToListAsync();
        return players;
        }

        public async Task<List<Players>> GetPlayer(Guid id)
        {
            var player = await _dbContext.Players.Where(c => c.Id == id).ToListAsync();
            if (player == null)
            {
                throw new InvalidOperationException("Such player with id doesnt exist ");
            }

            return player;
        }

        public async Task<Players> Create(Players player)
        {



            await _dbContext.Players.AddAsync(player);
            await _dbContext.SaveChangesAsync();
            return player;
        }

        public async Task<Players> Update(Guid id, Players player)
        {


            Players pl = _dbContext.Players.Where(c => c.Id == id).FirstOrDefault();
            if (pl == null) throw new Exception("");

            pl.ModifiedDate = DateTime.UtcNow;
            pl.Nickname = player.Nickname;
            pl.Password = player.Password;
            pl.Email = player.Email;
            pl.Playable_character = player.Playable_character;

            

            await _dbContext.SaveChangesAsync();
            return pl;
        }



        public async Task<Players> Delete(Guid id)
        {

            Players player = _dbContext.Players.Where(c => c.Id == id).FirstOrDefault();
            if (player == null) throw new Exception("");

            _dbContext.Players.Attach(player);
            _dbContext.Players.Remove(player);


            await _dbContext.SaveChangesAsync();


            return player;

        }

        public void PlayerCheck(Players player){

        if(!(player.Nickname.Length < 30)){
            throw new InvalidOperationException("Input invalid player name - too long " + player.Nickname.Length);
        }

        if(!(player.Password.Length > 8)){
            throw new InvalidOperationException("Input invalid password is too short " + player.Nickname.Length);
        }

        

        




    }
    }
}