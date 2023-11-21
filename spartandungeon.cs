namespace sample3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.ComponentModel;

    internal class Program
    {
        private static Character player;
        private static List<Item> inventory = new List<Item>();
        private static List<Monster> monster;
        private static List<Item> shopInventory;
        private static int currentFloor = 1;
        static void Main(string[] args)
        {
            GameDataSetting();
            PrintStartLogo();
            DisplayGameIntro();

        }
        public static void NameOption()//인호님 파트 시작
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
            switch (input)
            {
                case 1:

                    if (input == 1)
                    {
                        player.Job = "전사";
                        player.MaxHp = 120;
                        player.Hp = 120;
                        player.Atk = 8;
                        player.Def = 10;
                    }
                    break;

                case 2:

                    if (input == 2)
                    {
                        player.Job = "도적";
                        player.MaxHp = 100;
                        player.Hp = 100;
                        player.Atk = 10;
                        player.Def = 7;
                    }
                    break;
                case 3:

                    if (input == 3)
                    {
                        player.Job = "마법사";
                        player.MaxHp = 70;
                        player.Hp = 70;
                        player.Atk = 15;
                        player.Def = 2;
                    }
                    break;
                case 4:

                    if (input == 4)
                    {
                        player.Job = "궁수";
                        player.MaxHp = 90;
                        player.Hp = 90;
                        player.Atk = 13;
                        player.Def = 5;
                    }
                    break;
                    
            }//인호님 파트
            DisplayGameIntro();
        }

        static void Dungeon()
        {
            Console.Clear();
            Console.WriteLine($"던전 {currentFloor}층에 들어왔습니다.");
            Console.WriteLine("1. 계속하기" + $"(현재 진행: {currentFloor}층)");
            Console.WriteLine("0. 나가기");

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
            player = new Character("Chad", "전사", 1, 10, 5, 100, 3, 1500);

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
            new Item("롱고미니아드", ItemType.Armor, 100, 10, 20000,"물푸레나무로 만들고 날폭이 넓다."),
            new Item("엑스칼리버", ItemType.Armor, 10000, 10, 1200,"이 칼의 가진자는 왕이 될 자격이 있는자.")

            // 다른 상점 아이템 추가
        };
            monster = new List<Monster>
        {


          new Monster("슬라임", 1, 10, 3, 30, 30 ,"일반"),
          new Monster("고블린", 2, 13, 6, 50, 50, "일반"),
          new Monster("오크", 3, 20, 8, 80, 80, "일반"),
          new Monster("악어", 3, 20, 8, 40, 40, "일반")
        };

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

                // 상점에 아이템 등록
                shopInventory.Add(selected);
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
            SellItem();
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

                // 상점 목록에서 아이템 제거
                shopInventory.Remove(item);

                Console.WriteLine("상점으로 돌아가려면 아무 키나 눌러주세요.");
                Console.ReadKey();
                DisplayShop();
            }
            else
            {
                Console.WriteLine("골드가 부족하구! 젊은이");

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
            Console.WriteLine($"던전 {currentFloor}층 몬스터들이 나타났습니다!");

            // 랜덤으로 1~4마리 몬스터 선택
            int numberMonsters = new Random().Next(1, 5);

            List<Monster> selectedMonsters = new List<Monster>();

            Console.WriteLine($"등장한 몬스터 수: {numberMonsters}");
            Console.WriteLine("------------------------------");

            // 각 몬스터의 정보를 표시하고 선택
            for (int i = 0; i < numberMonsters; i++)
            {
                int randomMonsterIndex = new Random().Next(0, monster.Count);
                Monster selectedMonster = monster[randomMonsterIndex];
                selectedMonsters.Add(selectedMonster);
                if (currentFloor > 1)
                    Console.WriteLine($"[{i + 1}] {selectedMonster.Name} (Lv.{selectedMonster.Level}) - 공격력: {selectedMonster.Atk + (selectedMonster.Atk * currentFloor * 0.2)}, 방어력: {selectedMonster.Def + (selectedMonster.Def * currentFloor * 0.2)}, 체력: {selectedMonster.Hp + (selectedMonster.Hp * currentFloor * 0.2)}/{selectedMonster.MaxHp + (selectedMonster.MaxHp * currentFloor * 0.2)}, 계급: {selectedMonster.Class}");
                else Console.WriteLine($"[{i + 1}] {selectedMonster.Name} (Lv.{selectedMonster.Level}) - 공격력: {selectedMonster.Atk}, 방어력: {selectedMonster.Def}, 체력: {selectedMonster.Hp}/{selectedMonster.MaxHp}, 계급: {selectedMonster.Class}");
            }

            Console.WriteLine("------------------------------");

            // 선택지 동적 생성
            for (int i = 0; i < numberMonsters; i++)
            {
                Console.WriteLine($"{i + 1}. 전투 시작");
            }

            Console.WriteLine("0. 도망간다.");

            int input = CheckValidInput(0, numberMonsters);

            switch (input)
            {
                case 0:
                    Dungeon();
                    break;
                default:
                    Battle(selectedMonsters[input - 1], selectedMonsters);
                    break;
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
        static void Battle(Monster monster, List<Monster> allMonsters)
        {
            Console.Clear();
            Console.WriteLine($"전투 시작! 상대 몬스터: {monster.Name} (Lv.{monster.Level})");
            Console.WriteLine($"공격력: {monster.Atk}  방어력: {monster.Def}  체력: {monster.Hp}/{monster.MaxHp}");
            Console.WriteLine();
            // 전투 로직 구성

            while (player.Hp > 0 && monster.Hp > 0)
            {
                Console.WriteLine("플레이어의 차례");
                Console.WriteLine("1.공격");
                Console.WriteLine("2.스킬");
                Console.WriteLine("3.칭찬하기");
                Console.WriteLine();

                int playerChiose = CheckValidInput(1, 3);
                switch (playerChiose)
                {
                    case 1:
                        int PalyerDamage = Damage(player.Atk - (monster.Def / 2));
                        monster.Hp -= PalyerDamage;
                        Console.WriteLine($"플레이어가 {monster.Name}에게{PalyerDamage}의 피해를 주었습니다.");
                        break;
                    case 2:
                        Console.WriteLine("스킬포인트를 소모하여 스킬을 사용할수 있습니다");
                        Console.WriteLine("1.강격:스킬포인트를 2소모하여 강력한 공격을 가합니다.");
                        Console.WriteLine("2.찌르고비틀기:스킬포인트를 1소모하여 출혈을 가합니다.");
                        Console.WriteLine("3.방어태세:스킬포인트를 1소모하여 방어력을 올립니다.");
                        Console.WriteLine("");
                        int input = CheckValidInput(1, 4);
                        if (player.Sp>0 && input * 1 == 1)
                        {
                            int Skill1 = 2 * Damage(player.Atk);
                            monster.Hp -= Skill1;
                            player.Sp -= 2;
                            Console.WriteLine($"플레이어가 {monster.Name}에게 강격을 시전했습니다. {Skill1}만큼의 피해를 주었습니다.");
                        }
                        else if (input * 1 == 2)
                        {
                            int Skill2 = Damage(player.Atk);
                            monster.Hp -= Skill2;
                            player.Sp -= 1;
                            Console.WriteLine($"플레이어가 {monster.Name}에게 비틀어찌르기를 시전했습니다. {Skill2}만큼의 피해를 주었습니다");
                        }
                        else if (input * 1 == 3)
                        {
                            int Skill3 = 2 * player.Def;
                            player.Def += Skill3;
                            player.Sp -= 1;
                            Console.WriteLine($"플레이어가 방패를 올려 {Skill3}만큼 방어력이 상승했습니다.");
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.");
                        }

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
                int MonsterDamage = Damage(monster.Atk - (player.Def / 2));
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
                monster.IsDead = true;
                monster.Hp = 0;

                // 현재 층의 몬스터를 체크
                if (allMonsters.All(m => m.IsDead))
                {
                    Console.WriteLine($"던전 {currentFloor}층을 클리어하였습니다!");

                    // 다음 층으로 이동
                    currentFloor++;
                    ResetMonsters();
                    Console.WriteLine("다음 층으로 이동합니다. 아무 키나 눌러주세요.");
                    Console.ReadKey();

                    // 이동한 층에서 몬스터 다시 생성
                    Incount();
                }
                else
                {
                    // 전투 이후 로직 추가
                    Console.WriteLine("다른 적과의 전투를 시작하려면 아무 키나 눌러주세요.");
                    Console.ReadKey();
                    Incount();
                }
            }
        }
        static void ResetMonsters()
        {
            // 각 몬스터의 상태를 리셋
            foreach (var m in monster)
            {
                m.Hp = m.MaxHp;
                m.IsDead = false;
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
        public string Name { get; set; }
        public string Job { get; set; }
        public int Level { get; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public int Sp { get; set; }
        public int Gold { get; set; }
        public List<Item> EquippedItems { get; } = new List<Item>();

        public Character(string name, string job, int level, int atk, int def, int hp, int sp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Sp = sp;
            Gold = gold;
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
            else if (Job == "도적")
            {

            }
            else if (Job == "마법사")
            {

            }
            else if (Job == "궁수")
            {

            }


            foreach (Item item in EquippedItems)
            {
                if (item.Atk>0)
                {
                    Atk += item.Atk;
                }
                else if (item.Def>0)
                {
                    Def += item.Def;
                }
                

            }
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
        public string Class { get; set; }
        public bool IsDead { get; set; }

        public Monster(string name, int level, int atk, int def, int hp, int maxhp, string monsterClass)
        {
            Name = name;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            MaxHp = maxhp;
            Class = monsterClass;//적들의 등급표시
            IsDead = false;//Hp가 0이되면 활성화
        }
    }
}
