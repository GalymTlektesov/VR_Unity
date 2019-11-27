using UnityEngine.UI;
using UnityEngine;

public class KillTarget : MonoBehaviour
{
    public GameObject target;
    public ParticleSystem hitEffect;
    public GameObject killEffect;

    public Transform infoHealth;
    private Text HealthText;
    public float timeToSelect = 3.0f;
    public int score;

    public Text scoreText;
    private float countDown;
    void Start()
    {
        infoHealth.gameObject.SetActive(false);
        HealthText = infoHealth.Find("Text").GetComponent<Text>();
        score = 0;
        countDown = timeToSelect;
        hitEffect.enableEmission = false;
        scoreText.text = "Score: 0";
    }

    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        if(countDown != timeToSelect)
        {
            infoHealth.gameObject.SetActive(true);
            infoHealth.LookAt(camera.position);
            infoHealth.Rotate(0.0f, 180.0f, 0.0f);
            HealthText.text = "Health: " + (countDown * 100.0f / timeToSelect).ToString("F0");
        }
        else
        {
            infoHealth.gameObject.SetActive(false);
        }
        if(Physics.Raycast(ray, out hit) && (hit.collider.gameObject == target)){
            if(countDown > 0.0f){
                countDown -= Time.deltaTime;
                print(countDown);
                hitEffect.transform.position = hit.point;
                hitEffect.enableEmission = true;
            }
            else
            {
                Instantiate(killEffect, target.transform.position, target.transform.rotation);
                score += 1;
                scoreText.text = "Score: " + score.ToString();
                countDown = timeToSelect;
                SetRandomPosition();
            }
        }
        else
        {
            if(countDown < timeToSelect)
            {
                countDown += Time.deltaTime;
            }
            if(countDown > timeToSelect)
            {
                countDown = timeToSelect;
            }
            hitEffect.enableEmission = false;
        }
    }

    void SetRandomPosition()
    {
        float x = Random.Range(-5.0f, 5.0f);
        float z = Random.Range(-5.0f, 5.0f);
        target.transform.position = new Vector3(x, 0.0f, z);
    }
}