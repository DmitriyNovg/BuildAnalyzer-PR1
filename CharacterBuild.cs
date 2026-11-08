namespace BuildAnalyzer.Core;

/// <summary>
/// Модель игровой сборки персонажа, содержащая входные данные и расчетные характеристики.
/// </summary>
public class CharacterBuild
{
    /// <summary>
    /// Имя персонажа.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Базовая атака персонажа.
    /// </summary>
    public double BaseAttack { get; set; }

    /// <summary>
    /// Атака, добавляемая оружием.
    /// </summary>
    public double WeaponAttack { get; set; }

    /// <summary>
    /// Шанс критического удара в процентах.
    /// </summary>
    public double CritChancePercent { get; set; }

    /// <summary>
    /// Множитель критического урона в процентах.
    /// </summary>
    public double CritDamagePercent { get; set; }

    /// <summary>
    /// 1. Итоговая атака: Базовая атака + Атака оружия.
    /// </summary>
    public double TotalAttack => BaseAttack + WeaponAttack;

    /// <summary>
    /// 2. Критический урон: Итоговая атака * (1 + Критический урон в процентах / 100).
    /// </summary>
    public double CriticalDamageValue => TotalAttack * (1.0 + CritDamagePercent / 100.0);

    /// <summary>
    /// 3. Средний ожидаемый урон: Итоговая атака * (1 + (Шанс крита / 100) * (Крит. урон / 100)).
    /// </summary>
    public double AverageDamage => TotalAttack * (1.0 + (CritChancePercent / 100.0) * (CritDamagePercent / 100.0));

    /// <summary>
    /// 4. Рейтинг сборки на основе среднего ожидаемого урона.
    /// </summary>
    public string Rating => AverageDamage switch
    {
        < 1500 => "Слабая",
        < 2500 => "Нормальная",
        < 3500 => "Хорошая",
        _ => "Отличная"
    };
}