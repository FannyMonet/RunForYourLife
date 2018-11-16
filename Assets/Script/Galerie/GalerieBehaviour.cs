using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GalerieBehaviour : MonoBehaviour {

    private string[] storiesCharacters;
    private string[] nameCharacters;
    private int currentIndex;
    public Text description;
    public Text name;
    public Sprite[] spritesSpermous;
    public SpriteRenderer spermou;
    public Animator left_arrow;
    public Animator right_arrow;
    private int waitingTime;
    public int waitingTimeAtStart;
    public AudioSource audio;
    public AudioClip clip;
	// Use this for initialization
	void Start () {
        waitingTime = waitingTimeAtStart;
        description = GameObject.Find("Description").GetComponent<Text>();
        name = GameObject.Find("Name").GetComponent<Text>();
        spermou = GameObject.Find("spermou").GetComponent<SpriteRenderer>();
        left_arrow = GameObject.Find("left_arrow").GetComponent<Animator>();
        right_arrow = GameObject.Find("right_arrow").GetComponent<Animator>();
        nameCharacters = new string[]{ "Vanilla", "Martian Super Trooper", "Alpagamete", "Sterilicorne", "Masturbat-man", "Dandy Sgondteanclok", "Rastavortement", "Cyprene", "Satembryon", "Link-Vitro" };
        audio = GetComponent<AudioSource>();
        storiesCharacters = new string[10];
        storiesCharacters[0] = "Son rêve quand il sera grand, c’est de mettre des Vans, d’être fan de Coldplay, d’acheter un pavillon, d’avoir une femme et " +
            "de beaux enfants, un crédit à payer, un épagneul anglais et un coupé-cabriolet …un mec normal, avec des envies basiques, simples !";
        storiesCharacters[1] = "Il a un peu de mal à parler lui… Lorsqu’il s’est présenté, il ne m’a donné que ses initiales alors je l’ai baptisé moi-même " +
            "pour qu’il s’adapte plus facilement, je suis sûr qu’il me remerciera un jour…tiens ça me gratte un peu moi…";
        storiesCharacters[2] = "On ne sait pas vraiment comment il est arrivé ici…mais il est tellement mignon, qui peut résister à ses petits yeux, " +
            "et sa petite moumoute, ouhgouzougouzou, c’est qui le bebe mignon ? c’est qui ? Bah oui, c’est toi ! Ougouzou ! Oubébé ! …Hum ! Pardon…";
        storiesCharacters[3] = "Robe soyeuse, yeux de biche, crinière d’or, corps élancée…finalement c’est dingue ce que peuvent faire un rhinocéros " +
            "et un poney si on les laisse un peu ensemble, j’adore la génétique !";
        storiesCharacters[4] = "Cette cellule a perdu ses parents dans un accident tragique…mais attendez, comment peut-elle exister alors ?? Tant de " +
            "mystère entourent ce personnage au passé trouble et tragique !";
        storiesCharacters[5] = "Cela fait plusieurs années qu’il est là, personne n’ose lui demander son âge, ce n’est pas très gentleman après tout ! " +
            "Mais il est là depuis suffisamment longtemps pour avoir une moustache, c’est dire ! Du coup j’ai hâte de voir la tête des parents quand " +
            "il naitra avec cette pilosité !";
        storiesCharacters[6] = "Lui il est vraiment sympa ! Je ne sais pas pourquoi mais il prend vraiment toujours la vie à la cool, pas de soucis, " +
            "il n’y pas le feu…et il a raison ! J’ai tellement à apprendre de quelqu’un d’aussi saint et sage !";
        storiesCharacters[7] = "Vous n’imaginez pas la pression que c’est d’être un enfant de Poséidon ! « Tiens-toi droite ! », " +
            "« Ne mets pas tes mains sur la table ! », « Prend des cours de chant ! » … ! Avec tout ce stress, il fallait trouver un moyen de décompresser un peu !";
        storiesCharacters[8] = "Cette cellule doit faire naitre l’antéchrist, entité qui devra réduire le monde à feu et à sang, " +
            "son rire fait froid dans le dos mais il ramène souvent des chipos aux barbecues alors on l’aime bien !";
        storiesCharacters[9] = "Humble et courageuse, cette cellule reproductrice doit faire naitre le héros du temps qui sauvera son royaume du mal. " +
            "Quelqu’un comme ça doit avoir pleins de supers anecdotes…mais lui il n’est pas très loquace, il passe son temps à crier « Haaa ! » ou « Seyaah ! » " +
            "…probablement une expérience traumatisante";
        currentIndex = 0;
        description.text = storiesCharacters[currentIndex];
        name.text = nameCharacters[currentIndex];
        spermou.sprite = spritesSpermous[currentIndex];
    }
	
	// Update is called once per frame
	void Update () {
        if(waitingTime < 0)
        {
            if (Input.GetAxis("Horizontal1") < -0.1f)
            {
                if (currentIndex < 9)
                    currentIndex++;
                else
                    currentIndex = 0;
                description.text = storiesCharacters[currentIndex];
                name.text = nameCharacters[currentIndex];
                spermou.sprite = spritesSpermous[currentIndex];
                left_arrow.SetTrigger("buttonPressed");
                waitingTime = waitingTimeAtStart;
                audio.PlayOneShot(clip);
            }
            else if (Input.GetAxis("Horizontal1") > 0.1f)
            {
                if (currentIndex > 0)
                    currentIndex--;
                else
                    currentIndex = 9;
                description.text = storiesCharacters[currentIndex];
                name.text = nameCharacters[currentIndex];
                spermou.sprite = spritesSpermous[currentIndex];
                right_arrow.SetTrigger("buttonPressed");
                waitingTime = waitingTimeAtStart;
                audio.PlayOneShot(clip);
            }
        }
        else
            waitingTime--;
        if (Input.GetButtonDown("Fire1"))
            SceneManager.LoadScene(0);
    }
}
