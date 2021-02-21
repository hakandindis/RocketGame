using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetFuel : MonoBehaviour
{
    [SerializeField] private float maxFuel = 100f;
    [SerializeField] private float currentFuel = 100f;
    private float amount = 5f;
    public GameObject canvas;
    public GameObject fuelCanvas;

    public Slider fuelSlider;

    private void Start()
    {
        fuelSlider.maxValue = maxFuel;
        fuelSlider.value = currentFuel;
    }

    private void Update()
    {
        Lose_Fuel(amount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fuel"))
        {
            Get_Fuel(amount);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            Die();
        }
    }


    public void Get_Fuel(float amount)
    {
        currentFuel += amount + 20;
        fuelSlider.value += amount + 20;
        if (currentFuel >= 100)
        {
            currentFuel = maxFuel;
        }
    }

    public void Lose_Fuel(float amount)
    {
        currentFuel -= amount * Time.deltaTime;
        fuelSlider.value -= amount*Time.deltaTime;

        if (currentFuel <= 0)
        {
            Die();
        }
    }


    public void Die()
    {
        Debug.Log("Obstacle a dokundu!!!!");
        fuelCanvas.SetActive(false);
        canvas.SetActive(true);
        Time.timeScale = 0f;
    }
}
