using demo_rpg.Entities;
using Raylib_cs;

internal static class Game
{
    [System.STAThread]
    public static void Main()
    {
        Raylib.InitWindow(800, 800, "demo_rpg");

        Warrior warrior = new Warrior();

        string initialStateText =
            $"Class: Warrior\n" +
            $"MaxHP: {warrior.Health.MaxHP}\n" +
            $"Current HP: {warrior.Health.CurrentHP}\n" +
            $"Strength: {warrior.Stats.Strength}\n" +
            $"Intelligence: {warrior.Stats.Intelligence}\n" +
            $"LVL: {warrior.CurrentLVL}\n" +
            $"Current EXP: {warrior.CurrentEXP}\n" +
            $"Needed EXP: {warrior.CalculateExpToNextLVL(warrior.CurrentLVL)}";

        warrior.Health.TakeDamage(3);

        string damageStateText =
            $"WARRIOR TOOK 3 DAMAGE\n" +
            $"Current HP: {warrior.Health.CurrentHP} / {warrior.Health.MaxHP}";

        warrior.GainEXP(50);
        warrior.LVLUp();

        string levelUpStateText =
            $"+50 EXP\n" +
            $"MaxHP: {warrior.Health.MaxHP}\n" +
            $"Current HP: {warrior.Health.CurrentHP}\n" +
            $"Strength: {warrior.Stats.Strength}\n" +
            $"Intelligence: {warrior.Stats.Intelligence}\n" +
            $"LVL: {warrior.CurrentLVL}\n" +
            $"Current EXP: {warrior.CurrentEXP}\n" +
            $"Needed EXP: {warrior.CalculateExpToNextLVL(warrior.CurrentLVL)}";

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            Raylib.DrawText(initialStateText, 12, 12, 20, Color.Black);

            Raylib.DrawText(damageStateText, 12, 225, 20, Color.Red);

            Raylib.DrawText(levelUpStateText, 12, 300, 20, Color.Black);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}