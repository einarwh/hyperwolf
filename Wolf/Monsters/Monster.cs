using System;
using System.Collections.Generic;
using System.Linq;

namespace Wolf
{
    public abstract class Monster
    {
        private readonly Random _random;

        public abstract string Id { get; }
        public abstract string Title { get; }
        public abstract int DangerLevel { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsAlive { get; set; } = true;
        public Place Location { get; set; }

        public Monster(Random random)
        {
            _random = random;
        }

        public Representation Encounter(Player player)
        {
            return FightMonster(player, new List<string>());
        }

        private Representation FightMonster(Player player, List<string> battleReport)
        {
            var links = new List<Link>(); 
            if (!IsActive)
            {
                var link = new Link("continue", Location.Id);
                links.Add(link);
            }

            var actions = new List<Action>();
            if (IsActive)
            {
                var action = new Action("attack", "POST", Id, "Attack the monster");

                foreach (var weapon in player.Weapons)
                {
                    action.AddField(new Field("weapon") { Type = "radio", Value = weapon.Id, Title = weapon.Name });
                }

                actions.Add(action);
            }

            var props = new Dictionary<string, object>
            {
                ["Your health is"] = player.Health.ToString(),
            };

            if (battleReport.Any())
            {
                props.Add("Battle report", string.Join(" ", battleReport));
            }

            return new Representation
            {
                Title = new Title(Title),
                Description = new Description(Description),
                Properties = props,
                Links = links,
                Actions = actions
            };
        }

        private string Description
        {
            get 
            {
                if (IsAlive)
                {
                    if (IsActive)
                    {
                        return $"You are facing a {Title}. It has danger level {DangerLevel}.";
                    }
                    else
                    {
                        return $"The {Title} defeated you. You have been badly hurt.";
                    }
                }
                else
                {
                    return $"The dead {Title} lies at your feet.";
                }
            }
        }

        public Representation Attack(Player player, string weaponId)
        {
            var weapon = ChooseWeapon(player, weaponId);

            var battleReport = new List<string>();
            if (_random.NextDouble() > 0.5)
            {
                DangerLevel = 5 * DangerLevel / 6;
                battleReport.Add($"You wounded the {Title}.");
            }

            if (_random.NextDouble() > 0.5)
            {
                player.Wound(new Health(5), this);
                battleReport.Add($"The {Title} wounded you!");
            }

            if (_random.NextDouble() > 0.35)
            {
                if (battleReport.Count == 0)
                {
                    battleReport.Add("You both missed.");
                }

                // Keep fighting.
                return FightMonster(player, battleReport);
            }
            else
            {
                // Someone won.
                var armorFactor = player.HasArmor ? 0.75 : 1;
                var adjustedDangerLevel = DangerLevel * weapon.Factor * armorFactor;

                if (_random.NextDouble() * 16 > adjustedDangerLevel)
                {
                    DangerLevel = 0;
                    IsAlive = false;
                    battleReport.Add($"You killed the {Title}!");
                }
                else
                {
                    player.Wound(player.Health / 2, this);
                    battleReport.Add($"The {Title} defeated you.");
                }

                IsActive = false;

                return FightMonster(player, battleReport);
            }
        }

        private Weapon ChooseWeapon(Player player, string weaponId)
        {
            var weapon = player.Weapons.FirstOrDefault(it => weaponId == it.Id);
            if (weapon == null)
            {
                throw new Exception($"No such weapon: {weaponId}");
            }

            return weapon;
        }
    }
}
