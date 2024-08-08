using UnityEngine;
using System.Collections;
using System.Reflection;

public class Frog : MonoBehaviour
{
    private SkinnedMeshRenderer frogRender;
    public Animator frogAnimator;

    void Awake() // Use Awake to initialize components before Start
    {
        Transform bodyTransform = gameObject.transform.Find("Body");
        if (bodyTransform != null)
        {
            frogRender = bodyTransform.GetComponent<SkinnedMeshRenderer>();
            if (frogRender == null)
            {
                Debug.LogError("SkinnedMeshRenderer not found on the 'Body' object.");
            }
        }
        else
        {
            Debug.LogError("Child object 'Body' not found on the 'Frog' object.");
        }
    }

    void Start()
    {
        // frogAnimator = GetComponent<Animator>();
        Transform bodyTransform = gameObject.transform.Find("Body");

        if (bodyTransform != null)
            {
                SkinnedMeshRenderer skinnedMeshRenderer = bodyTransform.GetComponent<SkinnedMeshRenderer>();
                if (skinnedMeshRenderer != null)
                {
                    frogRender = bodyTransform.GetComponent<SkinnedMeshRenderer>();
                }
                else
                {
                    Debug.LogError("SkinnedMeshRenderer not found on the 'body' object.");
                }
            }
            else
            {
                Debug.LogError("Child object 'body' not found on the 'Frog' object.");
            }
    }

    void Update()
    {
        
    }

    public void Death()
    {
        setColor("green");
        Debug.Log("You KILL FROG !!!!!!!!!!!!!!!!!!!!");
        if (frogAnimator != null)
        {
            frogAnimator.Play("Kill");
            Debug.Log("Run TRIGGER");
        }
        else
        {
            Debug.LogError("Animator component not found.");
        }
    }

    public void DeathAnim()
    {
        setColor("green");
        Debug.Log("You KILL FROG !!!!!!!!!!!!!!!!!!!!");
    }

    public void setColor(string col)
    {
        Color color = Color.white; // Default color in case the specified color is not found
        PropertyInfo colorProperty = typeof(Color).GetProperty(col, BindingFlags.Static | BindingFlags.Public | BindingFlags.IgnoreCase);

        if (colorProperty != null)
        {
            color = (Color)colorProperty.GetValue(null, null);
        }
        else
        {
            Debug.LogWarning("Color not found: " + col);
        }

        if (frogRender != null)
        {
            frogRender.material.color = color;
        }
        else
        {
            Debug.LogError("frogRender is not assigned.");
        }
    }

    public void setMaterial(Material currentMaterial)
    {
        if (frogRender != null)
        {
            frogRender.material = currentMaterial;
            Debug.Log("Material set to: " + currentMaterial.name);
        }
        else
        {
            Debug.LogError("frogRender is not assigned.");
        }
    }
}