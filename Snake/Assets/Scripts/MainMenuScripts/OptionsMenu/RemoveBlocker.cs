using UnityEngine;
using UnityEngine.EventSystems;

namespace Snake
{
    public class RemoveBlocker : MonoBehaviour, IPointerExitHandler
    {

        void Start()
        {
            Destroy(GameObject.Find("Blocker"));
        }

        public void OnPointerExit(PointerEventData data)
        {
            Destroy(gameObject);
        }
    }
}