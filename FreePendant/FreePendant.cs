using BepInEx;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace FreePendant
{
    [BepInPlugin("makermacher.freependant", "FreePendant", "1.0")]
    public class FreePendant : BaseUnityPlugin
    {
        void Awake()
        {
            new Harmony("makermacher.freependant").PatchAll();

            Logger.LogMessage("Loaded and patched");
        }
    }

    [HarmonyPatch(typeof(HeroMerchant), "GetPendantCost")]
    public class Patch
    {
        [HarmonyPrefix]
        public static bool FreePendant(ref int __result)
        {
            __result = 0;
            return false;
        }
    }
}
