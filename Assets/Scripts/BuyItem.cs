using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyItem : MonoBehaviour
{
    public int m_price;
    public Text m_interactUI;
    public AudioClip m_buySound;
    [TextArea(3, 10)] public string m_description;

    public GameObject m_shopDescription;
    public Text m_shopDescriptionPrice;
    public Text m_shopDescriptionDescription;


    private bool m_isInRange;
    // Start is called before the first frame update
    void Awake()
    {
        m_interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
        m_shopDescription = GameObject.FindGameObjectWithTag("ShopDescription");
        m_shopDescriptionPrice = GameObject.FindGameObjectWithTag("ShopDescriptionPrice").GetComponent<Text>();
        m_shopDescriptionDescription = GameObject.FindGameObjectWithTag("ShopDescriptionDescription").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (m_isInRange && Input.GetKeyDown(KeyCode.E) && (Inventory.m_instance.m_coinsCount >= m_price))
        {
            if (gameObject.CompareTag("RedPot"))
            {
                //Destroy(gameObject);
                Inventory.m_instance.RemoveCoins(m_price);
                Inventory.m_instance.AddRedPot(1);
            }
            else if (gameObject.CompareTag("BluePot"))
            {
                Destroy(gameObject);
                Inventory.m_instance.RemoveCoins(m_price);
                Inventory.m_instance.AddBluePot(1);
            }
            else if (gameObject.CompareTag("GreenPot"))
            {
                Destroy(gameObject);
                Inventory.m_instance.RemoveCoins(m_price);
                Inventory.m_instance.AddGreenPot(1);
            }
            else if (gameObject.CompareTag("Meat"))
            {
                //Destroy(gameObject);
                Inventory.m_instance.RemoveCoins(m_price);
                PlayerHealth.m_instance.Heal(20);
            }
            AudioManager.m_instance.PlayClipAt(m_buySound, transform.position);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_interactUI.enabled = true;
            m_isInRange = true;
            m_shopDescriptionPrice.text = m_price.ToString();
            m_shopDescriptionDescription.text = m_description;
            m_shopDescription.GetComponent<Animator>().SetBool("isOpen", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_isInRange = false;
            m_interactUI.enabled = false;
            m_shopDescription.GetComponent<Animator>().SetBool("isOpen", false);
        }
    }
}
