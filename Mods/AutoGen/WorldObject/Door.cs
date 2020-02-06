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
    [RequireComponent(typeof(MinimapComponent))]                
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class DoorObject : 
        WorldObject,    
        IRepresentsItem
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Door"); } } 

        public virtual Type RepresentedItemType { get { return typeof(DoorItem); } } 

        public override bool HasTier { get { return true; } } 
        public override int Tier { get { return 1; } } 


        protected override void Initialize()
        {

            this.GetComponent<MinimapComponent>().Initialize(Localizer.DoStr("Misc"));                

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    [ItemTier(1)]                                      
    public partial class DoorItem :
        WorldObjectItem<DoorObject> 
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Door"); } } 
        public override LocString DisplayDescription  { get { return Localizer.DoStr("A sturdy wooden door. Can be locked for certain players."); } }

        static DoorItem()
        {
            
        }

        
    }

    [RequiresSkill(typeof(HewingSkill), 0)]      
    public partial class DoorRecipe : Recipe
    {
        public DoorRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<DoorItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(HewingSkill), 12, HewingSkill.MultiplicativeStrategy, typeof(HewingLavishResourcesTalent)),          
            };
            this.ExperienceOnCraft = 2;  
            this.CraftMinutes = CreateCraftTimeValue(typeof(DoorRecipe), Item.Get<DoorItem>().UILink(), 5, typeof(HewingSkill), typeof(HewingFocusedSpeedTalent), typeof(HewingParallelSpeedTalent));    
            this.Initialize(Localizer.DoStr("Door"), typeof(DoorRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}