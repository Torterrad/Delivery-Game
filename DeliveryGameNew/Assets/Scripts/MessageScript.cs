using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageScript : MonoBehaviour
{
    public float raiseTime;
    public float lowerTime;
    public float showTime;

    RectTransform rt;
    float startPosY;
    float targetPosY;
    bool lowered = true;


    public TextMeshProUGUI text;
    string[] openings = new string[] { "Ay my man, ", "Yo yo, ", "Ay listen up, ", "Hey, ", "Ay ay, " };
    string[] collects = new string[] { "pick up ", "grab ", "collect ", "get ", "fetch " };
    string[] sizes = new string[] { "small ", "regular ", "large ", "extra large ", "tripple ", "thin crust ", "filled crust ", "deep pan " };
    string[] flavours = new string[] { "cheese!", "pepperoni!", "vegan thing!", "meat feast!", "chilli supreme!", "veggie!", "BBQ chicken!", "hawaiian!" };
    string[] affirmatives = new string[] { "Alright, ", "Good job, ", "Magnifico, ", "Good good, ", "Okay, ", "Perfecto, " };
    string[] locations = new string[] { "Abby Park Street", "Adelaide Avenue", "Airplane Avenue", "Airport Avenue", "Airport Street", "Andreas Avenue", "Arthur Street", "Auerbach Avenue", "Auburn Avenue", "Barn Street", "Bay Avenue", "Beatles Avenue", "Belby Road", "Bus Avenue", "California Street", "Camp Street", "Cavour Avenue", "Central Cesta", "Central Street", "China Avenue", "Communal Square", "Constitution Street", "Copper Street", "Corn Street", "Costume Street", "Cresson Crescent", "Danish Avenue", "Dean Avenue", "Delaware Avenue", "Delta Street", "Democracy Avenue", "Department Street", "Dimitri Street", "Dock Street", "Dubnitz Road", "Eastern Cesta", "East Hills Avenue", "Easy Street", "Elgin Avenue", "Elisabeth Street", "Empire Avenue", "Eppink Square", "Farmer's Lane", "Federation Avenue", "Federation Square", "Flower Avenue", "Forest Street", "Francis II Street", "Freedom Avenue", "French Street", "Galghard Road", "Gateway Street", "Glider Avenue", "Gold Street", "Greenpark Avenue", "Hazlett Avenue", "Hendrix Avenue", "Heritage Avenue", "Highway Avenue", "History Avenue", "Hospital Street", "Hot-air Ballon Avenue", "Hurbadome Avenue", "Hurbanova Street", "Hurricane Avenue", "Ida Street", "Impressionist Avenue", "Industry Street", "Innovation Avenue", "Jamal Hustróva Street", "Jameson's Crossing", "Katrina Street", "King Arthur I street", "Kings Street", "Law Street", "Libertas Avenue", "Long Road Avenue", "Lucy Street", "Mandarin Park Lane", "Maple Street", "Marine Avenue", "Mayores Road", "McCrooke Avenue", "Medieval Street", "Mill Place", "Millstreet", "Mitch Cromwood Avenue", "Monorail Street", "Museum Avenue", "Newhaven Avenue", "New Orleans Street", "Newport Street", "New Street", "Noble City Path", "Northern Abby Avenue", "Ocean Avenue", "Oceana Side-street", "Old Port Avenue", "Old Wharf", "Overbanken Road", "Paul Hladovka Avenue", "Pazkolit Uskalie Avenue", "People's Avenue", "Pine Avenue", "Pine Street", "Plaza Street", "Poet's Street", "Prachstreet", "Prague Avenue", "Princess Avenue", "Quarry Avenue", "Queen Mary Elisabeth Alley", "Rail Avenue", "Railway Street", "River Side Road", "River Street", "Rome Avenue", "Sebastian Street", "School Street", "Shall Street", "Shopping Avenue", "Shopping Street", "Silver Street", "Sobrance Path", "Southern Abby Avenue", "Southern Avenue", "Southern Millstreet Avenue", "Southern Street", "Square Street", "State Avenue", "Stone Street", "Storm Alley", "Subway Street", "Swamp Street", "Swit Street", "Sycamore Drive", "Sylvania Avenue", "Technology Avenue", "Temmar Eastwood Avenue", "Theater Street", "Venice Street", "Vienna Street", "Vlackstreet", "Walden Alley", "Wallstreet", "Water-lily Avenue", "Water Street", "Western Cesta", "William Street", "Woodstock Street", "Zosnul Street" };
    string[] endings = new string[] { "Don't screw this up!", "Capeesh?", "Get a move on!", "On the double!", "Comprende?", "Hurry, hurry!" };

    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        startPosY = transform.localPosition.y;
        targetPosY = startPosY + rt.rect.height;
    }

    public void PrintPickUp()
    {
        if (lowered)
        {
            MessageRaise();
        }
        else
        {
            LeanTween.cancel(gameObject);
            LeanTween.moveLocal(gameObject, new Vector3(transform.localPosition.x, startPosY, 0), raiseTime).setOnComplete(() => MessageRaise());
            lowered = true;
        }

        GeneratePickUp();
    }

    public void PrintDropOff()
    {
        if (lowered)
        {
            MessageRaise();
        }
        else
        {
            LeanTween.cancel(gameObject);
            LeanTween.moveLocal(gameObject, new Vector3(transform.localPosition.x, startPosY, 0), raiseTime).setOnComplete(() => MessageRaise());
            lowered = true;
        }

        GenerateDropOff();
    }

    void MessageRaise()
    {
        lowered = false;
        LeanTween.moveLocal(gameObject, new Vector3(transform.localPosition.x, targetPosY, 0), raiseTime).setOnComplete(() => MessageLower());
    }

    void MessageLower()
    {
        LeanTween.moveLocal(gameObject, new Vector3(transform.localPosition.x, startPosY, 0), lowerTime).setDelay(showTime).setOnComplete(() => lowered = true);
    }

    public void GeneratePickUp()
    {
        text.text = openings[Random.Range(0, openings.Length)];
        text.text += "come " + collects[Random.Range(0, collects.Length)] + "this ";
        text.text += sizes[Random.Range(0, sizes.Length)];
        text.text += flavours[Random.Range(0, flavours.Length)];
    }

    public void GenerateDropOff()
    {
        text.text = affirmatives[Random.Range(0, affirmatives.Length)];
        text.text += "now deliver this to number " + Random.Range(0, 100) + " ";
        text.text += locations[Random.Range(0, locations.Length)] + "! ";
        text.text += endings[Random.Range(0, endings.Length)];
    }
}
