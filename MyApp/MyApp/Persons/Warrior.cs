namespace MyApp;

//персонаж Воин
public class Warrior : Person
{
    //конструктор для создания по умолчанию Воина
    public Warrior()
    {
        //присваивается навык Берсерк
        Skill = Skills.Berserk;
        //по умолчанию задаем количество жизней
        Live = 3;
        //по умолчанию задаем количество очков здоровья
        Health = 6;
        //по умолчанию задаем количество очков атаки
        AttackPoints = 2;
        //пустой список бонусных вещей
        BonusThings = new List<BonusThing>() { };
    }

    //Конструктор для создания Воина с бонусной вещью
    public Warrior(BonusThing bonusThing)
    {
        //присваивается навык Заморозка
        Skill = Skills.Berserk;
        //по умолчанию задаем количество жизней
        Live = 3;
        //по умолчанию задаем количество очков здоровья
        Health = 6;
        //по умолчанию задаем количество очков атаки
        AttackPoints = 2;
        //добавляем бронусную вещь
        BonusThings = new List<BonusThing>() { bonusThing };
    }

    //метод вызова навыка Берсерк
    public void Berserk()
    {
        this.Live--;
        this.AttackPoints++;
    }
    
    public void MakeMove(MoveType moveType, Person person)
    {
        switch (moveType)
        {
            case MoveType.Attack:
            {
                //посчитаем наши очки атаки
                var attackPoints = this.AttackPoints;
                //выберем все вещи с бонусом на атаку
                var bonusThings = this.BonusThings.Where(x => x.Property == Property.Attack);
                foreach (var bs in BonusThings)
                {
                    //добавим их бонус к нашим очкам атаки
                    attackPoints += bs.Point;

                }

                //атакуем противника, снимая из очков его здоровья 
                if (person.Health >= attackPoints)
                {
                    person.Health -= attackPoints;
                }

                //если очков здоровья не хватает - отнимаем одну жизнь
                person.Live--;
                break;
            }
            case MoveType.Skill:
            {
                //применяем метод навыка
                Berserk();
                break;
            }
            case MoveType.Pass:
            {
                //пропускаем ход, ничего не делая
                break;
            }
        }
    }
}