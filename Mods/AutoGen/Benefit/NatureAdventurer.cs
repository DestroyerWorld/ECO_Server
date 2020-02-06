namespace Eco.Mods.TechTree
{
    // [DoNotLocalize]
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    public partial class NatureAdventurerTalent : Talent
    {
        public override bool Base { get { return true; } }
    }

    [Serialized]
    public partial class SelfImprovementNatureAdventurerTalentGroup : TalentGroup
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Nature Adventurer: SelfImprovement"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Slightly increases movement speed in low activity areas."); } }

        public SelfImprovementNatureAdventurerTalentGroup()
        {
            Talents = new Type[]
            {
            
            typeof(SelfImprovementNatureAdventurerSpeedTalent), 
            
            
            };
            this.OwningSkill = typeof(SelfImprovementSkill);
            this.Level = 6;
        }
    }

    
    [Serialized]
    public partial class SelfImprovementNatureAdventurerSpeedTalent : NatureAdventurerTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(SelfImprovementNatureAdventurerTalentGroup); } }
        public SelfImprovementNatureAdventurerSpeedTalent()
        {
            this.Value = 1.2f;
        }
    }
    
    
    
}