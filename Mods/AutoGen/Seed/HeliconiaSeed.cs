namespace Eco.Mods.TechTree
{
    // [DoNotLocalize]
    using System.Collections.Generic;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Items.SearchAndSelect;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Players;
    using System.ComponentModel;

    [Serialized]
    [Weight(50)]  
    [StartsDiscovered]
    public partial class HeliconiaSeedItem : SeedItem
    {
        static HeliconiaSeedItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };

        public override LocString DisplayName        { get { return Localizer.DoStr("Heliconia Seed"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Plant to grow heliconia."); } }
        public override LocString SpeciesName        { get { return Localizer.DoStr("Heliconia"); } }

        public override float Calories { get { return 0; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [Category("Hidden")]
    [Weight(50)]  
    public partial class HeliconiaSeedPackItem : SeedPackItem
    {
        static HeliconiaSeedPackItem() { }

        public override LocString DisplayName        { get { return Localizer.DoStr("Heliconia Seed Pack"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Plant to grow heliconia."); } }
        public override LocString SpeciesName        { get { return Localizer.DoStr("Heliconia"); } }
    }

}