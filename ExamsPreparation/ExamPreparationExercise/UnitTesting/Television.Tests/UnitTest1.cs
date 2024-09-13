namespace Television.Tests
{
    using System;
    using System.Diagnostics;
    using NUnit.Framework;
    public class Tests
    {
        private TelevisionDevice televisionDevice;

        [SetUp]
        public void Setup()
        {
            televisionDevice = new TelevisionDevice("Samsung", 900, 40,25);
        }

        [Test]
        public void Ctor_WorksCorrectly()
        {
            Assert.That(televisionDevice, Is.Not.Null);
            Assert.That(televisionDevice.Brand, Is.EqualTo("Samsung"));
            Assert.That(televisionDevice.Price, Is.EqualTo(900));
            Assert.That(televisionDevice.ScreenWidth, Is.EqualTo(40));
            Assert.That(televisionDevice.ScreenHeigth, Is.EqualTo(25));
            Assert.That(televisionDevice.CurrentChannel, Is.EqualTo(0));
            Assert.That(televisionDevice.Volume, Is.EqualTo(13));
            Assert.That(televisionDevice.IsMuted, Is.EqualTo(false));
        }

        [Test]
        public void ToString_ReturnsCorrectly()
        {
            string expected = $"TV Device: {televisionDevice.Brand}, Screen Resolution: {televisionDevice.ScreenWidth}x{televisionDevice.ScreenHeigth}, Price {televisionDevice.Price}$";
            string actual = televisionDevice.ToString();
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void SwitchOn_HappyPath()
        {
            string expected = $"Cahnnel {televisionDevice.CurrentChannel} - Volume {televisionDevice.Volume} - Sound On";
            string actual = televisionDevice.SwitchOn();
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void ChangeChannel_HappyPath()
        {
            int expectedChannel = 7;
            var actual = televisionDevice.ChangeChannel(expectedChannel);
            Assert.That(expectedChannel, Is.EqualTo(actual));
        }

        [Test]
        public void ChangeChannel_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => televisionDevice.ChangeChannel(-2));
        }

        [Test]
        public void MuteDevice_HappyPath()
        {
            televisionDevice.MuteDevice();
            Assert.That(televisionDevice.IsMuted, Is.EqualTo(true));

            televisionDevice.MuteDevice();
            Assert.That(televisionDevice.IsMuted, Is.EqualTo(false));
        }

        [TestCase(7)]
        [TestCase(-7)]
        public void VolumeUp_Sets_CorrectVolume(int volumeChange)
        {
            string expected = "Volume: 20";
            string actual = televisionDevice.VolumeChange("UP", volumeChange);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void VolumeUp_SetsTo100()
        {
            string expected = "Volume: 100";
            string actual = televisionDevice.VolumeChange("UP", 100);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [TestCase(7)]
        [TestCase(-7)]
        public void VolumeDown_Sets_CorrectVolume(int volumeChange)
        {
            string expected = "Volume: 6";
            string actual = televisionDevice.VolumeChange("DOWN", volumeChange);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void VolumeDown_SetsTo0()
        {
            string expected = "Volume: 0";
            string actual = televisionDevice.VolumeChange("DOWN", -100);
            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}