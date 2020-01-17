using UnityEngine;

namespace Dustin.Scripts
{
    public enum ToolType
    {
        Axe,
        Hammer,
        PickAxe,
    }
    public class Tool : MonoBehaviour
    {
        public ToolType toolType;
        public int toolStrength = 1;
    }
}
