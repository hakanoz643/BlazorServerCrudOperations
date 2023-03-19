using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlazorServerCrudOperations.Data
{
    public class GameServices:IGameServices
    {
        public readonly Context _context;
        public readonly NavigationManager _navigationManager;

        public GameServices(Context context,NavigationManager navigationManager) {
            _context = context;
            _navigationManager = navigationManager;

            _context.Database.EnsureCreated();
        }
        public List<Game> games { get; set; } = new List<Game>();

        public async Task CreateGameAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("videogames");
        }

        public async Task DeleteGameAsync(int id)
        {
            var game = await _context.Games.FindAsync(id);
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("videogames");
        }

        public async Task<List<Game>> GetGamesAsync()
        {
            games = await _context.Games.ToListAsync();
            return games;
        }

        public async Task<Game> GetSingleGame(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
                throw new Exception("No game here. :/");
            return game;
        }

        public async Task UpdateGameAsync(Game ngame,int id)
        {
            var ogame = await _context.Games.FindAsync(id);
            ogame = ngame;

            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("videogames");

        }
    }

    public interface IGameServices
    {
         Task<List<Game>> GetGamesAsync();
         List<Game> games { get; set; }

        Task<Game> GetSingleGame(int id);
        Task CreateGameAsync(Game game);

        Task UpdateGameAsync(Game ngame, int id);

        Task DeleteGameAsync(int id);

    }
}
