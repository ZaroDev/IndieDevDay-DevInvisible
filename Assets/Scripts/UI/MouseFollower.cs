using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Inventory.UI
{
    public class MouseFollower : MonoBehaviour
    {
        [SerializeField]
        private Canvas canvas;
        private Camera mainCam;

        [SerializeField]
        private InventoryItemUI item;

        void Awake()
        {
            canvas = transform.root.GetComponent<Canvas>();
            mainCam = Camera.main;
            item = GetComponentInChildren<InventoryItemUI>();
        }
        public void SetData(Sprite sprite, int quantity)
        {
            item.SetData(sprite, quantity);
        }
        void Update()
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                (RectTransform)canvas.transform,
                Input.mousePosition,
                canvas.worldCamera,
                out position
            );
            transform.position = canvas.transform.TransformPoint(position);
        }
        public void Toggle(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}