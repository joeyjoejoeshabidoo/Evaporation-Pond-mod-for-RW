using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace EvaporationPond
{
    public class PlaceWorker_EvaporationPond : PlaceWorker
    {
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null, Thing thing = null)
        {
            foreach (IntVec3 c in GenAdj.CellsOccupiedBy(loc, rot, checkingDef.Size))
            {
                if (map.terrainGrid.TerrainAt(c) != DefDatabase<TerrainDef>.GetNamed("WaterOceanShallow"))
                {
                    return new AcceptanceReport("EP.MustBeBuiltOnWater".Translate());
                }
            }
            return true;
        }
    }
}
