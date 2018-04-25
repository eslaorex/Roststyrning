using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealtScript : MonoBehaviour {

    public float health;

    public Image currentHealthBar;
    public Text ratioText;

    private float hitPoint = 150;
    private float maxHitPoint = 150;

    public int levelToLoad;

    private void Start()
    {
        UpdateHealthBar();
    }

    void Update () {
		if (health < 0f)
        {
            EnemyAIScript.isPlayerAlive = false;
            //Destroy (gameObject);
            //DeadPlayer();
        }
	}

    private void UpdateHealthBar()
    {
        float ratio = hitPoint / maxHitPoint;
        currentHealthBar.rectTransform.localScale = new Vector3(ratio,1,1);
        ratioText.text = (ratio * 100).ToString("0") + '%';




    }

    private void TakeDamage(float damage)
    {
        hitPoint -= damage;
        if (hitPoint < 0)
        {
            hitPoint = 0;
            Debug.Log("Dead");
            DeadPlayer();
        }
        UpdateHealthBar();

    }


    private void HealDamage(float heal)
    {
        hitPoint += heal;
        if (hitPoint > maxHitPoint)
        {
            hitPoint = maxHitPoint;
            UpdateHealthBar();
        }
    }

    void DeadPlayer()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    
}
