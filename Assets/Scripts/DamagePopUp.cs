using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopUp : MonoBehaviour
{


    public static DamagePopUp Create(Vector3 position, int damage)
    {
        Transform damagePopUpTransform = Instantiate(GameAssets.i.pfDamagePopUp, position, Quaternion.identity);
        DamagePopUp damagePopUp = damagePopUpTransform.GetComponent<DamagePopUp>();
        damagePopUp.Setup(damage);

        return damagePopUp;
    }

    private void Awake()
    {
        damageText = transform.GetComponent<TextMeshPro>();
    }


    private const float DISAPPEAR_TIMER_MAX = 1f;
    private TextMeshPro damageText;
    private float disappearTimer;
    private Color textColor;
    private Vector3 moveVector;
    public void Setup(int damage)
    {
        damageText.SetText(damage.ToString());
        textColor = damageText.color;
        disappearTimer = DISAPPEAR_TIMER_MAX;

        moveVector = new Vector3(0.5f, .7f) * 30f;
    }

    private void Update()
    {
        // float moveYSpeed = 8f;
        // transform.Translate(new Vector3(0, moveYSpeed, 0) * Time.deltaTime);

        transform.position += moveVector * Time.deltaTime;
        moveVector -= moveVector * 2f * Time.deltaTime;

        if (disappearTimer > DISAPPEAR_TIMER_MAX * .5f)
        {
            float increaseScaleAmount = 1f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        }
        else
        {
            float decreaseScaleAmount = 1f;
            transform.localScale += Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            damageText.color = textColor;

            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
