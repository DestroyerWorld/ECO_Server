namespace Eco.Mods.WorldLayers
{
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Utils;
    using Eco.Simulation.WorldLayers.Layers;

    public class WorldLayerSettingsSaltWater : WorldLayerSettings
    {
        public WorldLayerSettingsSaltWater() : base()
        {
            this.Name = "SaltWater";
            this.DisplayName = Localizer.DoStr("Salt Water");
            this.InitMultiplier = 1f;
            this.SyncToClient = false;
            this.Range = new Range(0f, 1f);
            this.RenderRange = null;
            this.MinColor = new Color(1f, 1f, 1f);
            this.MaxColor = new Color(0f, 0.8f, 1f);
            this.Percent = true;
            this.SumRelevant = false;
            this.Unit = "";
            this.VoxelsPerEntry = 5;
            this.Category = WorldLayerCategory.World;
            this.ValueType = WorldLayerValueType.Percent;
            this.AreaDescription = "";

        }
    }
}