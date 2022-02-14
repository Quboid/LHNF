using ColossalFramework;
using HarmonyLib;
using UnityEngine;

namespace LHNF
{
    [HarmonyPatch(typeof(NetTool))]
    [HarmonyPatch("RenderSegment")]
    class PatchRenderSegment
    {
        static void Prefix(NetInfo info, NetSegment.Flags flags, ref Vector3 startPosition, ref Vector3 endPosition, ref Vector3 startDirection, ref Vector3 endDirection)
        {
            if (!isLHT())
            {
                return;
            }

            // Tunnel entrances don't need inverted
            if (info.m_netAI is RoadTunnelAI)
            {
                return;
            }

            Vector3 buffer;

            buffer = endPosition;
            endPosition = startPosition;
            startPosition = buffer;

            buffer = endDirection;
            endDirection = -startDirection;
            startDirection = -buffer;
        }

        static bool isLHT()
        {
            return Singleton<SimulationManager>.instance.m_metaData.m_invertTraffic == SimulationMetaData.MetaBool.True;
        }
    }
}
