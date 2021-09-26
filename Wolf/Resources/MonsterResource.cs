using Microsoft.AspNetCore.Http;
using System;

namespace Wolf
{
    public class MonsterResource : Resource
    {
        private readonly Game _game;
        private readonly Monster _monster;

        public MonsterResource(Game game, Monster monster)
        {
            _game = game;
            _monster = monster;
        }

        protected override Representation Get(HttpContext context)
        {
            return _monster.Encounter(_game.Player);
        }

        protected override Representation Post(HttpContext context)
        {
            try
            {
                var form = context.Request.Form;
                var weaponId = form["weapon"][0];
                return _monster.Attack(_game.Player, weaponId);
            }
            catch (Exception ex)
            {
                throw new ClientErrorException("You must choose a weapon!");
            }
        }
    }
}
