using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Transform parentToReturnTo = null;
    public Transform placeholderParent = null;

    GameObject placeholder = null;

    CardDisplay cardDisplay;
    Deck deck;
    Player player;
    void Awake()
    {
        deck = FindObjectOfType<Deck>();
        cardDisplay = gameObject.GetComponent<CardDisplay>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);

        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
        this.transform.SetAsLastSibling();

        parentToReturnTo = this.transform.parent;
        placeholderParent = parentToReturnTo;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //�巡�� �� �ð��� ������ �귯��
        this.transform.position = eventData.position;
        if(!player.levelUp)
            Time.timeScale = 0.2f;

        GetComponent<CanvasGroup>().alpha = 0.5f;

        if (placeholder.transform.parent != placeholderParent)
            placeholder.transform.SetParent(placeholderParent);

        int newSiblingIndex = placeholderParent.childCount;

        for (int i = 0; i < placeholderParent.childCount; i++)
        {
            if (this.transform.position.x < placeholderParent.GetChild(i).position.x)
            {
                newSiblingIndex = i;

                if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                    newSiblingIndex--;

                break;
            }
        }

        placeholder.transform.SetSiblingIndex(newSiblingIndex);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //�ð��� ���� �ӵ��� �ǵ���
        int returnCard = cardDisplay.cards[0].id;
        if (!player.levelUp)
        {
            Time.timeScale = 1.0f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }
        GetComponent<CanvasGroup>().alpha = 1.0f;

        this.transform.SetParent(parentToReturnTo);
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        //���� ������ Ȯ���ϰ� ī�带 �з� �ǵ���
        if (returnCard == 6 || returnCard == 7)
        {
            if (ManaSystem.currnetMana < cardDisplay.costXcards * -1)
            {
                transform.SetParent(placeholderParent);
                transform.localPosition = Vector3.zero;
            }
        }

        Destroy(placeholder);
    }

    public void ChangeTransform(float varScale, Vector3 varPos)
    {
        transform.localRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
        transform.localScale = new Vector3(varScale, varScale);
        transform.localPosition = varPos;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ChangeTransform(1.5f, new Vector3(transform.localPosition.x, transform.localPosition.y + 100.0f));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ChangeTransform(1.0f, new Vector3(transform.localPosition.x, transform.localPosition.y - 100.0f));
    }

}
