using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiButton : MonoBehaviour
{
    [SerializeField]
    private GameObject targetObject;
    [SerializeField]
    private string targetMessage;

    public Color highlightColor = Color.cyan;

    private void OnMouseEnter()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null )
        {
            sprite.color = highlightColor;
        }
    }

    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = Color.white;
        }
    }

    public void OnMouseDown()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }

    public void OnMouseUp()
    {
        transform.localScale = Vector3.one;

        if (targetObject != null)
        {
            targetObject.SendMessage(targetMessage);
        }
    }
}
