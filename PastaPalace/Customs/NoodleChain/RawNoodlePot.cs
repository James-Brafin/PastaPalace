using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace PastaPalace.Customs.NoodleChain
{
    internal class RawNoodlePot : CustomItemGroup
    {
        public override string UniqueNameID => "RawNoodlePot";
        public override GameObject Prefab => Mod.bundle.LoadAsset<GameObject>(UniqueNameID + "Model");
        public override Item DisposesTo => Mod.Pot;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>    
        {
            new ItemGroup.ItemSet
            {
                Max = 2,
                Min = 2,
                Items = new List<Item>
                {
                    Mod.Water,
                    Mod.RawNoodles
                }
            },
            new ItemGroup.ItemSet
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>
                {
                    Mod.Pot
                }
            }
        };
        public override List<ItemGroup.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 10,
                Process = Mod.Cook,
                Result = Mod.CookedNoodlePot
            }
        };

        internal class RawNoodlePotModel : ItemGroupView
        {
            internal RawNoodlePotModel()
            {
                GameObject Prefab = Mod.bundle.LoadAsset<GameObject>("RawNoodlePotModel");

                ComponentGroups = new List<ComponentGroup>() {
                new ComponentGroup()
                {
                    Item = Mod.RawNoodles,
                    GameObject = Prefab.transform.GetChild(0).Find("Spaghetti.003").gameObject
                },

                 new ComponentGroup()
                {
                    Item = Mod.Pot,
                    GameObject = Prefab.transform.GetChild(0).Find("Pot").gameObject
                },

                  new ComponentGroup()
                {
                    Item = Mod.Water,
                    GameObject = Prefab.transform.GetChild(0).Find("Water").gameObject
                }

            };
            }
        }

        public override void OnRegister(GameDataObject gdo)
        {
            gdo.name = "Ingredient - Raw Noodle Pot";

            Prefab.AddComponent<RawNoodlePotModel>();

             MaterialUtils.ApplyMaterial<MeshRenderer>(Prefab, "Pot/Pot.001/Cylinder.001", new Material[] {
                MaterialUtils.GetExistingMaterial("Metal")});

             MaterialUtils.ApplyMaterial<MeshRenderer>(Prefab, "Pot/Pot.001/Cylinder.003", new Material[] {
                MaterialUtils.GetExistingMaterial("Metal")});

             MaterialUtils.ApplyMaterial<MeshRenderer>(Prefab, "Water", new Material[] {
               MaterialUtils.GetExistingMaterial("Water")});

             MaterialUtils.ApplyMaterial<MeshRenderer>(Prefab, "Spaghetti.002/Spaghetti.003", new Material[] {
               MaterialUtils.GetExistingMaterial("Bread - Bun")});
        }
    }
}
