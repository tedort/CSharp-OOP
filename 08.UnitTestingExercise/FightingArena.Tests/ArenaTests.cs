using System;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena(); 
            warrior = new Warrior("Tedo", 150, 200);
        }

        [Test]
        public void Ctor_Test()
        {
            Assert.That(arena, Is.Not.Null);
        }

        [Test]
        public void Enroll_HappyPath_AddsWarrior()
        {
            arena.Enroll(warrior);
            Assert.That(arena.Count, Is.EqualTo(1));
        }

        [Test]
        public void Enroll_WarriorAlreadyAdded_ThrowsException()
        {
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        public void Fight_HappyPath()
        {
            arena.Enroll(warrior);
            Warrior secondWarrior = new Warrior("Tedo2", 120, 50);
            arena.Enroll(secondWarrior);
            int warriorHP = warrior.HP;
            arena.Fight("Tedo", "Tedo2");
            Assert.That(warrior.HP, Is.EqualTo(warriorHP - secondWarrior.Damage));
        }

        [Test]
        public void Fight_MissingWarrior_ThrowsException()
        {
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Tedo", "Tedo2"));
        }
    }
}
