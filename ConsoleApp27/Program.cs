using System.ComponentModel;

internal class Program
{
    private static Character player;
    private static List<Item> inventory = new List<Item>();
    private static List<Monster> monsters = new List<Monster>();
    
    


    static void Main(string[] args)
    {
        GameDataSetting();
        PrintStartLogo();
        DisplayGameIntro();
        
        
    }
    public static void NameOption()
    {
        Console.Clear();
        Console.WriteLine("스파르타 던전에 오신 여러분을 환영합니다.");
        Console.WriteLine("원하시는 이름을 설정해주세요.");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.Write(">>");
        player.Name = Console.ReadLine();        
        JobOption();
        
    }
    public static void JobOption()
    {
        Console.Clear();
        Console.WriteLine("직업을 선택해주세요.");
        Console.WriteLine("1. 전사");
        Console.WriteLine("2. 도적");
        Console.WriteLine("3. 마법사");
        Console.WriteLine("4. 궁수");
        
        int input = CheckValidInput(1, 4);
        switch(input)
        {
            case 1:
                
                if(input == 1)
                {
                    player.Job = "전사";
                    player.MaxHp = 120;
                    player.Hp = 120;
                    player.Atk = 8;
                    player.Def = 10;
                }
                break;
                
            case 2:
                
                if(input == 2)
                {
                    player.Job = "도적";
                    player.MaxHp = 100;
                    player.Hp = 100;
                    player.Atk = 10;
                    player.Def = 7;
                }
                break;
            case 3:
                
                if(input == 3)
                {
                    player.Job = "마법사";
                    player.MaxHp = 70;
                    player.Hp = 70;
                    player.Atk = 15;
                    player.Def = 2;
                }
                break;
            case 4:
                
                if(input == 4)
                {
                    player.Job = "궁수";
                    player.MaxHp = 90;
                    player.Hp = 90;
                    player.Atk = 13;
                    player.Def = 5;
                }
                break;
        }

    }
    static void Dungeon()
    {
        Console.Clear();
        Console.WriteLine("던전에 들어왔습니다.");
        Console.WriteLine("1.계속하기" + "(현재진행:0층)");
        Console.WriteLine("0.나가기");

        int input = CheckValidInput(0, 1);
        switch (input)
        {
            case 1:
                Incount();
                break;

            case 0:
                DisplayGameIntro();
                break;


            default:
                Console.WriteLine("잘못된 입력입니다.");
                break;
        }
    }

    private static void PrintStartLogo()
    {
        Console.WriteLine("   ▄████████    ▄███████▄    ▄████████    ▄████████     ███        ▄████████ ████████▄  ███    █▄  ███▄▄▄▄      ▄██████▄     ▄████████  ▄██████▄  ███▄▄▄▄   ");
        Console.WriteLine("  ███    ███   ███    ███   ███    ███   ███    ███ ▀█████████▄   ███    ███ ███   ▀███ ███    ███ ███▀▀▀██▄   ███    ███   ███    ███ ███    ███ ███▀▀▀██▄ ");
        Console.WriteLine("  ███    █▀    ███    ███   ███    ███   ███    ███    ▀███▀▀██   ███    ███ ███    ███ ███    ███ ███   ███   ███    █▀    ███    █▀  ███    ███ ███   ███ ");
        Console.WriteLine("  ███          ███    ███   ███    ███  ▄███▄▄▄▄██▀     ███   ▀   ███    ███ ███    ███ ███    ███ ███   ███  ▄███         ▄███▄▄▄     ███    ███ ███   ███ ");
        Console.WriteLine(" ▀███████████ ▀█████████▀  ▀███████████ ▀▀███▀▀▀▀▀       ███     ▀███████████ ███    ███ ███    ███ ███   ███ ▀▀███ ████▄  ▀▀███▀▀▀     ███    ███ ███   ███ ");
        Console.WriteLine("           ███   ███          ███    ███ ▀███████████     ███       ███    ███ ███    ███ ███    ███ ███   ███   ███    ███   ███    █▄  ███    ███ ███   ███ ");
        Console.WriteLine("      ▄█    ███   ███          ███    ███   ███    ███     ███       ███    ███ ███   ▄███ ███    ███ ███   ███   ███    ███   ███    ███ ███    ███ ███   ███ ");
        Console.WriteLine("     ▄████████▀   ▄████▀        ███    █▀    ███    ███    ▄████▀     ███    █▀  ████████▀  ████████▀   ▀█   █▀    ████████▀    ██████████  ▀██████▀   ▀█   █▀  ");
        Console.WriteLine("                               ███    ███                                                                                                         ");
        Console.ReadKey();
        NameOption();

    }
    static void GameDataSetting()
    {

        // 캐릭터 정보 세팅
        
        player = new Character("chad", "전사", 1, 10, 5, 100, 1500, 100);

        // 아이템 정보 세팅
        Item item1 = new Item("낡은검", "공격력", 2, "맨손보다는 조금 나은 낡은 검");
        Item item2 = new Item("무쇠갑옷", "방어력", 5, "무쇠로 만든 무거운 갑옷");
        Item item3 = new Item("가죽모자", "Hp", 10, "평범한 가죽모자");

        inventory.Add(item1);
        inventory.Add(item2);
        inventory.Add(item3);

        Monster monster1 = new Monster("슬라임", 1, 10, 3, 30, 30);
        Monster monster2 = new Monster("고블린", 2, 13, 6, 50, 50);
        Monster monster3 = new Monster("오크", 3, 20, 8, 80, 80);

        monsters.Add(monster1);
        monsters.Add(monster2);
        monsters.Add(monster3);
    }

    static void DisplayGameIntro()
    {
        Console.Clear();

        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("1. 상태보기");
        Console.WriteLine("2. 인벤토리");
        Console.WriteLine("3. 던전입장");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");

        int input = CheckValidInput(1, 3);
        switch (input)
        {
            case 1:
                DisplayMyInfo();
                break;

            case 2:
                DisplayInventory();
                break;

            case 3:
                Dungeon();
                break;

            default:
                Console.WriteLine("잘못된 입력입니다.");
                break;
        }
    }

    static void DisplayMyInfo()
    {
        Console.Clear();

        Console.WriteLine("상태보기");
        Console.WriteLine("캐릭터의 정보를 표시합니다.");
        Console.WriteLine();
        Console.WriteLine($"Lv.{player.Level}");
        Console.WriteLine($"이름:{player.Name}");
        Console.WriteLine($"직업:({player.Job})") ;
        Console.WriteLine($"공격력 :{player.Atk} ");
        Console.WriteLine($"방어력 : {player.Def} ");
        Console.WriteLine($"체력 : {player.Hp} ");
        Console.WriteLine($"Gold : {player.Gold} G");
        Console.WriteLine();
        Console.WriteLine("0. 나가기");

        int input = CheckValidInput(0, 0);
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;
        }
    }

    static void DisplayInventory()
    {
        Console.Clear();

        Console.WriteLine("인벤토리");
        Console.WriteLine("플레이어의 보유중인 아이템 목록을 표시합니다.");
        Console.WriteLine();


        foreach (Item item in inventory)
        {
            Console.Write($"{item.Name} {item.Type}+{item.Value}({item.Info})");


            Console.WriteLine();

        }
        Console.WriteLine("");
        Console.WriteLine("1. 장착관리");
        Console.WriteLine("0. 나가기");

        int input = CheckValidInput(0, 1);

        if (input == 0)
        {
            DisplayGameIntro();
        }
        else if (input == 1)
        {
            EquipOrUnequipItem();
        }
    }

    static void Incount()
    {

        Console.Clear();

        Console.WriteLine("적과 조우했습니다!");

        Console.WriteLine("1. 싸운다.");
        Console.WriteLine("0. 도망간다.");

        int input = CheckValidInput(0, 1);

        if (input == 0)
        {
            Dungeon();
        }
        else if (input == 1)
        {
            Battle();
        }


    }

    static void Battle()
    {
        Console.Clear();
        Console.WriteLine("전투시작!");

        Random random = new Random(Guid.NewGuid().GetHashCode());
        int numberOfMonsters = random.Next(1, 5);

        List<Monster> selectedMonsters = new List<Monster>();

        for (int i = 0; i < numberOfMonsters; i++)
        {
            int randomMonsterIndex = random.Next(0, monsters.Count);
            Monster selectedMonster = monsters[randomMonsterIndex];
            selectedMonsters.Add(selectedMonster);
        }

        for (int i = 0; i < selectedMonsters.Count; i++)
        {
            Monster monster = selectedMonsters[i];
            Console.WriteLine($"적 몬스터 {i + 1}: {monster.Name} 공격력:{monster.Atk} 방어력:{monster.Def} 체력:{monster.Hp}/{monster.MaxHp}");
        }

        Console.WriteLine("[내 정보]");
        Console.WriteLine($"Lv. {player.Level} {player.Name} {player.Job}");
        Console.WriteLine($"Hp {player.Hp}/{player.MaxHp}");
        Console.WriteLine();
    }
    static void EquipOrUnequipItem()
    {
        Console.Clear();
        Console.WriteLine("장착관리");
        Console.WriteLine("착용할 아이템을 선택해주세요");
        Console.WriteLine();
        int itemIndex = 1;
        foreach (Item item in inventory)
        {
            Console.Write($"{itemIndex}.{item.Name} {item.Type}+{item.Value}({item.Info})");

            if (player.EquippedItems.Contains(item))
            {
                Console.Write(" (E)");
            }

            Console.WriteLine();
            itemIndex++;
        }
        Console.WriteLine();
        Console.WriteLine("0. 인벤토리");

        int input = CheckValidInput(0, itemIndex - 1);
        if (input == 0)
        {
            DisplayInventory();
        }
        else
        {
            Item selectedInventoryItem = inventory[input - 1];
            if (player.EquippedItems.Contains(selectedInventoryItem))
            {
                player.UnequipItem(selectedInventoryItem);
                EquipOrUnequipItem();
            }
            else
            {
                player.EquipItem(selectedInventoryItem);
                EquipOrUnequipItem();
            }


        }
    }

    static int CheckValidInput(int min, int max)
    {
        while (true)
        {
            string input = Console.ReadLine();

            bool parseSuccess = int.TryParse(input, out var ret);
            if (parseSuccess)
            {
                if (ret >= min && ret <= max)
                    return ret;
            }

            Console.WriteLine("잘못된 입력입니다.");
        }
    }
}

public class Character
{
    
    public string Name { get; set; }
    public string Job { get; set; }
    public int Level { get; }
    public int Atk { get;  set; }
    public int Def { get;  set; }
    public int Hp { get;  set; }
    public int MaxHp { get; set; }
    public int Gold { get; }

    public List<Item> EquippedItems { get; } = new List<Item>();

    public Character(string name, string job, int level, int atk, int def, int hp, int gold, int maxhp)
    {
        Name = name;
        Job = job;
        Level = level;
        Atk = atk;
        Def = def;
        Hp = hp;
        Gold = gold;
        MaxHp = maxhp;
        
    }

    public void EquipItem(Item item)
    {
        EquippedItems.Add(item);
        UpdateStats();
    }

    public void UnequipItem(Item item)
    {
        EquippedItems.Remove(item);
        UpdateStats();
    }

    private void UpdateStats()
    {
        if (Job == "전사")
        {

        }
        else if(Job == "도적")
        {

        }
        else if(Job == "마법사")
        {

        }
        else if( Job == "궁수")
        {

        }
        

        foreach (Item item in EquippedItems)
        {
            if (item.Type == "공격력")
            {
                Atk += item.Value;
            }
            else if (item.Type == "방어력")
            {
                Def += item.Value;
            }
            else if (item.Type == "Hp")
            {
                Hp += item.Value;
            }

        }
    }
}

public class Item
{
    public string Name { get; }
    public string Type { get; }
    public int Value { get; }
    public string Info { get; }

    public Item(string name, string type, int value, string info)
    {
        Name = name;
        Type = type;
        Value = value;
        Info = info;
    }
}

public class Monster
{
    public string Name { get; }
    public int Level { get; }
    public int Atk { get; }
    public int Def { get; }
    public int Hp { get; }
    public int MaxHp { get; }

    public Monster(string name, int level, int atk, int def, int hp, int maxhp)
    {
        Name = name;
        Level = level;
        Atk = atk;
        Def = def;
        Hp = hp;
        MaxHp = maxhp;
    }
}