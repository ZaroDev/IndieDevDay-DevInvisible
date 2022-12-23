using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;
namespace Inventory.UI
{
    public class InventoryItemUI : MonoBehaviour,
     IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler
    {
        [SerializeField]
        private Image itemImage;

        [SerializeField]
        private Image borderImage;
        [SerializeField]
        private TMP_Text quantityTxt;
        private bool isEmpty = true;
        public event Action<InventoryItemUI> OnItemClicked,
            OnItemDroppedOn, OnItemBeginDrag, OnItemEndDrag,
            OnRightMouseBtnClick;
        void Awake()
        {
            ResetData();
            Deselect();
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        public void Deselect()
        {
            borderImage.enabled = false;
        }
        public void ResetData()
        {
            itemImage.gameObject.SetActive(false);
            isEmpty = true;

        }
        public void SetData(Sprite sprite, int quantity, int itemUses)
        {
            itemImage.gameObject.SetActive(true);
            itemImage.sprite = sprite;
            quantityTxt.text = quantity.ToString();
            if (itemUses > 0)
            {
                quantityTxt.text = itemUses.ToString();
            }
            isEmpty = false;
        }
        public void Select()
        {
            borderImage.enabled = true;
        }



        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                OnRightMouseBtnClick?.Invoke(this);
            }
            else
            {
                OnItemClicked?.Invoke(this);
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (isEmpty)
                return;
            OnItemBeginDrag?.Invoke(this);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OnItemEndDrag?.Invoke(this);
        }

        public void OnDrop(PointerEventData eventData)
        {
            OnItemDroppedOn?.Invoke(this);
        }

        public void OnDrag(PointerEventData eventData)
        {
        }
        public virtual void Use()
        {

        }
    }
}