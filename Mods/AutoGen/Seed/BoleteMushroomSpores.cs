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
    public partial class BoleteMushroomSporesItem : SeedItem
    {
        static BoleteMushroomSporesItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };

        public override LocString DisplayName        { get { return Localizer.DoStr("Bolete Mushroom Spores"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Plant to grow bolete mushrooms."); } }
        public override LocString SpeciesName        { get { return Localizer.DoStr("BoleteMushroom"); } }

        public override float Calories { get { return 0; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [Category("Hidden")]
    [Weight(50)]  
    public partial class BoleteMushroomSporesPackItem : SeedPackItem
    {
        static BoleteMushroomSporesPackItem() { }

        public override LocString DisplayName        { get { return Localizer.DoStr("Bolete Mushroom Spores Pack"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Plant to grow bolete mushrooms."); } }
        public override LocString SpeciesName        { get { return Localizer.DoStr("BoleteMushroom"); } }
    }

    [RequiresSkill(typeof(FarmingSkill), 0)]    
    public class BoleteMushroomSporesRecipe : Recipe
    {
        public BoleteMushroomSporesRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BoleteMushroomSporesItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BoleteMushroomsItem>(typeof(FarmingSkill), 2, FarmingSkill.MultiplicativeStrategy, typeof(FarmingLavishResourcesTalent))   
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(BoleteMushroomSporesRecipe), Item.Get<BoleteMushroomSporesItem>().UILink(), 1, typeof(FarmingSkill), typeof(FarmingFocusedSpeedTalent), typeof(FarmingParallelSpeedTalent));    

            this.Initialize(Localizer.DoStr("Bolete Mushroom Spores"), typeof(BoleteMushroomSporesRecipe));
            CraftingComponent.AddRecipe(typeof(FarmersTableObject), this);
        }
    }
}