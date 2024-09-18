using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace c__Project
{
    public enum GameMode
    {
        None,
        Lobby,
        Town,
        Field
    }
    public class Game
    {
        public GameMode mode = GameMode.Lobby;
        private Player player = null;
        private Monster monster = null;
        private Random random = new Random();
     public void Process()
        {
            // 게임 모드가 None이 아닐 때 계속해서 진행
            while (mode != GameMode.None)
            {
                switch (mode)
                {
                    case GameMode.Lobby:
                        ProcessLobby();
                        break;
                    case GameMode.Town:
                        ProcessTown();
                        break;
                    case GameMode.Field:
                        ProcessField();
                        break;
                }
            }
        }

        public void ProcessLobby()
        {
            System.Console.WriteLine("직업을 선택하세요");
            System.Console.WriteLine("[1] 기사");
            System.Console.WriteLine("[2] 궁수");
            System.Console.WriteLine("[3] 법사");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    player = new Knight();
                    mode= GameMode.Town;
                    break;
                case "2":
                    player = new Archer();
                    mode= GameMode.Town;
                    break;
                case "3":
                    player = new Mage();
                    mode= GameMode.Town;
                    break;
                default:
                    System.Console.WriteLine("잘못된 입력");
                    break;
            }
        }
    

        public void ProcessTown(){
            System.Console.WriteLine("마을에 입장했습니다.");
            System.Console.WriteLine("[1] 필드로 돌아가기");
            System.Console.WriteLine("[1] 마을로 돌아가기");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    mode= GameMode.Field;
                    break;
                case "2":
                    mode= GameMode.Lobby;
                    break;
                default:
                    System.Console.WriteLine("잘못된 입력");
                    break;
            }
        }

        private void ProcessField(){
            System.Console.WriteLine("필드에 입장했습니다.");
            System.Console.WriteLine("[1] 싸우기");
            System.Console.WriteLine("[2] 일정확률로 마을로 도망가기");

            CreateRandomMonster();

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    PorcessFight();
                    break;
                case "2":
                    TryEscape();
                    mode= GameMode.Town;
                    break;
                default:
                    System.Console.WriteLine("잘못된 입력");
                    break;
            }

        }

        private void TryEscape()
        {
            int randValue = random.Next(0, 100);
            if(randValue < 70){
                System.Console.WriteLine("도망 성공!");
                mode= GameMode.Town;
            }else{
                System.Console.WriteLine("도망 실패!");
                PorcessFight();
            }
        }
        private void PorcessFight(){
            while(true)
            {
                int damage = player.GetAttack();
                monster.OnDamage(damage);
                if(monster.isDead()){
                    System.Console.WriteLine("승리했습니다.");
                    System.Console.WriteLine($"남은 체력: {player.GetHp()}");
                    break;
                }
                damage = monster.GetAttack();
                player.OnDamage(damage);
                if(player.isDead()){
                    System.Console.WriteLine("패배했습니다.");
                    mode = GameMode.Lobby;
                    break;
                }
            }
        }

        private void CreateRandomMonster(){
            int randValue = random.Next(0,3);

            switch(randValue)
            {
                case 0:
                    monster = new Slime();
                    System.Console.WriteLine("슬라임 생성");
                    break;
                
                case 1:
                    monster = new Orc();
                    System.Console.WriteLine("오크 생성");
                    break;

                case 2:
                    monster = new Skeleton();
                    System.Console.WriteLine("스켈레톤 생성");
                    break;
            }
        }
    }
}