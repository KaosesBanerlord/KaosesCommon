using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

//Empire names
// https://www.fantasynamegenerators.com/roman_names.php
// https://www.fantasynamegenerators.com/latin-names.php
// https://www.fantasynamegenerators.com/byzantine-names.php
//Vlandia  https://www.fantasynamegenerators.com/norman-names.php
//Sturgia   https://www.fantasynamegenerators.com/slavic_names.php
//Battania https://www.fantasynamegenerators.com/modern-scottish-names.php
// https://www.fantasynamegenerators.com/celtic-breton-names.php
// Khuzait  https://www.fantasynamegenerators.com/mongolian-names.php
// Aserai  https://www.fantasynamegenerators.com/muslim_names.php
namespace KaosesCommon.Objects
{


    /// <summary>
    /// Additional Bandit Name Info generator
    /// </summary>
    public struct AdditionalBanditNameInfo
    {
        /// <summary>
        /// If Has name prefix
        /// </summary>
        public bool HasPrefix;

        /// <summary>
        /// If has name suffix
        /// </summary>
        public bool HasSuffix;

        /// <summary>
        /// Name suffix
        /// </summary>
        public string suffix;

        /// <summary>
        /// Name prefix
        /// </summary>
        public string prefix;

        /// <summary>
        /// Party name suffix
        /// </summary>
        public string partyNameSuffix;
    }


    /// <summary>
    /// Name Generator 
    /// </summary>
    public class NameGenerator
    {

        /// <summary>
        /// Bandit suffixes
        /// </summary>
        public static List<string> banditSuffixesList = new List<string>()
        {
            "the Pirate",
            "the Cheat",
            "the Cruel",
            "the Merciless",
            "the Blood Drinker",
            "the Blood Thrirsty",
            "the Knuckles",
            "Five Fingers",
            "the Greedy",
            "the Con",
            "the Dwarf",
            "the Ravager",
            "the Weasel",
            "the Beast",
            "the Silent",
            "the Nightmare",
            "the Rat",
            "the Crazy",
            "the Thief",
            "Black Eye",
            "Gold Digger",
            "the Danger",
            "the Lucky",
            "Black Eyes",
            "Two Face",
            "the Bull",
            "Toothless",
            "the Lunatic",
            "the Silent",
            "Coins",
            "Three Toes",
            "Three Fingers",
            "the Swindler",
            "the Ravager",
            "the Phantom",
            "Mad Eyes",
            "the Sly",
            "the Spider",
            "Devin the Cheat",
            "Terry the Pillager",
            "Coins",
            "Coins",
            "Coins",
        };

        /// <summary>
        /// Bandit Prefixes
        /// </summary>
        public static List<string> banditPrefixesList = new List<string>()
        {
            "Razortooth",
            "Rusty",
            "Merciless",
            "Bloody",
            "Reaper",
            "Serpent",
            "Grinning",
            "Fast Fingers",
            "Blackjack",
            "Brute",
            "One Eye",
            "Razor",
            //"Straight Jacket",
            "Smokey",
            "Dingbat",
            "Jester",
            "Laughing",
            "Whispering",
            "Mad Hat",
            "Lunatic",
            "Black Eyed",
            "Five Fingered",
            "Gold Digger",
            "Bullseye",
            "Viper",
            "Crazy Eyes",
            "Slithering",
            "Foolish",
            "Wild",
            "Scarface",
            "Scars",
            "jawwal",
            "Greedy",
            "Mad Eyed",
            "Dangerous",
            "Reaper",
            "Greedy",
            "Two Face",
        };

        /// <summary>
        /// Empire First Names
        /// </summary>
        public static List<string> empireFirstNames = new List<string>()
        {
            "Agnellus",
            "Lukas",
            "Euthymius",
            "Patricius",
            "Marcian",
            "Constantinianus",
            "Isidorus",
            "Florentius",
            "Libanius",
            "Andronicus",
            "Heracleonas",
            "Leontinus",
            "Donus",
            "Harmatius",
            "Cerularius",
            "Tribonianus",
            "Gregorius",
            "Gratian",
            "Domnicus",
            "Constantianus",
            "Nepotian",
            "Ablabius",
            "Aurelius",
            "Eusebius",
            "Auxentius",
            "Gratian",
            "Latinius",
            "Isidorus",
            "Praetextatus",
            "Mauricius",
            "Constantinianus",
            "Theophilus",
            "Ianuarius",
            "Libanius",
            "Fulgentius",
            "Georgios",
            "Basiliscus",
            "Domninus",
            "Eutropius",
            "Evgrius",
            "Chrysaphius",
            "Macedonius",
            "Anastasius",
            "Leontinus",
            "Priscian",
            "Avienus",
            "Romanus",
            "Hilarius",
            "Eustachius",
            "Joannes",
            "John",
            "Volusian",
            "Gallienus",
            "Vincentius",
            "Paulus",
            "Synesius",
            "Decentius",
            "Donus",
            "Spurius",
            "Manius",
            "Arruns",
            "Potitius",
            "Faenius",
            "Caelus",
            "Oppius",
            "Appius",
            "Quintis",
            "Proculus",
            "Placus",
            "Spurius",
            "Manius",
            "Aulus",
            "Gnaeus",
            "Potitus",
            "Tertius",
            "Gallus",
            "Mettius",
            "Manius",
            "Gallicles",
            "Cleomachus",
            "Godefridus",
            "Theodorus",
            "Halisca",
            "Periphanes",
            "Philematium",
            "Turbalio",
            "Phaedromus",
            "Coquus",
            "Philoxenus",
            "Cleostrata",
            "Epignomus",
            "Hadrius",
            "Charinus",
            "Abrahamus",
            "Vincentius",
            "Augustinus",
            "Quintinus",
            "Sulpicio"
        };

        /// <summary>
        /// Empire Last Names
        /// </summary>
        public static List<string> empireLastNames = new List<string>()
        {
            "Ducas",
            "Bardas",
            "Ooryphas",
            "Ptochoprodromus",
            "Caerularius",
            "Psellus",
            "Palaeologus",
            "Melodus",
            "Sphrantzes",
            "Bardanes",
            "Cantacuzene",
            "Zimisces",
            "Acominatus",
            "Ingerinus",
            "Kerularios",
            "Acropolita",
            "Rhagabe",
            "Phocus",
            "Angelus",
            "Glycas",
            "Ooryphas",
            "Bardanes",
            "Ducas",
            "Vatatzes",
            "Angelus",
            "Stauricius",
            "Constantinus",
            "Ypsilanti",
            "Melodus",
            "Phocus",
            "Rhagabe",
            "Bardas",
            "Lucaenus",
            "Planudes",
            "Macrembolitissus",
            "Attaliates",
            "Phrantzes",
            "Ooryphas",
            "Psellus",
            "Ingerinus",
            "Lascaris",
            "Ypsilanti",
            "Ooryphas",
            "Zimisces",
            "Akropolites",
            "Zonaras",
            "Lecapenas",
            "Ingerinus",
            "Palaeologus",
            "Constantinus",
            "Ingerinus",
            "Ooryphas",
            "Angelus",
            "Akropolites",
            "Botaniates",
            "Ypsilanti",
            "Lucaenus",
            "Ducas",
            "Melitus",
            "Tibullus",
            "Bellator",
            "Volturcius",
            "Albanus",
            "Cecilianus",
            "Marsyas",
            "Belisarius",
            "Roscius",
            "Asellio",
            "Lateranus",
            "Melus",
            "Rectus",
            "Decmitius",
            "Fimbria",
            "Cato",
            "Tullius",
            "Epolonius",
            "Luonercus",
            "Indaletius",
            "Seuso",
            "Iulian",
            "Tacitus",
            "Nazarius",
            "Romulus",
            "Sita",
            "Aquila",
            "Caepio",
            "Perpenna",
            "Clericus",
            "Septimius",
            "Turpilias",
            "Asellio",
            "Hortensis",
            "Laetinius",
            "Achaicus",
            "Emeritus",
            "Amor",
            "Iulian",
            "Phrantze",
            "Psella",
            "Phoca",
            "Botaniate",
            "Planuda",
            "Glyca",
            "Oorypha",
            "Maniake",
            "Ypsilantis",
            "Vatatze",
            "Caerularia",
            "Ingerina",
            "Planuda",
            "Comnena",
            "Botaniate",
            "Bardane",
            "Vatatze",
            "Lecapena",
            "Stratiotica",
            "Duca",
            "Philopona",
            "Bardane",
            "Botaniate",
            "Attaliate",
            "Gregora",
            "Cantacuzene",
            "Angela",
            "Vatatze",
            "Diogene",
            "Barda",
            "Attaliate",
            "Bardane",
            "Sphrantze",
            "Lecapena",
            "Kurkua",
            "Comnena",
            "Ptochoprodroma",
            "Stratiotica",
            "Prodroma",
            "Palama",
            "Lascari",
            "Oorypha",
            "Sphrantze",
            "Meloda",
            "Vatatze",
            "Botaniate",
            "Bardane",
            "Prodroma",
            "Diogene",
            "Kurkua",
            "Comnena",
            "Zimisce",
            "Attaliate",
            "jawwal",
            "Tzimiske",
            "Zonara",
            "Stratiotica",
            "Botaniate",
            "Lascari",
            "Planuda",
            "Lecapena",
            "Eonus",
            "Cervidus",
            "Angelus",
            "Emeritus",
            "Mancinus",
            "Marinius",
            "Velus",
            "Maecius",
            "Audaios",
            "Frontinus",
            "Lepidus",
            "Trebonius",
            "Dexion",
            "Sanga",
            "Sura",
            "Furius",
            "Burrus",
            "Fimus",
            "Gluvias",
            "Abito",
            "Egbuttia",
            "Dacien",
            "Agustalis",
            "Magna",
            "Balba",
            "Pomponia",
            "Turpiliana",
            "Crito",
            "Dio",
            "Cico",
            "Plautis",
            "Sura",
            "Senopiana",
            "Eburna",
            "Drusilla",
            "Adjutor",
            "Hibera",
            "Plauta",
            "Novellia",
            "Caeliana"
        };

        /// <summary>
        /// Empire First Names Female
        /// </summary>
        public static List<string> empireFirstNamesFemale = new List<string>()
        {
            "Cesarea",
            "Aemiliana",
            "Candida",
            "Placidia",
            "Pulcheria",
            "Masticana",
            "Eudoxia",
            "Honorata",
            "Domnica",
            "Didyma",
            "Placidina",
            "Ionnina",
            "Marcellina",
            "Theodoracis",
            "Cervella",
            "Proseria",
            "Iulia",
            "Athanasia",
            "Adula",
            "Epiphania",
            "Pulcheria",
            "Evantia",
            "Rhode",
            "Bore",
            "Damiane",
            "Xanthippe",
            "Marcellina",
            "Proseria",
            "Casia",
            "Olympia",
            "Marcia",
            "Prisca",
            "Eirene",
            "Palatina",
            "Argentea",
            "Honorata",
            "Stephanous",
            "Irene",
            "Passara",
            "Zena",
            "Marcellina",
            "Destasia",
            "Argentea",
            "Maximina",
            "Demetria",
            "Syagria",
            "Nereida",
            "Callinia",
            "Theophilia",
            "Cervella",
            "Honorata",
            "Marcellina",
            "Agnella",
            "Domentzia",
            "Paula",
            "Theodoracis",
            "Eugenia",
            "Nicasia",
            "Constantia",
            "Ceionia",
            "Annia",
            "Papiria",
            "Attia",
            "Bruccia",
            "Calidia",
            "Canidia",
            "Cluntia",
            "Beata",
            "Modia",
            "Grania",
            "Helvetia",
            "Viria",
            "Metilia",
            "Aelia",
            "Domitia",
            "Hirtia",
            "Aufidia",
            "Placidia",
            "Lutatia",
            "Caerellia",
            "Vagennia",
            "Vedia",
            "Vagnia",
            "Vatinia",
            "Viducia",
            "Pontidia",
            "Cantia",
            "Vesuvia",
            "Didia",
            "Cilnia",
            "Opsia",
            "Accoleia",
            "Secundinia",
            "Asinia",
            "Duronia",
            "Placidia",
            "Lucilia",
            "Camillia"
        };

        /// <summary>
        /// Vlandia First Names
        /// </summary>
        public static List<string> vlandiaFirstNames = new List<string>()
        {
            "Winebald",
            "Franc",
            "Ugene",
            "Godfreid",
            "Amalri",
            "Galeran",
            "Achard",
            "Josue",
            "Winebalt",
            "Achard",
            "Freton",
            "Tierri",
            "Teduin",
            "Aime",
            "Bernabe",
            "Dgilliaume",
            "Emory",
            "Guy",
            "Hugue",
            "Abelart",
            "Tedbald",
            "Guidmunt",
            "Droges",
            "Willelme",
            "Blaise",
            "Jules",
            "Josue",
            "Guidmund",
            "Genotin",
            "Martin",
            "Pierre",
            "Barnabe",
            "Aubin",
            "Benjamîn",
            "Serle",
            "Marc",
            "Alan",
            "Anselme",
            "Teobalt",
            "Gallien",
            "Harald",
            "Herfast",
            "Hunfreid"
        };

        /// <summary>
        /// Vlandia Last Names
        /// </summary>
        public static List<string> vlandiaLastNames = new List<string>()
        {
            "De Challon",
            "Baujot",
            "Paschal",
            "Bretel",
            "Amboise",
            "Le Goix",
            "De Moy",
            "De Montgomery",
            "Brevedent",
            "Le Goix",
            "De Quincey",
            "Mayeux",
            "Basnage",
            "Argent",
            "Masson",
            "Rassent",
            "Pane",
            "Patris",
            "De Fry",
            "Devereux",
            "Le Conte",
            "De Voil",
            "Le Pelletier",
            "Osmond",
            "Margas",
            "Enfield",
            "De Vandes",
            "Fitz",
            "Paschal",
            "De Marisco",
            "Blampied",
            "De Quincey",
            "Chambers",
            "Archer",
            "Le Jumel",
            "Osmond",
            "Du Moucel",
            "Ambray",
            "De Pardieu",
            "Timothee Brèvedent",
            "De Viuepont",
            "Godefroy",
            "Albert",
            "Riviere",
            "Carpenter",
            "De Maromme",
            "Bernard",
            "Chamberlain",
            "Maignart",
            "Le Cordier",
            "Bailleul",
            "De Viuepont",
            "Chamborne",
            "De Voil",
            "Bouchard",
            "Le Marinier",
            "Luci",
            "Mesnage",
            "Le Masson",
            "Damours",
            "Hackett",
            "Papon",
            "Wyvill",
            "Burguet",
            "Montagu",
            "Condon",
            "Busquent",
            "De Moy",
            "De Montgomery",
            "Le Seigneur",
            "Drury",
            "Puchot",
            "De Cahaihnes",
            "De Rely",
            "Halkett",
            "Beauchamp"
        };

        /// <summary>
        /// Vlandia Female First Names
        /// </summary>
        public static List<string> vlandiaFirstNamesFemale = new List<string>()
        {
            "Albrei",
            "Manoun",
            "Zenaide",
            "Pllagie",
            "Jacotte",
            "Ade",
            "Grace",
            "Jacotte",
            "Lezeline",
            "Perotene",
            "Vonette",
            "Jozeline",
            "Aspasie",
            "Elphege",
            "Juliette",
            "Claudile",
            "Helisende",
            "Eremberge",
            "Ernestene",
            "Alienor",
            "Felicitae",
            "Merleberge",
            "Cyrille",
            "Fraunchoun",
            "Denise",
            "Ophelie",
            "Katherine",
            "Rousalie",
            "Hauise",
            "Godhilde",
            "Edelene",
            "Haueise",
            "Jasmin",
            "Naise",
            "Mathilde",
            "Gabyelle",
            "Raine",
            "Victoere",
            "Louiseu",
            "Isobel",
            "Naise"
        };

        /// <summary>
        /// Sturgia First Names
        /// </summary>
        public static List<string> sturgiaFirstNames = new List<string>()
        {
            "Mecislav",
            "Derwan",
            "Bozydar",
            "Bozan",
            "Bratislav",
            "Neven",
            "Dobromil",
            "Vena",
            "Radoslaw",
            "Branik",
            "Ceslav",
            "Milanko",
            "Milosz",
            "Zeljko",
            "Vukaylo",
            "Milush",
            "Svatopluk",
            "Vojtik",
            "Jasenko",
            "Draha",
            "Zeljko",
            "Velousek",
            "Dragoslav",
            "Radoslaw",
            "Branik",
            "Miladin",
            "Slav",
            "Velousek",
            "Ludomir",
            "Nenad",
            "Radek",
            "Swietoslaw",
            "Grubisa",
            "Zvonko",
            "Bronislav",
            "Mecek",
            "Miloslaw",
            "Draha",
            "Boyan",
            "Rado",
            "Zdik",
            "Zitek",
            "Nemanja",
            "Vojkan",
            "Miroslaw",
            "Svetlan",
            "Vekoslav",
            "Yaroslav",
            "Swietoslaw",
            "Branik"
        };
        /// <summary>
        /// Sturgia Last Names
        /// </summary>
        public static List<string> sturgiaLastNames = new List<string>()
        {
            "Volinsky",
            "Zemlinsky",
            "Bobkov",
            "Ristovski",
            "Kowacewicz",
            "Stasov",
            "Pantelic",
            "Soika",
            "Golovkin",
            "Lebedev",
            "Bogoraz",
            "Petrov",
            "Hanak",
            "Calic",
            "Tichon",
            "Sosniok",
            "Jovanovi",
            "Marinovic",
            "Horny",
            "Antokolskiy",
            "Grabowsky",
            "Stojanovska",
            "Kowalski",
            "Hrushevksy",
            "Bogatzky",
            "Mirkovic",
            "Pivovarsky",
            "Chladny",
            "Vishinsky",
            "Tkacho",
            "Vinogradsky",
            "Kral",
            "Witkiewicz",
            "Morozov",
            "Tichy",
            "Tichy",
            "Fyodorov",
            "Balaban",
            "Korbel",
            "Tomasevsky",
            "Puchta",
            "Kudelin",
            "Wolny",
            "Bulganin",
            "Milutinovic",
            "Czermak",
            "Trajkovski",
            "Shostakovich",
            "Grabowski",
            "Kramar",
            "Litauer",
            "Klima",
            "Novak",
            "Perun",
            "Kulakov",
            "Yegorov",
            "Hnilo",
            "Volin",
            "Brodsky",
            "Babics",
            "Yegorov",
            "Litvinov",
            "Malik",
            "Berezovsky",
            "Mijalkovski",
            "Dokychuk",
            "Brodsky",
            "Miltchev",
            "Petrov",
            "Sendula",
            "Tomasevsky",
            "Janowitz",
            "Horak",
            "Gajic",
            "Mendeleev",
            "Miskovic",
            "Krall",
            "Spivak",
            "Dworschak",
            "Kramar",
            "Reznik",
            "Carlowitz",
            "Pribonic",
            "Jelen",
            "Jindrak",
            "Dworschak",
            "Prchal",
            "Slowacki",
            "Marusarz",
            "Witkiewicz",
            "Novacek",
            "Tolstoy",
            "Mehic",
            "Reszke",
            "Tomschik",
            "Boskovsky",
            "Lebedev",
            "Homolka"
        };
        /// <summary>
        /// Sturgia Female First Names
        /// </summary>
        public static List<string> sturgiaFirstNamesFemale = new List<string>()
        {
            "Ziva",
            "Slavica",
            "Darva",
            "Kveta",
            "Mirna",
            "Lubena",
            "Zdislava",
            "Vladimíra",
            "Milana",
            "Denica",
            "Pribislava",
            "Masha",
            "Sanya",
            "Elka",
            "Lonna",
            "Davorka",
            "Jadranka",
            "Zlatka",
            "Slavena",
            "Vesna",
            "Rada",
            "Bolena",
            "Zdeska",
            "Iryna",
            "Sonia",
            "Janika",
            "Milenka",
            "Olya",
            "Anca",
            "Lubuska",
            "Kolina",
            "Mecka",
            "Kresimira",
            "Elina",
            "Lenka",
            "Nevenka",
            "Marta",
            "Dabrowka",
            "Mira",
            "Rostislava",
            "Zdenka",
            "Sveta",
            "Zrina",
            "Svetlana",
            "Svetluska",
            "Waclawa",
            "jawwal",
            "jawwal",
            "jawwal",
            "Mirka",
            "Vedrana",
            "Kalina",
            "Tsviata",
        };

        /// <summary>
        /// Battania First Names
        /// </summary>
        public static List<string> battaniaFirstNames = new List<string>()
        {
            "Alan",
            "Callan",
            "Lyle",
            "Elijah",
            "Murray",
            "Hayden",
            "Arthur",
            "Dexter",
            "Killian",
            "Francis",
            "Leo",
            "Jamie",
            "Danny",
            "Harley",
            "Benjamin",
            "Alex",
            "Ryan",
            "Magnus",
            "Struan",
            "Alistair",
            "Brody",
            "Miller",
            "Gweltaz",
            "Gurvan",
            "Alunoc",
            "Tefanig",
            "Goul",
            "Dogmeel",
            "Gwenael",
            "Nedeleg",
            "Edern",
            "Franch",
            "Arneg",
            "Kilian",
            "Maudan",
            "Ael",
            "Meal",
            "Briz",
            "Tangi",
            "Gwenole",
            "Madenig",
            "Bieuzi",
            "Kadec",
            "Kaourant",
            "Elven",
            "Jezekael",
            "Trestanig",
            "Evemer",
            "Alinoe",
            "Mael",
            "Junan",
            "Nevenou",
            "Aidan",
            "Elijah",
            "Owen",
            "Dominic",
            "Maxwell",
            "Lochlan"
        };
        /// <summary>
        /// Battania Last Names
        /// </summary>
        public static List<string> battaniaLastNames = new List<string>()
        {
            "Higgins",
            "Steele",
            "Watson",
            "Armstrong",
            "Shepherd",
            "Hamilton",
            "McGill",
            "Irvine",
            "Sinclair",
            "Parker",
            "Connor",
            "McCallum",
            "Shaw",
            "Miller",
            "Bell",
            "Webster",
            "Middleton",
            "McBride",
            "Roberts",
            "Marshall",
            "Trepos",
            "Kerambrun",
            "Le Douget",
            "Ropars",
            "Mordrel",
            "Le Trocquer",
            "Bollore",
            "Aubert",
            "Le Goffic",
            "Pasquiou",
            "Kerdaniel",
            "Ar Merer",
            "Saliou",
            "Cariou",
            "Le Diouron",
            "Ar Mason",
            "Le Boudec",
            "Le Cam",
            "Kermabon",
            "Kerverdo",
            "Gouez",
            "Le Du",
            "Galand",
            "Lety",
            "Nedelec",
            "Calvez",
            "Le Guen",
            "Kerfriden",
            "McGregor",
            "MacMillan",
            "Montgomery",
            "Kennedy",
            "Shields",
            "McCulloch",
            "Lynch",
            "Sutherland",
            "Morvand",
            "Le Droumaguet",
            "Tardivel",
            "Dosser",
            "Dincuff",
            "Moisan",
            "Kadoret",
            "Badoual",
            "Kadoret",
            "Corbiere",
            "Le Bars",
            "Bothorel",
            "Visdeloup",
            "Eouzan",
            "Le Gonidec",
            "Moigne",
            "Segalen",
            "Yvenou",
            "Guillermo",
            "Le Goffic",
            "Guillou",
            "Flageul",
            "De Gaulle",
            "Le Borgne",
            "Eouzan",
            "Renan",
            "Le Goux",
            "Danielou",
            "Le Maux",
            "Visdeloup",
            "Edwards",
            "McKenzie",
            "Murdoch",
            "McLean",
            "Wallace",
            "Burns",
            "Nelson",
            "Duffy",
            "Sharp",
            "Morris",
            "Hall",
            "Scott",
            "Woods",
            "Gallagher",
            "Barclay",
            "Gordon",
            "Webster",
            "MacLean",
            "Rankin",
            "Campbell",
            "Leslie",
            "McBride"
        };
        /// <summary>
        /// Battania Female First Names
        /// </summary>
        public static List<string> battaniaFirstNamesFemale = new List<string>()
        {
            "Laorans",
            "Liz",
            "Privelez",
            "Annig",
            "Nolwene",
            "Alana",
            "Awen",
            "Arzhula",
            "Maiwenna",
            "Madenn",
            "Arzelig",
            "Eurielle",
            "Gwenhael",
            "Koulmig",
            "Maelezig",
            "Gwenaelle",
            "Flamellig",
            "Aelez",
            "Anaique",
            "Elizabed",
            "Nolwenne",
            "Ana",
            "Brendana",
            "Argane",
            "Delfina",
            "Yael",
            "Yulizh",
            "Elvan",
            "Ruvonez",
            "Kannaig",
            "Rose",
            "Amelia",
            "Mara",
            "Darcie",
            "Jorgie",
            "Jessica",
            "Nieve",
            "Maisie",
            "Sofia",
            "Astrid",
            "Ana",
            "Rachel",
            "Robyn",
            "Edie",
            "Isabella",
            "Evelyn",
            "Hollie",
            "Ayesha",
            "Penny",
            "Natalia",
            "Rebecca",
            "Belle",
            "Harley",
        };

        /// <summary>
        /// Khuzait First Names
        /// </summary>
        public static List<string> khuzaitFirstNames = new List<string>()
        {
            "Bugra",
            "Dogu",
            "Oben",
            "Baran",
            "Tugalp",
            "Yurttas",
            "Esen",
            "Kutlug",
            "Gulhan",
            "Barca",
            "Aydiner",
            "Mengi",
            "Ayturk",
            "Eylul",
            "Yetkin",
            "Akbora",
            "Selcuk",
            "Necmi",
            "Sezer",
            "Sener",
            "Altinay",
            "Balbay",
            "Mertkan",
            "Diri",
            "Ozutok",
            "Unsoy",
            "Esenboga",
            "Yagizboga",
            "Demirhan",
            "Ender",
            "Burim",
            "Tudaongke",
            "Yesunuva",
            "Asha",
            "Chingay",
            "Geugi",
            "Temujin",
            "Sorkhanhira",
            "Idughadai",
            "Teleboge",
            "Temur",
            "Narin",
            "Tumbinai",
            "Jebeioyan",
            "Bolkhadar",
            "Munokhoi",
            "Charakha",
            "Bardam",
            "Argat",
            "jawwal",
            "Yesun",
        };

        /// <summary>
        /// Khuzait Last Names
        /// </summary>
        public static List<string> khuzaitLastNames = new List<string>()
        {
            "Kaan",
            "Sasmaz",
            "Almaz",
            "Sirin",
            "Aras",
            "Izzet",
            "Efendi",
            "Karaca",
            "Ersoy",
            "Dilmen",
            "Olmez",
            "Karaman",
            "Erdinc",
            "Kutlu",
            "Namli",
            "Sancak",
            "Tekeli",
            "Kivanc",
            "Savas",
            "Yavuz",
            "Kobal",
            "Vural",
            "Sabri",
            "Arslan",
            "Turkmen",
            "Akbulut",
            "Ozek",
            "Berk",
            "Erketu",
            "Ogele",
            "Qoricarergan",
            "Segerandalitu",
            "Tartu",
            "Onggur",
            "Suyiketu",
            "Temujin",
            "Bogorchu",
            "Khulan",
            "Khal",
            "Bashimur",
            "Chilagun",
            "Durraimur",
            "Gansukh",
            "Begugtei",
            "Yavuz",
            "Sarigul",
            "Ayranci",
            "Topal",
            "Kocyigit",
            "Topbas",
            "Tahir",
            "Sancak",
            "Firat",
            "Senturk",
            "Uzun",
            "Aktug",
            "Erdem",
            "Sen",
            "Yazici",
            "Yanki",
            "Arikan",
            "Aydogan",
            "Arica",
            "Cicek",
            "Turker",
            "Oztoprak",
            "Sokullu",
            "Onal",
            "Kaldirim",
            "Volkan",
            "Oguz",
            "Tanyu",
            "Basturk",
            "Uzan",
            "Jiguur"
        };

        /// <summary>
        /// Khuzait Female First Names
        /// </summary>
        public static List<string> khuzaitFirstNamesFemale = new List<string>()
        {
            "Abaza",
            "Senol",
            "Bati",
            "Aysin",
            "Nazli",
            "Tangul",
            "Gulum",
            "Demet",
            "Guzel",
            "Hayal",
            "Ilkbahar",
            "Ufuk",
            "Guliz",
            "Ozil",
            "Hadiye",
            "Isim",
            "Burcin",
            "Uzay",
            "Algul",
            "Ayla",
            "Akgul",
            "Pelin",
            "Devlet",
            "Zeynep",
            "Uzay",
            "Sefa",
            "Turkiye",
            "Selcuk",
            "Pinar",
            "Saran",
            "Khongordzol",
            "Cirina",
            "Erdenetungalag",
            "Solongo",
            "Sarantuya",
            "Yesugen",
            "Checheyigen",
            "Altun",
            "Khorijin",
            "Borte",
            "Narantuyaa",
            "Bayarma",
            "Medekhgui",
            "Yesuntei",
            "Berude"
        };

        /// <summary>
        /// Aserai First Names
        /// </summary>
        public static List<string> aseraiFirstNames = new List<string>()
        {
            "Musheer",
            "Munsif",
            "Jafar",
            "Kaalim",
            "Irfaan",
            "Musab",
            "Samir",
            "Raihaan",
            "Abdul",
            "Khairi",
            "Jaarallah",
            "Hameed",
            "Shaheer",
            "Suwailim",
            "Zakariyya",
            "jawwal",
            "Khaalid",
            "Raakaan",
            "Taqi",
            "Aaqil",
            "Suhaib",
            "Noori",
            "Shaheer",
            "Mazeed",
            "Bassil",
            "Maisoon",
            "Yahya",
            "Jaasim",
            "Faalih",
            "Muhaajir",
            "Sharaf",
            "Daleel",
            "Wajdi",
            "Aseel",
            "Aaish",
            "jawwal",
            "Raaji",
            "Asghar",
            "Raaid",
            "Siraaj",
            "Amjad",
            "Raakaan",
        };

        /// <summary>
        /// Aserai Last Names
        /// </summary>
        public static List<string> aseraiLastNames = new List<string>()
        {
            "Waheed",
            "Meskin",
            "Shaban",
            "Shaheen",
            "arha",
            "Rasul",
            "Azzam",
            "Zadeh",
            "Nour",
            "Saad",
            "Hashim",
            "Abdella",
            "Quadri",
            "Azzam",
            "Khalifa",
            "Vohra",
            "Abood",
            "Akhtar",
            "Shariff",
            "Abed",
            "Shaer",
            "Hares",
            "Samad",
            "Toure",
            "Saadeh",
            "Hosseini",
            "Farag",
            "Assad",
            "Mohamed",
            "Odeh",
            "Ishmael",
            "Mahdavi",
            "Salik",
            "Ahmed",
            "Srour",
            "Younes",
            "Ansari",
            "Abad",
            "Khalil",
            "Khawaja",
            "Tawil",
            "Aziz",
            "Siddique",
            "Atallah",
            "Neman",
            "Aslam",
            "Basa",
            "Maroun",
            "Nagi",
            "Salih",
            "Miah",
            "Yassin",
            "Kazmi",
            "Beshara",
            "Dallal",
            "Zaki",
            "Chahine",
            "Samara",
            "Mourad",
            "Hamidi",
            "Azad",
            "Kaleel",
            "Ishak",
            "Chahine",
            "Rahim",
            "Farag",
            "Baten",
            "Elbaz",
            "Moghaddam",
            "Zahra",
            "Bey",
            "Rizk",
            "Sawaya",
            "Hadi",
            "Ahmad",
            "Ibrahim",
            "Naim"
        };

        /// <summary>
        /// Aserai Female First Names
        /// </summary>
        public static List<string> aseraiFirstNamesFemale = new List<string>()
        {
            "Haaritha",
            "Rahma",
            "Zahraaa",
            "Yaasmeena",
            "Mufliha",
            "Mayyaada",
            "Tawfeeqa",
            "Radwa",
            "Afnaan",
            "Shama",
            "Amal",
            "Hanoona",
            "Urwa",
            "Hazeela",
            "Sultana",
            "Rutaiba",
            "Ilhaam",
            "Khawla",
            "Zubaida",
            "Kameela",
            "Aadila",
            "Yaasmeena",
            "Juwairiya",
            "Sajaa",
            "Hamaama",
            "Mawzoona",
            "Maimoona",
            "Izza",
            "Tahiyya",
            "Aneesa",
            "Ilhaam",
            "Aatika",
            "Marzooqa",
            "Ramla",
            "Naqaa",
            "Adeeba",
            "Hadbaaa",
            "Lubaaba",
            "Tawheeda",
            "Husniyya",
            "Shaqeeqa",
            "Shamaail",
            "Ghazaala",
            "Fakeeha",
            "Shafeeqa",
            "Saamyya",
            "Rayyana",
            "Fikra",
            "Raihaana"
        };


        /// <summary>
        /// Generates a character name based on sex and clan culture
        /// </summary>
        /// <param name="clan"></param>
        /// <param name="IsFemale"></param>
        /// <returns></returns>
        public static string GetCharacterName(Clan clan, bool IsFemale = false)
        {
            string kingdomName = GetKingdomFromBanditClan(clan);
            return GetCharacterName(kingdomName, IsFemale);
        }

        /// <summary>
        /// Generates a character name based on sex and kingdom culture
        /// </summary>
        /// <param name="kingdomName"></param>
        /// <param name="IsFemale"></param>
        /// <returns></returns>
        public static string GetCharacterName(string kingdomName, bool IsFemale = false)
        {
            string characterName = "";
            int rndIndex = 0;
            float randomChance = MBRandom.RandomFloat;
            if (kingdomName == "sturgia")
            {
                //sturgian
                if (IsFemale)
                {
                    rndIndex = KaosesCommon.Kaoses.rand.Next(0, sturgiaFirstNamesFemale.Count - 1);
                    characterName = sturgiaFirstNamesFemale[rndIndex];
                }
                else
                {
                    rndIndex = KaosesCommon.Kaoses.rand.Next(0, sturgiaFirstNames.Count - 1);
                    characterName = sturgiaFirstNames[rndIndex];
                }
            }
            else if (kingdomName == "vlandia")
            {
                //vlandian
                if (IsFemale)
                {
                    rndIndex = KaosesCommon.Kaoses.rand.Next(0, sturgiaFirstNamesFemale.Count - 1);
                    characterName = sturgiaFirstNamesFemale[rndIndex];
                }
                else
                {
                    rndIndex = KaosesCommon.Kaoses.rand.Next(0, vlandiaFirstNames.Count - 1);
                    characterName = vlandiaFirstNames[rndIndex];
                }
            }
            else if (kingdomName == "battania")
            {
                //battania
                if (IsFemale)
                {
                    rndIndex = KaosesCommon.Kaoses.rand.Next(0, battaniaFirstNamesFemale.Count - 1);
                    characterName = battaniaFirstNamesFemale[rndIndex];
                }
                else
                {
                    rndIndex = KaosesCommon.Kaoses.rand.Next(0, battaniaFirstNames.Count - 1);
                    characterName = battaniaFirstNames[rndIndex];
                }
            }
            else if (kingdomName == "aserai")
            {
                //aserai
                if (IsFemale)
                {
                    rndIndex = KaosesCommon.Kaoses.rand.Next(0, aseraiFirstNamesFemale.Count - 1);
                    characterName = aseraiFirstNamesFemale[rndIndex];
                }
                else
                {
                    rndIndex = KaosesCommon.Kaoses.rand.Next(0, aseraiFirstNames.Count - 1);
                    characterName = aseraiFirstNames[rndIndex];
                }
            }
            else if (kingdomName == "khuzait")
            {
                //khuzait
                if (IsFemale)
                {
                    rndIndex = KaosesCommon.Kaoses.rand.Next(0, empireFirstNamesFemale.Count - 1);
                    characterName = empireFirstNamesFemale[rndIndex];
                }
                else
                {
                    rndIndex = KaosesCommon.Kaoses.rand.Next(0, empireFirstNames.Count - 1);
                    characterName = empireFirstNames[rndIndex];
                }
            }
            else
            {
                //empire
                if (IsFemale)
                {
                    rndIndex = KaosesCommon.Kaoses.rand.Next(0, khuzaitFirstNamesFemale.Count - 1);
                    characterName = khuzaitFirstNamesFemale[rndIndex];
                }
                else
                {
                    rndIndex = KaosesCommon.Kaoses.rand.Next(0, khuzaitFirstNames.Count - 1);
                    characterName = khuzaitFirstNames[rndIndex];
                }
            }
            return characterName;
        }

        /// <summary>
        /// Generate a Bandit name based on bandit culture
        /// </summary>
        /// <param name="clan"></param>
        /// <returns></returns>
        public static string GetKingdomFromBanditClan(Clan clan)
        {
            string kingdomName = "";
            switch (clan.StringId)
            {
                case "sea_raiders":
                    kingdomName = "sturgia";
                    break;
                case "mountain_bandits":
                    kingdomName = "vlandia";
                    break;
                case "forest_bandits":
                    kingdomName = "battania";
                    break;
                case "desert_bandits":
                    kingdomName = "aserai";
                    break;
                case "steppe_bandits":
                    kingdomName = "khuzait";
                    break;
                case "sturgia":
                    kingdomName = "sturgia";
                    break;
                case "vlandia":
                    kingdomName = "vlandia";
                    break;
                case "battania":
                    kingdomName = "battania";
                    break;
                case "aserai":
                    kingdomName = "aserai";
                    break;
                case "khuzait":
                    kingdomName = "khuzait";
                    break;
                default:
                    kingdomName = "empire";
                    break;
            }
            return kingdomName;
        }

        /// <summary>
        /// Generates additional party name parameters via random chance and culture
        /// </summary>
        /// <param name="clan"></param>
        /// <param name="additionalInfo"></param>
        public static void GetBanditAdditionalName(Clan clan, ref AdditionalBanditNameInfo additionalInfo)
        {

            int rndIndex = 0;
            float randomChance = MBRandom.RandomFloat;
            if (randomChance < 0.25f)
            {
                rndIndex = KaosesCommon.Kaoses.rand.Next(0, banditPrefixesList.Count - 1);
                additionalInfo.prefix = banditPrefixesList[rndIndex];
                additionalInfo.HasPrefix = true;
            }
            else if (randomChance > 0.75f)
            {
                rndIndex = KaosesCommon.Kaoses.rand.Next(0, banditSuffixesList.Count - 1);
                additionalInfo.suffix = banditSuffixesList[rndIndex];
                additionalInfo.HasSuffix = true;
            }

            switch (clan.StringId)
            {
                case "sea_raiders":
                    additionalInfo.partyNameSuffix = "Raiders";
                    break;
                case "mountain_bandits":
                    break;
                case "forest_bandits":
                    additionalInfo.partyNameSuffix = "Hunters";
                    break;
                case "desert_bandits":
                    additionalInfo.partyNameSuffix = "Marauders";
                    break;
                case "steppe_bandits":
                    additionalInfo.partyNameSuffix = "Horde";
                    break;
                default:
                    additionalInfo.partyNameSuffix = "Bandits";
                    break;
            }
            //return additionalInfo;
        }



    }
}
