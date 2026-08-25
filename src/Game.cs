using demo_rpg.Entities;
using Raylib_cs;

internal static class Game
{
    [System.STAThread]
    public static void Main()
    {
        BaseHero p1 = new Warrior();

        Console.WriteLine($"Warrior LVL {p1.CurrentLVL}\n" +
            $"MaxHP: {p1.Health.Max}\n" +
            $"Current HP: {p1.Health.Current}\n" +
            $"Strength: {p1.Strength}\n" +
            $"Intelligence: {p1.Intelligence}\n" +
            $"EXP: {p1.CurrentEXP} / {p1.CalculateExpToNextLVL(p1.CurrentLVL)}"
        );

        p1.Health.Reduce(3);

        Console.WriteLine(
            $"\nWARRIOR TOOK 3 DAMAGE\n" +
            $"Current HP: {p1.Health.Current} / {p1.Health.Max}"
        );

        p1.GainEXP(100);
        Console.WriteLine($"\n+{10} EXP");

        Console.WriteLine(
            $"Warrior LVL {p1.CurrentLVL}\n" +
            $"MaxHP: {p1.Health.Max}\n" +
            $"Current HP: {p1.Health.Current}\n" +
            $"Strength: {p1.Strength}\n" +
            $"Intelligence: {p1.Intelligence}\n" +
            $"EXP: {p1.CurrentEXP} / {p1.CalculateExpToNextLVL(p1.CurrentLVL)}"
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