﻿using System;

namespace Shop.Web
{
    public static class Globals
    {
        public const string AppName = "Shop Viewer";

        public static Random random = new Random();
        public static int RandomNum(int max = 1000) => random.Next(0, max);
    }
}