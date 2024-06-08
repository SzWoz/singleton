using System;
using System.Collections.Generic;

// Observer Interface
public interface IObserver
{
    void Update(List<Player> scoreBoard);
}

// Subject Class (Game)
public class Game
{
    private List<Player> players = new List<Player>();

    public void AddPlayer(Player player)
    {
        players.Add(player);
    }

    public void RemovePlayer(Player player)
    {
        players.Remove(player);
    }

    public void NotifyAll()
    {
        foreach (Player player in players)
        {
            player.Update(players);
        }
    }
}

// Player Class (ConcretePlayer implementing IObserver)
public class Player : IObserver
{
    public string Name { get; private set; }
    private int score;

    public Player(string name, int initialScore = 0)
    {
        Name = name;
        score = initialScore;
    }

    public void SetScore(int newScore)
    {
        score = newScore;
        // Notify game about score change
    }

    public int GetScore()
    {
        return score;
    }

    public void Update(List<Player> scoreBoard)
    {
        Console.WriteLine($"Scoreboard updated for {Name}:");
        foreach (Player player in scoreBoard)
        {
            Console.WriteLine($"{player.Name}: {player.GetScore()}");
        }
    }
}

// Test the implementation
public class Program
{
    public static void Main(string[] args)
    {
        Game game = new Game();

        Player player1 = new Player("Alice");
        Player player2 = new Player("Bob");
        Player player3 = new Player("Charlie");

        game.AddPlayer(player1);
        game.AddPlayer(player2);
        game.AddPlayer(player3);

        player1.SetScore(10);
        game.NotifyAll();

        player2.SetScore(20);
        game.NotifyAll();

        player3.SetScore(30);
        game.NotifyAll();
    }
}
