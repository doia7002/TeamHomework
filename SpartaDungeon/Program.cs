﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

internal class Program
{
    private static Character player;
    private static List<Item> inventory = new List<Item>();
    private static List<Monster> monsters = new List<Monster>();
    private static List<Item> shopInventory;
    static void Main(string[] args)
    {
        GameDataSetting();
        PrintStartLogo();
        DisplayGameIntro();

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


    }
    static void GameDataSetting()
    {
        // 캐릭터 정보 세팅
        player = new Character("Chad", "전사", 1, 10, 5, 100, 1500);

        // 아이템 정보 세팅
        inventory = new List<Item>
        {
             new Item("검낡은 검", ItemType.Weapon, 5, 0, 50,"맨손보다는 조금 나은 낡은 검."),
             new Item("무쇠갑옷", ItemType.Armor, 0, 5, 30,"무쇠로 만들어져 튼튼한 갑옷입니다."),
             new Item("가죽모자", ItemType.Armor ,0, 10,10, "평범한 가죽모자"),
            // 다른 아이템 추가 가능
        };
        // 상점 아이템 정보 세팅
        shopInventory = new List<Item>
        {
            new Item("도끼", ItemType.Weapon, 8, 0, 70, "쉽게 볼 수 있는 도끼입니다."),
            new Item("플레이트 아머", ItemType.Armor, 0, 8, 100, "누구나 하나쯤 집에 있는 갑옷이다"),
            new Item("회손이 심한 단검", ItemType.Weapon, 3, 0, 100, "누군가의 유품처럼 느껴진다."),
            new Item("가고일 가죽 갑옷", ItemType.Armor, 0, 3, 150, "옆에 소가죽이라고 젹혀있다"),
            new Item("영생의 저주 카타나", ItemType.Weapon, 10, 0, 500, "베이는 순간 생명체의 생기가 흡수된다."),
            new Item("시간여행자의 과거유산", ItemType.Armor, 0, 10, 800, "무엇에 쓰이는 물건인지 모르겠다."),
            new Item("롱고미니아드", ItemType.Armor, 100, 10, 20000,"물푸레나무로 만들고 날폭이 넓다.")

            // 다른 상점 아이템 추가
        };

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
        Console.WriteLine("3. 상점");
        Console.WriteLine("4. 던전입장");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");

        int input = CheckValidInput(1, 4);
        switch (input)
        {
            case 1:
                DisplayMyInfo();
                break;

            case 2:
                DisplayInventory();
                break;
            case 3:
                DisplayShop();
                break;
            case 4:
                Dungeon();
                break;

            default:
                Console.WriteLine("잘못된 입력입니다.");
                break;
        }
    }
    static void DisplayInventory()
    {
        Console.Clear();

        Console.WriteLine("인벤토리");
        Console.WriteLine("가지고 있는 아이템을 표시합니다.");
        Console.WriteLine();

        int index = 1;
        foreach (var item in inventory)
        {
            string equippedStatus = IsEquipped(item) ? "[E] " : "";
            Console.WriteLine($"{index}. {equippedStatus}{item.Name} ({item.Type}) - 공격력: {item.Atk}, 방어력: {item.Def}");
            index++;
        }

        Console.WriteLine();
        Console.WriteLine("0. 나가기");
        Console.WriteLine("원하는 아이템을 선택해주세요.");

        int input = CheckValidInput(0, index);
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;

            default:
                EquipItem(input - 1);
                break;
        }
    }

    static void DisplayShop()
    {

        Console.Clear();

        Console.WriteLine("델피아즈상점");
        Console.WriteLine("오! 젊은친구 어서오게");
        Console.WriteLine("판매 가능한 아이템을 표시합니다.");
        Console.WriteLine();
        Console.WriteLine($"돈: {player.Gold} G");
        Console.WriteLine();

        int index = 1;
        foreach (var item in shopInventory)
        {
            Console.WriteLine($"{index}. {item.Name} ({item.Type}) - 공격력: {item.Atk}, 방어력: {item.Def} - 가격: {item.Price} G");
            index++;
        }

        Console.WriteLine();
        Console.WriteLine("0. 나가기");
        Console.WriteLine("1. 아이템 구매");
        Console.WriteLine("2. 아이템 판매");
        Console.WriteLine("3. 도둑질");

        Console.WriteLine();
        Console.WriteLine("원하는 아이템을 선택해주세요.");

        int input = CheckValidInput(0, 3);
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;
            case 1:
                BuyItem();
                break;
            case 2:
                SellItem();
                break;
            case 3:
                PerformSpecialAction(); // 특정 행동
                break;
            default:
                Console.WriteLine("");
                Console.WriteLine(".");
                Console.ReadKey();
                DisplayGameIntro();
                break;


        }



    }
    static void PerformSpecialAction()
    {
        Console.WriteLine("도둑질 중...");
        // 특정 행동에 대한 코드 작성

        Console.WriteLine("상점 주인이 지켜본다...");
        Console.ReadKey();
        DisplayShop(); // 다시 상점 메뉴로 돌아가도록 호출
    }
    static void SellItem()
    {
        Console.Clear();
        Console.WriteLine("판매 가능한 아이템 목록:");

        int index = 1;
        foreach (var item in inventory)
        {
            Console.WriteLine($"{index}. {item.Name} - 가격: {item.Price} G");
            index++;
        }

        Console.WriteLine();
        Console.WriteLine("0. 나가기");
        Console.WriteLine("판매할 아이템을 선택해주세요.");

        int input = CheckValidInput(0, index - 1);
        if (input == 0)
        {
            DisplayShop();
        }

        else
        {
            Item selected = inventory[input - 1];
            SellItem(selected);
        }
    }

    static void SellItem(Item item)
    {
        player.Gold += item.Price;
        inventory.Remove(item);


        Console.WriteLine("젊은이 내가 특별히 사주는거야 하하!!");
        Console.WriteLine($"{item.Name}을(를) 판매했습니다. 획득한 골드: {item.Price} G");
        Console.WriteLine($"현재 골드: {player.Gold} G");


        Console.WriteLine("상점으로 돌아가려면 아무 키나 눌러주세요.");
        Console.ReadKey();
        DisplayInventory();
    }

    static void BuyItem()
    {
        Console.Clear();
        Console.WriteLine("구매 가능한 아이템 목록:");

        int index = 1;
        foreach (var item in shopInventory)
        {
            Console.WriteLine($"{index}. {item.Name} - 가격: {item.Price} G");
            index++;
        }

        Console.WriteLine();
        Console.WriteLine("0. 나가기");
        Console.WriteLine("구매할 아이템을 선택해주세요.");

        int input = CheckValidInput(0, index - 1);
        if (input == 0)
        {
            DisplayShop();
        }
        else
        {
            Item selected = shopInventory[input - 1];
            BuyItem(selected);
        }
    }

    static void BuyItem(Item item)
    {
        if (player.Gold >= item.Price)
        {
            player.Gold -= item.Price;
            inventory.Add(item);

            Console.WriteLine($"{item.Name}을(를) 구매했습니다. 소모한 골드: {item.Price} G");
            Console.WriteLine($"현재 골드: {player.Gold} G");
            Console.WriteLine("내가 만든 무기와 방어구는 뭐든지 최고라고 젊은이 하하!!");

            Console.WriteLine("상점으로 돌아가려면 아무 키나 눌러주세요.");
            Console.ReadKey();
            DisplayShop();
        }
        else
        {
            Console.WriteLine("골드가 부족하구!젊은이");

            Console.WriteLine("상점으로 돌아가려면 아무 키나 눌러주세요.");
            Console.ReadKey();
            DisplayShop();
        }
    }

    static void EquipItem(int itemIndex)
    {
        Item selected = inventory[itemIndex];

        // 이미 장착 중이면 해제, 아니면 장착
        if (IsEquipped(selected))
        {
            UnequipItem(selected);
        }
        else
        {
            Equip(selected);
        }

        Console.WriteLine("인벤토리로 돌아가려면 아무 키나 눌러주세요.");
        Console.ReadKey();
        DisplayInventory();
    }

    static void Equip(Item item)
    {
        player.Atk += item.Atk;
        player.Def += item.Def;
        player.EquippedItems.Add(item);

        Console.WriteLine($"{item.Name}을(를) 장착했습니다.");
        Console.WriteLine($"새로운 능력치 - 공격력: {player.Atk}, 방어력: {player.Def}");
    }

    static void UnequipItem(Item item)
    {
        player.Atk -= item.Atk;
        player.Def -= item.Def;
        player.EquippedItems.Remove(item);

        Console.WriteLine($"{item.Name}을(를) 해제했습니다.");
        Console.WriteLine($"새로운 능력치 - 공격력: {player.Atk}, 방어력: {player.Def}");
    }

    static bool IsEquipped(Item item)
    {
        return player.EquippedItems.Contains(item);
    }
    static void DisplayMyInfo()
    {
        Console.Clear();

        Console.WriteLine("상태보기");
        Console.WriteLine("캐릭터의 정보를 표시합니다.");
        Console.WriteLine();
        Console.WriteLine($"Lv.{player.Level}");
        Console.WriteLine($"{player.Name}({player.Job})");
        Console.WriteLine($"공격력 :{player.Atk} (+{player.Atk - 10})");
        Console.WriteLine($"방어력 : {player.Def} (+{player.Def - 5})");
        Console.WriteLine($"체력 : {player.Hp} (+{player.Hp - 100})");
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
            int randomMonsterIndex = new Random().Next(0, monsters.Count);
            Monster selectedMonster = monsters[randomMonsterIndex];
            Battle(selectedMonster);
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

        Console.WriteLine();
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
    static void Battle(Monster monster)
    {
        Console.Clear();
        Console.WriteLine("전투시작!");
        Console.WriteLine();
        // 전투 로직 구성
        while (player.Hp > 0 && monster.Hp > 0)
        {
            Console.WriteLine("플레이어의 차례");
            Console.WriteLine("1.공격");
            Console.WriteLine("2.아이템");
            Console.WriteLine("3.칭찬하기");
            Console.WriteLine();

            int playerChiose = CheckValidInput(1, 3);
            switch (playerChiose)
            {
                case 1:
                    int PalyerDamage = Damage(player.Atk);
                    monster.Hp -= PalyerDamage;
                    Console.WriteLine($"플레이어가 {monster.Name}에게{PalyerDamage}의 피해를 주었습니다.");
                    break;
                case 2:
                    Console.WriteLine("공사중...회복물약");
                    break;
                case 3:
                    Console.WriteLine("공사중...특정행동");
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine(".");
                    Console.ReadKey();
                    break;

            }

            Console.WriteLine("상대의 차례");
            int MonsterDamage = Damage(monster.Atk);
            player.Hp -= MonsterDamage;
            Console.WriteLine($"{monster.Name}이(가) 플레이어에게 {MonsterDamage}를(을) 피해를 주었습니다");

            Console.WriteLine($"플레이어 체력{player.Hp}");
            Console.WriteLine($"{monster.Name} 체력 {monster.Hp}");
        }
        if (player.Hp <= 0)
        {
            Console.WriteLine("패배했습니다. 게임 오버!");
            // 게임 오버 로직 추가
        }
        else
        {
            Console.WriteLine($"승리했습니다! {monster.Name}을(를) 처치했습니다.");
            // 전투 이후 로직 추가
        }
    }
    static int Damage(int AttckerAttack)
    {
        Random random = new Random();
        int damage = random.Next(AttckerAttack / 2, AttckerAttack + 1);
        return damage;
    }
}

public class Character
{
    public string Name { get; }
    public string Job { get; }
    public int Level { get; }
    public int Atk { get; set; }
    public int Def { get; set; }
    public int Hp { get; set; }
    public int Gold { get; set; }
    public List<Item> EquippedItems { get; } = new List<Item>();

    public Character(string name, string job, int level, int atk, int def, int hp, int gold)
    {
        Name = name;
        Job = job;
        Level = level;
        Atk = atk;
        Def = def;
        Hp = hp;
        Gold = gold;
    }
}
public enum ItemType
{
    Weapon,
    Armor,
    // 다른 아이템 타입 추가 가능
}
public class Item
{
    public string Name { get; }
    public ItemType Type { get; }
    public int Atk { get; }
    public int Def { get; }
    public int Price { get; }
    public string Explanation { get; }

    public Item(string name, ItemType type, int atk, int def, int price, string explanation)
    {
        Name = name;
        Type = type;
        Atk = atk;
        Def = def;
        Price = price;
        Explanation = explanation;
    }
}

public class Monster
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int Atk { get; set; }
    public int Def { get; set; }
    public int Hp { get; set; }
    public int MaxHp { get; set; }

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