using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Task
{
    Bandage,
    Pill
}

public class PatientScript : MonoBehaviour
{
    //PopUps
    [SerializeField] private GameObject bandagePopUp;
    [SerializeField] private GameObject pillPopUp;
    private GameObject instantiatedPopUp;

    //Patient members
    [SerializeField] public Task currentTask;
    [SerializeField] private int minCurrentHp;
    [SerializeField] private int maxCurrentHp;
    [SerializeField] private int currentHP;
    [SerializeField] private int patientMaxHP;

    // Health Bar section:
    [SerializeField] private GameObject healthBarPrefab;
    private GameObject healthBar;
    private Slider slider;
    private Camera cam;
    private Transform patientTransform;
    private Vector3 healthBarPos;
    private Vector3 positionDelta;
   
    public GameObject InstantiatedPopUp { get { return instantiatedPopUp; } set { instantiatedPopUp = value; }  }
    public int PatientMaxHp { get { return patientMaxHP; } set { patientMaxHP = value; } }
    public int CurrentHP { get { return currentHP; } set { currentHP = value; } }
    public bool needSomething { get; set; }
    public float randomTime { get; set; }


    private void Start()
    {
        instantiatedPopUp = null;
        currentHP = GetRandomHp();
        InstantiateHealthBar();
    }

    private void Update()
    {
        UpdateHealthBar();
    }

    public void InstantiatePopUp(Task currentTask)
    {
        Vector3 patientPos = transform.position;
        switch (currentTask)
        {
            case Task.Bandage:
                {
                    instantiatedPopUp = Instantiate(bandagePopUp);
                    break;
                }
            case Task.Pill:
                {
                    instantiatedPopUp = Instantiate(pillPopUp);
                    break;
                }
        }
        instantiatedPopUp.transform.position = new Vector3(patientPos.x, patientPos.y + 1.5f, patientPos.z);
        instantiatedPopUp.transform.SetParent(patientTransform);
    }

    public void DestroyPopUp()
    {
        if (instantiatedPopUp != null)
        {
            needSomething = false;
            Destroy(instantiatedPopUp);
        }
    }

    public int GetRandomHp()
    {
        return Random.Range(minCurrentHp, maxCurrentHp);
    }


    //Health Bar stuff:

    public void InstantiateHealthBar()
    {
        healthBar = Instantiate(healthBarPrefab, patientTransform);
        slider = healthBar.GetComponent<Slider>();
        healthBar.transform.SetParent(GameObject.Find("Canvas").transform, false);
        healthBar.transform.SetAsFirstSibling();
        slider.maxValue = PatientMaxHp;
        slider.value = currentHP;
    }

    public void DestroyHealthBar()
    {
        Destroy(healthBar);
    }

    public void UpdateHealthBar()
    {
        // if healthbar exists on patient (else it will make everything kaput when patients are destroyed)
        if (healthBar) 
        {
            // position healthbar (it will follow the patient) and update the value
            patientTransform = gameObject.transform;
            cam = GameObject.Find("Main Camera").GetComponent<Camera>();
            positionDelta = cam.WorldToScreenPoint(patientTransform.position);
            healthBarPos = cam.WorldToScreenPoint(new Vector3(patientTransform.position.x +
                CalculateHealthBarDeltaX(positionDelta.x), patientTransform.position.y +
                CalculateHealthBarDeltaY(positionDelta.x), patientTransform.position.z));
            healthBar.transform.position = healthBarPos;
            slider.value = LerpHealthBar(slider.value, currentHP);
        }
    }
    
    //Healthbar positioning
    private float CalculateHealthBarDeltaX(float screenPosition)
    {
        if (screenPosition >= 0 && screenPosition <= 400)
        {
            return 0.75f;
        }
        if (screenPosition > 400 && screenPosition <= 600)
        {
            return 0.8f;
        }
        if (screenPosition > 600 && screenPosition <= 800)
        {
            return 0.6f;
        }
        if (screenPosition > 800 && screenPosition <= 1920)
        {
            return 0.7f;
        }
        else return 0;
    }

    //Healthbar positioning
    private float CalculateHealthBarDeltaY(float screenPosition)
    {
        if (screenPosition >= 0 && screenPosition <= 400)
        {
            return 1.1f;
        }
        if (screenPosition > 400 && screenPosition <= 600)
        {
            return 0.9f;
        }
        if (screenPosition > 600 && screenPosition <= 800)
        {
            return 0.6f;
        }
        if (screenPosition > 800 && screenPosition <= 1920)
        {
            return 0.4f;
        }
        else return 0;
    }

    private float LerpHealthBar(float current, float newHp)
    {
        if(newHp > current)
        {
            current += 0.05f;
        }
        if(newHp < current)
        {
            current -= 0.05f;
        }
        return current;
    }


    public void SpawnParticles(GameObject particles, float duration)
    {
        GameObject newParticles = Instantiate(particles, patientTransform);
        Destroy(newParticles, duration);
    }




}
