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
    using Eco.Gameplay.Pipes.LiquidComponents; 

    [RequiresSkill(typeof(SmeltingSkill), 0)]      
    public partial class IronPipeRecipe : Recipe
    {
        public IronPipeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<IronPipeItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(typeof(SmeltingSkill), 3, SmeltingSkill.MultiplicativeStrategy, typeof(SmeltingLavishResourcesTalent)), 
            };
            this.ExperienceOnCraft = 0.5f;  
            this.CraftMinutes = CreateCraftTimeValue(typeof(IronPipeRecipe), Item.Get<IronPipeItem>().UILink(), 2, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Iron Pipe"), typeof(IronPipeRecipe));

            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }

    [Serialized]
    [Solid, Constructed]
    [Tier(2)]                                          
    [DoesntEncase]                                          
    [RequiresSkill(typeof(SmeltingSkill), 0)]   
    public partial class IronPipeBlock :
        PipeBlock      
        , IRepresentsItem   
    {
        public Type RepresentedItemType { get { return typeof(IronPipeItem); } }  
    }

    [Serialized]
    [MaxStackSize(10)]                                       
    [Weight(2000)]      
    [Currency]              
    [ItemTier(2)]                                      
    public partial class IronPipeItem :
    BlockItem<IronPipeBlock>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Iron Pipe"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("A pipe for transporting liquids."); } }

    }

}