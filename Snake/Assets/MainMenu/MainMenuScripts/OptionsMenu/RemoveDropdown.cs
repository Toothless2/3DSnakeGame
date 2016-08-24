using UnityEngine;
using UnityEngine.EventSystems;

namespace Snake
{
    public class RemoveDropdown : MonoBehaviour, IPointerExitHandler
    {
        public void OnPointerExit(PointerEventData eventData)
        {
            Destroy(GameObject.Find("Blocker"));
            Destroy(gameObject);
        }
    }
}