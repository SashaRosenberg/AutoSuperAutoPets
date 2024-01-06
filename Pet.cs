class Pet
{
    public string Name { get; set; } = "Ant";
    public int Attack { get; set; } = 2;
    public int Health { get; set; } = 2;
    public int Tier { get; set; } = 1;

    //add ability logic here?
    public string AbilityTrigger1 { get; set; } = "Faint";
    public string AbilityTrigger2 { get; set; } = "Faint";
    public string AbilityTrigger3 { get; set; } = "Faint";

    public int Cost { get; set; } = 3;
    public int Sell { get; set; } = 1;
    public string Pack { get; set; } = "Turtle";
    public int Position { get; set; } = 0; // Added Position property
    public Pet()
    {

    }
    public Pet(string name, int attack, int health, int tier, string abilityTrigger1, string abilityTrigger2, string abilityTrigger3, int cost, int sell, string pack, int position)
    {
        Name = name;
        Attack = attack;
        Health = health;
        Tier = tier;
        AbilityTrigger1 = abilityTrigger1;
        AbilityTrigger2 = abilityTrigger2;
        AbilityTrigger3 = abilityTrigger3;
        Cost = cost;
        Sell = sell;
        Pack = pack;
        Position = position;
    }

    public Pet(Pet p)
    {
        Name = p.Name;
        Attack = p.Attack;
        Health = p.Health;
        Tier = p.Tier;
        AbilityTrigger1 = p.AbilityTrigger1;
        AbilityTrigger2 = p.AbilityTrigger2;
        AbilityTrigger3 = p.AbilityTrigger3;
        Cost = p.Cost;
        Sell = p.Sell;
        Pack = p.Pack;
        Position = p.Position;
    }
    public void AttackPet(Pet target)
    {
        target.Health -= this.Attack;
    }

}

