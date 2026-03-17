using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Game;
namespace Battle
{
    public enum BattleAction { Attack, HeavyAttack, UseItem, Escape, Unknown }
    public class HeroDTO
    {
        public int HP { get; set; }
        public int MaxHP { get; set; }
    }
    public class EnemyDTO
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
    }
    public class ActionDTO
    {
        public BattleAction ActionType { get; set; }
        public int Damage { get; set; }
        public bool IsCrit { get; set; }
        public bool IsMiss { get; set; }
        public bool IsEscapeSuccess { get; set; }
    }
    public class BattleLogic
    {
        public static HeroDTO GetHeroData(Hero hero) => new HeroDTO { HP = hero.HP, MaxHP = hero.MaxHP };
        public static EnemyDTO GetEnemyData(Enemy enemy) => new EnemyDTO { Name = enemy.Name, HP = enemy.HP, MaxHP = enemy.MaxHP };
        public static ActionDTO Attack(Hero hero, Enemy enemy)
        {
            enemy.TakeDamage(hero.ATK);
            return new ActionDTO { ActionType = BattleAction.Attack, Damage = hero.ATK };
        }
        public static ActionDTO HeavyAttack(Hero hero, Enemy enemy, Random rnd)
        {
            if (rnd.Next(1, 3) == 1)
            {
                enemy.TakeDamage(hero.ATK * 2);
                return new ActionDTO { ActionType = BattleAction.HeavyAttack, Damage = hero.ATK * 2, IsCrit = true };
            }
            else
            {
                return new ActionDTO { ActionType = BattleAction.HeavyAttack, IsMiss = true };
            }
        }
        public static ActionDTO Escape(Random rnd)
        {
            if (rnd.Next(1, 3) == 1)
            {
                return new ActionDTO { ActionType = BattleAction.Escape, IsEscapeSuccess = true };
            }
            else
            {
                return new ActionDTO { ActionType = BattleAction.Escape, IsEscapeSuccess = false };
            }
        }
        public static ActionDTO EnemyTurn(Hero hero, Enemy enemy, Random rnd)
        {
            int damage = enemy.GetCritDMG(rnd, out bool Crit);
            hero.TakeDamage(damage);
            return new ActionDTO { Damage = damage, IsCrit = Crit };
        }
        public static void Victory(Hero hero, Enemy enemy)
        {
            hero.GainEXP(enemy.expGained);
            hero.UsesLeft = 3;
        }
    }
}
