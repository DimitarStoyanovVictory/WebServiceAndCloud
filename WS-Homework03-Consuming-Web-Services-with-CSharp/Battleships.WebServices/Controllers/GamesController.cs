namespace Battleships.WebServices.Controllers
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Web.Http;
    using Data;
    using Battleships.Models;
    using Infrastructure;
    using Models;

    [Authorize]
    public class GamesController : BaseApiController
    {
        private IUserIdProvider userIdProvider;
        
        public GamesController(IBattleshipsData data, IUserIdProvider userIdProvider) 
            : base(data)
        {
            this.userIdProvider = userIdProvider;
        }

        public IHttpActionResult GetGamesCount()
        {
            var gamesCount = Data.Games.All().Count();
            return Ok(gamesCount);
        }

        [HttpPost]
        [ActionName("create")]
        public IHttpActionResult CreateGame()
        {
            var userId = userIdProvider.GetUserId();
            var game = new Game
            {
                PlayerOneId = userId,

                // TODO: Generate ships
            };

            Data.Games.Add(game);
            Data.SaveChanges();

            return Ok(game.Id);
        }

        [HttpGet]
        [ActionName("available")]
        public IHttpActionResult GetAllAvailableGames()
        {
            var games = Data.Games
                .All()
                .Where(x => x.State == GameState.WaitingForPlayer)
                .Select(x => new
                {
                    x.Id,
                    PlayerOne = x.PlayerOne.UserName,
                    State = x.State.ToString(),
                })
                .ToList();

            return Ok(games);
        }

        [HttpPost]
        [ActionName("join")]
        public IHttpActionResult JoinGame(JoinGameBindingModel model)
        {
            var guidGameId = new Guid(model.GameId);
            var game = Data.Games
                .All()
                .FirstOrDefault(x => x.Id == guidGameId);
            if (game == null)
            {
                return NotFound();
            }

            var userId = userIdProvider.GetUserId();
            if (game.PlayerOneId == userId)
            {
                return BadRequest("You can not join in your game!");
            }

            game.PlayerTwoId = userId;
            game.State = GameState.TurnOne;

            Data.SaveChanges();

            return Ok(game.Id);
        }

        [HttpPost]
        [ActionName("play")]
        public IHttpActionResult PlayTurn(PlayTurnBindingModel model)
        {
            if (model == null)
            {
                ModelState.AddModelError("model", "The model is empty");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var guidGameId = new Guid(model.GameId);
            var game = Data.Games
                .All()
                .FirstOrDefault(x => x.Id == guidGameId);
            if (game == null)
            {
                return NotFound();
            }

            var userId = userIdProvider.GetUserId();
            if (game.PlayerOneId != userId && game.PlayerTwoId != userId)
            {
                return BadRequest("You can't make turn in this game!");
            }

            if ((game.PlayerOneId == userId && game.State == GameState.TurnTwo) || 
                (game.PlayerTwoId == userId && game.State == GameState.TurnOne))
            {
                return BadRequest("It's not your turn!");
            }

            var fieldSideLength = (int)Math.Sqrt(game.Field.Length);
            if (model.PositionX >= fieldSideLength || model.PositionY >= fieldSideLength)
            {
                return BadRequest("Invalid position!");
            }

            var fieldPosition = model.PositionX + (model.PositionY * fieldSideLength);
            if (game.Field[fieldPosition] == 'X')
            {
                return BadRequest("Position already bombed!");
            }

            var field = new StringBuilder(game.Field);
            field[fieldPosition] = 'X';
            game.Field = field.ToString();
            game.State = game.State == GameState.TurnOne ? GameState.TurnTwo : GameState.TurnOne;
            Data.SaveChanges();

            return Ok();
        }
    }
}