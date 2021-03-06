namespace Eco.Mods.WorldLayers
{
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Utils;
    using Eco.Simulation.WorldLayers.Layers;

    public class WorldLayerSettingsTemperature : WorldLayerSettings
    {
        public WorldLayerSettingsTemperature() : base()
        {
            this.Name = "Temperature";
            this.DisplayName = Localizer.DoStr("Temperature");
            this.InitMultiplier = 1f;
            this.SyncToClient = false;
            this.Range = new Range(0f, 1f);
            this.RenderRange = null;
            this.MinColor = new Color(0f, 0.5f, 1f);
            this.MaxColor = new Color(1f, 0.5f, 0.5f);
            this.Percent = false;
            this.SumRelevant = false;
            this.Unit = Localizer.DoStr("Celsius");
            this.VoxelsPerEntry = 5;
            this.Category = WorldLayerCategory.World;
            this.ValueType = WorldLayerValueType.Percent;
            this.AreaDescription = "";

        }
    }
}
