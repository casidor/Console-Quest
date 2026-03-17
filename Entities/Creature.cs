using System;
namespace Game
{
    public abstract class Creature
    {
        public string Name{ get; set; }
        private int _HP;
        public int MaxHP{ get; protected set; }
        public int HP
        {
            get => _HP;
            protected set => _HP = Math.Clamp(value, 0, MaxHP);
        }
        public bool IsAlive => HP > 0;
        public void TakeDamage(int damage)
        {
            HP -= damage;
        }
    }
}