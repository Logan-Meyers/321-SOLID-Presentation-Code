class Player {
    public string Name { get; set; }
    public int Health { get; set; }
    public string[,] inventory = new string[10,5];

    public void Move(int direction)
    {
        // move one unit in the direction
    }

    public void Jump(int direction)
    {
        // move up or down based on jump input
    }

    public void Attack(int direction)
    {
        // attachs in the direction of player input
    }
}
