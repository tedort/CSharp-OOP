using System;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        private const int MinAttackHp = 30;
        private const string PeshoName = "Pesho The Barbarian";
        private const int PeshoDamage = 100;
        private const int PeshoHP = 250;

        private const string IvanName = "Ivan The Invincible";
        private const int IvanDamage = 100;
        private const int IvanHP = 250;

        private Warrior pesho;

        [SetUp]
        public void SetUp()
        {
            pesho = new Warrior(PeshoName, PeshoDamage, PeshoHP);
        }

        [Test]
        public void Ctor_ValidProperties_CreatesInstance()
        {
            Assert.That(pesho, Is.Not.Null);
            Assert.That(pesho.Name, Is.EqualTo(PeshoName));
            Assert.That(pesho.HP, Is.EqualTo(PeshoHP));
            Assert.That(pesho.Damage, Is.EqualTo(PeshoDamage));
        }

        [Test]
        public void Name_IsNull_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(null, PeshoDamage, PeshoHP));
        }

        [Test]
        public void Name_IsWhiteSpace_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(" ", PeshoDamage, PeshoHP));
        }

        [Test]
        public void Damage_IsZero_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(PeshoName, 0, PeshoHP));
        }

        [Test]
        public void Damage_IsLessThanZero_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(PeshoName, -1, PeshoHP));
        }

        [Test]
        public void HP_IsLessThanZero_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(PeshoName, PeshoDamage, -1));
        }

        [Test]
        public void Attack_HappyPath_BiggerDamage()
        {
            Warrior dragan = new Warrior("Dragan", 100, 35);
            Warrior ivan = new Warrior(IvanName, IvanDamage, IvanHP);
            ivan.Attack(dragan);
            Assert.That(ivan.HP, Is.EqualTo(IvanHP - dragan.Damage));
            Assert.That(dragan.HP, Is.EqualTo(0));
        }

        [Test]
        public void Attack_HappyPath_LessDamage()
        {
            Warrior dragan = new Warrior("Dragan", 100, 35);
            int draganHP = dragan.HP;
            Warrior ivan = new Warrior("Ivan", 20, 250);
            int ivanDamage = ivan.Damage;
            ivan.Attack(dragan); 
            Assert.That(ivan.HP, Is.EqualTo(IvanHP - dragan.Damage));
            Assert.That(dragan.HP, Is.EqualTo(draganHP - ivanDamage));
        }

        [Test]
        public void Attack_EnemyWithThanMinHp_ThrowsError()
        {
            Warrior dragan = new Warrior("Dragan", 100, MinAttackHp - 5);
            Warrior ivan = new Warrior("Ivan", 20, 250);
            Assert.Throws<InvalidOperationException>(() => ivan.Attack(dragan));
        }

        [Test]
        public void Attack_WarriorWithLessThanMinHp_ThrowsError()
        {
            Warrior dragan = new Warrior("Dragan", 100, 55);
            Warrior ivan = new Warrior("Ivan", 20, MinAttackHp - 5);
            Assert.Throws<InvalidOperationException>(() => ivan.Attack(dragan));
        }

        [Test]
        public void Attack_TooStrongEnemy_ThrowsError()
        {
            Warrior dragan = new Warrior("Dragan", 100, 55);
            Warrior ivan = new Warrior("Ivan", 20, 54);
            Assert.Throws<InvalidOperationException>(() => ivan.Attack(dragan));
        }
    }
}