﻿namespace Shopy.Proto.Models
{
    public class Image
    {
        public string Url { get; set; }

        public Image(string url)
        {
            Url = url;
        }
    }
}