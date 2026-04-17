// Single Responsibility: Each class has one job
public interface IDamageable
{
    int Health { get; set; }
    void TakeDamage(int damage);
}

public interface ILogger
{
    void Log(string message);
}

public class FileLogger : ILogger
{
    public void Log(string message) 
        => File.AppendAllText("game_log.txt", message);
}

public abstract class Character : IDamageable
{
    public string Name { get; set; }
    public int Health { get; set; }
    protected ILogger Logger;
    
    protected Character(string name, int health, ILogger logger)
    {
        Name = name;
        Health = health;
        Logger = logger;
    }
    
    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
        Logger.Log($"{Name} took {damage} damage!\n");
    }
}

public class Player : Character
{
    public Inventory Inventory { get; set; }
    
    public Player(string name, int health, ILogger logger) 
        : base(name, health, logger)
    {
        Inventory = new Inventory(10);
    }
}

// Open/Closed: Easy to extend with Enemy
public class Enemy : Character
{
    public int AttackPower { get; set; }
    
    public Enemy(string name, int health, int attackPower, ILogger logger) 
        : base(name, health, logger)
    {
        AttackPower = attackPower;
    }
    
    public override void TakeDamage(int damage)
    {
        Health -= damage;
        Logger.Log($"Enemy {Name} hurt!\n");
    }
}

public class Inventory
{
    private readonly int _maxSize;
    private List<string> _items = new();
    
    public Inventory(int maxSize) => _maxSize = maxSize;
    
    public void AddItem(string item)
    {
        if (_items.Count >= _maxSize)
            _items.RemoveAt(0);
        _items.Add(item);
    }
}
