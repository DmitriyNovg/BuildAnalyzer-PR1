using System;
using BuildAnalyzer.Core;

namespace BuildAnalyzer.App;

class Program
{
    // ИСПРАВЛЕНО: Убран лишний текст после объявления метода Main
    static void Main(string[] args)
    {
        // Включаем поддержку кириллицы в консоли Windows
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== Анализатор игровой сборки персонажа ===\n");

        // Ввод данных с валидацией
        Console.Write("Введите имя персонажа: ");
        string name = Console.ReadLine() ?? "Безымянный";

        double baseAttack = ReadDouble("Введите базовую атаку: ");
        double weaponAttack = ReadDouble("Введите атаку оружия: ");
        double critChance = ReadDouble("Введите шанс критического удара (%): ");
        double critDamage = ReadDouble("Введите критический урон (%): ");

        // Создание модели из библиотеки Core
        var build = new CharacterBuild
        {
            Name = name,
            BaseAttack = baseAttack,
            WeaponAttack = weaponAttack,
            CritChancePercent = critChance,
            CritDamagePercent = critDamage
        };

        // Вывод результатов
        Console.WriteLine("\n--- Результаты анализа сборки ---");
        Console.WriteLine($"Персонаж: {build.Name}");
        Console.WriteLine($"Итоговая атака: {build.TotalAttack:F1}");
        Console.WriteLine($"Средний ожидаемый урон: {build.AverageDamage:F1}");
        Console.WriteLine($"Шанс критического удара: {build.CritChancePercent}%");
        Console.WriteLine($"Критический урон (при попадании): {build.CriticalDamageValue:F1}");
        Console.WriteLine($"Итоговый рейтинг сборки: {build.Rating}");
        Console.WriteLine("---------------------------------");

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }

    /// <summary>
    /// Вспомогательный метод для безопасного считывания чисел с консоли.
    /// </summary>
    static double ReadDouble(string prompt)
    {
        double result;
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (double.TryParse(input, out result) && result >= 0)
            {
                return result;
            }
            // ИСПРАВЛЕНО: Убран дублирующийся текст ошибки компиляции внутри строки
            Console.WriteLine("Ошибка: введите корректное неотрицательное число.");
        }
    }
}