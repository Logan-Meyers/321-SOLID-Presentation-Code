public class Player
{
    public string Name { get; set; }
    public int Health { get; set; }
    public List<string> Inventory { get; set; }
    
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} took {damage} damage!");
        
        // Violation: Player handles its own persistence
        File.AppendAllText("game_log.txt", $"{Name} damaged\n");
    }
    
    public void AddItem(string item)
    {
        Inventory.Add(item);
        // Violation: Hardcoded inventory limit logic
        if (Inventory.Count > 10)
            Inventory.RemoveAt(0);
    }
}
