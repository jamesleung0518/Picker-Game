using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(Animator), typeof(BoxCollider2D))]
public class Card : MonoBehaviour
{

    [SerializeField] protected GameObject item;
    private AudioSource audioSource;
    private Animator animator;
    
    // Start is called before the first frame update
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    public virtual void RevealItem()
    {
        if (item)
        {
            item.SetActive(true);
        }
        
        audioSource.Play();
        animator.SetTrigger("Tap");
        Player.instance.Chances -= 1;

        foreach (Transform card in transform.parent)
        {
            card.GetComponent<BoxCollider2D>().enabled = false;
        }

        Invoke("DeactivateItemAndShuffle", 2f);
    }

    private void DeactivateItemAndShuffle()
    {
        if (item)
        {
            item.SetActive(false);
        }

        animator.SetTrigger("Tap");

        if (Player.instance.Chances <= 0 || Player.instance.Health <= 0)
        {
            GameManager.instance.GameOver();
        } else
        {
            GameManager.instance.RandomShuffle();

            foreach (Transform card in transform.parent)
            {
                card.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }

}
