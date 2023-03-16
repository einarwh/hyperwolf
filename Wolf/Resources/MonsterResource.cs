using Microsoft.AspNetCore.Http;
using System;
using Microsoft.Extensions.Primitives;

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
            if (_game.Player == null) 
            {
                throw new RedirectException(302, "/start");
            }

            return _monster.Encounter(_game.Player);
        }

        protected override Representation Post(HttpContext context)
        {
            var form = context.Request.Form;
            var weaponValues = form["weapon"];
            if (weaponValues == StringValues.Empty) 
            {
                throw new ClientErrorException("You must choose a weapon!");
            }
            else 
            {
                var weaponId = weaponValues[0];
                return _monster.Attack(_game.Player, weaponId);
            }
        }
    }
}
