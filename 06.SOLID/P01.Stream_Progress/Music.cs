﻿namespace P01.Stream_Progress
{
    public class Music : StreamableFile
    {
        private string artist;
        private string album;

        public Music(int length, int bytesSent) : base(length, bytesSent)
        {
            this.artist = artist;
            this.album = album;
        }
    }
}
