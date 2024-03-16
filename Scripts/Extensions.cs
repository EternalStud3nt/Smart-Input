using UnityEngine;

namespace SmartInput
{
    public static class Extensions
    {
        public static bool IsPointed(this GameObject obj)
        {
            foreach (var hit in InputManager.Instance.RaycastPointer())
            {
                if (hit.gameObject == obj)
                {
                    return true;
                }
            }

            return false;
        }
    }

}
