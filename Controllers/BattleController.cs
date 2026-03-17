using UI;
using Game;
namespace Battle
{
    public class BattleController
    {
        public void BattleMode(Hero hero, Enemy enemy)
        {
            Random rnd = new Random();
            bool Escaped = false;
            BattleUI.RenderStart(enemy.Name);
            while (hero.HP > 0 && enemy.HP > 0 && !Escaped)
            {
                BattleUI.RenderStats(BattleLogic.GetHeroData(hero), BattleLogic.GetEnemyData(enemy));
                bool skipTurn = false;
                BattleAction action = BattleUI.GetPlayerAction();
                switch (action)
                {
                    case BattleAction.Attack:
                        var attackResult = BattleLogic.Attack(hero, enemy);
                        BattleUI.RenderPlayerAction(attackResult);
                        break;
                    case BattleAction.HeavyAttack:
                        var heavyResult = BattleLogic.HeavyAttack(hero, enemy, rnd);
                        BattleUI.RenderPlayerAction(heavyResult);
                        break;
                    case BattleAction.UseItem:
                        if (!Game.UI.UseItemFromInventory(hero))
                        {
                            skipTurn = true;
                        }
                        break;
                    case BattleAction.Escape:
                        var escapeResult = BattleLogic.Escape(rnd);
                        BattleUI.RenderPlayerAction(escapeResult);
                        Escaped = escapeResult.IsEscapeSuccess;
                        break;
                }
                if (enemy.HP > 0 && !Escaped && !skipTurn)
                {
                    var enemyResult = BattleLogic.EnemyTurn(hero, enemy, rnd);
                    BattleUI.RenderEnemyTurn(BattleLogic.GetEnemyData(enemy), enemyResult);
                }
                if (hero.HP > 0 && enemy.HP > 0 && !Escaped && !skipTurn)
                {
                    Game.UI.WaitEnter("\nНатисніть ENTER для продовження...");
                }
            }
            if (Escaped)
            {
                Game.UI.WaitEnter("\nНатисніть ENTER для повернення до головного меню...");
            }
            else if (hero.HP <= 0)
            {
                BattleUI.RenderDefeat();
                Game.UI.WaitEnter("\nНатисніть ENTER для повернення до головного меню...");
            }
            else if (enemy.HP <= 0)
            {
                BattleUI.RenderVictory();
                BattleLogic.Victory(hero, enemy);
                Game.UI.WaitEnter("\nНатисніть ENTER для повернення до головного меню...");
            }
        }
    }
}