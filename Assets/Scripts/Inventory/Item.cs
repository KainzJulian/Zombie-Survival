using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Item : MonoBehaviour, Pickable
{
    public ItemConfig item;
    public int amount;

    [SerializeField] SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        setSprite();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void pick()
    {
        Debug.Log(item.name);
    }

    private void setSprite()
    {
        spriteRenderer.sprite = item.sprite;
    }

    private void OnDrawGizmos()
    {
        setSprite();
    }
}
