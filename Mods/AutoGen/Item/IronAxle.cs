namespace Eco.Mods.TechTree
{
    // [DoNotLocalize]
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    [RequiresModule(typeof(MachinistTableObject))]        
    [RequiresSkill(typeof(MechanicsSkill), 1)]      
    public partial class IronAxleRecipe : Recipe
    {
        public IronAxleRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<IronAxleItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(typeof(MechanicsSkill), 6, MechanicsSkill.MultiplicativeStrategy, typeof(MechanicsLavishResourcesTalent)), 
            };
            this.ExperienceOnCraft = 1;  

            this.CraftMinutes = CreateCraftTimeValue(typeof(IronAxleRecipe), Item.Get<IronAxleItem>().UILink(), 5, typeof(MechanicsSkill), typeof(MechanicsFocusedSpeedTalent), typeof(MechanicsParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Iron Axle"), typeof(IronAxleRecipe));

            CraftingComponent.AddRecipe(typeof(LatheObject), this);
        }
    }

    [Serialized]
    [Weight(500)]      
    [Currency]              
    public partial class IronAxleItem :
    Item                                    
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Iron Axle"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr(""); } }
    }
}