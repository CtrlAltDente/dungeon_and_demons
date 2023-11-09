using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClansWars.Game
{
    public static class GameplayInformation
    {
        public static RuntimePlatform RuntimePlatform => Application.platform;

        public static int MapIndex;

        public static int PlayerTypeIndex;
    }
}