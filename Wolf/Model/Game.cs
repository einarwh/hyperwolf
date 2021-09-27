using System;
using System.Collections.Generic;
using System.Linq;

namespace Wolf
{
    public class Game
    {
        public Player Player { get; set; }

        private List<RegularRoom> _regularRooms;

        public Random Random => _random;


        private static void ScatterTreasures(IEnumerable<Treasure> treasures, IList<RegularRoom> rooms, Random random)
        {
            if (treasures.Any() && rooms.Any())
            {
                var t = treasures.First();
                var rest = treasures.Skip(1);
                var index = random.Next(0, rooms.Count);
                var chosenRoom = rooms[index];
                chosenRoom.AddTreasure(t);
                rooms.Remove(chosenRoom);
                ScatterTreasures(rest, rooms, random);
            }
        }

        private static void ScatterMonsters(IEnumerable<Monster> monsters, IList<RegularRoom> rooms, Random random)
        {
            if (monsters.Any() && rooms.Any())
            {
                var t = monsters.First();
                var rest = monsters.Skip(1);
                var index = random.Next(0, rooms.Count);
                var chosenRoom = rooms[index];
                chosenRoom.PlaceMonster(t);
                rooms.Remove(chosenRoom);
                ScatterMonsters(rest, rooms, random);
            }
        }

        public Game()
        {
            var random = new Random();

            Shop = new Shop();
            Hallway = new Hallway();
            AudienceChamber = new AudienceChamber();
            GreatHall = new GreatHall();
            MeetingRoom = new MeetingRoom(CreateLargeTreasure(random));
            InnerHallway = new InnerHallway();
            Entrance = new Entrance();
            Kitchen = new Kitchen();
            StoreRoom = new StoreRoom();
            Lift = new Lift();
            RearVestibule = new RearVestibule();
            CastleExit = new CastleExit();
            Dungeon = new Dungeon();
            GuardRoom = new GuardRoom();
            MasterBedroom = new MasterBedroom();
            UpperHallway = new UpperHallway();
            Treasury = new Treasury(CreateLargeTreasure(random));
            ChambermaidsRoom = new ChambermaidsRoom();
            DressingChamber = new DressingChamber();
            SmallRoom = new SmallRoom();

            Werewolf = new Werewolf(random);
            Fleshgorger = new Fleshgorger(random);
            Maldemer = new Maldemer(random);
            Dragon = new Dragon(random);

            _regularRooms = new List<RegularRoom> {
                Hallway, AudienceChamber, GreatHall, InnerHallway, Kitchen, StoreRoom, RearVestibule, Dungeon, GuardRoom, MasterBedroom, UpperHallway, ChambermaidsRoom, DressingChamber, SmallRoom
            };

            var treasures = new List<Treasure>
            {
                CreateSmallTreasure(random),
                CreateSmallTreasure(random),
                CreateSmallTreasure(random),
                CreateSmallTreasure(random)
            };

            ScatterTreasures(treasures, RegularRooms, random);

            var monsters = new List<Monster>
            {
                Werewolf, Fleshgorger, Maldemer, Dragon
            };

            ScatterMonsters(monsters, RegularRooms, random);

            _random = random;
        }

        private static Treasure CreateSmallTreasure(Random random)
        {
            var amount = 10 + random.Next(1, 100);
            return new Treasure(new Money(amount));
        }

        private static Treasure CreateLargeTreasure(Random random)
        {
            var amount = 100 + random.Next(1, 100);
            return new Treasure(new Money(amount));
        }

        public List<RegularRoom> RegularRooms => _regularRooms.ToList();

        private readonly Random _random;

        public Shop Shop { get; }
        public Hallway Hallway { get; }
        public AudienceChamber AudienceChamber { get; }
        public GreatHall GreatHall { get; } 
        public MeetingRoom MeetingRoom { get; }
        public InnerHallway InnerHallway { get; } 
        public Entrance Entrance { get; }
        public Kitchen Kitchen { get; }
        public StoreRoom StoreRoom { get; }
        public Lift Lift { get; } 
        public RearVestibule RearVestibule { get; }
        public CastleExit CastleExit { get; }
        public Dungeon Dungeon { get; }
        public GuardRoom GuardRoom { get; }
        public MasterBedroom MasterBedroom { get; }
        public UpperHallway UpperHallway { get; }
        public Treasury Treasury { get; }
        public ChambermaidsRoom ChambermaidsRoom { get; }
        public DressingChamber DressingChamber { get; }
        public SmallRoom SmallRoom { get; }
        public Werewolf Werewolf { get; }
        public Fleshgorger Fleshgorger { get; }
        public Maldemer Maldemer { get; }
        public Dragon Dragon { get; }
    }
}
