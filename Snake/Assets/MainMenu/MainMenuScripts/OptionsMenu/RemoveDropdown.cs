using UnityEngine;
using UnityEngine.EventSystems;

namespace Snake
{
    public class RemoveDropdown : MonoBehaviour
    {
        void Update()
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if(GameObject.Find("Dropdown List") != null)
                {
                    Destroy(GameObject.Find("Dropdown List").gameObject);
                }
            }
        }
    }
}