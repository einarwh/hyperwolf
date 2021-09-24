namespace Wolf
{
    public abstract class RegularRoom : Room
    {
        public void AddTreasure(Treasure treasure)
        {
            AddThing(treasure);
        }

        public void PlaceMonster(Monster monster)
        {
            monster.Location = this;
            AddMonster(monster);
        }
    }
}
