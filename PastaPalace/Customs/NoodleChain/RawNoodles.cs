using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace PastaPalace.Customs.NoodleChain
{
    internal class RawNoodles : CustomItemGroup
    {
        public override string UniqueNameID => "RawNoodles";
        public override GameObject Prefab => Mod.bundle.LoadAsset<GameObject>(UniqueNameID + "Model");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                Items = new List<Item>()
                {
                    Mod.Flour,
                    Mod.EggCracked
                }
            }
        };

        public override void OnRegister(GameDataObject gdo)
        {
            gdo.name = "Ingredient - Raw Noodles";

            MaterialUtils.ApplyMaterial<MeshRenderer>(Prefab, "Spaghetti/Spaghetti.001", new Material[] {
                MaterialUtils.GetExistingMaterial("Bread - Bun")});
        }
    }
}
