using demo_rpg.Entities;
using Raylib_cs;

internal static class Game
{
    [System.STAThread]
    public static void Main()
    {
        Warrior warrior = new Warrior();

        Console.WriteLine("Class: Warrior\n" +
            $"MaxHP: {warrior.Health.MaxHP}\n" +
            $"Current HP: {warrior.Health.CurrentHP}\n" +
            $"Strength: {warrior.Stats.Strength}\n" +
            $"Intelligence: {warrior.Stats.Intelligence}\n" +
            $"LVL: {warrior.CurrentLVL}\n" +
            $"Current EXP: {warrior.CurrentEXP}\n" +
            $"EXP to next LVL: {warrior.CalculateExpToNextLVL(warrior.CurrentLVL)}"
        );

        warrior.Health.TakeDamage(3);

        Console.WriteLine(
            $"\nWARRIOR TOOK 3 DAMAGE\n" +
            $"Current HP: {warrior.Health.CurrentHP} / {warrior.Health.MaxHP}"
        );

        UInt32 exp = 50;
        warrior.GainEXP(exp);

        Console.WriteLine(
            $"\n+{exp} EXP\n" +
            $"MaxHP: {warrior.Health.MaxHP}\n" +
            $"Current HP: {warrior.Health.CurrentHP}\n" +
            $"Strength: {warrior.Stats.Strength}\n" +
            $"Intelligence: {warrior.Stats.Intelligence}\n" +
            $"LVL: {warrior.CurrentLVL}\n" +
            $"Current EXP: {warrior.CurrentEXP}\n" +
            $"EXP to next LVL: {warrior.CalculateExpToNextLVL(warrior.CurrentLVL)}"
        );

        /*

        Raylib.InitWindow(800, 800, "demo_rpg");

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            Raylib.DrawText("DEMO_RPG", 12, 12, 20, Color.Black);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
        */
    }
}