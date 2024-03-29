using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;
using System.IO;
using Unity.VisualScripting;
using System.Drawing;

public class InventorySystem : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public Dictionary<string, string> descriptions = new Dictionary<string, string>();
    public Dictionary<string, string> combinableItems = new Dictionary<string, string>();

    private void Start()
    {
        // --- First area combinable items ---
        combinableItems.Add("ASU Trinket", " ");
        combinableItems.Add("Electromagnetic Fields", "Solar Panels");
        combinableItems.Add("Solar Panels", "Electromagnetic Fields");
        combinableItems.Add("Falcon Heavy Rocket", " ");
        combinableItems.Add("Solar Electric Propulsion", " ");

        // --- Second area combinable items ---
        combinableItems.Add("Neutron Spectrometer", "Cosmic Rays");
        combinableItems.Add("Cosmic Rays", "Neutron Spectrometer");   
        combinableItems.Add("Magnetometer", " ");
        combinableItems.Add("X-Band Radio Frequency", " ");
        combinableItems.Add("Gamma Ray Spectrometer", " ");


        // First area item descriptions
        descriptions.Add("Arizona State University", "A university in Arizona that is the lead for the NASA Psyche mission and is " +
            "well known for other scientific initiatives.");

        descriptions.Add("Solar Panels", "Solar panels capture sunlight and turn it into electricity. They are used on " +
            "many spacecraft for its reliability and renewability.");

        descriptions.Add("Electromagnetic Fields", "A field of moving electrons that has many applications, one being the " +
            "generation of charged atoms. If there was a way to power an electromagnetic field it would be an extremely " +
            "efficient form of movement in a vacuum.");

        descriptions.Add("Falcon Heavy Rocket", "The Falcon Heavy is a two-stage rocket with side boosters developed by SpaceX.");

        descriptions.Add("Solar Electric Propulsion", "Powered by Hall-effect thrusters, Psyche’s solar electric propulsion system" +
            " harnesses energy from large solar arrays to create electric and magnetic fields. These, in turn, accelerate and expel" +
            " charged atoms, or ions, of a propellant called xenon (a neutral gas used in car headlights and plasma TVs) at such high" +
            " speed, it creates thrust.");

        // Second area item descriptions
        descriptions.Add("Magnetometer", "A device that can precisely detect very small magnetic fields.");

        descriptions.Add("Cosmic Rays", "High-energy particles that flow into our solar system from far away in the galaxy. " +
            "When the particles hit a surface, the elements there absorb the energy and emit neutrons and gamma rays of " +
            "varying energy levels.");

        descriptions.Add("X-Band Radio Frequency", "The X-band frequency range is on the radio portion of the electromagnetic spectrum.");

        descriptions.Add("Neutron Spectrometer", "A device that measures the amount of neutrons being released from a material or area" +
            " that can be used to identify what a specific material might be made of");

        descriptions.Add("Gamma Ray Spectrometer", "This device measures the amount and type of gamma rays a material emits when hit by" +
            " cosmic rays, the amount and type are unique for each element and is extremely useful for determining what an asteroid or" +
            " planet is made of.");


    }

    public bool findItem(string searchedName)
    {
        foreach (GameObject item in items)
        {
            if (item.name == searchedName)
            {
                return true;
            }
                
        }
        return false;
    }

    public void AddItem(GameObject item)
    {
        items.Add(item);
    }
}
