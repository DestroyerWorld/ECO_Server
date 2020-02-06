namespace Eco.Mods.TechTree
{
    // [DoNotLocalize]
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;
    
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(CustomTextComponent))]              
    [RequireComponent(typeof(MinimapComponent))]                
    public partial class LargeHangingStoneSignObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Hanging Stone Sign"); } } 

        public virtual Type RepresentedItemType { get { return typeof(LargeHangingStoneSignItem); } } 



        protected override void Initialize()
        {

            this.GetComponent<MinimapComponent>().Initialize(Localizer.DoStr("Sign"));                
            this.GetComponent<CustomTextComponent>().Initialize(700);                                       

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class LargeHangingStoneSignItem :
        WorldObjectItem<LargeHangingStoneSignObject> 
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Large Hanging Stone Sign"); } } 
        public override LocString DisplayDescription  { get { return Localizer.DoStr("A large sign for all your large text needs!"); } }

        static LargeHangingStoneSignItem()
        {
            
        }

        
    }

    [RequiresSkill(typeof(MortaringSkill), 5)]      
    public partial class LargeHangingStoneSignRecipe : Recipe
    {
        public LargeHangingStoneSignRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LargeHangingStoneSignItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<StoneItem>(typeof(MortaringSkill), 60, MortaringSkill.MultiplicativeStrategy, typeof(MortaringLavishResourcesTalent)),          
            };
            this.ExperienceOnCraft = 3;  
            this.CraftMinutes = CreateCraftTimeValue(typeof(LargeHangingStoneSignRecipe), Item.Get<LargeHangingStoneSignItem>().UILink(), 10, typeof(MortaringSkill), typeof(MortaringFocusedSpeedTalent), typeof(MortaringParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Large Hanging Stone Sign"), typeof(LargeHangingStoneSignRecipe));
            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }
}